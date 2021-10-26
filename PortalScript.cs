using UnityEngine;

public class PortalScript : MonoBehaviour
{
	public RivalMorningEventManagerScript[] MorningEvents;

	public OsanaMorningFriendEventScript[] FriendEvents;

	public OsanaMondayBeforeClassEventScript OsanaEvent;

	public RivalAfterClassEventManagerScript OsanaWednesdayAfterClassEvent;

	public RivalAfterClassEventManagerScript OsanaTuesdayAfterClassEvent;

	public OsanaThursdayAfterClassEventScript OsanaThursdayEvent;

	public OsanaFridayBeforeClassEvent1Script OsanaFridayEvent1;

	public OsanaFridayBeforeClassEvent2Script OsanaFridayEvent2;

	public OsanaTuesdayLunchEventScript OsanaTuesdayLunchEvent;

	public OsanaMondayLunchEventScript OsanaMondayLunchEvent;

	public OsanaFridayLunchEventScript OsanaFridayLunchEvent;

	public OsanaClubEventScript OsanaClubEvent;

	public OsanaPoolEventScript OsanaPoolEvent;

	public DelinquentManagerScript DelinquentManager;

	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public LoveManagerScript LoveManager;

	public ReputationScript Reputation;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PoliceScript Police;

	public PromptScript Prompt;

	public ClassScript Class;

	public ClockScript Clock;

	public GameObject EvidenceWarning;

	public GameObject HeartbeatCamera;

	public GameObject Headmaster;

	public UISprite ClassDarkness;

	public Texture HomeMapMarker;

	public Renderer MapMarker;

	public Transform Teacher;

	public bool CanAttendClass;

	public bool BypassWarning;

	public bool LateReport1;

	public bool LateReport2;

	public bool Transition;

	public bool FadeOut;

	public bool Proceed;

	public float Timer;

	public int Late;

	public UILabel BottomLabel;

	public UILabel AttendClassLabel;

	public UILabel CorpsesLabel;

	public UILabel BodyPartsLabel;

	public UILabel BloodStainsLabel;

	public UILabel BloodyClothingLabel;

	public UILabel BloodyWeaponsLabel;

	public GenericRivalEventScript[] MorningGenericEvents;

	public GenericRivalEventScript[] LunchGenericEvents;

	public GenericRivalEventScript[] FinalGenericEvents;

