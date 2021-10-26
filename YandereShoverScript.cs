using UnityEngine;

public class YandereShoverScript : MonoBehaviour
{
	public YandereScript Yandere;

	public bool PreventNudity;

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer != 13)
		{
			return;
		}
		bool flag = false;
		if (PreventNudity)
		{
			if (Yandere.Schoolwear == 0)
			{
				flag = true;
				if (Yandere.NotificationManager.NotificationParent.childCount == 0)
				{
					Yandere.NotificationManager.CustomText = "Get dressed first!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else
		{
			flag = true;
			if (Yandere.NotificationManager.NotificationParent.childCount == 0)
			{
				Yandere.NotificationManager.CustomText = "That's the boys' locker room!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		if (flag)
		{
			if (Yandere.Aiming)
			{
				Yandere.StopAiming();
			}
			if (Yandere.Laughing)
			{
				Yandere.StopLaughing();
			}
			Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, Yandere.transform.position.y, base.transform.position.z) - Yandere.transform.position);
			Yandere.CharacterAnimation["f02_shoveA_01"].time = 0f;
			Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
			Yandere.YandereVision = false;
			Yandere.NearSenpai = false;
			Yandere.Degloving = false;
			Yandere.Flicking = false;
			Yandere.Punching = false;
			Yandere.CanMove = false;
			Yandere.Shoved = true;
			Yandere.EmptyHands();
			Yandere.GloveTimer = 0f;
			Yandere.h = 0f;
			Yandere.v = 0f;
			Yandere.ShoveSpeed = 2f;
		}
		if (Yandere.Talking)
		{
			Yandere.transform.position = new Vector3(14f, 0f, -12f);
		}
	}
}
