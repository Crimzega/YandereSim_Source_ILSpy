using UnityEngine;

public class MatchmakingResultsWindowScript : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			base.gameObject.SetActive(value: false);
			Time.timeScale = 1f;
		}
	}
}
