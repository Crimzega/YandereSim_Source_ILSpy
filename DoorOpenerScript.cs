using UnityEngine;

public class DoorOpenerScript : MonoBehaviour
{
	public StudentScript Student;

	public DoorScript Door;

	private void Start()
	{
		base.gameObject.layer = 1;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			Student = other.gameObject.GetComponent<StudentScript>();
			if (Student != null && !Student.Dying && !Door.Open && !Door.Locked)
			{
				Door.Student = Student;
				Door.OpenDoor();
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!Door.Open && other.gameObject.layer == 9)
		{
			Student = other.gameObject.GetComponent<StudentScript>();
			if (Student != null && !Student.Dying && !Door.Open && !Door.Locked)
			{
				Door.Student = Student;
				Door.OpenDoor();
			}
		}
	}
}
