using UnityEngine;

public class TaskManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public GameObject[] TaskObjects;

	public PromptScript[] Prompts;

	public bool[] GirlsQuestioned;

	public int[] TaskStatus;

	public bool Initialized;

	public void Start()
	{
		for (int i = 1; i < 101; i++)
		{
			TaskStatus[i] = TaskGlobals.GetTaskStatus(i);
		}
		if (TaskStatus[46] == 1)
		{
			TaskGlobals.SetTaskStatus(46, 0);
			TaskStatus[46] = 0;
		}
		if (StudentManager != null)
		{
			UpdateTaskStatus();
		}
		Initialized = true;
	}

	public void CheckTaskPickups()
	{
		if (TaskStatus[11] == 1 && Prompts[11].Circle[3] != null && Prompts[11].Circle[3].fillAmount == 0f)
		{
			if (StudentManager.Students[11] != null)
			{
				StudentManager.Students[11].TaskPhase = 5;
			}
			Yandere.NotificationManager.TopicName = "Cats";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			ConversationGlobals.SetTopicLearnedByStudent(15, 11, value: true);
			TaskStatus[11] = 2;
			Object.Destroy(TaskObjects[11]);
		}
		if (TaskStatus[25] == 1 && Prompts[25].Circle[3].fillAmount == 0f)
		{
			if (StudentManager.Students[25] != null)
			{
				StudentManager.Students[25].TaskPhase = 5;
			}
			TaskStatus[25] = 2;
			Object.Destroy(TaskObjects[25]);
		}
		if (TaskStatus[37] == 1 && Prompts[37].Circle[3] != null && Prompts[37].Circle[3].fillAmount == 0f)
		{
			if (StudentManager.Students[37] != null)
			{
				StudentManager.Students[37].TaskPhase = 5;
			}
			TaskStatus[37] = 2;
			Object.Destroy(TaskObjects[37]);
		}
	}

	public void UpdateTaskStatus()
	{
		if (TaskStatus[8] == 1 && StudentManager.Students[8] != null)
		{
			if (StudentManager.Students[8].TaskPhase == 0)
			{
				StudentManager.Students[8].TaskPhase = 4;
			}
			if (Yandere.Inventory.Soda)
			{
				StudentManager.Students[8].TaskPhase = 5;
			}
		}
		if (TaskStatus[11] == 1)
		{
			if (StudentManager.Students[11] != null)
			{
				if (StudentManager.Students[11].TaskPhase == 0)
				{
					StudentManager.Students[11].TaskPhase = 4;
				}
				TaskObjects[11].SetActive(value: true);
			}
		}
		else if (TaskObjects[11] != null)
		{
			TaskObjects[11].SetActive(value: false);
		}
		if (TaskStatus[25] == 1)
		{
			if (StudentManager.Students[25] != null)
			{
				if (StudentManager.Students[25].TaskPhase == 0)
				{
					StudentManager.Students[25].TaskPhase = 4;
				}
				TaskObjects[25].SetActive(value: true);
			}
		}
		else if (TaskObjects[25] != null)
		{
			TaskObjects[25].SetActive(value: false);
		}
		if (TaskStatus[28] == 1 && StudentManager.Students[28] != null)
		{
			if (StudentManager.Students[28].TaskPhase == 0)
			{
				StudentManager.Students[28].TaskPhase = 4;
			}
			for (int i = 1; i < 26; i++)
			{
				if (TaskGlobals.GetKittenPhoto(i))
				{
					Debug.Log("Riku's Task can be turned in.");
					StudentManager.Students[28].TaskPhase = 5;
				}
			}
		}
		if (TaskStatus[30] == 1 && StudentManager.Students[30] != null && StudentManager.Students[30].TaskPhase == 0)
		{
			StudentManager.Students[30].TaskPhase = 4;
		}
		if (TaskStatus[36] == 1 && StudentManager.Students[36] != null)
		{
			if (StudentManager.Students[36].TaskPhase == 0)
			{
				StudentManager.Students[36].TaskPhase = 4;
			}
			if (GirlsQuestioned[1] && GirlsQuestioned[2] && GirlsQuestioned[3] && GirlsQuestioned[4] && GirlsQuestioned[5])
			{
				Debug.Log("Gema's task should be ready to turn in!");
				StudentManager.Students[36].TaskPhase = 5;
			}
		}
		if (TaskStatus[37] == 1)
		{
			if (StudentManager.Students[37] != null)
			{
				if (StudentManager.Students[37].TaskPhase == 0)
				{
					StudentManager.Students[37].TaskPhase = 4;
				}
				TaskObjects[37].SetActive(value: true);
			}
		}
		else if (TaskObjects[37] != null)
		{
			TaskObjects[37].SetActive(value: false);
		}
		if (TaskStatus[38] == 1)
		{
			if (StudentManager.Students[38] != null && StudentManager.Students[38].TaskPhase == 0)
			{
				StudentManager.Students[38].TaskPhase = 4;
			}
		}
		else if (TaskStatus[38] == 2 && StudentManager.Students[38] != null)
		{
			StudentManager.Students[38].TaskPhase = 5;
		}
		if (TaskStatus[46] == 1 && StudentManager.Students[46] != null)
		{
			if (StudentManager.Students[46].TaskPhase == 0)
			{
				StudentManager.Students[46].TaskPhase = 4;
			}
			if (StudentManager.Students[10] != null && Vector3.Distance(StudentManager.Students[46].transform.position, StudentManager.Students[10].transform.position) < 2f)
			{
				Debug.Log("Budo's task should be ready to turn in!");
				StudentManager.Students[46].TaskPhase = 5;
			}
		}
		if (ClubGlobals.GetClubClosed(ClubType.LightMusic) || StudentManager.Students[51] == null)
		{
			if (StudentManager.Students[52] != null)
			{
				StudentManager.Students[52].TaskPhase = 100;
			}
			TaskStatus[52] = 100;
		}
		else if (TaskStatus[52] == 1 && StudentManager.Students[52] != null)
		{
			StudentManager.Students[52].TaskPhase = 4;
			for (int j = 1; j < 52; j++)
			{
				if (TaskGlobals.GetGuitarPhoto(j))
				{
					StudentManager.Students[52].TaskPhase = 5;
				}
			}
		}
		if (TaskStatus[81] == 1 && StudentManager.Students[81] != null)
		{
			if (StudentManager.Students[81].TaskPhase == 0)
			{
				StudentManager.Students[81].TaskPhase = 4;
			}
			for (int k = 1; k < 26; k++)
			{
				if (TaskGlobals.GetHorudaPhoto(k))
				{
					Debug.Log("Musume's Task can be turned in.");
					StudentManager.Students[81].TaskPhase = 5;
				}
			}
		}
		if (TaskStatus[79] == 1 && StudentManager.Students[79] != null)
		{
			Debug.Log("Telling delinquent to change his destination.");
			ScheduleBlock obj = StudentManager.Students[79].ScheduleBlocks[6];
			obj.destination = "Wait";
			obj.action = "Wait";
			ScheduleBlock obj2 = StudentManager.Students[79].ScheduleBlocks[7];
			obj2.destination = "Wait";
			obj2.action = "Wait";
			StudentManager.Students[79].GetDestinations();
		}
	}

	public void SaveTaskStatuses()
	{
		for (int i = 1; i < 101; i++)
		{
			TaskGlobals.SetTaskStatus(i, TaskStatus[i]);
			if (StudentManager.Students[i] != null)
			{
				PlayerGlobals.SetStudentFriend(i, StudentManager.Students[i].Friend);
			}
		}
	}
}
