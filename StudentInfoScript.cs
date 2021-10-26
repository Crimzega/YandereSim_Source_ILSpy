using UnityEngine;

public class StudentInfoScript : MonoBehaviour
{
	public StudentInfoMenuScript StudentInfoMenu;

	public StudentManagerScript StudentManager;

	public DialogueWheelScript DialogueWheel;

	public HomeInternetScript HomeInternet;

	public TopicManagerScript TopicManager;

	public NoteLockerScript NoteLocker;

	public RadarChart ReputationChart;

	public PromptBarScript PromptBar;

	public ShutterScript Shutter;

	public YandereScript Yandere;

	public JsonScript JSON;

	public Texture GuidanceCounselor;

	public Texture DefaultPortrait;

	public Texture BlankPortrait;

	public Texture Headmaster;

	public Texture InfoChan;

	public Transform ReputationBar;

	public GameObject Static;

	public GameObject Topics;

	public UILabel OccupationLabel;

	public UILabel ReputationLabel;

	public UILabel RealNameLabel;

	public UILabel StrengthLabel;

	public UILabel PersonaLabel;

	public UILabel ClassLabel;

	public UILabel CrushLabel;

	public UILabel ClubLabel;

	public UILabel InfoLabel;

	public UILabel NameLabel;

	public UITexture Portrait;

	public string[] OpinionSpriteNames;

	public string[] Strings;

	public int CurrentStudent;

	public bool ShowRep;

	public bool Back;

	public UISprite[] TopicIcons;

	public UISprite[] TopicOpinionIcons;

	private static readonly IntAndStringDictionary StrengthStrings = new IntAndStringDictionary
	{
		{ 0, "Incapable" },
		{ 1, "Very Weak" },
		{ 2, "Weak" },
		{ 3, "Strong" },
		{ 4, "Very Strong" },
		{ 5, "Peak Physical Strength" },
		{ 6, "Extensive Training" },
		{ 7, "Carries Pepper Spray" },
		{ 8, "Armed" },
		{ 9, "Invincible" },
		{ 99, "?????" }
	};

	private void Start()
	{
		StudentGlobals.SetStudentPhotographed(98, value: true);
		StudentGlobals.SetStudentPhotographed(99, value: true);
		StudentGlobals.SetStudentPhotographed(100, value: true);
		Topics.SetActive(value: false);
	}

