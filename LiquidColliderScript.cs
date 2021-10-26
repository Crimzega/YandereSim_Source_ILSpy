using UnityEngine;

public class LiquidColliderScript : MonoBehaviour
{
	private GameObject NewPool;

	public AudioClip SplashSound;

	public GameObject GroundSplash;

	public GameObject Splash;

	public GameObject Pool;

	public bool AlreadyDoused;

	public bool Static;

	public bool Bucket;

	public bool Brown;

	public bool Blood;

	public bool Gas;

	private void Start()
	{
		if (Bucket)
		{
			GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 400f);
		}
	}

	private void Update()
	{
		if (Static)
		{
			return;
		}
		if (!Bucket)
		{
			if (base.transform.position.y < 0f)
			{
				Object.Instantiate(GroundSplash, new Vector3(base.transform.position.x, 0f, base.transform.position.z), Quaternion.identity);
				NewPool = Object.Instantiate(Pool, new Vector3(base.transform.position.x, 0.012f, base.transform.position.z), Quaternion.identity);
				NewPool.transform.localEulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
				if (Blood)
				{
					NewPool.transform.parent = GameObject.Find("BloodParent").transform;
				}
				Object.Destroy(base.gameObject);
			}
		}
		else
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x + Time.deltaTime * 2f, base.transform.localScale.y + Time.deltaTime * 2f, base.transform.localScale.z + Time.deltaTime * 2f);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (AlreadyDoused || other.gameObject.layer != 9)
		{
			return;
		}
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (!(component != null))
		{
			return;
		}
		if (!component.BeenSplashed && component.StudentID > 1 && component.StudentID != 10 && !component.Teacher && component.Club != ClubType.Council && !component.Fleeing && component.CurrentAction != StudentActionType.Sunbathe && !component.GasWarned)
		{
			AudioSource.PlayClipAtPoint(SplashSound, base.transform.position);
			Object.Instantiate(Splash, new Vector3(base.transform.position.x, 1.5f, base.transform.position.z), Quaternion.identity);
			if (Blood)
			{
				component.Bloody = true;
			}
			else if (Gas)
			{
				component.Gas = true;
			}
			else if (Brown)
			{
				component.DyedBrown = true;
			}
			component.GetWet();
			AlreadyDoused = true;
			Object.Destroy(base.gameObject);
		}
		else if (!component.Wet && !component.Fleeing)
		{
			Debug.Log(component.Name + " just dodged a bucket of liquid.");
			if (component.Investigating)
			{
				component.StopInvestigating();
			}
			if (component.ReturningMisplacedWeapon)
			{
				component.DropMisplacedWeapon();
			}
			component.CharacterAnimation.CrossFade(component.DodgeAnim);
			component.Pathfinding.canSearch = false;
			component.Pathfinding.canMove = false;
			component.SentToLocker = false;
			component.Routine = false;
			component.DodgeSpeed = 2f;
			component.Dodging = true;
			if (component.Following)
			{
				ParticleSystem.EmissionModule emission = component.Hearts.emission;
				emission.enabled = false;
				component.FollowCountdown.gameObject.SetActive(value: false);
				component.Yandere.Follower = null;
				component.Yandere.Followers--;
				component.Following = false;
				component.CurrentDestination = component.Destinations[component.Phase];
				component.Pathfinding.target = component.Destinations[component.Phase];
				component.Pathfinding.speed = 1f;
			}
		}
	}
}