	private void Start()
	{
		EvidenceWarning.SetActive(value: false);
		ClassDarkness.enabled = false;
		if (GameGlobals.EightiesTutorial)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Clock.HourTime > 8.52f && Clock.HourTime < 8.53f && !Yandere.InClass && !LateReport1)
		{
			LateReport1 = true;
			Yandere.NotificationManager.DisplayNotification(NotificationType.Late);
		}
		if (Clock.HourTime > 13.52f && Clock.HourTime < 13.53f && !Yandere.InClass && !LateReport2)
		{
			LateReport2 = true;
			Yandere.NotificationManager.DisplayNotification(NotificationType.Late);
		}
		bool flag = false;
		if (EvidenceWarning.activeInHierarchy)
		{
			if (Input.GetButtonDown("A"))
			{
				EvidenceWarning.SetActive(value: false);
				BypassWarning = true;
				flag = true;
			}
			if (Input.GetButtonDown("B"))
			{
				EvidenceWarning.SetActive(value: false);
				Yandere.CanMove = true;
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f || flag)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if ((!BypassWarning && Police.Corpses - Police.HiddenCorpses > 0) || (!BypassWarning && Police.LimbParent.childCount > 0) || (!BypassWarning && Police.BloodParent.childCount > 0) || (!BypassWarning && Police.BloodyClothing > 0) || (!BypassWarning && Police.BloodyWeapons > 0))
			{
				CorpsesLabel.text = "Corpses: " + (Police.Corpses - Police.HiddenCorpses);
				BodyPartsLabel.text = "Body Parts: " + Police.LimbParent.childCount;
				BloodStainsLabel.text = "Blood Stains: " + Police.BloodParent.childCount;
				BloodyClothingLabel.text = "Bloody Clothing: " + Police.BloodyClothing;
				BloodyWeaponsLabel.text = "Bloody Weapons: " + Police.BloodyWeapons;
				if (Clock.HourTime > 13.5f)
				{
					BottomLabel.text = "If you try to leave school right now, the police will be called.";
					AttendClassLabel.text = "Leave School";
				}
				EvidenceWarning.SetActive(value: true);
				Yandere.CanMove = false;
			}
			else
			{
				CheckForLateness();
				Reputation.UpdateRep();
				bool flag2 = false;
				if (Clock.HourTime > 13f)
				{
					CheckForPoison();
				}
				if (Police.PoisonScene || (Police.SuicideScene && Police.Corpses - Police.HiddenCorpses > 0) || Police.Corpses - Police.HiddenCorpses > 0 || Police.BloodParent.childCount > 0 || Reputation.Reputation <= -100f)
				{
					EndDay();
				}
				else if (Clock.HourTime < 15.5f)
				{
					if (!Police.Show)
					{
						bool flag3 = false;
						if (StudentManager.Teachers[21] != null && StudentManager.Teachers[21].DistanceToDestination < 1f)
						{
							flag3 = true;
						}
						if (StudentManager.Students[StudentManager.RivalID] != null)
						{
							StudentManager.Students[StudentManager.RivalID].PlaceBag();
						}
						if (Late > 0 && flag3)
						{
							Yandere.Subtitle.UpdateLabel(SubtitleType.TeacherLateReaction, Late, 5.5f);
							Yandere.RPGCamera.enabled = false;
							Yandere.ShoulderCamera.Scolding = true;
							Yandere.ShoulderCamera.Teacher = Teacher;
						}
						else
						{
							ClassDarkness.enabled = true;
							Transition = true;
							FadeOut = true;
						}
						Clock.StopTime = true;
					}
					else
					{
						EndDay();
					}
				}
				else if (Yandere.Inventory.RivalPhone && !StudentManager.RivalEliminated)
				{
					Yandere.NotificationManager.CustomText = "Put the stolen phone on the owner's desk!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					Yandere.NotificationManager.CustomText = "You are carrying a stolen phone!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					flag2 = true;
				}
				else
				{
					EndFinalEvents();
					EndDay();
				}
				if (!flag2)
				{
					Yandere.Character.GetComponent<Animation>().CrossFade(Yandere.IdleAnim);
					Yandere.YandereVision = false;
					Yandere.CanMove = false;
					if (Clock.HourTime < 15.5f)
					{
						Yandere.InClass = true;
						if (Clock.HourTime < 8.5f)
						{
							EndEvents();
						}
						else
						{
							StudentManager.CheckBentos();
							if (StudentManager.Students[11] != null && StudentManager.Students[11].Alive && OsanaMondayLunchEvent.Bento[2].Poison == 2)
							{
								Debug.Log("The player poisoned Osana, so we're killing her automatically.");
								StudentManager.Students[11].DeathType = DeathType.Poison;
								StudentManager.Students[11].BecomeRagdoll();
								ClassDarkness.enabled = false;
								Yandere.InClass = false;
								Transition = false;
								FadeOut = false;
								EndDay();
							}
							else if (StudentManager.Students[10] != null && StudentManager.Students[10].Alive && OsanaMondayLunchEvent.Bento[3].Poison == 2)
							{
								Debug.Log("The player poisoned Raibaru, so we're killing her automatically.");
								StudentManager.Students[10].DeathType = DeathType.Poison;
								StudentManager.Students[10].BecomeRagdoll();
								ClassDarkness.enabled = false;
								Yandere.InClass = false;
								Transition = false;
								FadeOut = false;
								EndDay();
							}
							else
							{
								EndLaterEvents();
							}
						}
					}
				}
			}
		}
		if (Transition)
		{
			if (FadeOut)
			{
				if (LoveManager.HoldingHands)
				{
					LoveManager.Rival.transform.position = new Vector3(0f, 0f, -50f);
				}
				ClassDarkness.color = new Color(ClassDarkness.color.r, ClassDarkness.color.g, ClassDarkness.color.b, ClassDarkness.color.a + Time.deltaTime);
				if (ClassDarkness.color.a >= 1f)
				{
					if (Yandere.Resting)
					{
						Yandere.IdleAnim = "f02_idleShort_00";
						Yandere.WalkAnim = "f02_newWalk_00";
						Yandere.OriginalIdleAnim = Yandere.IdleAnim;
						Yandere.OriginalWalkAnim = Yandere.WalkAnim;
						Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
						Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
						Yandere.Resting = false;
						Yandere.Health = 10;
						FadeOut = false;
						Proceed = true;
					}
					else
					{
						if (Yandere.Armed)
						{
							Yandere.Unequip();
						}
						HeartbeatCamera.SetActive(value: false);
						ClassDarkness.color = new Color(ClassDarkness.color.r, ClassDarkness.color.g, ClassDarkness.color.b, 1f);
						FadeOut = false;
						Proceed = false;
						Yandere.RPGCamera.enabled = false;
						PromptBar.ClearButtons();
						PromptBar.Label[4].text = "Choose";
						PromptBar.Label[5].text = "Allocate";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						Class.StudyPoints += ((PlayerGlobals.PantiesEquipped == 7) ? 10 : 5);
						Class.StudyPoints += Class.BonusPoints;
						Class.BonusPoints = 0;
						Class.StudyPoints -= Late;
						Class.UpdateLabel();
						Class.gameObject.SetActive(value: true);
						Class.Show = true;
						if (Police.Show)
						{
							Police.Timer = 1E-06f;
						}
					}
				}
			}
			else if (Proceed)
			{
				if (ClassDarkness.color.a >= 1f)
				{
					if (!StudentManager.Eighties)
					{
						HeartbeatCamera.SetActive(value: true);
					}
					Clock.enabled = true;
					Yandere.FixCamera();
					Yandere.RPGCamera.enabled = false;
					if (Clock.HourTime < 13f)
					{
						if (StudentManager.Bully)
						{
							StudentManager.UpdateGraffiti();
						}
						Yandere.Incinerator.Timer -= 780f - Clock.PresentTime;
						DelinquentManager.CheckTime();
						Clock.PresentTime = 780f;
					}
					else
					{
						Yandere.Incinerator.Timer -= 930f - Clock.PresentTime;
						DelinquentManager.CheckTime();
						Clock.PresentTime = 930f;
					}
					Clock.HourTime = Clock.PresentTime / 60f;
					StudentManager.AttendClass();
				}
				ClassDarkness.color = new Color(ClassDarkness.color.r, ClassDarkness.color.g, ClassDarkness.color.b, ClassDarkness.color.a - Time.deltaTime);
				if (ClassDarkness.color.a <= 0f)
				{
					ClassDarkness.enabled = false;
					ClassDarkness.color = new Color(ClassDarkness.color.r, ClassDarkness.color.g, ClassDarkness.color.b, 0f);
					Clock.StopTime = false;
					Transition = false;
					Proceed = false;
					Yandere.RPGCamera.enabled = true;
					Yandere.InClass = false;
					Yandere.CanMove = true;
					StudentManager.ResumeMovement();
					if (Clock.HourTime > 15f && DateGlobals.Week != 2)
					{
						StudentManager.TakeOutTheTrash();
					}
					if (!MissionModeGlobals.MissionMode)
					{
						if (Headmaster.activeInHierarchy)
						{
							Headmaster.SetActive(value: false);
						}
						else
						{
							Headmaster.SetActive(value: true);
						}
					}
				}
			}
		}
		if (Clock.HourTime > 15.5f)
		{
			if (base.transform.position.z < 0f)
			{
				StudentManager.RemovePapersFromDesks();
				if (!MissionModeGlobals.MissionMode)
				{
					MapMarker.material.mainTexture = HomeMapMarker;
					base.transform.position = new Vector3(0f, 1f, -75f);
					Prompt.Label[0].text = "     Go Home";
					Prompt.enabled = true;
				}
				else
				{
					base.transform.position = new Vector3(0f, -10f, 0f);
					Prompt.Hide();
					Prompt.enabled = false;
				}
			}
		}
		else
		{
			if (Yandere.Police.FadeOut || !(Vector3.Distance(Yandere.transform.position, base.transform.position) < 1.4f))
			{
				return;
			}
			CanAttendClass = true;
			CheckForProblems();
			if (!CanAttendClass)
			{
				if (Timer == 0f)
				{
					if (Yandere.Armed)
					{
						Yandere.NotificationManager.CustomText = "Carrying Weapon";
					}
					else if (Yandere.Bloodiness > 0f)
					{
						Yandere.NotificationManager.CustomText = "Bloody";
					}
					else if (Yandere.Sanity < 33.333f)
					{
						Yandere.NotificationManager.CustomText = "Visibly Insane";
					}
					else if (Yandere.Attacking)
					{
						Yandere.NotificationManager.CustomText = "In Combat";
					}
					else if (Yandere.Dragging || Yandere.Carrying)
					{
						Yandere.NotificationManager.CustomText = "Holding Corpse";
					}
					else if (Yandere.PickUp != null)
					{
						Yandere.NotificationManager.CustomText = "Carrying Item";
					}
					else if (Yandere.Chased || Yandere.Chasers > 0)
					{
						Yandere.NotificationManager.CustomText = "Chased";
					}
					else if ((bool)StudentManager.Reporter && !Police.Show)
					{
						Yandere.NotificationManager.CustomText = "Murder being reported";
					}
					else if (StudentManager.MurderTakingPlace)
					{
						Yandere.NotificationManager.CustomText = "Murder taking place";
					}
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					Yandere.NotificationManager.CustomText = "Cannot attend class. Reason:";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				Prompt.Hide();
				Prompt.enabled = false;
				Timer += Time.deltaTime;
				if (Timer > 5f)
				{
					Timer = 0f;
				}
			}
			else
			{
				Prompt.enabled = true;
			}
		}
	}

