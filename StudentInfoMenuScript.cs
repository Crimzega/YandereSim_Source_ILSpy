using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudentInfoMenuScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public StudentInfoScript StudentInfo;

	public NoteWindowScript NoteWindow;

	public PromptBarScript PromptBar;

	public JsonScript JSON;

	public GameObject StudentPortrait;

	public Texture UnknownPortrait;

	public Texture BlankPortrait;

	public Texture Headmaster;

	public Texture Counselor;

	public Texture InfoChan;

	public Texture EightiesHeadmaster;

	public Texture EightiesCounselor;

	public Texture Journalist;

	public Transform PortraitGrid;

	public Transform Highlight;

	public Transform Scrollbar;

	public StudentPortraitScript[] StudentPortraits;

	public Texture[] RivalPortraits;

	public bool[] PortraitLoaded;

	public UISprite[] DeathShadows;

	public UISprite[] Friends;

	public UISprite[] Panties;

	public UITexture[] PrisonBars;

	public UITexture[] Portraits;

	public UILabel NameLabel;

	public bool FiringCouncilMember;

	public bool GettingOpinions;

	public bool CyberBullying;

	public bool CyberStalking;

	public bool FindingLocker;

	public bool UsingLifeNote;

	public bool GettingInfo;

	public bool MatchMaking;

	public bool Distracting;

	public bool SendingHome;

	public bool Gossiping;

	public bool Targeting;

	public bool Dead;

	public int[] SetSizes;

	public int StudentID;

	public int Column;

	public int Row;

	public int Set;

	public int Columns;

	public int Rows;

	public bool GrabbedPortraits;

	public bool Debugging;

	private void Start()
	{
		StudentGlobals.GetStudentPhotographed(11);
		for (int i = 1; i < 101; i++)
		{
			GameObject gameObject = Object.Instantiate(StudentPortrait, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = PortraitGrid;
			gameObject.transform.localPosition = new Vector3(-300f + (float)Column * 150f, 80f - (float)Row * 160f, 0f);
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			StudentPortraits[i] = gameObject.GetComponent<StudentPortraitScript>();
			Column++;
			if (Column > 4)
			{
				Column = 0;
				Row++;
			}
		}
		if (StudentManager.Eighties)
		{
			Headmaster = EightiesHeadmaster;
			Counselor = EightiesCounselor;
			InfoChan = Journalist;
		}
		Column = 0;
		Row = 0;
	}

	private void Update()
	{
		if (!GrabbedPortraits)
		{
			StartCoroutine(UpdatePortraits());
			GrabbedPortraits = true;
			PauseScreen.BlackenAllText();
		}
		if (Input.GetButtonDown("A"))
		{
			if (PromptBar.Label[0].text != string.Empty)
			{
				if (StudentGlobals.GetStudentPhotographed(StudentID) || StudentID > 97)
				{
					if (UsingLifeNote)
					{
						PauseScreen.MainMenu.SetActive(value: true);
						PauseScreen.Sideways = false;
						PauseScreen.Show = false;
						base.gameObject.SetActive(value: false);
						NoteWindow.TargetStudent = StudentID;
						NoteWindow.gameObject.SetActive(value: true);
						NoteWindow.SlotLabels[1].text = StudentManager.Students[StudentID].Name;
						NoteWindow.SlotsFilled[1] = true;
						UsingLifeNote = false;
						PromptBar.Label[0].text = "Confirm";
						PromptBar.UpdateButtons();
						NoteWindow.CheckForCompletion();
					}
					else
					{
						StudentInfo.gameObject.SetActive(value: true);
						StudentInfo.UpdateInfo(StudentID);
						StudentInfo.Topics.SetActive(value: false);
						base.gameObject.SetActive(value: false);
						PromptBar.ClearButtons();
						if (Gossiping)
						{
							PromptBar.Label[0].text = "Gossip";
						}
						if (Distracting)
						{
							PromptBar.Label[0].text = "Distract";
						}
						if (CyberBullying || CyberStalking)
						{
							PromptBar.Label[0].text = "Accept";
						}
						if (FindingLocker)
						{
							PromptBar.Label[0].text = "Find Locker";
						}
						if (MatchMaking)
						{
							PromptBar.Label[0].text = "Match";
						}
						if (Targeting || UsingLifeNote)
						{
							PromptBar.Label[0].text = "Kill";
						}
						if (SendingHome)
						{
							PromptBar.Label[0].text = "Send Home";
						}
						if (FiringCouncilMember)
						{
							PromptBar.Label[0].text = "Fire";
						}
						if (GettingOpinions)
						{
							PromptBar.Label[0].text = "Get Opinions";
						}
						if (StudentManager.Students[StudentID] != null)
						{
							if (StudentManager.Students[StudentID].gameObject.activeInHierarchy)
							{
								if (StudentManager.Tag.Target == StudentManager.Students[StudentID].Head)
								{
									PromptBar.Label[2].text = "Untag";
								}
								else
								{
									PromptBar.Label[2].text = "Tag";
								}
							}
							else
							{
								PromptBar.Label[2].text = "";
							}
						}
						else
						{
							PromptBar.Label[2].text = "";
						}
						PromptBar.Label[1].text = "Back";
						PromptBar.Label[3].text = "Interests";
						PromptBar.Label[6].text = "Reputation";
						PromptBar.UpdateButtons();
					}
				}
				else
				{
					StudentGlobals.SetStudentPhotographed(StudentID, value: true);
					if (StudentManager.Students[StudentID] != null)
					{
						for (int i = 0; i < StudentManager.Students[StudentID].Outlines.Length; i++)
						{
							if (StudentManager.Students[StudentID].Outlines[i] != null)
							{
								StudentManager.Students[StudentID].Outlines[i].enabled = true;
							}
						}
					}
					PauseScreen.ServiceMenu.gameObject.SetActive(value: true);
					PauseScreen.ServiceMenu.UpdateList();
					PauseScreen.ServiceMenu.UpdateDesc();
					PauseScreen.ServiceMenu.Purchase();
					GettingInfo = false;
					base.gameObject.SetActive(value: false);
				}
				PauseScreen.BlackenAllText();
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			if (Gossiping || Distracting || MatchMaking || Targeting)
			{
				if (Targeting)
				{
					PauseScreen.Yandere.RPGCamera.enabled = true;
				}
				PauseScreen.Yandere.Interaction = YandereInteractionType.Bye;
				PauseScreen.Yandere.TalkTimer = 2f;
				PauseScreen.MainMenu.SetActive(value: true);
				PauseScreen.Sideways = false;
				PauseScreen.Show = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 1f;
				Distracting = false;
				MatchMaking = false;
				Gossiping = false;
				Targeting = false;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (CyberBullying || CyberStalking || FindingLocker)
			{
				PauseScreen.MainMenu.SetActive(value: true);
				PauseScreen.Sideways = false;
				PauseScreen.Show = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 1f;
				if (FindingLocker)
				{
					PauseScreen.Yandere.RPGCamera.enabled = true;
				}
				FindingLocker = false;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
			}
			else if (SendingHome || GettingInfo || GettingOpinions || FiringCouncilMember)
			{
				PauseScreen.ServiceMenu.gameObject.SetActive(value: true);
				PauseScreen.ServiceMenu.UpdateList();
				PauseScreen.ServiceMenu.UpdateDesc();
				base.gameObject.SetActive(value: false);
				FiringCouncilMember = false;
				GettingOpinions = false;
				SendingHome = false;
				GettingInfo = false;
			}
			else if (UsingLifeNote)
			{
				PauseScreen.MainMenu.SetActive(value: true);
				PauseScreen.Sideways = false;
				PauseScreen.Show = false;
				base.gameObject.SetActive(value: false);
				NoteWindow.gameObject.SetActive(value: true);
				UsingLifeNote = false;
			}
			else
			{
				PauseScreen.MainMenu.SetActive(value: true);
				PauseScreen.Sideways = false;
				PauseScreen.PressedB = true;
				base.gameObject.SetActive(value: false);
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[1].text = "Exit";
				PromptBar.Label[4].text = "Choose";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
		}
		float t = Time.unscaledDeltaTime * 10f;
		float num = ((Row % 2 == 0) ? (Row / 2) : ((Row - 1) / 2));
		float b = 320f * num;
		PortraitGrid.localPosition = new Vector3(PortraitGrid.localPosition.x, Mathf.Lerp(PortraitGrid.localPosition.y, b, t), PortraitGrid.localPosition.z);
		Scrollbar.localPosition = new Vector3(Scrollbar.localPosition.x, Mathf.Lerp(Scrollbar.localPosition.y, 175f - 350f * (PortraitGrid.localPosition.y / 2880f), t), Scrollbar.localPosition.z);
		if (InputManager.TappedUp)
		{
			Row--;
			if (Row < 0)
			{
				Row = Rows - 1;
			}
			UpdateHighlight();
		}
		if (InputManager.TappedDown)
		{
			Row++;
			if (Row > Rows - 1)
			{
				Row = 0;
			}
			UpdateHighlight();
		}
		if (InputManager.TappedRight)
		{
			Column++;
			if (Column > Columns - 1)
			{
				Column = 0;
			}
			UpdateHighlight();
		}
		if (InputManager.TappedLeft)
		{
			Column--;
			if (Column < 0)
			{
				Column = Columns - 1;
			}
			UpdateHighlight();
		}
	}

	public void UpdateHighlight()
	{
		StudentID = 1 + (Column + Row * Columns);
		if (StudentGlobals.GetStudentPhotographed(StudentID) || StudentID > 97)
		{
			PromptBar.Label[0].text = "View Info";
			PromptBar.UpdateButtons();
		}
		else
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (Gossiping && (StudentID == 1 || StudentID == PauseScreen.Yandere.TargetStudent.StudentID || JSON.Students[StudentID].Club == ClubType.Sports || StudentManager.Students[StudentID] == null || StudentGlobals.GetStudentDead(StudentID) || StudentID > 97))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (CyberBullying && (JSON.Students[StudentID].Gender == 1 || StudentGlobals.GetStudentDead(StudentID) || StudentID > 97))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (CyberStalking && (StudentGlobals.GetStudentDead(StudentID) || StudentGlobals.GetStudentArrested(StudentID) || StudentID > 97))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (FindingLocker && (StudentID == 1 || StudentID > 89 || (StudentManager.Students[StudentID] != null && StudentManager.Students[StudentID].Club == ClubType.Council) || StudentGlobals.GetStudentDead(StudentID)))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (Distracting)
		{
			Dead = false;
			if (StudentManager.Students[StudentID] == null)
			{
				Dead = true;
			}
			if (Dead)
			{
				PromptBar.Label[0].text = string.Empty;
				PromptBar.UpdateButtons();
			}
			else if (StudentID == 1 || !StudentManager.Students[StudentID].Alive || StudentID == PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentKidnapped(StudentID) || StudentManager.Students[StudentID].Tranquil || StudentManager.Students[StudentID].Teacher || StudentManager.Students[StudentID].Slave || StudentGlobals.GetStudentDead(StudentID) || StudentManager.Students[StudentID].MyBento.Tampered || StudentID > 97)
			{
				PromptBar.Label[0].text = string.Empty;
				PromptBar.UpdateButtons();
			}
		}
		if (MatchMaking && (StudentID == PauseScreen.Yandere.TargetStudent.StudentID || StudentGlobals.GetStudentDead(StudentID) || StudentID > 97))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (Targeting && (StudentID == 1 || StudentID > 97 || StudentGlobals.GetStudentDead(StudentID) || (StudentManager.Students[StudentID] != null && !StudentManager.Students[StudentID].gameObject.activeInHierarchy) || (StudentManager.Students[StudentID] != null && StudentManager.Students[StudentID].InEvent) || (StudentManager.Students[StudentID] != null && StudentManager.Students[StudentID].Tranquil)))
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		if (SendingHome)
		{
			Debug.Log("Highlighting student number " + StudentID);
			if (StudentManager.Students[StudentID] != null)
			{
				StudentScript studentScript = StudentManager.Students[StudentID];
				if (StudentID == 1 || StudentGlobals.GetStudentDead(StudentID) || (StudentID < 98 && studentScript.SentHome) || StudentID > 97 || StudentGlobals.StudentSlave == StudentID || (studentScript.Club == ClubType.MartialArts && studentScript.ClubAttire) || (studentScript.Club == ClubType.Sports && studentScript.ClubAttire) || StudentManager.Students[StudentID].CameraReacting || !StudentGlobals.GetStudentPhotographed(StudentID) || studentScript.Wet || studentScript.Slave || studentScript.Phoneless)
				{
					PromptBar.Label[0].text = string.Empty;
					PromptBar.UpdateButtons();
				}
			}
		}
		if (GettingInfo)
		{
			if (StudentGlobals.GetStudentPhotographed(StudentID) || StudentID > 97)
			{
				PromptBar.Label[0].text = string.Empty;
			}
			else
			{
				PromptBar.Label[0].text = "Get Info";
			}
			PromptBar.UpdateButtons();
		}
		if (GettingOpinions)
		{
			PromptBar.Label[0].text = "Get Opinions";
			PromptBar.UpdateButtons();
		}
		if (UsingLifeNote)
		{
			if (StudentID == 1 || StudentID > 97 || (StudentID > 11 && StudentID < 21) || StudentPortraits[StudentID].DeathShadow.activeInHierarchy || (StudentManager.Students[StudentID] != null && !StudentManager.Students[StudentID].enabled))
			{
				PromptBar.Label[0].text = "";
			}
			else
			{
				PromptBar.Label[0].text = "Kill";
			}
			PromptBar.UpdateButtons();
		}
		if (FiringCouncilMember)
		{
			if (StudentManager.Students[StudentID] != null)
			{
				if (!StudentGlobals.GetStudentPhotographed(StudentID) || StudentManager.Students[StudentID].Club != ClubType.Council)
				{
					PromptBar.Label[0].text = "";
				}
				else
				{
					PromptBar.Label[0].text = "Fire";
				}
			}
			PromptBar.UpdateButtons();
		}
		if (MissionModeGlobals.MissionMode && StudentID == 1)
		{
			PromptBar.Label[0].text = "";
		}
		Highlight.localPosition = new Vector3(-300f + (float)Column * 150f, 80f - (float)Row * 160f, Highlight.localPosition.z);
		UpdateNameLabel();
	}

	private void UpdateNameLabel()
	{
		if (StudentID > 97 || StudentGlobals.GetStudentPhotographed(StudentID) || GettingInfo)
		{
			NameLabel.text = JSON.Students[StudentID].Name;
		}
		else
		{
			NameLabel.text = "Unknown";
		}
	}

	public IEnumerator UpdatePortraits()
	{
		if (Debugging)
		{
			Debug.Log("The Student Info Menu was instructed to get photos.");
		}
		string EightiesPrefix = "";
		if (GameGlobals.Eighties)
		{
			EightiesPrefix = "1989";
		}
		for (int ID = 1; ID < 101; ID++)
		{
			if (ID == 0)
			{
				StudentPortraits[ID].Portrait.mainTexture = InfoChan;
			}
			else if (!PortraitLoaded[ID])
			{
				if (ID < 98)
				{
					if (StudentManager.Eighties || (!StudentManager.Eighties && ID < 12) || (!StudentManager.Eighties && ID > 20))
					{
						if (StudentGlobals.GetStudentPhotographed(ID))
						{
							string url = "file:///" + Application.streamingAssetsPath + "/Portraits" + EightiesPrefix + "/Student_" + ID + ".png";
							WWW www = new WWW(url);
							yield return www;
							if (www.error == null)
							{
								if (!StudentGlobals.GetStudentReplaced(ID))
								{
									StudentPortraits[ID].Portrait.mainTexture = www.texture;
								}
								else
								{
									StudentPortraits[ID].Portrait.mainTexture = BlankPortrait;
								}
							}
							else
							{
								StudentPortraits[ID].Portrait.mainTexture = UnknownPortrait;
							}
							PortraitLoaded[ID] = true;
						}
						else
						{
							StudentPortraits[ID].Portrait.mainTexture = UnknownPortrait;
						}
					}
					else
					{
						Debug.Log("Right now, we're trying to get the portrait of Student #" + ID);
						StudentPortraits[ID].Portrait.mainTexture = RivalPortraits[ID];
					}
				}
				else
				{
					switch (ID)
					{
					case 98:
						StudentPortraits[ID].Portrait.mainTexture = Counselor;
						break;
					case 99:
						StudentPortraits[ID].Portrait.mainTexture = Headmaster;
						break;
					case 100:
						StudentPortraits[ID].Portrait.mainTexture = InfoChan;
						break;
					default:
						StudentPortraits[ID].Portrait.mainTexture = RivalPortraits[ID];
						break;
					}
				}
			}
			if (StudentManager.PantyShotTaken[ID] || PlayerGlobals.GetStudentPantyShot(ID))
			{
				StudentPortraits[ID].Panties.SetActive(value: true);
			}
			if (StudentManager.Students[ID] != null)
			{
				StudentPortraits[ID].Friend.SetActive(StudentManager.Students[ID].Friend);
			}
			if (StudentGlobals.GetStudentDying(ID) || StudentGlobals.GetStudentDead(ID))
			{
				StudentPortraits[ID].DeathShadow.SetActive(value: true);
			}
			if (MissionModeGlobals.MissionMode && ID == 1)
			{
				StudentPortraits[ID].DeathShadow.SetActive(value: true);
			}
			if (SceneManager.GetActiveScene().name == "SchoolScene" && StudentManager.Students[ID] != null && StudentManager.Students[ID].Tranquil)
			{
				StudentPortraits[ID].DeathShadow.SetActive(value: true);
			}
			if (StudentGlobals.GetStudentArrested(ID))
			{
				StudentPortraits[ID].PrisonBars.SetActive(value: true);
				StudentPortraits[ID].DeathShadow.SetActive(value: true);
			}
		}
	}
}
