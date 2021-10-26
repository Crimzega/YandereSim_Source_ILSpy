using UnityEngine;

public class GenericPromptScript : MonoBehaviour
{
	public GenericPromptScript NextPrompt;

	public GenericRivalEventScript Event;

	public GameObject CrushCollider;

	public GameObject Effect;

	public GameObject[] Object;

	public Transform ObjectToRotate;

	public Transform PlayerSpot;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public Mesh NewMesh;

	public bool PerformingAction;

	public bool SpawnedEffect;

	public float TargetRotation = 90f;

	public float Rotation;

	public float Speed;

	public int ID;

	private void Update()
	{
		if (ID == 1)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					bool flag = false;
					if (Prompt.Yandere.Inventory.EmeticPoison)
					{
						Prompt.Yandere.Inventory.EmeticPoison = false;
						flag = true;
					}
					else if (Prompt.Yandere.Inventory.RatPoison)
					{
						Prompt.Yandere.Inventory.RatPoison = false;
						flag = true;
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					if (flag)
					{
						Prompt.Yandere.StudentManager.Students[1].MyBento.Tampered = true;
						Prompt.Yandere.StudentManager.Students[1].MyBento.Emetic = true;
						SabotageAndDisable();
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 2)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					SabotageAndDisable();
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 3)
		{
			if (Prompt.Circle[0].fillAmount == 0f || Prompt.Circle[1].fillAmount == 0f || Prompt.Circle[2].fillAmount == 0f || Prompt.Circle[3].fillAmount == 0f)
			{
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					if (Prompt.Circle[0].fillAmount == 0f)
					{
						if (Prompt.Yandere.Inventory.Sake)
						{
							Prompt.Yandere.Inventory.Sake = false;
							SabotageAndDisable();
						}
						else
						{
							Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					if (Prompt.Circle[1].fillAmount == 0f)
					{
						if (Prompt.Yandere.Inventory.Condoms)
						{
							Prompt.Yandere.Inventory.Condoms = false;
							SabotageAndDisable();
						}
						else
						{
							Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					if (Prompt.Circle[2].fillAmount == 0f)
					{
						if (Prompt.Yandere.Inventory.Cigs)
						{
							Prompt.Yandere.Inventory.Cigs = false;
							SabotageAndDisable();
						}
						else
						{
							Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					if (Prompt.Circle[3].fillAmount == 0f)
					{
						if (Prompt.Yandere.Inventory.Narcotics)
						{
							Prompt.Yandere.Inventory.Narcotics = false;
							SabotageAndDisable();
						}
						else
						{
							Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Circle[1].fillAmount = 1f;
				Prompt.Circle[2].fillAmount = 1f;
				Prompt.Circle[3].fillAmount = 1f;
			}
		}
		else if (ID == 4)
		{
			if ((Prompt.Yandere.PickUp != null && (bool)Prompt.Yandere.PickUp.Bucket && Prompt.Yandere.PickUp.Bucket.Gasoline) || (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.JerryCan))
			{
				Prompt.enabled = true;
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					Prompt.Circle[0].fillAmount = 1f;
					Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (!Prompt.Yandere.StudentManager.YandereVisible)
					{
						Prompt.Yandere.StudentManager.GasInWateringCan = true;
						MyAudio.Play();
						Prompt.enabled = false;
						Prompt.Hide();
						base.enabled = false;
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
			}
			else if (Prompt.enabled)
			{
				Prompt.enabled = false;
				Prompt.Hide();
			}
		}
		else if (ID == 5)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (Prompt.Yandere.Class.PhysicalGrade + Prompt.Yandere.Class.PhysicalBonus > 0)
				{
					Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (!Prompt.Yandere.StudentManager.YandereVisible)
					{
						Prompt.Yandere.CharacterAnimation.CrossFade("f02_dumpsterPull_00");
						Prompt.Yandere.CanMove = false;
						PerformingAction = true;
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "You're not strong enough to move this!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 6)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					Prompt.Yandere.CharacterAnimation.CrossFade("f02_bookcasePush_00");
					Prompt.Yandere.transform.position = PlayerSpot.position;
					Prompt.Yandere.transform.rotation = PlayerSpot.rotation;
					Prompt.Yandere.CanMove = false;
					PerformingAction = true;
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 7)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				StudentScript studentScript = Prompt.Yandere.StudentManager.Students[15];
				if (studentScript != null && studentScript.CurrentAction == StudentActionType.Sunbathe && studentScript.SunbathePhase == 3)
				{
					if (studentScript.Blind)
					{
						Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
						if (!Prompt.Yandere.StudentManager.YandereVisible)
						{
							studentScript.transform.parent = base.transform.parent;
							studentScript.transform.localPosition = new Vector3(1.374146f, 0.0175f, 0.05f);
							PerformingAction = true;
							studentScript.enabled = false;
						}
						else
						{
							Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "It won't work. She's not asleep.";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "Nobody is in this chair.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 8)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.Electronic)
				{
					PickUpScript pickUp = Prompt.Yandere.PickUp;
					Prompt.Yandere.EmptyHands();
					pickUp.gameObject.SetActive(value: false);
					pickUp.Prompt.enabled = false;
					pickUp.Prompt.Hide();
					Object[1].SetActive(value: true);
					Prompt.enabled = false;
					Prompt.Hide();
					base.enabled = false;
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "You're not holding a power strip.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 9)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (Prompt.Yandere.EquippedWeapon != null && Prompt.Yandere.EquippedWeapon.WeaponID == 6)
				{
					base.gameObject.SetActive(value: false);
					Object[1].SetActive(value: false);
					Object[2].SetActive(value: true);
					Prompt.enabled = false;
					Prompt.Hide();
					base.enabled = false;
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "You're not holding a screwdriver.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 10)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (Prompt.Yandere.PickUp != null && (bool)Prompt.Yandere.PickUp.Bucket && Prompt.Yandere.PickUp.Bucket.Full)
				{
					Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (!Prompt.Yandere.StudentManager.YandereVisible)
					{
						Object[1].SetActive(value: true);
						Prompt.Yandere.PickUp.Bucket.Empty();
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "You're not holding a bucket of water.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 11 && Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Object[1].activeInHierarchy && Object[2].activeInHierarchy)
			{
				Effect.SetActive(!Effect.activeInHierarchy);
			}
		}
		if (!PerformingAction)
		{
			return;
		}
		if (ID == 5)
		{
			Rotation = Mathf.MoveTowards(Rotation, -90f, Time.deltaTime * 36f);
			ObjectToRotate.localEulerAngles = new Vector3(0f, Rotation, 0f);
			Prompt.Yandere.transform.position = PlayerSpot.position;
			Prompt.Yandere.transform.rotation = PlayerSpot.rotation;
			if (Rotation == -90f)
			{
				NextPrompt.gameObject.SetActive(value: true);
				Prompt.Yandere.CanMove = true;
				Prompt.enabled = false;
				Prompt.Hide();
				base.enabled = false;
				PerformingAction = false;
			}
		}
		else if (ID == 6)
		{
			if (Prompt.Yandere.CharacterAnimation["f02_bookcasePush_00"].time > 0.5f)
			{
				ObjectToRotate.transform.localPosition = Vector3.MoveTowards(ObjectToRotate.transform.localPosition, new Vector3(-0.169f, 0.17f, -0.94f), Time.deltaTime);
				if (Prompt.Yandere.StudentManager.Students[13] != null && !Prompt.Yandere.StudentManager.Students[13].Alive && Prompt.Yandere.StudentManager.Students[13].DeathType == DeathType.Weight)
				{
					Prompt.Yandere.StudentManager.Students[13].CharacterAnimation.Play("f02_crushed_00");
					Debug.Log("We could be doing something here.");
				}
				Rotation = Mathf.MoveTowards(Rotation, TargetRotation, Time.deltaTime * 360f);
				ObjectToRotate.localEulerAngles = new Vector3(Rotation, -90f, 0f);
				CrushCollider.SetActive(value: true);
				if (Rotation == TargetRotation)
				{
					MyAudio.Play();
					CrushCollider.SetActive(value: false);
					Prompt.Yandere.CanMove = true;
					Prompt.enabled = false;
					Prompt.Hide();
					base.enabled = false;
					PerformingAction = false;
				}
			}
		}
		else
		{
			if (ID != 7)
			{
				return;
			}
			Rotation = Mathf.MoveTowards(Rotation, TargetRotation, Time.deltaTime * 360f);
			base.transform.parent.localEulerAngles = new Vector3(0f, 0f, Rotation);
			base.transform.parent.localPosition = Vector3.MoveTowards(base.transform.parent.localPosition, new Vector3(6f, 3.75f, 2f), Time.deltaTime);
			if (Rotation == TargetRotation)
			{
				if (!SpawnedEffect)
				{
					UnityEngine.Object.Instantiate(Effect, base.transform.position, Quaternion.identity).transform.eulerAngles = new Vector3(-90f, 0f, 0f);
					Prompt.Yandere.StudentManager.Students[15].transform.parent = base.transform;
					SpawnedEffect = true;
				}
				base.transform.position -= new Vector3(0f, Time.deltaTime, 0f);
				if (base.transform.localPosition.y > 3.1537f)
				{
					StudentScript obj = Prompt.Yandere.StudentManager.Students[15];
					obj.Drowned = true;
					obj.BecomeRagdoll();
					obj.Ragdoll.Zs.SetActive(value: false);
					obj.Ragdoll.DestroyRigidbodies();
					obj.DeathType = DeathType.Drowning;
					obj.CharacterAnimation.enabled = true;
					obj.CharacterAnimation.Play("f02_sunbatheSleep_00");
					PerformingAction = false;
					Prompt.enabled = false;
					Prompt.Hide();
					base.enabled = false;
				}
			}
		}
	}

	public void SabotageAndDisable()
	{
		Event.Sabotage();
		Prompt.enabled = false;
		Prompt.Hide();
		base.enabled = false;
	}
}
