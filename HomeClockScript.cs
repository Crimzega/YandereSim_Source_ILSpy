using System;
using System.Globalization;
using UnityEngine;

public class HomeClockScript : MonoBehaviour
{
	public UILabel MoneyLabel;

	public UILabel HourLabel;

	public UILabel DayLabel;

	public AudioSource MyAudio;

	public bool ShakeMoney;

	public Vector3 Origin;

	public float Shake;

	public float G;

	public float B;

	private void Start()
	{
		DayLabel.text = GetWeekdayText(DateGlobals.Weekday);
		if (HomeGlobals.Night)
		{
			HourLabel.text = "8:00 PM";
		}
		else
		{
			HourLabel.text = (HomeGlobals.LateForSchool ? "7:30 AM" : "6:30 AM");
		}
		UpdateMoneyLabel();
	}

	private void Update()
	{
		if (ShakeMoney)
		{
			Shake = Mathf.MoveTowards(Shake, 0f, Time.deltaTime * 10f);
			MoneyLabel.transform.localPosition = new Vector3(Origin.x + UnityEngine.Random.Range(Shake * -1f, Shake * 1f), Origin.y + UnityEngine.Random.Range(Shake * -1f, Shake * 1f), 0f);
			G = Mathf.MoveTowards(G, 0.75f, Time.deltaTime);
			B = Mathf.MoveTowards(B, 1f, Time.deltaTime);
			MoneyLabel.color = new Color(1f, G, B, 1f);
			if (Shake == 0f)
			{
				ShakeMoney = false;
			}
		}
	}

	private string GetWeekdayText(DayOfWeek weekday)
	{
		return weekday switch
		{
			DayOfWeek.Sunday => "SUNDAY", 
			DayOfWeek.Monday => "MONDAY", 
			DayOfWeek.Tuesday => "TUESDAY", 
			DayOfWeek.Wednesday => "WEDNESDAY", 
			DayOfWeek.Thursday => "THURSDAY", 
			DayOfWeek.Friday => "FRIDAY", 
			_ => "SATURDAY", 
		};
	}

	public void UpdateMoneyLabel()
	{
		MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	public void MoneyFail()
	{
		Origin = MoneyLabel.transform.localPosition;
		ShakeMoney = true;
		Shake = 10f;
		G = 0f;
		B = 0f;
		MyAudio.Play();
	}
}
