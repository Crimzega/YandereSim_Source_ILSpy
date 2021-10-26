using UnityEngine;

public class WorkbenchScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public InventoryScript Inventory;

	public PromptBarScript PromptBar;

	public PromptScript Prompt;

	public GameObject ConfirmationWindow;

	public GameObject OutcomeCamera;

	public Transform WorkbenchWindow;

	public Transform Highlight;

	public UILabel ConfirmationLabel;

	public AudioSource MyAudio;

	public UISprite Darkness;

	public GameObject[] MaterialModel;

	public GameObject[] OutcomeModel;

	public GameObject[] Checkmark;

	public AudioClip[] SFX;

	public UILabel[] Label;

	public bool[] InStock;

	public int[] Material;

	public bool CraftingSequence;

	public bool Triple;

	public bool Return;

	public bool Show;

	public string Outcome = "";

	public int Checkmarks;

	public int Selection = 1;

	public int OutcomeID = 1;

	public float Rotation;

	private void Start()
	{
		RemoveCheckmarks();
	}

	private void Update()
	{
		if (!Show)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (!Prompt.Yandere.Chased && Prompt.Yandere.Chasers == 0)
				{
					Prompt.Yandere.MainCamera.transform.position = new Vector3(26f, 5.55f, 5f);
					Prompt.Yandere.MainCamera.transform.eulerAngles = new Vector3(54f, 0f, 0f);
					Prompt.Yandere.transform.position = new Vector3(26f, 4f, 4f);
					Prompt.Yandere.MyController.enabled = false;
					Prompt.Yandere.RPGCamera.enabled = false;
					Prompt.Yandere.CanMove = false;
					WorkbenchWindow.gameObject.SetActive(value: true);
					PromptBar.Label[0].text = "Select";
					PromptBar.Label[1].text = "Exit";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					CheckInventory();
					Show = true;
				}
			}
		}
		else if (!CraftingSequence)
		{
			if (!ConfirmationWindow.activeInHierarchy)
			{
				if (InputManager.TappedUp)
				{
					Selection--;
					UpdateHighlight();
				}
				else if (InputManager.TappedDown)
				{
					Selection++;
					UpdateHighlight();
				}
				if (Input.GetButtonDown("A"))
				{
					if (InStock[Selection] && Label[Selection].alpha == 1f)
					{
						MaterialModel[Selection].SetActive(!MaterialModel[Selection].activeInHierarchy);
						Checkmark[Selection].SetActive(!Checkmark[Selection].activeInHierarchy);
						if (Checkmark[Selection].activeInHierarchy)
						{
							Material[Checkmarks + 1] = Selection;
						}
						else
						{
							Material[Checkmarks] = 0;
						}
						CountCheckmarks();
						PlayRandomSound();
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					WorkbenchWindow.gameObject.SetActive(value: false);
					Prompt.Yandere.MyController.enabled = true;
					Prompt.Yandere.RPGCamera.enabled = true;
					Prompt.Yandere.CanMove = true;
					PromptBar.ClearButtons();
					PromptBar.UpdateButtons();
					PromptBar.Show = false;
					RemoveCheckmarks();
					Material[1] = 0;
					Material[2] = 0;
					Material[3] = 0;
					Triple = false;
					Show = false;
				}
				else if (Input.GetButtonDown("X") && PromptBar.Label[2].text != "")
				{
					PromptBar.Label[0].text = "Yes";
					PromptBar.Label[1].text = "No";
					PromptBar.Label[2].text = "";
					PromptBar.UpdateButtons();
					ConfirmationWindow.SetActive(value: true);
					ConfirmationLabel.text = "Combine these objects to make " + Outcome + "?";
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				ConfirmationWindow.SetActive(value: false);
				OutcomeModel[OutcomeID].transform.localScale = new Vector3(0f, 0f, 0f);
				OutcomeModel[OutcomeID].SetActive(value: true);
				OutcomeCamera.SetActive(value: true);
				CraftingSequence = true;
				PromptBar.Label[0].text = "Continue";
				PromptBar.Label[1].text = "";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				PlayRandomSound();
			}
			else if (Input.GetButtonDown("B"))
			{
				ConfirmationWindow.SetActive(value: false);
				PromptBar.Label[0].text = "Select";
				PromptBar.Label[1].text = "Exit";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
		}
		else if (!Return)
		{
			Rotation = Mathf.Lerp(Rotation, 360f, Time.deltaTime * 10f);
			OutcomeModel[OutcomeID].transform.localScale = Vector3.Lerp(OutcomeModel[OutcomeID].transform.localScale, Vector3.one, Time.deltaTime * 10f);
			OutcomeModel[OutcomeID].transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
			Darkness.alpha = Mathf.Lerp(Darkness.alpha, 0.5f, Time.deltaTime * 10f);
			if (Darkness.alpha > 0.49f && Input.GetButtonDown("A"))
			{
				if (OutcomeID == 1)
				{
					Inventory.Ammonium = false;
					Inventory.Balloons = false;
					GameObject obj = Object.Instantiate(Prompt.Yandere.PauseScreen.FavorMenu.DropsMenu.InfoChanWindow.Drops[13], Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0.5f), Quaternion.identity);
					obj.GetComponent<Rigidbody>().useGravity = true;
					obj.GetComponent<Rigidbody>().isKinematic = false;
				}
				else if (OutcomeID == 2)
				{
					Inventory.Hairpins = false;
					Inventory.PaperClips = false;
					Inventory.LockPick = true;
				}
				else if (OutcomeID == 3)
				{
					Inventory.SilverFulminate = false;
					Inventory.Paper = false;
					GameObject obj2 = Object.Instantiate(Prompt.Yandere.PauseScreen.FavorMenu.DropsMenu.InfoChanWindow.Drops[12], Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0.5f), Quaternion.identity);
					obj2.GetComponent<Rigidbody>().useGravity = true;
					obj2.GetComponent<Rigidbody>().isKinematic = false;
				}
				else if (OutcomeID == 4)
				{
					Inventory.Nails = false;
					Prompt.Yandere.EquippedWeapon.Nails.SetActive(value: true);
				}
				else if (OutcomeID == 5)
				{
					Inventory.Bandages = false;
					Inventory.WoodenSticks = false;
					Inventory.Glass = false;
					Prompt.Yandere.WeaponManager.Weapons[45].gameObject.SetActive(value: true);
					Prompt.Yandere.WeaponManager.Weapons[45].transform.position = Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0.5f);
					Prompt.Yandere.WeaponManager.Weapons[45].GetComponent<Rigidbody>().useGravity = true;
					Prompt.Yandere.WeaponManager.Weapons[45].GetComponent<Rigidbody>().isKinematic = false;
				}
				RemoveCheckmarks();
				CheckInventory();
				Return = true;
			}
		}
		else
		{
			Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 10f);
			OutcomeModel[OutcomeID].transform.localScale = Vector3.Lerp(OutcomeModel[OutcomeID].transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			OutcomeModel[OutcomeID].transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha == 0f)
			{
				OutcomeModel[OutcomeID].transform.localScale = Vector3.zero;
				OutcomeModel[OutcomeID].SetActive(value: false);
				OutcomeCamera.SetActive(value: false);
				PromptBar.Label[0].text = "Select";
				PromptBar.Label[1].text = "Exit";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				CraftingSequence = false;
				Return = false;
			}
		}
	}

	private void PlayRandomSound()
	{
		MyAudio.clip = SFX[Random.Range(1, SFX.Length)];
		MyAudio.Play();
	}

	private void CheckInventory()
	{
		Debug.Log("The game is now checking what items are currently in Yandere-chan's inventory.");
		for (int i = 1; i < Checkmark.Length; i++)
		{
			Label[i].color = new Color(0f, 0f, 0f, 0.5f);
			Label[i].text = "?????";
			InStock[i] = false;
		}
		if (Inventory.Ammonium)
		{
			Label[1].text = "Ammonium";
			InStock[1] = true;
		}
		if (Inventory.Balloons)
		{
			Label[2].text = "Balloons";
			InStock[2] = true;
		}
		if (Inventory.Bandages)
		{
			Label[3].text = "Bandages";
			InStock[3] = true;
		}
		if (Inventory.Glass)
		{
			Label[4].text = "Glass Shards";
			InStock[4] = true;
		}
		if (Inventory.Hairpins)
		{
			Label[5].text = "Hair Pins";
			InStock[5] = true;
		}
		if (Inventory.Nails)
		{
			Label[6].text = "Nails";
			InStock[6] = true;
		}
		if (Inventory.Paper)
		{
			Label[7].text = "Paper";
			InStock[7] = true;
		}
		if (Inventory.PaperClips)
		{
			Label[8].text = "Paper Clips";
			InStock[8] = true;
		}
		if (Inventory.SilverFulminate)
		{
			Label[9].text = "Silver Fulminate";
			InStock[9] = true;
		}
		if (Inventory.WoodenSticks)
		{
			Label[10].text = "Wooden Sticks";
			InStock[10] = true;
		}
		if (Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.WeaponID == 9 && !Prompt.Yandere.EquippedWeapon.Nails.activeInHierarchy)
		{
			Label[11].text = "Baseball Bat";
			InStock[11] = true;
		}
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Label[i].text != "?????")
			{
				Label[i].color = new Color(0f, 0f, 0f, 1f);
			}
		}
	}

	private void UpdateHighlight()
	{
		if (Selection > 11)
		{
			Selection = 1;
		}
		else if (Selection < 1)
		{
			Selection = 11;
		}
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 440f - 80f * (float)Selection, Highlight.localPosition.z);
	}

	private void CountCheckmarks()
	{
		Debug.Log("The game is now counting how many checkmarks are currently displayed.");
		PromptBar.Label[2].text = "";
		Checkmarks = 0;
		Triple = false;
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Checkmark[i].activeInHierarchy)
			{
				Checkmarks++;
				if (i == 3 || i == 4 || i == 10)
				{
					Triple = true;
				}
			}
		}
		if (!Triple && Checkmarks == 2)
		{
			PromptBar.Label[2].text = "Combine";
		}
		else if (Checkmarks == 3)
		{
			PromptBar.Label[2].text = "Combine";
		}
		PromptBar.UpdateButtons();
		DisableInvalidOptions();
	}

	private void RemoveCheckmarks()
	{
		for (int i = 1; i < Checkmark.Length; i++)
		{
			MaterialModel[i].SetActive(value: false);
			Checkmark[i].SetActive(value: false);
		}
		Checkmarks = 0;
	}

	private void DisableInvalidOptions()
	{
		Debug.Log("The player has picked a material, and the game is now disabling the materials that cannot be applied to that material.");
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Checkmarks > 0)
			{
				Label[i].color = new Color(0f, 0f, 0f, 0.5f);
			}
			else
			{
				Label[i].color = new Color(0f, 0f, 0f, 1f);
			}
		}
		if (!Triple)
		{
			if (Material[1] == 1 || Material[1] == 2)
			{
				Label[1].color = new Color(0f, 0f, 0f, 1f);
				Label[2].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "five stink bombs";
				OutcomeID = 1;
			}
			else if (Material[1] == 5 || Material[1] == 8)
			{
				Label[5].color = new Color(0f, 0f, 0f, 1f);
				Label[8].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "a lockpick";
				OutcomeID = 2;
			}
			else if (Material[1] == 7 || Material[1] == 9)
			{
				Label[7].color = new Color(0f, 0f, 0f, 1f);
				Label[9].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "five bang snaps";
				OutcomeID = 3;
			}
			else if (Material[1] == 6 || Material[1] == 11)
			{
				Label[11].color = new Color(0f, 0f, 0f, 1f);
				Label[6].color = new Color(0f, 0f, 0f, 1f);
				Outcome = "a spiked baseball bat";
				OutcomeID = 4;
			}
		}
		if (Triple && (Material[1] == 3 || Material[2] == 3 || Material[1] == 4 || Material[2] == 4 || Material[1] == 10 || Material[2] == 10))
		{
			Label[3].color = new Color(0f, 0f, 0f, 1f);
			Label[4].color = new Color(0f, 0f, 0f, 1f);
			Label[10].color = new Color(0f, 0f, 0f, 1f);
			Outcome = "a makeshift knife";
			OutcomeID = 5;
		}
		for (int i = 1; i < Checkmark.Length; i++)
		{
			if (Label[i].text == "?????")
			{
				Label[i].color = new Color(0f, 0f, 0f, 0.5f);
			}
		}
	}
}
