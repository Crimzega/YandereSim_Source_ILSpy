using UnityEngine;

public class InventoryMenuScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public InventoryScript Inventory;

	public UILabel[] Labels;

	public void UpdateLabels()
	{
		Labels[0].alpha = ((!Inventory.ModifiedUniform) ? 0.75f : 1f);
		Labels[1].alpha = ((!Inventory.DirectionalMic) ? 0.75f : 1f);
		Labels[2].alpha = ((!Inventory.DuplicateSheet) ? 0.75f : 1f);
		Labels[3].alpha = ((!Inventory.AnswerSheet) ? 0.75f : 1f);
		Labels[4].alpha = ((!Inventory.MaskingTape) ? 0.75f : 1f);
		Labels[5].alpha = ((!Inventory.RivalPhone) ? 0.75f : 1f);
		Labels[6].alpha = ((!Inventory.LockPick) ? 0.75f : 1f);
		Labels[7].alpha = ((!Inventory.Headset) ? 0.75f : 1f);
		Labels[8].alpha = ((!Inventory.FakeID) ? 0.75f : 1f);
		Labels[9].alpha = ((!Inventory.IDCard) ? 0.75f : 1f);
		Labels[10].alpha = ((!Inventory.Book) ? 0.75f : 1f);
		Labels[11].alpha = ((!Inventory.LethalPoison) ? 0.75f : 1f);
		Labels[12].alpha = ((!Inventory.ChemicalPoison) ? 0.75f : 1f);
		Labels[13].alpha = ((!Inventory.EmeticPoison) ? 0.75f : 1f);
		Labels[14].alpha = ((!Inventory.RatPoison) ? 0.75f : 1f);
		Labels[15].alpha = ((!Inventory.HeadachePoison) ? 0.75f : 1f);
		Labels[16].alpha = ((!Inventory.Tranquilizer) ? 0.75f : 1f);
		Labels[17].alpha = ((!Inventory.Sedative) ? 0.75f : 1f);
		Labels[18].alpha = ((!Inventory.Cigs) ? 0.75f : 1f);
		Labels[19].alpha = ((!Inventory.Ring) ? 0.75f : 1f);
		Labels[20].alpha = ((!Inventory.Sake) ? 0.75f : 1f);
		Labels[21].alpha = ((!Inventory.Soda) ? 0.75f : 1f);
		Labels[22].alpha = ((!Inventory.Bra) ? 0.75f : 1f);
		Labels[23].alpha = ((!Inventory.CabinetKey) ? 0.75f : 1f);
		Labels[24].alpha = ((!Inventory.CaseKey) ? 0.75f : 1f);
		Labels[25].alpha = ((!Inventory.SafeKey) ? 0.75f : 1f);
		Labels[26].alpha = ((!Inventory.ShedKey) ? 0.75f : 1f);
	}

	private void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			PauseScreen.MainMenu.SetActive(value: true);
			base.gameObject.SetActive(value: false);
		}
	}
}
