using UnityEngine;

public class ServicesScript : MonoBehaviour
{
	public TextMessageManagerScript TextMessageManager;

	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public ReputationScript Reputation;

	public InventoryScript Inventory;

	public PromptBarScript PromptBar;

	public SchemesScript Schemes;

	public YandereScript Yandere;

	public GameObject FavorMenu;

	public Transform Highlight;

	public AudioSource MyAudio;

	public PoliceScript Police;

	public UITexture ServiceIcon;

	public UILabel ServiceLimit;

	public UILabel ServiceDesc;

	public UILabel PantyCount;

	public UILabel[] CostLabels;

	public UILabel[] NameLabels;

	public Texture[] ServiceIcons;

	public string[] ServiceLimits;

	public string[] ServiceDescs;

	public string[] ServiceNames;

	public bool[] ServiceAvailable;

	public bool[] ServicePurchased;

	public int[] ServiceCosts;

	public int Selected = 1;

	public int ID = 1;

	public AudioClip InfoUnavailable;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	private void Start()
	{
		for (int i = 1; i < ServiceNames.Length; i++)
		{
			ServicePurchased[i] = SchemeGlobals.GetServicePurchased(i);
			NameLabels[i].text = ServiceNames[i];
		}
	}

	private void Update()
	{
		if (InputManager.TappedUp)
		{
			Selected--;
			if (Selected < 1)
			{
				Selected = ServiceNames.Length - 1;
			}
			UpdateDesc();
		}
		if (InputManager.TappedDown)
		{
			Selected++;
			if (Selected > ServiceNames.Length - 1)
			{
				Selected = 1;
			}
			UpdateDesc();
		}
		if (Input.GetButtonDown("A"))
		{
			if (!ServicePurchased[Selected] && (double)NameLabels[Selected].color.a == 1.0)
			{
				if (PromptBar.Label[0].text != string.Empty)
				{
					if (Inventory.PantyShots >= ServiceCosts[Selected])
					{
						if (Selected == 1)
						{
							Yandere.PauseScreen.StudentInfoMenu.GettingInfo = true;
							Yandere.PauseScreen.StudentInfoMenu.Column = 0;
							Yandere.PauseScreen.StudentInfoMenu.Row = 0;
							Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
							Yandere.PauseScreen.Sideways = true;
							Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
							StartCoroutine(Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
							Yandere.PromptBar.ClearButtons();
							Yandere.PromptBar.Label[1].text = "Cancel";
							Yandere.PromptBar.UpdateButtons();
							Yandere.PromptBar.Show = true;
							base.gameObject.SetActive(value: false);
						}
						else if (Selected == 2)
						{
							Reputation.PendingRep += 5f;
							Purchase();
						}
						else if (Selected == 3)
						{
							StudentManager.StudentReps[StudentManager.RivalID] -= 5f;
							Purchase();
						}
						else if (Selected == 4)
						{
							ServicePurchased[Selected] = true;
							StudentManager.EmbarassingSecret = true;
							Purchase();
						}
						else if (Selected == 5)
						{
							Yandere.PauseScreen.StudentInfoMenu.SendingHome = true;
							Yandere.PauseScreen.StudentInfoMenu.Column = 0;
							Yandere.PauseScreen.StudentInfoMenu.Row = 0;
							Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
							Yandere.PauseScreen.Sideways = true;
							Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
							Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
							StartCoroutine(Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
							Yandere.PromptBar.ClearButtons();
							Yandere.PromptBar.Label[1].text = "Cancel";
							Yandere.PromptBar.UpdateButtons();
							Yandere.PromptBar.Show = true;
							base.gameObject.SetActive(value: false);
						}
						else if (Selected == 6)
						{
							Police.Timer += 300f;
							Police.Delayed = true;
							Purchase();
						}
						else if (Selected == 7)
						{
							ServicePurchased[Selected] = true;
							CounselorGlobals.CounselorTape = 1;
							Purchase();
						}
						else if (Selected == 8)
						{
							Yandere.PauseScreen.StudentInfoMenu.GettingOpinions = true;
							Yandere.PauseScreen.StudentInfoMenu.Column = 0;
							Yandere.PauseScreen.StudentInfoMenu.Row = 0;
							Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
							Yandere.PauseScreen.Sideways = true;
							Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
							StartCoroutine(Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
							Yandere.PromptBar.ClearButtons();
							Yandere.PromptBar.Label[0].text = "Get Opinions";
							Yandere.PromptBar.Label[1].text = "Cancel";
							Yandere.PromptBar.UpdateButtons();
							Yandere.PromptBar.Show = true;
							base.gameObject.SetActive(value: false);
						}
						else if (Selected == 9)
						{
							Yandere.PauseScreen.StudentInfoMenu.FiringCouncilMember = true;
							Yandere.PauseScreen.StudentInfoMenu.Column = 0;
							Yandere.PauseScreen.StudentInfoMenu.Row = 0;
							Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
							Yandere.PauseScreen.Sideways = true;
							Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
							Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
							StartCoroutine(Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
							Yandere.PromptBar.ClearButtons();
							Yandere.PromptBar.Label[1].text = "Cancel";
							Yandere.PromptBar.UpdateButtons();
							Yandere.PromptBar.Show = true;
							base.gameObject.SetActive(value: false);
						}
						else if (Selected == 10)
						{
							ServicePurchased[Selected] = true;
							Yandere.Police.EndOfDay.LearnedOsanaInfo1 = true;
							Yandere.Police.EndOfDay.LearnedOsanaInfo2 = true;
							Purchase();
						}
					}
				}
				else if (Inventory.PantyShots < ServiceCosts[Selected])
				{
					MyAudio.clip = InfoAfford;
					MyAudio.Play();
				}
				else
				{
					MyAudio.clip = InfoUnavailable;
					MyAudio.Play();
				}
			}
			else
			{
				MyAudio.clip = InfoUnavailable;
				MyAudio.Play();
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[5].text = "Choose";
			PromptBar.UpdateButtons();
			FavorMenu.SetActive(value: true);
			base.gameObject.SetActive(value: false);
		}
	}

	public void UpdateList()
	{
		for (ID = 1; ID < ServiceNames.Length; ID++)
		{
			CostLabels[ID].text = ServiceCosts[ID].ToString();
			ServiceAvailable[ID] = false;
			if (ID == 1 || ID == 2 || ID == 3)
			{
				ServiceAvailable[ID] = true;
			}
			else if (ID == 4)
			{
				if (!StudentManager.EmbarassingSecret)
				{
					ServiceAvailable[ID] = true;
				}
			}
			else if (ID == 5)
			{
				if (!ServicePurchased[ID])
				{
					ServiceAvailable[ID] = true;
				}
			}
			else if (ID == 6)
			{
				if (Police.Show && !Police.Delayed)
				{
					ServiceAvailable[ID] = true;
				}
			}
			else if (ID == 7)
			{
				if (CounselorGlobals.CounselorTape == 0)
				{
					ServiceAvailable[ID] = true;
				}
			}
			else if (ID == 8)
			{
				if (!ServicePurchased[8])
				{
					ServiceAvailable[ID] = true;
				}
			}
			else if (ID == 9)
			{
				if (MissionModeGlobals.MissionMode)
				{
					ServiceAvailable[ID] = true;
				}
			}
			else if (ID == 10 && (!Yandere.Police.EndOfDay.LearnedOsanaInfo1 || !Yandere.Police.EndOfDay.LearnedOsanaInfo2))
			{
				ServiceAvailable[ID] = true;
			}
			if (StudentManager.MissionMode)
			{
				ServiceAvailable[5] = false;
			}
			UILabel uILabel = NameLabels[ID];
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, ServiceAvailable[ID] ? 1f : 0.5f);
		}
	}

	public void UpdateDesc()
	{
		if (ServiceAvailable[Selected] && !ServicePurchased[Selected])
		{
			PromptBar.Label[0].text = ((Inventory.PantyShots >= ServiceCosts[Selected]) ? "Purchase" : string.Empty);
			PromptBar.UpdateButtons();
		}
		else
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 200f - 25f * (float)Selected, Highlight.localPosition.z);
		ServiceIcon.mainTexture = ServiceIcons[Selected];
		ServiceLimit.text = ServiceLimits[Selected];
		ServiceDesc.text = ServiceDescs[Selected];
		if (Selected == 5)
		{
			ServiceDesc.text = ServiceDescs[Selected] + "\n\nIf student portraits don't appear, back out of the menu, load the Student Info menu, then return to this screen.";
		}
		UpdatePantyCount();
	}

	public void UpdatePantyCount()
	{
		PantyCount.text = Inventory.PantyShots.ToString();
	}

	public void Purchase()
	{
		TextMessageManager.SpawnMessage(Selected);
		Inventory.PantyShots -= ServiceCosts[Selected];
		AudioSource.PlayClipAtPoint(InfoPurchase, base.transform.position);
		UpdateList();
		UpdateDesc();
		PromptBar.Label[0].text = string.Empty;
		PromptBar.Label[1].text = "Back";
		PromptBar.UpdateButtons();
	}

	public void SaveServicesPurchased()
	{
		for (int i = 1; i < ServiceNames.Length; i++)
		{
			SchemeGlobals.SetServicePurchased(i, ServicePurchased[i]);
		}
	}
}
