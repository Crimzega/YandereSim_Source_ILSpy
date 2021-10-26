using UnityEngine;

public class TitleSaveFilesScript : MonoBehaviour
{
	public NewTitleScreenScript NewTitleScreen;

	public InputManagerScript InputManager;

	public TitleSaveDataScript[] SaveDatas;

	public GameObject ConfirmationWindow;

	public GameObject ErrorWindow;

	public PromptBarScript PromptBar;

	public TitleMenuScript Menu;

	public Transform Highlight;

	public bool Started;

	public bool Show;

	public int EightiesPrefix;

	public int ID = 1;

	private void Update()
	{
		if (!(NewTitleScreen.Speed > 3f) || NewTitleScreen.FadeOut)
		{
			return;
		}
		if (Started)
		{
			ErrorWindow.SetActive(value: true);
			Started = false;
		}
		if (InputManager.TappedDown)
		{
			ID++;
			if (ID > 3)
			{
				ID = 1;
			}
			UpdateHighlight();
		}
		if (InputManager.TappedUp)
		{
			ID--;
			if (ID < 1)
			{
				ID = 3;
			}
			UpdateHighlight();
		}
		if (!ErrorWindow.activeInHierarchy)
		{
			if (!ConfirmationWindow.activeInHierarchy)
			{
				if (!PromptBar.Show)
				{
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Make Selection";
					PromptBar.Label[1].text = "Go Back";
					if (GameGlobals.Debug)
					{
						PromptBar.Label[3].text = "Quick Start";
					}
					PromptBar.Label[4].text = "Change Selection";
					UpdateHighlight();
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
				}
				if (Input.GetButtonDown("A") || (GameGlobals.Debug && Input.GetButtonDown("Y")))
				{
					if (PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) == 0)
					{
						Started = true;
						bool debug = GameGlobals.Debug;
						GameGlobals.Profile = EightiesPrefix + ID;
						Globals.DeleteAll();
						if (GameGlobals.Eighties)
						{
							for (int i = 1; i < 101; i++)
							{
								StudentGlobals.SetStudentPhotographed(i, value: true);
							}
						}
						GameGlobals.Profile = EightiesPrefix + ID;
						GameGlobals.Debug = debug;
						NewTitleScreen.Darkness.color = new Color(1f, 1f, 1f, 0f);
						Started = false;
					}
					else
					{
						Debug.Log("Loading a pre-existing save file!");
						GameGlobals.Profile = EightiesPrefix + ID;
					}
					NewTitleScreen.FadeOut = true;
					if (GameGlobals.Debug && Input.GetButtonDown("Y"))
					{
						NewTitleScreen.QuickStart = true;
					}
				}
				else if (Input.GetButtonDown("X"))
				{
					if (PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) > 0)
					{
						ConfirmationWindow.SetActive(value: true);
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					NewTitleScreen.Speed = 0f;
					NewTitleScreen.Phase = 2;
					PromptBar.Show = false;
					base.enabled = false;
				}
			}
			else
			{
				PromptBar.Show = false;
				if (Input.GetButtonDown("A"))
				{
					PlayerPrefs.SetInt("ProfileCreated_" + (EightiesPrefix + ID), 0);
					ConfirmationWindow.SetActive(value: false);
					SaveDatas[ID].Start();
				}
				else if (Input.GetButtonDown("B"))
				{
					ConfirmationWindow.SetActive(value: false);
				}
			}
		}
		else if (Input.anyKeyDown)
		{
			PlayerPrefs.DeleteAll();
			Debug.Log("All player prefs deleted...");
			Application.Quit();
		}
	}

	private void UpdateHighlight()
	{
		Highlight.localPosition = new Vector3(0f, 700f - 350f * (float)ID, 0f);
		if (PlayerPrefs.GetInt("ProfileCreated_" + (EightiesPrefix + ID)) > 0)
		{
			PromptBar.Label[2].text = "Delete";
			PromptBar.UpdateButtons();
		}
		else
		{
			PromptBar.Label[2].text = "";
		}
		PromptBar.UpdateButtons();
	}
}
