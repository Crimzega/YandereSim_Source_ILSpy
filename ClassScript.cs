using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassScript : MonoBehaviour
{
	public CutsceneManagerScript CutsceneManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public SchemesScript Schemes;

	public PortalScript Portal;

	public GameObject Poison;

	public UILabel StudyPointsLabel;

	public UILabel[] SubjectLabels;

	public UILabel GradeUpDesc;

	public UILabel GradeUpName;

	public UILabel DescLabel;

	public UISprite Darkness;

	public Transform[] Subject1Bars;

	public Transform[] Subject2Bars;

	public Transform[] Subject3Bars;

	public Transform[] Subject4Bars;

	public Transform[] Subject5Bars;

	public string[] Subject1GradeText;

	public string[] Subject2GradeText;

	public string[] Subject3GradeText;

	public string[] Subject4GradeText;

	public string[] Subject5GradeText;

	public Transform GradeUpWindow;

	public Transform Highlight;

	public int[] SubjectTemp;

	public int[] Subject;

	public string[] Desc;

	public int GradeUpSubject;

	public int BonusPoints;

	public int StudyPoints;

	public int Selected;

	public int Grade;

	public bool GradeUp;

	public bool Show;

	public int Biology;

	public int Chemistry;

	public int Language;

	public int Physical;

	public int Psychology;

	public int BiologyGrade;

	public int ChemistryGrade;

	public int LanguageGrade;

	public int PhysicalGrade;

	public int PsychologyGrade;

	public int BiologyBonus;

	public int ChemistryBonus;

	public int LanguageBonus;

	public int PhysicalBonus;

	public int PsychologyBonus;

	public int Seduction;

	public int Numbness;

	public int Social;

	public int Stealth;

	public int Speed;

	public int Enlightenment;

	public int SpeedBonus;

	public int SocialBonus;

	public int StealthBonus;

	public int SeductionBonus;

	public int NumbnessBonus;

	public int EnlightenmentBonus;

	public bool Initialized;

	private void Start()
	{
		if (Portal == null || !Portal.StudentManager.ReturnedFromSave)
		{
			GetStats();
		}
		if (SceneManager.GetActiveScene().name != "SchoolScene")
		{
			base.enabled = false;
			return;
		}
		GradeUpWindow.localScale = Vector3.zero;
		Subject[1] = Biology;
		Subject[2] = Chemistry;
		Subject[3] = Language;
		Subject[4] = Physical;
		Subject[5] = Psychology;
		DescLabel.text = Desc[Selected];
		UpdateSubjectLabels();
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 1f);
		UpdateBars();
	}

	public void GetStats()
	{
		if (!Initialized)
		{
			BonusPoints += ClassGlobals.BonusStudyPoints;
			Initialized = true;
		}
		Biology = ClassGlobals.Biology;
		Chemistry = ClassGlobals.Chemistry;
		Language = ClassGlobals.Language;
		Physical = ClassGlobals.Physical;
		Psychology = ClassGlobals.Psychology;
		BiologyGrade = ClassGlobals.BiologyGrade;
		ChemistryGrade = ClassGlobals.ChemistryGrade;
		LanguageGrade = ClassGlobals.LanguageGrade;
		PhysicalGrade = ClassGlobals.PhysicalGrade;
		PsychologyGrade = ClassGlobals.PsychologyGrade;
		if (BiologyBonus == 0)
		{
			BiologyBonus = ClassGlobals.BiologyBonus;
		}
		if (ChemistryBonus == 0)
		{
			ChemistryBonus = ClassGlobals.ChemistryBonus;
		}
		if (LanguageBonus == 0)
		{
			LanguageBonus = ClassGlobals.LanguageBonus;
		}
		if (PhysicalBonus == 0)
		{
			PhysicalBonus = ClassGlobals.PhysicalBonus;
		}
		if (PsychologyBonus == 0)
		{
			PsychologyBonus = ClassGlobals.PsychologyBonus;
		}
		Seduction = PlayerGlobals.Seduction;
		Numbness = PlayerGlobals.Numbness;
		Enlightenment = PlayerGlobals.Enlightenment;
		if (SpeedBonus == 0)
		{
			SpeedBonus = PlayerGlobals.SpeedBonus;
		}
		if (SocialBonus == 0)
		{
			SocialBonus = PlayerGlobals.SocialBonus;
		}
		if (StealthBonus == 0)
		{
			StealthBonus = PlayerGlobals.StealthBonus;
		}
		if (SeductionBonus == 0)
		{
			SeductionBonus = PlayerGlobals.SeductionBonus;
		}
		if (NumbnessBonus == 0)
		{
			NumbnessBonus = PlayerGlobals.NumbnessBonus;
		}
		if (EnlightenmentBonus == 0)
		{
			EnlightenmentBonus = PlayerGlobals.EnlightenmentBonus;
		}
	}

	private void Update()
	{
		if (Show)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a - Time.deltaTime);
			if (!(Darkness.color.a <= 0f))
			{
				return;
			}
			if (!Portal.Yandere.NoDebug)
			{
				if (Input.GetKeyDown(KeyCode.Backslash))
				{
					GivePoints();
				}
				if (Input.GetKeyDown(KeyCode.P))
				{
					MaxPhysical();
				}
			}
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 0f);
			if (InputManager.TappedDown)
			{
				Selected++;
				if (Selected > 5)
				{
					Selected = 1;
				}
				Highlight.localPosition = new Vector3(Highlight.localPosition.x, 375f - 125f * (float)Selected, Highlight.localPosition.z);
				DescLabel.text = Desc[Selected];
				UpdateSubjectLabels();
			}
			if (InputManager.TappedUp)
			{
				Selected--;
				if (Selected < 1)
				{
					Selected = 5;
				}
				Highlight.localPosition = new Vector3(Highlight.localPosition.x, 375f - 125f * (float)Selected, Highlight.localPosition.z);
				DescLabel.text = Desc[Selected];
				UpdateSubjectLabels();
			}
			if (InputManager.TappedRight && StudyPoints > 0 && Subject[Selected] + SubjectTemp[Selected] < 100)
			{
				SubjectTemp[Selected]++;
				StudyPoints--;
				UpdateLabel();
				UpdateBars();
			}
			if (InputManager.TappedLeft && SubjectTemp[Selected] > 0)
			{
				SubjectTemp[Selected]--;
				StudyPoints++;
				UpdateLabel();
				UpdateBars();
			}
			if (Input.GetButtonDown("A"))
			{
				Show = false;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Biology = Subject[1] + SubjectTemp[1];
				Chemistry = Subject[2] + SubjectTemp[2];
				Language = Subject[3] + SubjectTemp[3];
				Physical = Subject[4] + SubjectTemp[4];
				Psychology = Subject[5] + SubjectTemp[5];
				for (int i = 0; i < 6; i++)
				{
					Subject[i] += SubjectTemp[i];
					SubjectTemp[i] = 0;
				}
				CheckForGradeUp();
			}
			return;
		}
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a + Time.deltaTime);
		if (!(Darkness.color.a >= 1f))
		{
			return;
		}
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 1f);
		if (!GradeUp)
		{
			if (GradeUpWindow.localScale.x > 0.1f)
			{
				GradeUpWindow.localScale = Vector3.Lerp(GradeUpWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else
			{
				GradeUpWindow.localScale = Vector3.zero;
			}
			if (!(GradeUpWindow.localScale.x < 0.01f))
			{
				return;
			}
			GradeUpWindow.localScale = Vector3.zero;
			CheckForGradeUp();
			if (!GradeUp)
			{
				if (ChemistryGrade > 0 && Poison != null)
				{
					Poison.SetActive(value: true);
				}
				StudentManagerScript studentManager = Portal.Yandere.StudentManager;
				if (CutsceneManager.Scheme > 0 && studentManager.Students[studentManager.RivalID] != null && studentManager.Students[studentManager.RivalID].Alive && !studentManager.Students[studentManager.RivalID].Tranquil)
				{
					SchemeGlobals.SetSchemeStage(CutsceneManager.Scheme, 100);
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Continue";
					PromptBar.UpdateButtons();
					CutsceneManager.gameObject.SetActive(value: true);
					Schemes.UpdateInstructions();
					base.gameObject.SetActive(value: false);
				}
				else if (!Portal.FadeOut)
				{
					Portal.Yandere.PhysicalGrade = PhysicalGrade;
					PromptBar.Show = false;
					Portal.Proceed = true;
					base.gameObject.SetActive(value: false);
				}
			}
			return;
		}
		if (GradeUpWindow.localScale.x == 0f)
		{
			if (GradeUpSubject == 1)
			{
				GradeUpName.text = "BIOLOGY RANK UP";
				GradeUpDesc.text = Subject1GradeText[Grade];
			}
			else if (GradeUpSubject == 2)
			{
				GradeUpName.text = "CHEMISTRY RANK UP";
				GradeUpDesc.text = Subject2GradeText[Grade];
			}
			else if (GradeUpSubject == 3)
			{
				GradeUpName.text = "LANGUAGE RANK UP";
				GradeUpDesc.text = Subject3GradeText[Grade];
			}
			else if (GradeUpSubject == 4)
			{
				GradeUpName.text = "PHYSICAL RANK UP";
				GradeUpDesc.text = Subject4GradeText[Grade];
			}
			else if (GradeUpSubject == 5)
			{
				GradeUpName.text = "PSYCHOLOGY RANK UP";
				GradeUpDesc.text = Subject5GradeText[Grade];
			}
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Continue";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
		}
		else if (GradeUpWindow.localScale.x > 0.99f && Input.GetButtonDown("A"))
		{
			PromptBar.ClearButtons();
			GradeUp = false;
		}
		GradeUpWindow.localScale = Vector3.Lerp(GradeUpWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	private void UpdateSubjectLabels()
	{
		for (int i = 1; i < 6; i++)
		{
			SubjectLabels[i].color = new Color(0f, 0f, 0f, 1f);
		}
		SubjectLabels[Selected].color = new Color(1f, 1f, 1f, 1f);
	}

	public void UpdateLabel()
	{
		StudyPointsLabel.text = "STUDY POINTS: " + StudyPoints;
		if (StudyPoints == 0)
		{
			PromptBar.Label[0].text = "Confirm";
			PromptBar.UpdateButtons();
		}
		else
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
	}

	private void UpdateBars()
	{
		for (int i = 1; i < 6; i++)
		{
			Transform transform = Subject1Bars[i];
			if (Subject[1] + SubjectTemp[1] > (i - 1) * 20)
			{
				transform.localScale = new Vector3(0f - (float)((i - 1) * 20 - (Subject[1] + SubjectTemp[1])) / 20f, transform.localScale.y, transform.localScale.z);
				if (transform.localScale.x > 1f)
				{
					transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
				}
			}
			else
			{
				transform.localScale = new Vector3(0f, transform.localScale.y, transform.localScale.z);
			}
		}
		for (int j = 1; j < 6; j++)
		{
			Transform transform2 = Subject2Bars[j];
			if (Subject[2] + SubjectTemp[2] > (j - 1) * 20)
			{
				transform2.localScale = new Vector3(0f - (float)((j - 1) * 20 - (Subject[2] + SubjectTemp[2])) / 20f, transform2.localScale.y, transform2.localScale.z);
				if (transform2.localScale.x > 1f)
				{
					transform2.localScale = new Vector3(1f, transform2.localScale.y, transform2.localScale.z);
				}
			}
			else
			{
				transform2.localScale = new Vector3(0f, transform2.localScale.y, transform2.localScale.z);
			}
		}
		for (int k = 1; k < 6; k++)
		{
			Transform transform3 = Subject3Bars[k];
			if (Subject[3] + SubjectTemp[3] > (k - 1) * 20)
			{
				transform3.localScale = new Vector3(0f - (float)((k - 1) * 20 - (Subject[3] + SubjectTemp[3])) / 20f, transform3.localScale.y, transform3.localScale.z);
				if (transform3.localScale.x > 1f)
				{
					transform3.localScale = new Vector3(1f, transform3.localScale.y, transform3.localScale.z);
				}
			}
			else
			{
				transform3.localScale = new Vector3(0f, transform3.localScale.y, transform3.localScale.z);
			}
		}
		for (int l = 1; l < 6; l++)
		{
			Transform transform4 = Subject4Bars[l];
			if (Subject[4] + SubjectTemp[4] > (l - 1) * 20)
			{
				transform4.localScale = new Vector3(0f - (float)((l - 1) * 20 - (Subject[4] + SubjectTemp[4])) / 20f, transform4.localScale.y, transform4.localScale.z);
				if (transform4.localScale.x > 1f)
				{
					transform4.localScale = new Vector3(1f, transform4.localScale.y, transform4.localScale.z);
				}
			}
			else
			{
				transform4.localScale = new Vector3(0f, transform4.localScale.y, transform4.localScale.z);
			}
		}
		for (int m = 1; m < 6; m++)
		{
			Transform transform5 = Subject5Bars[m];
			if (Subject[5] + SubjectTemp[5] > (m - 1) * 20)
			{
				transform5.localScale = new Vector3(0f - (float)((m - 1) * 20 - (Subject[5] + SubjectTemp[5])) / 20f, transform5.localScale.y, transform5.localScale.z);
				if (transform5.localScale.x > 1f)
				{
					transform5.localScale = new Vector3(1f, transform5.localScale.y, transform5.localScale.z);
				}
			}
			else
			{
				transform5.localScale = new Vector3(0f, transform5.localScale.y, transform5.localScale.z);
			}
		}
	}

	private void CheckForGradeUp()
	{
		if (Biology >= 20 && BiologyGrade < 1)
		{
			BiologyGrade = 1;
			GradeUpSubject = 1;
			GradeUp = true;
			Grade = 1;
		}
		else if (Chemistry >= 20 && ChemistryGrade < 1)
		{
			ChemistryGrade = 1;
			GradeUpSubject = 2;
			GradeUp = true;
			Grade = 1;
		}
		else if (Language >= 20 && LanguageGrade < 1)
		{
			LanguageGrade = 1;
			GradeUpSubject = 3;
			GradeUp = true;
			Grade = 1;
		}
		else if (Physical >= 20 && PhysicalGrade < 1)
		{
			PhysicalGrade = 1;
			GradeUpSubject = 4;
			GradeUp = true;
			Grade = 1;
		}
		else if (Physical >= 40 && PhysicalGrade < 2)
		{
			PhysicalGrade = 2;
			GradeUpSubject = 4;
			GradeUp = true;
			Grade = 2;
		}
		else if (Physical >= 60 && PhysicalGrade < 3)
		{
			PhysicalGrade = 3;
			GradeUpSubject = 4;
			GradeUp = true;
			Grade = 3;
		}
		else if (Physical >= 80 && PhysicalGrade < 4)
		{
			PhysicalGrade = 4;
			GradeUpSubject = 4;
			GradeUp = true;
			Grade = 4;
		}
		else if (Physical == 100 && PhysicalGrade < 5)
		{
			PhysicalGrade = 5;
			GradeUpSubject = 4;
			GradeUp = true;
			Grade = 5;
		}
		else if (Psychology >= 20 && PsychologyGrade < 1)
		{
			PsychologyGrade = 1;
			GradeUpSubject = 5;
			GradeUp = true;
			Grade = 1;
		}
		else if (Psychology >= 40 && PsychologyGrade < 2)
		{
			PsychologyGrade = 2;
			GradeUpSubject = 5;
			GradeUp = true;
			Grade = 2;
		}
		else if (Psychology >= 60 && PsychologyGrade < 3)
		{
			PsychologyGrade = 3;
			GradeUpSubject = 5;
			GradeUp = true;
			Grade = 3;
		}
		else if (Psychology >= 80 && PsychologyGrade < 4)
		{
			PsychologyGrade = 4;
			GradeUpSubject = 5;
			GradeUp = true;
			Grade = 4;
		}
		else if (Psychology >= 100 && PsychologyGrade < 5)
		{
			PsychologyGrade = 5;
			GradeUpSubject = 5;
			GradeUp = true;
			Grade = 5;
		}
	}

	private void GivePoints()
	{
		BiologyGrade = 0;
		ChemistryGrade = 0;
		LanguageGrade = 0;
		PhysicalGrade = 0;
		PsychologyGrade = 0;
		Biology = 19;
		Chemistry = 19;
		Language = 19;
		Physical = 19;
		Psychology = 19;
		Subject[1] = Biology;
		Subject[2] = Chemistry;
		Subject[3] = Language;
		Subject[4] = Physical;
		Subject[5] = Psychology;
		UpdateBars();
	}

	private void MaxPhysical()
	{
		PhysicalGrade = 0;
		Physical = 99;
		Subject[4] = Physical;
		UpdateBars();
	}
}
