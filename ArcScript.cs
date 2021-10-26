using UnityEngine;

public class ArcScript : MonoBehaviour
{
	private static readonly Vector3 NEW_ARC_RELATIVE_FORCE = Vector3.forward * 375f;

	public GameObject ArcTrail;

	public float Timer;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 1f)
		{
			Object.Instantiate(ArcTrail, base.transform.position, base.transform.rotation).GetComponent<Rigidbody>().AddRelativeForce(NEW_ARC_RELATIVE_FORCE);
			Timer = 0f;
		}
	}
}