	public void UpdateInfo(int ID)
	{
		StudentJson studentJson = JSON.Students[ID];
		if (studentJson.RealName == "")
		{
			NameLabel.transform.localPosition = new Vector3(-228f, 195f, 0f);
			RealNameLabel.text = "";
		}
		else
		{
			NameLabel.transform.localPosition = new Vector3(-228f, 210f, 0f);
			RealNameLabel.text = "Real Name: " + studentJson.RealName;
		}
		NameLabel.text = studentJson.Name;
		string text = string.Concat(studentJson.Class);
		text = text.Insert(1, "-");
		ClassLabel.text = "Class " + text;
		if (ID == 90 || ID > 96)
		{
			ClassLabel.text = "";
		}
		float num = 0f;
		num = ((!(StudentManager != null)) ? ((float)StudentGlobals.GetStudentReputation(ID)) : StudentManager.StudentReps[ID]);
		if (num < 0f)
		{
			ReputationLabel.text = string.Concat(num);
		}
		else if (num > 0f)
		{
			ReputationLabel.text = "+" + num;
		}
		else
		{
			ReputationLabel.text = "0";
		}
		ReputationBar.localPosition = new Vector3(num * 0.96f, ReputationBar.localPosition.y, ReputationBar.localPosition.z);
		if (ReputationBar.localPosition.x > 96f)
		{
			ReputationBar.localPosition = new Vector3(96f, ReputationBar.localPosition.y, ReputationBar.localPosition.z);
		}
		if (ReputationBar.localPosition.x < -96f)
		{
			ReputationBar.localPosition = new Vector3(-96f, ReputationBar.localPosition.y, ReputationBar.localPosition.z);
		}
		PersonaLabel.text = Persona.PersonaNames[studentJson.Persona];
		if (studentJson.Persona == PersonaType.Strict && studentJson.Club == ClubType.GymTeacher && !StudentGlobals.GetStudentReplaced(ID))
		{
			PersonaLabel.text = "Friendly but Strict";
		}
		if (studentJson.Crush == 0)
		{
			CrushLabel.text = "None";
		}
		else if (studentJson.Crush == 99)
		{
			CrushLabel.text = "?????";
		}
		else
		{
			CrushLabel.text = JSON.Students[studentJson.Crush].Name;
		}
		if (studentJson.Club < ClubType.Teacher)
		{
			OccupationLabel.text = "Club";
		}
		else
		{
			OccupationLabel.text = "Occupation";
		}
		if (studentJson.Club < ClubType.Teacher)
		{
			ClubLabel.text = Club.ClubNames[studentJson.Club];
		}
		else
		{
			ClubLabel.text = Club.TeacherClubNames[studentJson.Class];
		}
		if (ClubGlobals.GetClubClosed(studentJson.Club))
		{
			ClubLabel.text = "No Club";
		}
		StrengthLabel.text = StrengthStrings[studentJson.Strength];
		AudioSource component = GetComponent<AudioSource>();
		component.enabled = false;
		Static.SetActive(value: false);
		component.volume = 0f;
		component.Stop();
		string text2 = "";
		if (GameGlobals.Eighties)
		{
			text2 = "1989";
		}
		if (ID < 98)
		{
			if (StudentManager.Eighties || (!StudentManager.Eighties && ID < 12) || (!StudentManager.Eighties && ID > 20))
			{
				WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + text2 + "/Student_" + ID + ".png");
				if (!StudentGlobals.GetStudentReplaced(ID))
				{
					Portrait.mainTexture = wWW.texture;
				}
				else
				{
					Portrait.mainTexture = BlankPortrait;
				}
			}
			else
			{
				Portrait.mainTexture = StudentInfoMenu.RivalPortraits[ID];
			}
		}
		else
		{
			switch (ID)
			{
			case 98:
				Portrait.mainTexture = StudentInfoMenu.Counselor;
				break;
			case 99:
				Portrait.mainTexture = StudentInfoMenu.Headmaster;
				break;
			case 100:
				Portrait.mainTexture = StudentInfoMenu.InfoChan;
				if (!StudentManager.Eighties)
				{
					Static.SetActive(value: true);
					if (!StudentInfoMenu.Gossiping && !StudentInfoMenu.Distracting && !StudentInfoMenu.CyberBullying && !StudentInfoMenu.CyberStalking)
					{
						component.enabled = true;
						component.volume = 1f;
						component.Play();
					}
				}
				break;
			}
		}
		UpdateAdditionalInfo(ID);
		CurrentStudent = ID;
		UpdateRepChart();
	}

	private void Update()
	{
		if (CurrentStudent == 100)
		{
			UpdateRepChart();
		}
		if (Input.GetButtonDown("A"))
		{
			if (StudentInfoMenu.Gossiping)
			{
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				DialogueWheel.Victim = CurrentStudent;
				StudentInfoMenu.Gossiping = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 0.0001f;
				DialogueWheel.TopicInterface.Socializing = false;
				DialogueWheel.TopicInterface.StudentID = Yandere.TargetStudent.StudentID;
				DialogueWheel.TopicInterface.Student = Yandere.TargetStudent;
				DialogueWheel.TopicInterface.TargetStudentID = CurrentStudent;
				DialogueWheel.TopicInterface.TargetStudent = StudentManager.Students[CurrentStudent];
				DialogueWheel.TopicInterface.UpdateOpinions();
				DialogueWheel.TopicInterface.UpdateTopicHighlight();
				DialogueWheel.TopicInterface.gameObject.SetActive(value: true);
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Speak";
				PromptBar.Label[1].text = "Back";
				PromptBar.Label[2].text = "Positive/Negative";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			else if (StudentInfoMenu.Distracting)
			{
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				DialogueWheel.Victim = CurrentStudent;
				StudentInfoMenu.Distracting = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 1f;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (StudentInfoMenu.CyberBullying)
			{
				HomeInternet.PostLabels[1].text = JSON.Students[CurrentStudent].Name;
				HomeInternet.Student = CurrentStudent;
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				StudentInfoMenu.CyberBullying = false;
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (StudentInfoMenu.CyberStalking)
			{
				HomeInternet.HomeCamera.CyberstalkWindow.SetActive(value: true);
				HomeInternet.Student = CurrentStudent;
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				StudentInfoMenu.CyberStalking = false;
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (StudentInfoMenu.MatchMaking)
			{
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				DialogueWheel.Victim = CurrentStudent;
				StudentInfoMenu.MatchMaking = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 1f;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (StudentInfoMenu.Targeting)
			{
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				Yandere.TargetStudent.HuntTarget = StudentManager.Students[CurrentStudent];
				Yandere.TargetStudent.HuntTarget.Hunted = true;
				Yandere.TargetStudent.GoCommitMurder();
				Yandere.RPGCamera.enabled = true;
				Yandere.TargetStudent = null;
				StudentInfoMenu.Targeting = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 1f;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (StudentInfoMenu.SendingHome)
			{
				if (CurrentStudent == 10 || CurrentStudent == StudentManager.RivalID)
				{
					StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(11);
					base.gameObject.SetActive(value: false);
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = string.Empty;
					PromptBar.Label[1].text = "Back";
					PromptBar.UpdateButtons();
				}
				else if (StudentManager.Students[CurrentStudent].Routine && !StudentManager.Students[CurrentStudent].InEvent && !StudentManager.Students[CurrentStudent].TargetedForDistraction && StudentManager.Students[CurrentStudent].ClubActivityPhase < 16 && !StudentManager.Students[CurrentStudent].MyBento.Tampered)
				{
					StudentManager.Students[CurrentStudent].Routine = false;
					StudentManager.Students[CurrentStudent].SentHome = true;
					StudentManager.Students[CurrentStudent].CameraReacting = false;
					StudentManager.Students[CurrentStudent].SpeechLines.Stop();
					StudentManager.Students[CurrentStudent].EmptyHands();
					StudentInfoMenu.PauseScreen.ServiceMenu.gameObject.SetActive(value: true);
					StudentInfoMenu.PauseScreen.ServiceMenu.UpdateList();
					StudentInfoMenu.PauseScreen.ServiceMenu.UpdateDesc();
					StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
					StudentInfoMenu.SendingHome = false;
					base.gameObject.SetActive(value: false);
					PromptBar.ClearButtons();
					PromptBar.Show = false;
				}
				else
				{
					StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(0);
					base.gameObject.SetActive(value: false);
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = string.Empty;
					PromptBar.Label[1].text = "Back";
					PromptBar.UpdateButtons();
				}
			}
			else if (StudentInfoMenu.FindingLocker)
			{
				NoteLocker.gameObject.SetActive(value: true);
				NoteLocker.transform.position = StudentManager.Students[StudentInfoMenu.StudentID].MyLocker.position;
				NoteLocker.transform.position += new Vector3(0f, 1.355f, 0f);
				NoteLocker.transform.position += StudentManager.Students[StudentInfoMenu.StudentID].MyLocker.forward * 0.33333f;
				NoteLocker.Prompt.Label[0].text = "     Leave note for " + StudentManager.Students[StudentInfoMenu.StudentID].Name;
				NoteLocker.Student = StudentManager.Students[StudentInfoMenu.StudentID];
				NoteLocker.LockerOwner = StudentInfoMenu.StudentID;
				NoteLocker.Prompt.enabled = true;
				NoteLocker.transform.GetChild(0).gameObject.SetActive(value: true);
				NoteLocker.CheckingNote = false;
				NoteLocker.CanLeaveNote = true;
				NoteLocker.SpawnedNote = false;
				NoteLocker.NoteLeft = false;
				NoteLocker.Success = false;
				NoteLocker.Timer = 0f;
				StudentInfoMenu.PauseScreen.MainMenu.SetActive(value: true);
				StudentInfoMenu.PauseScreen.Show = false;
				StudentInfoMenu.FindingLocker = false;
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Yandere.RPGCamera.enabled = true;
				Time.timeScale = 1f;
				if (StudentInfoMenu.StudentID == 11 && SchemeGlobals.GetSchemeStage(6) == 4)
				{
					SchemeGlobals.SetSchemeStage(6, 5);
					Yandere.PauseScreen.Schemes.UpdateInstructions();
				}
			}
			else if (StudentInfoMenu.FiringCouncilMember)
			{
				if (StudentManager.Students[CurrentStudent].Routine && !StudentManager.Students[CurrentStudent].InEvent && !StudentManager.Students[CurrentStudent].TargetedForDistraction && StudentManager.Students[CurrentStudent].ClubActivityPhase < 16 && !StudentManager.Students[CurrentStudent].MyBento.Tampered)
				{
					StudentManager.Students[CurrentStudent].OriginalPersona = PersonaType.Heroic;
					StudentManager.Students[CurrentStudent].Persona = PersonaType.Heroic;
					StudentManager.Students[CurrentStudent].Club = ClubType.None;
					StudentManager.Students[CurrentStudent].CameraReacting = false;
					StudentManager.Students[CurrentStudent].SpeechLines.Stop();
					StudentManager.Students[CurrentStudent].EmptyHands();
					StudentManager.Students[CurrentStudent].IdleAnim = StudentManager.Students[CurrentStudent].BulliedIdleAnim;
					StudentManager.Students[CurrentStudent].WalkAnim = StudentManager.Students[CurrentStudent].BulliedWalkAnim;
					StudentManager.Students[CurrentStudent].Armband.SetActive(value: false);
					StudentScript studentScript = StudentManager.Students[CurrentStudent];
					ScheduleBlock obj = studentScript.ScheduleBlocks[3];
					obj.destination = "LunchSpot";
					obj.action = "Eat";
					studentScript.GetDestinations();
					studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
					studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
					StudentInfoMenu.PauseScreen.ServiceMenu.gameObject.SetActive(value: true);
					StudentInfoMenu.PauseScreen.ServiceMenu.UpdateList();
					StudentInfoMenu.PauseScreen.ServiceMenu.UpdateDesc();
					StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
					StudentInfoMenu.FiringCouncilMember = false;
					StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(9);
				}
				else
				{
					StudentInfoMenu.PauseScreen.ServiceMenu.TextMessageManager.SpawnMessage(0);
				}
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = string.Empty;
				PromptBar.Label[1].text = "Back";
				PromptBar.UpdateButtons();
			}
			else if (StudentInfoMenu.GettingOpinions)
			{
				for (int i = 1; i < 26; i++)
				{
					ConversationGlobals.SetTopicDiscovered(i, value: true);
					ConversationGlobals.SetTopicLearnedByStudent(i, CurrentStudent, value: true);
				}
				StudentInfoMenu.PauseScreen.ServiceMenu.Purchase();
				base.gameObject.SetActive(value: false);
				StudentInfoMenu.GettingOpinions = false;
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = string.Empty;
				PromptBar.Label[1].text = "Back";
				PromptBar.UpdateButtons();
			}
		}
		if (Input.GetButtonDown("B"))
		{
			ShowRep = false;
			Topics.SetActive(value: false);
			GetComponent<AudioSource>().Stop();
			ReputationChart.transform.localScale = new Vector3(0f, 0f, 0f);
			if (Shutter != null)
			{
				if (!Shutter.PhotoIcons.activeInHierarchy)
				{
					Back = true;
				}
			}
			else
			{
				Back = true;
			}
			if (Back)
			{
				StudentInfoMenu.gameObject.SetActive(value: true);
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "View Info";
				if (!StudentInfoMenu.Gossiping)
				{
					PromptBar.Label[1].text = "Back";
				}
				PromptBar.UpdateButtons();
				Back = false;
			}
		}
		if (Input.GetButtonDown("X") && PromptBar.Button[2].enabled)
		{
			if (StudentManager.Tag.Target != StudentManager.Students[CurrentStudent].Head)
			{
				StudentManager.Tag.Target = StudentManager.Students[CurrentStudent].Head;
				StudentManager.TagStudentID = CurrentStudent;
				PromptBar.Label[2].text = "Untag";
			}
			else
			{
				StudentManager.TagStudentID = 0;
				StudentManager.Tag.Target = null;
				PromptBar.Label[2].text = "Tag";
			}
		}
		if (Input.GetButtonDown("Y") && PromptBar.Button[3].enabled)
		{
			if (!Topics.activeInHierarchy)
			{
				PromptBar.Label[3].text = "Basic Info";
				PromptBar.UpdateButtons();
				Topics.SetActive(value: true);
				UpdateTopics();
			}
			else
			{
				PromptBar.Label[3].text = "Interests";
				PromptBar.UpdateButtons();
				Topics.SetActive(value: false);
			}
		}
		if (Input.GetButtonDown("LB"))
		{
			UpdateRepChart();
			ShowRep = !ShowRep;
		}
		if (Yandere != null && !Yandere.NoDebug)
		{
			if (Input.GetKeyDown(KeyCode.Equals))
			{
				StudentManager.StudentReps[CurrentStudent] += 10f;
				UpdateInfo(CurrentStudent);
			}
			if (Input.GetKeyDown(KeyCode.Minus))
			{
				StudentManager.StudentReps[CurrentStudent] -= 10f;
				UpdateInfo(CurrentStudent);
			}
		}
		StudentInfoMenuScript studentInfoMenu = StudentInfoMenu;
		if (!studentInfoMenu.CyberBullying && !studentInfoMenu.CyberStalking && !studentInfoMenu.FindingLocker && !studentInfoMenu.UsingLifeNote && !studentInfoMenu.GettingInfo && !studentInfoMenu.MatchMaking && !studentInfoMenu.Distracting && !studentInfoMenu.SendingHome && !studentInfoMenu.Gossiping && !studentInfoMenu.Targeting && !studentInfoMenu.GettingOpinions && !studentInfoMenu.Dead)
		{
			if (StudentInfoMenu.PauseScreen.InputManager.TappedRight)
			{
				CurrentStudent++;
				if (CurrentStudent > 100)
				{
					CurrentStudent = 1;
				}
				while (!StudentGlobals.GetStudentPhotographed(CurrentStudent))
				{
					CurrentStudent++;
					if (CurrentStudent > 100)
					{
						CurrentStudent = 1;
					}
				}
				UpdateInfo(CurrentStudent);
			}
			if (StudentInfoMenu.PauseScreen.InputManager.TappedLeft)
			{
				CurrentStudent--;
				if (CurrentStudent < 1)
				{
					CurrentStudent = 100;
				}
				while (!StudentGlobals.GetStudentPhotographed(CurrentStudent))
				{
					CurrentStudent--;
					if (CurrentStudent < 1)
					{
						CurrentStudent = 100;
					}
				}
				UpdateInfo(CurrentStudent);
			}
		}
		if (ShowRep)
		{
			ReputationChart.transform.localScale = Vector3.Lerp(ReputationChart.transform.localScale, new Vector3(138f, 138f, 138f), Time.unscaledDeltaTime * 10f);
		}
		else
		{
			ReputationChart.transform.localScale = Vector3.Lerp(ReputationChart.transform.localScale, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
		}
	}

	private void UpdateAdditionalInfo(int ID)
	{
		if (!GameGlobals.Eighties)
		{
			switch (ID)
			{
			case 11:
				if (Yandere != null)
				{
					Strings[1] = (Yandere.Police.EndOfDay.LearnedOsanaInfo1 ? "May be a victim of blackmail." : "?????");
					Strings[2] = (Yandere.Police.EndOfDay.LearnedOsanaInfo2 ? "Has a stalker." : "?????");
				}
				else
				{
					Strings[1] = "?????";
					Strings[2] = "?????";
				}
				InfoLabel.text = Strings[1] + "\n\n" + Strings[2];
				break;
			case 51:
				if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
				{
					InfoLabel.text = "Disbanded the Light Music Club, dyed her hair back to its original color, removed her piercings, and stopped socializing with others.";
				}
				else
				{
					InfoLabel.text = JSON.Students[ID].Info;
				}
				break;
			}
		}
		else if (!StudentGlobals.GetStudentReplaced(ID))
		{
			if (JSON.Students[ID].Info == string.Empty)
			{
				InfoLabel.text = "No additional information is available at this time.";
			}
			else
			{
				InfoLabel.text = JSON.Students[ID].Info;
			}
		}
		else
		{
			InfoLabel.text = "No additional information is available at this time.";
		}
	}

	private void UpdateTopics()
	{
		for (int i = 1; i < TopicIcons.Length; i++)
		{
			TopicIcons[i].spriteName = (ConversationGlobals.GetTopicDiscovered(i) ? i : 0).ToString();
		}
		for (int j = 1; j <= 25; j++)
		{
			UISprite uISprite = TopicOpinionIcons[j];
			if (!ConversationGlobals.GetTopicLearnedByStudent(j, CurrentStudent))
			{
				uISprite.spriteName = "Unknown";
				continue;
			}
			int[] topics = JSON.Topics[CurrentStudent].Topics;
			uISprite.spriteName = OpinionSpriteNames[topics[j]];
		}
	}

	private void UpdateRepChart()
	{
		Vector3 vector = ((CurrentStudent >= 100) ? new Vector3(Random.Range(-100, 101), Random.Range(-100, 101), Random.Range(-100, 101)) : StudentGlobals.GetReputationTriangle(CurrentStudent));
		ReputationChart.fields[0].Value = vector.x;
		ReputationChart.fields[1].Value = vector.y;
		ReputationChart.fields[2].Value = vector.z;
	}
}
