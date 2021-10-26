using UnityEngine;

public class EmergencyShowerScript : MonoBehaviour
{
	public FoldedUniformScript CleanUniform;

	public SkinnedMeshRenderer Curtain;

	public TallLockerScript TallLocker;

	public GameObject CensorSteam;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform BatheSpot;

	public float OpenValue;

	public float Timer;

	public int Phase = 1;

	public bool Bathing;

	public AudioSource MyAudio;

	public AudioClip CurtainClose;

	public AudioClip CurtainOpen;

	public AudioClip ClothRustle;

	private void Update()
	{
		if (Yandere.Bloodiness > 0f && Yandere.PickUp != null && Yandere.PickUp.Clothing && !Yandere.PickUp.Evidence && Yandere.PickUp.Gloves == null)
		{
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (!Yandere.Chased && Yandere.Chasers == 0)
				{
					Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
					Yandere.CannotBeSprayed = true;
					Yandere.CanMove = false;
					CleanUniform = Yandere.PickUp.gameObject.GetComponent<FoldedUniformScript>();
					Yandere.EmptyHands();
					CleanUniform.transform.position = new Vector3(26.25f, 5f, -8f);
					AudioSource.PlayClipAtPoint(CurtainClose, base.transform.position);
					Bathing = true;
					Phase = 1;
					Timer = 0f;
				}
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
		}
		if (!Bathing)
		{
			return;
		}
		Timer += Time.deltaTime;
		if (Phase == 1)
		{
			Yandere.MoveTowardsTarget(BatheSpot.position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, BatheSpot.rotation, 10f * Time.deltaTime);
			OpenValue = Mathf.Lerp(OpenValue, 0f, Time.deltaTime * 10f);
			Curtain.SetBlendShapeWeight(1, OpenValue);
			if (Timer > 1f)
			{
				PickUpScript component;
				if (Yandere.ClubAttire)
				{
					component = Object.Instantiate(TallLocker.BloodyClubUniform[(int)Yandere.Club], new Vector3(25.75f, 5f, -8f), Quaternion.identity).GetComponent<PickUpScript>();
					Yandere.StudentManager.ChangingBooths[(int)Yandere.Club].CannotChange = true;
					Yandere.StudentManager.ChangingBooths[(int)Yandere.Club].CheckYandereClub();
				}
				else
				{
					component = Object.Instantiate(TallLocker.BloodyUniform[Yandere.Schoolwear], new Vector3(25.75f, 5f, -8f), Quaternion.identity).GetComponent<PickUpScript>();
				}
				AudioSource.PlayClipAtPoint(ClothRustle, base.transform.position);
				if (Yandere.RedPaint)
				{
					component.RedPaint = true;
				}
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (Timer > 2f)
			{
				CensorSteam.SetActive(value: true);
				MyAudio.Play();
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			if (Timer > 6.5f)
			{
				CleanUniform.Prompt.Hide();
				Object.Destroy(CleanUniform.gameObject);
				Yandere.StudentManager.NewUniforms--;
				Yandere.ClubAttire = false;
				Yandere.Schoolwear = 1;
				Yandere.ChangeSchoolwear();
				Yandere.Bloodiness = 0f;
				AudioSource.PlayClipAtPoint(ClothRustle, base.transform.position);
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			if (Timer > 7.5f)
			{
				AudioSource.PlayClipAtPoint(CurtainOpen, base.transform.position);
				Phase++;
			}
		}
		else
		{
			OpenValue = Mathf.Lerp(OpenValue, 100f, Time.deltaTime * 10f);
			Curtain.SetBlendShapeWeight(1, OpenValue);
			if (Timer > 8.5f)
			{
				CensorSteam.SetActive(value: false);
				Yandere.CannotBeSprayed = false;
				Yandere.CanMove = true;
				Bathing = false;
			}
		}
	}
}
