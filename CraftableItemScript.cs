using UnityEngine;

public class CraftableItemScript : MonoBehaviour
{
	public PromptScript Prompt;

	public int ID;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			switch (ID)
			{
			case 1:
				Prompt.Yandere.Inventory.Ammonium = true;
				break;
			case 2:
				Prompt.Yandere.Inventory.Balloons = true;
				break;
			case 3:
				Prompt.Yandere.Inventory.Bandages = true;
				break;
			case 4:
				Prompt.Yandere.Inventory.Glass = true;
				break;
			case 5:
				Prompt.Yandere.Inventory.Hairpins = true;
				break;
			case 6:
				Prompt.Yandere.Inventory.Nails = true;
				break;
			case 7:
				Prompt.Yandere.Inventory.Paper = true;
				break;
			case 8:
				Prompt.Yandere.Inventory.PaperClips = true;
				break;
			case 9:
				Prompt.Yandere.Inventory.SilverFulminate = true;
				break;
			case 10:
				Prompt.Yandere.Inventory.WoodenSticks = true;
				break;
			}
			Prompt.Hide();
			Object.Destroy(base.gameObject);
		}
	}
}
