using UnityEngine;
using UnityEngine.SceneManagement;

public class BloodPoolSpawnerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public RagdollScript Ragdoll;

	public GameObject LastBloodPool;

	public GameObject BloodPool;

	public Transform BloodParent;

	public Transform Hips;

	public Collider MyCollider;

	public Collider GardenArea;

	public Collider TreeArea;

	public Collider NEStairs;

	public Collider NWStairs;

	public Collider SEStairs;

	public Collider SWStairs;

	public Vector3[] Positions;

	public bool CanSpawn;

	public bool Falling;

	public int PoolsSpawned;

	public int NearbyBlood;

	public float FallTimer;

	public float Height;

	public float Timer;

	public LayerMask Mask;

	public void Start()
	{
		if (SceneManager.GetActiveScene().name == "SchoolScene")
		{
			PoolsSpawned = Ragdoll.Student.BloodPoolsSpawned;
			if (StudentManager == null)
			{
				StudentManager = Ragdoll.Student.StudentManager;
			}
			GardenArea = StudentManager.GardenArea;
			TreeArea = StudentManager.TreeArea;
			NEStairs = StudentManager.NEStairs;
			NWStairs = StudentManager.NWStairs;
			SEStairs = StudentManager.SEStairs;
			SWStairs = StudentManager.SWStairs;
		}
		BloodParent = GameObject.Find("BloodParent").transform;
		Positions = new Vector3[5];
		Positions[0] = Vector3.zero;
		Positions[1] = new Vector3(0.5f, 0.012f, 0f);
		Positions[2] = new Vector3(-0.5f, 0.012f, 0f);
		Positions[3] = new Vector3(0f, 0.012f, 0.5f);
		Positions[4] = new Vector3(0f, 0.012f, -0.5f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			LastBloodPool = other.gameObject;
			NearbyBlood++;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			NearbyBlood--;
		}
	}

	private void Update()
	{
		if (!Falling)
		{
			if (!MyCollider.enabled)
			{
				return;
			}
			if (Timer > 0f)
			{
				Timer -= Time.deltaTime;
			}
			SetHeight();
			Vector3 position = base.transform.position;
			if (SceneManager.GetActiveScene().name == "SchoolScene")
			{
				CanSpawn = !GardenArea.bounds.Contains(position) && !TreeArea.bounds.Contains(position) && !NEStairs.bounds.Contains(position) && !NWStairs.bounds.Contains(position) && !SEStairs.bounds.Contains(position) && !SWStairs.bounds.Contains(position);
			}
			if (!CanSpawn || !(position.y < Height + 0.333333343f))
			{
				return;
			}
			if (NearbyBlood > 0 && LastBloodPool == null)
			{
				NearbyBlood--;
			}
			if (NearbyBlood >= 1 || !(Timer <= 0f))
			{
				return;
			}
			Timer = 0.1f;
			GameObject gameObject = null;
			if (PoolsSpawned < 10)
			{
				gameObject = Object.Instantiate(BloodPool, new Vector3(position.x, Height + 0.012f, position.z), Quaternion.identity);
				gameObject.transform.localEulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
				gameObject.transform.parent = BloodParent;
				PoolsSpawned++;
				Ragdoll.Student.BloodPoolsSpawned++;
			}
			else if (PoolsSpawned < 20)
			{
				gameObject = Object.Instantiate(BloodPool, new Vector3(position.x, Height + 0.012f, position.z), Quaternion.identity);
				gameObject.transform.localEulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
				gameObject.transform.parent = BloodParent;
				PoolsSpawned++;
				Ragdoll.Student.BloodPoolsSpawned++;
				gameObject.GetComponent<BloodPoolScript>().TargetSize = 1f - (float)(PoolsSpawned - 10) * 0.1f;
				if (PoolsSpawned == 20)
				{
					base.gameObject.SetActive(value: false);
				}
			}
			if (gameObject != null && (StudentManager.EastBathroomArea.bounds.Contains(base.transform.position) || StudentManager.WestBathroomArea.bounds.Contains(base.transform.position)))
			{
				gameObject.GetComponent<BloodPoolScript>().TargetSize = gameObject.GetComponent<BloodPoolScript>().TargetSize * 0.5f;
			}
		}
		else
		{
			FallTimer += Time.deltaTime;
			if (FallTimer > 10f)
			{
				Falling = false;
			}
		}
	}

	public void SpawnBigPool()
	{
		SetHeight();
		Vector3 vector = new Vector3(Hips.position.x, Height + 0.012f, Hips.position.z);
		for (int i = 0; i < 5; i++)
		{
			GameObject obj = Object.Instantiate(BloodPool, vector + Positions[i], Quaternion.identity);
			obj.transform.localEulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
			obj.transform.parent = BloodParent;
		}
	}

	private void SpawnRow(Transform Location)
	{
		Vector3 position = Location.position;
		Vector3 forward = Location.forward;
		GameObject obj = Object.Instantiate(BloodPool, position + forward * 2f, Quaternion.identity);
		obj.transform.localEulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
		obj.transform.parent = BloodParent;
		GameObject obj2 = Object.Instantiate(BloodPool, position + forward * 2.5f, Quaternion.identity);
		obj2.transform.localEulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
		obj2.transform.parent = BloodParent;
		GameObject obj3 = Object.Instantiate(BloodPool, position + forward * 3f, Quaternion.identity);
		obj3.transform.localEulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
		obj3.transform.parent = BloodParent;
	}

	public void SpawnPool(Transform Location)
	{
		GameObject obj = Object.Instantiate(BloodPool, Location.position + Location.forward + new Vector3(0f, 0.0001f, 0f), Quaternion.identity);
		obj.transform.localEulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
		obj.transform.parent = BloodParent;
	}

	private void SetHeight()
	{
		float y = base.transform.position.y;
		if (y < 4f)
		{
			Height = 0f;
		}
		else if (y < 8f)
		{
			Height = 4f;
		}
		else if (y < 12f)
		{
			Height = 8f;
		}
		else
		{
			Height = 12f;
		}
	}
}
