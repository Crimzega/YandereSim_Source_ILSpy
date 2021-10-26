using Bayat.SaveSystem;
using UnityEngine;
using UnityEngine.PostProcessing;

public class StalkerYandereScript : MonoBehaviour
{
	public CharacterController MyController;

	public PostProcessingProfile Profile;

	public AutoSaveManager SaveManager;

	public StalkerScript Stalker;

	public Transform TrellisClimbSpot;

	public Transform CameraTarget;

	public Transform ObjectTarget;

	public Transform RightHand;

	public Transform EntryPOV;

	public Transform RightArm;

	public Transform Object;

	public Transform Hips;

	public Renderer PonytailRenderer;

	public GameObject GroundImpact;

	public Animation MyAnimation;

	public RPG_Camera RPGCamera;

	public AudioSource Jukebox;

	public Camera MainCamera;

	public bool Struggling;

	public bool Climbing;

	public bool Running;

	public bool Invisible;

	public bool Eighties;

	public bool InDesert;

	public bool CanMove;

	public bool Chased;

	public bool Hidden;

	public bool Street;

	public Stance Stance = new Stance(StanceType.Standing);

	public string IdleAnim;

	public string WalkAnim;

	public string RunAnim;

	public string CrouchIdleAnim;

	public string CrouchWalkAnim;

	public string CrouchRunAnim;

	public float WalkSpeed;

	public float RunSpeed;

	public float CrouchWalkSpeed;

	public float CrouchRunSpeed;

	public float Intensity = 0.45f;

	public int ClimbPhase;

	public int Frame;

	public SkinnedMeshRenderer MyRenderer;

	public GameObject ClothingAttacher;

	public GameObject EightiesAttacher;

	public GameObject RyobaHair;

	public Material Transparent;

	public Texture BlondePony;

	public Mesh HeadOnlyMesh;

	public Transform BreastL;

	public Transform BreastR;

	public void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (BlondePony != null && GameGlobals.BlondeHair)
		{
			PonytailRenderer.material.mainTexture = BlondePony;
		}
		if (GameGlobals.Eighties)
		{
			Eighties = true;
		}
		if (GameGlobals.Eighties && EightiesAttacher != null)
		{
			EightiesAttacher.SetActive(value: true);
			MyRenderer.sharedMesh = HeadOnlyMesh;
			PonytailRenderer.gameObject.SetActive(value: false);
			RyobaHair.SetActive(value: true);
			MyRenderer.materials[0].mainTexture = MyRenderer.materials[2].mainTexture;
			Eighties = true;
		}
		else
		{
			ClothingAttacher.SetActive(value: true);
			MyRenderer.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (Input.GetKeyDown("m") && Jukebox != null)
		{
			if (Jukebox.isPlaying)
			{
				Jukebox.Stop();
			}
			else
			{
				Jukebox.Play();
			}
		}
		if (CanMove)
		{
			if (CameraTarget != null)
			{
				CameraTarget.localPosition = new Vector3(0f, 1f + (RPGCamera.distanceMax - RPGCamera.distance) * 0.2f, 0f);
			}
			if (InDesert && base.transform.position.y < 13.7f)
			{
				UnityEngine.Object.Instantiate(GroundImpact, base.transform.position + new Vector3(0f, 0.1f, 0f), Quaternion.identity);
				InDesert = false;
			}
			UpdateMovement();
		}
		else if (CameraTarget != null)
		{
			if (Climbing)
			{
				if (ClimbPhase == 1)
				{
					if (MyAnimation["f02_climbTrellis_00"].time < MyAnimation["f02_climbTrellis_00"].length - 1f)
					{
						CameraTarget.position = Vector3.MoveTowards(CameraTarget.position, Hips.position + new Vector3(0f, 0.103729f, 0.003539f), Time.deltaTime);
					}
					else
					{
						CameraTarget.position = Vector3.MoveTowards(CameraTarget.position, new Vector3(-9.5f, 5f, -2.5f), Time.deltaTime);
					}
					MoveTowardsTarget(TrellisClimbSpot.position);
					SpinTowardsTarget(TrellisClimbSpot.rotation);
					if (MyAnimation["f02_climbTrellis_00"].time > 7.5f)
					{
						RPGCamera.transform.position = EntryPOV.position;
						RPGCamera.transform.eulerAngles = EntryPOV.eulerAngles;
						RPGCamera.enabled = false;
						RenderSettings.ambientIntensity = 8f;
						ClimbPhase++;
					}
				}
				else
				{
					RPGCamera.transform.position = EntryPOV.position;
					RPGCamera.transform.eulerAngles = EntryPOV.eulerAngles;
					if (MyAnimation["f02_climbTrellis_00"].time > 11f)
					{
						base.transform.position = Vector3.MoveTowards(base.transform.position, TrellisClimbSpot.position + new Vector3(0.4f, 0f, 0f), Time.deltaTime * 0.5f);
					}
				}
				if (MyAnimation["f02_climbTrellis_00"].time > MyAnimation["f02_climbTrellis_00"].length)
				{
					MyAnimation.Play("f02_idleShort_00");
					base.transform.position = new Vector3(-9.1f, 4f, -2.5f);
					CameraTarget.position = base.transform.position + new Vector3(0f, 1f, 0f);
					RPGCamera.enabled = true;
					Climbing = false;
					CanMove = true;
					Physics.SyncTransforms();
				}
			}
			else if (Chased)
			{
				Quaternion b = Quaternion.LookRotation(Stalker.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, 10f * Time.deltaTime);
			}
		}
		if (Street && base.transform.position.x < -16f)
		{
			base.transform.position = new Vector3(-16f, 0f, base.transform.position.z);
		}
		if (!(Profile != null))
		{
			return;
		}
		if (Stance.Current == StanceType.Crouching && Hidden)
		{
			if (Intensity != 1f)
			{
				Intensity = Mathf.MoveTowards(Intensity, 1f, Time.deltaTime);
				UpdateVignette();
			}
		}
		else if (Intensity != 0.45f)
		{
			Intensity = Mathf.MoveTowards(Intensity, 0.45f, Time.deltaTime);
			UpdateVignette();
		}
	}

