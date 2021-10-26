using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDemoChecklistScript : MonoBehaviour
{
	public NewTitleScreenScript NewTitleScreen;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public UISprite[] ConfirmBlocks;

	public string[] ItemNames;

	public string[] ItemDescs;

	public UILabel ItemNameLabel;

	public UILabel ItemDescLabel;

	public UILabel ResetLabel;

	public Vector3 OriginalPosition;

	public GameObject ResetWindow;

	public Transform Highlight;

	public bool DeletingGlobals;

	public bool Shrink;

	public bool Show;

	public bool Zoom;

	public int Confirmations;

	public int Columns;

	public int Rows;

	private int Column;

	private int Row;

	private int Selected = 1;

	public UITexture[] Items;

	public Texture[] ItemTextures;

	private void Start()
	{
		UpdateHighlight();
		if (PlayerPrefs.GetInt("Attack") == 1)
		{
			Items[1].mainTexture = ItemTextures[1];
		}
		if (PlayerPrefs.GetInt("Befriend") == 1)
		{
			Items[2].mainTexture = ItemTextures[2];
		}
		if (PlayerPrefs.GetInt("Betray") == 1)
		{
			Items[3].mainTexture = ItemTextures[3];
		}
		if (PlayerPrefs.GetInt("Bully") == 1)
		{
			Items[4].mainTexture = ItemTextures[4];
		}
		if (PlayerPrefs.GetInt("Burn") == 1)
		{
			Items[5].mainTexture = ItemTextures[5];
		}
		if (PlayerPrefs.GetInt("Crush") == 1)
		{
			Items[6].mainTexture = ItemTextures[6];
		}
		if (PlayerPrefs.GetInt("Drown") == 1)
		{
			Items[7].mainTexture = ItemTextures[7];
		}
		if (PlayerPrefs.GetInt("Electrocute") == 1)
		{
			Items[8].mainTexture = ItemTextures[8];
		}
		if (PlayerPrefs.GetInt("Expel") == 1)
		{
			Items[9].mainTexture = ItemTextures[9];
		}
		if (PlayerPrefs.GetInt("Fan") == 1)
		{
			Items[10].mainTexture = ItemTextures[10];
		}
		if (PlayerPrefs.GetInt("Frame") == 1)
		{
			Items[11].mainTexture = ItemTextures[11];
		}
		if (PlayerPrefs.GetInt("Kidnap") == 1)
		{
			Items[12].mainTexture = ItemTextures[12];
		}
		if (PlayerPrefs.GetInt("Matchmake") == 1)
		{
			Items[13].mainTexture = ItemTextures[13];
		}
		if (PlayerPrefs.GetInt("MurderSuicide") == 1)
		{
			Items[14].mainTexture = ItemTextures[14];
		}
		if (PlayerPrefs.GetInt("Poison") == 1)
		{
			Items[15].mainTexture = ItemTextures[15];
		}
		if (PlayerPrefs.GetInt("Pool") == 1)
		{
			Items[16].mainTexture = ItemTextures[16];
		}
		if (PlayerPrefs.GetInt("Push") == 1)
		{
			Items[17].mainTexture = ItemTextures[17];
		}
		if (PlayerPrefs.GetInt("Reject") == 1)
		{
			Items[18].mainTexture = ItemTextures[18];
		}
		if (PlayerPrefs.GetInt("Suicide") == 1)
		{
			Items[19].mainTexture = ItemTextures[19];
		}
		if (PlayerPrefs.GetInt("DrivenToMurder") == 1)
		{
			Items[20].mainTexture = ItemTextures[20];
		}
		if (PlayerPrefs.GetInt("HeadHunter") > 9)
		{
			Items[21].mainTexture = ItemTextures[21];
		}
		if (PlayerPrefs.GetInt("PantyQueen") == 1)
		{
			Items[22].mainTexture = ItemTextures[22];
		}
		if (PlayerPrefs.GetInt("RichGirl") == 1)
		{
			Items[23].mainTexture = ItemTextures[23];
		}
		if (PlayerPrefs.GetInt("WeaponMaster") == 1)
		{
			Items[24].mainTexture = ItemTextures[24];
		}
	}

	public void GetIndex()
	{
		Selected = Column + Row * Columns + 1;
	}

	private void Update()
	{
		if (Zoom)
		{
			if (!Shrink)
			{
				Items[Selected].transform.localPosition = Vector3.Lerp(Items[Selected].transform.localPosition, new Vector3(0f, 25f, 0f), Time.deltaTime * 10f);
				Items[Selected].transform.localScale = Vector3.Lerp(Items[Selected].transform.localScale, Vector3.one, Time.deltaTime * 10f);
				if (Input.GetButtonDown("B"))
				{
					Items[Selected].depth = 0;
					Shrink = true;
				}
				return;
			}
			Items[Selected].transform.localPosition = Vector3.Lerp(Items[Selected].transform.localPosition, OriginalPosition, Time.deltaTime * 10f);
			Items[Selected].transform.localScale = Vector3.Lerp(Items[Selected].transform.localScale, new Vector3(0.195f, 0.195f, 0.195f), Time.deltaTime * 10f);
			if (Items[Selected].transform.localScale.x < 0.2f)
			{
				Items[Selected].transform.localPosition = OriginalPosition;
				Items[Selected].transform.localScale = new Vector3(0.195f, 0.195f, 0.195f);
				Shrink = false;
				Zoom = false;
			}
		}
		else if (!ResetWindow.activeInHierarchy)
		{
			if (InputManager.TappedUp)
			{
				Row = ((Row > 0) ? (Row - 1) : (Rows - 1));
			}
			if (InputManager.TappedDown)
			{
				Row = ((Row < Rows - 1) ? (Row + 1) : 0);
			}
			if (InputManager.TappedRight)
			{
				Column = ((Column < Columns - 1) ? (Column + 1) : 0);
			}
			if (InputManager.TappedLeft)
			{
				Column = ((Column > 0) ? (Column - 1) : (Columns - 1));
			}
			if (InputManager.TappedUp || InputManager.TappedDown || InputManager.TappedRight || InputManager.TappedLeft)
			{
				UpdateHighlight();
			}
			if (NewTitleScreen.Speed > 3f)
			{
				if (!PromptBar.Show)
				{
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "View Image";
					PromptBar.Label[1].text = "Go Back";
					PromptBar.Label[2].text = "Reset Progress";
					PromptBar.Label[4].text = "Change Selection";
					PromptBar.Label[5].text = "Change Selection";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
				}
				if (Input.GetButtonDown("A"))
				{
					OriginalPosition = Items[Selected].transform.localPosition;
					Items[Selected].depth = 2;
					Zoom = true;
				}
				else if (Input.GetButtonDown("X"))
				{
					ResetWindow.SetActive(value: true);
				}
				else if (Input.GetButtonDown("B"))
				{
					NewTitleScreen.Speed = 0f;
					NewTitleScreen.Phase = 2;
					PromptBar.Show = false;
					base.enabled = false;
				}
				else if (Input.GetKeyDown("r"))
				{
					ResetLabel.text = "This is a hidden debug command for completely removing all Yandere Simulator data from your computer's registry. This command will delete all of your save data, but may fix certain types of bugs that cannot be fixed in any other way.";
					DeletingGlobals = true;
					ResetWindow.SetActive(value: true);
				}
			}
		}
		else if (Input.GetButtonDown("A"))
		{
			Confirmations++;
			ConfirmBlocks[Confirmations].color = new Color(1f, 1f, 1f, 1f);
			if (Confirmations == 10)
			{
				if (DeletingGlobals)
				{
					PlayerPrefs.DeleteAll();
					OptionGlobals.DisableScanlines = true;
				}
				else
				{
					PlayerPrefs.SetInt("Attack", 0);
					PlayerPrefs.SetInt("Befriend", 0);
					PlayerPrefs.SetInt("Betray", 0);
					PlayerPrefs.SetInt("Bully", 0);
					PlayerPrefs.SetInt("Burn", 0);
					PlayerPrefs.SetInt("Crush", 0);
					PlayerPrefs.SetInt("Drown", 0);
					PlayerPrefs.SetInt("Electrocute", 0);
					PlayerPrefs.SetInt("Expel", 0);
					PlayerPrefs.SetInt("Fan", 0);
					PlayerPrefs.SetInt("Frame", 0);
					PlayerPrefs.SetInt("Kidnap", 0);
					PlayerPrefs.SetInt("Matchmake", 0);
					PlayerPrefs.SetInt("MurderSuicide", 0);
					PlayerPrefs.SetInt("Poison", 0);
					PlayerPrefs.SetInt("Pool", 0);
					PlayerPrefs.SetInt("Push", 0);
					PlayerPrefs.SetInt("Reject", 0);
					PlayerPrefs.SetInt("Suicide", 0);
					PlayerPrefs.SetInt("DrivenToMurder", 0);
					PlayerPrefs.SetInt("HeadHunter", 0);
					PlayerPrefs.SetInt("PantyQueen", 0);
					PlayerPrefs.SetInt("RichGirl", 0);
					PlayerPrefs.SetInt("WeaponMaster", 0);
				}
				SceneManager.LoadScene("NewTitleScene");
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			ResetConfirmations();
		}
	}

	private void UpdateHighlight()
	{
		Highlight.localPosition = new Vector3(-350f + (float)Column * 100f, 100f - (float)Row * 100f, Highlight.localPosition.z);
		GetIndex();
		ItemNameLabel.text = ItemNames[Selected];
		ItemDescLabel.text = ItemDescs[Selected];
	}

	private void ResetConfirmations()
	{
		ResetLabel.text = "Are you ABSOLUTELY CERTAIN that you want to reset your Demo Checklist progress?\n\nMash the Confirm button 10 times to reaffirm this decision.";
		ResetWindow.SetActive(value: false);
		DeletingGlobals = false;
		PromptBar.Show = true;
		Confirmations = 0;
		ConfirmBlocks[1].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[2].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[3].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[4].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[5].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[6].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[7].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[8].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[9].color = new Color(1f, 1f, 1f, 0.5f);
		ConfirmBlocks[10].color = new Color(1f, 1f, 1f, 0.5f);
	}
}
