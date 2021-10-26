using UnityEngine;

public class TallLockerScript : MonoBehaviour
{
	public GameObject[] BloodyClubUniform;

	public GameObject[] BloodyUniform;

	public GameObject[] Schoolwear;

	public bool[] Removed;

	public bool[] Bloody;

	public GameObject CleanUniform;

	public GameObject SteamCloud;

	public StudentManagerScript StudentManager;

	public RivalPhoneScript RivalPhone;

	public StudentScript Student;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform Hinge;

	public bool RemovingClubAttire;

	public bool DropCleanUniform;

	public bool SteamCountdown;

	public bool YandereLocker;

	public bool Swapping;

	public bool Open;

	public float Rotation;

	public float Timer;

	public int AvailableUniforms = 2;

	public int Phase = 1;

	private void Start()
	{
		Prompt.HideButton[1] = true;
		Prompt.HideButton[2] = true;
		Prompt.HideButton[3] = true;
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f && !Yandere.Chased && Yandere.Chasers == 0)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Open)
			{
				Open = true;
				if (YandereLocker)
				{
					if (!Yandere.ClubAttire || (Yandere.ClubAttire && Yandere.Bloodiness > 0f))
					{
						if (Yandere.Bloodiness == 0f)
						{
							if (!Bloody[1])
							{
								Prompt.HideButton[1] = false;
							}
							if (!Bloody[2])
							{
								Prompt.HideButton[2] = false;
							}
							if (!Bloody[3])
							{
								Prompt.HideButton[3] = false;
							}
						}
						else if (Yandere.Schoolwear > 0)
						{
							if (!Yandere.ClubAttire)
							{
								Prompt.HideButton[Yandere.Schoolwear] = false;
							}
							else
							{
								Prompt.HideButton[1] = false;
							}
						}
					}
					else
					{
						Prompt.HideButton[1] = true;
						Prompt.HideButton[2] = true;
						Prompt.HideButton[3] = true;
					}
				}
				UpdateSchoolwear();
				Prompt.Label[0].text = "     Close";
			}
			else
			{
				Open = false;
				Prompt.HideButton[1] = true;
				Prompt.HideButton[2] = true;
				Prompt.HideButton[3] = true;
				Prompt.Label[0].text = "     Open";
			}
		}
		if (!Open)
		{
			if (YandereLocker)
			{
				Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 10f);
			}
			Prompt.HideButton[1] = true;
			Prompt.HideButton[2] = true;
			Prompt.HideButton[3] = true;
		}
		else
		{
			if (YandereLocker)
			{
				Rotation = Mathf.Lerp(Rotation, -180f, Time.deltaTime * 10f);
			}
			if (Prompt.Circle[1].fillAmount == 0f)
			{
				Yandere.EmptyHands();
				if (Yandere.ClubAttire)
				{
					RemovingClubAttire = true;
				}
				Yandere.PreviousSchoolwear = Yandere.Schoolwear;
				if (Yandere.Schoolwear == 1)
				{
					Yandere.Schoolwear = 0;
					if (!Removed[1])
					{
						if (Yandere.Bloodiness == 0f)
						{
							DropCleanUniform = true;
						}
					}
					else
					{
						Removed[1] = false;
					}
				}
				else
				{
					Yandere.Schoolwear = 1;
					Removed[1] = true;
				}
				SpawnSteam();
				Yandere.CurrentUniformOrigin = 1;
			}
			else if (Prompt.Circle[2].fillAmount == 0f)
			{
				bool flag = false;
				if (Yandere.Schoolwear > 0)
				{
					Debug.Log("Checking to see if it's okay for the player to take off clothing.");
					CheckAvailableUniforms();
					if (AvailableUniforms > 0)
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					Yandere.EmptyHands();
					if (Yandere.ClubAttire)
					{
						RemovingClubAttire = true;
					}
					Yandere.PreviousSchoolwear = Yandere.Schoolwear;
					if (Yandere.Schoolwear == 1 && !Removed[1])
					{
						DropCleanUniform = true;
					}
					if (Yandere.Schoolwear == 2)
					{
						Yandere.Schoolwear = 0;
						Removed[2] = false;
					}
					else
					{
						Yandere.Schoolwear = 2;
						Removed[2] = true;
					}
					SpawnSteam();
					Yandere.CurrentUniformOrigin = 1;
				}
				else
				{
					Prompt.Circle[2].fillAmount = 1f;
					Debug.Log("Error Message.");
				}
			}
			else if (Prompt.Circle[3].fillAmount == 0f)
			{
				Yandere.EmptyHands();
				if (Yandere.ClubAttire)
				{
					RemovingClubAttire = true;
				}
				Yandere.PreviousSchoolwear = Yandere.Schoolwear;
				if (Yandere.Schoolwear == 1 && !Removed[1])
				{
					DropCleanUniform = true;
				}
				if (Yandere.Schoolwear == 3)
				{
					Yandere.Schoolwear = 0;
					Removed[3] = false;
				}
				else
				{
					Yandere.Schoolwear = 3;
					Removed[3] = true;
				}
				SpawnSteam();
				Yandere.CurrentUniformOrigin = 1;
			}
		}
		if (YandereLocker)
		{
			Hinge.localEulerAngles = new Vector3(0f, Rotation, 0f);
		}
		if (!SteamCountdown)
		{
			return;
		}
		Timer += Time.deltaTime;
		if (Phase == 1)
		{
			if (!(Timer > 1.5f))
			{
				return;
			}
			if (YandereLocker)
			{
				if (Yandere.Gloved)
				{
					Yandere.Gloves.GetComponent<PickUpScript>().MyRigidbody.isKinematic = false;
					Yandere.Gloves.transform.localPosition = new Vector3(0f, 1f, -1f);
					Yandere.Gloves.transform.parent = null;
					Yandere.GloveAttacher.newRenderer.enabled = false;
					Yandere.Gloves.gameObject.SetActive(value: true);
					Yandere.Gloved = false;
					Yandere.Gloves = null;
					Yandere.GloveBlood = 0;
				}
				if (Yandere.WearingRaincoat)
				{
					Yandere.RaincoatAttacher.newRenderer.enabled = false;
					Yandere.PantyAttacher.newRenderer.enabled = true;
					Yandere.TheDebugMenuScript.UpdateCensor();
					Yandere.CoatBloodiness = Yandere.Bloodiness;
					Yandere.Bloodiness = Yandere.OriginalBloodiness;
					Yandere.WearingRaincoat = false;
					Yandere.Hairstyle = 1;
					Yandere.UpdateHair();
				}
				Yandere.ChangeSchoolwear();
				if (Yandere.Bloodiness > 0f)
				{
					PickUpScript pickUpScript = null;
					if (RemovingClubAttire)
					{
						pickUpScript = Object.Instantiate(BloodyClubUniform[(int)Yandere.Club], Yandere.transform.position + Vector3.forward * 0.5f + Vector3.up, Quaternion.identity).GetComponent<PickUpScript>();
						StudentManager.ChangingBooths[(int)Yandere.Club].CannotChange = true;
						StudentManager.ChangingBooths[(int)Yandere.Club].CheckYandereClub();
						Prompt.HideButton[1] = true;
						Prompt.HideButton[2] = true;
						Prompt.HideButton[3] = true;
						RemovingClubAttire = false;
					}
					else
					{
						pickUpScript = Object.Instantiate(BloodyUniform[Yandere.PreviousSchoolwear], Yandere.transform.position + Vector3.forward * 0.5f + Vector3.up, Quaternion.identity).GetComponent<PickUpScript>();
						Prompt.HideButton[Yandere.PreviousSchoolwear] = true;
						Bloody[Yandere.PreviousSchoolwear] = true;
					}
					if (Yandere.RedPaint)
					{
						pickUpScript.RedPaint = true;
					}
				}
			}
			else if (Student != null)
			{
				if (Student.Schoolwear == 0 && !Student.Male && !RivalPhone.gameObject.activeInHierarchy && !Yandere.Inventory.RivalPhone)
				{
					Debug.Log(string.Concat(Student, " just left her smartphone in the locker room!"));
					RivalPhone.transform.parent = StudentManager.StrippingPositions[Student.GirlID];
					RivalPhone.transform.localPosition = new Vector3(0f, 0.92f, 0.2375f);
					RivalPhone.transform.localEulerAngles = new Vector3(-80f, 0f, 0f);
					Physics.SyncTransforms();
					RivalPhone.gameObject.SetActive(value: true);
					RivalPhone.StudentID = Student.StudentID;
					RivalPhone.MyRenderer.material.mainTexture = Student.SmartPhone.GetComponent<Renderer>().material.mainTexture;
				}
				Student.ChangeSchoolwear();
			}
			UpdateSchoolwear();
			Phase++;
		}
		else if (Timer > 3f)
		{
			if (!YandereLocker && Student != null)
			{
				Student.BathePhase++;
			}
			SteamCountdown = false;
			Phase = 1;
			Timer = 0f;
		}
	}

	public void SpawnSteam()
	{
		if (Student != null)
		{
			Debug.Log(string.Concat(Student, " is changing clothes, with all strings attached."));
		}
		SteamCountdown = true;
		if (YandereLocker)
		{
			Object.Instantiate(SteamCloud, Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			Yandere.CharacterAnimation.CrossFade("f02_stripping_00");
			Yandere.Stripping = true;
			Yandere.CanMove = false;
		}
		else
		{
			Object.Instantiate(SteamCloud, Student.transform.position + Vector3.up * 0.81f, Quaternion.identity).transform.parent = Student.transform;
			Student.CharacterAnimation.CrossFade(Student.StripAnim);
			Student.Pathfinding.canSearch = false;
			Student.Pathfinding.canMove = false;
		}
	}

	public void SpawnSteamNoSideEffects(StudentScript SteamStudent)
	{
		Debug.Log(string.Concat(SteamStudent, " is changing clothes, no strings attached."));
		Object.Instantiate(SteamCloud, SteamStudent.transform.position + Vector3.up * 0.81f, Quaternion.identity).transform.parent = SteamStudent.transform;
		SteamStudent.CharacterAnimation.CrossFade(SteamStudent.StripAnim);
		SteamStudent.Pathfinding.canSearch = false;
		SteamStudent.Pathfinding.canMove = false;
		SteamStudent.MustChangeClothing = false;
		SteamStudent.Stripping = true;
		SteamStudent.Routine = false;
		SteamStudent.WalkAnim = SteamStudent.OriginalOriginalWalkAnim;
	}

	public void UpdateSchoolwear()
	{
		if (DropCleanUniform)
		{
			Object.Instantiate(CleanUniform, Yandere.transform.position + Vector3.forward * -0.5f + Vector3.up, Quaternion.identity);
			DropCleanUniform = false;
		}
		if (!Bloody[1])
		{
			Schoolwear[1].SetActive(value: true);
		}
		if (!Bloody[2])
		{
			Schoolwear[2].SetActive(value: true);
		}
		if (!Bloody[3])
		{
			Schoolwear[3].SetActive(value: true);
		}
		Prompt.Label[1].text = "     School Uniform";
		Prompt.Label[2].text = "     School Swimsuit";
		Prompt.Label[3].text = "     Gym Uniform";
		if (YandereLocker)
		{
			if (!Yandere.ClubAttire)
			{
				if (Yandere.Schoolwear > 0)
				{
					Prompt.Label[Yandere.Schoolwear].text = "     Towel";
					if (Removed[Yandere.Schoolwear])
					{
						Schoolwear[Yandere.Schoolwear].SetActive(value: false);
					}
				}
			}
			else
			{
				Prompt.Label[1].text = "     Towel";
			}
		}
		else if (Student != null && Student.Schoolwear > 0)
		{
			Prompt.HideButton[Student.Schoolwear] = true;
			Schoolwear[Student.Schoolwear].SetActive(value: false);
			Student.Indoors = true;
		}
	}

	public void UpdateButtons()
	{
		if (!Yandere.ClubAttire || (Yandere.ClubAttire && Yandere.Bloodiness > 0f))
		{
			if (!Open)
			{
				return;
			}
			if (Yandere.Bloodiness > 0f)
			{
				Prompt.HideButton[1] = true;
				Prompt.HideButton[2] = true;
				Prompt.HideButton[3] = true;
				if (Yandere.Schoolwear > 0 && !Yandere.ClubAttire)
				{
					Prompt.HideButton[Yandere.Schoolwear] = false;
				}
				if (Yandere.ClubAttire)
				{
					Debug.Log("Don't hide Prompt 1!");
					Prompt.HideButton[1] = false;
				}
			}
			else
			{
				if (!Bloody[1])
				{
					Prompt.HideButton[1] = false;
				}
				if (!Bloody[2])
				{
					Prompt.HideButton[2] = false;
				}
				if (!Bloody[3])
				{
					Prompt.HideButton[3] = false;
				}
			}
		}
		else
		{
			Prompt.HideButton[1] = true;
			Prompt.HideButton[2] = true;
			Prompt.HideButton[3] = true;
		}
	}

	private void CheckAvailableUniforms()
	{
		AvailableUniforms = StudentManager.OriginalUniforms;
		Debug.Log(AvailableUniforms + " of the original uniforms are still clean.");
		Debug.Log("There are " + StudentManager.NewUniforms + " new uniforms in school.");
		if (StudentManager.NewUniforms <= 0)
		{
			return;
		}
		int num = 0;
		for (num = 0; num < StudentManager.Uniforms.Length; num++)
		{
			Transform transform = StudentManager.Uniforms[num];
			if (transform != null && StudentManager.LockerRoomArea.bounds.Contains(transform.position))
			{
				Debug.Log("Cool, there's a uniform in the locker room.");
				AvailableUniforms++;
			}
		}
	}
}
