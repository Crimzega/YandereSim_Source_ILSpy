using UnityEngine;

public class GenericRivalBagScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public GenericRivalEventScript Event;

	public PromptBarScript PromptBar;

	public StudentScript Rival;

	public PromptScript Prompt;

	public JsonScript JSON;

	public Transform Highlight;

	public GameObject Window;

	public UILabel[] Label;

	public bool BorrowedBook;

	public bool Alcohol;

	public bool Condoms;

	public bool Cigarettes;

	public bool StolenRing;

	public bool AnswerSheet;

	public bool Narcotics;

	public bool BentoStolen;

	public bool NoBento;

	public int Selected;

	public int Limit;

	public int Menu;

	public int[] RivalOpinions;

	public string[] Subjects;

	public string[] RivalDislikes;

	public string[] RivalLikes;

	public int Dislikes = 1;

	public int Likes = 1;

	public int[] DesiredHairstyles;

	public int[] DesiredAccessories;

	public int[] DesiredEyewears;

	public int[] DesiredSkins;

	public string[] DesiredHairColors;

	public bool[] DesiredJewelries;

	public int[] DesiredTraits;

	public int DesiredHairstyle;

	public int DesiredAccessory;

	public int DesiredEyewear;

	public int DesiredSkin;

	public string DesiredHairColor;

	public bool DesiredJewelry;

	public int DesiredTrait;

	public string DesiredHairstyleText;

	public string DesiredAccessoryText;

	public string DesiredEyewearText;

	public string DesiredSkinText;

	public string DesiredHairColorText;

	public string DesiredJewelryText;

	public string DesiredTraitText;

	public bool Initialized;

	public void Start()
	{
		if (Initialized)
		{
			return;
		}
		int week = DateGlobals.Week;
		if (week < 11)
		{
			if (week == 4)
			{
				NoBento = true;
			}
			int num = 10 + week;
			RivalOpinions = JSON.Topics[num].Topics;
			for (int i = 1; i < 26; i++)
			{
				if (RivalOpinions[i] == 2)
				{
					RivalLikes[Likes] = Subjects[i];
					Likes++;
				}
				else if (RivalOpinions[i] == 1)
				{
					RivalDislikes[Dislikes] = Subjects[i];
					Dislikes++;
				}
			}
			num -= 10;
			DesiredHairstyle = DesiredHairstyles[num];
			DesiredAccessory = DesiredAccessories[num];
			DesiredEyewear = DesiredEyewears[num];
			DesiredSkin = DesiredSkins[num];
			DesiredHairColor = DesiredHairColors[num];
			DesiredJewelry = DesiredJewelries[num];
			DesiredTrait = DesiredTraits[num];
			if (DesiredHairstyle == 55)
			{
				DesiredHairstyleText = "She likes boys who have ponytails.";
			}
			else if (DesiredHairstyle == 56)
			{
				DesiredHairstyleText = "She likes boys who have slick hair.";
			}
			if (DesiredAccessory == 17)
			{
				DesiredAccessoryText = "She likes boys who have piercings.";
			}
			else if (DesiredAccessory == 1)
			{
				DesiredAccessoryText = "She likes boys who wear bandanas.";
			}
			if (DesiredEyewear == 6)
			{
				DesiredEyewearText = "She likes boys who wear glasses.";
			}
			else if (DesiredEyewear == 3)
			{
				DesiredEyewearText = "She likes boys who wear shades.";
			}
			if (DesiredSkin == 6)
			{
				DesiredSkinText = "She likes boys who tan their skin.";
			}
			else
			{
				DesiredSkinText = "She doesn't like boys who tan their skin.";
			}
			if (DesiredHairColor == "SolidBlack")
			{
				DesiredHairColorText = "She likes boys with dark hair.";
			}
			else
			{
				DesiredHairColorText = "She doesn't like dark hair.";
			}
			if (DesiredJewelry)
			{
				DesiredJewelryText = "She likes boys who wear a lot of jewelry.";
			}
			else
			{
				DesiredJewelryText = "She doesn't like boys who wear a lot of jewlery.";
			}
			if (DesiredTrait == 1)
			{
				DesiredTraitText = "She admires men who have intelligence.";
			}
			else if (DesiredTrait == 2)
			{
				DesiredTraitText = "She admires men with a lot of physical strength.";
			}
			else if (DesiredTrait == 3)
			{
				DesiredTraitText = "She admires men who have a lot of courage.";
			}
		}
		base.gameObject.SetActive(value: false);
		Window.SetActive(value: false);
		Prompt.enabled = false;
		Prompt.Hide();
		Initialized = true;
	}

	private void Update()
	{
		if (!Window.activeInHierarchy)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					Prompt.Yandere.RPGCamera.enabled = false;
					Prompt.Yandere.CanMove = false;
					Time.timeScale = 0.0001f;
					Window.SetActive(value: true);
					Menu = 1;
					UpdateMenuLabels();
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Confirm";
					PromptBar.Label[5].text = "Change Selection";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			return;
		}
		if (InputManager.TappedDown)
		{
			Selected++;
			UpdateHighlight();
		}
		else if (InputManager.TappedUp)
		{
			Selected--;
			UpdateHighlight();
		}
		if (Input.GetButtonDown("A"))
		{
			if (Menu == 1)
			{
				if (Label[Selected].color.a == 1f)
				{
					if (Selected == 1)
					{
						Menu = 2;
						UpdateMenuLabels();
					}
					else if (Selected == 2)
					{
						Menu = 3;
						UpdateMenuLabels();
					}
					else if (Selected == 3)
					{
						Menu = 4;
						UpdateMenuLabels();
					}
					else if (Selected == 4)
					{
						CloseWindow();
					}
				}
			}
			else if (Menu == 2)
			{
				if (Label[Selected].color.a == 1f)
				{
					if (Selected == 1)
					{
						BorrowedBook = false;
						Event.Sabotage();
						ScheduleBlock obj = Rival.ScheduleBlocks[4];
						obj.destination = "Search";
						obj.action = "Search";
						Rival.GetDestinations();
						UpdateMenuLabels();
					}
					else if (Selected == 2)
					{
						Highlight.gameObject.SetActive(value: false);
						PromptBar.ClearButtons();
						PromptBar.Label[1].text = "Back";
						PromptBar.UpdateButtons();
						Menu = 5;
						UpdateMenuLabels();
					}
					else if (Selected == 3)
					{
						Highlight.gameObject.SetActive(value: false);
						PromptBar.ClearButtons();
						PromptBar.Label[1].text = "Back";
						PromptBar.UpdateButtons();
						Menu = 6;
						UpdateMenuLabels();
					}
					else if (Selected == 4)
					{
						Menu = 1;
						UpdateMenuLabels();
					}
				}
			}
			else if (Menu == 3)
			{
				if (Label[Selected].color.a != 1f)
				{
					return;
				}
				if (Selected == 1)
				{
					if (Prompt.Yandere.Inventory.RatPoison)
					{
						Prompt.Yandere.Inventory.RatPoison = false;
					}
					else
					{
						Prompt.Yandere.Inventory.EmeticPoison = false;
					}
					Rival.MyBento.Tampered = true;
					Rival.MyBento.Emetic = true;
				}
				else if (Selected == 2)
				{
					Rival.MyBento.Tampered = true;
					Rival.MyBento.Lethal = true;
				}
				else if (Selected == 3)
				{
					Rival.MyBento.Tampered = true;
					Rival.MyBento.Headache = true;
				}
				else if (Selected == 4)
				{
					if (Prompt.Yandere.Inventory.Tranquilizer)
					{
						Prompt.Yandere.Inventory.Tranquilizer = false;
					}
					else
					{
						Prompt.Yandere.Inventory.Sedative = false;
					}
					Rival.MyBento.Tampered = true;
					Rival.MyBento.Tranquil = true;
				}
				else if (Selected == 5)
				{
					Rival.ScheduleBlocks[4].action = "Shamed";
					Rival.GetDestinations();
					BentoStolen = true;
				}
				Menu = 1;
				UpdateMenuLabels();
			}
			else if (Menu == 4 && Label[Selected].color.a == 1f)
			{
				if (Selected == 1)
				{
					Prompt.Yandere.Inventory.Sake = false;
					Alcohol = true;
				}
				else if (Selected == 2)
				{
					Prompt.Yandere.Inventory.Condoms = false;
					Condoms = true;
				}
				else if (Selected == 3)
				{
					Prompt.Yandere.Inventory.Cigs = false;
					Cigarettes = true;
				}
				else if (Selected == 4)
				{
					Prompt.Yandere.Inventory.Ring = false;
					StolenRing = true;
				}
				else if (Selected == 5)
				{
					Prompt.Yandere.Inventory.AnswerSheet = false;
					AnswerSheet = true;
				}
				else if (Selected == 6)
				{
					Prompt.Yandere.Inventory.Narcotics = false;
					Narcotics = true;
				}
				Menu = 1;
				UpdateMenuLabels();
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			Highlight.gameObject.SetActive(value: true);
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Confirm";
			PromptBar.Label[5].text = "Change Selection";
			PromptBar.UpdateButtons();
			if (Menu == 5)
			{
				Menu = 2;
				UpdateMenuLabels();
			}
			else if (Menu == 6)
			{
				Menu = 2;
				UpdateMenuLabels();
			}
		}
	}

	private void CloseWindow()
	{
		Selected = 1;
		UpdateHighlight();
		Prompt.Yandere.RPGCamera.enabled = true;
		Prompt.Yandere.CanMove = true;
		Window.SetActive(value: false);
		Time.timeScale = 1f;
		PromptBar.ClearButtons();
		PromptBar.Show = false;
	}

	private void UpdateHighlight()
	{
		if (Selected > Limit)
		{
			Selected = 1;
		}
		else if (Selected < 1)
		{
			Selected = Limit;
		}
		Highlight.localPosition = new Vector3(0f, 400 - Selected * 100, 0f);
	}

	private void UpdateMenuLabels()
	{
		Selected = 1;
		UpdateHighlight();
		for (int i = 1; i < Label.Length; i++)
		{
			Label[i].color = new Color(1f, 1f, 1f, 1f);
			Label[i].text = "";
		}
		Label[8].text = "";
		if (Menu == 1)
		{
			Label[1].text = "BOOKS";
			Label[2].text = "BENTO";
			Label[3].text = "CONTRABAND";
			Label[4].text = "EXIT";
			if (Rival.MyBento.Tampered || BentoStolen || NoBento)
			{
				Label[2].color = new Color(1f, 1f, 1f, 0.5f);
				if (BentoStolen)
				{
					Label[2].text = "BENTO (STOLEN)";
				}
				else if (NoBento)
				{
					Label[2].text = "NO BENTO";
				}
				else
				{
					Label[2].text = "BENTO (POISONED)";
				}
			}
			if (Prompt.Yandere.StudentManager.Clock.Period > 3)
			{
				Label[2].color = new Color(1f, 1f, 1f, 0.5f);
			}
			Limit = 4;
		}
		else if (Menu == 2)
		{
			Label[1].text = "STEAL BORROWED BOOK";
			Label[2].text = "READ MAGAZINE";
			Label[3].text = "READ DIARY";
			Label[4].text = "BACK";
			if (!BorrowedBook || Prompt.Yandere.StudentManager.Clock.Period == 3)
			{
				Label[1].color = new Color(1f, 1f, 1f, 0.5f);
			}
			Limit = 4;
		}
		else if (Menu == 3)
		{
			Label[1].text = "PUT EMETIC POISON IN BENTO";
			Label[2].text = "PUT LETHAL POISON IN BENTO";
			Label[3].text = "PUT HEADACHE POISON IN BENTO";
			Label[4].text = "PUT SEDATIVE POISON IN BENTO";
			Label[5].text = "STEAL BENTO";
			Label[6].text = "BACK";
			if (!Prompt.Yandere.Inventory.EmeticPoison && !Prompt.Yandere.Inventory.RatPoison)
			{
				Label[1].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.LethalPoison)
			{
				Label[2].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.HeadachePoison)
			{
				Label[3].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.Sedative && !Prompt.Yandere.Inventory.Tranquilizer)
			{
				Label[4].color = new Color(1f, 1f, 1f, 0.5f);
			}
			Limit = 6;
		}
		else if (Menu == 4)
		{
			Label[1].text = "PUT ALCOHOL INTO BAG";
			Label[2].text = "PUT CONDOMS INTO BAG";
			Label[3].text = "PUT CIGARETTES INTO BAG";
			Label[4].text = "PUT STOLEN RING INTO BAG";
			Label[5].text = "PUT ANSWER SHEET INTO BAG";
			Label[6].text = "PUT NARCOTICS INTO BAG";
			Label[7].text = "BACK";
			if (!Prompt.Yandere.Inventory.Sake)
			{
				Label[1].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.Condoms)
			{
				Label[2].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.Cigs)
			{
				Label[3].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.Ring)
			{
				Label[4].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.AnswerSheet)
			{
				Label[5].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.Narcotics)
			{
				Label[6].color = new Color(1f, 1f, 1f, 0.5f);
			}
			Limit = 7;
		}
		else if (Menu == 5)
		{
			Label[8].text = "You find a magazine in your rival's bookbag. It's a magazine about cute boys. Your rival has drawn circles around the boys she likes the most. It's apparent that...\n\n" + DesiredHairstyleText + "\n\n" + DesiredAccessoryText + "\n\n" + DesiredEyewearText + "\n\n" + DesiredSkinText + "\n\n" + DesiredHairColorText + "\n\n" + DesiredJewelryText + "\n\n" + DesiredTraitText;
		}
		else if (Menu == 6)
		{
			Label[8].text = "You look through your rival's diary. \n\nShe likes " + RivalLikes[1] + ", " + RivalLikes[2] + ", " + RivalLikes[3] + ", " + RivalLikes[4] + ", and " + RivalLikes[5] + ".\n\nShe dislikes " + RivalDislikes[1] + ", " + RivalDislikes[2] + ", " + RivalDislikes[3] + ", " + RivalDislikes[4] + ", and " + RivalDislikes[5] + ".\n\nYou learn some embarassing secrets that will help you spread gossip about her.\n\nMost recent diary entry: \n\n''I can't sleep! I'm too worried about that EVIL PHOTOGRAPHER!''\n\nPerhaps you should befriend her and put a note in her locker to arrange a discussion about that topic.";
			Prompt.Yandere.Police.EndOfDay.LearnedAboutPhotographer = true;
			Prompt.Yandere.StudentManager.EmbarassingSecret = true;
		}
	}
}
