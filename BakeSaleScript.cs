using UnityEngine;
using UnityEngine.SceneManagement;

public class BakeSaleScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public GameObject AmaiSuccess;

	public GameObject AmaiFail;

	public Transform MeetSpot;

	public float Timer;

	public int ID = 46;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 60f && StudentManager.Students[ID] != null)
		{
			if (StudentManager.Students[ID].Routine)
			{
				Debug.Log(StudentManager.Students[ID].Name + " has decided to go to the bake sale.");
				Timer = 0f;
				StudentManager.Students[ID].Meeting = true;
				StudentManager.Students[ID].BakeSale = true;
				StudentManager.Students[ID].MeetTime = 0.0001f;
				StudentManager.Students[ID].MeetSpot = MeetSpot;
				IncreaseID();
			}
			else
			{
				IncreaseID();
			}
		}
		if (StudentManager.Yandere.Alerts > 0 || StudentManager.Yandere.Police.StudentFoundCorpse)
		{
			AmaiFail.SetActive(value: true);
			if (Input.GetKeyDown("`"))
			{
				SceneManager.LoadScene("LoadingScene");
			}
		}
		else if (StudentManager.Students[12] != null && StudentManager.Students[12].Ragdoll.Disposed)
		{
			AmaiSuccess.SetActive(value: true);
		}
	}

	private void IncreaseID()
	{
		ID++;
		if (ID > 89)
		{
			ID = 46;
		}
	}
}
