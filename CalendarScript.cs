using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class CalendarScript : MonoBehaviour
{
	public PostProcessingProfile NewTitleScreenProfile;

	public SelectiveGrayscale GrayscaleEffect;

	public ChallengeScript Challenge;

	public Vignetting Vignette;

	public GameObject SkipConfirmationWindow;

	public GameObject CongratulationsWindow;

	public GameObject ConfirmationWindow;

	public GameObject AmaiWindow;

	public GameObject DeadlineLabel;

	public GameObject StatsButton;

	public GameObject AmaiButton;

	public GameObject SkipButton;

	public UILabel AtmosphereLabel;

	public UIPanel ChallengePanel;

	public UIPanel CalendarPanel;

	public UISprite Darkness;

	public UITexture Cloud;

	public UITexture Sun;

	public Transform Highlight;

	public Transform Continue;

	public UILabel[] DayNumber;

	public UILabel[] DayLabel;

	public UILabel MonthLabel;

	public UILabel WeekNumber;

	public UILabel YearLabel;

	public UILabel SkipLabel;

	public bool ViewingStats;

	public bool Incremented;

	public bool Eighties;

	public bool LoveSick;

	public bool FadeOut;

	public bool Switch;

	public bool Reset;

	public float Timer;

	public float Target;

	public float Offset = 66.66666f;

	public int Adjustment;

	public int Phase = 1;

	public UILabel[] Labels;

	public GameObject SundayLabel;

	public GameObject EndingLabel;

	public Font VCR;

	private void Start()
	{
		NewTitleScreenProfile.colorGrading.enabled = false;
		SetVignettePink();
		PlayerGlobals.BringingItem = 0;
		if (GameGlobals.RivalEliminationID == 0 && StudentGlobals.GetStudentDead(10 + DateGlobals.Week))
		{
			Debug.Log("Upon entering the Calendar screen, the rival was dead, but RivalEliminationID was 0. Setting it to 1.");
			GameGlobals.RivalEliminationID = 1;
		}
		Debug.Log("At Calendar Screen, SpecificEliminationID is currently: " + GameGlobals.SpecificEliminationID);
		Debug.Log("At Calendar Screen, RivalEliminationID is currently: " + GameGlobals.RivalEliminationID);
		Debug.Log("MaleUniform is: " + StudentGlobals.MaleUniform + " and FemaleUniform is: " + StudentGlobals.FemaleUniform);
		if (GameGlobals.Eighties)
		{
			if (DateGlobals.Week == 1)
			{
				Debug.Log("Rival is cute.");
			}
			else if (DateGlobals.Week == 2)
			{
				Debug.Log("Rival is pryomaniac.");
			}
			else if (DateGlobals.Week == 3)
			{
				Debug.Log("Rival is bookworm.");
			}
			else if (DateGlobals.Week == 4)
			{
				Debug.Log("Rival is sporty.");
			}
			else if (DateGlobals.Week == 5)
			{
				Debug.Log("Rival is rich.");
			}
			else if (DateGlobals.Week == 6)
			{
				Debug.Log("Rival is idol.");
			}
			else if (DateGlobals.Week == 7)
			{
				Debug.Log("Rival is prodigy.");
			}
			else if (DateGlobals.Week == 8)
			{
				Debug.Log("Rival is traditional.");
			}
			else if (DateGlobals.Week == 9)
			{
				Debug.Log("Rival is gravure.");
			}
			else if (DateGlobals.Week == 10)
			{
				Debug.Log("Rival is investigator.");
			}
		}
		LoveSickCheck();
		if (!ConversationGlobals.GetTopicDiscovered(1))
		{
			for (int i = 1; i < 26; i++)
			{
				ConversationGlobals.SetTopicDiscovered(i, value: true);
			}
		}
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			OptionGlobals.EnableShadows = false;
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 1f;
			PlayerGlobals.Money = 10f;
			PlayerGlobals.SetCannotBringItem(4, value: true);
			PlayerGlobals.SetCannotBringItem(5, value: true);
			PlayerGlobals.SetCannotBringItem(6, value: true);
			PlayerGlobals.SetCannotBringItem(7, value: true);
		}
		if (DateGlobals.PassDays > 0 && !SchoolGlobals.HighSecurity)
		{
			SchoolGlobals.SchoolAtmosphere += 0.05f;
		}
		ImproveSchoolAtmosphere();
		DateGlobals.DayPassed = true;
		Continue.transform.localPosition = new Vector3(Continue.transform.localPosition.x, -610f, Continue.transform.localPosition.z);
		ChallengePanel.alpha = 0f;
		CalendarPanel.alpha = 1f;
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 1f);
		Time.timeScale = 1f;
		if (GameGlobals.RivalEliminationID > 0)
		{
			DeadlineLabel.SetActive(value: false);
		}
		WeekNumber.text = "WEEK " + DateGlobals.Week;
		LoveSickCheck();
		ChangeDayColor();
		if (GameGlobals.Eighties)
		{
			BecomeEighties();
		}
		else
		{
			AmaiButton.SetActive(value: false);
			StatsButton.SetActive(value: false);
			SkipButton.transform.localPosition = new Vector3(-120f, -500f, 0f);
			if (DateGlobals.Week == 1)
			{
				DayNumber[1].text = "3";
				DayNumber[2].text = "4";
				DayNumber[3].text = "5";
				DayNumber[4].text = "6";
				DayNumber[5].text = "7";
				DayNumber[6].text = "8";
				DayNumber[7].text = "9";
				Adjustment = -50;
			}
			else if (DateGlobals.Week == 2)
			{
				DayNumber[1].text = "10";
				DayNumber[2].text = "11";
				DayNumber[3].text = "12";
				DayNumber[4].text = "13";
				DayNumber[5].text = "14";
				DayNumber[6].text = "15";
				DayNumber[7].text = "16";
				Adjustment = -50;
				AmaiButton.SetActive(value: true);
			}
		}
		Highlight.localPosition = new Vector3(-750f + Offset + 250f * (float)DateGlobals.Weekday + (float)Adjustment, Highlight.localPosition.y, Highlight.localPosition.z);
		if (DateGlobals.Weekday == DayOfWeek.Saturday)
		{
			Highlight.localPosition = new Vector3(-1150f, Highlight.localPosition.y, Highlight.localPosition.z);
		}
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (!FadeOut)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a - Time.deltaTime);
			if (Darkness.color.a < 0f)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 0f);
			}
			if (Timer > 1f)
			{
				if (!Incremented)
				{
					if (DateGlobals.PassDays > 0)
					{
						GetComponent<AudioSource>().pitch = 1f - (0.8f - SchoolGlobals.SchoolAtmosphere * 0.8f);
						GetComponent<AudioSource>().Play();
					}
					while (DateGlobals.PassDays > 0)
					{
						DateGlobals.GameplayDay++;
						DateGlobals.Weekday++;
						DateGlobals.PassDays--;
						ChangeDayColor();
					}
					Target = 250f * (float)DateGlobals.Weekday + (float)Adjustment;
					if (DateGlobals.Weekday > DayOfWeek.Saturday)
					{
						Darkness.color = new Color(0f, 0f, 0f, 0f);
						DateGlobals.Weekday = DayOfWeek.Sunday;
						Target = Adjustment;
					}
					if (!Eighties && DateGlobals.Weekday != 0 && DateGlobals.Weekday < DayOfWeek.Saturday && GameGlobals.RivalEliminationID > 0 && !GameGlobals.InformedAboutSkipping && DateGlobals.Week < 2)
					{
						GameGlobals.InformedAboutSkipping = true;
						CongratulationsWindow.SetActive(value: true);
					}
					Incremented = true;
					ChangeDayColor();
				}
				else
				{
					Highlight.localPosition = new Vector3(Mathf.Lerp(Highlight.localPosition.x, -750f + Offset + Target, Time.deltaTime * 10f), Highlight.localPosition.y, Highlight.localPosition.z);
				}
				if (Timer > 2f)
				{
					Continue.localPosition = new Vector3(Continue.localPosition.x, Mathf.Lerp(Continue.localPosition.y, -500f, Time.deltaTime * 10f), Continue.localPosition.z);
					if (!Switch)
					{
						if (ViewingStats)
						{
							if (Input.GetButtonDown("B"))
							{
								Switch = true;
							}
						}
						else if (CongratulationsWindow.activeInHierarchy)
						{
							if (Input.GetButtonDown("A"))
							{
								CongratulationsWindow.SetActive(value: false);
							}
						}
						else if (ConfirmationWindow.activeInHierarchy)
						{
							if (Input.GetButtonDown("A"))
							{
								FadeOut = true;
								Reset = true;
							}
							if (Input.GetButtonDown("B"))
							{
								ConfirmationWindow.SetActive(value: false);
							}
						}
						else if (SkipConfirmationWindow.activeInHierarchy)
						{
							if (Input.GetButtonDown("A"))
							{
								SundayLabel.SetActive(value: false);
								if (StudentGlobals.MemorialStudents > 0)
								{
									StudentGlobals.MemorialStudents = 0;
									StudentGlobals.MemorialStudent1 = 0;
									StudentGlobals.MemorialStudent2 = 0;
									StudentGlobals.MemorialStudent3 = 0;
									StudentGlobals.MemorialStudent4 = 0;
									StudentGlobals.MemorialStudent5 = 0;
									StudentGlobals.MemorialStudent6 = 0;
									StudentGlobals.MemorialStudent7 = 0;
									StudentGlobals.MemorialStudent8 = 0;
									StudentGlobals.MemorialStudent9 = 0;
								}
								SkipConfirmationWindow.SetActive(value: false);
								ClassGlobals.BonusStudyPoints += 10;
								DateGlobals.Weekday++;
								Incremented = false;
								if (!SchoolGlobals.HighSecurity)
								{
									SchoolGlobals.SchoolAtmosphere += 0.05f;
								}
								ImproveSchoolAtmosphere();
								if ((GameGlobals.RivalEliminationID == 0 && DateGlobals.Weekday == DayOfWeek.Friday) || DateGlobals.Weekday > DayOfWeek.Friday)
								{
									SkipButton.SetActive(value: false);
									if (Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
									{
										SkipButton.SetActive(value: true);
									}
								}
							}
							if (Input.GetButtonDown("B"))
							{
								SkipConfirmationWindow.SetActive(value: false);
							}
						}
						else if (AmaiWindow.activeInHierarchy)
						{
							if (Input.GetButtonDown("A"))
							{
								AmaiButton.SetActive(value: false);
								AmaiWindow.SetActive(value: false);
								DateGlobals.Weekday++;
								Incremented = false;
								if (!SchoolGlobals.HighSecurity)
								{
									SchoolGlobals.SchoolAtmosphere += 0.05f;
								}
								ImproveSchoolAtmosphere();
								AmaiWindow.SetActive(value: false);
							}
							if (Input.GetButtonDown("B"))
							{
								AmaiWindow.SetActive(value: false);
							}
						}
						else
						{
							if (Input.GetButtonDown("A"))
							{
								FadeOut = true;
							}
							else if (Input.GetButtonDown("B"))
							{
								ConfirmationWindow.SetActive(value: true);
							}
							else if (Input.GetButtonDown("X"))
							{
								Switch = true;
							}
							if (SkipButton.activeInHierarchy)
							{
								if (Input.GetButtonDown("Y"))
								{
									SkipConfirmationWindow.SetActive(value: true);
								}
							}
							else if (AmaiButton.activeInHierarchy && Input.GetButtonDown("Y"))
							{
								AmaiWindow.SetActive(value: true);
							}
							if (Input.GetKeyDown(KeyCode.Z))
							{
								if (SchoolGlobals.SchoolAtmosphere > 0f)
								{
									SchoolGlobals.SchoolAtmosphere -= 0.1f;
								}
								else
								{
									SchoolGlobals.SchoolAtmosphere = 100f;
								}
								SceneManager.LoadScene(SceneManager.GetActiveScene().name);
							}
						}
					}
				}
			}
		}
		else
		{
			Continue.localPosition = new Vector3(Continue.localPosition.x, Mathf.Lerp(Continue.localPosition.y, -610f, Time.deltaTime * 10f), Continue.localPosition.z);
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a + Time.deltaTime);
			if (Darkness.color.a >= 1f)
			{
				if (Reset)
				{
					bool eighties = GameGlobals.Eighties;
					int profile = GameGlobals.Profile;
					bool debug = GameGlobals.Debug;
					int femaleUniform = StudentGlobals.FemaleUniform;
					int maleUniform = StudentGlobals.MaleUniform;
					Globals.DeleteAll();
					PlayerPrefs.SetInt("ProfileCreated_" + profile, 1);
					GameGlobals.Eighties = eighties;
					GameGlobals.Profile = profile;
					GameGlobals.Debug = debug;
					StudentGlobals.FemaleUniform = femaleUniform;
					StudentGlobals.MaleUniform = maleUniform;
					GameGlobals.LoveSick = LoveSick;
					DateGlobals.PassDays = 1;
					if (GameGlobals.Eighties)
					{
						for (int i = 1; i < 101; i++)
						{
							StudentGlobals.SetStudentPhotographed(i, value: true);
						}
					}
					if (eighties)
					{
						OptionGlobals.DisableTint = false;
					}
					else
					{
						OptionGlobals.DisableTint = true;
					}
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
				else
				{
					if (HomeGlobals.Night)
					{
						HomeGlobals.Night = false;
					}
					if (DateGlobals.Weekday == DayOfWeek.Saturday)
					{
						if (!Eighties)
						{
							SceneManager.LoadScene("BusStopScene");
						}
						else
						{
							Debug.Log("As of now, on Saturday, the current week is " + DateGlobals.Week);
							GameGlobals.EightiesCutsceneID = DateGlobals.Week + 1;
							SceneManager.LoadScene("EightiesCutsceneScene");
						}
					}
					else
					{
						if (DateGlobals.Weekday == DayOfWeek.Sunday && !Eighties)
						{
							HomeGlobals.Night = true;
						}
						SceneManager.LoadScene("HomeScene");
					}
				}
			}
		}
		if (Switch)
		{
			if (!ViewingStats)
			{
				if (Phase == 1)
				{
					CalendarPanel.alpha -= Time.deltaTime;
					if (CalendarPanel.alpha <= 0f)
					{
						Phase++;
					}
				}
				else
				{
					ChallengePanel.alpha += Time.deltaTime;
					if (ChallengePanel.alpha >= 1f)
					{
						ViewingStats = true;
						Switch = false;
						Phase = 1;
					}
				}
			}
			else if (Phase == 1)
			{
				ChallengePanel.alpha -= Time.deltaTime;
				if (ChallengePanel.alpha <= 0f)
				{
					Phase++;
				}
			}
			else
			{
				CalendarPanel.alpha += Time.deltaTime;
				if (CalendarPanel.alpha >= 1f)
				{
					ViewingStats = false;
					Switch = false;
					Phase = 1;
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			GameGlobals.LoveSick = !GameGlobals.LoveSick;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void ChangeDayColor()
	{
		UILabel[] dayLabel = DayLabel;
		for (int i = 0; i < dayLabel.Length; i++)
		{
			_ = dayLabel[i];
		}
		dayLabel = DayNumber;
		for (int i = 0; i < dayLabel.Length; i++)
		{
			_ = dayLabel[i] != null;
		}
		if ((GameGlobals.RivalEliminationID == 0 && DateGlobals.Weekday < DayOfWeek.Friday) || (GameGlobals.RivalEliminationID > 0 && DateGlobals.Weekday < DayOfWeek.Saturday))
		{
			SkipButton.SetActive(value: true);
		}
		else
		{
			SkipButton.SetActive(value: false);
			if (Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
			{
				SkipButton.SetActive(value: true);
			}
		}
		if (!Eighties && DateGlobals.Week == 2)
		{
			SkipButton.SetActive(value: false);
		}
	}

	public void LoveSickCheck()
	{
		if (!GameGlobals.LoveSick)
		{
			return;
		}
		SchoolGlobals.SchoolAtmosphereSet = true;
		SchoolGlobals.SchoolAtmosphere = 0f;
		LoveSick = true;
		Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
		GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject obj in array)
		{
			UISprite component = obj.GetComponent<UISprite>();
			if (component != null)
			{
				component.color = new Color(1f, 0f, 0f, component.color.a);
			}
			UITexture component2 = obj.GetComponent<UITexture>();
			if (component2 != null)
			{
				component2.color = new Color(1f, 0f, 0f, component2.color.a);
			}
			UILabel component3 = obj.GetComponent<UILabel>();
			if (component3 != null)
			{
				if (component3.color != Color.black)
				{
					component3.color = new Color(1f, 0f, 0f, component3.color.a);
				}
				if (component3.text == "?")
				{
					component3.color = new Color(1f, 0f, 0f, component3.color.a);
				}
			}
		}
		Darkness.color = Color.black;
		AtmosphereLabel.enabled = false;
		Cloud.enabled = false;
		Sun.enabled = false;
	}

	public void SetVignettePink()
	{
		VignetteModel.Settings settings = NewTitleScreenProfile.vignette.settings;
		settings.color = new Color(1f, 0.75f, 1f, 1f);
		NewTitleScreenProfile.vignette.settings = settings;
	}

	private void ImproveSchoolAtmosphere()
	{
		if (SchoolGlobals.SchoolAtmosphere > 1f)
		{
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		Sun.color = new Color(Sun.color.r, Sun.color.g, Sun.color.b, SchoolGlobals.SchoolAtmosphere);
		Cloud.color = new Color(Cloud.color.r, Cloud.color.g, Cloud.color.b, 1f - SchoolGlobals.SchoolAtmosphere);
		AtmosphereLabel.text = (SchoolGlobals.SchoolAtmosphere * 100f).ToString("f0") + "%";
		float num = 1f - SchoolGlobals.SchoolAtmosphere;
		GrayscaleEffect.desaturation = num;
		Vignette.intensity = num * 5f;
		Vignette.blur = num;
		Vignette.chromaticAberration = num;
	}

	private void BecomeEighties()
	{
		StudentGlobals.FemaleUniform = 6;
		StudentGlobals.MaleUniform = 1;
		if (DateGlobals.Weekday == DayOfWeek.Sunday && DateGlobals.PassDays == 0)
		{
			SundayLabel.SetActive(value: true);
			SkipButton.SetActive(value: true);
		}
		Eighties = true;
		Labels = UnityEngine.Object.FindSceneObjectsOfType(typeof(UILabel)) as UILabel[];
		for (int i = 0; i < Labels.Length; i++)
		{
			EightiesifyLabel(Labels[i]);
		}
		EightiesifyLabel(SkipLabel);
		for (int i = 1; i < DayNumber.Length; i++)
		{
			DayNumber[i].fontSize = 150;
			DayNumber[i].effectDistance = new Vector2(10f, 10f);
		}
		for (int i = 0; i < DayLabel.Length; i++)
		{
			DayLabel[i].pivot = UIWidget.Pivot.Center;
			DayLabel[i].transform.localPosition = new Vector3(0f, 120f, 0f);
			DayLabel[i].transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
		}
		Camera.main.backgroundColor = new Color(0f, 0f, 0.75f, 1f);
		AtmosphereLabel.color = new Color(0f, 0f, 0f, 1f);
		YearLabel.text = "1989";
		Offset = 0f;
		Highlight.localScale = new Vector3(1f, 1.25f, 1f);
		DeadlineLabel.transform.localPosition = new Vector3(500f, -200f, 0f);
		Continue.localPosition = new Vector3(650f, Continue.localPosition.y, Continue.localPosition.z);
		if (DateGlobals.Week == 1)
		{
			DayNumber[1].text = "2";
			DayNumber[2].text = "3";
			DayNumber[3].text = "4";
			DayNumber[4].text = "5";
			DayNumber[5].text = "6";
			DayNumber[6].text = "7";
			DayNumber[7].text = "8";
		}
		else if (DateGlobals.Week == 2)
		{
			DayNumber[1].text = "9";
			DayNumber[2].text = "10";
			DayNumber[3].text = "11";
			DayNumber[4].text = "12";
			DayNumber[5].text = "13";
			DayNumber[6].text = "14";
			DayNumber[7].text = "15";
		}
		else if (DateGlobals.Week == 3)
		{
			DayNumber[1].text = "16";
			DayNumber[2].text = "17";
			DayNumber[3].text = "18";
			DayNumber[4].text = "19";
			DayNumber[5].text = "20";
			DayNumber[6].text = "21";
			DayNumber[7].text = "22";
		}
		else if (DateGlobals.Week == 4)
		{
			DayNumber[1].text = "23";
			DayNumber[2].text = "24";
			DayNumber[3].text = "25";
			DayNumber[4].text = "26";
			DayNumber[5].text = "27";
			DayNumber[6].text = "28";
			DayNumber[7].text = "29";
		}
		else if (DateGlobals.Week == 5)
		{
			DayNumber[1].text = "30";
			DayNumber[2].text = "1";
			DayNumber[3].text = "2";
			DayNumber[4].text = "3";
			DayNumber[5].text = "4";
			DayNumber[6].text = "5";
			DayNumber[7].text = "6";
		}
		else if (DateGlobals.Week == 6)
		{
			DayNumber[1].text = "7";
			DayNumber[2].text = "8";
			DayNumber[3].text = "9";
			DayNumber[4].text = "10";
			DayNumber[5].text = "11";
			DayNumber[6].text = "12";
			DayNumber[7].text = "13";
		}
		else if (DateGlobals.Week == 7)
		{
			DayNumber[1].text = "14";
			DayNumber[2].text = "15";
			DayNumber[3].text = "16";
			DayNumber[4].text = "17";
			DayNumber[5].text = "18";
			DayNumber[6].text = "19";
			DayNumber[7].text = "20";
		}
		else if (DateGlobals.Week == 8)
		{
			DayNumber[1].text = "21";
			DayNumber[2].text = "22";
			DayNumber[3].text = "23";
			DayNumber[4].text = "24";
			DayNumber[5].text = "25";
			DayNumber[6].text = "26";
			DayNumber[7].text = "27";
		}
		else if (DateGlobals.Week == 9)
		{
			DayNumber[1].text = "28";
			DayNumber[2].text = "29";
			DayNumber[3].text = "30";
			DayNumber[4].text = "31";
			DayNumber[5].text = "1";
			DayNumber[6].text = "2";
			DayNumber[7].text = "3";
		}
		else if (DateGlobals.Week == 10)
		{
			DayNumber[1].text = "4";
			DayNumber[2].text = "5";
			DayNumber[3].text = "6";
			DayNumber[4].text = "7";
			DayNumber[5].text = "8";
			DayNumber[6].text = "9";
			DayNumber[7].text = "10";
		}
		else if (DateGlobals.Week == 11)
		{
			GameGlobals.RivalEliminationID = 1;
			EndingLabel.SetActive(value: true);
			DayNumber[1].text = "11";
			DayNumber[2].text = "12";
			DayNumber[3].text = "13";
			DayNumber[4].text = "14";
			DayNumber[5].text = "15";
			DayNumber[6].text = "16";
			DayNumber[7].text = "17";
		}
		if ((DateGlobals.Week == 9 && DateGlobals.Weekday > DayOfWeek.Wednesday) || DateGlobals.Week > 9)
		{
			MonthLabel.text = "JUNE";
		}
		else if ((DateGlobals.Week == 5 && DateGlobals.Weekday > DayOfWeek.Sunday) || DateGlobals.Week > 5)
		{
			MonthLabel.text = "MAY";
		}
	}

	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}
}
