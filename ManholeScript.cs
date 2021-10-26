using UnityEngine;

public class ManholeScript : MonoBehaviour
{
	public GameObject BigSewerWaterSplash;

	public GameObject SewerCamera;

	public RagdollScript Corpse;

	public PromptScript Prompt;

	public AudioClip MoveCover;

	public float AnimateTimer;

	public float SewerTimer;

	public bool Open;

	private void Update()
	{
		if (!Open)
		{
			if (Prompt.Yandere.EquippedWeapon != null)
			{
				if (Prompt.Yandere.EquippedWeapon.WeaponID == 19 || Prompt.Yandere.EquippedWeapon.WeaponID == 29)
				{
					if (Prompt.Yandere.EquippedWeapon.WeaponID == 19)
					{
						Prompt.Text[0] = "Use Crowbar";
					}
					else
					{
						Prompt.Text[0] = "Use Tool";
					}
					if (Prompt.Circle[0].fillAmount == 0f)
					{
						Prompt.Text[0] = "Dump Body";
						AudioSource.PlayClipAtPoint(MoveCover, base.transform.position);
						AnimateTimer = 1f;
						Open = true;
					}
				}
				else
				{
					Prompt.Text[0] = "Need Crowbar or Manhole Tool";
				}
			}
			else
			{
				Prompt.Text[0] = "Need Crowbar or Manhole Tool";
			}
			Prompt.Label[0].text = "     " + Prompt.Text[0];
			return;
		}
		if (AnimateTimer > 0f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(34.1f, 0f, 24.1f), Time.deltaTime);
			AnimateTimer -= Time.deltaTime;
		}
		if (SewerTimer > 0f)
		{
			if (Corpse.Student.Hips.transform.position.y < -5f)
			{
				if (Corpse.Student.Hips.transform.position.y > -5f)
				{
					Corpse.Student.Hips.transform.position = new Vector3(Corpse.Student.Hips.transform.position.x, -5f, Corpse.Student.Hips.transform.position.z);
				}
				if (Corpse.AllRigidbodies[0].useGravity)
				{
					Object.Instantiate(BigSewerWaterSplash, Corpse.Student.Hips.transform.position, Quaternion.identity).transform.eulerAngles = new Vector3(-90f, 0f, 0f);
					for (int i = 0; i < Corpse.AllRigidbodies.Length; i++)
					{
						Corpse.AllRigidbodies[i].useGravity = false;
					}
				}
				Corpse.AllRigidbodies[0].AddForce(new Vector3(-100f, -50f, 0f));
			}
			SewerTimer -= Time.deltaTime;
			if (SewerTimer <= 0f)
			{
				Prompt.Yandere.Police.Corpses--;
				Corpse.gameObject.SetActive(value: false);
				Corpse.Disposed = true;
				if (Corpse.StudentID == Prompt.Yandere.StudentManager.RivalID)
				{
					Debug.Log("Just dumped Osana's corpse into the sewer.");
					Prompt.Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
				}
				SewerCamera.SetActive(value: false);
				Prompt.Yandere.StudentManager.UpdateStudents();
			}
		}
		if (Prompt.Yandere.Ragdoll != null)
		{
			Prompt.Label[0].text = "     Dump Body";
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Corpse = Prompt.Yandere.Ragdoll.GetComponent<RagdollScript>();
				Prompt.Yandere.EmptyHands();
				Corpse.Student.Hips.transform.position = base.transform.position + new Vector3(0f, -1f, 0f);
				Corpse.BloodPoolSpawner.enabled = false;
				Physics.SyncTransforms();
				SewerCamera.SetActive(value: true);
				SewerTimer = 5f;
			}
		}
		else if ((Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.Evidence) || (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.Evidence) || (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.ConcealedBodyPart))
		{
			Prompt.Label[0].text = "     Dump Evidence";
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount != 0f)
			{
				return;
			}
			if (Prompt.Yandere.Armed)
			{
				WeaponScript equippedWeapon = Prompt.Yandere.EquippedWeapon;
				Prompt.Yandere.EmptyHands();
				Prompt.Yandere.Police.BloodyWeapons--;
				Object.Destroy(equippedWeapon.gameObject);
				return;
			}
			PickUpScript pickUp = Prompt.Yandere.PickUp;
			Prompt.Yandere.EmptyHands();
			if (pickUp.Clothing)
			{
				Prompt.Yandere.Police.BloodyClothing--;
			}
			if (pickUp.ConcealedBodyPart)
			{
				Prompt.Yandere.Police.BodyParts--;
			}
			Object.Destroy(pickUp.gameObject);
		}
		else
		{
			Prompt.HideButton[0] = true;
		}
	}
}
