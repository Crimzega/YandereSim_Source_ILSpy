using UnityEngine;

public class DatingMinigameScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public LoveManagerScript LoveManager;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public StudentScript Suitor;

	public StudentScript Rival;

	public PromptScript Prompt;

	public JsonScript JSON;

	public Transform AffectionSet;

	public Transform OptionSet;

	public GameObject HeartbeatCamera;

	public GameObject SeductionIcon;

	public GameObject PantyIcon;

	public Transform TopicHighlight;

	public Transform ComplimentSet;

	public Transform AffectionBar;

	public Transform Highlight;

	public Transform GiveGift;

	public Transform PeekSpot;

	public Transform[] Options;

	public Transform ShowOff;

	public Transform Topics;

	public Texture X;

	public UISprite[] OpinionIcons;

	public UISprite[] TopicIcons;

	public UITexture[] MultiplierIcons;

	public UILabel[] ComplimentLabels;

	public UISprite[] ComplimentBGs;

	public UILabel MultiplierLabel;

	public UILabel SeductionLabel;

	public UILabel TopicNameLabel;

	public UILabel DialogueLabel;

	public UIPanel DatingSimHUD;

	public UILabel WisdomLabel;

	public UIPanel Panel;

	public UITexture[] GiftIcons;

	public UISprite[] TraitBGs;

	public UISprite[] GiftBGs;

	public UILabel[] Labels;

	public string[] OpinionSpriteNames;

	public string[] Compliments;

	public string[] TopicNames;

	public string[] GiveGifts;

	public string[] Greetings;

	public string[] Farewells;

	public string[] Negatives;

	public string[] Positives;

	public string[] ShowOffs;

	public bool[] ComplimentsGiven;

	public bool[] TopicsDiscussed;

	public bool[] GiftsPurchased;

	public bool[] GiftsGiven;

	public bool SuitorAndRivalTalking;

	public bool DataNeedsSaving;

	public bool SelectingTopic;

	public bool AffectionGrow;

	public bool Complimenting;

	public bool Matchmaking;

	public bool GivingGift;

	public bool ShowingOff;

	public bool Eighties;

	public bool Negative;

	public bool SlideOut;

	public bool Testing;

	public float HighlightTarget;

	public float Affection;

	public float Rotation;

	public float Speed;

	public float Timer;

	public int ComplimentSelected = 1;

	public int TraitSelected = 1;

	public int TopicSelected = 1;

	public int GiftSelected = 1;

	public int Selected = 1;

	public int AffectionLevel;

	public int Multiplier;

	public int Opinion;

	public int Phase = 1;

	public int WisdomTraitDemonstrated;

	public int WisdomTrait;

	public int GiftColumn = 1;

	public int GiftRow = 1;

	public int Column = 1;

	public int Row = 1;

	public int Side = 1;

	public int Line = 1;

	public string CurrentAnim = string.Empty;

	public Color OriginalColor;

	public Camera MainCamera;

	private void Start()
	{
		MainCamera = Camera.main;
		Affection = DatingGlobals.Affection;
		AffectionBar.localScale = new Vector3(Affection / 100f, AffectionBar.localScale.y, AffectionBar.localScale.z);
		CalculateAffection();
		OriginalColor = ComplimentBGs[1].color;
		ComplimentSet.localScale = Vector3.zero;
		GiveGift.localScale = Vector3.zero;
		ShowOff.localScale = Vector3.zero;
		Topics.localScale = Vector3.zero;
		DatingSimHUD.gameObject.SetActive(value: false);
		DatingSimHUD.alpha = 0f;
		for (int i = 1; i < 26; i++)
		{
			if (DatingGlobals.GetTopicDiscussed(i))
			{
				TopicsDiscussed[i] = true;
				UISprite uISprite = TopicIcons[i];
				uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, 0.5f);
			}
		}
		for (int j = 1; j < 11; j++)
		{
			if (DatingGlobals.GetComplimentGiven(j))
			{
				ComplimentsGiven[j] = true;
				UILabel uILabel = ComplimentLabels[j];
				uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
			}
		}
		UpdateComplimentHighlight();
		UpdateTraitHighlight();
		UpdateGiftHighlight();
		Eighties = GameGlobals.Eighties;
	}

	private void CalculateAffection()
	{
		if (Affection > 100f)
		{
			Affection = 100f;
		}
		if (Affection == 0f)
		{
			AffectionLevel = 0;
		}
		else if (Affection < 25f)
		{
			AffectionLevel = 1;
		}
		else if (Affection < 50f)
		{
			AffectionLevel = 2;
		}
		else if (Affection < 75f)
		{
			AffectionLevel = 3;
		}
		else if (Affection < 100f)
		{
			AffectionLevel = 4;
		}
		else
		{
			AffectionLevel = 5;
		}
	}

	private void Update()
	{
		if (Testing)
		{
			Prompt.enabled = true;
		}
		else if (LoveManager.RivalWaiting)
		{
			if (Rival == null)
			{
				Suitor = StudentManager.Students[LoveManager.SuitorID];
				Rival = StudentManager.Students[LoveManager.RivalID];
			}
			if (Rival.MeetTimer > 0f && Suitor.MeetTimer > 0f)
			{
				if (!Eighties)
				{
					Prompt.enabled = true;
				}
				else if (!SuitorAndRivalTalking)
				{
					Debug.Log("DatingMinigameScript is now setting SuitorAndRivalTalking to ''true''.");
					Suitor.CurrentDestination = Rival.transform;
					Suitor.Pathfinding.target = Rival.transform;
					Suitor.DistractionTarget = Rival;
					Suitor.TargetDistance = 1f;
					Suitor.DistractTimer = 10f;
					Suitor.Distracting = true;
					Suitor.Routine = false;
					Suitor.Pathfinding.canSearch = true;
					Suitor.Pathfinding.canMove = true;
					Rival.Pathfinding.canSearch = false;
					Rival.Pathfinding.canMove = false;
					Suitor.Meeting = false;
					Rival.Meeting = false;
					Suitor.MeetTimer = 0f;
					Rival.MeetTimer = 0f;
					SuitorAndRivalTalking = true;
				}
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Yandere.Chased && Yandere.Chasers == 0 && !Rival.Hunted)
			{
				Yandere.CameraEffects.UpdateDOF(1f);
				Suitor.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Suitor.CharacterAnimation.enabled = true;
				Rival.CharacterAnimation.enabled = true;
				Suitor.enabled = false;
				Rival.enabled = false;
				Rival.CharacterAnimation["f02_smile_00"].layer = 1;
				Rival.CharacterAnimation.Play("f02_smile_00");
				Rival.CharacterAnimation["f02_smile_00"].weight = 0f;
				StudentManager.Clock.StopTime = true;
				Yandere.RPGCamera.enabled = false;
				HeartbeatCamera.SetActive(value: false);
				Yandere.Headset.SetActive(value: true);
				Yandere.CanMove = false;
				Yandere.EmptyHands();
				if (Yandere.YandereVision)
				{
					Yandere.ResetYandereEffects();
					Yandere.YandereVision = false;
				}
				Yandere.transform.position = PeekSpot.position;
				Yandere.transform.eulerAngles = PeekSpot.eulerAngles;
				Yandere.CharacterAnimation.Play("f02_treePeeking_00");
				MainCamera.transform.position = new Vector3(48f, 3f, -44f);
				MainCamera.transform.eulerAngles = new Vector3(15f, 90f, 0f);
				WisdomTrait = DatingGlobals.GetSuitorTrait(2);
				WisdomTraitDemonstrated = DatingGlobals.GetTraitDemonstrated(2);
				WisdomLabel.text = "Wisdom: " + WisdomTrait;
				GiftIcons[1].enabled = CollectibleGlobals.GetGiftPurchased(6);
				GiftIcons[2].enabled = CollectibleGlobals.GetGiftPurchased(7);
				GiftIcons[3].enabled = CollectibleGlobals.GetGiftPurchased(8);
				GiftIcons[4].enabled = CollectibleGlobals.GetGiftPurchased(9);
				GiftsPurchased[1] = CollectibleGlobals.GetGiftPurchased(6);
				GiftsPurchased[2] = CollectibleGlobals.GetGiftPurchased(7);
				GiftsPurchased[3] = CollectibleGlobals.GetGiftPurchased(8);
				GiftsPurchased[4] = CollectibleGlobals.GetGiftPurchased(9);
				GiftsGiven[1] = CollectibleGlobals.GetGiftGiven(1);
				GiftsGiven[2] = CollectibleGlobals.GetGiftGiven(2);
				GiftsGiven[3] = CollectibleGlobals.GetGiftGiven(3);
				GiftsGiven[4] = CollectibleGlobals.GetGiftGiven(4);
				Matchmaking = true;
				UpdateTopics();
				Time.timeScale = 1f;
			}
		}
		if (!Matchmaking)
		{
			return;
		}
		if (CurrentAnim != string.Empty && Rival.CharacterAnimation[CurrentAnim].time >= Rival.CharacterAnimation[CurrentAnim].length)
		{
			Rival.CharacterAnimation.Play(Rival.IdleAnim);
		}
		if (Phase == 1)
		{
			Panel.alpha = Mathf.MoveTowards(Panel.alpha, 0f, Time.deltaTime);
			Timer += Time.deltaTime;
			MainCamera.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(54f, 1.25f, -45.25f), Timer * 0.02f);
			MainCamera.transform.eulerAngles = Vector3.Lerp(MainCamera.transform.eulerAngles, new Vector3(0f, 45f, 0f), Timer * 0.02f);
			if (Timer > 5f)
			{
				Yandere.CameraEffects.UpdateDOF(0.6f);
				Suitor.CharacterAnimation.Play("insertEarpiece_00");
				Suitor.CharacterAnimation["insertEarpiece_00"].time = 0f;
				Suitor.CharacterAnimation.Play("insertEarpiece_00");
				Suitor.Earpiece.SetActive(value: true);
				MainCamera.transform.position = new Vector3(45.5f, 1.25f, -44.5f);
				MainCamera.transform.eulerAngles = new Vector3(0f, -45f, 0f);
				Rotation = -45f;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			Timer += Time.deltaTime;
			if (Timer > 4f)
			{
				Suitor.Earpiece.transform.parent = Suitor.Head;
				Suitor.Earpiece.transform.localPosition = new Vector3(0f, -1.12f, 1.14f);
				Suitor.Earpiece.transform.localEulerAngles = new Vector3(45f, -180f, 0f);
				MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, new Vector3(45.11f, 1.375f, -44f), (Timer - 4f) * 0.02f);
				Rotation = Mathf.Lerp(Rotation, 90f, (Timer - 4f) * 0.02f);
				MainCamera.transform.eulerAngles = new Vector3(MainCamera.transform.eulerAngles.x, Rotation, MainCamera.transform.eulerAngles.z);
				if (Rotation > 89.9f)
				{
					Yandere.CameraEffects.UpdateDOF(0.75f);
					Rival.CharacterAnimation["f02_turnAround_00"].time = 0f;
					Rival.CharacterAnimation.CrossFade("f02_turnAround_00");
					AffectionBar.localScale = new Vector3(Affection / 100f, AffectionBar.localScale.y, AffectionBar.localScale.z);
					DialogueLabel.text = Greetings[AffectionLevel];
					CalculateMultiplier();
					DatingSimHUD.gameObject.SetActive(value: true);
					Timer = 0f;
					Phase++;
				}
			}
		}
		else if (Phase == 3)
		{
			DatingSimHUD.alpha = Mathf.MoveTowards(DatingSimHUD.alpha, 1f, Time.deltaTime);
			if (Rival.CharacterAnimation["f02_turnAround_00"].time >= Rival.CharacterAnimation["f02_turnAround_00"].length)
			{
				Rival.transform.eulerAngles = new Vector3(Rival.transform.eulerAngles.x, -90f, Rival.transform.eulerAngles.z);
				Rival.CharacterAnimation.Play("f02_turnAround_00");
				Rival.CharacterAnimation["f02_turnAround_00"].time = 0f;
				Rival.CharacterAnimation["f02_turnAround_00"].speed = 0f;
				Rival.CharacterAnimation.Play("f02_turnAround_00");
				Rival.CharacterAnimation.CrossFade(Rival.IdleAnim);
				Time.timeScale = 1f;
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Confirm";
				PromptBar.Label[1].text = "Back";
				PromptBar.Label[4].text = "Select";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			if (AffectionGrow)
			{
				Affection = Mathf.MoveTowards(Affection, 100f, Time.deltaTime * 10f);
				CalculateAffection();
			}
			Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", Affection * 0.01f);
			Rival.CharacterAnimation["f02_smile_00"].weight = Affection * 0.01f;
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, Mathf.Lerp(Highlight.localPosition.y, HighlightTarget, Time.deltaTime * 10f), Highlight.localPosition.z);
			for (int i = 1; i < Options.Length; i++)
			{
				Transform transform = Options[i];
				transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, (i == Selected) ? 750f : 800f, Time.deltaTime * 10f), transform.localPosition.y, transform.localPosition.z);
			}
			AffectionBar.localScale = new Vector3(Mathf.Lerp(AffectionBar.localScale.x, Affection / 100f, Time.deltaTime * 10f), AffectionBar.localScale.y, AffectionBar.localScale.z);
			if (!SelectingTopic && !Complimenting && !ShowingOff && !GivingGift)
			{
				Topics.localScale = Vector3.Lerp(Topics.localScale, Vector3.zero, Time.deltaTime * 10f);
				ComplimentSet.localScale = Vector3.Lerp(ComplimentSet.localScale, Vector3.zero, Time.deltaTime * 10f);
				ShowOff.localScale = Vector3.Lerp(ShowOff.localScale, Vector3.zero, Time.deltaTime * 10f);
				GiveGift.localScale = Vector3.Lerp(GiveGift.localScale, Vector3.zero, Time.deltaTime * 10f);
				if (InputManager.TappedUp)
				{
					Selected--;
					UpdateHighlight();
				}
				if (InputManager.TappedDown)
				{
					Selected++;
					UpdateHighlight();
				}
				if (Input.GetButtonDown("A") && Labels[Selected].color.a == 1f)
				{
					if (Selected == 1)
					{
						SelectingTopic = true;
						Negative = true;
					}
					else if (Selected == 2)
					{
						SelectingTopic = true;
						Negative = false;
					}
					else if (Selected == 3)
					{
						Complimenting = true;
					}
					else if (Selected == 4)
					{
						ShowingOff = true;
					}
					else if (Selected == 5)
					{
						GivingGift = true;
					}
					else if (Selected == 6)
					{
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Confirm";
						PromptBar.UpdateButtons();
						CalculateAffection();
						DialogueLabel.text = Farewells[AffectionLevel];
						Phase++;
					}
				}
			}
			else if (SelectingTopic)
			{
				Topics.localScale = Vector3.Lerp(Topics.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				if (InputManager.TappedUp)
				{
					Row--;
					UpdateTopicHighlight();
				}
				else if (InputManager.TappedDown)
				{
					Row++;
					UpdateTopicHighlight();
				}
				if (InputManager.TappedLeft)
				{
					Column--;
					UpdateTopicHighlight();
				}
				else if (InputManager.TappedRight)
				{
					Column++;
					UpdateTopicHighlight();
				}
				if (Input.GetButtonDown("A") && TopicIcons[TopicSelected].color.a == 1f)
				{
					SelectingTopic = false;
					UISprite uISprite = TopicIcons[TopicSelected];
					uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, 0.5f);
					TopicsDiscussed[TopicSelected] = true;
					DetermineOpinion();
					if (!ConversationGlobals.GetTopicLearnedByStudent(Opinion, LoveManager.RivalID))
					{
						ConversationGlobals.SetTopicLearnedByStudent(Opinion, LoveManager.RivalID, value: true);
					}
					if (Negative)
					{
						UILabel uILabel = Labels[1];
						uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
						if (Opinion == 2)
						{
							DialogueLabel.text = "Hey! Just so you know, I take offense to that...";
							Rival.CharacterAnimation.CrossFade("f02_refuse_00");
							CurrentAnim = "f02_refuse_00";
							Affection -= 1f;
							CalculateAffection();
						}
						else if (Opinion == 1)
						{
							DialogueLabel.text = Negatives[AffectionLevel];
							Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
							CurrentAnim = "f02_lookdown_00";
							Affection += Multiplier;
							CalculateAffection();
						}
						else if (Opinion == 0)
						{
							DialogueLabel.text = "Um...okay.";
						}
					}
					else
					{
						UILabel uILabel2 = Labels[2];
						uILabel2.color = new Color(uILabel2.color.r, uILabel2.color.g, uILabel2.color.b, 0.5f);
						if (Opinion == 2)
						{
							DialogueLabel.text = Positives[AffectionLevel];
							Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
							CurrentAnim = "f02_lookdown_00";
							Affection += Multiplier;
							CalculateAffection();
						}
						else if (Opinion == 1)
						{
							DialogueLabel.text = "To be honest with you, I strongly disagree...";
							Rival.CharacterAnimation.CrossFade("f02_refuse_00");
							CurrentAnim = "f02_refuse_00";
							Affection -= 1f;
							CalculateAffection();
						}
						else if (Opinion == 0)
						{
							DialogueLabel.text = "Um...all right.";
						}
					}
					if (Affection > 100f)
					{
						Affection = 100f;
					}
					else if (Affection < 0f)
					{
						Affection = 0f;
					}
				}
				if (Input.GetButtonDown("B"))
				{
					SelectingTopic = false;
				}
			}
			else if (Complimenting)
			{
				ComplimentSet.localScale = Vector3.Lerp(ComplimentSet.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				if (InputManager.TappedUp)
				{
					Line--;
					UpdateComplimentHighlight();
				}
				else if (InputManager.TappedDown)
				{
					Line++;
					UpdateComplimentHighlight();
				}
				if (InputManager.TappedLeft)
				{
					Side--;
					UpdateComplimentHighlight();
				}
				else if (InputManager.TappedRight)
				{
					Side++;
					UpdateComplimentHighlight();
				}
				if (Input.GetButtonDown("A") && ComplimentLabels[ComplimentSelected].color.a == 1f)
				{
					UILabel uILabel3 = Labels[3];
					uILabel3.color = new Color(uILabel3.color.r, uILabel3.color.g, uILabel3.color.b, 0.5f);
					Complimenting = false;
					DialogueLabel.text = Compliments[ComplimentSelected];
					ComplimentsGiven[ComplimentSelected] = true;
					if (ComplimentSelected == 1 || ComplimentSelected == 4 || ComplimentSelected == 5 || ComplimentSelected == 8 || ComplimentSelected == 9)
					{
						Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
						CurrentAnim = "f02_lookdown_00";
						Affection += Multiplier;
						CalculateAffection();
					}
					else
					{
						Rival.CharacterAnimation.CrossFade("f02_refuse_00");
						CurrentAnim = "f02_refuse_00";
						Affection -= 1f;
						CalculateAffection();
					}
					if (Affection > 100f)
					{
						Affection = 100f;
					}
					else if (Affection < 0f)
					{
						Affection = 0f;
					}
				}
				if (Input.GetButtonDown("B"))
				{
					Complimenting = false;
				}
			}
			else if (ShowingOff)
			{
				ShowOff.localScale = Vector3.Lerp(ShowOff.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				if (InputManager.TappedUp)
				{
					TraitSelected--;
					UpdateTraitHighlight();
				}
				else if (InputManager.TappedDown)
				{
					TraitSelected++;
					UpdateTraitHighlight();
				}
				if (Input.GetButtonDown("A"))
				{
					UILabel uILabel4 = Labels[4];
					uILabel4.color = new Color(uILabel4.color.r, uILabel4.color.g, uILabel4.color.b, 0.5f);
					ShowingOff = false;
					if (TraitSelected == 2)
					{
						Debug.Log("Wisdom trait is " + WisdomTrait + ". Wisdom Demonstrated is " + WisdomTraitDemonstrated + ".");
						if (WisdomTrait > WisdomTraitDemonstrated)
						{
							WisdomTraitDemonstrated++;
							DialogueLabel.text = ShowOffs[AffectionLevel];
							Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
							CurrentAnim = "f02_lookdown_00";
							Affection += Multiplier;
							CalculateAffection();
						}
						else if (WisdomTrait == 0)
						{
							DialogueLabel.text = "Uh...that doesn't sound correct...";
						}
						else if (WisdomTrait == WisdomTraitDemonstrated)
						{
							DialogueLabel.text = "Uh...you already told me about that...";
						}
					}
					else
					{
						DialogueLabel.text = "Um...well...that sort of thing doesn't really matter to me...";
					}
					if (Affection > 100f)
					{
						Affection = 100f;
					}
					else if (Affection < 0f)
					{
						Affection = 0f;
					}
				}
				if (Input.GetButtonDown("B"))
				{
					ShowingOff = false;
				}
			}
			else if (GivingGift)
			{
				GiveGift.localScale = Vector3.Lerp(GiveGift.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				if (InputManager.TappedUp)
				{
					GiftRow--;
					UpdateGiftHighlight();
				}
				else if (InputManager.TappedDown)
				{
					GiftRow++;
					UpdateGiftHighlight();
				}
				if (InputManager.TappedLeft)
				{
					GiftColumn--;
					UpdateGiftHighlight();
				}
				else if (InputManager.TappedRight)
				{
					GiftColumn++;
					UpdateGiftHighlight();
				}
				if (Input.GetButtonDown("A"))
				{
					if (GiftIcons[GiftSelected].enabled)
					{
						GiftsPurchased[GiftSelected] = false;
						GiftsGiven[GiftSelected] = true;
						Rival.Cosmetic.CatGifts[GiftSelected].SetActive(value: true);
						UILabel uILabel5 = Labels[5];
						uILabel5.color = new Color(uILabel5.color.r, uILabel5.color.g, uILabel5.color.b, 0.5f);
						GivingGift = false;
						DialogueLabel.text = GiveGifts[GiftSelected];
						Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
						CurrentAnim = "f02_lookdown_00";
						Affection += Multiplier;
						CalculateAffection();
					}
					if (Affection > 100f)
					{
						Affection = 100f;
					}
					else if (Affection < 0f)
					{
						Affection = 0f;
					}
				}
				if (Input.GetButtonDown("B"))
				{
					GivingGift = false;
				}
			}
		}
		else if (Phase == 5)
		{
			Speed += Time.deltaTime * 100f;
			AffectionSet.localPosition = new Vector3(AffectionSet.localPosition.x, AffectionSet.localPosition.y + Speed, AffectionSet.localPosition.z);
			OptionSet.localPosition = new Vector3(OptionSet.localPosition.x + Speed, OptionSet.localPosition.y, OptionSet.localPosition.z);
			if (Speed > 100f && Input.GetButtonDown("A"))
			{
				Phase++;
			}
		}
		else if (Phase == 6)
		{
			DatingSimHUD.alpha = Mathf.MoveTowards(DatingSimHUD.alpha, 0f, Time.deltaTime);
			if (DatingSimHUD.alpha == 0f)
			{
				DatingSimHUD.gameObject.SetActive(value: false);
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			if (Panel.alpha == 0f)
			{
				Yandere.CameraEffects.UpdateDOF(2f);
				Suitor.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
				LoveManager.RivalWaiting = false;
				LoveManager.Courted = true;
				Suitor.enabled = true;
				Rival.enabled = true;
				Suitor.CurrentDestination = Suitor.Destinations[Suitor.Phase];
				Suitor.Pathfinding.target = Suitor.Destinations[Suitor.Phase];
				Suitor.Prompt.Label[0].text = "     Talk";
				Suitor.Pathfinding.canSearch = true;
				Suitor.Pathfinding.canMove = true;
				Suitor.Pushable = false;
				Suitor.Meeting = false;
				Suitor.Routine = true;
				Suitor.MeetTimer = 0f;
				Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
				Rival.CurrentDestination = Rival.Destinations[Rival.Phase];
				Rival.Pathfinding.target = Rival.Destinations[Rival.Phase];
				Rival.CharacterAnimation["f02_smile_00"].weight = 0f;
				Rival.Prompt.Label[0].text = "     Talk";
				Rival.Pathfinding.canSearch = true;
				Rival.Pathfinding.canMove = true;
				Rival.DistanceToDestination = 100f;
				Rival.Pushable = false;
				Rival.Meeting = false;
				Rival.Routine = true;
				Rival.MeetTimer = 0f;
				StudentManager.Clock.StopTime = false;
				Yandere.RPGCamera.enabled = true;
				Suitor.Earpiece.SetActive(value: false);
				HeartbeatCamera.SetActive(value: true);
				Yandere.Headset.SetActive(value: false);
				if (AffectionLevel == 5)
				{
					LoveManager.ConfessToSuitor = true;
				}
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				if (StudentManager.Students[10] != null)
				{
					StudentManager.Students[10].CurrentDestination = StudentManager.Students[10].FollowTarget.transform;
					StudentManager.Students[10].Pathfinding.target = StudentManager.Students[10].FollowTarget.transform;
				}
				DataNeedsSaving = true;
			}
			else if (Panel.alpha == 1f)
			{
				Matchmaking = false;
				Yandere.CanMove = true;
				base.gameObject.SetActive(value: false);
			}
			Panel.alpha = Mathf.MoveTowards(Panel.alpha, 1f, Time.deltaTime);
		}
		if (Yandere.NoDebug)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Yandere.CharacterAnimation["f02_treePeeking_00"].time = 0f;
			Yandere.CharacterAnimation.Play("f02_treePeeking_00");
			MainCamera.transform.position = new Vector3(48f, 3f, -44f);
			MainCamera.transform.eulerAngles = new Vector3(15f, 90f, 0f);
			Rival.transform.eulerAngles = new Vector3(Rival.transform.eulerAngles.x, 90f, Rival.transform.eulerAngles.z);
			Rival.CharacterAnimation.Play(Rival.IdleAnim);
			Rival.CharacterAnimation["f02_turnAround_00"].speed = 1f;
			DatingGlobals.SetComplimentGiven(1, value: false);
			DatingGlobals.SetComplimentGiven(4, value: false);
			DatingGlobals.SetComplimentGiven(5, value: false);
			DatingGlobals.SetComplimentGiven(8, value: false);
			DatingGlobals.SetComplimentGiven(9, value: false);
			DatingGlobals.SetTraitDemonstrated(2, 0);
			DatingGlobals.AffectionLevel = 0f;
			DatingGlobals.Affection = 0f;
			AffectionBar.localScale = new Vector3(0f, AffectionBar.localScale.y, AffectionBar.localScale.z);
			AffectionLevel = 0;
			Affection = 0f;
			for (int j = 1; j < 6; j++)
			{
				UILabel uILabel6 = Labels[j];
				uILabel6.color = new Color(uILabel6.color.r, uILabel6.color.g, uILabel6.color.b, 1f);
			}
			Phase = 1;
			Timer = 0f;
			for (int k = 1; k < 26; k++)
			{
				DatingGlobals.SetTopicDiscussed(k, value: false);
				UISprite uISprite2 = TopicIcons[k];
				uISprite2.color = new Color(uISprite2.color.r, uISprite2.color.g, uISprite2.color.b, 1f);
			}
			UpdateTopics();
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			Affection += 10f;
			CalculateAffection();
			DialogueLabel.text = Greetings[AffectionLevel];
		}
	}

	private void LateUpdate()
	{
		_ = Phase;
		_ = 4;
	}

	private void CalculateMultiplier()
	{
		Multiplier = 5;
		if (!Suitor.Cosmetic.MaleHair[55].activeInHierarchy)
		{
			MultiplierIcons[1].mainTexture = X;
			Multiplier--;
		}
		if (!Suitor.Cosmetic.MaleAccessories[17].activeInHierarchy)
		{
			MultiplierIcons[2].mainTexture = X;
			Multiplier--;
		}
		if (!Suitor.Cosmetic.Eyewear[6].activeInHierarchy)
		{
			MultiplierIcons[3].mainTexture = X;
			Multiplier--;
		}
		if (Suitor.Cosmetic.SkinColor != 6)
		{
			MultiplierIcons[4].mainTexture = X;
			Multiplier--;
		}
		if (PlayerGlobals.PantiesEquipped == 2)
		{
			PantyIcon.SetActive(value: true);
			Multiplier++;
		}
		else
		{
			PantyIcon.SetActive(value: false);
		}
		if (Yandere.Class.Seduction + Yandere.Class.SeductionBonus > 0)
		{
			SeductionLabel.text = (Yandere.Class.Seduction + Yandere.Class.SeductionBonus).ToString();
			Multiplier += Yandere.Class.Seduction + Yandere.Class.SeductionBonus;
			SeductionIcon.SetActive(value: true);
		}
		else
		{
			SeductionIcon.SetActive(value: false);
		}
		Multiplier += Yandere.Class.PsychologyGrade + Yandere.Class.PsychologyBonus;
		MultiplierLabel.text = "Multiplier: " + Multiplier + "x";
	}

	private void UpdateHighlight()
	{
		if (Selected < 1)
		{
			Selected = 6;
		}
		else if (Selected > 6)
		{
			Selected = 1;
		}
		HighlightTarget = 450f - 100f * (float)Selected;
	}

	private void UpdateTopicHighlight()
	{
		if (Row < 1)
		{
			Row = 5;
		}
		else if (Row > 5)
		{
			Row = 1;
		}
		if (Column < 1)
		{
			Column = 5;
		}
		else if (Column > 5)
		{
			Column = 1;
		}
		TopicHighlight.localPosition = new Vector3(-375 + 125 * Column, 375 - 125 * Row, TopicHighlight.localPosition.z);
		TopicSelected = (Row - 1) * 5 + Column;
		TopicNameLabel.text = (ConversationGlobals.GetTopicDiscovered(TopicSelected) ? TopicNames[TopicSelected] : "??????????");
	}

	private void DetermineOpinion()
	{
		int[] topics = JSON.Topics[LoveManager.RivalID].Topics;
		Opinion = topics[TopicSelected];
	}

	private void UpdateTopics()
	{
		for (int i = 1; i < TopicIcons.Length; i++)
		{
			UISprite uISprite = TopicIcons[i];
			if (!ConversationGlobals.GetTopicDiscovered(i))
			{
				uISprite.spriteName = 0.ToString();
				uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, 0.5f);
			}
			else
			{
				uISprite.spriteName = i.ToString();
			}
		}
		for (int j = 1; j <= 25; j++)
		{
			UISprite uISprite2 = OpinionIcons[j];
			if (!ConversationGlobals.GetTopicLearnedByStudent(j, LoveManager.RivalID))
			{
				uISprite2.spriteName = "Unknown";
				continue;
			}
			int[] topics = JSON.Topics[LoveManager.RivalID].Topics;
			uISprite2.spriteName = OpinionSpriteNames[topics[j]];
		}
	}

	private void UpdateComplimentHighlight()
	{
		for (int i = 1; i < TopicIcons.Length; i++)
		{
			ComplimentBGs[ComplimentSelected].color = OriginalColor;
		}
		if (Line < 1)
		{
			Line = 5;
		}
		else if (Line > 5)
		{
			Line = 1;
		}
		if (Side < 1)
		{
			Side = 2;
		}
		else if (Side > 2)
		{
			Side = 1;
		}
		ComplimentSelected = (Line - 1) * 2 + Side;
		ComplimentBGs[ComplimentSelected].color = Color.white;
	}

	private void UpdateTraitHighlight()
	{
		if (TraitSelected < 1)
		{
			TraitSelected = 3;
		}
		else if (TraitSelected > 3)
		{
			TraitSelected = 1;
		}
		for (int i = 1; i < TraitBGs.Length; i++)
		{
			TraitBGs[i].color = OriginalColor;
		}
		TraitBGs[TraitSelected].color = Color.white;
	}

	private void UpdateGiftHighlight()
	{
		for (int i = 1; i < GiftBGs.Length; i++)
		{
			GiftBGs[i].color = OriginalColor;
		}
		if (GiftRow < 1)
		{
			GiftRow = 2;
		}
		else if (GiftRow > 2)
		{
			GiftRow = 1;
		}
		if (GiftColumn < 1)
		{
			GiftColumn = 2;
		}
		else if (GiftColumn > 2)
		{
			GiftColumn = 1;
		}
		GiftSelected = (GiftRow - 1) * 2 + GiftColumn;
		GiftBGs[GiftSelected].color = Color.white;
	}

	public void SaveTopicsAndCompliments()
	{
		for (int i = 1; i < 26; i++)
		{
			DatingGlobals.SetTopicDiscussed(i, TopicsDiscussed[i]);
		}
		for (int j = 1; j < 11; j++)
		{
			DatingGlobals.SetComplimentGiven(j, ComplimentsGiven[j]);
		}
		DatingGlobals.SetTraitDemonstrated(2, WisdomTraitDemonstrated);
		for (int k = 1; k < 5; k++)
		{
			CollectibleGlobals.SetGiftPurchased(k + 5, GiftsPurchased[k]);
			CollectibleGlobals.SetGiftGiven(k, GiftsGiven[k]);
		}
		DatingGlobals.Affection = Affection;
		Debug.Log("Saving Dating Minigame data.");
	}
}
