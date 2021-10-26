using UnityEngine;

public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	public PromptScript Prompt;

	public int ID;

	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(ID))
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.StudentManager.Police.EndOfDay.ShrineItemsCollected++;
			Prompt.Yandere.Inventory.ShrineCollectibles[ID] = true;
			Prompt.Hide();
			Object.Destroy(base.gameObject);
		}
	}
}
