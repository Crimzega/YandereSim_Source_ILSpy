using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeYandereScript : MonoBehaviour
{
	public CharacterController MyController;

	public HomeVideoGamesScript HomeVideoGames;

	public HomeCameraScript HomeCamera;

	public UISprite HomeDarkness;

	public Animation CharacterAnimation;

	public GameObject CutsceneYandere;

	public GameObject Controller;

	public GameObject Character;

	public GameObject RyobaHair;

	public GameObject Disc;

	public Renderer LongHairRenderer;

	public Renderer PonytailRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public AudioClip MiyukiReaction;

	public AudioClip DiscScratch;

	public AudioSource MyAudio;

	public Texture EightiesSocks;

	public Texture BlondePony;

	public Texture BlondeLong;

	public Transform Ponytail;

	public Transform HairR;

	public Transform HairL;

	public float WalkSpeed;

	public float RunSpeed;

	public bool UpdateFace;

	public bool CanMove;

	public bool Running;

	public bool HidePony;

	public string IdleAnim = "";

	public string WalkAnim = "";

	public int Hairstyle;

	public int VictimID;

	public float Timer;

	public int AlphabetID;

	public string[] Letter;

	public SkinnedMeshRenderer MyRenderer;

	public Texture[] UniformTextures;

	public Texture FaceTexture;

	public Mesh[] Uniforms;

	public RiggedAccessoryAttacher Pajamas;

	public Texture PajamaTexture;

	public Mesh PajamaMesh;

	public Texture NudeTexture;

	public Mesh NudeMesh;

	public void Start()
	{
		Debug.Log("Here at the Home scene, GameGlobals.RivalEliminationID is currently: " + GameGlobals.RivalEliminationID);
		if (CutsceneYandere != null)
		{
			CutsceneYandere.GetComponent<Animation>()["f02_midoriTexting_00"].speed = 0.1f;
		}
		if (SceneManager.GetActiveScene().name == "HomeScene")
		{
			if (!YanvaniaGlobals.DraculaDefeated && !HomeGlobals.MiyukiDefeated)
			{
				base.transform.position = Vector3.zero;
				base.transform.eulerAngles = Vector3.zero;
				if (!GameGlobals.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
				{
					Nude();
				}
				else if (!HomeGlobals.Night)
				{
					if (DateGlobals.Weekday == DayOfWeek.Sunday)
					{
						WearPajamas();
					}
					else
					{
						ChangeSchoolwear();
						StartCoroutine(ApplyCustomCostume());
					}
				}
				else
				{
					WearPajamas();
				}
			}
			else if (HomeGlobals.StartInBasement)
			{
				HomeGlobals.StartInBasement = false;
				base.transform.position = new Vector3(0f, -135f, 0f);
				base.transform.eulerAngles = Vector3.zero;
			}
			else if (HomeGlobals.MiyukiDefeated)
			{
				base.transform.position = new Vector3(1f, 0f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				CharacterAnimation.Play("f02_discScratch_00");
				Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
				Controller.transform.localEulerAngles = new Vector3(0f, 0f, -180f);
				HomeCamera.Destination = HomeCamera.Destinations[5];
				HomeCamera.Target = HomeCamera.Targets[5];
				Disc.SetActive(value: true);
				WearPajamas();
				MyAudio.clip = MiyukiReaction;
			}
			else
			{
				base.transform.position = new Vector3(1f, 0f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				CharacterAnimation.Play("f02_discScratch_00");
				Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
				Controller.transform.localEulerAngles = new Vector3(0f, 0f, -180f);
				HomeCamera.Destination = HomeCamera.Destinations[5];
				HomeCamera.Target = HomeCamera.Targets[5];
				Disc.SetActive(value: true);
				WearPajamas();
			}
			if (GameGlobals.BlondeHair)
			{
				PonytailRenderer.material.mainTexture = BlondePony;
				PigtailR.material.mainTexture = BlondePony;
				PigtailL.material.mainTexture = BlondePony;
				Drills.material.mainTexture = BlondePony;
				LongHairRenderer.material.mainTexture = BlondeLong;
			}
		}
		Time.timeScale = 1f;
		IdleAnim = "f02_idleShort_00";
		WalkAnim = "f02_newWalk_00";
		if (GameGlobals.Eighties)
		{
			RyobaHair.SetActive(value: true);
			IdleAnim = "f02_idleCouncilGrace_00";
			WalkAnim = "f02_walkCouncilGrace_00";
			if (!HomeGlobals.Night)
			{
				MyRenderer.SetBlendShapeWeight(0, 50f);
				MyRenderer.SetBlendShapeWeight(5, 25f);
				MyRenderer.SetBlendShapeWeight(9, 0f);
				MyRenderer.SetBlendShapeWeight(12, 100f);
				if (!Pajamas.gameObject.activeInHierarchy)
				{
					ChangeSchoolwear();
				}
				MyRenderer.materials[0].mainTexture = EightiesSocks;
			}
		}
		else
		{
			PonytailRenderer.transform.parent.gameObject.SetActive(value: true);
			RyobaHair.SetActive(value: false);
			Hairstyle = 0;
			UpdateHair();
		}
	}

	private void Update()
	{
		if (UpdateFace)
		{
			UpdateFace = false;
		}
		if (!Disc.activeInHierarchy)
		{
			if (CanMove)
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
				MyController.Move(Physics.gravity * 0.01f);
				float axis = Input.GetAxis("Vertical");
				float axis2 = Input.GetAxis("Horizontal");
				Vector3 vector = Camera.main.transform.TransformDirection(Vector3.forward);
				vector.y = 0f;
				vector = vector.normalized;
				Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
				Vector3 vector3 = axis2 * vector2 + axis * vector;
				if (vector3 != Vector3.zero)
				{
					Quaternion b = Quaternion.LookRotation(vector3);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
				}
				if (axis != 0f || axis2 != 0f)
				{
					if (Running)
					{
						CharacterAnimation.CrossFade("f02_run_00");
						MyController.Move(base.transform.forward * RunSpeed * Time.deltaTime);
					}
					else
					{
						CharacterAnimation.CrossFade(WalkAnim);
						MyController.Move(base.transform.forward * WalkSpeed * Time.deltaTime);
					}
				}
				else
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
			}
			else
			{
				CharacterAnimation.CrossFade(IdleAnim);
			}
		}
		else if (HomeDarkness.color.a == 0f)
		{
			if (Timer == 0f)
			{
				MyAudio.Play();
			}
			else if (Timer > MyAudio.clip.length + 1f)
			{
				YanvaniaGlobals.DraculaDefeated = false;
				HomeGlobals.MiyukiDefeated = false;
				Disc.SetActive(value: false);
				HomeVideoGames.Quit();
			}
			Timer += Time.deltaTime;
		}
		Rigidbody component = GetComponent<Rigidbody>();
		if (component != null)
		{
			component.velocity = Vector3.zero;
		}
		if (base.transform.position.y < -10f)
		{
			base.transform.position = new Vector3(base.transform.position.x, -10f, base.transform.position.z);
		}
	}

	private void LateUpdate()
	{
		if (HidePony)
		{
			Ponytail.parent.transform.localScale = new Vector3(1f, 1f, 0.93f);
			Ponytail.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
			HairR.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
			HairL.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
		}
		if (!Input.GetKeyDown(Letter[AlphabetID]))
		{
			return;
		}
		AlphabetID++;
		if (AlphabetID == Letter.Length)
		{
			DateGlobals.Weekday = DayOfWeek.Monday;
			GameGlobals.AlphabetMode = true;
			StudentGlobals.MemorialStudents = 0;
			for (int i = 1; i < 101; i++)
			{
				StudentGlobals.SetStudentDead(i, value: false);
				StudentGlobals.SetStudentKidnapped(i, value: false);
				StudentGlobals.SetStudentArrested(i, value: false);
				StudentGlobals.SetStudentExpelled(i, value: false);
			}
			SceneManager.LoadScene("LoadingScene");
		}
	}

	private void UpdateHair()
	{
		PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3(1f, 0.75f, 1f);
		PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3(1f, 0.75f, 1f);
		LongHairRenderer.gameObject.SetActive(value: false);
		PigtailR.gameObject.SetActive(value: false);
		PigtailL.gameObject.SetActive(value: false);
		Drills.gameObject.SetActive(value: false);
		PonytailRenderer.enabled = true;
		HidePony = true;
		Hairstyle++;
		if (Hairstyle > 8)
		{
			Hairstyle = 1;
		}
		if (Hairstyle == 1)
		{
			HidePony = false;
			Ponytail.localScale = new Vector3(1f, 1f, 1f);
			HairR.localScale = new Vector3(1f, 1f, 1f);
			HairL.localScale = new Vector3(1f, 1f, 1f);
		}
		else if (Hairstyle == 2)
		{
			PigtailR.gameObject.SetActive(value: true);
		}
		else if (Hairstyle == 3)
		{
			PigtailL.gameObject.SetActive(value: true);
		}
		else if (Hairstyle == 4)
		{
			PigtailR.gameObject.SetActive(value: true);
			PigtailL.gameObject.SetActive(value: true);
		}
		else if (Hairstyle == 5)
		{
			PigtailR.gameObject.SetActive(value: true);
			PigtailL.gameObject.SetActive(value: true);
			HidePony = false;
			Ponytail.localScale = new Vector3(1f, 1f, 1f);
			HairR.localScale = new Vector3(1f, 1f, 1f);
			HairL.localScale = new Vector3(1f, 1f, 1f);
		}
		else if (Hairstyle == 6)
		{
			PigtailR.gameObject.SetActive(value: true);
			PigtailL.gameObject.SetActive(value: true);
			PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3(2f, 2f, 2f);
			PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3(2f, 2f, 2f);
		}
		else if (Hairstyle == 7)
		{
			Drills.gameObject.SetActive(value: true);
		}
		else if (Hairstyle == 8)
		{
			LongHairRenderer.gameObject.SetActive(value: true);
			PonytailRenderer.enabled = false;
		}
	}

	private void ChangeSchoolwear()
	{
		MyRenderer.sharedMesh = Uniforms[StudentGlobals.FemaleUniform];
		MyRenderer.materials[0].mainTexture = UniformTextures[StudentGlobals.FemaleUniform];
		MyRenderer.materials[1].mainTexture = UniformTextures[StudentGlobals.FemaleUniform];
		MyRenderer.materials[2].mainTexture = FaceTexture;
		StartCoroutine(ApplyCustomCostume());
	}

	private void WearPajamas()
	{
		Hairstyle = 6;
		UpdateHair();
		Pajamas.gameObject.SetActive(value: true);
		MyRenderer.sharedMesh = null;
		MyRenderer.materials[0].mainTexture = PajamaTexture;
		MyRenderer.materials[1].mainTexture = PajamaTexture;
		MyRenderer.materials[2].mainTexture = FaceTexture;
		StartCoroutine(ApplyCustomFace());
		if (GameGlobals.Eighties)
		{
			UpdateFace = true;
		}
	}

	private void Nude()
	{
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = NudeTexture;
		MyRenderer.materials[1].mainTexture = NudeTexture;
		MyRenderer.materials[2].mainTexture = NudeTexture;
	}

	private IEnumerator ApplyCustomCostume()
	{
		if (StudentGlobals.FemaleUniform == 1)
		{
			WWW CustomUniform4 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
			yield return CustomUniform4;
			if (CustomUniform4.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform4.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform4.texture;
			}
		}
		else if (StudentGlobals.FemaleUniform == 2)
		{
			WWW CustomUniform4 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
			yield return CustomUniform4;
			if (CustomUniform4.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform4.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform4.texture;
			}
		}
		else if (StudentGlobals.FemaleUniform == 3)
		{
			WWW CustomUniform4 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
			yield return CustomUniform4;
			if (CustomUniform4.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform4.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform4.texture;
			}
		}
		else if (StudentGlobals.FemaleUniform == 4 || StudentGlobals.FemaleUniform == 5)
		{
			WWW CustomUniform4 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
			yield return CustomUniform4;
			if (CustomUniform4.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform4.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform4.texture;
			}
		}
		StartCoroutine(ApplyCustomFace());
	}

	private IEnumerator ApplyCustomFace()
	{
		WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
		yield return CustomFace;
		if (CustomFace.error == null)
		{
			MyRenderer.materials[2].mainTexture = CustomFace.texture;
			FaceTexture = CustomFace.texture;
		}
		WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
		yield return CustomHair;
		if (CustomHair.error == null)
		{
			PonytailRenderer.material.mainTexture = CustomHair.texture;
			PigtailR.material.mainTexture = CustomHair.texture;
			PigtailL.material.mainTexture = CustomHair.texture;
		}
		WWW CustomDrills = new WWW("file:///" + Application.streamingAssetsPath + "/CustomDrills.png");
		yield return CustomDrills;
		if (CustomDrills.error == null)
		{
			Drills.materials[0].mainTexture = CustomDrills.texture;
			Drills.materials[1].mainTexture = CustomDrills.texture;
			Drills.materials[2].mainTexture = CustomDrills.texture;
		}
	}
}
