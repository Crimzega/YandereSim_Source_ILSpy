using UnityEngine;

public class SmokeBombScript : MonoBehaviour
{
	public StudentScript[] Students;

	public float TimeLimit = 15f;

	public float Timer;

	public bool Amnesia;

	public bool Stink;

	public int ID;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (!(Timer > TimeLimit))
		{
			return;
		}
		if (!Stink)
		{
			StudentScript[] students = Students;
			foreach (StudentScript studentScript in students)
			{
				if (studentScript != null)
				{
					studentScript.Blind = false;
				}
			}
		}
		Object.Destroy(base.gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer != 9)
		{
			return;
		}
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (!(component != null))
		{
			return;
		}
		if (Stink)
		{
			GoAway(component);
			return;
		}
		if (Amnesia && !component.Chasing)
		{
			component.ReturnToNormal();
		}
		Students[ID] = component;
		component.Blind = true;
		ID++;
	}

	private void OnTriggerStay(Collider other)
	{
		if (Stink)
		{
			if (other.gameObject.layer == 9)
			{
				StudentScript component = other.gameObject.GetComponent<StudentScript>();
				if (component != null && !component.Yandere.Noticed)
				{
					GoAway(component);
				}
			}
		}
		else if (Amnesia && other.gameObject.layer == 9)
		{
			StudentScript component2 = other.gameObject.GetComponent<StudentScript>();
			if (component2 != null && component2.Alarmed && !component2.Chasing)
			{
				component2.ReturnToNormal();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!Stink && !Amnesia && other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log(component.Name + " left a smoke cloud and stopped being blind.");
				component.Blind = false;
			}
		}
	}

	private void GoAway(StudentScript Student)
	{
		if (!Student.Chasing && !Student.WitnessedMurder && !Student.WitnessedCorpse && !Student.Fleeing && !Student.Yandere.Noticed && !Student.Hunting && !Student.Confessing)
		{
			if (Student.Following)
			{
				Student.Yandere.Follower = null;
				Student.Yandere.Followers--;
				ParticleSystem.EmissionModule emission = Student.Hearts.emission;
				emission.enabled = false;
				Student.FollowCountdown.gameObject.SetActive(value: false);
				Student.Following = false;
			}
			if (Student.SolvingPuzzle)
			{
				Student.PuzzleTimer = 0f;
				Student.DropPuzzle();
			}
			Student.CurrentDestination = Student.StudentManager.GoAwaySpots.List[Student.StudentID];
			Student.Pathfinding.target = Student.StudentManager.GoAwaySpots.List[Student.StudentID];
			Student.Pathfinding.canSearch = true;
			Student.Pathfinding.canMove = true;
			Student.CharacterAnimation.CrossFade(Student.SprintAnim);
			Student.DistanceToDestination = 100f;
			Student.Pathfinding.speed = 4f;
			Student.AmnesiaTimer = 10f;
			Student.Distracted = true;
			Student.Alarmed = false;
			Student.Routine = false;
			Student.GoAway = true;
			Student.AlarmTimer = 0f;
		}
	}
}
