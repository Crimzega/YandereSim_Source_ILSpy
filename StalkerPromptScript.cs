using UnityEngine;
using UnityEngine.SceneManagement;

public class StalkerPromptScript : MonoBehaviour
{
	public StalkerPromptScript ExitPrompt;

	public FamilyVoiceScript FatherVoice;

	public StalkerYandereScript Yandere;

	public SmoothLookAtScript Cat;

	public StalkerScript Stalker;

	public GameObject DomesticDispute;

	public GameObject StairBlocker;

	public GameObject CatPrompt;

	public GameObject FrontDoor;

	public GameObject Button;

	public GameObject Father;

	public GameObject Mother;

	public GameObject Lights;

	public GameObject Fire;

	public UILabel BagsToBurnLabel;

	public UILabel Label;

	public Transform KitchenDoor;

	public Transform CatCage;

	public Transform Door;

	public AudioSource FireAudio;

	public AudioSource MyAudio;

	public AudioClip SwingOpen;

	public AudioClip PowerDown;

	public UISprite MySprite;

	public Renderer Darkness;

	public bool ServedPurpose;

	public bool Eighties;

	public bool OpenDoor;

	public bool FadeOut;

	public bool Open;

	public float TargetRotation = 5.5f;

	public float MinimumDistance = 2f;

	public float Rotation;

	public float Alpha;

	public float Speed;

	public int BagsToBurn;

	public int BagID;

	public int ID;

