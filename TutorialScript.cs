using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
	public EightiesEffectEnablerScript EightiesEffectEnabler;

	public StudentManagerScript StudentManager;

	public InputDeviceType PreviousInputDevice;

	public PostProcessingProfile Profile;

	public InputDeviceScript InputDevice;

	public WeaponMenuScript WeaponMenu;

	public PromptScript VictimPrompt;

	public UILabel InstructionLabel;

	public TallLockerScript Locker;

	public PromptScript ExitPortal;

	public DoorScript BathroomDoor;

	public RagdollScript Ragdoll;

	public YandereScript Yandere;

	public Transform BloodParent;

	public UILabel SubtitleLabel;

	public DoorScript FirstDoor;

	public Transform ExitWindow;

	public BucketScript Bucket;

	public AudioSource MyAudio;

	public WeaponScript Knife;

	public Camera MainCamera;

	public ClockScript Clock;

	public UISprite TutorialFadeOut;

	public UISprite ReputationHUD;

	public UISprite SanityHUD;

	public UISprite ClockHUD;

	public UISprite Darkness;

	public UISprite HUD;

	public string[] KeyboardInstructions;

	public string[] GamepadInstructions;

	public string[] Animations;

	public string[] Text;

	public PromptScript[] PromptsToDisable;

	public Transform[] Destination;

	public Animation[] Animator;

	public GameObject[] Blocker;

	public AudioSource[] BGM;

	public AudioClip[] Voice;

	public int[] Speaker;

	public AudioClip DramaticPianoNote;

	public AudioClip ReversePianoNote;

	public GameObject HeartbeatCamera;

	public GameObject OutOfOrderSign;

	public GameObject PauseScreen;

	public GameObject VictimGirl;

	public GameObject Jukebox;

	public GameObject FPSBG;

	public GameObject FPS;

	public bool EightiesEffectsEnabled;

	public bool TransitionToCutscene;

	public bool ReturnToTitleScreen;

	public bool FadeInstructions;

	public bool MovementProgress;

	public bool CameraProgress;

	public bool MusicSynced;

	public bool CanPickUp;

	public bool Cutscene;

	public bool Pause;

	public bool DOF;

	public int CutscenePhase;

	public int Phase;

	public float MusicTimer;

	public float SpawnTimer;

	public float Rotation = 90f;

	public float Timer;

	public float RagdollRotation;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Transform RightArm;

	public Transform RightEye;

	public Transform LeftEye;

	public float EyeShrink;

	private void Start()
	{
		if (!GameGlobals.EightiesTutorial)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		Debug.Log("The game believes that we are currently in the 1980s Mode tutorial sequence.");
		Yandere.NotificationManager.transform.localPosition = new Vector3(0f, 100f, 0f);
		Yandere.RightFootprintSpawner.MyCollider.enabled = false;
		Yandere.LeftFootprintSpawner.MyCollider.enabled = false;
		MainCamera.clearFlags = CameraClearFlags.Color;
		MainCamera.backgroundColor = new Color(1f, 1f, 1f, 1f);
		RenderSettings.fogColor = new Color(1f, 1f, 1f, 1f);
		RenderSettings.fogMode = FogMode.Exponential;
		RenderSettings.fogDensity = 0.1f;
		ExitWindow.localScale = new Vector3(0f, 0f, 0f);
		Yandere.Incinerator.CannotIncinerate = true;
		Yandere.Incinerator.enabled = false;
		Yandere.CameraEffects.EnableBloom();
		Yandere.HeartCamera.enabled = false;
		Yandere.CanMove = false;
		RightEyeOrigin = RightEye.localPosition;
		LeftEyeOrigin = LeftEye.localPosition;
		HeartbeatCamera.SetActive(value: false);
		OutOfOrderSign.SetActive(value: false);
		PauseScreen.SetActive(value: false);
		Blocker[1].SetActive(value: true);
		Blocker[2].SetActive(value: true);
		Jukebox.SetActive(value: false);
		FPSBG.SetActive(value: false);
		FPS.SetActive(value: false);
		VictimPrompt.Hide();
		VictimPrompt.enabled = false;
		VictimGirl.SetActive(value: false);
		MainCamera.farClipPlane = 50f;
		Knife.Prompt.enabled = false;
		Knife.Prompt.Hide();
		InstructionLabel.alpha = 0f;
		UpdateInstructionText();
		Clock.BloomFadeSpeed = 5f;
		Clock.StopTime = true;
		Clock.BloomWait = 1f;
		Knife.Undroppable = true;
		SubtitleLabel.text = "";
		ReputationHUD.alpha = 0f;
		SanityHUD.alpha = 0f;
		ClockHUD.alpha = 0f;
		for (int i = 1; i < PromptsToDisable.Length; i++)
		{
			PromptsToDisable[i].Hide();
			PromptsToDisable[i].enabled = false;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
		{
			TogglePauseScreen();
		}
		if (Pause)
		{
			if (Input.GetButtonDown("A"))
			{
				EightiesEffectsEnabled = !EightiesEffectsEnabled;
				OptionGlobals.DisableStatic = !EightiesEffectsEnabled;
				OptionGlobals.DisableDisplacement = !EightiesEffectsEnabled;
				OptionGlobals.DisableAbberation = !EightiesEffectsEnabled;
				OptionGlobals.DisableVignette = !EightiesEffectsEnabled;
				OptionGlobals.DisableDistortion = !EightiesEffectsEnabled;
				OptionGlobals.DisableScanlines = true;
				OptionGlobals.DisableNoise = !EightiesEffectsEnabled;
				OptionGlobals.DisableTint = !EightiesEffectsEnabled;
				EightiesEffectEnabler.UpdateEightiesEffects();
				TogglePauseScreen();
			}
			else if (Input.GetButtonDown("Y"))
			{
				Phase = 54;
				TogglePauseScreen();
				Time.timeScale = 5f;
			}
			else if (Input.GetButtonDown("X"))
			{
				ReturnToTitleScreen = true;
				Phase = 54;
				TogglePauseScreen();
				Time.timeScale = 5f;
			}
			else if (Input.GetButtonDown("B"))
			{
				TogglePauseScreen();
			}
		}
		if (!Clock.UpdateBloom)
		{
			if (!Cutscene)
			{
				if (Phase > 51 && Phase < 54)
				{
					ClockHUD.alpha = Mathf.MoveTowards(ClockHUD.alpha, 1f, Time.deltaTime);
				}
				else if (Phase > 47)
				{
					ReputationHUD.alpha = Mathf.MoveTowards(ReputationHUD.alpha, 1f, Time.deltaTime);
				}
				else if (Phase > 46)
				{
					StudentManager.Students[25].Witnessed = StudentWitnessType.Tutorial;
				}
				else if (Phase > 45)
				{
					if (StudentManager.Students[2] != null)
					{
						StudentManager.Students[2].Pathfinding.target = Destination[47];
						StudentManager.Students[2].CurrentDestination = Destination[47];
					}
				}
				else if (Phase > 44)
				{
					SanityHUD.alpha = Mathf.MoveTowards(SanityHUD.alpha, 1f, Time.deltaTime);
				}
				else if (Phase == 15 && !CanPickUp)
				{
					StudentManager.Students[2].CharacterAnimation.Play("f02_knifeStealthB_00");
					StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].time = StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].length;
				}
				if (Phase > 53)
				{
					BGM[1].volume = Mathf.MoveTowards(BGM[1].volume, 0f, Time.deltaTime * 0.2f);
				}
				else if (Phase > 52)
				{
					if (!MyAudio.isPlaying)
					{
						BGM[1].volume = Mathf.MoveTowards(BGM[1].volume, 1f, Time.deltaTime * 0.2f);
					}
					else
					{
						BGM[1].volume = Mathf.MoveTowards(BGM[1].volume, 0.5f, Time.deltaTime * 0.2f);
					}
					BGM[2].volume = Mathf.MoveTowards(BGM[2].volume, 0f, Time.deltaTime * 0.2f);
				}
				else if (Phase > 45)
				{
					if (!MyAudio.isPlaying)
					{
						BGM[2].volume = Mathf.MoveTowards(BGM[2].volume, 1f, Time.deltaTime * 0.2f);
					}
					else
					{
						BGM[2].volume = Mathf.MoveTowards(BGM[2].volume, 0.5f, Time.deltaTime * 0.2f);
					}
					BGM[3].volume = Mathf.MoveTowards(BGM[3].volume, 0f, Time.deltaTime * 0.2f);
				}
				else if (Phase > 13)
				{
					BGM[2].volume = Mathf.MoveTowards(BGM[2].volume, 0f, Time.deltaTime * 0.2f);
					if (!MyAudio.isPlaying)
					{
						BGM[3].volume = Mathf.MoveTowards(BGM[3].volume, 1f, Time.deltaTime * 0.2f);
					}
					else
					{
						BGM[3].volume = Mathf.MoveTowards(BGM[3].volume, 0.5f, Time.deltaTime * 0.2f);
					}
				}
				else if (Phase > 5)
				{
					BGM[1].volume = Mathf.MoveTowards(BGM[1].volume, 0f, Time.deltaTime * 0.2f);
					if (!MyAudio.isPlaying)
					{
						BGM[2].volume = Mathf.MoveTowards(BGM[2].volume, 1f, Time.deltaTime * 0.2f);
					}
					else
					{
						BGM[2].volume = Mathf.MoveTowards(BGM[2].volume, 0.5f, Time.deltaTime * 0.2f);
					}
				}
				else if (!MyAudio.isPlaying)
				{
					BGM[1].volume = Mathf.MoveTowards(BGM[1].volume, 1f, Time.deltaTime * 0.2f);
				}
				else
				{
					BGM[1].volume = Mathf.MoveTowards(BGM[1].volume, 0.5f, Time.deltaTime * 0.2f);
				}
				if (Yandere.Laughing)
				{
					RenderSettings.fogColor = new Color((Yandere.Sanity - 50f) / 50f, (Yandere.Sanity - 50f) / 50f, (Yandere.Sanity - 50f) / 50f, 1f);
					MainCamera.backgroundColor = RenderSettings.fogColor;
				}
				if (FadeInstructions)
				{
					InstructionLabel.alpha = Mathf.MoveTowards(InstructionLabel.alpha, 0f, Time.deltaTime * 2f);
					if (InstructionLabel.alpha == 0f)
					{
						if (!TransitionToCutscene)
						{
							FadeInstructions = false;
							Phase++;
							if (InputDevice.Type == InputDeviceType.Gamepad)
							{
								InstructionLabel.text = GamepadInstructions[Phase];
							}
							else
							{
								InstructionLabel.text = KeyboardInstructions[Phase];
							}
						}
						else
						{
							Cutscene = true;
						}
					}
				}
				else
				{
					InstructionLabel.alpha = Mathf.MoveTowards(InstructionLabel.alpha, 1f, Time.deltaTime * 2f);
					if (InstructionLabel.alpha == 1f)
					{
						if (Phase == 1)
						{
							float axis = Input.GetAxis("Vertical");
							float axis2 = Input.GetAxis("Horizontal");
							float axis3 = Input.GetAxis("Mouse X");
							float axis4 = Input.GetAxis("Mouse Y");
							if (!CameraProgress && (axis != 0f || axis2 != 0f))
							{
								CameraProgress = true;
							}
							if (!MovementProgress && (axis3 != 0f || axis4 != 0f))
							{
								MovementProgress = true;
							}
							if ((CameraProgress && MovementProgress) || Yandere.transform.position.z > -50f)
							{
								if (Vector3.Distance(Yandere.transform.position, Destination[3].position) < 1f)
								{
									Phase += 2;
								}
								FadeInstructions = true;
							}
						}
						else if (Phase == 2)
						{
							if (Input.GetButtonDown("LS") || Input.GetKeyDown("t") || Vector3.Distance(Yandere.transform.position, Destination[3].position) < 1f)
							{
								if (Vector3.Distance(Yandere.transform.position, Destination[3].position) < 1f)
								{
									Phase++;
								}
								FadeInstructions = true;
							}
						}
						else if (Phase == 3)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 1f)
							{
								Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
								FadeInstructions = true;
								Yandere.Frozen = true;
							}
						}
						else if (Phase == 4)
						{
							if (FirstDoor.Open)
							{
								FadeInstructions = true;
								Yandere.Frozen = false;
							}
						}
						else if (Phase == 5)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 0.5f)
							{
								Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
								Knife.Prompt.enabled = true;
								FadeInstructions = true;
								Yandere.Frozen = true;
							}
						}
						else if (Phase == 6)
						{
							if (Yandere.Armed || Yandere.Weapon[1] != null)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 7)
						{
							if (!Yandere.Armed)
							{
								Blocker[2].SetActive(value: false);
								Blocker[3].SetActive(value: true);
								FadeInstructions = true;
								Yandere.Frozen = false;
							}
						}
						else if (Phase == 8)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 1f)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 9)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 0.5f)
							{
								FadeInstructions = true;
								Yandere.Frozen = false;
							}
						}
						else if (Phase == 10)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 0.5f && !BathroomDoor.Open)
							{
								Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
								Yandere.RPGCamera.enabled = false;
								TransitionToCutscene = true;
								Blocker[4].SetActive(value: true);
								FadeInstructions = true;
								Yandere.CanMove = false;
							}
						}
						else if (Phase == 11)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 1f)
							{
								VictimPrompt.enabled = true;
								FadeInstructions = true;
								Yandere.Frozen = true;
							}
						}
						else if (Phase == 12)
						{
							if (VictimPrompt.Circle[0].fillAmount == 0f)
							{
								VictimPrompt.Hide();
								VictimPrompt.enabled = false;
								Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
								InstructionLabel.alpha = 0f;
								FadeInstructions = true;
								Yandere.CanMove = false;
								Cutscene = true;
								Animator[Speaker[CutscenePhase]].CrossFade(Animations[CutscenePhase]);
								SubtitleLabel.text = Text[CutscenePhase];
								MyAudio.clip = Voice[CutscenePhase];
								MyAudio.Play();
							}
						}
						else if (Phase == 13)
						{
							if (Yandere.Armed)
							{
								WeaponMenu.enabled = false;
								WeaponMenu.InstantHide();
								VictimPrompt.enabled = true;
								VictimPrompt.HideButton[0] = true;
								VictimPrompt.HideButton[2] = false;
								FadeInstructions = true;
							}
						}
						else if (Phase == 14)
						{
							if (VictimPrompt.Circle[2].fillAmount != 1f)
							{
								VictimPrompt.Hide();
								VictimPrompt.enabled = false;
								AudioSource.PlayClipAtPoint(ReversePianoNote, MainCamera.transform.position);
								Yandere.CharacterAnimation.CrossFade("f02_knifeStealthA_00");
								Animator[2].CrossFade("f02_knifeStealthB_00");
								DOF = Profile.depthOfField.enabled;
								Profile.depthOfField.enabled = false;
								Yandere.RPGCamera.enabled = false;
								InstructionLabel.alpha = 0f;
								WeaponMenu.enabled = true;
								FadeInstructions = true;
								Yandere.CanMove = false;
								Cutscene = true;
							}
						}
						else if (Phase == 15)
						{
							if (Yandere.PickUp != null && Yandere.PickUp.GarbageBagBox)
							{
								Ragdoll.Prompt.enabled = true;
								FadeInstructions = true;
							}
						}
						else if (Phase == 16)
						{
							if (Ragdoll.Concealed)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 17)
						{
							if (Yandere.PickUp == null)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 18)
						{
							if (Yandere.PickUp != null && Yandere.PickUp.Bucket != null)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 19)
						{
							if (Yandere.PickUp != null && Yandere.PickUp.Bucket != null && Yandere.PickUp.Bucket.Full)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 20)
						{
							if (Yandere.PickUp == null)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 21)
						{
							if (Yandere.PickUp != null && Yandere.PickUp.Bleach)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 22)
						{
							if (Bucket.Bleached)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 23)
						{
							if (Yandere.PickUp == null)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 24)
						{
							if (Yandere.PickUp != null && Yandere.PickUp.Mop != null)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 25)
						{
							if (Yandere.PickUp != null && Yandere.PickUp.Mop != null && Yandere.PickUp.Mop.Bleached)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 26)
						{
							if (Yandere.YandereVision)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 27)
						{
							if (BloodParent.childCount == 0)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 28)
						{
							if (Yandere.PickUp == null)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 29)
						{
							if (Yandere.Carrying)
							{
								Blocker[1].SetActive(value: false);
								Blocker[3].SetActive(value: false);
								Blocker[4].SetActive(value: false);
								FadeInstructions = true;
							}
						}
						else if (Phase == 30)
						{
							if (Yandere.Carrying && Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 0.5f)
							{
								Yandere.Incinerator.enabled = true;
								FadeInstructions = true;
								Yandere.Frozen = true;
							}
						}
						else if (Phase == 31)
						{
							if (Yandere.Dumping)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 32)
						{
							if (Yandere.Armed)
							{
								Knife.Undroppable = false;
								FadeInstructions = true;
							}
						}
						else if (Phase == 33)
						{
							if (Knife.Dumped)
							{
								FadeInstructions = true;
								Yandere.Frozen = false;
							}
						}
						else if (Phase == 34)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 1f)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 35)
						{
							if (Locker.Open)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 36)
						{
							if (Yandere.Schoolwear == 0)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 37)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 0.5f)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 38)
						{
							if (Yandere.Bloodiness == 0f)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 39)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 1f)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 40)
						{
							if (Yandere.Schoolwear == 3)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 41)
						{
							if (Yandere.PickUp != null && Yandere.PickUp.Clothing)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 42)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 0.5f)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 43)
						{
							if (Yandere.Incinerator.BloodyClothing > 0)
							{
								Yandere.Incinerator.CannotIncinerate = false;
								FadeInstructions = true;
							}
						}
						else if (Phase == 44)
						{
							if (Yandere.Incinerator.Timer > 0f)
							{
								FadeInstructions = true;
								Yandere.Frozen = true;
							}
						}
						else if (Phase == 45)
						{
							if (Input.GetButtonDown("A"))
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 46)
						{
							if (Yandere.Sanity == 100f)
							{
								if (StudentManager.Students[2] != null)
								{
									Object.Destroy(StudentManager.Students[2].gameObject);
									StudentManager.Students[2] = null;
								}
								StudentManager.ForceSpawn = true;
								StudentManager.SpawnPositions[25] = Destination[Phase + 1].transform;
								StudentManager.SpawnID = 25;
								StudentManager.SpawnStudent(25);
								StudentManager.Students[25].FocusOnYandere = true;
								StudentManager.Students[25].Blind = true;
								StudentManager.Students[25].enabled = true;
								StudentManager.Students[25].Start();
								StudentManager.Students[25].OriginalIdleAnim = "f02_idleShort_01";
								StudentManager.Students[25].IdleAnim = "f02_idleShort_01";
								StudentManager.Students[25].transform.eulerAngles = new Vector3(0f, 90f, 0f);
								StudentManager.Students[25].Indoors = true;
								StudentManager.Students[25].Spawned = true;
								if (StudentManager.Students[25].ShoeRemoval.Locker == null)
								{
									StudentManager.Students[25].ShoeRemoval.Start();
								}
								StudentManager.Students[25].ShoeRemoval.PutOnShoes();
								StudentManager.StayInOneSpot(25);
								Blocker[5].SetActive(value: true);
								FadeInstructions = true;
								Yandere.Frozen = false;
							}
						}
						else if (Phase == 47)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 4f)
							{
								StudentManager.Students[25].Witnessed = StudentWitnessType.Tutorial;
								StudentManager.Students[25].Reputation.PendingRep -= 10f;
								StudentManager.Students[25].PendingRep = -10f;
								StudentManager.Students[25].Witness = true;
								StudentManager.Students[25].Alarm = 200f;
								Yandere.CameraEffects.Alarm();
								TransitionToCutscene = true;
								FadeInstructions = true;
								Yandere.Frozen = true;
							}
						}
						else if (Phase == 48)
						{
							if (Input.GetButtonDown("A"))
							{
								FadeInstructions = true;
								Yandere.Frozen = false;
							}
						}
						else if (Phase == 49)
						{
							if (Vector3.Distance(Yandere.transform.position, Destination[Phase].position) < 1f)
							{
								StudentManager.Students[25].Prompt.HideButton[0] = false;
								StudentManager.Students[25].Witness = true;
								FadeInstructions = true;
								Yandere.Frozen = true;
							}
						}
						else if (Phase == 50)
						{
							if (Yandere.Talking)
							{
								FadeInstructions = true;
							}
						}
						else if (Phase == 51)
						{
							if (StudentManager.Students[25].Forgave && !Yandere.Talking)
							{
								StudentManager.Students[25].Reputation.PendingRep = 0f;
								Yandere.RPGCamera.enabled = false;
								MainCamera.transform.position = new Vector3(0f, 14f, -38.5666656f);
								MainCamera.transform.eulerAngles = Vector3.zero;
								StudentManager.Students[25].gameObject.SetActive(value: false);
								Blocker[5].SetActive(value: false);
								MainCamera.clearFlags = CameraClearFlags.Skybox;
								MainCamera.farClipPlane = 350f;
								RenderSettings.fog = false;
								Clock.PresentTime = 1079f;
								FadeInstructions = true;
							}
						}
						else if (Phase == 52)
						{
							if (Input.GetButtonDown("A"))
							{
								ExitPortal.gameObject.SetActive(value: true);
								Yandere.RPGCamera.enabled = true;
								FadeInstructions = true;
								Yandere.Frozen = false;
							}
						}
						else if (Phase == 53)
						{
							if (ExitPortal.Circle[0].fillAmount == 0f)
							{
								InstructionLabel.gameObject.SetActive(value: false);
								Yandere.Frozen = true;
								Phase++;
							}
						}
						else if (Phase == 54)
						{
							TutorialFadeOut.alpha = Mathf.MoveTowards(TutorialFadeOut.alpha, 1f, Time.deltaTime * 0.2f);
							if (TutorialFadeOut.alpha == 1f)
							{
								if (!ReturnToTitleScreen)
								{
									GameGlobals.EightiesTutorial = false;
									GameGlobals.EightiesCutsceneID = 1;
									OptionGlobals.Fog = false;
									SceneManager.LoadScene("EightiesCutsceneScene");
								}
								else
								{
									SceneManager.LoadScene("NewTitleScene");
								}
							}
						}
					}
				}
			}
			else
			{
				if (CutscenePhase == 0)
				{
					Yandere.MainCamera.transform.position = new Vector3(25f, 9f, -29f);
					Yandere.MainCamera.transform.eulerAngles = new Vector3(0f, 75f, 0f);
					VictimGirl.SetActive(value: true);
					Animator[2].Play("f02_walkShy_00");
					CutscenePhase++;
				}
				else if (CutscenePhase == 1)
				{
					VictimGirl.transform.position += new Vector3(Time.deltaTime, 0f, 0f);
					Animator[2].CrossFade("f02_walkShy_00");
					if (Input.GetButtonDown("A"))
					{
						VictimGirl.transform.position = new Vector3(29.5f, 8f, -28.5f);
					}
					if (VictimGirl.transform.position.x >= 29.5f)
					{
						VictimGirl.transform.position = new Vector3(29.5f, 8f, -28.5f);
						SubtitleLabel.text = Text[CutscenePhase];
						MyAudio.clip = Voice[CutscenePhase];
						MyAudio.Play();
						Animator[2].CrossFade("f02_idleShy_00");
						CutscenePhase++;
					}
				}
				else if (CutscenePhase == 2)
				{
					if (Input.GetButtonDown("A"))
					{
						MyAudio.Stop();
					}
					if (!MyAudio.isPlaying)
					{
						Yandere.RPGCamera.enabled = true;
						TransitionToCutscene = false;
						SubtitleLabel.text = "";
						Yandere.CanMove = true;
						Cutscene = false;
						CutscenePhase++;
					}
				}
				else if (CutscenePhase < 7)
				{
					if (CutscenePhase < 5)
					{
						Rotation = Mathf.Lerp(Rotation, -90f, Time.deltaTime * 5f);
						VictimGirl.transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
					}
					else
					{
						Rotation = Mathf.Lerp(Rotation, 90f, Time.deltaTime * 5f);
						VictimGirl.transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
					}
					Yandere.MoveTowardsTarget(new Vector3(28.5f, 8f, -28.5f));
					Yandere.targetRotation = Quaternion.LookRotation(VictimGirl.transform.position - Yandere.transform.position);
					Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, Yandere.targetRotation, Time.deltaTime * 10f);
					if (Input.GetButtonDown("A"))
					{
						MyAudio.Stop();
					}
					if (Animator[Speaker[CutscenePhase]][Animations[CutscenePhase]].time >= Animator[Speaker[CutscenePhase]][Animations[CutscenePhase]].length)
					{
						if (Speaker[CutscenePhase] == 1)
						{
							Animator[1].CrossFade(Yandere.IdleAnim);
						}
						else if (CutscenePhase == 5)
						{
							Animator[2].CrossFade("f02_idleShame_00");
						}
						else
						{
							Animator[2].CrossFade("f02_idleShy_00");
						}
					}
					if (!MyAudio.isPlaying)
					{
						CutscenePhase++;
						if (CutscenePhase < 7)
						{
							Animator[1].CrossFade(Yandere.IdleAnim);
							Animator[2].CrossFade("f02_idleShy_00");
							Animator[Speaker[CutscenePhase]].CrossFade(Animations[CutscenePhase]);
							SubtitleLabel.text = Text[CutscenePhase];
							MyAudio.clip = Voice[CutscenePhase];
							MyAudio.Play();
						}
					}
				}
				else if (CutscenePhase == 7)
				{
					TransitionToCutscene = false;
					SubtitleLabel.text = "";
					Yandere.CanMove = true;
					Cutscene = false;
					CutscenePhase++;
				}
				else if (CutscenePhase == 8)
				{
					BGM[2].volume = Mathf.MoveTowards(BGM[2].volume, 0f, Time.deltaTime * 0.2f);
					BGM[3].volume = Mathf.MoveTowards(BGM[3].volume, 0f, Time.deltaTime * 0.2f);
					Yandere.MainCamera.transform.position = new Vector3(30f, 9.366666f, -28.5f);
					Yandere.MainCamera.transform.eulerAngles = new Vector3(0f, -90f, 0f);
					VictimGirl.transform.eulerAngles = new Vector3(0f, 90f, 0f);
					VictimGirl.transform.position = new Vector3(29.5f, 8f, -28.5f);
					Yandere.transform.position = new Vector3(28.82f, 8f, -28.5f);
					Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
					Yandere.CharacterAnimation["f02_knifeStealthA_00"].speed = Mathf.MoveTowards(Yandere.CharacterAnimation["f02_knifeStealthA_00"].speed, 0.1f, Time.deltaTime);
					Animator[2]["f02_knifeStealthB_00"].speed = Mathf.MoveTowards(Animator[2]["f02_knifeStealthB_00"].speed, 0.1f, Time.deltaTime);
					if (Yandere.CharacterAnimation["f02_knifeStealthA_00"].time > 0.5f)
					{
						EyeShrink = Mathf.MoveTowards(EyeShrink, 1f, Time.deltaTime);
					}
					if (Yandere.CharacterAnimation["f02_knifeStealthA_00"].time > Yandere.CharacterAnimation["f02_knifeStealthA_00"].length * 0.475f)
					{
						Yandere.RPGCamera.mouseX = 45f;
						Yandere.RPGCamera.mouseY = 45f;
						Yandere.RPGCamera.mouseXSmooth = -315f;
						Yandere.RPGCamera.mouseYSmooth = -315f;
						Yandere.RPGCamera.GetDesiredPosition();
						Yandere.RPGCamera.PositionUpdate();
						SubtitleLabel.text = Text[CutscenePhase];
						MyAudio.clip = Voice[CutscenePhase];
						MyAudio.Play();
						BGM[2].volume = 0f;
						BGM[3].volume = 0f;
						Darkness.alpha = 1f;
						CutscenePhase++;
					}
				}
				else if (CutscenePhase == 9)
				{
					if (StudentManager.Students[2] == null)
					{
						StudentManager.ForceSpawn = true;
						StudentManager.SpawnPositions[2] = VictimGirl.transform;
						StudentManager.SpawnID = 2;
						StudentManager.SpawnStudent(2);
					}
					else if (!StudentManager.Students[2].Ragdoll.enabled)
					{
						StudentManager.Students[2].CharacterAnimation.Play("f02_knifeStealthB_00");
						StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].time = StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].length;
						StudentManager.Students[2].transform.position = new Vector3(29.9f, 8f, -29.4f);
						StudentManager.Students[2].transform.eulerAngles = new Vector3(0f, -90f, 0f);
						StudentManager.Students[2].BecomeRagdoll();
						StudentManager.Students[2].Cosmetic.FemaleHair[StudentManager.Students[2].Cosmetic.Hairstyle].SetActive(value: false);
						StudentManager.Students[2].Cosmetic.HairRenderer = StudentManager.Students[2].Cosmetic.FemaleHairRenderers[57];
						StudentManager.Students[2].Cosmetic.FemaleHair[57].SetActive(value: true);
						StudentManager.Students[2].Cosmetic.Hairstyle = 57;
						Ragdoll = StudentManager.Students[2].Ragdoll;
					}
					if (MyAudio.time > MyAudio.clip.length - 0.2f)
					{
						Yandere.RPGCamera.enabled = true;
					}
					if (!MyAudio.isPlaying)
					{
						AudioSource.PlayClipAtPoint(DramaticPianoNote, MainCamera.transform.position);
						MainCamera.backgroundColor = new Color(0f, 0f, 0f, 1f);
						RenderSettings.fogColor = new Color(0f, 0f, 0f, 1f);
						BGM[3].volume = 0.5f;
						Knife.Blood.enabled = true;
						Knife.MurderWeapon = true;
						Knife.Bloody = true;
						Yandere.Bloodiness += 100f;
						Yandere.Sanity -= 50f;
						StudentManager.Students[2].CharacterAnimation.enabled = true;
						StudentManager.Students[2].CharacterAnimation.Play("f02_knifeStealthB_00");
						StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].time = StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].length;
						Profile.depthOfField.enabled = DOF;
						TransitionToCutscene = false;
						VictimGirl.SetActive(value: false);
						SubtitleLabel.text = "";
						Yandere.Frozen = false;
						Yandere.CanMove = true;
						Darkness.alpha = 0f;
						CanPickUp = true;
						Cutscene = false;
						CutscenePhase++;
					}
				}
				else if (CutscenePhase == 10 && StudentManager.Students[25].Routine)
				{
					TransitionToCutscene = false;
					Yandere.Frozen = true;
					Cutscene = false;
					CutscenePhase++;
				}
				if (BGM[1].volume > 0f)
				{
					BGM[1].volume = Mathf.MoveTowards(BGM[1].volume, 0.5f, Time.deltaTime);
				}
				else if (BGM[2].volume > 0f)
				{
					BGM[2].volume = Mathf.MoveTowards(BGM[2].volume, 0.5f, Time.deltaTime);
				}
				else if (BGM[3].volume > 0f)
				{
					BGM[3].volume = Mathf.MoveTowards(BGM[3].volume, 0.5f, Time.deltaTime);
				}
			}
		}
		else if (!MusicSynced)
		{
			MusicTimer += Time.deltaTime;
			if (MusicTimer > 1f)
			{
				BGM[1].time = 0f;
				BGM[2].time = 0f;
				BGM[3].time = 0f;
				BGM[1].Play();
				BGM[2].Play();
				BGM[3].Play();
				MusicSynced = true;
			}
		}
		else
		{
			BGM[1].volume = Mathf.MoveTowards(BGM[1].volume, 1f, Time.deltaTime * 0.2f);
		}
		if (InputDevice.Type != PreviousInputDevice)
		{
			UpdateInstructionText();
		}
	}

	private void UpdateInstructionText()
	{
		PreviousInputDevice = InputDevice.Type;
		if (InputDevice.Type == InputDeviceType.Gamepad)
		{
			InstructionLabel.text = GamepadInstructions[Phase];
		}
		else
		{
			InstructionLabel.text = KeyboardInstructions[Phase];
		}
	}

	private void LateUpdate()
	{
		if (EyeShrink > 0f)
		{
			LeftEye.localPosition = new Vector3(LeftEye.localPosition.x, LeftEye.localPosition.y, LeftEyeOrigin.z - EyeShrink * 0.01f);
			RightEye.localPosition = new Vector3(RightEye.localPosition.x, RightEye.localPosition.y, RightEyeOrigin.z + EyeShrink * 0.01f);
			LeftEye.localScale = new Vector3(1f - EyeShrink * 0.5f, 1f - EyeShrink * 0.5f, LeftEye.localScale.z);
			RightEye.localScale = new Vector3(1f - EyeShrink * 0.5f, 1f - EyeShrink * 0.5f, RightEye.localScale.z);
		}
		if (CutscenePhase == 8)
		{
			RightArm.localEulerAngles += new Vector3(15f, 0f, 0f);
		}
	}

	public void TogglePauseScreen()
	{
		Pause = !Pause;
		if (Pause)
		{
			Time.timeScale = 0f;
			ExitWindow.localScale = new Vector3(1f, 1f, 1f);
		}
		else
		{
			Time.timeScale = 1f;
			ExitWindow.localScale = new Vector3(0f, 0f, 0f);
		}
	}
}
