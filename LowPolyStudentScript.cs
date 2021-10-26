using UnityEngine;

public class LowPolyStudentScript : MonoBehaviour
{
	public StudentScript Student;

	public Renderer TeacherMesh;

	public Renderer MyMesh;

	private void Start()
	{
		if (Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if ((float)Student.StudentManager.LowDetailThreshold > 0f)
		{
			if (Student.Prompt.DistanceSqr > (float)Student.StudentManager.LowDetailThreshold)
			{
				if (!MyMesh.enabled)
				{
					Student.MyRenderer.enabled = false;
					MyMesh.enabled = true;
				}
			}
			else if (MyMesh.enabled)
			{
				Student.MyRenderer.enabled = true;
				MyMesh.enabled = false;
			}
		}
		else if (MyMesh.enabled)
		{
			Student.MyRenderer.enabled = true;
			MyMesh.enabled = false;
		}
	}
}
