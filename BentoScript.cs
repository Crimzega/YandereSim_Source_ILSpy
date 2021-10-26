using UnityEngine;

public class BentoScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public Transform PoisonSpot;

	public PromptScript Prompt;

	public int Poison;

	public int ID;

	private void Start()
	{
		if (Prompt.Yandere != null)
		{
			Yandere = Prompt.Yandere;
		}
	}

	private void Update()
	{
		if (Yandere == null)
		{
			if (Prompt.Yandere != null)
			{
				Yandere = Prompt.Yandere;
			}
		}
		else if (Yandere.Inventory.EmeticPoison || Yandere.Inventory.RatPoison || Yandere.Inventory.LethalPoison || Yandere.Inventory.ChemicalPoison)
		{
			Prompt.enabled = true;
			if (!Yandere.Inventory.EmeticPoison && !Yandere.Inventory.RatPoison)
			{
				Prompt.HideButton[0] = true;
			}
			else
			{
				Prompt.HideButton[0] = false;
			}
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					if (Yandere.Inventory.EmeticPoison)
					{
						Yandere.Inventory.EmeticPoison = false;
						Yandere.PoisonType = 1;
					}
					else
					{
						Yandere.Inventory.RatPoison = false;
						Yandere.PoisonType = 3;
					}
					StudentManager.Students[ID].MyBento.Tampered = true;
					StudentManager.Students[ID].MyBento.Emetic = true;
					StudentManager.Students[ID].Emetic = true;
					Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
					Yandere.PoisonSpot = PoisonSpot;
					Yandere.Poisoning = true;
					Yandere.CanMove = false;
					base.enabled = false;
					Poison = 1;
					if (ID != 1)
					{
						StudentManager.Students[ID].Emetic = true;
					}
					Prompt.Hide();
					Prompt.enabled = false;
					Prompt.Yandere.StudentManager.UpdateAllBentos();
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			if (ID != 11 && ID != 6)
			{
				return;
			}
			if (Prompt.Yandere.Inventory.LethalPoison || Prompt.Yandere.Inventory.ChemicalPoison)
			{
				Prompt.HideButton[1] = false;
			}
			else
			{
				Prompt.HideButton[1] = true;
			}
			if (Prompt.Circle[1].fillAmount == 0f)
			{
				if (Yandere.Inventory.LethalPoison)
				{
					Yandere.Inventory.LethalPoison = false;
				}
				else
				{
					Yandere.Inventory.ChemicalPoison = false;
				}
				Prompt.Yandere.Inventory.LethalPoisons--;
				Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
				StudentManager.Students[ID].MyBento.Tampered = true;
				StudentManager.Students[ID].MyBento.Lethal = true;
				StudentManager.Students[ID].Lethal = true;
				Prompt.Yandere.PoisonSpot = PoisonSpot;
				Prompt.Yandere.Poisoning = true;
				Prompt.Yandere.CanMove = false;
				Prompt.Yandere.PoisonType = 2;
				base.enabled = false;
				Poison = 2;
				Prompt.Hide();
				Prompt.enabled = false;
				Prompt.Yandere.StudentManager.UpdateAllBentos();
			}
		}
		else
		{
			Prompt.enabled = false;
		}
	}
}
