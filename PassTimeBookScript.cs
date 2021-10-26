using UnityEngine;

public class PassTimeBookScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public UISprite Darkness;

	public bool TimeSkipping;

	public bool FadeOut;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Yandere.StudentManager.Clock.HourTime < 15.5f)
			{
				Yandere.NotificationManager.CustomText = "Only available after 3:30 PM";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Yandere.Armed || Yandere.Bloodiness > 0f || Yandere.Sanity < 33.333f || Yandere.Attacking || Yandere.Dragging || Yandere.Carrying || Yandere.PickUp != null || Yandere.Chased || Yandere.Chasers > 0 || (Yandere.StudentManager.Reporter != null && !Yandere.Police.Show) || Yandere.StudentManager.MurderTakingPlace)
			{
				DisplayErrorMessage();
			}
			else
			{
				Yandere.RPGCamera.enabled = false;
				Darkness.enabled = true;
				Yandere.CanMove = false;
				TimeSkipping = true;
				FadeOut = true;
			}
		}
		if (!TimeSkipping)
		{
			return;
		}
		if (FadeOut)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			if (Darkness.color.a > 0.99999f)
			{
				Yandere.StudentManager.Clock.PresentTime += 30f;
				Yandere.StudentManager.Clock.UpdateClock();
				FadeOut = false;
			}
			return;
		}
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
		if (Darkness.color.a == 0f)
		{
			if (PlayerGlobals.PantiesEquipped == 7)
			{
				Yandere.StudentManager.Reputation.Portal.Class.BonusPoints += 2;
				Yandere.NotificationManager.CustomText = "Gained 2 extra Study Points!";
			}
			else
			{
				Yandere.StudentManager.Reputation.Portal.Class.BonusPoints++;
				Yandere.NotificationManager.CustomText = "Gained 1 extra Study Point!";
			}
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Yandere.RPGCamera.enabled = true;
			Darkness.enabled = false;
			Yandere.CanMove = true;
			TimeSkipping = false;
		}
	}

	public void DisplayErrorMessage()
	{
		if (Yandere.Armed)
		{
			Yandere.NotificationManager.CustomText = "Carrying Weapon";
		}
		else if (Yandere.Bloodiness > 0f)
		{
			Yandere.NotificationManager.CustomText = "Bloody";
		}
		else if (Yandere.Sanity < 33.333f)
		{
			Yandere.NotificationManager.CustomText = "Visibly Insane";
		}
		else if (Yandere.Attacking)
		{
			Yandere.NotificationManager.CustomText = "In Combat";
		}
		else if (Yandere.Dragging || Yandere.Carrying)
		{
			Yandere.NotificationManager.CustomText = "Holding Corpse";
		}
		else if (Yandere.PickUp != null)
		{
			Yandere.NotificationManager.CustomText = "Carrying Item";
		}
		else if (Yandere.Chased || Yandere.Chasers > 0)
		{
			Yandere.NotificationManager.CustomText = "Chased";
		}
		else if ((bool)Yandere.StudentManager.Reporter && !Yandere.Police.Show)
		{
			Yandere.NotificationManager.CustomText = "Murder being reported";
		}
		else if (Yandere.StudentManager.MurderTakingPlace)
		{
			Yandere.NotificationManager.CustomText = "Murder taking place";
		}
		Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		Yandere.NotificationManager.CustomText = "Cannot pass time. Reason:";
		Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
	}
}
