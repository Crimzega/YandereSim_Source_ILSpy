using System;
using RetroAesthetics;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class NewTitleScreenScript : MonoBehaviour
{
	public CameraFilterPack_TV_Vignetting Vignette;

	public SelectiveGrayscale Grayscale;

	public TitleScreenOsanaScript Osana;

	public TitleDemoChecklistScript TitleDemoChecklist;

	public TitleSaveFilesScript TitleSaveFiles;

	public InputManagerScript InputManager;

	public TitleSponsorScript TitleSponsor;

	public NewSettingsScript NewSettings;

	public InputDeviceScript InputDevice;

	public PromptBarScript PromptBar;

	public PostProcessingProfile Profile;

	public Animation YandereAnimation;

	public GameObject CongratulationsWindow;

	public GameObject BloodProjector;

	public GameObject LoveLetter;

	public GameObject Knife;

	public AudioSource[] FountainSFX;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public AudioClip SpookyEightiesMusic;

	public AudioClip SpookyMusic;

	public Transform LookAtTarget;

	public UIPanel TitleScreenPanel;

	public UISprite EightiesWindow;

	public UISprite DemoWindow;

	public UISprite DemoChecklist;

	public UISprite ModeSelection;

	public UISprite CheatEntry;

	public UISprite SaveFiles;

	public UISprite Darkness;

	public UISprite Settings;

	public UISprite Sponsors;

	public UISprite Cursor;

	public UILabel[] Questions;

	public UILabel ExtrasLabel;

	public UILabel CheatLabel;

	public UILabel PressStart;

	public UILabel DebugLog;

	public AudioClip Whoosh;

	public float BloomIntensity = 40f;

	public float SpeedUpFactor = 1f;

	public float BloomRadius = 7f;

	public float DepthFocus = 2f;

	public float Speed = 1f;

	public float DebugTimer;

	public int CurrentQuestion = 1;

	public int PositionX;

	public int Selection = 1;

	public int Options = 7;

	public int Phase = 1;

	public int Log;

	public bool FadeQuestion;

	public bool QuickStart;

	public bool Eighties;

	public bool ForVideo;

	public bool FadeOut;

	public AudioClip MakeSelection;

	public AudioClip MoveCursor;

	public RetroCameraEffect EightiesEffects;

	public NormalBufferView VaporwaveVisuals;

	public AudioSource EightiesJukebox;

	public AudioSource CurrentJukebox;

	public Material VaporwaveSkybox;

	public UILabel MissionModeLabel;

	public UITexture EightiesLogo;

	public GameObject HeartPanel;

	public GameObject PalmTrees;

	public GameObject DemoText;

	public GameObject Trees;

	public GameObject AyanoHair;

	public GameObject RyobaHair;

	public GameObject EightiesFilter;

	public GameObject NormalLogo;

	public Material NormalSkybox;

	public Font Futura;

	public Font VCR;

	public string[] EightiesRivalNames;

	public string[] RivalNames;

	private void Start()
	{
		MissionModeGlobals.MissionMode = false;
		Eighties = GameGlobals.Eighties;
		Time.timeScale = 1f;
		YandereAnimation["f02_idleCouncilStrict_00"].speed = 0.5f;
		base.transform.position = new Vector3(0f, 0.5f, -18f);
		base.transform.eulerAngles = new Vector3(-15f, 0f, 0f);
		LookAtTarget.position = new Vector3(0f, 5.055138f, 0f);
		UpdateBloom(BloomIntensity, BloomRadius);
		UpdateDOF(DepthFocus);
		ResetVignette();
		ModeSelection.alpha = 0f;
		DemoChecklist.alpha = 0f;
		CheatEntry.alpha = 0f;
		PressStart.alpha = 0f;
		SaveFiles.alpha = 0f;
		Settings.alpha = 0f;
		Sponsors.alpha = 0f;
		Cursor.alpha = 0f;
		Profile.colorGrading.enabled = false;
		BloodProjector.SetActive(value: false);
		LoveLetter.SetActive(value: true);
		Knife.SetActive(value: false);
		if (PlayerGlobals.Kills > 0 || (GameGlobals.RivalEliminationID > 0 && !GameGlobals.NonlethalElimination))
		{
			BloodProjector.SetActive(value: true);
			LoveLetter.SetActive(value: false);
			Knife.SetActive(value: true);
		}
		if (Eighties)
		{
			EnableEightiesEffects();
		}
		else
		{
			DisableEightiesEffects();
		}
		if (SchoolGlobals.SchoolAtmosphereSet && SchoolGlobals.SchoolAtmosphere < 0.5f)
		{
			EightiesJukebox.clip = SpookyEightiesMusic;
			Jukebox.clip = SpookyMusic;
			EightiesJukebox.Play();
			Jukebox.Play();
			Grayscale.enabled = true;
			Vignette.enabled = true;
		}
		if (OptionGlobals.DrawDistance == 0)
		{
			OptionGlobals.DrawDistanceLimit = 350;
			OptionGlobals.DrawDistance = 350;
		}
		NewSettings.UpdateGraphics();
		GameGlobals.TransitionToPostCredits = false;
		GameGlobals.DarkEnding = false;
		GameGlobals.Debug = false;
		if (DateGlobals.Week == 2 && !GameGlobals.PlayerHasBeatenDemo && !Eighties)
		{
			CongratulationsWindow.SetActive(value: true);
			GameGlobals.PlayerHasBeatenDemo = true;
			PlayerPrefs.SetInt("UnlockedDebugMode", 1);
		}
		if (PlayerPrefs.GetInt("UnlockedDebugMode") == 1)
		{
			ExtrasLabel.alpha = 1f;
		}
		if (Eighties)
		{
			ExtrasLabel.alpha = 0.5f;
		}
		EightiesLogo.alpha = 0f;
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			if (Input.GetKeyDown("-"))
			{
				Time.timeScale -= 1f;
			}
			if (Input.GetKeyDown("="))
			{
				Time.timeScale += 1f;
			}
			DebugTimer += Time.deltaTime;
			if (DebugTimer > 100f)
			{
				DateGlobals.Week = 2;
				GameGlobals.RivalEliminationID = 1;
				GameGlobals.NonlethalElimination = false;
				SceneManager.LoadScene("NewTitleScene");
			}
		}
		if (Log == 0)
		{
			if (Input.GetKeyDown("l"))
			{
				Log++;
			}
		}
		else if (Log == 1)
		{
			if (Input.GetKeyDown("o"))
			{
				Log++;
			}
		}
		else if (Log == 2)
		{
			if (Input.GetKeyDown("g"))
			{
				DebugLog.gameObject.SetActive(value: true);
				Log++;
			}
		}
		else if (Log == 3)
		{
			DebugLog.text = "GameGlobals.Debug is: " + GameGlobals.Debug + " and QuickStart is: " + QuickStart;
		}
		if (Input.GetKeyDown("m"))
		{
			CurrentJukebox.volume = 0f;
		}
		Cursor.transform.parent.Rotate(new Vector3(Time.deltaTime * 100f, 0f, 0f), Space.Self);
		if (Phase != 2)
		{
			Cursor.alpha = Mathf.MoveTowards(Cursor.alpha, 0f, Time.deltaTime);
		}
		Cursor.transform.parent.localPosition = Vector3.Lerp(Cursor.transform.parent.localPosition, new Vector3(PositionX, 300f - 75f * (float)Selection, Cursor.transform.parent.localPosition.z), Time.deltaTime * 10f);
		if (!FadeOut)
		{
			if (InputDevice.Type == InputDeviceType.Gamepad)
			{
				PressStart.text = "PRESS START";
			}
			else
			{
				PressStart.text = "PRESS ENTER";
			}
			if (Phase < 2)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 0.5f, -17f), Time.deltaTime * 0.5f * SpeedUpFactor);
				EightiesLogo.alpha = Mathf.MoveTowards(EightiesLogo.alpha, 1f, Time.deltaTime * 0.2f);
				BloomIntensity = Mathf.Lerp(BloomIntensity, 1f, Time.deltaTime * Speed);
				BloomRadius = Mathf.Lerp(BloomRadius, 4f, Time.deltaTime * Speed);
				UpdateBloom(BloomIntensity, BloomRadius);
				UpdateDOF(2f);
			}
			if (Phase == 0)
			{
				if (Input.anyKeyDown)
				{
					Speed += 1f;
				}
				if (BloomIntensity < 1.1f)
				{
					if (CongratulationsWindow.activeInHierarchy)
					{
						if (!PromptBar.Show)
						{
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Cool, thanks bro!";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						if (Input.GetButtonDown("A"))
						{
							CongratulationsWindow.SetActive(value: false);
							PromptBar.Show = false;
						}
					}
					else
					{
						PressStart.alpha = Mathf.MoveTowards(PressStart.alpha, 1f, Time.deltaTime);
						if (Input.GetButtonDown("Start"))
						{
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Confirm";
							PromptBar.Label[5].text = "Change Selection";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							Speed = 0f;
							Phase++;
						}
					}
				}
			}
			else if (Phase == 1)
			{
				LookAtTarget.position = Vector3.Lerp(LookAtTarget.position, new Vector3(0f, 5.055138f, 0f), Time.deltaTime);
				ModeSelection.alpha = Mathf.MoveTowards(ModeSelection.alpha, 1f, Time.deltaTime);
				PressStart.alpha = Mathf.MoveTowards(PressStart.alpha, 0f, Time.deltaTime);
				if (Eighties)
				{
					EightiesWindow.alpha = Mathf.MoveTowards(EightiesWindow.alpha, 1f, Time.deltaTime * 10f);
					DemoWindow.alpha = Mathf.MoveTowards(DemoWindow.alpha, 0.25f, Time.deltaTime * 10f);
				}
				else
				{
					EightiesWindow.alpha = Mathf.MoveTowards(EightiesWindow.alpha, 0.25f, Time.deltaTime * 10f);
					DemoWindow.alpha = Mathf.MoveTowards(DemoWindow.alpha, 1f, Time.deltaTime * 10f);
				}
				if (ModeSelection.alpha == 1f && LookAtTarget.position.y > 3f)
				{
					if (InputManager.TappedLeft || InputManager.TappedRight)
					{
						Eighties = !Eighties;
						GameGlobals.Eighties = Eighties;
						if (Eighties)
						{
							EnableEightiesEffects();
						}
						else
						{
							DisableEightiesEffects();
						}
					}
					if (Input.GetButtonDown("A"))
					{
						PromptBar.Label[0].text = "Make Selection";
						PromptBar.Label[1].text = "Back";
						PromptBar.Label[4].text = "Change Selection";
						PromptBar.Label[5].text = "";
						PromptBar.UpdateButtons();
						MyAudio.clip = Whoosh;
						MyAudio.pitch = 0.5f;
						MyAudio.volume = 1f;
						MyAudio.Play();
						Speed = 0f;
						Phase = 2;
					}
				}
			}
			else if (Phase == 2)
			{
				Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-0.666666f, 1.195f, -2.9f), Time.deltaTime * Speed);
				LookAtTarget.position = Vector3.Lerp(LookAtTarget.position, new Vector3(0f, 1.195f, -2.263333f), Time.deltaTime * Speed);
				DepthFocus = Mathf.Lerp(DepthFocus, 1f, Time.deltaTime * Speed);
				UpdateDOF(DepthFocus);
				Settings.alpha = Mathf.MoveTowards(Settings.alpha, 0f, Time.deltaTime);
				Sponsors.alpha = Mathf.MoveTowards(Sponsors.alpha, 0f, Time.deltaTime);
				SaveFiles.alpha = Mathf.MoveTowards(SaveFiles.alpha, 0f, Time.deltaTime);
				CheatEntry.alpha = Mathf.MoveTowards(CheatEntry.alpha, 0f, Time.deltaTime);
				DemoChecklist.alpha = Mathf.MoveTowards(DemoChecklist.alpha, 0f, Time.deltaTime);
				if (Speed > 3f)
				{
					Cursor.alpha = Mathf.MoveTowards(Cursor.alpha, 1f, Time.deltaTime);
					if (Cursor.alpha == 1f)
					{
						if (!PromptBar.Show && !ForVideo)
						{
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Make Selection";
							PromptBar.Label[1].text = "Back";
							PromptBar.Label[4].text = "Change Selection";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						if (InputManager.TappedDown)
						{
							Selection++;
							UpdateCursor();
						}
						if (InputManager.TappedUp)
						{
							Selection--;
							UpdateCursor();
						}
						if (Input.GetButtonDown("A"))
						{
							if (ForVideo)
							{
								Phase = 7;
							}
							else
							{
								PromptBar.Show = false;
								if (Selection == 1)
								{
									TitleSaveFiles.enabled = true;
									Speed = 0f;
									Phase = 3;
								}
								else if (Selection == 2)
								{
									TitleDemoChecklist.enabled = true;
									Speed = 0f;
									Phase = 4;
								}
								else if (Selection == 4)
								{
									TitleSponsor.enabled = true;
									Speed = 0f;
									Phase = 5;
								}
								else if (Selection == 5)
								{
									NewSettings.enabled = true;
									NewSettings.Cursor.alpha = 0f;
									NewSettings.Selection = 1;
									Speed = 0f;
									Phase = 6;
								}
								else if (Selection == 7)
								{
									if (ExtrasLabel.alpha == 1f)
									{
										Speed = 0f;
										Phase = 7;
									}
									else
									{
										PromptBar.Show = true;
									}
								}
								else if ((Selection == 3 && !Eighties) || Selection == 6 || Selection == 8)
								{
									FadeOut = true;
								}
								MyAudio.clip = MakeSelection;
								MyAudio.volume = 0.5f;
								MyAudio.pitch = 1f;
								MyAudio.Play();
							}
						}
						else if (Input.GetButtonDown("B"))
						{
							PromptBar.Label[1].text = "";
							PromptBar.Label[4].text = "";
							PromptBar.Label[5].text = "Change Selection";
							PromptBar.UpdateButtons();
							SpeedUpFactor = 10f;
							Speed = 0f;
							Phase = 1;
						}
					}
				}
			}
			else if (Phase == 3)
			{
				Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0.125f, 0.875f, -2.66666f), Time.deltaTime * Speed);
				LookAtTarget.position = Vector3.Lerp(LookAtTarget.position, new Vector3(0.1f, 0.875f, 0f), Time.deltaTime * Speed);
				SaveFiles.alpha = Mathf.MoveTowards(SaveFiles.alpha, 1f, Time.deltaTime);
				DepthFocus = Mathf.Lerp(DepthFocus, 0.225f, Time.deltaTime * Speed);
				UpdateDOF(DepthFocus);
			}
			else if (Phase == 4)
			{
				Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 29.5f, 0f), Time.deltaTime * Speed);
				LookAtTarget.position = Vector3.Lerp(LookAtTarget.position, new Vector3(0f, 0f, 0.1f), Time.deltaTime * Speed);
				DemoChecklist.alpha = Mathf.MoveTowards(DemoChecklist.alpha, 1f, Time.deltaTime);
				DepthFocus = Mathf.Lerp(DepthFocus, 2f, Time.deltaTime * Speed);
				UpdateDOF(DepthFocus);
			}
			else if (Phase == 5)
			{
				Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 0.66f, -1.6f), Time.deltaTime * Speed);
				LookAtTarget.position = Vector3.Lerp(LookAtTarget.position, new Vector3(0f, 0.66f, 0f), Time.deltaTime * Speed);
				Sponsors.alpha = Mathf.MoveTowards(Sponsors.alpha, 1f, Time.deltaTime);
				DepthFocus = Mathf.Lerp(DepthFocus, 1f, Time.deltaTime * Speed);
				UpdateDOF(DepthFocus);
			}
			else if (Phase == 6)
			{
				Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 0.85f, -4f), Time.deltaTime * Speed);
				LookAtTarget.position = Vector3.Lerp(LookAtTarget.position, new Vector3(0f, 0.85f, 0f), Time.deltaTime * Speed);
				Settings.alpha = Mathf.MoveTowards(Settings.alpha, 1f, Time.deltaTime);
				DepthFocus = Mathf.Lerp(DepthFocus, 2f, Time.deltaTime * Speed);
				UpdateDOF(DepthFocus);
			}
			else if (Phase == 7)
			{
				Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 2.4f, -0.5f), Time.deltaTime * Speed);
				LookAtTarget.position = Vector3.Lerp(LookAtTarget.position, new Vector3(0f, 2.4f, 0f), Time.deltaTime * Speed);
				DepthFocus = Mathf.Lerp(DepthFocus, 0.5f, Time.deltaTime * Speed);
				UpdateDOF(DepthFocus);
				CheatEntry.alpha = Mathf.MoveTowards(CheatEntry.alpha, 1f, Time.deltaTime);
				if (Speed > 3f)
				{
					if (!PromptBar.Show)
					{
						PromptBar.ClearButtons();
						PromptBar.Label[1].text = "Go Back";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
					}
					if (Input.GetKeyDown(KeyCode.Return))
					{
						if (CheatLabel.text == "debug" || CheatLabel.text == "Debug")
						{
							CheatLabel.text = "Cheat Enabled!";
							GameGlobals.Debug = true;
						}
						else if (CheatLabel.text == "Nice Boat")
						{
							CheatLabel.text = "Awwwww, you remembered!";
						}
					}
					if (Input.GetButtonDown("B"))
					{
						PromptBar.Show = false;
						Speed = 0f;
						Phase = 2;
					}
				}
			}
			else if (Phase == 8)
			{
				if (TitleScreenPanel.alpha > 0f)
				{
					TitleScreenPanel.alpha = Mathf.MoveTowards(TitleScreenPanel.alpha, 0f, Time.deltaTime * 2f);
				}
				else if (!FadeQuestion)
				{
					Questions[CurrentQuestion].alpha = Mathf.MoveTowards(Questions[CurrentQuestion].alpha, 1f, Time.deltaTime * 2f);
					if (Input.GetButtonDown("A"))
					{
						FadeQuestion = true;
					}
				}
				else
				{
					Questions[CurrentQuestion].alpha = Mathf.MoveTowards(Questions[CurrentQuestion].alpha, 0f, Time.deltaTime * 2f);
					if (Questions[CurrentQuestion].alpha == 0f)
					{
						FadeQuestion = false;
						CurrentQuestion++;
					}
				}
			}
		}
		else
		{
			PromptBar.Show = false;
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime * 0.5f);
			CurrentJukebox.volume = Mathf.MoveTowards(CurrentJukebox.volume, 0f, Time.deltaTime * 0.5f);
			FountainSFX[1].volume = Mathf.MoveTowards(FountainSFX[1].volume, 0f, Time.deltaTime * 0.5f);
			FountainSFX[2].volume = Mathf.MoveTowards(FountainSFX[2].volume, 0f, Time.deltaTime * 0.5f);
			if (Darkness.alpha == 1f)
			{
				if (Selection == 1)
				{
					if (PlayerPrefs.GetInt("ProfileCreated_" + GameGlobals.Profile) == 0)
					{
						PlayerPrefs.SetInt("ProfileCreated_" + GameGlobals.Profile, 1);
						OptionGlobals.EnableShadows = false;
						PlayerGlobals.Money = 10f;
						DateGlobals.Weekday = DayOfWeek.Sunday;
						DateGlobals.PassDays = 1;
						UpdateDOF(2f);
						if (!QuickStart)
						{
							if (Eighties)
							{
								SceneManager.LoadScene("EightiesCutsceneScene");
								GameGlobals.EightiesTutorial = true;
								GameGlobals.Eighties = true;
								for (int i = 1; i < 101; i++)
								{
									StudentGlobals.SetStudentPhotographed(i, value: true);
								}
								StudentGlobals.FemaleUniform = 6;
								StudentGlobals.MaleUniform = 1;
								OptionGlobals.DisableTint = false;
								DateGlobals.Weekday = DayOfWeek.Saturday;
							}
							else
							{
								StudentGlobals.FemaleUniform = 1;
								StudentGlobals.MaleUniform = 1;
								OptionGlobals.DisableTint = true;
								SceneManager.LoadScene("SenpaiScene");
							}
						}
						else
						{
							SceneManager.LoadScene("CalendarScene");
						}
					}
					else if (!GameGlobals.EightiesTutorial)
					{
						if (DateGlobals.Week < 11)
						{
							SceneManager.LoadScene("CalendarScene");
						}
						else
						{
							SceneManager.LoadScene("LoadingScene");
						}
					}
					else
					{
						SceneManager.LoadScene("EightiesCutsceneScene");
					}
				}
				else if (Selection == 3)
				{
					SceneManager.LoadScene("MissionModeScene");
				}
				else if (Selection == 6)
				{
					SceneManager.LoadScene("CreditsScene");
				}
				else if (Selection == 8)
				{
					Application.Quit();
				}
			}
		}
		base.transform.LookAt(LookAtTarget);
	}

	private void UpdateBloom(float Intensity, float Radius)
	{
		BloomModel.Settings settings = Profile.bloom.settings;
		settings.bloom.intensity = Intensity;
		settings.bloom.radius = Radius;
		settings.bloom.softKnee = 1f;
		Profile.bloom.settings = settings;
		settings.bloom.softKnee = 1f;
	}

	private void UpdateDOF(float Focus)
	{
		Focus *= ((float)Screen.width / 1280f + (float)Screen.height / 720f) * 0.5f;
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		Profile.depthOfField.settings = settings;
	}

	private void ResetVignette()
	{
		VignetteModel.Settings settings = Profile.vignette.settings;
		settings.color = new Color(1f, 0.75f, 1f);
		ChromaticAberrationModel.Settings settings2 = Profile.chromaticAberration.settings;
		settings2.intensity = 0.1f;
		Profile.vignette.settings = settings;
		Profile.chromaticAberration.settings = settings2;
	}

	private void UpdateCursor()
	{
		if (Selection > Options)
		{
			Selection = 1;
		}
		else if (Selection < 1)
		{
			Selection = Options;
		}
		if (Selection == 1)
		{
			PositionX = 0;
		}
		else if (Selection == 2)
		{
			PositionX = 20;
		}
		else
		{
			PositionX = 40 + Selection * 10;
		}
		MyAudio.clip = MoveCursor;
		MyAudio.volume = 0.5f;
		MyAudio.pitch = 1f;
		MyAudio.Play();
	}

	private void EnableEightiesEffects()
	{
		GameObjectUtils.SetLayerRecursively(EightiesLogo.transform.parent.gameObject, 5);
		RenderSettings.skybox = VaporwaveSkybox;
		VaporwaveVisuals.ApplyNormalView();
		EightiesEffects.enabled = true;
		CurrentJukebox = EightiesJukebox;
		EightiesJukebox.volume = 0.5f;
		Jukebox.volume = 0f;
		MissionModeLabel.alpha = 0.5f;
		ExtrasLabel.alpha = 0.5f;
		TitleSaveFiles.EightiesPrefix = 10;
		TitleSaveFiles.SaveDatas[1].ID = 11;
		TitleSaveFiles.SaveDatas[2].ID = 12;
		TitleSaveFiles.SaveDatas[3].ID = 13;
		TitleSaveFiles.SaveDatas[1].Start();
		TitleSaveFiles.SaveDatas[2].Start();
		TitleSaveFiles.SaveDatas[3].Start();
		EightiesLogo.gameObject.SetActive(value: true);
		NormalLogo.SetActive(value: false);
		HeartPanel.SetActive(value: true);
		DemoText.SetActive(value: false);
		AyanoHair.SetActive(value: false);
		RyobaHair.SetActive(value: true);
		EightiesFilter.SetActive(value: true);
		PalmTrees.SetActive(value: true);
		Trees.SetActive(value: false);
		ChangeTextOutline();
		GameGlobals.Eighties = true;
		PressStart.trueTypeFont = VCR;
	}

	private void DisableEightiesEffects()
	{
		GameObjectUtils.SetLayerRecursively(EightiesLogo.transform.parent.gameObject, 0);
		RenderSettings.skybox = NormalSkybox;
		VaporwaveVisuals.DisableNormalView();
		EightiesEffects.enabled = false;
		CurrentJukebox = Jukebox;
		EightiesJukebox.volume = 0f;
		Jukebox.volume = 0.5f;
		MissionModeLabel.alpha = 1f;
		ExtrasLabel.alpha = 1f;
		TitleSaveFiles.EightiesPrefix = 0;
		TitleSaveFiles.SaveDatas[1].ID = 1;
		TitleSaveFiles.SaveDatas[2].ID = 2;
		TitleSaveFiles.SaveDatas[3].ID = 3;
		TitleSaveFiles.SaveDatas[1].Start();
		TitleSaveFiles.SaveDatas[2].Start();
		TitleSaveFiles.SaveDatas[3].Start();
		EightiesLogo.gameObject.SetActive(value: false);
		HeartPanel.SetActive(value: false);
		NormalLogo.SetActive(value: true);
		DemoText.SetActive(value: true);
		AyanoHair.SetActive(value: true);
		RyobaHair.SetActive(value: false);
		EightiesFilter.SetActive(value: false);
		PalmTrees.SetActive(value: false);
		Trees.SetActive(value: true);
		ChangeTextOutline();
		GameGlobals.Eighties = false;
		Debug.Log("DisableEightiesEffects() was just called. GameGlobals.Eighties is: " + GameGlobals.Eighties);
	}

	private void ChangeTextOutline()
	{
		UILabel[] array = UnityEngine.Object.FindObjectsOfType<UILabel>();
		foreach (UILabel uILabel in array)
		{
			if (Eighties)
			{
				uILabel.effectColor = new Color(0f, 0f, 0f);
			}
			else
			{
				uILabel.effectColor = new Color(1f, 0.5f, 1f);
			}
		}
	}
}
