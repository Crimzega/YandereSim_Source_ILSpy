using UnityEngine;

public class CleanUpScript : MonoBehaviour
{
	public Projector BloodProjector;

	public UISprite CleanUpDarkness;

	public PromptScript Prompt;

	public bool FadeOut;

	public bool FadeIn;

	private void Update()
	{
		if (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.Mop != null && Prompt.Yandere.PickUp.Mop.Bleached)
		{
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Yandere.CanMove = false;
				FadeOut = true;
			}
			if (FadeOut)
			{
				CleanUpDarkness.alpha = Mathf.MoveTowards(CleanUpDarkness.alpha, 1f, Time.deltaTime);
				if (CleanUpDarkness.alpha == 1f)
				{
					BloodProjector.enabled = false;
					FadeOut = false;
					FadeIn = true;
				}
			}
			if (FadeIn)
			{
				CleanUpDarkness.alpha = Mathf.MoveTowards(CleanUpDarkness.alpha, 0f, Time.deltaTime);
				if (CleanUpDarkness.alpha == 0f)
				{
					Prompt.Hide();
					BloodProjector.gameObject.SetActive(value: false);
					Prompt.Yandere.CanMove = true;
				}
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
		}
	}
}
