using UnityEngine;

public class InstantDeathColliderScript : MonoBehaviour
{
	public int Frame;

	private void Update()
	{
		Frame++;
		if (Frame > 1)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				component.DeathType = DeathType.Explosion;
				component.BecomeRagdoll();
				Rigidbody obj = component.Ragdoll.AllRigidbodies[0];
				obj.isKinematic = false;
				Vector3 vector = obj.transform.position - base.transform.position;
				obj.AddForce(vector * 10000f);
			}
		}
	}
}
