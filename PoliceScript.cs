using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoliceScript : MonoBehaviour
{
	public LowRepGameOverScript LowRepGameOver;

	public StudentManagerScript StudentManager;

	public ClubManagerScript ClubManager;

	public HeartbrokenScript Heartbroken;

	public LoveManagerScript LoveManager;

	public PauseScreenScript PauseScreen;

	public ReputationScript Reputation;

	public TranqCaseScript TranqCase;

	public EndOfDayScript EndOfDay;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public ClockScript Clock;

	public JsonScript JSON;

	public UIPanel Panel;

	public GameObject HeartbeatCamera;

	public GameObject DetectionCamera;

	public GameObject SuicideStudent;

	public GameObject UICamera;

	public GameObject Icons;

	public GameObject FPS;

	public Transform GarbageParent;

	public Transform BloodParent;

	public Transform LimbParent;

	public RagdollScript[] CorpseList;

	public UILabel[] ResultsLabels;

	public UILabel ContinueLabel;

	public UILabel TimeLabel;

	public UISprite ContinueButton;

	public UISprite Darkness;

	public UISprite BloodIcon;

	public UISprite UniformIcon;

	public UISprite WeaponIcon;

	public UISprite CorpseIcon;

	public UISprite PartsIcon;

	public UISprite SanityIcon;

	public string ElectrocutedStudentName = string.Empty;

	public string DrownedStudentName = string.Empty;

	public bool BloodDisposed;

	public bool UniformDisposed;

	public bool WeaponDisposed;

	public bool CorpseDisposed;

	public bool PartsDisposed;

	public bool SanityRestored;

	public bool MurderSuicideScene;

	public bool ElectroScene;

	public bool SuicideScene;

	public bool PoisonScene;

	public bool MurderScene;

	public bool SkippingPastPoison;

	public bool StudentFoundCorpse;

	public bool BeginConfession;

	public bool GenocideEnding;

	public bool TeacherReport;

	public bool ClubActivity;

	public bool CouncilDeath;

	public bool MaskReported;

	public bool SelfReported;

	public bool FadeResults;

	public bool ShowResults;

	public bool SuicideNote;

	public bool TextUpdated;

	public bool GameOver;

	public bool DayOver;

	public bool Delayed;

	public bool FadeOut;

	public bool Invalid;

	public bool Suicide;

	public bool Called;

	public bool LowRep;

	public bool Show;

	public int IncineratedWeapons;

	public int RedPaintClothing;

	public int SuicideVictims;

	public int BloodyClothing;

	public int BloodyWeapons;

	public int HiddenCorpses;

	public int MurderWeapons;

	public int PhotoEvidence;

	public int DrownVictims;

	public int BodyParts;

	public int SuicideID;

	public int Witnesses;

	public int Corpses;

	public int Deaths;

	public int Frame;

	public float ResultsTimer;

	public float Timer;

	public float TargetX;

	public float TargetY;

	public int Minutes;

	public int Seconds;

	public string Protagonist = "Ayano";

	public int SuspensionLength;

	public int RemainingDays;

	public bool Suspended;

	private void Start()
	{
		if (SchoolGlobals.SchoolAtmosphere > 0.5f)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 0f);
			Darkness.enabled = false;
		}
		base.transform.localPosition = new Vector3(-260f, base.transform.localPosition.y, base.transform.localPosition.z);
		UILabel[] resultsLabels = ResultsLabels;
		foreach (UILabel uILabel in resultsLabels)
		{
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0f);
		}
		ContinueLabel.color = new Color(ContinueLabel.color.r, ContinueLabel.color.g, ContinueLabel.color.b, 0f);
		ContinueButton.color = new Color(ContinueButton.color.r, ContinueButton.color.g, ContinueButton.color.b, 0f);
		Icons.SetActive(value: false);
		if (GameGlobals.Eighties)
		{
			Protagonist = "Ryoba";
			TargetX = 25f;
			TargetY = -25f;
		}
	}

	private void Update()
	{
		UILabel[] componentsInChildren;
		if (Show)
		{
			if (StudentManager.Eighties && !TextUpdated)
			{
				Frame++;
				if (Frame > 1)
				{
					componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>();
					foreach (UILabel label in componentsInChildren)
					{
						StudentManager.EightiesifyLabel(label);
					}
					TextUpdated = true;
				}
			}
			StudentManager.TutorialWindow.ShowPoliceMessage = true;
			_ = PoisonScene;
			if (!Icons.activeInHierarchy)
			{
				Icons.SetActive(value: true);
			}
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, TargetX, Time.deltaTime * 10f), Mathf.Lerp(base.transform.localPosition.y, TargetY, Time.deltaTime * 10f), base.transform.localPosition.z);
			if (BloodParent.childCount == 0)
			{
				if (!BloodDisposed)
				{
					BloodIcon.spriteName = "Yes";
					BloodDisposed = true;
				}
			}
			else if (BloodDisposed)
			{
				BloodIcon.spriteName = "No";
				BloodDisposed = false;
			}
			if (BloodyClothing == 0)
			{
				if (!UniformDisposed)
				{
					UniformIcon.spriteName = "Yes";
					UniformDisposed = true;
				}
			}
			else if (UniformDisposed)
			{
				UniformIcon.spriteName = "No";
				UniformDisposed = false;
			}
			if (MurderWeapons == 0 || IncineratedWeapons == MurderWeapons)
			{
				if (!WeaponDisposed)
				{
					WeaponIcon.spriteName = "Yes";
					WeaponDisposed = true;
				}
			}
			else if (WeaponDisposed)
			{
				WeaponIcon.spriteName = "No";
				WeaponDisposed = false;
			}
			if (Corpses == 0)
			{
				if (!CorpseDisposed)
				{
					CorpseIcon.spriteName = "Yes";
					CorpseDisposed = true;
				}
			}
			else if (CorpseDisposed)
			{
				CorpseIcon.spriteName = "No";
				CorpseDisposed = false;
			}
			if (BodyParts == 0)
			{
				if (!PartsDisposed)
				{
					PartsIcon.spriteName = "Yes";
					PartsDisposed = true;
				}
			}
			else if (PartsDisposed)
			{
				PartsIcon.spriteName = "No";
				PartsDisposed = false;
			}
			if (Yandere.Sanity == 100f)
			{
				if (!SanityRestored)
				{
					SanityIcon.spriteName = "Yes";
					SanityRestored = true;
				}
			}
			else if (SanityRestored)
			{
				SanityIcon.spriteName = "No";
				SanityRestored = false;
			}
			if (!Clock.StopTime)
			{
				Timer = Mathf.MoveTowards(Timer, 0f, Time.deltaTime);
			}
			if (Timer <= 0f)
			{
				Timer = 0f;
				if (!Yandere.Attacking && !Yandere.Struggling && !Yandere.Egg && !FadeOut)
				{
					BeginFadingOut();
				}
			}
			int num = Mathf.CeilToInt(Timer);
			Minutes = num / 60;
			Seconds = num % 60;
			TimeLabel.text = $"{Minutes:00}:{Seconds:00}";
			if (Yandere.NotificationManager.NotificationParent.localPosition.x == 0f)
			{
				Yandere.NotificationManager.NotificationParent.localPosition = new Vector3(0.15f, Yandere.NotificationManager.NotificationParent.localPosition.y, Yandere.NotificationManager.NotificationParent.localPosition.z);
			}
		}
		else if (Deaths > 86 && !Invalid && !Yandere.Egg && Clock.Weekday == 1 && StudentManager.Students[1].gameObject.activeInHierarchy && !StudentManager.Students[1].Fleeing)
		{
			GenocideEnding = true;
			BeginFadingOut();
		}
		if (FadeOut)
		{
			if (Yandere.Laughing)
			{
				Yandere.StopLaughing();
			}
			if (Clock.TimeSkip || Yandere.CanMove)
			{
				if (Clock.TimeSkip)
				{
					Clock.EndTimeSkip();
				}
				Yandere.StopAiming();
				Yandere.CanMove = false;
				Yandere.YandereVision = false;
				Yandere.PauseScreen.enabled = false;
				Yandere.CharacterAnimation.CrossFade("f02_idleShort_00");
				if (Yandere.Mask != null)
				{
					Yandere.Mask.Drop();
				}
				if (Yandere.PickUp != null)
				{
					Yandere.EmptyHands();
				}
				if (Yandere.Dragging || Yandere.Carrying)
				{
					Yandere.EmptyHands();
				}
			}
			PauseScreen.Panel.alpha = Mathf.MoveTowards(PauseScreen.Panel.alpha, 0f, Time.deltaTime);
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			if (Darkness.color.a >= 1f && !ShowResults)
			{
				HeartbeatCamera.SetActive(value: false);
				DetectionCamera.SetActive(value: false);
				if (ClubActivity)
				{
					ClubManager.Club = Yandere.Club;
					ClubManager.ClubActivity();
					FadeOut = false;
				}
				else
				{
					Yandere.MyController.enabled = false;
					Yandere.enabled = false;
					DetermineResults();
					ShowResults = true;
					Time.timeScale = 2f;
					Jukebox.Volume = 0f;
				}
				if (GenocideEnding)
				{
					SceneManager.LoadScene("GenocideScene");
				}
			}
		}
		if (ShowResults)
		{
			ResultsTimer += Time.deltaTime;
			if (ResultsTimer > 1f)
			{
				UILabel uILabel = ResultsLabels[0];
				uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, uILabel.color.a + Time.deltaTime);
			}
			if (ResultsTimer > 2f)
			{
				UILabel uILabel2 = ResultsLabels[1];
				uILabel2.color = new Color(uILabel2.color.r, uILabel2.color.g, uILabel2.color.b, uILabel2.color.a + Time.deltaTime);
			}
			if (ResultsTimer > 3f)
			{
				UILabel uILabel3 = ResultsLabels[2];
				uILabel3.color = new Color(uILabel3.color.r, uILabel3.color.g, uILabel3.color.b, uILabel3.color.a + Time.deltaTime);
			}
			if (ResultsTimer > 4f)
			{
				UILabel uILabel4 = ResultsLabels[3];
				uILabel4.color = new Color(uILabel4.color.r, uILabel4.color.g, uILabel4.color.b, uILabel4.color.a + Time.deltaTime);
			}
			if (ResultsTimer > 5f)
			{
				UILabel uILabel5 = ResultsLabels[4];
				uILabel5.color = new Color(uILabel5.color.r, uILabel5.color.g, uILabel5.color.b, uILabel5.color.a + Time.deltaTime);
			}
			if (ResultsTimer > 6f)
			{
				ContinueButton.color = new Color(ContinueButton.color.r, ContinueButton.color.g, ContinueButton.color.b, ContinueButton.color.a + Time.deltaTime);
				ContinueLabel.color = new Color(ContinueLabel.color.r, ContinueLabel.color.g, ContinueLabel.color.b, ContinueLabel.color.a + Time.deltaTime);
				if (ContinueButton.color.a > 1f)
				{
					ContinueButton.color = new Color(ContinueButton.color.r, ContinueButton.color.g, ContinueButton.color.b, 1f);
				}
				if (ContinueLabel.color.a > 1f)
				{
					ContinueLabel.color = new Color(ContinueLabel.color.r, ContinueLabel.color.g, ContinueLabel.color.b, 1f);
				}
			}
			if (Input.GetKeyDown("space"))
			{
				ShowResults = false;
				FadeResults = true;
				FadeOut = false;
				ResultsTimer = 0f;
			}
			if (ResultsTimer > 7f && Input.GetButtonDown("A"))
			{
				ShowResults = false;
				FadeResults = true;
				FadeOut = false;
				ResultsTimer = 0f;
			}
		}
		componentsInChildren = ResultsLabels;
		foreach (UILabel uILabel6 in componentsInChildren)
		{
			if (uILabel6.color.a > 1f)
			{
				uILabel6.color = new Color(uILabel6.color.r, uILabel6.color.g, uILabel6.color.b, 1f);
			}
		}
		if (!FadeResults)
		{
			return;
		}
		componentsInChildren = ResultsLabels;
		foreach (UILabel uILabel7 in componentsInChildren)
		{
			uILabel7.color = new Color(uILabel7.color.r, uILabel7.color.g, uILabel7.color.b, uILabel7.color.a - Time.deltaTime);
		}
		ContinueButton.color = new Color(ContinueButton.color.r, ContinueButton.color.g, ContinueButton.color.b, ContinueButton.color.a - Time.deltaTime);
		ContinueLabel.color = new Color(ContinueLabel.color.r, ContinueLabel.color.g, ContinueLabel.color.b, ContinueLabel.color.a - Time.deltaTime);
		if (!(ResultsLabels[0].color.a <= 0f))
		{
			return;
		}
		if (BeginConfession)
		{
			LoveManager.Suitor = StudentManager.Students[1];
			LoveManager.Rival = StudentManager.Students[StudentManager.RivalID];
			LoveManager.Suitor.CharacterAnimation.enabled = true;
			LoveManager.Rival.CharacterAnimation.enabled = true;
			LoveManager.BeginConfession();
			Time.timeScale = 1f;
			base.enabled = false;
		}
		else if (GameOver)
		{
			Heartbroken.transform.parent.transform.parent = null;
			Heartbroken.transform.parent.gameObject.SetActive(value: true);
			Heartbroken.Noticed = false;
			base.transform.parent.transform.parent.gameObject.SetActive(value: false);
			if (!EndOfDay.gameObject.activeInHierarchy)
			{
				Time.timeScale = 1f;
			}
		}
		else if (LowRep)
		{
			Yandere.RPGCamera.enabled = false;
			Yandere.RPGCamera.transform.parent = LowRepGameOver.MyCamera;
			Yandere.RPGCamera.transform.localPosition = new Vector3(0f, 0f, 0f);
			Yandere.RPGCamera.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			LowRepGameOver.gameObject.SetActive(value: true);
			UICamera.SetActive(value: false);
			FPS.SetActive(value: false);
			Time.timeScale = 1f;
			base.enabled = false;
		}
		else if (!TeacherReport)
		{
			if (EndOfDay.Phase == 1)
			{
				EndOfDay.gameObject.SetActive(value: true);
				EndOfDay.enabled = true;
				EndOfDay.Phase = 14;
				if (EndOfDay.PreviouslyActivated)
				{
					EndOfDay.Start();
				}
				for (int j = 0; j < 5; j++)
				{
					ResultsLabels[j].text = string.Empty;
				}
				base.enabled = false;
			}
		}
		else
		{
			DetermineResults();
			TeacherReport = false;
			FadeResults = false;
			ShowResults = true;
		}
	}

	private void DetermineResults()
	{
		ResultsLabels[0].transform.parent.gameObject.SetActive(value: true);
		if (Show)
		{
			EndOfDay.gameObject.SetActive(value: true);
			base.enabled = false;
			for (int i = 0; i < 5; i++)
			{
				ResultsLabels[i].text = string.Empty;
			}
		}
		else if (Yandere.ShoulderCamera.GoingToCounselor)
		{
			ResultsLabels[0].text = "While " + Protagonist + " was in the counselor's office,";
			ResultsLabels[1].text = "a corpse was discovered on school grounds.";
			ResultsLabels[2].text = "The school faculty was informed of the corpse,";
			ResultsLabels[3].text = "and the police were called to the school.";
			ResultsLabels[4].text = "No one is allowed to leave school until a police investigation has taken place.";
			TeacherReport = true;
			Show = true;
		}
		else if (Reputation.Reputation <= -100f)
		{
			ResultsLabels[0].text = Protagonist + "'s bizarre conduct has been observed and discussed by many people.";
			ResultsLabels[1].text = "Word of " + Protagonist + "'s strange behavior has reached Senpai.";
			ResultsLabels[2].text = "Senpai is now aware that " + Protagonist + " is a deranged person.";
			ResultsLabels[3].text = "From this day forward, Senpai will fear and avoid " + Protagonist + ".";
			ResultsLabels[4].text = Protagonist + " will never have her Senpai's love.";
			LowRep = true;
		}
		else if (!Suicide && !PoisonScene)
		{
			if (Clock.HourTime < 18f)
			{
				if (Yandere.InClass)
				{
					if (SkippingPastPoison)
					{
						ResultsLabels[0].text = "A student has died from eating poisoned food.";
					}
					else
					{
						ResultsLabels[0].text = Protagonist + " attempts to attend class without disposing of a corpse.";
					}
				}
				else if (Yandere.Resting && Corpses > 0)
				{
					ResultsLabels[0].text = Protagonist + " rests without disposing of a corpse.";
				}
				else if (Yandere.Resting)
				{
					if (GameGlobals.SenpaiMourning)
					{
						ResultsLabels[0].text = Protagonist + " recovers from her injuries, and is ready to leave school.";
					}
					else
					{
						ResultsLabels[0].text = Protagonist + " recovers from her injuries, and is ready to leave school.";
					}
				}
				else if (GameGlobals.SenpaiMourning)
				{
					ResultsLabels[0].text = Protagonist + " is ready to leave school.";
				}
				else
				{
					ResultsLabels[0].text = Protagonist + " is ready to leave school.";
				}
			}
			else
			{
				ResultsLabels[0].text = "The school day has ended. Faculty members must walk through the school and tell any lingering students to leave.";
			}
			if (Suspended)
			{
				Yandere.Class.Portal.EndFinalEvents();
				if (Clock.Weekday == 1)
				{
					RemainingDays = 5;
				}
				else if (Clock.Weekday == 2)
				{
					RemainingDays = 4;
				}
				else if (Clock.Weekday == 3)
				{
					RemainingDays = 3;
				}
				else if (Clock.Weekday == 4)
				{
					RemainingDays = 2;
				}
				else if (Clock.Weekday == 5)
				{
					RemainingDays = 1;
				}
				if (RemainingDays - SuspensionLength <= 0 && !StudentManager.RivalEliminated)
				{
					ResultsLabels[0].text = "Due to her suspension,";
					ResultsLabels[1].text = Protagonist + " will be unable";
					ResultsLabels[2].text = "to prevent her rival";
					ResultsLabels[3].text = "from confessing to Senpai.";
					ResultsLabels[4].text = Protagonist + " will never have Senpai.";
					GameOver = true;
				}
				else if (SuspensionLength == 1)
				{
					ResultsLabels[0].text = Protagonist + " has been sent home early.";
					ResultsLabels[1].text = "";
					ResultsLabels[2].text = "She won't be able to see Senpai again until tomorrow.";
					ResultsLabels[3].text = "";
					ResultsLabels[4].text = Protagonist + "'s heart aches as she thinks of Senpai.";
				}
				else
				{
					ResultsLabels[0].text = Protagonist + " has been sent home early.";
					ResultsLabels[1].text = "";
					ResultsLabels[2].text = "She will have to wait " + (SuspensionLength - 1) + " days before returning to school.";
					ResultsLabels[3].text = "";
					ResultsLabels[4].text = Protagonist + "'s heart aches as she thinks of Senpai.";
				}
				return;
			}
			BloodyClothing -= RedPaintClothing;
			if (Corpses == 0 && LimbParent.childCount == 0 && BloodParent.childCount == 0 && BloodyWeapons == 0 && BloodyClothing == 0 && !SuicideScene)
			{
				if (Yandere.Sanity < 66.66666f || (Yandere.Bloodiness > 0f && !Yandere.RedPaint))
				{
					ResultsLabels[1].text = Protagonist + " is approached by a faculty member.";
					if (Yandere.Bloodiness > 0f)
					{
						ResultsLabels[2].text = "The faculty member immediately notices the blood staining her clothing.";
						ResultsLabels[3].text = Protagonist + " is not able to convince the faculty member that nothing is wrong.";
						ResultsLabels[4].text = "The faculty member calls the police.";
						TeacherReport = true;
						Show = true;
					}
					else
					{
						ResultsLabels[2].text = Protagonist + " exhibited extremely erratic behavior, frightening the faculty member.";
						ResultsLabels[3].text = "The faculty member becomes angry with " + Protagonist + ", but " + Protagonist + " leaves before the situation gets worse.";
						ResultsLabels[4].text = Protagonist + " returns home.";
					}
					return;
				}
				if (Yandere.Inventory.Ring || (Yandere.Inventory.RivalPhone && StudentManager.CommunalLocker.RivalPhone.StudentID == StudentManager.RivalID && !StudentManager.RivalEliminated) || (Yandere.Inventory.RivalPhone && StudentManager.CommunalLocker.RivalPhone.StudentID != StudentManager.RivalID && StudentManager.Students[StudentManager.CommunalLocker.RivalPhone.StudentID].Alive))
				{
					if (Yandere.Inventory.Ring)
					{
						ResultsLabels[1].text = "A student tells the faculty that her ring is missing.";
						ResultsLabels[2].text = "Suspecting theft, the faculty check all students' belongings before they are allowed to leave school.";
						ResultsLabels[3].text = "The stolen ring is found on " + Protagonist + "'s person.";
						ResultsLabels[4].text = Protagonist + " is expelled from school for stealing from another student.";
					}
					else if (StudentManager.CommunalLocker.RivalPhone.StudentID == StudentManager.RivalID)
					{
						ResultsLabels[1].text = "Osana tells the faculty that her phone is missing.";
						ResultsLabels[2].text = "Suspecting theft, the faculty check all students' belongings before they are allowed to leave school.";
						ResultsLabels[3].text = "Osana's stolen phone is found on " + Protagonist + "'s person.";
						ResultsLabels[4].text = Protagonist + " is expelled from school for stealing from another student.";
					}
					else
					{
						ResultsLabels[1].text = "A student tells the faculty that her phone is missing.";
						ResultsLabels[2].text = "Suspecting theft, the faculty check all students' belongings before they are allowed to leave school.";
						ResultsLabels[3].text = "The student's stolen phone is found on " + Protagonist + "'s person.";
						ResultsLabels[4].text = Protagonist + " is expelled from school for stealing from another student.";
					}
					GameOver = true;
					Heartbroken.Counselor.Expelled = true;
					return;
				}
				if (DateGlobals.Weekday == DayOfWeek.Friday)
				{
					if (!StudentManager.RivalEliminated && StudentManager.SabotageProgress < 5 && !StudentManager.LoveManager.ConfessToSuitor)
					{
						ResultsLabels[0].text = "It is 6:00 PM on Friday.";
						ResultsLabels[1].text = Protagonist + "'s rival asks Senpai to meet her under the cherry tree behind the school.";
						ResultsLabels[2].text = "As cherry blossoms fall around them...";
						ResultsLabels[3].text = "...she confesses her feelings for Senpai.";
						ResultsLabels[4].text = Protagonist + " watches from a short distance away...";
						BeginConfession = true;
						return;
					}
					if (!StudentManager.RivalEliminated)
					{
						if (StudentManager.LoveManager.ConfessToSuitor)
						{
							StudentManager.RivalEliminated = true;
							EndOfDay.RivalEliminationMethod = RivalEliminationType.Matchmade;
						}
						else if (StudentManager.SabotageProgress == 5)
						{
							StudentManager.RivalEliminated = true;
							EndOfDay.RivalEliminationMethod = RivalEliminationType.Rejected;
						}
					}
					ResultsLabels[0].text = Protagonist + "'s rival is no longer a threat.";
					ResultsLabels[1].text = Protagonist + " considers confessing her love to Senpai...";
					ResultsLabels[2].text = "...but she cannot build up the courage to speak to him.";
					ResultsLabels[3].text = Protagonist + " follows Senpai out of school and watches him from a distance until he has returned to his home.";
					ResultsLabels[4].text = "Then, " + Protagonist + " returns to her own home, and considers what she should do next...";
					return;
				}
				if (Clock.HourTime < 18f)
				{
					if (Yandere.Senpai.position.z > -75f)
					{
						ResultsLabels[1].text = "However, she can't bring herself to leave before Senpai does.";
						ResultsLabels[2].text = Protagonist + " waits at the school's entrance until Senpai eventually appears.";
						ResultsLabels[3].text = "She follows him and watches him from a distance until he has returned to his home.";
						ResultsLabels[4].text = "Then, " + Protagonist + " returns to her house.";
					}
					else
					{
						ResultsLabels[1].text = Protagonist + " quickly runs out of school, determined to catch a glimpse of Senpai as he walks home.";
						ResultsLabels[2].text = "Eventually, she catches up to him.";
						ResultsLabels[3].text = Protagonist + " follows Senpai and watches him from a distance until he has returned to his home.";
						ResultsLabels[4].text = "Then, " + Protagonist + " returns to her house.";
					}
				}
				else
				{
					ResultsLabels[1].text = "Like all other students, " + Protagonist + " is instructed to leave school.";
					ResultsLabels[2].text = "After exiting school, " + Protagonist + " locates Senpai.";
					ResultsLabels[3].text = Protagonist + " follows Senpai and watches him from a distance until he has returned to his home.";
					ResultsLabels[4].text = "Then, " + Protagonist + " returns to her house.";
				}
				if (GameGlobals.SenpaiMourning)
				{
					ResultsLabels[1].text = "Like all other students, " + Protagonist + " is instructed to leave school.";
					ResultsLabels[2].text = Protagonist + " leaves school.";
					ResultsLabels[3].text = Protagonist + " returns to her home.";
					ResultsLabels[4].text = "Her heart aches as she thinks of Senpai.";
				}
				return;
			}
			if (Corpses > 0)
			{
				ResultsLabels[1].text = "While walking around the school, a faculty member discovers a corpse.";
				ResultsLabels[2].text = "The faculty member immediately calls the police.";
				ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
				ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
				TeacherReport = true;
				Show = true;
			}
			else if (LimbParent.childCount > 0)
			{
				ResultsLabels[1].text = "While walking around the school, a faculty member discovers a dismembered body part.";
				ResultsLabels[2].text = "The faculty member decides to call the police.";
				ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
				ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
				TeacherReport = true;
				Show = true;
			}
			else if (BloodParent.childCount > 0 || BloodyClothing > 0)
			{
				ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious blood stain.";
				ResultsLabels[2].text = "The faculty member decides to call the police.";
				ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
				ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
				TeacherReport = true;
				Show = true;
			}
			else if (BloodyWeapons > 0)
			{
				ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious bloody weapon.";
				ResultsLabels[2].text = "The faculty member decides to call the police.";
				ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
				ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
				TeacherReport = true;
				Show = true;
			}
			else if (SuicideScene)
			{
				ResultsLabels[1].text = "While walking around the school, a faculty member discovers a pair of shoes on the rooftop.";
				ResultsLabels[2].text = "The faculty member fears that there has been a suicide, but cannot find a corpse anywhere. The faculty member does not take any action.";
				ResultsLabels[3].text = Protagonist + " leaves school and follows Senpai, watching him as he walks home.";
				ResultsLabels[4].text = "Once he is safely home, " + Protagonist + " returns to her own home.";
				if (GameGlobals.SenpaiMourning)
				{
					ResultsLabels[3].text = Protagonist + " leaves school.";
					ResultsLabels[4].text = Protagonist + " returns home.";
				}
			}
			if (SelfReported)
			{
				ResultsLabels[0].text = Protagonist + " informs a faculty member that something alarming is present at school.";
				ResultsLabels[1].text = "The faculty member confirms that " + Protagonist + " is telling the truth.";
			}
		}
		else if (Suicide)
		{
			if (!Yandere.InClass)
			{
				ResultsLabels[0].text = "The school day has ended. Faculty members must walk through the school and tell any lingering students to leave.";
			}
			else if (Corpses > 0)
			{
				ResultsLabels[0].text = Protagonist + " attempts to attend class without disposing of a corpse.";
			}
			else
			{
				ResultsLabels[0].text = Protagonist + " attempts to attend class without cleaning up some blood.";
			}
			ResultsLabels[1].text = "While walking around the school, a faculty member discovers a corpse.";
			if (SuicideNote)
			{
				ResultsLabels[2].text = "It appears as though a student has committed suicide.";
			}
			else
			{
				ResultsLabels[2].text = "It appears as though a student has fallen from the school rooftop.";
			}
			ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
			ResultsLabels[4].text = "The faculty members agree to call the police and report the student's death.";
			TeacherReport = true;
			Show = true;
		}
		else if (PoisonScene)
		{
			ResultsLabels[0].text = "A faculty member discovers the student who " + Protagonist + " poisoned.";
			ResultsLabels[1].text = "The faculty member calls for an ambulance immediately.";
			ResultsLabels[2].text = "The faculty member suspects that the student's death was a murder.";
			ResultsLabels[3].text = "The faculty member also calls for the police.";
			ResultsLabels[4].text = "The school's students are not allowed to leave until a police investigation has taken place.";
			TeacherReport = true;
			Show = true;
		}
	}

	public void KillStudents()
	{
		for (int i = 1; i < 101; i++)
		{
			if (StudentGlobals.GetStudentDead(i) || !(StudentManager.StudentReps[i] < -150f))
			{
				continue;
			}
			Deaths++;
			PlayerGlobals.Kills++;
			StudentGlobals.SetStudentDead(i, value: true);
			Debug.Log("PlayerGlobals.Kills is being incremented.");
			if (StudentGlobals.MemorialStudents < 9)
			{
				StudentGlobals.MemorialStudents++;
				if (StudentGlobals.MemorialStudents == 1)
				{
					StudentGlobals.MemorialStudent1 = i;
				}
				else if (StudentGlobals.MemorialStudents == 2)
				{
					StudentGlobals.MemorialStudent2 = i;
				}
				else if (StudentGlobals.MemorialStudents == 3)
				{
					StudentGlobals.MemorialStudent3 = i;
				}
				else if (StudentGlobals.MemorialStudents == 4)
				{
					StudentGlobals.MemorialStudent4 = i;
				}
				else if (StudentGlobals.MemorialStudents == 5)
				{
					StudentGlobals.MemorialStudent5 = i;
				}
				else if (StudentGlobals.MemorialStudents == 6)
				{
					StudentGlobals.MemorialStudent6 = i;
				}
				else if (StudentGlobals.MemorialStudents == 7)
				{
					StudentGlobals.MemorialStudent7 = i;
				}
				else if (StudentGlobals.MemorialStudents == 8)
				{
					StudentGlobals.MemorialStudent8 = i;
				}
				else if (StudentGlobals.MemorialStudents == 9)
				{
					StudentGlobals.MemorialStudent9 = i;
				}
			}
		}
		if (Deaths > 0)
		{
			PlayerGlobals.Kills += Deaths;
			Debug.Log("PlayerGlobals.Kills is being incremented.");
			for (int j = 2; j < StudentManager.NPCsTotal + 1; j++)
			{
				if (StudentGlobals.GetStudentDying(j))
				{
					if (j < 90)
					{
						SchoolGlobals.SchoolAtmosphere -= 0.05f;
					}
					else
					{
						SchoolGlobals.SchoolAtmosphere -= 0.15f;
					}
					if (JSON.Students[j].Club == ClubType.Council)
					{
						SchoolGlobals.SchoolAtmosphere -= 1f;
						SchoolGlobals.HighSecurity = true;
					}
					StudentGlobals.SetStudentDead(j, value: true);
				}
			}
			SchoolGlobals.SchoolAtmosphere -= (float)Corpses * 0.05f;
			if (SuicideVictims + DrownVictims + Corpses > 0)
			{
				RagdollScript[] corpseList = CorpseList;
				foreach (RagdollScript ragdollScript in corpseList)
				{
					if (ragdollScript != null && !ragdollScript.Disposed && StudentGlobals.MemorialStudents < 9)
					{
						StudentGlobals.MemorialStudents++;
						if (StudentGlobals.MemorialStudents == 1)
						{
							StudentGlobals.MemorialStudent1 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 2)
						{
							StudentGlobals.MemorialStudent2 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 3)
						{
							StudentGlobals.MemorialStudent3 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 4)
						{
							StudentGlobals.MemorialStudent4 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 5)
						{
							StudentGlobals.MemorialStudent5 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 6)
						{
							StudentGlobals.MemorialStudent6 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 7)
						{
							StudentGlobals.MemorialStudent7 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 8)
						{
							StudentGlobals.MemorialStudent8 = ragdollScript.Student.StudentID;
						}
						else if (StudentGlobals.MemorialStudents == 9)
						{
							StudentGlobals.MemorialStudent9 = ragdollScript.Student.StudentID;
						}
					}
				}
			}
		}
		SchoolGlobals.SchoolAtmosphere = Mathf.Clamp01(SchoolGlobals.SchoolAtmosphere);
		for (int l = 1; l < StudentManager.StudentsTotal; l++)
		{
			StudentScript studentScript = StudentManager.Students[l];
			if (studentScript != null && studentScript.Grudge && studentScript.Persona != PersonaType.Evil)
			{
				StudentGlobals.SetStudentGrudge(l, value: true);
				if (studentScript.OriginalPersona == PersonaType.Sleuth && !StudentGlobals.GetStudentDying(l))
				{
					StudentGlobals.SetStudentGrudge(56, value: true);
					StudentGlobals.SetStudentGrudge(57, value: true);
					StudentGlobals.SetStudentGrudge(58, value: true);
					StudentGlobals.SetStudentGrudge(59, value: true);
					StudentGlobals.SetStudentGrudge(60, value: true);
				}
			}
		}
	}

	public void BeginFadingOut()
	{
		DayOver = true;
		StudentManager.StopMoving();
		Darkness.enabled = true;
		Yandere.StopLaughing();
		Clock.StopTime = true;
		FadeOut = true;
		if (!EndOfDay.gameObject.activeInHierarchy)
		{
			Time.timeScale = 1f;
		}
	}

	public void UpdateCorpses()
	{
		RagdollScript[] corpseList = CorpseList;
		foreach (RagdollScript ragdollScript in corpseList)
		{
			if (ragdollScript != null)
			{
				ragdollScript.Prompt.HideButton[3] = true;
				if (Yandere.Class.PhysicalGrade + Yandere.Class.PhysicalBonus > 0 && !ragdollScript.Tranquil)
				{
					ragdollScript.Prompt.HideButton[3] = false;
				}
			}
		}
	}
}