	private void Start()
	{
		Eighties = GameGlobals.Eighties;
		if (!Eighties)
		{
			return;
		}
		if (ID == 1)
		{
			if (BagID > DateGlobals.Week)
			{
				base.gameObject.SetActive(value: false);
			}
		}
		else
		{
			BagsToBurn = DateGlobals.Week;
			BagsToBurnLabel.text = "BAGS TO BURN: " + BagsToBurn;
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		base.transform.LookAt(Yandere.MainCamera.transform);
		if (Vector3.Distance(base.transform.position, Yandere.transform.position) < 5f)
		{
			if (!ServedPurpose)
			{
				if (Vector3.Distance(base.transform.position, Yandere.transform.position) < MinimumDistance)
				{
					Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime);
				}
				else
				{
					Alpha = Mathf.MoveTowards(Alpha, 0.5f, Time.deltaTime);
				}
			}
			else
			{
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
			}
			if (Vector3.Distance(base.transform.position, Yandere.transform.position) < MinimumDistance && !ServedPurpose && Input.GetButtonDown("A"))
			{
				if (!Eighties)
				{
					if (ID == 1)
					{
						Yandere.MyAnimation.CrossFade("f02_climbTrellis_00");
						CatPrompt.SetActive(value: true);
						Yandere.Climbing = true;
						Yandere.CanMove = false;
						Object.Destroy(base.gameObject);
						Object.Destroy(MySprite);
					}
					else if (ID == 2)
					{
						CatPrompt.SetActive(value: true);
						Stalker.enabled = true;
						ServedPurpose = true;
						OpenDoor = true;
						MyAudio.Play();
					}
					else if (ID == 3)
					{
						BeginCarryingCat();
						Door.transform.localEulerAngles = Vector3.zero;
						KitchenDoor.localEulerAngles = new Vector3(0f, 180f, 0f);
						Father.SetActive(value: false);
						Mother.SetActive(value: false);
						DomesticDispute.SetActive(value: true);
						StairBlocker.SetActive(value: true);
						FrontDoor.SetActive(value: true);
						Cat.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						Cat.enabled = false;
						MyAudio.Play();
						base.gameObject.SetActive(value: false);
						Object.Destroy(MySprite);
						Stalker.Limit = 10;
					}
					else if (ID == 4)
					{
						CatCage.gameObject.SetActive(value: true);
						ServedPurpose = true;
						OpenDoor = true;
						MyAudio.Play();
					}
					else if (ID == 5)
					{
						Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
						Yandere.CanMove = false;
						ServedPurpose = true;
						OpenDoor = true;
						MyAudio.Play();
					}
					else if (ID == 6)
					{
						if (!Open)
						{
							MyAudio.clip = SwingOpen;
							MyAudio.Play();
							Label.text = "Sabotage";
							Open = true;
						}
						else
						{
							FatherVoice.MyAnimation.CrossFade("walkConfident_00");
							FatherVoice.Investigating = true;
							AudioSource.PlayClipAtPoint(PowerDown, Camera.main.transform.position);
							Lights.SetActive(value: false);
							ServedPurpose = true;
						}
					}
				}
				else if (ID == 1)
				{
					ExitPrompt.CountBags();
					Fire.SetActive(value: true);
					ServedPurpose = true;
					MyAudio.Play();
				}
				else if (ID == 2)
				{
					Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
					BagsToBurnLabel.gameObject.SetActive(value: false);
					Yandere.CanMove = false;
					ServedPurpose = true;
					FadeOut = true;
					MyAudio.Play();
				}
			}
		}
		else
		{
			if (!Eighties && (ID == 1 || ID == 6) && Yandere.transform.position.x > -11f && Yandere.transform.position.x < 11f && Yandere.transform.position.z > -11f && Yandere.transform.position.z < 11f)
			{
				if (ID == 1)
				{
					CatPrompt.SetActive(value: true);
				}
				ServedPurpose = true;
			}
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
		}
		if (Label != null && Door != null)
		{
			if (Open)
			{
				Door.transform.localEulerAngles = Vector3.Lerp(Door.transform.localEulerAngles, new Vector3(Door.transform.localEulerAngles.x, 180f, Door.transform.localEulerAngles.z), Time.deltaTime * 10f);
			}
			else
			{
				Door.transform.localEulerAngles = Vector3.Lerp(Door.transform.localEulerAngles, new Vector3(Door.transform.localEulerAngles.x, 0f, Door.transform.localEulerAngles.z), Time.deltaTime * 10f);
			}
		}
		if (OpenDoor)
		{
			Speed += Time.deltaTime * 0.1f;
			Rotation = Mathf.Lerp(Rotation, TargetRotation, Time.deltaTime * Speed);
			Door.transform.localEulerAngles = new Vector3(Door.transform.localEulerAngles.x, Rotation, Door.transform.localEulerAngles.z);
			if (ID == 5)
			{
				Darkness.material.color = new Color(0f, 0f, 0f, Darkness.material.color.a + Time.deltaTime * 0.33333f);
				if (Darkness.material.color.a >= 1f)
				{
					EventGlobals.OsanaConversation = true;
					SceneManager.LoadScene("PhoneScene");
				}
			}
		}
		if (FadeOut)
		{
			Darkness.material.color = new Color(0f, 0f, 0f, Darkness.material.color.a + Time.deltaTime * 0.33333f);
			MyAudio.volume -= Time.deltaTime;
			if (Darkness.material.color.a >= 1f)
			{
				SceneManager.LoadScene("LivingRoomScene");
			}
		}
		if (FireAudio != null)
		{
			if (Yandere.transform.position.y < 1f)
			{
				FireAudio.volume = 0f;
			}
			else
			{
				FireAudio.volume = 1f;
			}
		}
		MySprite.color = new Color(1f, 1f, 1f, Alpha);
	}

	public void BeginCarryingCat()
	{
		Yandere.MyAnimation["f02_grip_00"].layer = 1;
		Yandere.MyAnimation.Play("f02_grip_00");
		Yandere.Object = CatCage;
		CatCage.parent = Yandere.RightHand;
		CatCage.localEulerAngles = new Vector3(0f, 0f, 0f);
		CatCage.localPosition = new Vector3(0.075f, -0.025f, 0.0125f);
		CatCage.GetComponent<Rigidbody>().isKinematic = true;
		CatCage.GetComponent<Rigidbody>().useGravity = false;
		CatCage.GetComponent<Collider>().isTrigger = true;
	}

	public void CountBags()
	{
		BagsToBurn--;
		if (BagsToBurn == 0)
		{
			BagsToBurnLabel.text = "EXIT THE BUILDING FROM THE WINDOW YOU CAME IN FROM!";
			base.gameObject.SetActive(value: true);
		}
		else
		{
			BagsToBurnLabel.text = "BAGS TO BURN: " + BagsToBurn;
		}
	}
}
