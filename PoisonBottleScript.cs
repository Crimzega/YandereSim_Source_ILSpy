using UnityEngine;

public class PoisonBottleScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Theft;

	public int ID;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		if (Theft)
		{
			Prompt.Yandere.TheftTimer = 0.1f;
		}
		if (ID == 1)
		{
			Prompt.Yandere.Inventory.EmeticPoison = true;
		}
		else if (ID == 2)
		{
			Prompt.Yandere.Inventory.LethalPoison = true;
			Prompt.Yandere.Inventory.LethalPoisons++;
		}
		else if (ID == 3)
		{
			if (!Prompt.Yandere.Inventory.RatPoison)
			{
				Prompt.Yandere.Inventory.RatPoison = true;
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "You're already carrying some of that";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		else if (ID == 4)
		{
			Prompt.Yandere.Inventory.HeadachePoison = true;
		}
		else if (ID == 5)
		{
			Prompt.Yandere.Inventory.Tranquilizer = true;
		}
		else if (ID == 6)
		{
			Prompt.Yandere.Inventory.Sedative = true;
		}
		Prompt.Yandere.StudentManager.UpdateAllBentos();
		Object.Destroy(base.gameObject);
	}
}
