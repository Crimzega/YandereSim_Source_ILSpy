using UnityEngine;

public class PowerSwitchScript : MonoBehaviour
{
	public DrinkingFountainScript DrinkingFountain;

	public PowerOutletScript PowerOutlet;

	public GameObject Electricity;

	public Light BathroomLight;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public AudioClip[] Flick;

	public bool On;

	private void Start()
	{
		if (BathroomLight != null)
		{
			Prompt.Label[0].text = "     Turn Off";
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		On = !On;
		if (BathroomLight == null)
		{
			if (On)
			{
				Prompt.Label[0].text = "     Turn Off";
				MyAudio.clip = Flick[1];
			}
			else
			{
				Prompt.Label[0].text = "     Turn On";
				MyAudio.clip = Flick[0];
			}
		}
		else
		{
			if (On)
			{
				Prompt.Label[0].text = "     Turn On";
				MyAudio.clip = Flick[1];
			}
			else
			{
				Prompt.Label[0].text = "     Turn Off";
				MyAudio.clip = Flick[0];
			}
			BathroomLight.enabled = !BathroomLight.enabled;
		}
		CheckPuddle();
		MyAudio.Play();
	}

	public void CheckPuddle()
	{
		if (On)
		{
			if (DrinkingFountain.Puddle != null && DrinkingFountain.Puddle.gameObject.activeInHierarchy && PowerOutlet.SabotagedOutlet.activeInHierarchy)
			{
				Electricity.SetActive(value: true);
			}
		}
		else
		{
			Electricity.SetActive(value: false);
		}
	}
}
