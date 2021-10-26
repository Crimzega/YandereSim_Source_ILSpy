using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenuScript : MonoBehaviour
{
	public FakeStudentSpawnerScript FakeStudentSpawner;

	public DelinquentManagerScript DelinquentManager;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public WeaponManagerScript WeaponManager;

	public ReputationScript Reputation;

	public CounselorScript Counselor;

	public DebugConsole DebugConsole;

	public YandereScript Yandere;

	public BentoScript Bento;

	public ClockScript Clock;

	public PrayScript Turtle;

	public ZoomScript Zoom;

	public AstarPath Astar;

	public OsanaFridayBeforeClassEvent1Script OsanaEvent1;

	public OsanaFridayBeforeClassEvent2Script OsanaEvent2;

	public OsanaFridayLunchEventScript OsanaEvent3;

	public GameObject EasterEggWindow;

	public GameObject SacrificialArm;

	public GameObject DebugPoisons;

	public GameObject CircularSaw;

	public GameObject GreenScreen;

	public GameObject Knife;

	public Transform[] TeleportSpot;

	public Transform RooftopSpot;

	public Transform MidoriSpot;

	public Transform Lockers;

	public GameObject MissionModeWindow;

	public GameObject Window;

	public GameObject[] ElectrocutionKit;

	public bool WaitingForNumber;

	public bool TryNextFrame;

	public bool MissionMode;

	public bool NoDebug;

	public int KidnappedVictim = 11;

	public int RooftopStudent = 7;

	public int DebugInputs;

	public float Timer;

	public int ID;

	public Texture PantyCensorTexture;

	private int DebugInt;

	public GameObject Mop;

	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 0f, base.transform.localPosition.z);
		MissionModeWindow.SetActive(value: false);
		Window.SetActive(value: false);
		MissionMode = true;
		NoDebug = true;
	}

	private void Update()
	{
		if (!MissionMode && !NoDebug)
		{
			if (!Yandere.InClass && !Yandere.Chased && Yandere.Chasers == 0 && Yandere.CanMove)
			{
				if (Input.GetKeyDown(KeyCode.Backslash) && Yandere.transform.position.y < 100f)
				{
					EasterEggWindow.SetActive(value: false);
					Window.SetActive(!Window.activeInHierarchy);
				}
			}
			else if (Window.activeInHierarchy)
			{
				Window.SetActive(value: false);
			}
			if (Window.activeInHierarchy)
			{
				if (Input.GetKeyDown(KeyCode.F1))
				{
					StudentGlobals.FemaleUniform = 1;
					StudentGlobals.MaleUniform = 1;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F2))
				{
					StudentGlobals.FemaleUniform = 2;
					StudentGlobals.MaleUniform = 2;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F3))
				{
					StudentGlobals.FemaleUniform = 3;
					StudentGlobals.MaleUniform = 3;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F4))
				{
					StudentGlobals.FemaleUniform = 4;
					StudentGlobals.MaleUniform = 4;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F5))
				{
					StudentGlobals.FemaleUniform = 5;
					StudentGlobals.MaleUniform = 5;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F6))
				{
					StudentGlobals.FemaleUniform = 6;
					StudentGlobals.MaleUniform = 6;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F7))
				{
					for (ID = 1; ID < 8; ID++)
					{
						StudentManager.DrinkingFountains[ID].PowerSwitch.PowerOutlet.SabotagedOutlet.SetActive(value: true);
						StudentManager.DrinkingFountains[ID].Puddle.SetActive(value: true);
					}
					Window.SetActive(value: false);
				}
				else if (Input.GetKeyDown(KeyCode.F8))
				{
					GameGlobals.CensorBlood = !GameGlobals.CensorBlood;
					WeaponManager.ChangeBloodTexture();
					Yandere.Bloodiness += 0f;
					Window.SetActive(value: false);
				}
				else if (Input.GetKeyDown(KeyCode.F9))
				{
					GameGlobals.CensorKillingAnims = !GameGlobals.CensorKillingAnims;
					Yandere.AttackManager.Censor = !Yandere.AttackManager.Censor;
					Window.SetActive(value: false);
				}
				else if (Input.GetKeyDown(KeyCode.F10))
				{
					StudentManager.Students[21].Attempts = 101;
					StudentManager.Students[22].Attempts = 101;
					StudentManager.Students[23].Attempts = 101;
					StudentManager.Students[24].Attempts = 101;
					StudentManager.Students[25].Attempts = 101;
					Window.SetActive(value: false);
				}
				else if (Input.GetKeyDown(KeyCode.F11))
				{
					DatingGlobals.RivalSabotaged = 5;
					DateGlobals.Weekday = DayOfWeek.Friday;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (!Input.GetKeyDown(KeyCode.F12))
				{
					if (Input.GetKeyDown(KeyCode.Alpha1))
					{
						DateGlobals.Weekday = DayOfWeek.Monday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha2))
					{
						DateGlobals.Weekday = DayOfWeek.Tuesday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha3))
					{
						DateGlobals.Weekday = DayOfWeek.Wednesday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha4))
					{
						DateGlobals.Weekday = DayOfWeek.Thursday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha5))
					{
						DateGlobals.Weekday = DayOfWeek.Friday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha6))
					{
						Yandere.transform.position = TeleportSpot[1].position;
						if (Yandere.Followers > 0)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha7))
					{
						Yandere.transform.position = TeleportSpot[2].position + new Vector3(0.75f, 0f, 0f);
						if (Yandere.Followers > 0)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha8))
					{
						Yandere.transform.position = TeleportSpot[3].position;
						if (Yandere.Followers > 0)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha9))
					{
						Yandere.transform.position = TeleportSpot[4].position;
						if (Yandere.Followers > 0)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Clock.PresentTime = 426f;
						StudentScript studentScript = StudentManager.Students[30];
						if (studentScript != null)
						{
							if (studentScript.Phase < 2)
							{
								studentScript.ShoeRemoval.Start();
								studentScript.ShoeRemoval.PutOnShoes();
								studentScript.CanTalk = true;
								studentScript.Phase = 2;
								studentScript.CurrentDestination = studentScript.Destinations[2];
								studentScript.Pathfinding.target = studentScript.Destinations[2];
							}
							studentScript.transform.position = studentScript.Destinations[2].position;
						}
						StudentScript studentScript2 = StudentManager.Students[28];
						if (studentScript2 != null)
						{
							studentScript2.ShoeRemoval.Start();
							studentScript2.ShoeRemoval.PutOnShoes();
							studentScript2.Phase = 2;
							studentScript2.CurrentDestination = studentScript2.Destinations[2];
							studentScript2.Pathfinding.target = studentScript2.Destinations[2];
							studentScript2.transform.position = studentScript2.Destinations[2].position;
						}
						StudentScript studentScript3 = StudentManager.Students[39];
						if (studentScript3 != null)
						{
							studentScript3.ShoeRemoval.Start();
							studentScript3.ShoeRemoval.PutOnShoes();
							studentScript3.Phase = 2;
							studentScript3.ScheduleBlocks[2].action = "Stand";
							studentScript3.GetDestinations();
							studentScript3.CurrentDestination = MidoriSpot;
							studentScript3.Pathfinding.target = MidoriSpot;
							studentScript3.transform.position = MidoriSpot.position;
						}
						Window.SetActive(value: false);
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.Alpha0))
					{
						Yandere.transform.position = TeleportSpot[11].position;
						if (Yandere.Followers > 0)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Window.SetActive(value: false);
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.A))
					{
						if (SchoolAtmosphere.Type == SchoolAtmosphereType.High)
						{
							SchoolGlobals.SchoolAtmosphere = 0.5f;
						}
						else if (SchoolAtmosphere.Type == SchoolAtmosphereType.Medium)
						{
							SchoolGlobals.SchoolAtmosphere = 0f;
						}
						else
						{
							SchoolGlobals.SchoolAtmosphere = 1f;
						}
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.C))
					{
						for (ID = 1; ID < 11; ID++)
						{
							CollectibleGlobals.SetTapeCollected(ID, value: true);
							StudentManager.TapesCollected[ID] = true;
						}
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.D))
					{
						for (ID = 0; ID < 5; ID++)
						{
							StudentScript studentScript4 = StudentManager.Students[76 + ID];
							if (studentScript4 != null)
							{
								if (studentScript4.Phase < 2)
								{
									studentScript4.ShoeRemoval.Start();
									studentScript4.ShoeRemoval.PutOnShoes();
									studentScript4.Phase = 2;
									studentScript4.CurrentDestination = studentScript4.Destinations[2];
									studentScript4.Pathfinding.target = studentScript4.Destinations[2];
								}
								studentScript4.transform.position = studentScript4.Destinations[2].position;
							}
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
						CounselorGlobals.CounselorTape = 1;
						CounselorGlobals.DelinquentPunishments = 5;
					}
					else if (Input.GetKeyDown(KeyCode.F))
					{
						GreenScreen.SetActive(value: true);
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.G))
					{
						StudentScript studentScript5 = StudentManager.Students[RooftopStudent];
						if (Clock.HourTime < 15f)
						{
							PlayerGlobals.SetStudentFriend(RooftopStudent, value: true);
							StudentManager.Students[RooftopStudent].Friend = true;
							Yandere.transform.position = RooftopSpot.position + new Vector3(1f, 0f, 0f);
							WeaponManager.Weapons[6].transform.position = Yandere.transform.position + new Vector3(0f, 0f, 1.915f);
							if (studentScript5 != null)
							{
								StudentManager.OsanaOfferHelp.UpdateLocation();
								StudentManager.OsanaOfferHelp.enabled = true;
								StudentManager.NoteWindow.MeetID = 9;
								if (!studentScript5.Indoors)
								{
									if (studentScript5.ShoeRemoval.Locker == null)
									{
										studentScript5.ShoeRemoval.Start();
									}
									studentScript5.ShoeRemoval.PutOnShoes();
								}
								studentScript5.CharacterAnimation.Play(studentScript5.IdleAnim);
								studentScript5.transform.position = RooftopSpot.position;
								studentScript5.transform.rotation = RooftopSpot.rotation;
								studentScript5.Prompt.Label[0].text = "     Push";
								studentScript5.CurrentDestination = RooftopSpot;
								studentScript5.Pathfinding.target = RooftopSpot;
								studentScript5.Pathfinding.canSearch = false;
								studentScript5.Pathfinding.canMove = false;
								studentScript5.SpeechLines.Stop();
								studentScript5.Pushable = true;
								studentScript5.Routine = false;
								studentScript5.Meeting = true;
								studentScript5.MeetTime = 0f;
							}
							if (Clock.HourTime < 7.1f)
							{
								Clock.PresentTime = 426f;
							}
						}
						else
						{
							Clock.PresentTime = 960f;
							studentScript5.transform.position = Lockers.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.K))
					{
						SchoolGlobals.KidnapVictim = KidnappedVictim;
						StudentGlobals.StudentSlave = KidnappedVictim;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.L))
					{
						DatingGlobals.Affection = 100f;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.M))
					{
						PlayerGlobals.Money = 100f;
						Yandere.Inventory.Money = 100f;
						Yandere.Inventory.UpdateMoney();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.O))
					{
						Yandere.Inventory.RivalPhone = true;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.P))
					{
						for (ID = 2; ID < 93; ID++)
						{
							StudentScript studentScript6 = StudentManager.Students[ID];
							if (studentScript6 != null)
							{
								studentScript6.Patience = 999;
								studentScript6.Pestered = -999;
								studentScript6.Ignoring = false;
							}
						}
						Yandere.Inventory.PantyShots += 20;
						PlayerGlobals.PantyShots += 20;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Q))
					{
						Censor();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.R))
					{
						if (PlayerGlobals.Reputation == -100f)
						{
							PlayerGlobals.Reputation = -66.66666f;
						}
						else if (PlayerGlobals.Reputation == -66.66666f)
						{
							PlayerGlobals.Reputation = 0f;
						}
						else if (PlayerGlobals.Reputation == 0f)
						{
							PlayerGlobals.Reputation = 66.66666f;
						}
						else if (PlayerGlobals.Reputation == 66.66666f)
						{
							PlayerGlobals.Reputation = 100f;
						}
						else if (PlayerGlobals.Reputation == 100f)
						{
							PlayerGlobals.Reputation = -100f;
						}
						else
						{
							PlayerGlobals.Reputation = 0f;
						}
						Reputation.Reputation = PlayerGlobals.Reputation;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.S))
					{
						Yandere.Class.PhysicalGrade = 5;
						Yandere.Class.Seduction = 5;
						StudentManager.Police.UpdateCorpses();
						for (ID = 1; ID < 101; ID++)
						{
							StudentGlobals.SetStudentPhotographed(ID, value: true);
							if (StudentManager.Students[ID] != null)
							{
								StudentManager.Students[ID].Friend = true;
							}
						}
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.T))
					{
						Zoom.OverShoulder = !Zoom.OverShoulder;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.U))
					{
						PlayerGlobals.SetStudentFriend(6, value: true);
						PlayerGlobals.SetStudentFriend(11, value: true);
						StudentManager.Students[6].Friend = true;
						StudentManager.Students[11].Friend = true;
						for (ID = 1; ID < 26; ID++)
						{
							ConversationGlobals.SetTopicLearnedByStudent(ID, 11, value: true);
							ConversationGlobals.SetTopicDiscovered(ID, value: true);
						}
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Z))
					{
						Yandere.Police.Invalid = true;
						if (Input.GetKey(KeyCode.LeftShift))
						{
							for (ID = 2; ID < 93; ID++)
							{
								_ = StudentManager.Students[ID] != null;
							}
						}
						else
						{
							for (ID = 2; ID < 101; ID++)
							{
								StudentScript studentScript7 = StudentManager.Students[ID];
								if (studentScript7 != null)
								{
									studentScript7.SpawnAlarmDisc();
									studentScript7.BecomeRagdoll();
									studentScript7.DeathType = DeathType.EasterEgg;
								}
							}
						}
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.X))
					{
						TaskGlobals.SetTaskStatus(36, 3);
						SchoolGlobals.ReactedToGameLeader = false;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Backspace))
					{
						Time.timeScale = 1f;
						Clock.PresentTime = 1079f;
						Clock.HourTime = Clock.PresentTime / 60f;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.BackQuote))
					{
						bool debug = GameGlobals.Debug;
						bool eighties = GameGlobals.Eighties;
						Globals.DeleteAll();
						GameGlobals.Debug = debug;
						GameGlobals.Eighties = eighties;
						StudentGlobals.FemaleUniform = 6;
						StudentGlobals.MaleUniform = 6;
						for (int i = 1; i < 101; i++)
						{
							StudentGlobals.SetStudentPhotographed(i, value: true);
						}
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Space))
					{
						Yandere.transform.position = TeleportSpot[5].position;
						if (Yandere.Follower != null)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						for (int j = 46; j < 51; j++)
						{
							if (!(StudentManager.Students[j] != null))
							{
								continue;
							}
							StudentManager.Students[j].transform.position = TeleportSpot[5].position;
							if (!StudentManager.Students[j].Indoors)
							{
								if (StudentManager.Students[j].ShoeRemoval.Locker == null)
								{
									StudentManager.Students[j].ShoeRemoval.Start();
								}
								StudentManager.Students[j].ShoeRemoval.PutOnShoes();
							}
						}
						Clock.PresentTime = 1015f;
						Clock.HourTime = Clock.PresentTime / 60f;
						Window.SetActive(value: false);
						OsanaEvent1.enabled = false;
						OsanaEvent2.enabled = false;
						OsanaEvent3.enabled = false;
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.LeftAlt))
					{
						Turtle.SpawnWeapons();
						Yandere.transform.position = TeleportSpot[6].position;
						if (Yandere.Follower != null)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Clock.PresentTime = 425f;
						Clock.HourTime = Clock.PresentTime / 60f;
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.LeftControl))
					{
						Yandere.transform.position = TeleportSpot[7].position;
						if (Yandere.Follower != null)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.RightControl))
					{
						Yandere.transform.position = TeleportSpot[8].position;
						if (Yandere.Follower != null)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Equals))
					{
						Clock.PresentTime += 10f;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Return))
					{
						Yandere.transform.eulerAngles = TeleportSpot[10].eulerAngles;
						Yandere.transform.position = TeleportSpot[10].position;
						if (Yandere.Follower != null)
						{
							Yandere.Follower.transform.position = Yandere.transform.position;
						}
						StudentManager.Students[1].ShoeRemoval.Start();
						StudentManager.Students[1].ShoeRemoval.PutOnShoes();
						StudentManager.Students[1].transform.position = new Vector3(0f, 12.1f, -25f);
						StudentManager.Students[1].Alarmed = true;
						StudentManager.Students[11].Lethal = true;
						StudentManager.Students[11].ShoeRemoval.Start();
						StudentManager.Students[11].ShoeRemoval.PutOnShoes();
						StudentManager.Students[11].transform.position = new Vector3(0f, 12.1f, -25f);
						Clock.PresentTime = 780f;
						Clock.HourTime = Clock.PresentTime / 60f;
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.B))
					{
						Yandere.Inventory.Headset = true;
						StudentManager.LoveManager.SuitorProgress = 1;
						DatingGlobals.SuitorProgress = 1;
						PlayerGlobals.SetStudentFriend(6, value: true);
						PlayerGlobals.SetStudentFriend(11, value: true);
						StudentManager.Students[6].Friend = true;
						StudentManager.Students[11].Friend = true;
						for (int k = 0; k < 11; k++)
						{
							DatingGlobals.SetComplimentGiven(k, value: false);
						}
						for (ID = 1; ID < 26; ID++)
						{
							ConversationGlobals.SetTopicLearnedByStudent(ID, 11, value: true);
							ConversationGlobals.SetTopicDiscovered(ID, value: true);
						}
						StudentScript studentScript8 = StudentManager.Students[11];
						if (studentScript8 != null)
						{
							studentScript8.ShoeRemoval.Start();
							studentScript8.ShoeRemoval.PutOnShoes();
							studentScript8.CanTalk = true;
							studentScript8.Phase = 2;
							studentScript8.Pestered = 0;
							studentScript8.Patience = 999;
							studentScript8.Ignoring = false;
							studentScript8.CurrentDestination = studentScript8.Destinations[2];
							studentScript8.Pathfinding.target = studentScript8.Destinations[2];
							studentScript8.transform.position = studentScript8.Destinations[2].position;
						}
						StudentScript studentScript9 = StudentManager.Students[6];
						if (studentScript9 != null)
						{
							studentScript9.ShoeRemoval.Start();
							studentScript9.ShoeRemoval.PutOnShoes();
							studentScript9.Phase = 2;
							studentScript9.Pestered = 0;
							studentScript9.Patience = 999;
							studentScript9.Ignoring = false;
							studentScript9.CurrentDestination = studentScript9.Destinations[2];
							studentScript9.Pathfinding.target = studentScript9.Destinations[2];
							studentScript9.transform.position = studentScript9.Destinations[2].position;
						}
						_ = StudentManager.Students[10];
						if (studentScript9 != null)
						{
							studentScript9.transform.position = studentScript8.transform.position;
						}
						CollectibleGlobals.SetGiftPurchased(6, value: true);
						CollectibleGlobals.SetGiftPurchased(7, value: true);
						CollectibleGlobals.SetGiftPurchased(8, value: true);
						CollectibleGlobals.SetGiftPurchased(9, value: true);
						Physics.SyncTransforms();
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.Pause))
					{
						Clock.StopTime = !Clock.StopTime;
						Window.SetActive(value: false);
					}
					else if (Input.GetKeyDown(KeyCode.W))
					{
						DateGlobals.Week++;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.H))
					{
						StudentGlobals.FragileSlave = 5;
						StudentGlobals.FragileTarget = 11;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.I))
					{
						StudentManager.Students[3].BecomeRagdoll();
						WeaponManager.Weapons[1].Blood.enabled = true;
						WeaponManager.Weapons[1].FingerprintID = 2;
						WeaponManager.Weapons[1].Victims[3] = true;
						StudentManager.Students[5].BecomeRagdoll();
						WeaponManager.Weapons[2].Blood.enabled = true;
						WeaponManager.Weapons[2].FingerprintID = 4;
						WeaponManager.Weapons[2].Victims[5] = true;
					}
					else if (!Input.GetKeyDown(KeyCode.J))
					{
						if (Input.GetKeyDown(KeyCode.V))
						{
							StudentManager.LoveManager.ConfessToSuitor = true;
							StudentManager.DatingMinigame.Affection = 100f;
							DateGlobals.Weekday = DayOfWeek.Friday;
							Window.SetActive(value: false);
						}
						else if (Input.GetKeyDown(KeyCode.N))
						{
							ElectrocutionKit[0].transform.position = Yandere.transform.position;
							ElectrocutionKit[1].transform.position = Yandere.transform.position;
							ElectrocutionKit[2].transform.position = Yandere.transform.position;
							ElectrocutionKit[3].transform.position = Yandere.transform.position;
							ElectrocutionKit[3].SetActive(value: true);
						}
					}
				}
				if (Input.GetKeyDown(KeyCode.Tab))
				{
					DatingGlobals.SuitorProgress = 2;
					SceneManager.LoadScene("LoadingScene");
				}
				if (Input.GetKeyDown(KeyCode.CapsLock))
				{
					StudentManager.LoveManager.ConfessToSuitor = true;
				}
			}
			else
			{
				if (Input.GetKey(KeyCode.BackQuote))
				{
					Timer += Time.deltaTime;
					if (Timer > 1f)
					{
						for (ID = 0; ID < StudentManager.NPCsTotal; ID++)
						{
							if (StudentGlobals.GetStudentDying(ID))
							{
								StudentGlobals.SetStudentDying(ID, value: false);
							}
						}
						SceneManager.LoadScene("LoadingScene");
					}
				}
				if (Input.GetKeyUp(KeyCode.BackQuote))
				{
					Timer = 0f;
				}
			}
			if (TryNextFrame)
			{
				UpdateCensor();
			}
		}
		else
		{
			Input.GetKeyDown(KeyCode.Backslash);
		}
		if (!WaitingForNumber)
		{
			return;
		}
		if (Input.GetKey("1"))
		{
			Debug.Log("Going to class should trigger panty shot lecture.");
			if (!StudentManager.Eighties)
			{
				SchemeGlobals.SetSchemeStage(1, 100);
			}
			StudentGlobals.ExpelProgress = 0;
			Counselor.CutsceneManager.Scheme = 1;
			Counselor.LectureID = 1;
			WaitingForNumber = false;
		}
		else if (Input.GetKey("2"))
		{
			Debug.Log("Going to class should trigger theft lecture.");
			if (!StudentManager.Eighties)
			{
				SchemeGlobals.SetSchemeStage(2, 100);
			}
			StudentGlobals.ExpelProgress = 1;
			Counselor.CutsceneManager.Scheme = 2;
			Counselor.LectureID = 2;
			WaitingForNumber = false;
		}
		else if (Input.GetKey("3"))
		{
			Debug.Log("Going to class should trigger contraband lecture.");
			if (!StudentManager.Eighties)
			{
				SchemeGlobals.SetSchemeStage(3, 100);
			}
			StudentGlobals.ExpelProgress = 2;
			Counselor.CutsceneManager.Scheme = 3;
			Counselor.LectureID = 3;
			WaitingForNumber = false;
		}
		else if (Input.GetKey("4"))
		{
			Debug.Log("Going to class should trigger Vandalism lecture.");
			if (!StudentManager.Eighties)
			{
				SchemeGlobals.SetSchemeStage(4, 100);
			}
			StudentGlobals.ExpelProgress = 3;
			Counselor.CutsceneManager.Scheme = 4;
			Counselor.LectureID = 4;
			WaitingForNumber = false;
		}
		else if (Input.GetKey("5"))
		{
			Debug.Log("Going to class at lunchtime should get your rival expelled!");
			if (!StudentManager.Eighties)
			{
				SchemeGlobals.SetSchemeStage(5, 100);
			}
			StudentGlobals.ExpelProgress = 4;
			Counselor.CutsceneManager.Scheme = 5;
			Counselor.LectureID = 5;
			WaitingForNumber = false;
		}
	}

	public void Censor()
	{
		if (GameGlobals.CensorPanties)
		{
			if (Yandere.Schoolwear == 1)
			{
				if (!Yandere.Sans && !Yandere.SithLord && !Yandere.BanchoActive)
				{
					if (!Yandere.FlameDemonic && !Yandere.TornadoHair.activeInHierarchy)
					{
						Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
						Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
						Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
						Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
						if (Yandere.PantyAttacher.newRenderer != null)
						{
							Yandere.PantyAttacher.newRenderer.enabled = false;
						}
					}
					else
					{
						Debug.Log("This block of code activated a shadow.");
						Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", PantyCensorTexture);
						Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
						Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
						Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
					}
				}
				else
				{
					Yandere.PantyAttacher.newRenderer.enabled = false;
				}
			}
			if (Yandere.MiyukiCostume.activeInHierarchy || Yandere.Rain.activeInHierarchy)
			{
				Yandere.PantyAttacher.newRenderer.enabled = false;
				Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", PantyCensorTexture);
				Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", PantyCensorTexture);
				Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
				Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
				Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 1f);
			}
			if (Yandere.NierCostume.activeInHierarchy || Yandere.MyRenderer.sharedMesh == Yandere.NudeMesh || Yandere.MyRenderer.sharedMesh == Yandere.SchoolSwimsuit || Yandere.WearingRaincoat)
			{
				EasterEggCheck();
			}
			StudentManager.CensorStudents();
		}
		else
		{
			Debug.Log("The censor is OFF.");
			Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			if (Yandere.MyRenderer.sharedMesh != Yandere.NudeMesh && Yandere.MyRenderer.sharedMesh != Yandere.SchoolSwimsuit)
			{
				Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
				Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
				Yandere.PantyAttacher.newRenderer.enabled = true;
				EasterEggCheck();
			}
			else
			{
				Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
				Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
				Yandere.PantyAttacher.newRenderer.enabled = false;
				EasterEggCheck();
			}
			if (Yandere.MiyukiCostume.activeInHierarchy)
			{
				Yandere.PantyAttacher.newRenderer.enabled = false;
			}
			StudentManager.CensorStudents();
		}
	}

	public void EasterEggCheck()
	{
		Debug.Log("Checking for easter eggs.");
		if (Yandere.BanchoActive || Yandere.Sans || Yandere.RaincoatAttacher.gameObject.activeInHierarchy || Yandere.KLKSword.activeInHierarchy || Yandere.Gazing || Yandere.Ninja || Yandere.ClubAttire || Yandere.LifeNotebook.activeInHierarchy || Yandere.FalconHelmet.activeInHierarchy || Yandere.WearingRaincoat || Yandere.MyRenderer.sharedMesh == Yandere.NudeMesh || Yandere.MyRenderer.sharedMesh == Yandere.SchoolSwimsuit)
		{
			Debug.Log("A pants-wearing easter egg is active, so we're going to disable all shadows and panties.");
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
			Yandere.PantyAttacher.newRenderer.enabled = false;
		}
		if (Yandere.FlameDemonic || Yandere.TornadoHair.activeInHierarchy)
		{
			Debug.Log("This other block of code activated a shadow.");
			Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", PantyCensorTexture);
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
		}
		if (!Yandere.NierCostume.activeInHierarchy)
		{
			return;
		}
		Debug.Log("Nier costume special case.");
		Yandere.PantyAttacher.newRenderer.enabled = false;
		SkinnedMeshRenderer newRenderer = Yandere.NierCostume.GetComponent<RiggedAccessoryAttacher>().newRenderer;
		if (newRenderer == null)
		{
			TryNextFrame = true;
			return;
		}
		TryNextFrame = false;
		if (GameGlobals.CensorPanties)
		{
			newRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			newRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			newRenderer.materials[2].SetFloat("_BlendAmount", 1f);
			newRenderer.materials[3].SetFloat("_BlendAmount", 1f);
		}
		else
		{
			newRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			newRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			newRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			newRenderer.materials[3].SetFloat("_BlendAmount", 0f);
		}
	}

	public void UpdateCensor()
	{
		Censor();
		Censor();
	}

	public void DebugTest()
	{
		if (DebugInt == 0)
		{
			StudentScript obj = StudentManager.Students[39];
			obj.ShoeRemoval.Start();
			obj.ShoeRemoval.PutOnShoes();
			obj.Phase = 2;
			obj.ScheduleBlocks[2].action = "Stand";
			obj.GetDestinations();
			obj.CurrentDestination = MidoriSpot;
			obj.Pathfinding.target = MidoriSpot;
			obj.transform.position = Yandere.transform.position;
			Physics.SyncTransforms();
		}
		else if (DebugInt == 1)
		{
			Knife.transform.position = Yandere.transform.position + new Vector3(-1f, 1f, 0f);
			Knife.GetComponent<Rigidbody>().isKinematic = false;
			Knife.GetComponent<Rigidbody>().useGravity = true;
		}
		else if (DebugInt == 2)
		{
			Mop.transform.position = Yandere.transform.position + new Vector3(1f, 1f, 0f);
			Mop.GetComponent<Rigidbody>().isKinematic = false;
			Mop.GetComponent<Rigidbody>().useGravity = true;
		}
		DebugInt++;
	}
}
