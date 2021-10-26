using UnityEngine;

public class SpyScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject SpyCamera;

	public Transform SpyTarget;

	public Transform SpySpot;

	public float Timer;

	public bool RecordEvent;

	public bool CanRecord;

	public bool Recording;

	public int Phase;

	private void Start()
	{
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Yandere.CharacterAnimation.CrossFade("f02_spying_00");
			Yandere.CanMove = false;
			Phase++;
		}
		if (Phase == 1)
		{
			Quaternion b = Quaternion.LookRotation(SpyTarget.transform.position - Yandere.transform.position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, b, Time.deltaTime * 10f);
			Yandere.MoveTowardsTarget(SpySpot.position);
			if (!Recording && RecordEvent && Yandere.Inventory.DirectionalMic)
			{
				Yandere.CharacterAnimation.CrossFade("f02_spyRecord_00");
				Yandere.Microphone.SetActive(value: true);
				Recording = true;
			}
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				PromptBar.Label[1].text = "Stop";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				Yandere.MainCamera.enabled = false;
				SpyCamera.SetActive(value: true);
				Phase++;
			}
		}
		else if (Phase == 2 && Input.GetButtonDown("B"))
		{
			End();
		}
	}

	public void End()
	{
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		Yandere.Microphone.SetActive(value: false);
		Yandere.MainCamera.enabled = true;
		Yandere.CanMove = true;
		SpyCamera.SetActive(value: false);
		Timer = 0f;
		Phase = 0;
	}
}
