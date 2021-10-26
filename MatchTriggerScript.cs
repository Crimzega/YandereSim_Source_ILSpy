using UnityEngine;

public class MatchTriggerScript : MonoBehaviour
{
	public StudentScript Student;

	public bool Fireball;

	public bool Candle;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer != 9)
		{
			return;
		}
		Student = other.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
		if (Student != null && Student.StudentID > 1 && (Student.Gas || Fireball))
		{
			Student.Combust();
			if (!Candle)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