	private void UpdateMovement()
	{
		if (!OptionGlobals.ToggleRun)
		{
			Running = false;
			if (Input.GetButton("LB"))
			{
				Running = true;
			}
		}
		else if (Input.GetButtonDown("LB"))
		{
			Running = !Running;
		}
		MyController.Move(Physics.gravity * Time.deltaTime);
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		Vector3 vector = MainCamera.transform.TransformDirection(Vector3.forward);
		vector.y = 0f;
		vector = vector.normalized;
		Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
		Vector3 vector3 = axis2 * vector2 + axis * vector;
		Quaternion b = Quaternion.identity;
		if (vector3 != Vector3.zero)
		{
			b = Quaternion.LookRotation(vector3);
		}
		if (vector3 != Vector3.zero)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
		}
		else
		{
			b = new Quaternion(0f, 0f, 0f, 0f);
		}
		if (!Street)
		{
			if (Stance.Current == StanceType.Standing)
			{
				if (Input.GetButtonDown("RS"))
				{
					Stance.Current = StanceType.Crouching;
					MyController.center = new Vector3(0f, 0.5f, 0f);
					MyController.height = 1f;
				}
			}
			else if (Input.GetButtonDown("RS"))
			{
				Stance.Current = StanceType.Standing;
				MyController.center = new Vector3(0f, 0.75f, 0f);
				MyController.height = 1.5f;
			}
		}
		if (axis != 0f || axis2 != 0f)
		{
			if (Running)
			{
				if (Stance.Current == StanceType.Crouching)
				{
					MyAnimation.CrossFade(CrouchRunAnim);
					MyController.Move(base.transform.forward * CrouchRunSpeed * Time.deltaTime);
				}
				else
				{
					MyAnimation.CrossFade(RunAnim);
					MyController.Move(base.transform.forward * RunSpeed * Time.deltaTime);
				}
			}
			else if (Stance.Current == StanceType.Crouching)
			{
				MyAnimation.CrossFade(CrouchWalkAnim);
				MyController.Move(base.transform.forward * (CrouchWalkSpeed * Time.deltaTime));
			}
			else
			{
				MyAnimation.CrossFade(WalkAnim);
				MyController.Move(base.transform.forward * (WalkSpeed * Time.deltaTime));
			}
		}
		else if (Stance.Current == StanceType.Crouching)
		{
			MyAnimation.CrossFade(CrouchIdleAnim);
		}
		else
		{
			MyAnimation.CrossFade(IdleAnim);
		}
	}

	private void LateUpdate()
	{
		if (Object != null)
		{
			if (RightArm != null)
			{
				RightArm.localEulerAngles = new Vector3(RightArm.localEulerAngles.x, RightArm.localEulerAngles.y + 15f, RightArm.localEulerAngles.z);
			}
			Object.LookAt(ObjectTarget);
		}
	}

	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 vector = target - base.transform.position;
		MyController.Move(vector * (Time.deltaTime * 10f));
	}

	private void SpinTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	public void UpdateVignette()
	{
		VignetteModel.Settings settings = Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = Intensity;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		Profile.vignette.settings = settings;
	}

	public void BeginStruggle()
	{
		MyAnimation.CrossFade("f02_struggleA_00");
		Struggling = true;
		Object.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		Object.gameObject.GetComponent<Rigidbody>().useGravity = true;
		Object.gameObject.GetComponent<Collider>().isTrigger = false;
		Object.parent = null;
		Object = null;
	}
}
