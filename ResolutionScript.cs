using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class ResolutionScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PostProcessingProfile Profile;

	public UILabel ResolutionLabel;

	public UILabel FullScreenLabel;

	public UILabel QualityLabel;

	public Transform Highlight;

	public UISprite Darkness;

	public float Alpha = 1f;

	public bool FullScreen;

	public bool FadeOut;

	public string[] Qualities;

	public int[] Widths;

	public int[] Heights;

	public int QualityID;

	public int ResID = 1;

	public int ID = 1;

	private void Start()
	{
		if (Screen.width < 664 || Screen.height < 664)
		{
			Screen.SetResolution(1280, 720, fullscreen: false);
		}
		Darkness.color = new Color(1f, 1f, 1f, 1f);
		Cursor.visible = false;
		Screen.fullScreen = false;
		Screen.SetResolution(Screen.width, Screen.height, fullscreen: false);
		ResolutionLabel.text = Screen.width + " x " + Screen.height;
		QualityLabel.text = Qualities[QualitySettings.GetQualityLevel()] ?? "";
		FullScreenLabel.text = "No";
		Debug.Log("The quality level is set to: " + QualitySettings.GetQualityLevel());
		Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
		ResetGraphicsToDefault();
	}

	private void Update()
	{
		if (Screen.width < 664 || Screen.height < 664)
		{
			Screen.SetResolution(1280, 720, fullscreen: false);
		}
		if (FadeOut)
		{
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime);
			if (Alpha == 1f)
			{
				Debug.Log("Finished setting the resolution. Sending the player to the welcome screen.");
				SceneManager.LoadScene("WelcomeScene");
			}
		}
		else
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
		}
		Darkness.color = new Color(1f, 1f, 1f, Alpha);
		if (Alpha == 0f)
		{
			if (InputManager.TappedDown)
			{
				ID++;
				UpdateHighlight();
			}
			if (InputManager.TappedUp)
			{
				ID--;
				UpdateHighlight();
			}
			if (ID == 1)
			{
				if (InputManager.TappedRight)
				{
					ResID++;
					if (ResID == Widths.Length)
					{
						ResID = 0;
					}
					UpdateRes();
				}
				else if (InputManager.TappedLeft)
				{
					ResID--;
					if (ResID < 0)
					{
						ResID = Widths.Length - 1;
					}
					UpdateRes();
				}
			}
			else if (ID == 2)
			{
				if (InputManager.TappedRight || InputManager.TappedLeft)
				{
					FullScreen = !FullScreen;
					if (FullScreen)
					{
						FullScreenLabel.text = "Yes";
					}
					else
					{
						FullScreenLabel.text = "No";
					}
					Screen.SetResolution(Screen.width, Screen.height, FullScreen);
				}
			}
			else if (ID == 3)
			{
				if (InputManager.TappedRight)
				{
					QualityID++;
					if (QualityID == Qualities.Length)
					{
						QualityID = 0;
					}
					UpdateQuality();
				}
				else if (InputManager.TappedLeft)
				{
					QualityID--;
					if (QualityID < 0)
					{
						QualityID = Qualities.Length - 1;
					}
					UpdateQuality();
				}
			}
			else if (ID == 4 && Input.GetButtonUp("A"))
			{
				FadeOut = true;
			}
		}
		Highlight.localPosition = Vector3.Lerp(Highlight.localPosition, new Vector3(-307.5f, 250 - ID * 100, 0f), Time.deltaTime * 10f);
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			SceneManager.LoadScene("NewTitleScene");
		}
	}

	private void UpdateRes()
	{
		Screen.SetResolution(Widths[ResID], Heights[ResID], Screen.fullScreen);
		ResolutionLabel.text = Widths[ResID] + " x " + Heights[ResID];
	}

	private void UpdateQuality()
	{
		QualitySettings.SetQualityLevel(QualityID, applyExpensiveChanges: true);
		QualityLabel.text = Qualities[QualityID] ?? "";
		Debug.Log("The quality level is set to: " + QualitySettings.GetQualityLevel());
	}

	private void UpdateHighlight()
	{
		if (ID < 1)
		{
			ID = 4;
		}
		else if (ID > 4)
		{
			ID = 1;
		}
	}

	private void ResetGraphicsToDefault()
	{
		OptionGlobals.DisableStatic = false;
		OptionGlobals.DisableDisplacement = false;
		OptionGlobals.DisableAbberation = false;
		OptionGlobals.DisableVignette = false;
		OptionGlobals.DisableDistortion = false;
		OptionGlobals.DisableNoise = false;
		OptionGlobals.DisableScanlines = true;
		OptionGlobals.OpaqueWindows = false;
		OptionGlobals.MotionBlur = false;
		OptionGlobals.Fog = false;
	}
}
