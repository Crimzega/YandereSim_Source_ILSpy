using UnityEngine;

public class DialogueWheelScript : MonoBehaviour
{
	public AppearanceWindowScript AppearanceWindow;

	public PracticeWindowScript PracticeWindow;

	public TopicInterfaceScript TopicInterface;

	public AdviceWindowScript AdviceWindow;

	public ClubManagerScript ClubManager;

	public LoveManagerScript LoveManager;

	public PauseScreenScript PauseScreen;

	public TaskManagerScript TaskManager;

	public ClubWindowScript ClubWindow;

	public NoteLockerScript NoteLocker;

	public ReputationScript Reputation;

	public TaskWindowScript TaskWindow;

	public PromptBarScript PromptBar;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public ClockScript Clock;

	public UIPanel Panel;

	public GameObject SwitchTopicsWindow;

	public GameObject TaskDialogueWindow;

	public GameObject ClubLeaderWindow;

	public GameObject DatingMinigame;

	public GameObject LockerWindow;

	public Transform Interaction;

	public Transform Favors;

	public Transform Club;

	public Transform Love;

	public UISprite TaskIcon;

	public UISprite Impatience;

	public UILabel CenterLabel;

	public UISprite[] Segment;

	public UISprite[] Shadow;

	public string[] Text;

	public UISprite[] FavorSegment;

	public UISprite[] FavorShadow;

	public UISprite[] ClubSegment;

	public UISprite[] ClubShadow;

	public UISprite[] LoveSegment;

	public UISprite[] LoveShadow;

	public string[] FavorText;

	public string[] ClubText;

	public string[] LoveText;

	public int Selected;

	public int Victim;

	public bool AskingFavor;

	public bool Matchmaking;

	public bool ClubLeader;

	public bool Pestered;

	public bool Show;

	public Vector3 PreviousPosition;

	public Vector2 MouseDelta;

	public Color OriginalColor;

	private void Start()
	{
		Interaction.localScale = new Vector3(1f, 1f, 1f);
		Favors.localScale = Vector3.zero;
		Club.localScale = Vector3.zero;
		Love.localScale = Vector3.zero;
		base.transform.localScale = Vector3.zero;
		OriginalColor = CenterLabel.color;
	}

