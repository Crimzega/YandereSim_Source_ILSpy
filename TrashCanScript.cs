using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
	public WeaponScript ConcealedWeapon;

	public ContainerScript Container;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform TrashPosition;

	public Rigidbody MyRigidbody;

	public GameObject Item;

	public bool Occupied;

	public bool Wearable;

	public bool Weapon;

	public float KinematicTimer;

	private void Update()
	{
		if (!Occupied)
		{
			if (Prompt.HideButton[0])
			{
				if (Yandere.Armed)
				{
					UpdatePrompt();
				}
			}
			else
			{
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					Prompt.Circle[0].fillAmount = 1f;
					if (Yandere.PickUp != null)
					{
						Item = Yandere.PickUp.gameObject;
						Yandere.MyController.radius = 0.5f;
						Yandere.EmptyHands();
					}
					else
					{
						ConcealedWeapon = Yandere.EquippedWeapon;
						Item = Yandere.EquippedWeapon.gameObject;
						Yandere.DropTimer[Yandere.Equipped] = 0.5f;
						Yandere.DropWeapon(Yandere.Equipped);
						Weapon = true;
					}
					Item.transform.parent = TrashPosition;
					Item.GetComponent<Rigidbody>().useGravity = false;
					Item.GetComponent<Collider>().enabled = false;
					Item.GetComponent<PromptScript>().Hide();
					Item.GetComponent<PromptScript>().enabled = false;
					Occupied = true;
					UpdatePrompt();
				}
				if (!Yandere.Armed)
				{
					UpdatePrompt();
				}
			}
		}
		else if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			Item.GetComponent<PromptScript>().Circle[3].fillAmount = -1f;
			Item.GetComponent<PromptScript>().enabled = true;
			Item = null;
			Occupied = false;
			Weapon = false;
			UpdatePrompt();
		}
		if (Item != null)
		{
			if (Weapon)
			{
				if (ConcealedWeapon != null && ConcealedWeapon.WeaponID == 23)
				{
					if (Wearable)
					{
						Item.transform.localPosition = new Vector3(-0.05f, 0.25f, 0.0066666f);
						Item.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
						Item.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
					}
					else
					{
						Item.transform.localPosition = new Vector3(-0.1f, 0.29f, 0f);
						Item.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
					}
				}
				else
				{
					Item.transform.localPosition = new Vector3(0f, 0.29f, 0f);
					Item.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
				}
				if (Item.transform.parent != TrashPosition)
				{
					Item = null;
					Weapon = false;
				}
			}
			else
			{
				Item.transform.localPosition = new Vector3(0f, 0f, -0.021f);
				Item.transform.localEulerAngles = Vector3.zero;
			}
		}
		if (!Wearable)
		{
			return;
		}
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.Circle[3].fillAmount = 1f;
			base.transform.parent = Prompt.Yandere.Backpack;
			base.transform.localPosition = Vector3.zero;
			base.transform.localEulerAngles = new Vector3(90f, -154f, 0f);
			Prompt.Yandere.Container = Container;
			Prompt.Yandere.WeaponMenu.UpdateSprites();
			Prompt.MyCollider.enabled = false;
			Prompt.Hide();
			Prompt.enabled = false;
			Rigidbody component = GetComponent<Rigidbody>();
			component.isKinematic = true;
			component.useGravity = false;
		}
		if (!MyRigidbody.isKinematic)
		{
			KinematicTimer = Mathf.MoveTowards(KinematicTimer, 5f, Time.deltaTime);
			if (KinematicTimer == 5f)
			{
				MyRigidbody.isKinematic = true;
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -71f && base.transform.position.x < -61f && base.transform.position.z > -37.5f && base.transform.position.z < -27.5f)
			{
				Yandere.NotificationManager.CustomText = "You can't drop that there!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				base.transform.position = new Vector3(-63f, 1f, -26.5f);
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -21f && base.transform.position.x < 21f && base.transform.position.z > 100f && base.transform.position.z < 135f)
			{
				base.transform.position = new Vector3(0f, 1f, 100f);
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -46f && base.transform.position.x < -18f && base.transform.position.z > 66f && base.transform.position.z < 78f)
			{
				base.transform.position = new Vector3(-16f, 5f, 72f);
				KinematicTimer = 0f;
			}
		}
	}

	public void UpdatePrompt()
	{
		if (!Occupied)
		{
			if (Yandere.Armed)
			{
				Prompt.Label[0].text = "     Insert";
				Prompt.HideButton[0] = false;
			}
			else if (Yandere.PickUp != null)
			{
				if (!Yandere.PickUp.Bucket)
				{
					if (Yandere.PickUp.Evidence || Yandere.PickUp.Suspicious)
					{
						Prompt.Label[0].text = "     Insert";
						Prompt.HideButton[0] = false;
					}
					else
					{
						Prompt.HideButton[0] = true;
					}
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
		}
		else
		{
			Prompt.Label[0].text = "     Remove";
			Prompt.HideButton[0] = false;
		}
	}
}