	public void CheckForProblems()
	{
		if (Yandere.Armed || Yandere.Bloodiness > 0f || Yandere.Sanity < 33.333f || Yandere.Attacking || Yandere.Dragging || Yandere.Carrying || Yandere.PickUp != null || Yandere.Chased || Yandere.Chasers > 0 || (StudentManager.Reporter != null && !Police.Show) || StudentManager.MurderTakingPlace)
		{
			CanAttendClass = false;
		}
	}

	public void EndDay()
	{
		StudentManager.StopMoving();
		Yandere.StopLaughing();
		Yandere.EmptyHands();
		Clock.StopTime = true;
		Police.Darkness.enabled = true;
		Police.FadeOut = true;
		Police.DayOver = true;
		if (SchemeGlobals.GetSchemeStage(6) == 8)
		{
			SchemeGlobals.SetSchemeStage(6, 9);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
	}

	private void CheckForLateness()
	{
		Late = 0;
		if (Clock.HourTime < 13f)
		{
			if (Clock.HourTime < 8.52f)
			{
				Late = 0;
			}
			else if (Clock.HourTime < 10f)
			{
				Late = 1;
			}
			else if (Clock.HourTime < 11f)
			{
				Late = 2;
			}
			else if (Clock.HourTime < 12f)
			{
				Late = 3;
			}
			else if (Clock.HourTime < 13f)
			{
				Late = 4;
			}
		}
		else if (Clock.HourTime < 13.52f)
		{
			Late = 0;
		}
		else if (Clock.HourTime < 14f)
		{
			Late = 1;
		}
		else if (Clock.HourTime < 14.5f)
		{
			Late = 2;
		}
		else if (Clock.HourTime < 15f)
		{
			Late = 3;
		}
		else if (Clock.HourTime < 15.5f)
		{
			Late = 4;
		}
		Reputation.PendingRep -= 5 * Late;
		_ = Late;
		_ = 0;
	}

	public void EndEvents()
	{
		for (int i = 0; i < MorningEvents.Length; i++)
		{
			if (MorningEvents[i].enabled)
			{
				MorningEvents[i].EndEvent();
			}
		}
		for (int i = 0; i < FriendEvents.Length; i++)
		{
			if (FriendEvents[i].enabled)
			{
				FriendEvents[i].EndEvent();
			}
		}
		if (OsanaEvent.enabled)
		{
			OsanaEvent.EndEvent();
		}
		if (OsanaClubEvent.enabled)
		{
			OsanaClubEvent.EndEvent();
		}
		if (!OsanaClubEvent.enabled && !OsanaClubEvent.ReachedTheEnd && !StudentManager.Eighties)
		{
			Debug.Log("The Portal is checking the Osana Club Event.");
			OsanaClubEvent.CheckForRooftopConvo();
		}
		if (OsanaFridayEvent1.enabled)
		{
			OsanaFridayEvent1.EndEvent();
		}
		if (OsanaFridayEvent2.enabled)
		{
			OsanaFridayEvent2.EndEvent();
		}
		for (int i = 1; i < MorningGenericEvents.Length; i++)
		{
			if (MorningGenericEvents[i].enabled)
			{
				MorningGenericEvents[i].NaturalEnd = true;
				MorningGenericEvents[i].EndEvent();
			}
		}
	}

	public void EndLaterEvents()
	{
		if (OsanaMondayLunchEvent.enabled && OsanaMondayLunchEvent.Phase > 0 && OsanaMondayLunchEvent.Bento[1].Poison > 0)
		{
			Debug.Log("We're skipping past Osana's Monday lunchtime event, but it was was sabotaged, so we're incrementing the Sabotage count.");
			StudentManager.SabotageProgress++;
		}
		if (OsanaFridayLunchEvent.enabled && OsanaFridayLunchEvent.Rival != null && OsanaFridayLunchEvent.Rival.InEvent && OsanaFridayLunchEvent.AudioSoftware.AudioDoctored)
		{
			Debug.Log("We're skipping past Osana's Friday lunchtime event, but it was was sabotaged, so we're incrementing the Sabotage count.");
			StudentManager.SabotageProgress++;
		}
		for (int i = 1; i < LunchGenericEvents.Length; i++)
		{
			if (LunchGenericEvents[i].enabled && LunchGenericEvents[i].Sabotaged)
			{
				Debug.Log("We're skipping past a generic rival lunchtime event, but it was was sabotaged, so we're incrementing the Sabotage count.");
				StudentManager.SabotageProgress++;
			}
		}
		Debug.Log("Sabotage Progress is currently: " + StudentManager.SabotageProgress);
		if (OsanaPoolEvent.Phase > 0)
		{
			OsanaPoolEvent.EndEvent();
		}
		if (OsanaFridayLunchEvent.enabled)
		{
			OsanaFridayLunchEvent.EndEvent();
		}
		for (int i = 1; i < LunchGenericEvents.Length; i++)
		{
			if (LunchGenericEvents[i].enabled)
			{
				LunchGenericEvents[i].EndEvent();
			}
		}
	}

	public void EndFinalEvents()
	{
		if (OsanaTuesdayAfterClassEvent.enabled && OsanaTuesdayAfterClassEvent.Sabotaged)
		{
			Debug.Log("We're skipping past Osana's Tuesday talk-to-Senpai-outside-of-school event, but it was was sabotaged, so we're incrementing the Sabotage count.");
			StudentManager.SabotageProgress++;
		}
		if (OsanaWednesdayAfterClassEvent.enabled && OsanaWednesdayAfterClassEvent.Rival != null && OsanaWednesdayAfterClassEvent.Rival.LewdPhotos)
		{
			Debug.Log("We're skipping past Osana's Wednesday talk-to-Senpai-outside-of-school event, but it was was sabotaged, so we're incrementing the Sabotage count.");
			StudentManager.SabotageProgress++;
		}
		if (OsanaThursdayEvent.enabled && OsanaThursdayEvent.Phase > 0 && OsanaThursdayEvent.Sabotaged)
		{
			Debug.Log("We're skipping past Osana's Thursday rooftop event, but it was was sabotaged, so we're incrementing the Sabotage count.");
			StudentManager.SabotageProgress++;
		}
		for (int i = 1; i < FinalGenericEvents.Length; i++)
		{
			if (FinalGenericEvents[i].enabled)
			{
				FinalGenericEvents[i].EndEvent();
			}
		}
		Debug.Log("It is the end of the day, and Sabotage Progress is currently " + StudentManager.SabotageProgress + " out of 5.");
	}

	public void CheckForPoison()
	{
		for (int i = 0; i < StudentManager.Students.Length; i++)
		{
			if (StudentManager.Students[i] != null && StudentManager.Students[i].Alive && StudentManager.Students[i].MyBento.Lethal)
			{
				Police.SkippingPastPoison = true;
				StudentManager.Students[i].Ragdoll.Poisoned = true;
				StudentManager.Students[i].BecomeRagdoll();
				StudentManager.Students[i].DeathType = DeathType.Poison;
			}
		}
	}
}
