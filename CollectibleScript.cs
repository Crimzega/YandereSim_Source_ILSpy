using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
	public PromptScript Prompt;

	public string Name = string.Empty;

	public int Type;

	public int ID;

	public CollectibleType CollectibleType
	{
		get
		{
			if (Name == "HeadmasterTape")
			{
				return CollectibleType.HeadmasterTape;
			}
			if (Name == "BasementTape")
			{
				return CollectibleType.BasementTape;
			}
			if (Name == "Manga")
			{
				return CollectibleType.Manga;
			}
			if (Name == "Tape")
			{
				return CollectibleType.Tape;
			}
			if (Type == 5)
			{
				return CollectibleType.Key;
			}
			if (Type == 6)
			{
				return CollectibleType.Panty;
			}
			Debug.LogError("Unrecognized collectible \"" + Name + "\".", base.gameObject);
			return CollectibleType.Tape;
		}
	}

	private void Start()
	{
		if ((CollectibleType == CollectibleType.BasementTape && CollectibleGlobals.GetBasementTapeCollected(ID)) || (CollectibleType == CollectibleType.Manga && CollectibleGlobals.GetMangaCollected(ID)) || (CollectibleType == CollectibleType.Tape && CollectibleGlobals.GetTapeCollected(ID)) || (CollectibleType == CollectibleType.Panty && CollectibleGlobals.GetPantyPurchased(11)))
		{
			Object.Destroy(base.gameObject);
		}
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || (GameGlobals.Eighties && CollectibleType == CollectibleType.Manga) || (GameGlobals.Eighties && CollectibleType == CollectibleType.Tape))
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (CollectibleType == CollectibleType.HeadmasterTape)
			{
				Prompt.Yandere.StudentManager.HeadmasterTapesCollected[ID] = true;
			}
			else if (CollectibleType == CollectibleType.BasementTape)
			{
				CollectibleGlobals.SetBasementTapeCollected(ID, value: true);
			}
			else if (CollectibleType == CollectibleType.Manga)
			{
				Prompt.Yandere.StudentManager.MangaCollected[ID] = true;
			}
			else if (CollectibleType == CollectibleType.Tape)
			{
				Prompt.Yandere.StudentManager.TapesCollected[ID] = true;
			}
			else if (CollectibleType == CollectibleType.Key)
			{
				Prompt.Yandere.Inventory.MysteriousKeys++;
			}
			else if (CollectibleType == CollectibleType.Panty)
			{
				Prompt.Yandere.StudentManager.PantiesCollected[11] = true;
				CountPanties();
			}
			else
			{
				Debug.LogError("Collectible \"" + Name + "\" not implemented.", base.gameObject);
			}
			Object.Destroy(base.gameObject);
		}
	}

	private void CountPanties()
	{
		int num = 1;
		for (int i = 1; i < 11; i++)
		{
			if (CollectibleGlobals.GetPantyPurchased(i))
			{
				num++;
			}
		}
		if (num == 10)
		{
			PlayerPrefs.SetInt("PantyQueen", 1);
		}
	}
}
