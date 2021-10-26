using UnityEngine;

public class VendingMachineScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Transform CanSpawn;

	public GameObject[] Cans;

	public bool SnackMachine;

	public bool Sabotaged;

	public int Price;

	private void Start()
	{
		if (SnackMachine)
		{
			Prompt.Text[0] = "Buy Snack for $" + Price + ".00";
		}
		else
		{
			Prompt.Text[0] = "Buy Drink for $" + Price + ".00";
		}
		Prompt.Label[0].text = "     " + Prompt.Text[0];
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (Prompt.Yandere.Inventory.Money >= (float)Price)
		{
			if (!Sabotaged)
			{
				Object.Instantiate(Cans[Random.Range(0, Cans.Length)], CanSpawn.position, CanSpawn.rotation).GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
			}
			if (SnackMachine && SchemeGlobals.GetSchemeStage(4) == 3)
			{
				SchemeGlobals.SetSchemeStage(4, 4);
				Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
			}
			Prompt.Yandere.Inventory.Money -= Price;
			Prompt.Yandere.Inventory.UpdateMoney();
		}
		else
		{
			Prompt.Yandere.StudentManager.TutorialWindow.ShowMoneyMessage = true;
			Prompt.Yandere.NotificationManager.CustomText = "Not enough money!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}
}