	private void Update()
	{
		if (!Show)
		{
			if (base.transform.localScale.x > 0.1f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (Panel.enabled)
			{
				base.transform.localScale = Vector3.zero;
				Panel.enabled = false;
			}
		}
		else
		{
			if (Yandere.PauseScreen.Show)
			{
				Yandere.PauseScreen.ExitPhone();
			}
			if (ClubLeader)
			{
				Interaction.localScale = Vector3.Lerp(Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
				Favors.localScale = Vector3.Lerp(Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
				Club.localScale = Vector3.Lerp(Club.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				Love.localScale = Vector3.Lerp(Love.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (AskingFavor)
			{
				Interaction.localScale = Vector3.Lerp(Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
				Favors.localScale = Vector3.Lerp(Favors.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				Club.localScale = Vector3.Lerp(Club.localScale, Vector3.zero, Time.deltaTime * 10f);
				Love.localScale = Vector3.Lerp(Love.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (Matchmaking)
			{
				Interaction.localScale = Vector3.Lerp(Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
				Favors.localScale = Vector3.Lerp(Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
				Club.localScale = Vector3.Lerp(Club.localScale, Vector3.zero, Time.deltaTime * 10f);
				Love.localScale = Vector3.Lerp(Love.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			else
			{
				Interaction.localScale = Vector3.Lerp(Interaction.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				Favors.localScale = Vector3.Lerp(Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
				Club.localScale = Vector3.Lerp(Club.localScale, Vector3.zero, Time.deltaTime * 10f);
				Love.localScale = Vector3.Lerp(Love.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			MouseDelta.x += Input.GetAxis("Mouse X");
			MouseDelta.y += Input.GetAxis("Mouse Y");
			if (MouseDelta.x > 11f)
			{
				MouseDelta.x = 11f;
			}
			else if (MouseDelta.x < -11f)
			{
				MouseDelta.x = -11f;
			}
			if (MouseDelta.y > 11f)
			{
				MouseDelta.y = 11f;
			}
			else if (MouseDelta.y < -11f)
			{
				MouseDelta.y = -11f;
			}
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (!AskingFavor && !Matchmaking)
			{
				if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
				{
					Selected = 0;
				}
				if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (MouseDelta.y > 10f && MouseDelta.x < 10f && MouseDelta.x > -10f))
				{
					Selected = 1;
				}
				if ((Input.GetAxis("Vertical") > 0f && Input.GetAxis("Horizontal") > 0.5f) || (MouseDelta.y > 0f && MouseDelta.x > 10f))
				{
					Selected = 2;
				}
				if ((Input.GetAxis("Vertical") < 0f && Input.GetAxis("Horizontal") > 0.5f) || (MouseDelta.y < 0f && MouseDelta.x > 10f))
				{
					Selected = 3;
				}
				if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (MouseDelta.y < -10f && MouseDelta.x < 10f && MouseDelta.x > -10f))
				{
					Selected = 4;
				}
				if ((Input.GetAxis("Vertical") < 0f && Input.GetAxis("Horizontal") < -0.5f) || (MouseDelta.y < 0f && MouseDelta.x < -10f))
				{
					Selected = 5;
				}
				if ((Input.GetAxis("Vertical") > 0f && Input.GetAxis("Horizontal") < -0.5f) || (MouseDelta.y > 0f && MouseDelta.x < -10f))
				{
					Selected = 6;
				}
				CenterLabel.text = Text[Selected];
				CenterLabel.color = OriginalColor;
				if (!ClubLeader)
				{
					if (Selected == 5)
					{
						if (Yandere.TargetStudent.Friend)
						{
							CenterLabel.text = "Love";
						}
					}
					else if (Selected == 6 && Yandere.Club == ClubType.Delinquent)
					{
						CenterLabel.text = "Intimidate";
						CenterLabel.color = new Color(1f, 0f, 0f, 1f);
					}
				}
				else
				{
					CenterLabel.text = ClubText[Selected];
				}
			}
			else
			{
				if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
				{
					Selected = 0;
				}
				if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (MouseDelta.y > 10f && MouseDelta.x < 10f && MouseDelta.x > -10f))
				{
					Selected = 1;
				}
				if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") > 0.5f) || (MouseDelta.y < 10f && MouseDelta.y > -10f && MouseDelta.x > 10f))
				{
					Selected = 2;
				}
				if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (MouseDelta.y < -10f && MouseDelta.x < 10f && MouseDelta.x > -10f))
				{
					Selected = 3;
				}
				if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < -0.5f) || (MouseDelta.y < 10f && MouseDelta.y > -10f && MouseDelta.x < -10f))
				{
					Selected = 4;
				}
				if (Selected < FavorText.Length)
				{
					CenterLabel.text = (AskingFavor ? FavorText[Selected] : LoveText[Selected]);
				}
			}
			if (!ClubLeader)
			{
				for (int i = 1; i < 7; i++)
				{
					Transform obj = Segment[i].transform;
					obj.localScale = Vector3.Lerp(obj.localScale, (Selected == i) ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
			else
			{
				for (int j = 1; j < 7; j++)
				{
					Transform obj2 = ClubSegment[j].transform;
					obj2.localScale = Vector3.Lerp(obj2.localScale, (Selected == j) ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
			if (!Matchmaking)
			{
				for (int k = 1; k < 5; k++)
				{
					Transform obj3 = FavorSegment[k].transform;
					obj3.localScale = Vector3.Lerp(obj3.localScale, (Selected == k) ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
			else
			{
				for (int l = 1; l < 5; l++)
				{
					Transform obj4 = LoveSegment[l].transform;
					obj4.localScale = Vector3.Lerp(obj4.localScale, (Selected == l) ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
			if (Input.GetButtonDown("A"))
			{
				if (ClubLeader)
				{
					if (Selected != 0 && ClubShadow[Selected].color.a == 0f)
					{
						int num = 0;
						if (Yandere.TargetStudent.Sleuthing)
						{
							num = 5;
						}
						if (Selected == 1)
						{
							Impatience.fillAmount = 0f;
							Yandere.TargetStudent.Interaction = StudentInteractionType.ClubInfo;
							Yandere.TargetStudent.TalkTimer = 100f;
							Yandere.TargetStudent.ClubPhase = 1;
							Show = false;
						}
						else if (Selected == 2)
						{
							Impatience.fillAmount = 0f;
							Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
							Yandere.TargetStudent.TalkTimer = 100f;
							Show = false;
							ClubManager.CheckGrudge(Yandere.TargetStudent.Club);
							if (ClubGlobals.GetQuitClub(Yandere.TargetStudent.Club))
							{
								Yandere.TargetStudent.ClubPhase = 4;
							}
							else if (Yandere.Club != 0)
							{
								Yandere.TargetStudent.ClubPhase = 5;
							}
							else if (ClubManager.ClubGrudge)
							{
								Yandere.TargetStudent.ClubPhase = 6;
							}
							else
							{
								Yandere.TargetStudent.ClubPhase = 1;
							}
						}
						else if (Selected == 3)
						{
							Impatience.fillAmount = 0f;
							Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
							Yandere.TargetStudent.TalkTimer = 100f;
							Yandere.TargetStudent.ClubPhase = 1;
							Show = false;
						}
						else if (Selected == 4)
						{
							Impatience.fillAmount = 0f;
							Yandere.TargetStudent.Interaction = StudentInteractionType.ClubBye;
							Yandere.TargetStudent.TalkTimer = Yandere.Subtitle.ClubFarewellClips[(int)(Yandere.TargetStudent.Club + num)].length;
							Show = false;
							Debug.Log("This club leader exchange is over.");
						}
						else if (Selected == 5)
						{
							Impatience.fillAmount = 0f;
							Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
							Yandere.TargetStudent.TalkTimer = 100f;
							if (Clock.HourTime < 17f)
							{
								Yandere.TargetStudent.ClubPhase = 4;
							}
							else if (Clock.HourTime > 17.5f)
							{
								Yandere.TargetStudent.ClubPhase = 5;
							}
							else
							{
								Yandere.TargetStudent.ClubPhase = 1;
							}
							Show = false;
						}
						else if (Selected == 6)
						{
							Impatience.fillAmount = 0f;
							Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
							Yandere.TargetStudent.TalkTimer = 100f;
							Yandere.TargetStudent.ClubPhase = 1;
							Show = false;
						}
					}
				}
				else if (AskingFavor)
				{
					if (Selected != 0)
					{
						if (Selected < FavorShadow.Length && FavorShadow[Selected] != null && FavorShadow[Selected].color.a == 0f)
						{
							if (Selected == 1)
							{
								Impatience.fillAmount = 0f;
								Yandere.Interaction = YandereInteractionType.FollowMe;
								Yandere.TalkTimer = 3f;
								Show = false;
							}
							else if (Selected == 2)
							{
								Impatience.fillAmount = 0f;
								Yandere.Interaction = YandereInteractionType.GoAway;
								Yandere.TalkTimer = 3f;
								Show = false;
							}
							else if (Selected == 4)
							{
								PauseScreen.StudentInfoMenu.Distracting = true;
								PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
								PauseScreen.StudentInfoMenu.Column = 0;
								PauseScreen.StudentInfoMenu.Row = 0;
								PauseScreen.StudentInfoMenu.UpdateHighlight();
								StartCoroutine(PauseScreen.StudentInfoMenu.UpdatePortraits());
								PauseScreen.MainMenu.SetActive(value: false);
								PauseScreen.Panel.enabled = true;
								PauseScreen.Sideways = true;
								PauseScreen.Show = true;
								Time.timeScale = 0.0001f;
								PromptBar.ClearButtons();
								PromptBar.Label[1].text = "Cancel";
								PromptBar.UpdateButtons();
								PromptBar.Show = true;
								Impatience.fillAmount = 0f;
								Yandere.Interaction = YandereInteractionType.DistractThem;
								Yandere.TalkTimer = 3f;
								Show = false;
							}
						}
						if (Selected == 3)
						{
							AskingFavor = false;
						}
					}
				}
				else if (Matchmaking)
				{
					if (Selected != 0)
					{
						if (Selected < LoveShadow.Length && LoveShadow[Selected] != null && LoveShadow[Selected].color.a == 0f)
						{
							if (Selected == 1)
							{
								PromptBar.ClearButtons();
								PromptBar.Label[0].text = "Select";
								PromptBar.Label[4].text = "Change";
								PromptBar.UpdateButtons();
								PromptBar.Show = true;
								AppearanceWindow.gameObject.SetActive(value: true);
								AppearanceWindow.Show = true;
								Show = false;
							}
							else if (Selected == 2)
							{
								Impatience.fillAmount = 0f;
								Yandere.Interaction = YandereInteractionType.Court;
								Yandere.TalkTimer = 5f;
								Show = false;
							}
							else if (Selected == 4)
							{
								PromptBar.ClearButtons();
								PromptBar.Label[1].text = "Exit";
								PromptBar.Label[4].text = "Change";
								PromptBar.Label[5].text = "Change";
								PromptBar.UpdateButtons();
								PromptBar.Show = true;
								AdviceWindow.UpdateText();
								AdviceWindow.gameObject.SetActive(value: true);
								Time.timeScale = 0.0001f;
								base.transform.localScale = Vector3.zero;
								Yandere.Subtitle.Label.text = "";
								Impatience.fillAmount = 0f;
								Show = false;
							}
						}
						if (Selected == 3)
						{
							Matchmaking = false;
						}
					}
				}
				else if (Selected != 0 && Shadow[Selected].color.a == 0f)
				{
					if (Selected == 1)
					{
						Impatience.fillAmount = 0f;
						Yandere.Interaction = YandereInteractionType.Apologizing;
						Yandere.TalkTimer = 10f;
						Show = false;
					}
					else if (Selected == 2)
					{
						Time.timeScale = 0.0001f;
						TopicInterface.Socializing = true;
						TopicInterface.StudentID = Yandere.TargetStudent.StudentID;
						TopicInterface.Student = Yandere.TargetStudent;
						TopicInterface.UpdateOpinions();
						TopicInterface.UpdateTopicHighlight();
						TopicInterface.gameObject.SetActive(value: true);
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Speak";
						PromptBar.Label[1].text = "Back";
						PromptBar.Label[2].text = "Positive/Negative";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						base.transform.localScale = Vector3.zero;
						Impatience.fillAmount = 0f;
						Show = false;
					}
					else if (Selected == 3)
					{
						PauseScreen.StudentInfoMenu.Gossiping = true;
						PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
						PauseScreen.StudentInfoMenu.Column = 0;
						PauseScreen.StudentInfoMenu.Row = 0;
						PauseScreen.StudentInfoMenu.UpdateHighlight();
						StartCoroutine(PauseScreen.StudentInfoMenu.UpdatePortraits());
						PauseScreen.MainMenu.SetActive(value: false);
						PauseScreen.Panel.enabled = true;
						PauseScreen.Sideways = true;
						PauseScreen.Show = true;
						Time.timeScale = 0.0001f;
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = string.Empty;
						PromptBar.Label[1].text = "Cancel";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						Yandere.Subtitle.Label.text = "";
						base.transform.localScale = Vector3.zero;
						Impatience.fillAmount = 0f;
						Show = false;
					}
					else if (Selected == 4)
					{
						Impatience.fillAmount = 0f;
						Yandere.Interaction = YandereInteractionType.Bye;
						Yandere.TalkTimer = 2f;
						Show = false;
					}
					else if (Selected == 5)
					{
						if (!Yandere.TargetStudent.Friend)
						{
							CheckTaskCompletion();
							Show = false;
							if (Yandere.TargetStudent.TaskPhase == 0)
							{
								bool flag = true;
								if (Yandere.TargetStudent.StudentID == 36 && Clock.Period > 1)
								{
									Yandere.NotificationManager.CustomText = "Task only available in morning";
									Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
									flag = false;
									Show = true;
								}
								if (flag)
								{
									Impatience.fillAmount = 0f;
									Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
									Yandere.TargetStudent.TalkTimer = 100f;
									Yandere.TargetStudent.TaskPhase = 1;
								}
							}
							else
							{
								Impatience.fillAmount = 0f;
								Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
								Yandere.TargetStudent.TalkTimer = 100f;
							}
						}
						else if (Yandere.LoveManager.SuitorProgress == 0)
						{
							PauseScreen.StudentInfoMenu.MatchMaking = true;
							PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
							PauseScreen.StudentInfoMenu.Column = 0;
							PauseScreen.StudentInfoMenu.Row = 0;
							PauseScreen.StudentInfoMenu.UpdateHighlight();
							StartCoroutine(PauseScreen.StudentInfoMenu.UpdatePortraits());
							PauseScreen.MainMenu.SetActive(value: false);
							PauseScreen.Panel.enabled = true;
							PauseScreen.Sideways = true;
							PauseScreen.Show = true;
							Time.timeScale = 0.0001f;
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "View Info";
							PromptBar.Label[1].text = "Cancel";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							Impatience.fillAmount = 0f;
							Yandere.Interaction = YandereInteractionType.NamingCrush;
							Yandere.TalkTimer = 3f;
							Show = false;
						}
						else
						{
							Matchmaking = true;
						}
					}
					else if (Selected == 6)
					{
						AskingFavor = true;
					}
				}
			}
			else if (Input.GetButtonDown("X"))
			{
				if (TaskDialogueWindow.activeInHierarchy)
				{
					Impatience.fillAmount = 0f;
					Yandere.Interaction = YandereInteractionType.TaskInquiry;
					Yandere.TalkTimer = 3f;
					Show = false;
				}
				else if (SwitchTopicsWindow.activeInHierarchy)
				{
					ClubLeader = !ClubLeader;
					HideShadows();
				}
			}
			else if (Input.GetButtonDown("B") && LockerWindow.activeInHierarchy)
			{
				Impatience.fillAmount = 0f;
				Yandere.Interaction = YandereInteractionType.SendingToLocker;
				Yandere.TalkTimer = 5f;
				Show = false;
				if (Yandere.TargetStudent.StudentID == 11 && SchemeGlobals.GetSchemeStage(6) == 6)
				{
					SchemeGlobals.SetSchemeStage(6, 7);
					Yandere.PauseScreen.Schemes.UpdateInstructions();
				}
			}
		}
		PreviousPosition = Input.mousePosition;
	}

	public void HideShadows()
	{
		Jukebox.Dip = 0.5f;
		TaskDialogueWindow.SetActive(value: false);
		ClubLeaderWindow.SetActive(value: false);
		LockerWindow.SetActive(value: false);
		if (ClubLeader && !Yandere.TargetStudent.Talk.Fake)
		{
			SwitchTopicsWindow.SetActive(value: true);
		}
		else
		{
			SwitchTopicsWindow.SetActive(value: false);
		}
		if (Yandere.TargetStudent.Armband.activeInHierarchy && !ClubLeader && Yandere.TargetStudent.Club != ClubType.Council)
		{
			ClubLeaderWindow.SetActive(value: true);
		}
		if (Yandere.TargetStudent.Indoors && NoteLocker.NoteLeft && NoteLocker.Student == Yandere.TargetStudent)
		{
			LockerWindow.SetActive(value: true);
		}
		if (Yandere.TargetStudent.Club == ClubType.Bully && TaskManager.TaskStatus[36] == 1)
		{
			TaskDialogueWindow.SetActive(value: true);
		}
		if (Yandere.TargetStudent.StudentID == 10 && TaskManager.TaskStatus[46] == 1)
		{
			TaskDialogueWindow.SetActive(value: true);
		}
		TaskIcon.spriteName = (Yandere.TargetStudent.Friend ? "Heart" : "Task");
		Impatience.fillAmount = 0f;
		for (int i = 1; i < 7; i++)
		{
			UISprite uISprite = Shadow[i];
			uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, 0f);
		}
		for (int j = 1; j < 5; j++)
		{
			UISprite uISprite2 = FavorShadow[j];
			uISprite2.color = new Color(uISprite2.color.r, uISprite2.color.g, uISprite2.color.b, 0f);
		}
		for (int k = 1; k < 7; k++)
		{
			UISprite uISprite3 = ClubShadow[k];
			uISprite3.color = new Color(uISprite3.color.r, uISprite3.color.g, uISprite3.color.b, 0f);
		}
		for (int l = 1; l < 5; l++)
		{
			UISprite uISprite4 = LoveShadow[l];
			uISprite4.color = new Color(uISprite4.color.r, uISprite4.color.g, uISprite4.color.b, 0f);
		}
		if (!Yandere.TargetStudent.Witness || Yandere.TargetStudent.Forgave || Yandere.TargetStudent.Club == ClubType.Council)
		{
			UISprite uISprite5 = Shadow[1];
			uISprite5.color = new Color(uISprite5.color.r, uISprite5.color.g, uISprite5.color.b, 0.75f);
		}
		if (Yandere.TargetStudent.Complimented || Yandere.TargetStudent.Club == ClubType.Council)
		{
			UISprite uISprite6 = Shadow[2];
			uISprite6.color = new Color(uISprite6.color.r, uISprite6.color.g, uISprite6.color.b, 0.75f);
		}
		if (Yandere.TargetStudent.Gossiped || Yandere.TargetStudent.Club == ClubType.Council)
		{
			UISprite uISprite7 = Shadow[3];
			uISprite7.color = new Color(uISprite7.color.r, uISprite7.color.g, uISprite7.color.b, 0.75f);
		}
		if (Yandere.Bloodiness > 0f || Yandere.Sanity < 33.33333f || Yandere.TargetStudent.Club == ClubType.Council)
		{
			UISprite uISprite8 = Shadow[3];
			uISprite8.color = new Color(uISprite8.color.r, uISprite8.color.g, uISprite8.color.b, 0.75f);
			Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
			UISprite uISprite9 = Shadow[6];
			uISprite9.color = new Color(uISprite9.color.r, uISprite9.color.g, uISprite9.color.b, 0.75f);
		}
		else if (Reputation.Reputation < -33.33333f)
		{
			UISprite uISprite10 = Shadow[3];
			uISprite10.color = new Color(uISprite10.color.r, uISprite10.color.g, uISprite10.color.b, 0.75f);
		}
		if (!Yandere.TargetStudent.Indoors || Yandere.TargetStudent.Club == ClubType.Council)
		{
			Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
		}
		else if (!Yandere.TargetStudent.Friend)
		{
			bool flag = false;
			if (Yandere.StudentManager.Eighties)
			{
				if (Yandere.TargetStudent.StudentID != 79)
				{
					flag = true;
				}
				if (flag && TaskManager.TaskStatus[Yandere.TargetStudent.StudentID] == 1 && Yandere.Inventory.FinishedHomework)
				{
					Shadow[5].color = new Color(0f, 0f, 0f, 0f);
				}
			}
			else
			{
				if (Yandere.TargetStudent.StudentID != 8 && Yandere.TargetStudent.StudentID != 11 && Yandere.TargetStudent.StudentID != 25 && Yandere.TargetStudent.StudentID != 28 && Yandere.TargetStudent.StudentID != 30 && Yandere.TargetStudent.StudentID != 36 && Yandere.TargetStudent.StudentID != 37 && Yandere.TargetStudent.StudentID != 38 && Yandere.TargetStudent.StudentID != 52 && Yandere.TargetStudent.StudentID != 76 && Yandere.TargetStudent.StudentID != 77 && Yandere.TargetStudent.StudentID != 78 && Yandere.TargetStudent.StudentID != 79 && Yandere.TargetStudent.StudentID != 80 && Yandere.TargetStudent.StudentID != 81)
				{
					flag = true;
				}
				if (Yandere.TargetStudent.StudentID == 6)
				{
					Debug.Log("Speaking to Osana's suitor.");
					flag = false;
				}
				if (Yandere.TargetStudent.StudentID == 1 || Yandere.TargetStudent.StudentID == 10 || Yandere.TargetStudent.StudentID == 41)
				{
					Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
				}
				else
				{
					TaskManager.UpdateTaskStatus();
					if ((Yandere.TargetStudent.TaskPhase > 0 && Yandere.TargetStudent.TaskPhase < 5) || (TaskManager.TaskStatus[Yandere.TargetStudent.StudentID] > 0 && TaskManager.TaskStatus[Yandere.TargetStudent.StudentID] < 5 && TaskManager.TaskStatus[Yandere.TargetStudent.StudentID] != 2) || Yandere.TargetStudent.TaskPhase == 100)
					{
						Debug.Log("Hiding task button.");
						Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
					}
					if (Yandere.TargetStudent.TaskPhase == 5)
					{
						Shadow[5].color = new Color(0f, 0f, 0f, 0f);
					}
					if (Yandere.TargetStudent.StudentID == 6)
					{
						if (Yandere.StudentManager.Students[11] == null)
						{
							Debug.Log("Osana's dead; hiding suitor's Task button.");
							Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
						}
						else
						{
							Debug.Log("The status of Task #6 is:" + TaskManager.TaskStatus[6]);
							if (TaskManager.TaskStatus[6] == 1 && Yandere.Inventory.Headset)
							{
								Shadow[5].color = new Color(0f, 0f, 0f, 0f);
								Debug.Log("Player has a headset.");
							}
						}
					}
					else if (Yandere.TargetStudent.StudentID == 36)
					{
						if (TaskManager.TaskStatus[36] == 0 && (StudentGlobals.GetStudentDead(81) || StudentGlobals.GetStudentDead(82) || StudentGlobals.GetStudentDead(83) || StudentGlobals.GetStudentDead(84) || StudentGlobals.GetStudentDead(85)))
						{
							Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
						}
					}
					else if ((Yandere.TargetStudent.StudentID == 46 && Clock.Period == 3) || (Yandere.TargetStudent.StudentID == 46 && Clock.Period == 5))
					{
						Debug.Log("Hiding Budo's Task button.");
						Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
					}
					else if (Yandere.TargetStudent.StudentID == 81)
					{
						if (TaskManager.TaskStatus[81] == 0 && StudentGlobals.GetStudentDead(5))
						{
							Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
						}
					}
					else if (Yandere.TargetStudent.StudentID == 76)
					{
						if (TaskManager.TaskStatus[76] == 1 && Yandere.Inventory.Money >= 100f)
						{
							Shadow[5].color = new Color(0f, 0f, 0f, 0f);
							Debug.Log("Player has over $100.");
						}
					}
					else if (Yandere.TargetStudent.StudentID == 77)
					{
						if (TaskManager.TaskStatus[77] == 1 && ((Yandere.Weapon[1] != null && Yandere.Weapon[1].WeaponID == 1 && !Yandere.Weapon[1].Bloody) || (Yandere.Weapon[1] != null && Yandere.Weapon[1].WeaponID == 8 && !Yandere.Weapon[1].Bloody) || (Yandere.Weapon[2] != null && Yandere.Weapon[2].WeaponID == 1 && !Yandere.Weapon[2].Bloody) || (Yandere.Weapon[2] != null && Yandere.Weapon[2].WeaponID == 8 && !Yandere.Weapon[2].Bloody)))
						{
							Shadow[5].color = new Color(0f, 0f, 0f, 0f);
							Debug.Log("Player has a knife.");
						}
					}
					else if (Yandere.TargetStudent.StudentID == 78)
					{
						if (TaskManager.TaskStatus[78] == 1 && Yandere.Inventory.Sake)
						{
							Shadow[5].color = new Color(0f, 0f, 0f, 0f);
							Debug.Log("Player has sake.");
						}
					}
					else if (Yandere.TargetStudent.StudentID == 79)
					{
						if (TaskManager.TaskStatus[79] == 1 && Yandere.Inventory.Cigs)
						{
							Shadow[5].color = new Color(0f, 0f, 0f, 0f);
							Debug.Log("Player has ciggies.");
						}
					}
					else if (Yandere.TargetStudent.StudentID == 80 && TaskManager.TaskStatus[80] == 1 && (Yandere.Inventory.AnswerSheet || Yandere.Inventory.DuplicateSheet))
					{
						Shadow[5].color = new Color(0f, 0f, 0f, 0f);
						Debug.Log("Player has the answer sheet.");
					}
				}
				if (flag && TaskManager.TaskStatus[Yandere.TargetStudent.StudentID] == 1 && Yandere.Inventory.Book)
				{
					Shadow[5].color = new Color(0f, 0f, 0f, 0f);
					Debug.Log("The player has a library book.");
				}
			}
		}
		else if (Yandere.TargetStudent.StudentID != LoveManager.RivalID && Yandere.TargetStudent.StudentID != LoveManager.SuitorID)
		{
			Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
		}
		else if (!Yandere.TargetStudent.Male && LoveManager.SuitorProgress == 0)
		{
			Shadow[5].color = new Color(0f, 0f, 0f, 0.75f);
		}
		if (!Yandere.TargetStudent.Indoors || Yandere.TargetStudent.Club == ClubType.Council)
		{
			UISprite uISprite11 = Shadow[6];
			uISprite11.color = new Color(uISprite11.color.r, uISprite11.color.g, uISprite11.color.b, 0.75f);
		}
		else
		{
			if (!Yandere.TargetStudent.Friend)
			{
				Shadow[6].color = new Color(0f, 0f, 0f, 0.75f);
			}
			if ((Yandere.TargetStudent.Male && Yandere.Class.Seduction + Yandere.Class.SeductionBonus > 3) || Yandere.Class.Seduction + Yandere.Class.SeductionBonus > 4 || Yandere.Club == ClubType.Delinquent)
			{
				Shadow[6].color = new Color(0f, 0f, 0f, 0f);
			}
			if (Yandere.TargetStudent.Club == ClubType.Delinquent)
			{
				Shadow[6].color = new Color(0f, 0f, 0f, 0.75f);
			}
			_ = Yandere.TargetStudent.CurrentAction;
			_ = 30;
		}
		if (Yandere.Club == Yandere.TargetStudent.Club)
		{
			UISprite uISprite12 = ClubShadow[1];
			uISprite12.color = new Color(uISprite12.color.r, uISprite12.color.g, uISprite12.color.b, 0.75f);
			UISprite uISprite13 = ClubShadow[2];
			uISprite13.color = new Color(uISprite13.color.r, uISprite13.color.g, uISprite13.color.b, 0.75f);
		}
		if (Yandere.ClubAttire || Yandere.Mask != null || Yandere.Gloves != null || Yandere.Container != null)
		{
			UISprite uISprite14 = ClubShadow[3];
			uISprite14.color = new Color(uISprite14.color.r, uISprite14.color.g, uISprite14.color.b, 0.75f);
		}
		if (Yandere.Club != Yandere.TargetStudent.Club)
		{
			UISprite uISprite15 = ClubShadow[2];
			uISprite15.color = new Color(uISprite15.color.r, uISprite15.color.g, uISprite15.color.b, 0f);
			UISprite uISprite16 = ClubShadow[3];
			uISprite16.color = new Color(uISprite16.color.r, uISprite16.color.g, uISprite16.color.b, 0.75f);
			ClubShadow[5].color = new Color(0f, 0f, 0f, 0.75f);
		}
		if (Yandere.StudentManager.MurderTakingPlace)
		{
			ClubShadow[5].color = new Color(0f, 0f, 0f, 0.75f);
		}
		if ((Yandere.TargetStudent.StudentID != 46 && Yandere.TargetStudent.StudentID != 51 && Yandere.TargetStudent.StudentID != 76) || Yandere.Police.Show || Clock.Period == 3 || Clock.Period == 5)
		{
			UISprite uISprite17 = ClubShadow[6];
			uISprite17.color = new Color(uISprite17.color.r, uISprite17.color.g, uISprite17.color.b, 0.75f);
		}
		if (Yandere.TargetStudent.StudentID == 51 || Yandere.TargetStudent.StudentID == 76)
		{
			int num = 4;
			if (Yandere.TargetStudent.StudentID == 51 && (Yandere.Club != ClubType.LightMusic || PracticeWindow.PlayedRhythmMinigame))
			{
				num = 0;
			}
			for (int m = Yandere.TargetStudent.StudentID + 1; m < Yandere.TargetStudent.StudentID + 5; m++)
			{
				if (Yandere.StudentManager.Students[m] == null)
				{
					num--;
				}
				else if (!Yandere.StudentManager.Students[m].gameObject.activeInHierarchy || Yandere.StudentManager.Students[m].Investigating || Yandere.StudentManager.Students[m].Distracting || Yandere.StudentManager.Students[m].Distracted || Yandere.StudentManager.Students[m].SentHome || Yandere.StudentManager.Students[m].Tranquil || Yandere.StudentManager.Students[m].GoAway || !Yandere.StudentManager.Students[m].Routine || !Yandere.StudentManager.Students[m].Alive)
				{
					num--;
				}
			}
			if (num < 4)
			{
				UISprite uISprite18 = ClubShadow[6];
				uISprite18.color = new Color(uISprite18.color.r, uISprite18.color.g, uISprite18.color.b, 0.75f);
			}
		}
		if (Yandere.Followers > 0)
		{
			Debug.Log("Can't do task because of follower.");
			UISprite uISprite19 = FavorShadow[1];
			uISprite19.color = new Color(uISprite19.color.r, uISprite19.color.g, uISprite19.color.b, 0.75f);
		}
		if (Yandere.TargetStudent.DistanceToDestination > 2f)
		{
			UISprite uISprite20 = FavorShadow[2];
			uISprite20.color = new Color(uISprite20.color.r, uISprite20.color.g, uISprite20.color.b, 0.75f);
		}
		if (!Yandere.TargetStudent.Male)
		{
			UISprite uISprite21 = LoveShadow[1];
			uISprite21.color = new Color(uISprite21.color.r, uISprite21.color.g, uISprite21.color.b, 0.75f);
		}
		if (DatingMinigame == null || (Yandere.TargetStudent.Male && !LoveManager.RivalWaiting) || LoveManager.Courted)
		{
			UISprite uISprite22 = LoveShadow[2];
			uISprite22.color = new Color(uISprite22.color.r, uISprite22.color.g, uISprite22.color.b, 0.75f);
		}
		if (Yandere.TargetStudent.StudentID != Yandere.StudentManager.SuitorID)
		{
			UISprite uISprite23 = LoveShadow[4];
			uISprite23.color = new Color(uISprite23.color.r, uISprite23.color.g, uISprite23.color.b, 0.75f);
		}
		if (Yandere.StudentManager.TutorialActive)
		{
			for (int n = 2; n < 7; n++)
			{
				UISprite uISprite24 = Shadow[n];
				uISprite24.color = new Color(uISprite24.color.r, uISprite24.color.g, uISprite24.color.b, 0.75f);
			}
		}
	}

	private void CheckTaskCompletion()
	{
		bool flag = false;
		if (Yandere.StudentManager.Eighties)
		{
			if (Yandere.TargetStudent.StudentID != 79)
			{
				flag = true;
			}
		}
		else
		{
			if (Yandere.TargetStudent.StudentID == 6 && TaskManager.TaskStatus[6] == 1)
			{
				if (Yandere.Inventory.Headset)
				{
					Yandere.TargetStudent.TaskPhase = 5;
					Yandere.LoveManager.SuitorProgress = 1;
					DatingGlobals.SuitorProgress = 1;
				}
			}
			else if (Yandere.TargetStudent.StudentID == 36 && TaskManager.TaskStatus[36] == 1)
			{
				Yandere.TargetStudent.UpdateAppearance = true;
				ScheduleBlock obj = Yandere.TargetStudent.ScheduleBlocks[Yandere.TargetStudent.Phase];
				obj.destination = "LockerRoom";
				obj.action = "UpdateAppearance";
				Yandere.TargetStudent.GetDestinations();
				Yandere.TargetStudent.TaskPhase = 5;
			}
			else if (Yandere.TargetStudent.StudentID == 11 && TaskManager.TaskStatus[11] == 2)
			{
				Debug.Log("Setting Osana's phone charm active.");
				Yandere.TargetStudent.Cosmetic.PhoneCharms[11].SetActive(value: true);
			}
			else if (Yandere.TargetStudent.StudentID == 76 && TaskManager.TaskStatus[76] == 1)
			{
				Yandere.TargetStudent.RespectEarned = true;
				Yandere.TargetStudent.TaskPhase = 5;
				Yandere.Inventory.Money -= 100f;
				Yandere.Inventory.UpdateMoney();
			}
			else if (Yandere.TargetStudent.StudentID == 77 && TaskManager.TaskStatus[77] == 1)
			{
				Yandere.TargetStudent.RespectEarned = true;
				Yandere.TargetStudent.TaskPhase = 5;
				WeaponScript weaponScript;
				if ((Yandere.Weapon[1] != null && Yandere.Weapon[1].WeaponID == 1) || (Yandere.Weapon[1] != null && Yandere.Weapon[1].WeaponID == 8))
				{
					weaponScript = Yandere.Weapon[1];
					Yandere.Weapon[1] = null;
				}
				else
				{
					weaponScript = Yandere.Weapon[2];
					Yandere.Weapon[2] = null;
				}
				weaponScript.Drop();
				weaponScript.FingerprintID = 77;
				weaponScript.gameObject.SetActive(value: false);
				Yandere.WeaponManager.UpdateLabels();
				Yandere.WeaponMenu.UpdateSprites();
			}
			else if (Yandere.TargetStudent.StudentID == 78 && TaskManager.TaskStatus[78] == 1)
			{
				Yandere.TargetStudent.RespectEarned = true;
				Yandere.TargetStudent.TaskPhase = 5;
				Yandere.Inventory.Sake = false;
			}
			else if (Yandere.TargetStudent.StudentID == 79 && TaskManager.TaskStatus[79] == 1)
			{
				Yandere.TargetStudent.RespectEarned = true;
				Yandere.TargetStudent.TaskPhase = 5;
				Yandere.Inventory.Cigs = false;
			}
			else if (Yandere.TargetStudent.StudentID == 80 && TaskManager.TaskStatus[80] == 1)
			{
				Yandere.TargetStudent.RespectEarned = true;
				Yandere.TargetStudent.TaskPhase = 5;
				Yandere.Inventory.AnswerSheet = false;
			}
			if (Yandere.TargetStudent.StudentID != 8 && Yandere.TargetStudent.StudentID != 11 && Yandere.TargetStudent.StudentID != 25 && Yandere.TargetStudent.StudentID != 28 && Yandere.TargetStudent.StudentID != 30 && Yandere.TargetStudent.StudentID != 36 && Yandere.TargetStudent.StudentID != 37 && Yandere.TargetStudent.StudentID != 38 && Yandere.TargetStudent.StudentID != 52 && Yandere.TargetStudent.StudentID != 76 && Yandere.TargetStudent.StudentID != 77 && Yandere.TargetStudent.StudentID != 78 && Yandere.TargetStudent.StudentID != 79 && Yandere.TargetStudent.StudentID != 80 && Yandere.TargetStudent.StudentID != 81)
			{
				flag = true;
			}
		}
		if (flag && TaskManager.TaskStatus[Yandere.TargetStudent.StudentID] == 1 && ((!Yandere.StudentManager.Eighties && Yandere.Inventory.Book) || (Yandere.StudentManager.Eighties && Yandere.Inventory.FinishedHomework)))
		{
			Yandere.TargetStudent.TaskPhase = 5;
		}
		if (Yandere.Club == ClubType.Delinquent)
		{
			Text[6] = "Intimidate";
		}
		else
		{
			Text[6] = "Ask Favor";
		}
	}

	public void End()
	{
		if (Yandere.TargetStudent != null)
		{
			if (Yandere.TargetStudent.Pestered >= 10)
			{
				Yandere.TargetStudent.Ignoring = true;
			}
			if (!Pestered)
			{
				Yandere.Subtitle.Label.text = string.Empty;
			}
			Yandere.TargetStudent.Interaction = StudentInteractionType.Idle;
			Yandere.TargetStudent.WaitTimer = 1f;
			if (Yandere.TargetStudent.enabled)
			{
				Yandere.TargetStudent.CurrentDestination = Yandere.TargetStudent.Destinations[Yandere.TargetStudent.Phase];
				Yandere.TargetStudent.Pathfinding.target = Yandere.TargetStudent.Destinations[Yandere.TargetStudent.Phase];
				if (Yandere.TargetStudent.Actions[Yandere.TargetStudent.Phase] == StudentActionType.Clean)
				{
					Yandere.TargetStudent.EquipCleaningItems();
				}
				if (Yandere.TargetStudent.Actions[Yandere.TargetStudent.Phase] == StudentActionType.Patrol)
				{
					Yandere.TargetStudent.CurrentDestination = Yandere.TargetStudent.StudentManager.Patrols.List[Yandere.TargetStudent.StudentID].GetChild(Yandere.TargetStudent.PatrolID);
					Yandere.TargetStudent.Pathfinding.target = Yandere.TargetStudent.CurrentDestination;
				}
				if (Yandere.TargetStudent.Actions[Yandere.TargetStudent.Phase] == StudentActionType.Sleuth)
				{
					Yandere.TargetStudent.CurrentDestination = Yandere.TargetStudent.SleuthTarget;
					Yandere.TargetStudent.Pathfinding.target = Yandere.TargetStudent.SleuthTarget;
				}
				if (Yandere.TargetStudent.Actions[Yandere.TargetStudent.Phase] == StudentActionType.Sunbathe && Yandere.TargetStudent.SunbathePhase > 1)
				{
					Yandere.TargetStudent.CurrentDestination = Yandere.StudentManager.SunbatheSpots[Yandere.TargetStudent.StudentID];
					Yandere.TargetStudent.Pathfinding.target = Yandere.StudentManager.SunbatheSpots[Yandere.TargetStudent.StudentID];
				}
			}
			if (Yandere.TargetStudent.Persona == PersonaType.PhoneAddict)
			{
				bool flag = false;
				if (Yandere.TargetStudent.CurrentAction == StudentActionType.Sunbathe && Yandere.TargetStudent.SunbathePhase > 2)
				{
					flag = true;
				}
				if (!Yandere.TargetStudent.Scrubber.activeInHierarchy && !flag && !Yandere.TargetStudent.Phoneless)
				{
					Yandere.TargetStudent.SmartPhone.SetActive(value: true);
					Yandere.TargetStudent.WalkAnim = Yandere.TargetStudent.PhoneAnims[1];
				}
				else
				{
					Yandere.TargetStudent.SmartPhone.SetActive(value: false);
				}
			}
			if (Yandere.TargetStudent.LostTeacherTrust)
			{
				Yandere.TargetStudent.WalkAnim = Yandere.TargetStudent.BulliedWalkAnim;
				Yandere.TargetStudent.SmartPhone.SetActive(value: false);
			}
			if (Yandere.TargetStudent.EatingSnack)
			{
				Yandere.TargetStudent.Scrubber.SetActive(value: false);
				Yandere.TargetStudent.Eraser.SetActive(value: false);
			}
			if (Yandere.TargetStudent.SentToLocker)
			{
				Yandere.TargetStudent.CurrentDestination = Yandere.TargetStudent.MyLocker;
				Yandere.TargetStudent.Pathfinding.target = Yandere.TargetStudent.MyLocker;
			}
			if (Yandere.TargetStudent.StudentID == 10 && Yandere.TargetStudent.FollowTarget != null && Yandere.TargetStudent.FollowTarget.FocusOnYandere)
			{
				Debug.Log("Osana was stopped, but she should continue walking now.");
				Yandere.TargetStudent.FollowTarget.Pathfinding.canSearch = true;
				Yandere.TargetStudent.FollowTarget.Pathfinding.canMove = true;
				Yandere.TargetStudent.FollowTarget.FocusOnYandere = false;
				Yandere.TargetStudent.FollowTarget.Routine = true;
			}
			Yandere.TargetStudent.Talk.NegativeResponse = false;
			Yandere.ShoulderCamera.OverShoulder = false;
			Yandere.TargetStudent.Waiting = true;
			Yandere.TargetStudent = null;
		}
		Yandere.CameraEffects.UpdateDOF(2f);
		Yandere.StudentManager.VolumeUp();
		Jukebox.Dip = 1f;
		AskingFavor = false;
		Matchmaking = false;
		ClubLeader = false;
		Pestered = false;
		Show = false;
	}
}
