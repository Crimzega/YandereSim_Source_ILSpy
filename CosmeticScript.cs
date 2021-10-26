using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CosmeticScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public TextureManagerScript TextureManager;

	public SkinnedMeshUpdater SkinUpdater;

	public LoveManagerScript LoveManager;

	public Animation CharacterAnimation;

	public ModelSwapScript ModelSwap;

	public StudentScript Student;

	public JsonScript JSON;

	public GameObject[] TeacherAccessories;

	public GameObject[] FemaleAccessories;

	public GameObject[] MaleAccessories;

	public GameObject[] ClubAccessories;

	public GameObject[] PunkAccessories;

	public GameObject[] RightStockings;

	public GameObject[] LeftStockings;

	public GameObject[] CouncilBrows;

	public GameObject[] PhoneCharms;

	public GameObject[] TeacherHair;

	public GameObject[] FacialHair;

	public GameObject[] FemaleHair;

	public GameObject[] MusicNotes;

	public GameObject[] Kerchiefs;

	public GameObject[] CatGifts;

	public GameObject[] MaleHair;

	public GameObject[] RedCloth;

	public GameObject[] Scanners;

	public GameObject[] Eyewear;

	public GameObject[] Goggles;

	public GameObject[] Flowers;

	public GameObject[] Masks;

	public GameObject[] Roses;

	public Renderer[] TeacherHairRenderers;

	public Renderer[] FacialHairRenderers;

	public Renderer[] FemaleHairRenderers;

	public Renderer[] MaleHairRenderers;

	public Renderer[] Fingernails;

	public Texture[] GanguroSwimsuitTextures;

	public Texture[] GanguroUniformTextures;

	public Texture[] GanguroCasualTextures;

	public Texture[] GanguroSocksTextures;

	public Texture[] GanguroNailTextures;

	public Texture[] ObstacleUniformTextures;

	public Texture[] ObstacleCasualTextures;

	public Texture[] ObstacleSocksTextures;

	public Texture[] OccultUniformTextures;

	public Texture[] OccultCasualTextures;

	public Texture[] OccultSocksTextures;

	public Texture[] FemaleUniformTextures;

	public Texture[] FemaleCasualTextures;

	public Texture[] FemaleSocksTextures;

	public Texture[] MaleUniformTextures;

	public Texture[] MaleCasualTextures;

	public Texture[] MaleSocksTextures;

	public Texture[] SmartphoneTextures;

	public Texture[] HoodieTextures;

	public Texture[] FaceTextures;

	public Texture[] SkinTextures;

	public Texture[] WristwearTextures;

	public Texture[] CardiganTextures;

	public Texture[] BookbagTextures;

	public Texture[] EyeTextures;

	public Texture[] CheekTextures;

	public Texture[] ForeheadTextures;

	public Texture[] MouthTextures;

	public Texture[] NoseTextures;

	public Texture[] ApronTextures;

	public Texture[] CanTextures;

	public Texture[] Trunks;

	public Texture[] MusicStockings;

	public Mesh[] FemaleUniforms;

	public Mesh[] MaleUniforms;

	public Mesh[] Berets;

	public Color[] BullyColor;

	public SkinnedMeshRenderer CardiganRenderer;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer FacialHairRenderer;

	public Renderer RightEyeRenderer;

	public Renderer LeftEyeRenderer;

	public Renderer HoodieRenderer;

	public Renderer ScarfRenderer;

	public Renderer HairRenderer;

	public Renderer CanRenderer;

	public Mesh EightiesDelinquentMesh;

	public Mesh DelinquentMesh;

	public Mesh SchoolUniform;

	public Mesh SukebanMesh;

	public Texture DefaultFaceTexture;

	public Texture TeacherBodyTexture;

	public Texture CoachPaleBodyTexture;

	public Texture CoachBodyTexture;

	public Texture CoachFaceTexture;

	public Texture UniformTexture;

	public Texture CasualTexture;

	public Texture SocksTexture;

	public Texture FaceTexture;

	public Texture PurpleStockings;

	public Texture YellowStockings;

	public Texture BlackStockings;

	public Texture GreenStockings;

	public Texture BlueStockings;

	public Texture CyanStockings;

	public Texture RedStockings;

	public Texture YellowSocks;

	public Texture GreenSocks;

	public Texture BlueSocks;

	public Texture RedSocks;

	public Texture BlackKneeSocks;

	public Texture KizanaStockings;

	public Texture OsanaStockings;

	public Texture AmaiStockings;

	public Texture TurtleStockings;

	public Texture TigerStockings;

	public Texture BirdStockings;

	public Texture DragonStockings;

	public Texture[] EightiesRivalStockings;

	public Texture[] CustomStockings;

	public Texture MyStockings;

	public Texture BlackBody;

	public Texture BlackFace;

	public Texture GrayFace;

	public Texture EightiesDelinquentUniformTexture;

	public Texture EightiesDelinquentCasualTexture;

	public Texture EightiesDelinquentSocksTexture;

	public Texture EightiesMaleUniformTexture;

	public Texture EightiesMaleCasualTexture;

	public Texture EightiesMaleSocksTexture;

	public Texture OsanaSwimsuitTexture;

	public Texture ObstacleSwimsuitTexture;

	public Texture ObstacleTowelTexture;

	public Texture ObstacleGymTexture;

	public Texture TanSwimsuitTexture;

	public Texture TanTowelTexture;

	public Texture TanGymTexture;

	public Texture WaifuIrisTexture;

	public Texture WaifuEyeTexture;

	public Texture AmaiApron;

	public Texture NewspaperArmbandTexture;

	public Texture TanCouncilUniform;

	public GameObject RightIrisLight;

	public GameObject LeftIrisLight;

	public GameObject RightWristband;

	public GameObject LeftWristband;

	public GameObject Cardigan;

	public GameObject Bookbag;

	public GameObject ThickBrows;

	public GameObject Character;

	public GameObject RightShoe;

	public GameObject LeftShoe;

	public GameObject SadBrows;

	public GameObject Armband;

	public GameObject Hoodie;

	public GameObject Tongue;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform RightTemple;

	public Transform LeftTemple;

	public Transform Head;

	public Transform Neck;

	public Color CorrectColor;

	public Color ColorValue;

	public Mesh EightiesNurseMesh;

	public Mesh TeacherMesh;

	public Mesh CoachMesh;

	public Mesh NurseMesh;

	public bool MysteriousObstacle;

	public bool DoNotChangeFace;

	public bool TakingPortrait;

	public bool Initialized;

	public bool CustomEyes;

	public bool CustomHair;

	public bool LookCamera;

	public bool HomeScene;

	public bool Kidnapped;

	public bool Randomize;

	public bool Cutscene;

	public bool Eighties;

	public bool Modified;

	public bool TurnedOn;

	public bool Medibang;

	public bool Teacher;

	public bool Yandere;

	public bool Empty;

	public bool Male;

	public float BreastSize;

	public string OriginalStockings = string.Empty;

	public string HairColor = string.Empty;

	public string Stockings = string.Empty;

	public string EyeColor = string.Empty;

	public string EyeType = string.Empty;

	public string Name = string.Empty;

	public int FacialHairstyle;

	public int Accessory;

	public int Direction;

	public int Hairstyle;

	public int SkinColor;

	public int StudentID;

	public int EyewearID;

	public ClubType Club;

	public int ID;

	public GameObject[] GaloAccessories;

	public Material[] NurseMaterials;

	public GameObject CardiganPrefab;

	public int FaceID;

	public int SkinID;

	public int UniformID;

	public void Start()
	{
		if (StudentManager != null)
		{
			Eighties = StudentManager.Eighties;
		}
		else
		{
			Eighties = GameGlobals.Eighties;
		}
		if (Eighties && Male)
		{
			MaleUniformTextures[1] = EightiesMaleUniformTexture;
			MaleCasualTextures[1] = EightiesMaleCasualTexture;
			MaleSocksTextures[1] = EightiesMaleSocksTexture;
		}
		if (Cutscene && EventGlobals.OsanaConversation)
		{
			StudentID = 11;
		}
		if (RightShoe != null)
		{
			RightShoe.SetActive(value: false);
			LeftShoe.SetActive(value: false);
		}
		ColorValue = new Color(1f, 1f, 1f, 1f);
		if (JSON == null)
		{
			JSON = Student.JSON;
		}
		string empty = string.Empty;
		if (!Initialized)
		{
			Accessory = int.Parse(JSON.Students[StudentID].Accessory);
			Hairstyle = int.Parse(JSON.Students[StudentID].Hairstyle);
			Stockings = JSON.Students[StudentID].Stockings;
			BreastSize = JSON.Students[StudentID].BreastSize;
			EyeType = JSON.Students[StudentID].EyeType;
			HairColor = JSON.Students[StudentID].Color;
			EyeColor = JSON.Students[StudentID].Eyes;
			Club = JSON.Students[StudentID].Club;
			Name = JSON.Students[StudentID].Name;
			if (Yandere)
			{
				Accessory = 0;
				Hairstyle = 1;
				Stockings = "Black";
				BreastSize = 1f;
				HairColor = "White";
				EyeColor = "Black";
				Club = ClubType.None;
			}
			OriginalStockings = Stockings;
			Initialized = true;
		}
		if (Medibang)
		{
			Accessory = 0;
			Hairstyle = 56;
			Stockings = "";
			BreastSize = 1f;
			EyeType = "";
			HairColor = "";
			EyeColor = "";
			Club = ClubType.Occult;
			Name = "Edgy Example Girl";
		}
		if (!Eighties)
		{
			if (StudentID == 11)
			{
				if (DateGlobals.Week > 1 && !Kidnapped && !Student.Slave)
				{
					Hairstyle = 54;
				}
			}
			else if (StudentID == 36)
			{
				FacialHairstyle = 12;
				EyewearID = 8;
				if (StudentManager.TaskManager != null && StudentManager.TaskManager.TaskStatus[36] == 3)
				{
					Debug.Log("Gema is updating his appearance.");
					FacialHairstyle = 0;
					EyewearID = 9;
					Hairstyle = 49;
					Accessory = 0;
				}
			}
			else if (StudentID == 51 && ClubGlobals.GetClubClosed(ClubType.LightMusic))
			{
				Hairstyle = 51;
			}
		}
		if (StudentManager != null && StudentManager.EmptyDemon && (StudentID == 21 || StudentID == 26 || StudentID == 31 || StudentID == 36 || StudentID == 41 || StudentID == 46 || StudentID == 51 || StudentID == 56 || StudentID == 61 || StudentID == 66 || StudentID == 71))
		{
			if (!Male)
			{
				Hairstyle = 52;
			}
			else
			{
				Hairstyle = 53;
			}
			FacialHairstyle = 0;
			EyewearID = 0;
			Accessory = 0;
			Stockings = "";
			BreastSize = 1f;
			Empty = true;
		}
		if (Name == "Random")
		{
			Randomize = true;
			if (!Male)
			{
				empty = StudentManager.FirstNames[Random.Range(0, StudentManager.FirstNames.Length)] + " " + StudentManager.LastNames[Random.Range(0, StudentManager.LastNames.Length)];
				JSON.Students[StudentID].Name = empty;
				Student.Name = empty;
			}
			else
			{
				empty = StudentManager.MaleNames[Random.Range(0, StudentManager.MaleNames.Length)] + " " + StudentManager.LastNames[Random.Range(0, StudentManager.LastNames.Length)];
				JSON.Students[StudentID].Name = empty;
				Student.Name = empty;
			}
			if (MissionModeGlobals.MissionMode && MissionModeGlobals.MissionTarget == StudentID)
			{
				JSON.Students[StudentID].Name = MissionModeGlobals.MissionTargetName;
				Student.Name = MissionModeGlobals.MissionTargetName;
				empty = MissionModeGlobals.MissionTargetName;
			}
		}
		if (Randomize)
		{
			Teacher = false;
			BreastSize = Random.Range(0.5f, 2f);
			Accessory = 0;
			Club = ClubType.None;
			if (!Male)
			{
				Hairstyle = Random.Range(1, FemaleHair.Length);
			}
			else
			{
				SkinColor = Random.Range(0, SkinTextures.Length);
				Hairstyle = Random.Range(1, MaleHair.Length);
			}
		}
		GameObject[] femaleAccessories = FemaleAccessories;
		foreach (GameObject gameObject in femaleAccessories)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
		femaleAccessories = MaleAccessories;
		foreach (GameObject gameObject2 in femaleAccessories)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(value: false);
			}
		}
		femaleAccessories = ClubAccessories;
		foreach (GameObject gameObject3 in femaleAccessories)
		{
			if (gameObject3 != null)
			{
				gameObject3.SetActive(value: false);
			}
		}
		femaleAccessories = TeacherAccessories;
		foreach (GameObject gameObject4 in femaleAccessories)
		{
			if (gameObject4 != null)
			{
				gameObject4.SetActive(value: false);
			}
		}
		femaleAccessories = TeacherHair;
		foreach (GameObject gameObject5 in femaleAccessories)
		{
			if (gameObject5 != null)
			{
				gameObject5.SetActive(value: false);
			}
		}
		femaleAccessories = FemaleHair;
		foreach (GameObject gameObject6 in femaleAccessories)
		{
			if (gameObject6 != null)
			{
				gameObject6.SetActive(value: false);
			}
		}
		femaleAccessories = MaleHair;
		foreach (GameObject gameObject7 in femaleAccessories)
		{
			if (gameObject7 != null)
			{
				gameObject7.SetActive(value: false);
			}
		}
		femaleAccessories = FacialHair;
		foreach (GameObject gameObject8 in femaleAccessories)
		{
			if (gameObject8 != null)
			{
				gameObject8.SetActive(value: false);
			}
		}
		femaleAccessories = Eyewear;
		foreach (GameObject gameObject9 in femaleAccessories)
		{
			if (gameObject9 != null)
			{
				gameObject9.SetActive(value: false);
			}
		}
		femaleAccessories = RightStockings;
		foreach (GameObject gameObject10 in femaleAccessories)
		{
			if (gameObject10 != null)
			{
				gameObject10.SetActive(value: false);
			}
		}
		femaleAccessories = LeftStockings;
		foreach (GameObject gameObject11 in femaleAccessories)
		{
			if (gameObject11 != null)
			{
				gameObject11.SetActive(value: false);
			}
		}
		femaleAccessories = Scanners;
		foreach (GameObject gameObject12 in femaleAccessories)
		{
			if (gameObject12 != null)
			{
				gameObject12.SetActive(value: false);
			}
		}
		femaleAccessories = Flowers;
		foreach (GameObject gameObject13 in femaleAccessories)
		{
			if (gameObject13 != null)
			{
				gameObject13.SetActive(value: false);
			}
		}
		femaleAccessories = Roses;
		foreach (GameObject gameObject14 in femaleAccessories)
		{
			if (gameObject14 != null)
			{
				gameObject14.SetActive(value: false);
			}
		}
		femaleAccessories = Goggles;
		foreach (GameObject gameObject15 in femaleAccessories)
		{
			if (gameObject15 != null)
			{
				gameObject15.SetActive(value: false);
			}
		}
		femaleAccessories = RedCloth;
		foreach (GameObject gameObject16 in femaleAccessories)
		{
			if (gameObject16 != null)
			{
				gameObject16.SetActive(value: false);
			}
		}
		femaleAccessories = Kerchiefs;
		foreach (GameObject gameObject17 in femaleAccessories)
		{
			if (gameObject17 != null)
			{
				gameObject17.SetActive(value: false);
			}
		}
		femaleAccessories = CatGifts;
		foreach (GameObject gameObject18 in femaleAccessories)
		{
			if (gameObject18 != null)
			{
				gameObject18.SetActive(value: false);
			}
		}
		femaleAccessories = PunkAccessories;
		foreach (GameObject gameObject19 in femaleAccessories)
		{
			if (gameObject19 != null)
			{
				gameObject19.SetActive(value: false);
			}
		}
		femaleAccessories = MusicNotes;
		foreach (GameObject gameObject20 in femaleAccessories)
		{
			if (gameObject20 != null)
			{
				gameObject20.SetActive(value: false);
			}
		}
		femaleAccessories = Masks;
		foreach (GameObject gameObject21 in femaleAccessories)
		{
			if (gameObject21 != null)
			{
				gameObject21.SetActive(value: false);
			}
		}
		femaleAccessories = CouncilBrows;
		foreach (GameObject gameObject22 in femaleAccessories)
		{
			if (gameObject22 != null)
			{
				gameObject22.SetActive(value: false);
			}
		}
		bool flag = false;
		if (StudentManager != null && StudentID == StudentManager.SuitorID)
		{
			flag = true;
		}
		if (flag && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorEyewear > 0)
		{
			Eyewear[StudentGlobals.CustomSuitorEyewear].SetActive(value: true);
		}
		if (!Male)
		{
			ThickBrows.SetActive(value: false);
			if (!TakingPortrait)
			{
				Tongue.SetActive(value: false);
			}
			femaleAccessories = PhoneCharms;
			foreach (GameObject gameObject23 in femaleAccessories)
			{
				if (gameObject23 != null)
				{
					gameObject23.SetActive(value: false);
				}
			}
			if (QualitySettings.GetQualityLevel() > 1)
			{
				Student.BreastSize = 1f;
				BreastSize = 1f;
			}
			RightBreast.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
			LeftBreast.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
			RightWristband.SetActive(value: false);
			LeftWristband.SetActive(value: false);
			if (!Eighties)
			{
				if (StudentID == 51)
				{
					RightTemple.name = "RENAMED";
					LeftTemple.name = "RENAMED";
					RightTemple.localScale = new Vector3(0f, 1f, 1f);
					LeftTemple.localScale = new Vector3(0f, 1f, 1f);
					if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
					{
						SadBrows.SetActive(value: true);
					}
					else
					{
						ThickBrows.SetActive(value: true);
					}
				}
				else if (StudentID == 84 && StudentGlobals.GetStudentDead(81) && StudentGlobals.GetStudentDead(82) && StudentGlobals.GetStudentDead(83) && StudentGlobals.GetStudentDead(85))
				{
					Student.Club = ClubType.None;
					Club = ClubType.None;
					Hairstyle = 53;
				}
			}
			if (Club == ClubType.Bully)
			{
				if (!Kidnapped)
				{
					Student.SmartPhone.GetComponent<Renderer>().material.mainTexture = SmartphoneTextures[StudentID];
					Student.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
					Student.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
				}
				RightWristband.GetComponent<Renderer>().material.mainTexture = WristwearTextures[StudentID];
				LeftWristband.GetComponent<Renderer>().material.mainTexture = WristwearTextures[StudentID];
				Bookbag.GetComponent<Renderer>().material.mainTexture = BookbagTextures[StudentID];
				HoodieRenderer.material.mainTexture = HoodieTextures[StudentID];
				if (PhoneCharms.Length != 0)
				{
					PhoneCharms[StudentID].SetActive(value: true);
				}
				if (StudentGlobals.FemaleUniform < 2 || StudentGlobals.FemaleUniform == 3)
				{
					RightWristband.SetActive(value: true);
					LeftWristband.SetActive(value: true);
				}
				Bookbag.SetActive(value: true);
				Hoodie.SetActive(value: true);
				for (int j = 0; j < 10; j++)
				{
					Fingernails[j].material.mainTexture = GanguroNailTextures[StudentID];
				}
				Student.GymTexture = TanGymTexture;
				Student.TowelTexture = TanTowelTexture;
			}
			else
			{
				for (int k = 0; k < 10; k++)
				{
					Fingernails[k].gameObject.SetActive(value: false);
				}
				if (Club == ClubType.Gardening && !TakingPortrait && !Kidnapped)
				{
					CanRenderer.material.mainTexture = CanTextures[StudentID];
				}
			}
			if (!Kidnapped && SceneManager.GetActiveScene().name == "PortraitScene")
			{
				if (!Eighties)
				{
					if (StudentID == 2)
					{
						CharacterAnimation.Play("succubus_a_idle_twins_01");
						base.transform.position = new Vector3(0.094f, 0f, 0f);
						LookCamera = true;
						CharacterAnimation["f02_smile_00"].layer = 1;
						CharacterAnimation.Play("f02_smile_00");
						CharacterAnimation["f02_smile_00"].weight = 1f;
					}
					else if (StudentID == 3)
					{
						CharacterAnimation.Play("succubus_b_idle_twins_02");
						base.transform.position = new Vector3(-0.332f, 0f, 0f);
						LookCamera = true;
						CharacterAnimation["f02_smile_00"].layer = 1;
						CharacterAnimation.Play("f02_smile_00");
						CharacterAnimation["f02_smile_00"].weight = 1f;
					}
					else if (StudentID == 4)
					{
						CharacterAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						LookCamera = true;
					}
					else if (StudentID == 5)
					{
						CharacterAnimation.Play("f02_shy_00");
						CharacterAnimation.Play("f02_shy_00");
						CharacterAnimation["f02_shy_00"].time = 1f;
					}
					else if (StudentID == 10)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
					}
					else if (StudentID == 24)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						CharacterAnimation["f02_idleGirly_00"].time = 1f;
					}
					else if (StudentID == 25)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						CharacterAnimation["f02_idleGirly_00"].time = 0f;
					}
					else if (StudentID == 30)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						CharacterAnimation["f02_idleGirly_00"].time = 0f;
					}
					else if (StudentID == 34)
					{
						CharacterAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						LookCamera = true;
					}
					else if (StudentID == 35)
					{
						CharacterAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						LookCamera = true;
					}
					else if (StudentID == 38)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						CharacterAnimation["f02_idleGirly_00"].time = 0f;
					}
					else if (StudentID == 39)
					{
						CharacterAnimation.Play("f02_socialCameraPose_00");
						base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.05f, base.transform.position.z);
					}
					else if (StudentID == 40)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						CharacterAnimation["f02_idleGirly_00"].time = 1f;
					}
					else if (StudentID == 51)
					{
						CharacterAnimation.Play("f02_musicPose_00");
						Tongue.SetActive(value: true);
					}
					else if (StudentID == 59)
					{
						CharacterAnimation.Play("f02_sleuthPortrait_00");
					}
					else if (StudentID == 60)
					{
						CharacterAnimation.Play("f02_sleuthPortrait_01");
					}
					else if (StudentID == 64)
					{
						CharacterAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						LookCamera = true;
					}
					else if (StudentID == 65)
					{
						CharacterAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						LookCamera = true;
					}
					else if (StudentID == 71)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						CharacterAnimation["f02_idleGirly_00"].time = 0f;
					}
					else if (StudentID == 72)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						CharacterAnimation["f02_idleGirly_00"].time = 0.66666f;
					}
					else if (StudentID == 73)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						CharacterAnimation["f02_idleGirly_00"].time = 1.33332f;
					}
					else if (StudentID == 74)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						CharacterAnimation["f02_idleGirly_00"].time = 1.99998f;
					}
					else if (StudentID == 75)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						CharacterAnimation["f02_idleGirly_00"].time = 2.66664f;
					}
					else if (StudentID == 81)
					{
						string text = "";
						text = "Casual";
						CharacterAnimation["f02_faceCouncil" + text + "_00"].layer = 1;
						CharacterAnimation.Play("f02_faceCouncil" + text + "_00");
						CharacterAnimation.Play("f02_socialCameraPose_00");
						base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.05f, base.transform.position.z);
					}
					else if (StudentID == 82 || StudentID == 52)
					{
						CharacterAnimation.Play("f02_galPose_01");
					}
					else if (StudentID == 83 || StudentID == 53)
					{
						CharacterAnimation.Play("f02_galPose_02");
					}
					else if (StudentID == 84 || StudentID == 54)
					{
						CharacterAnimation.Play("f02_galPose_03");
					}
					else if (StudentID == 85 || StudentID == 55)
					{
						CharacterAnimation.Play("f02_galPose_04");
					}
					else if (Club != ClubType.Council)
					{
						CharacterAnimation.Play("f02_idleShort_01");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						LookCamera = true;
					}
				}
				else
				{
					base.transform.position = new Vector3(0.015f, 0f, 0f);
					if (StudentID == 4)
					{
						CharacterAnimation.Play("f02_cutePose_00");
					}
					else if (StudentID == 11)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						base.transform.position = new Vector3(-0.02f, 0f, 0f);
					}
					else if (StudentID == 12)
					{
						CharacterAnimation.Play("f02_idleConfident_01");
					}
					else if (StudentID == 13)
					{
						CharacterAnimation.Play("f02_idleShy_00");
						base.transform.position = new Vector3(-0.005f, 0f, 0f);
					}
					else if (StudentID == 14)
					{
						CharacterAnimation.Play("f02_idleLively_00");
						base.transform.position = new Vector3(0.01f, 0f, 0f);
					}
					else if (StudentID == 15)
					{
						CharacterAnimation.Play("f02_idleHaughty_00");
						base.transform.position = new Vector3(0f, 0f, 0f);
					}
					else if (StudentID == 16)
					{
						CharacterAnimation.Play("f02_idleGirly_00");
						base.transform.position = new Vector3(-0.02f, 0f, 0f);
					}
					else if (StudentID == 17)
					{
						CharacterAnimation.Play("f02_idleCouncilGrace_00");
						base.transform.position = new Vector3(-0.085f, 0f, 0f);
					}
					else if (StudentID == 18)
					{
						CharacterAnimation.Play("f02_idleCouncilStrict_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
					}
					else if (StudentID == 19)
					{
						CharacterAnimation.Play("f02_idleElegant_00");
						base.transform.position = new Vector3(0.02f, 0f, 0f);
					}
					else if (StudentID == 20)
					{
						CharacterAnimation.Play("f02_idleConfident_00");
						base.transform.position = new Vector3(0.01f, 0f, 0f);
					}
					if ((StudentID > 2 && StudentID < 7) || StudentID == 11 || StudentID == 12 || StudentID == 14 || StudentID == 16 || StudentID == 17 || StudentID == 18 || StudentID == 19)
					{
						CharacterAnimation["f02_smile_00"].layer = 1;
						CharacterAnimation.Play("f02_smile_00");
						CharacterAnimation["f02_smile_00"].weight = 1f;
					}
				}
			}
		}
		else
		{
			femaleAccessories = GaloAccessories;
			for (int i = 0; i < femaleAccessories.Length; i++)
			{
				femaleAccessories[i].SetActive(value: false);
			}
			bool flag2 = false;
			if (StudentManager != null && StudentID == StudentManager.SuitorID)
			{
				flag2 = true;
			}
			if (flag2 && StudentGlobals.CustomSuitor)
			{
				if (StudentGlobals.CustomSuitorHair > 0)
				{
					Hairstyle = StudentGlobals.CustomSuitorHair;
				}
				if (StudentGlobals.CustomSuitorAccessory > 0)
				{
					Accessory = StudentGlobals.CustomSuitorAccessory;
					if (Accessory == 1)
					{
						Transform obj = MaleAccessories[1].transform;
						obj.localScale = new Vector3(1.066666f, 1f, 1f);
						obj.localPosition = new Vector3(0f, -1.525f, 0.0066666f);
					}
				}
				if (StudentGlobals.CustomSuitorBlack)
				{
					HairColor = "SolidBlack";
				}
				if (StudentGlobals.CustomSuitorJewelry > 0)
				{
					femaleAccessories = GaloAccessories;
					for (int i = 0; i < femaleAccessories.Length; i++)
					{
						femaleAccessories[i].SetActive(value: true);
					}
				}
			}
			if (StudentManager == null || !Eighties)
			{
				ThickBrows.SetActive(value: false);
				if (Club == ClubType.Occult)
				{
					CharacterAnimation["sadFace_00"].layer = 1;
					CharacterAnimation.Play("sadFace_00");
					CharacterAnimation["sadFace_00"].weight = 1f;
				}
				if (StudentID == 36 || StudentID == 66)
				{
					CharacterAnimation["toughFace_00"].layer = 1;
					CharacterAnimation.Play("toughFace_00");
					CharacterAnimation["toughFace_00"].weight = 1f;
					if (StudentID == 66)
					{
						ThickBrows.SetActive(value: true);
					}
				}
				if (SceneManager.GetActiveScene().name == "PortraitScene")
				{
					if (StudentID == 26)
					{
						CharacterAnimation.Play("idleHaughty_00");
					}
					else if (StudentID == 36)
					{
						CharacterAnimation.Play("slouchIdle_00");
					}
					else if (StudentID == 56)
					{
						CharacterAnimation.Play("idleConfident_00");
					}
					else if (StudentID == 57)
					{
						CharacterAnimation.Play("sleuthPortrait_00");
					}
					else if (StudentID == 58)
					{
						CharacterAnimation.Play("sleuthPortrait_01");
					}
					else if (StudentID == 61)
					{
						CharacterAnimation.Play("scienceMad_00");
						base.transform.position = new Vector3(0f, 0.1f, 0f);
					}
					else if (StudentID == 62)
					{
						CharacterAnimation.Play("idleFrown_00");
					}
					else if (StudentID == 69)
					{
						CharacterAnimation.Play("idleFrown_00");
					}
					else if (StudentID == 76)
					{
						CharacterAnimation.Play("delinquentPoseB");
					}
					else if (StudentID == 77)
					{
						CharacterAnimation.Play("delinquentPoseA");
					}
					else if (StudentID == 78)
					{
						CharacterAnimation.Play("delinquentPoseC");
					}
					else if (StudentID == 79)
					{
						CharacterAnimation.Play("delinquentPoseD");
					}
					else if (StudentID == 80)
					{
						CharacterAnimation.Play("delinquentPoseE");
					}
				}
			}
			else
			{
				if (Eighties)
				{
					if (StudentID == 86)
					{
						CharacterAnimation["toughFace_00"].layer = 1;
						CharacterAnimation.Play("toughFace_00");
						CharacterAnimation["toughFace_00"].weight = 1f;
					}
					if (Club == ClubType.Council)
					{
						CouncilBrows[StudentID - 85].SetActive(value: true);
					}
					if (StudentID == 76)
					{
						CharacterAnimation.Play("delinquentPoseB");
					}
					else if (StudentID == 77)
					{
						CharacterAnimation.Play("delinquentPoseA");
					}
					else if (StudentID == 78)
					{
						CharacterAnimation.Play("delinquentPoseC");
					}
					else if (StudentID == 79)
					{
						CharacterAnimation.Play("delinquentPoseD");
					}
					else if (StudentID == 80)
					{
						CharacterAnimation.Play("delinquentPoseE");
					}
				}
				if (Club == ClubType.Delinquent)
				{
					base.transform.position = new Vector3(0.005f, 0.03f, 0f);
				}
				else
				{
					base.transform.position = new Vector3(0.005f, 0f, 0f);
				}
			}
		}
		if (Club == ClubType.Teacher)
		{
			MyRenderer.sharedMesh = TeacherMesh;
			if (!SystemInfo.supportsComputeShaders)
			{
				MyRenderer.sharedMesh.ClearBlendShapes();
			}
			Teacher = true;
			if (Eighties)
			{
				Student.EightiesTeacherAttacher.SetActive(value: true);
				Student.MyRenderer.enabled = false;
			}
		}
		else if (Club == ClubType.GymTeacher)
		{
			if (!StudentGlobals.GetStudentReplaced(StudentID))
			{
				CharacterAnimation["f02_smile_00"].layer = 1;
				CharacterAnimation.Play("f02_smile_00");
				CharacterAnimation["f02_smile_00"].weight = 1f;
				RightEyeRenderer.gameObject.SetActive(value: false);
				LeftEyeRenderer.gameObject.SetActive(value: false);
			}
			MyRenderer.sharedMesh = CoachMesh;
			Teacher = true;
		}
		else if (Club == ClubType.Nurse)
		{
			MyRenderer.sharedMesh = NurseMesh;
			Teacher = true;
		}
		else if (Club == ClubType.Council)
		{
			Armband.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(-103f / 160f, 0f));
			Armband.SetActive(value: true);
			string text2 = "";
			if (StudentID == 86)
			{
				text2 = "Strict";
			}
			if (StudentID == 87)
			{
				text2 = "Casual";
			}
			if (StudentID == 88)
			{
				text2 = "Grace";
			}
			if (StudentID == 89)
			{
				text2 = "Edgy";
			}
			if (!Eighties)
			{
				CharacterAnimation["f02_faceCouncil" + text2 + "_00"].layer = 1;
				CharacterAnimation.Play("f02_faceCouncil" + text2 + "_00");
				CharacterAnimation["f02_idleCouncil" + text2 + "_00"].time = 1f;
				CharacterAnimation.Play("f02_idleCouncil" + text2 + "_00");
			}
		}
		if (!ClubGlobals.GetClubClosed(Club) && (StudentID == 21 || StudentID == 26 || StudentID == 31 || StudentID == 36 || StudentID == 41 || StudentID == 46 || StudentID == 51 || StudentID == 56 || StudentID == 61 || StudentID == 66 || StudentID == 71))
		{
			Armband.SetActive(value: true);
			Renderer component = Armband.GetComponent<Renderer>();
			if (StudentID == 21)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(-0.63f, -0.22f));
			}
			else if (StudentID == 26)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.22f));
			}
			else if (StudentID == 31)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.69f, 0.01f));
			}
			else if (StudentID == 36)
			{
				if (!Eighties)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(-0.633333f, -0.44f));
				}
				else
				{
					component.material.mainTexture = NewspaperArmbandTexture;
					component.material.SetTextureOffset("_MainTex", new Vector2(0f, 0.0075f));
				}
			}
			else if (StudentID == 41)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(-0.62f, -0.66666f));
			}
			else if (StudentID == 46)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.66666f));
			}
			else if (StudentID == 51)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.69f, 0.5566666f));
			}
			else if (StudentID == 56)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, 0.5533333f));
			}
			else if (StudentID == 61)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
			}
			else if (StudentID == 66)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.69f, -0.22f));
			}
			else if (StudentID == 71)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.69f, 0.335f));
			}
		}
		if (StudentID == 1 && SenpaiGlobals.CustomSenpai)
		{
			if (SenpaiGlobals.SenpaiEyeWear > 0)
			{
				Eyewear[SenpaiGlobals.SenpaiEyeWear].SetActive(value: true);
			}
			FacialHairstyle = SenpaiGlobals.SenpaiFacialHair;
			HairColor = SenpaiGlobals.SenpaiHairColor;
			EyeColor = SenpaiGlobals.SenpaiEyeColor;
			Hairstyle = SenpaiGlobals.SenpaiHairStyle;
		}
		if (!Male)
		{
			if (!Teacher)
			{
				FemaleHair[Hairstyle].SetActive(value: true);
				HairRenderer = FemaleHairRenderers[Hairstyle];
				SetFemaleUniform();
			}
			else
			{
				TeacherHair[Hairstyle].SetActive(value: true);
				HairRenderer = TeacherHairRenderers[Hairstyle];
				if (Club == ClubType.Teacher)
				{
					MyRenderer.materials[1].mainTexture = TeacherBodyTexture;
					MyRenderer.materials[2].mainTexture = DefaultFaceTexture;
					MyRenderer.materials[0].mainTexture = TeacherBodyTexture;
				}
				else if (Club == ClubType.GymTeacher)
				{
					if (StudentGlobals.GetStudentReplaced(StudentID))
					{
						MyRenderer.materials[2].mainTexture = DefaultFaceTexture;
						MyRenderer.materials[0].mainTexture = CoachPaleBodyTexture;
						MyRenderer.materials[1].mainTexture = CoachPaleBodyTexture;
					}
					else
					{
						MyRenderer.materials[2].mainTexture = CoachFaceTexture;
						MyRenderer.materials[0].mainTexture = CoachBodyTexture;
						MyRenderer.materials[1].mainTexture = CoachBodyTexture;
					}
				}
				else if (Club == ClubType.Nurse)
				{
					MyRenderer.materials = NurseMaterials;
				}
			}
		}
		else
		{
			if (Hairstyle > 0)
			{
				MaleHair[Hairstyle].SetActive(value: true);
				HairRenderer = MaleHairRenderers[Hairstyle];
			}
			if (FacialHairstyle > 0)
			{
				FacialHair[FacialHairstyle].SetActive(value: true);
				FacialHairRenderer = FacialHairRenderers[FacialHairstyle];
			}
			if (EyewearID > 0)
			{
				Eyewear[EyewearID].SetActive(value: true);
			}
			SetMaleUniform();
		}
		if (!Male)
		{
			if (!Teacher)
			{
				if (FemaleAccessories[Accessory] != null)
				{
					FemaleAccessories[Accessory].SetActive(value: true);
				}
			}
			else if (TeacherAccessories[Accessory] != null)
			{
				TeacherAccessories[Accessory].SetActive(value: true);
			}
		}
		else if (MaleAccessories[Accessory] != null)
		{
			MaleAccessories[Accessory].SetActive(value: true);
		}
		if (StudentManager == null || (!Empty && !StudentManager.TutorialActive))
		{
			if (StudentManager == null || !Eighties)
			{
				if ((Club < ClubType.Gaming || Club == ClubType.Newspaper) && ClubAccessories[(int)Club] != null && !ClubGlobals.GetClubClosed(Club) && StudentID != 26)
				{
					ClubAccessories[(int)Club].SetActive(value: true);
				}
				if (!Eighties && StudentID == 36)
				{
					ClubAccessories[(int)Club].SetActive(value: true);
				}
				if (Club == ClubType.Cooking)
				{
					ClubAccessories[(int)Club].SetActive(value: false);
					ClubAccessories[(int)Club] = Kerchiefs[StudentID];
					if (!ClubGlobals.GetClubClosed(Club) && StudentID > 12)
					{
						ClubAccessories[(int)Club].SetActive(value: true);
					}
				}
				else if (Club == ClubType.Drama)
				{
					ClubAccessories[(int)Club].SetActive(value: false);
					ClubAccessories[(int)Club] = Roses[StudentID];
					if (!ClubGlobals.GetClubClosed(Club))
					{
						ClubAccessories[(int)Club].SetActive(value: true);
					}
				}
				else if (Club == ClubType.Art)
				{
					ClubAccessories[(int)Club].GetComponent<MeshFilter>().sharedMesh = Berets[StudentID];
					if (StudentID == 44)
					{
						ClubAccessories[(int)Club].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						ClubAccessories[(int)Club].transform.localScale = new Vector3(100f, 100f, 100f);
						ClubAccessories[(int)Club].transform.localPosition = new Vector3(0f, -1.445f, 0.02f);
					}
				}
				else if (Club == ClubType.Science)
				{
					ClubAccessories[(int)Club].SetActive(value: false);
					ClubAccessories[(int)Club] = Scanners[StudentID];
					if (!ClubGlobals.GetClubClosed(Club))
					{
						ClubAccessories[(int)Club].SetActive(value: true);
					}
				}
				else if (Club == ClubType.LightMusic)
				{
					ClubAccessories[(int)Club].SetActive(value: false);
					ClubAccessories[(int)Club] = MusicNotes[StudentID - 50];
					if (!ClubGlobals.GetClubClosed(Club))
					{
						ClubAccessories[(int)Club].SetActive(value: true);
					}
				}
				else if (Club == ClubType.Sports)
				{
					ClubAccessories[(int)Club].SetActive(value: false);
					ClubAccessories[(int)Club] = Goggles[StudentID];
					if (!ClubGlobals.GetClubClosed(Club))
					{
						ClubAccessories[(int)Club].SetActive(value: true);
					}
				}
				else if (Club == ClubType.Gardening)
				{
					ClubAccessories[(int)Club].SetActive(value: false);
					ClubAccessories[(int)Club] = Flowers[StudentID];
					if (!ClubGlobals.GetClubClosed(Club))
					{
						ClubAccessories[(int)Club].SetActive(value: true);
					}
				}
				else if (Club == ClubType.Gaming)
				{
					if (ClubAccessories[(int)Club] != null)
					{
						ClubAccessories[(int)Club].SetActive(value: false);
					}
					ClubAccessories[(int)Club] = RedCloth[StudentID];
					if (!ClubGlobals.GetClubClosed(Club) && ClubAccessories[(int)Club] != null)
					{
						ClubAccessories[(int)Club].SetActive(value: true);
					}
				}
			}
			if (!Eighties && StudentID == 36 && StudentManager != null && StudentManager.TaskManager != null && StudentManager.TaskManager.TaskStatus[36] == 3)
			{
				ClubAccessories[(int)Club].SetActive(value: false);
			}
		}
		if (StudentID == 11 && !TakingPortrait && !Cutscene && !Kidnapped && SceneManager.GetActiveScene().name == "SchoolScene")
		{
			CatGifts[1].SetActive(CollectibleGlobals.GetGiftGiven(1));
			CatGifts[2].SetActive(CollectibleGlobals.GetGiftGiven(2));
			CatGifts[3].SetActive(CollectibleGlobals.GetGiftGiven(3));
			CatGifts[4].SetActive(CollectibleGlobals.GetGiftGiven(4));
		}
		if (!Male)
		{
			StartCoroutine(PutOnStockings());
		}
		if (!Randomize)
		{
			if (EyeColor != string.Empty)
			{
				if (EyeColor == "White")
				{
					CorrectColor = new Color(1f, 1f, 1f);
				}
				else if (EyeColor == "Black")
				{
					CorrectColor = new Color(0.5f, 0.5f, 0.5f);
				}
				else if (EyeColor == "Red")
				{
					CorrectColor = new Color(1f, 0f, 0f);
				}
				else if (EyeColor == "Yellow")
				{
					CorrectColor = new Color(1f, 1f, 0f);
				}
				else if (EyeColor == "Green")
				{
					CorrectColor = new Color(0f, 1f, 0f);
				}
				else if (EyeColor == "Cyan")
				{
					CorrectColor = new Color(0f, 1f, 1f);
				}
				else if (EyeColor == "Blue")
				{
					CorrectColor = new Color(0f, 0f, 1f);
				}
				else if (EyeColor == "Purple")
				{
					CorrectColor = new Color(1f, 0f, 1f);
				}
				else if (EyeColor == "Orange")
				{
					CorrectColor = new Color(1f, 0.5f, 0f);
				}
				else if (EyeColor == "Brown")
				{
					CorrectColor = new Color(0.5f, 0.25f, 0f);
				}
				else
				{
					CorrectColor = new Color(0f, 0f, 0f);
				}
				if (StudentID > 90 && StudentID < 97)
				{
					CorrectColor.r *= 0.5f;
					CorrectColor.g *= 0.5f;
					CorrectColor.b *= 0.5f;
				}
				if (CorrectColor != new Color(0f, 0f, 0f))
				{
					RightEyeRenderer.material.color = CorrectColor;
					LeftEyeRenderer.material.color = CorrectColor;
				}
			}
		}
		else
		{
			float r = Random.Range(0f, 1f);
			float g = Random.Range(0f, 1f);
			float b = Random.Range(0f, 1f);
			RightEyeRenderer.material.color = new Color(r, g, b);
			LeftEyeRenderer.material.color = new Color(r, g, b);
		}
		if (!Randomize)
		{
			if (HairColor == "White")
			{
				ColorValue = new Color(1f, 1f, 1f);
			}
			else if (HairColor == "Black")
			{
				ColorValue = new Color(0.5f, 0.5f, 0.5f);
			}
			else if (HairColor == "SolidBlack")
			{
				ColorValue = new Color(0.0001f, 0.0001f, 0.0001f);
			}
			else if (HairColor == "Red")
			{
				ColorValue = new Color(1f, 0f, 0f);
			}
			else if (HairColor == "Yellow")
			{
				ColorValue = new Color(1f, 1f, 0f);
			}
			else if (HairColor == "Green")
			{
				ColorValue = new Color(0f, 1f, 0f);
			}
			else if (HairColor == "Cyan")
			{
				ColorValue = new Color(0f, 1f, 1f);
			}
			else if (HairColor == "Blue")
			{
				ColorValue = new Color(0f, 0f, 1f);
			}
			else if (HairColor == "Purple")
			{
				ColorValue = new Color(1f, 0f, 1f);
			}
			else if (HairColor == "Orange")
			{
				ColorValue = new Color(1f, 0.5f, 0f);
			}
			else if (HairColor == "Brown")
			{
				ColorValue = new Color(0.5f, 0.25f, 0f);
			}
			else
			{
				ColorValue = new Color(0f, 0f, 0f);
				RightIrisLight.SetActive(value: false);
				LeftIrisLight.SetActive(value: false);
			}
			if (StudentID > 90 && StudentID < 97)
			{
				ColorValue.r *= 0.5f;
				ColorValue.g *= 0.5f;
				ColorValue.b *= 0.5f;
			}
			if (ColorValue == new Color(0f, 0f, 0f))
			{
				RightEyeRenderer.material.mainTexture = HairRenderer.material.mainTexture;
				LeftEyeRenderer.material.mainTexture = HairRenderer.material.mainTexture;
				if (!DoNotChangeFace)
				{
					FaceTexture = HairRenderer.material.mainTexture;
				}
				if (Empty)
				{
					FaceTexture = GrayFace;
				}
				CustomHair = true;
			}
			if (!CustomHair)
			{
				if (Hairstyle > 0)
				{
					if (GameGlobals.LoveSick)
					{
						HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
						if (HairRenderer.materials.Length > 1)
						{
							HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
						}
					}
					else
					{
						HairRenderer.material.color = ColorValue;
					}
				}
			}
			else if (GameGlobals.LoveSick)
			{
				HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
				if (HairRenderer.materials.Length > 1)
				{
					HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
				}
			}
			if (!Male)
			{
				if (StudentID == 25)
				{
					FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(0f, 1f, 1f);
				}
				else if (StudentID == 30)
				{
					FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f);
				}
			}
		}
		else
		{
			HairRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		}
		if (!Teacher)
		{
			if (CustomHair)
			{
				if (!Male)
				{
					MyRenderer.materials[2].mainTexture = FaceTexture;
				}
				else if (Club == ClubType.Council)
				{
					MyRenderer.materials[0].mainTexture = FaceTexture;
				}
				else if (StudentGlobals.MaleUniform == 1)
				{
					MyRenderer.materials[2].mainTexture = FaceTexture;
				}
				else if (StudentGlobals.MaleUniform < 4)
				{
					MyRenderer.materials[1].mainTexture = FaceTexture;
				}
				else
				{
					MyRenderer.materials[0].mainTexture = FaceTexture;
				}
			}
		}
		else if (Teacher && StudentGlobals.GetStudentReplaced(StudentID))
		{
			Color studentColor = StudentGlobals.GetStudentColor(StudentID);
			Color studentEyeColor = StudentGlobals.GetStudentEyeColor(StudentID);
			HairRenderer.material.color = studentColor;
			RightEyeRenderer.material.color = studentEyeColor;
			LeftEyeRenderer.material.color = studentEyeColor;
		}
		if (Male)
		{
			if (Accessory == 2)
			{
				RightIrisLight.SetActive(value: false);
				LeftIrisLight.SetActive(value: false);
			}
			if (SceneManager.GetActiveScene().name == "PortraitScene")
			{
				Character.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
			}
			if (FacialHairRenderer != null)
			{
				FacialHairRenderer.material.color = ColorValue;
				if (FacialHairRenderer.materials.Length > 1)
				{
					FacialHairRenderer.materials[1].color = ColorValue;
				}
			}
		}
		if (!Eighties)
		{
			if (StudentID != 10)
			{
				if (StudentID == 25 || StudentID == 30)
				{
					FemaleAccessories[6].SetActive(value: true);
					if ((float)StudentGlobals.GetStudentReputation(StudentID) < -33.33333f)
					{
						FemaleAccessories[6].SetActive(value: false);
					}
				}
				else if (StudentID == 2)
				{
					if (GameGlobals.RingStolen)
					{
						FemaleAccessories[3].SetActive(value: false);
					}
				}
				else if (StudentID == 40)
				{
					if (base.transform.position != Vector3.zero)
					{
						RightEyeRenderer.material.mainTexture = WaifuEyeTexture;
						LeftEyeRenderer.material.mainTexture = WaifuEyeTexture;
						RightIrisLight.GetComponent<Renderer>().material.mainTexture = WaifuIrisTexture;
						LeftIrisLight.GetComponent<Renderer>().material.mainTexture = WaifuIrisTexture;
						RightIrisLight.SetActive(value: true);
						LeftIrisLight.SetActive(value: true);
						RightEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
						LeftEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
					}
				}
				else if (StudentID == 41)
				{
					CharacterAnimation["moodyEyes_00"].layer = 1;
					CharacterAnimation.Play("moodyEyes_00");
					CharacterAnimation["moodyEyes_00"].weight = 1f;
					CharacterAnimation.Play("moodyEyes_00");
				}
				else if (StudentID == 51)
				{
					if (!ClubGlobals.GetClubClosed(ClubType.LightMusic))
					{
						PunkAccessories[1].SetActive(value: true);
						PunkAccessories[2].SetActive(value: true);
						PunkAccessories[3].SetActive(value: true);
					}
				}
				else if (StudentID == 59)
				{
					ClubAccessories[7].transform.localPosition = new Vector3(0f, -1.04f, 0.5f);
					ClubAccessories[7].transform.localEulerAngles = new Vector3(-22.5f, 0f, 0f);
				}
				else if (StudentID == 60)
				{
					FemaleAccessories[13].SetActive(value: true);
				}
			}
		}
		else if (StudentID == 86)
		{
			CharacterAnimation["moodyEyes_00"].layer = 1;
			CharacterAnimation.Play("moodyEyes_00");
			CharacterAnimation["moodyEyes_00"].weight = 1f;
			CharacterAnimation.Play("moodyEyes_00");
		}
		if (Student != null && Student.AoT)
		{
			Student.AttackOnTitan();
		}
		if (HomeScene)
		{
			Student.CharacterAnimation["idle_00"].time = 9f;
			Student.CharacterAnimation["idle_00"].speed = 0f;
			Hairstyle = 65;
		}
		if (!Eighties)
		{
			TaskCheck();
		}
		TurnOnCheck();
		if (!Male)
		{
			EyeTypeCheck();
		}
		if (Kidnapped)
		{
			WearIndoorShoes();
		}
	}

	public void SetMaleUniform()
	{
		if (StudentID == 1)
		{
			SkinColor = SenpaiGlobals.SenpaiSkinColor;
			FaceTexture = FaceTextures[SkinColor];
		}
		else
		{
			FaceTexture = (CustomHair ? HairRenderer.material.mainTexture : FaceTextures[SkinColor]);
			bool flag = false;
			if (StudentManager != null && StudentID == StudentManager.SuitorID)
			{
				flag = true;
			}
			if (flag && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorTan)
			{
				SkinColor = 6;
				DoNotChangeFace = true;
				FaceTexture = FaceTextures[6];
			}
		}
		MyRenderer.sharedMesh = MaleUniforms[StudentGlobals.MaleUniform];
		SchoolUniform = MaleUniforms[StudentGlobals.MaleUniform];
		UniformTexture = MaleUniformTextures[StudentGlobals.MaleUniform];
		CasualTexture = MaleCasualTextures[StudentGlobals.MaleUniform];
		SocksTexture = MaleSocksTextures[StudentGlobals.MaleUniform];
		if (Club == ClubType.Council)
		{
			FaceID = 0;
			SkinID = 1;
			UniformID = 2;
		}
		else if (StudentGlobals.MaleUniform == 1)
		{
			SkinID = 0;
			UniformID = 1;
			FaceID = 2;
		}
		else if (StudentGlobals.MaleUniform == 2 || StudentGlobals.MaleUniform == 3)
		{
			UniformID = 0;
			FaceID = 1;
			SkinID = 2;
		}
		else if (StudentGlobals.MaleUniform == 4 || StudentGlobals.MaleUniform == 5 || StudentGlobals.MaleUniform == 6)
		{
			FaceID = 0;
			SkinID = 1;
			UniformID = 2;
		}
		if (Club == ClubType.Delinquent && StudentGlobals.MaleUniform < 2)
		{
			MyRenderer.sharedMesh = DelinquentMesh;
			if (!Eighties)
			{
				if (StudentID == 76)
				{
					UniformTexture = EyeTextures[0];
					CasualTexture = EyeTextures[1];
					SocksTexture = EyeTextures[2];
				}
				else if (StudentID == 77)
				{
					UniformTexture = CheekTextures[0];
					CasualTexture = CheekTextures[1];
					SocksTexture = CheekTextures[2];
				}
				else if (StudentID == 78)
				{
					UniformTexture = ForeheadTextures[0];
					CasualTexture = ForeheadTextures[1];
					SocksTexture = ForeheadTextures[2];
				}
				else if (StudentID == 79)
				{
					UniformTexture = MouthTextures[0];
					CasualTexture = MouthTextures[1];
					SocksTexture = MouthTextures[2];
				}
				else if (StudentID == 80)
				{
					UniformTexture = NoseTextures[0];
					CasualTexture = NoseTextures[1];
					SocksTexture = NoseTextures[2];
				}
			}
			else
			{
				UniformTexture = EightiesDelinquentUniformTexture;
				CasualTexture = EightiesDelinquentCasualTexture;
				SocksTexture = EightiesDelinquentSocksTexture;
			}
		}
		if (!Eighties && StudentID == 58)
		{
			SkinColor = 8;
			Student.TowelTexture = TanTowelTexture;
			Student.SwimsuitTexture = TanSwimsuitTexture;
		}
		if (Empty)
		{
			UniformTexture = MaleUniformTextures[7];
			CasualTexture = MaleCasualTextures[7];
			SocksTexture = MaleSocksTextures[7];
			FaceTexture = GrayFace;
			SkinColor = 7;
		}
		if (Club == ClubType.Council)
		{
			MyRenderer.sharedMesh = MaleUniforms[4];
			SchoolUniform = MaleUniforms[4];
			UniformTexture = MaleUniformTextures[8];
			CasualTexture = MaleCasualTextures[8];
			SocksTexture = MaleSocksTextures[8];
			if (StudentID == 87)
			{
				UniformTexture = TanCouncilUniform;
				CasualTexture = TanCouncilUniform;
				SocksTexture = TanCouncilUniform;
				SkinColor = 8;
			}
		}
		if (!Student.Indoors)
		{
			MyRenderer.materials[FaceID].mainTexture = FaceTexture;
			MyRenderer.materials[SkinID].mainTexture = SkinTextures[SkinColor];
			MyRenderer.materials[UniformID].mainTexture = CasualTexture;
		}
		else
		{
			MyRenderer.materials[FaceID].mainTexture = FaceTexture;
			MyRenderer.materials[SkinID].mainTexture = SkinTextures[SkinColor];
			MyRenderer.materials[UniformID].mainTexture = UniformTexture;
		}
	}

	public void SetFemaleUniform()
	{
		if (Club != ClubType.Council)
		{
			MyRenderer.sharedMesh = FemaleUniforms[StudentGlobals.FemaleUniform];
			SchoolUniform = FemaleUniforms[StudentGlobals.FemaleUniform];
			if (Club == ClubType.Delinquent)
			{
				MyRenderer.sharedMesh = SukebanMesh;
				Masks[StudentID].SetActive(value: true);
			}
			if (Club == ClubType.Bully)
			{
				UniformTexture = GanguroUniformTextures[StudentGlobals.FemaleUniform];
				CasualTexture = GanguroCasualTextures[StudentGlobals.FemaleUniform];
				SocksTexture = GanguroSocksTextures[StudentGlobals.FemaleUniform];
			}
			else if (StudentID == 10)
			{
				UniformTexture = ObstacleUniformTextures[StudentGlobals.FemaleUniform];
				CasualTexture = ObstacleCasualTextures[StudentGlobals.FemaleUniform];
				SocksTexture = ObstacleSocksTextures[StudentGlobals.FemaleUniform];
			}
			else
			{
				UniformTexture = FemaleUniformTextures[StudentGlobals.FemaleUniform];
				CasualTexture = FemaleCasualTextures[StudentGlobals.FemaleUniform];
				SocksTexture = FemaleSocksTextures[StudentGlobals.FemaleUniform];
			}
			if (!Eighties)
			{
				if (StudentID == 10)
				{
					Student.GymTexture = ObstacleGymTexture;
					Student.TowelTexture = ObstacleTowelTexture;
					Student.SwimsuitTexture = ObstacleSwimsuitTexture;
				}
				else if (StudentID == 11)
				{
					Student.SwimsuitTexture = OsanaSwimsuitTexture;
				}
			}
		}
		else
		{
			RightIrisLight.SetActive(value: false);
			LeftIrisLight.SetActive(value: false);
			MyRenderer.sharedMesh = FemaleUniforms[4];
			SchoolUniform = FemaleUniforms[4];
			UniformTexture = FemaleUniformTextures[7];
			CasualTexture = FemaleCasualTextures[7];
			SocksTexture = FemaleSocksTextures[7];
		}
		if (Empty)
		{
			UniformTexture = FemaleUniformTextures[8];
			CasualTexture = FemaleCasualTextures[8];
			SocksTexture = FemaleSocksTextures[8];
		}
		if (!Cutscene)
		{
			if (!Kidnapped)
			{
				if (!Student.Indoors)
				{
					MyRenderer.materials[0].mainTexture = CasualTexture;
					MyRenderer.materials[1].mainTexture = CasualTexture;
				}
				else
				{
					MyRenderer.materials[0].mainTexture = UniformTexture;
					MyRenderer.materials[1].mainTexture = UniformTexture;
				}
			}
			else
			{
				MyRenderer.materials[0].mainTexture = UniformTexture;
				MyRenderer.materials[1].mainTexture = UniformTexture;
			}
		}
		else
		{
			UniformTexture = FemaleUniformTextures[StudentGlobals.FemaleUniform];
			FaceTexture = DefaultFaceTexture;
			MyRenderer.materials[0].mainTexture = UniformTexture;
			MyRenderer.materials[1].mainTexture = UniformTexture;
		}
		_ = Club;
		_ = 13;
		if (MysteriousObstacle)
		{
			FaceTexture = BlackBody;
		}
		MyRenderer.materials[2].mainTexture = FaceTexture;
		if (!TakingPortrait && Student != null && Student.StudentManager != null && GameGlobals.CensorPanties)
		{
			CensorPanties();
		}
		if (MyStockings != null)
		{
			StartCoroutine(PutOnStockings());
		}
	}

	public void CensorPanties()
	{
		if (!Student.ClubAttire && Student.Schoolwear == 1)
		{
			MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
			MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
		}
		else
		{
			RemoveCensor();
		}
	}

	public void RemoveCensor()
	{
		MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
	}

	private void TaskCheck()
	{
		if (StudentID == 37)
		{
			if (TaskGlobals.GetTaskStatus(37) < 3)
			{
				if (!TakingPortrait)
				{
					MaleAccessories[1].SetActive(value: false);
				}
				else
				{
					MaleAccessories[1].SetActive(value: true);
				}
			}
		}
		else if (StudentID == 11 && PhoneCharms.Length != 0)
		{
			if (TaskGlobals.GetTaskStatus(11) < 3)
			{
				PhoneCharms[11].SetActive(value: false);
			}
			else
			{
				PhoneCharms[11].SetActive(value: true);
			}
		}
	}

	private void TurnOnCheck()
	{
		if (!TurnedOn && !TakingPortrait && Male)
		{
			if (Hairstyle == 46 || Hairstyle == 48 || Hairstyle == 49)
			{
				LoveManager.Targets[LoveManager.TotalTargets] = Student.Head;
				LoveManager.TotalTargets++;
			}
			else if ((Accessory > 1 && Accessory < 10) || Accessory == 13 || Accessory == 17)
			{
				LoveManager.Targets[LoveManager.TotalTargets] = Student.Head;
				LoveManager.TotalTargets++;
			}
			else if (Student.Persona == PersonaType.TeachersPet)
			{
				LoveManager.Targets[LoveManager.TotalTargets] = Student.Head;
				LoveManager.TotalTargets++;
			}
			else if (EyewearID > 0)
			{
				LoveManager.Targets[LoveManager.TotalTargets] = Student.Head;
				LoveManager.TotalTargets++;
			}
			else if (SkinColor == 8)
			{
				LoveManager.Targets[LoveManager.TotalTargets] = Student.Head;
				LoveManager.TotalTargets++;
			}
		}
		TurnedOn = true;
	}

	private void DestroyUnneccessaryObjects()
	{
		GameObject[] femaleAccessories = FemaleAccessories;
		foreach (GameObject gameObject in femaleAccessories)
		{
			if (gameObject != null && !gameObject.activeInHierarchy)
			{
				Object.Destroy(gameObject);
			}
		}
		femaleAccessories = MaleAccessories;
		foreach (GameObject gameObject2 in femaleAccessories)
		{
			if (gameObject2 != null && !gameObject2.activeInHierarchy)
			{
				Object.Destroy(gameObject2);
			}
		}
		femaleAccessories = ClubAccessories;
		foreach (GameObject gameObject3 in femaleAccessories)
		{
			if (gameObject3 != null && !gameObject3.activeInHierarchy)
			{
				Object.Destroy(gameObject3);
			}
		}
		femaleAccessories = TeacherAccessories;
		foreach (GameObject gameObject4 in femaleAccessories)
		{
			if (gameObject4 != null && !gameObject4.activeInHierarchy)
			{
				Object.Destroy(gameObject4);
			}
		}
		femaleAccessories = TeacherHair;
		foreach (GameObject gameObject5 in femaleAccessories)
		{
			if (gameObject5 != null && !gameObject5.activeInHierarchy)
			{
				Object.Destroy(gameObject5);
			}
		}
		femaleAccessories = FemaleHair;
		foreach (GameObject gameObject6 in femaleAccessories)
		{
			if (gameObject6 != null && !gameObject6.activeInHierarchy)
			{
				Object.Destroy(gameObject6);
			}
		}
		femaleAccessories = MaleHair;
		foreach (GameObject gameObject7 in femaleAccessories)
		{
			if (gameObject7 != null && !gameObject7.activeInHierarchy)
			{
				Object.Destroy(gameObject7);
			}
		}
		femaleAccessories = FacialHair;
		foreach (GameObject gameObject8 in femaleAccessories)
		{
			if (gameObject8 != null && !gameObject8.activeInHierarchy)
			{
				Object.Destroy(gameObject8);
			}
		}
		femaleAccessories = Eyewear;
		foreach (GameObject gameObject9 in femaleAccessories)
		{
			if (gameObject9 != null && !gameObject9.activeInHierarchy)
			{
				Object.Destroy(gameObject9);
			}
		}
		femaleAccessories = RightStockings;
		foreach (GameObject gameObject10 in femaleAccessories)
		{
			if (gameObject10 != null && !gameObject10.activeInHierarchy)
			{
				Object.Destroy(gameObject10);
			}
		}
		femaleAccessories = LeftStockings;
		foreach (GameObject gameObject11 in femaleAccessories)
		{
			if (gameObject11 != null && !gameObject11.activeInHierarchy)
			{
				Object.Destroy(gameObject11);
			}
		}
	}

	public IEnumerator PutOnStockings()
	{
		RightStockings[0].SetActive(value: false);
		LeftStockings[0].SetActive(value: false);
		if (StudentManager.TutorialActive)
		{
			Stockings = "";
		}
		if (Stockings == string.Empty)
		{
			MyStockings = null;
		}
		else if (Stockings == "Red")
		{
			MyStockings = RedStockings;
		}
		else if (Stockings == "Yellow")
		{
			MyStockings = YellowStockings;
		}
		else if (Stockings == "Green")
		{
			MyStockings = GreenStockings;
		}
		else if (Stockings == "Cyan")
		{
			MyStockings = CyanStockings;
		}
		else if (Stockings == "Blue")
		{
			MyStockings = BlueStockings;
		}
		else if (Stockings == "Purple")
		{
			MyStockings = PurpleStockings;
		}
		else if (Stockings == "ShortGreen")
		{
			MyStockings = GreenSocks;
		}
		else if (Stockings == "ShortRed")
		{
			MyStockings = RedSocks;
		}
		else if (Stockings == "ShortBlue")
		{
			MyStockings = BlueSocks;
		}
		else if (Stockings == "ShortYellow")
		{
			MyStockings = YellowSocks;
		}
		else if (Stockings == "ShortBlack")
		{
			MyStockings = BlackKneeSocks;
		}
		else if (Stockings == "Black")
		{
			MyStockings = BlackStockings;
		}
		else if (Stockings == "Osana")
		{
			MyStockings = OsanaStockings;
		}
		else if (Stockings == "Amai")
		{
			MyStockings = AmaiStockings;
		}
		else if (Stockings == "Kizana")
		{
			MyStockings = KizanaStockings;
		}
		else if (Stockings == "Council1")
		{
			MyStockings = TurtleStockings;
		}
		else if (Stockings == "Council2")
		{
			MyStockings = TigerStockings;
		}
		else if (Stockings == "Council3")
		{
			MyStockings = BirdStockings;
		}
		else if (Stockings == "Council4")
		{
			MyStockings = DragonStockings;
		}
		else if (Stockings == "Music1")
		{
			if (!ClubGlobals.GetClubClosed(ClubType.LightMusic))
			{
				MyStockings = MusicStockings[1];
			}
		}
		else if (Stockings == "Music2")
		{
			MyStockings = MusicStockings[2];
		}
		else if (Stockings == "Music3")
		{
			MyStockings = MusicStockings[3];
		}
		else if (Stockings == "Music4")
		{
			MyStockings = MusicStockings[4];
		}
		else if (Stockings == "Music5")
		{
			MyStockings = MusicStockings[5];
		}
		else if (Stockings == "Custom1")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings1.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				CustomStockings[1] = NewCustomStockings10.texture;
			}
			MyStockings = CustomStockings[1];
		}
		else if (Stockings == "Custom2")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings2.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				CustomStockings[2] = NewCustomStockings10.texture;
			}
			MyStockings = CustomStockings[2];
		}
		else if (Stockings == "Custom3")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings3.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				CustomStockings[3] = NewCustomStockings10.texture;
			}
			MyStockings = CustomStockings[3];
		}
		else if (Stockings == "Custom4")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings4.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				CustomStockings[4] = NewCustomStockings10.texture;
			}
			MyStockings = CustomStockings[4];
		}
		else if (Stockings == "Custom5")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings5.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				CustomStockings[5] = NewCustomStockings10.texture;
			}
			MyStockings = CustomStockings[5];
		}
		else if (Stockings == "Custom6")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings6.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				CustomStockings[6] = NewCustomStockings10.texture;
			}
			MyStockings = CustomStockings[6];
		}
		else if (Stockings == "Custom7")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings7.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				CustomStockings[7] = NewCustomStockings10.texture;
			}
			MyStockings = CustomStockings[7];
		}
		else if (Stockings == "Custom8")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings8.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				CustomStockings[8] = NewCustomStockings10.texture;
			}
			MyStockings = CustomStockings[8];
		}
		else if (Stockings == "Custom9")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings9.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				CustomStockings[9] = NewCustomStockings10.texture;
			}
			MyStockings = CustomStockings[9];
		}
		else if (Stockings == "Custom10")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings10.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				CustomStockings[10] = NewCustomStockings10.texture;
			}
			MyStockings = CustomStockings[10];
		}
		else if (Stockings == "Rival")
		{
			MyStockings = EightiesRivalStockings[StudentID];
		}
		else if (Stockings == "Loose" && !Kidnapped)
		{
			MyStockings = null;
			RightStockings[0].SetActive(value: true);
			LeftStockings[0].SetActive(value: true);
		}
		if (MyStockings != null)
		{
			MyRenderer.materials[0].SetTexture("_OverlayTex", MyStockings);
			MyRenderer.materials[1].SetTexture("_OverlayTex", MyStockings);
			MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
		}
		else
		{
			MyRenderer.materials[0].SetTexture("_OverlayTex", null);
			MyRenderer.materials[1].SetTexture("_OverlayTex", null);
			MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		}
	}

	public void WearIndoorShoes()
	{
		if (!Male)
		{
			MyRenderer.materials[0].mainTexture = CasualTexture;
			MyRenderer.materials[1].mainTexture = CasualTexture;
		}
		else
		{
			MyRenderer.materials[UniformID].mainTexture = CasualTexture;
		}
	}

	public void WearOutdoorShoes()
	{
		if (!Male)
		{
			MyRenderer.materials[0].mainTexture = UniformTexture;
			MyRenderer.materials[1].mainTexture = UniformTexture;
		}
		else
		{
			MyRenderer.materials[UniformID].mainTexture = UniformTexture;
		}
	}

	public void EyeTypeCheck()
	{
		int num = 0;
		if (EyeType == "Thin")
		{
			MyRenderer.SetBlendShapeWeight(8, 100f);
			MyRenderer.SetBlendShapeWeight(9, 100f);
			StudentManager.Thins++;
			num = StudentManager.Thins;
		}
		else if (EyeType == "Serious")
		{
			MyRenderer.SetBlendShapeWeight(5, 50f);
			MyRenderer.SetBlendShapeWeight(9, 100f);
			StudentManager.Seriouses++;
			num = StudentManager.Seriouses;
		}
		else if (EyeType == "Round")
		{
			MyRenderer.SetBlendShapeWeight(5, 15f);
			MyRenderer.SetBlendShapeWeight(9, 100f);
			StudentManager.Rounds++;
			num = StudentManager.Rounds;
		}
		else if (EyeType == "Sad")
		{
			MyRenderer.SetBlendShapeWeight(0, 50f);
			MyRenderer.SetBlendShapeWeight(5, 15f);
			MyRenderer.SetBlendShapeWeight(6, 50f);
			MyRenderer.SetBlendShapeWeight(8, 50f);
			MyRenderer.SetBlendShapeWeight(9, 100f);
			StudentManager.Sads++;
			num = StudentManager.Sads;
		}
		else if (EyeType == "Mean")
		{
			MyRenderer.SetBlendShapeWeight(10, 100f);
			StudentManager.Means++;
			num = StudentManager.Means;
		}
		else if (EyeType == "Smug")
		{
			MyRenderer.SetBlendShapeWeight(0, 50f);
			MyRenderer.SetBlendShapeWeight(5, 25f);
			StudentManager.Smugs++;
			num = StudentManager.Smugs;
		}
		else if (EyeType == "Gentle")
		{
			MyRenderer.SetBlendShapeWeight(9, 100f);
			MyRenderer.SetBlendShapeWeight(12, 100f);
			StudentManager.Gentles++;
			num = StudentManager.Gentles;
		}
		else if (EyeType == "MO")
		{
			MyRenderer.SetBlendShapeWeight(8, 50f);
			MyRenderer.SetBlendShapeWeight(9, 100f);
			MyRenderer.SetBlendShapeWeight(12, 100f);
			StudentManager.Gentles++;
			num = StudentManager.Gentles;
		}
		else if (EyeType == "Rival1")
		{
			MyRenderer.SetBlendShapeWeight(8, 5f);
			MyRenderer.SetBlendShapeWeight(9, 20f);
			MyRenderer.SetBlendShapeWeight(10, 50f);
			MyRenderer.SetBlendShapeWeight(11, 50f);
			MyRenderer.SetBlendShapeWeight(12, 10f);
			StudentManager.Rival1s++;
			num = StudentManager.Rival1s;
		}
		if (!Modified)
		{
			if ((EyeType == "Thin" && StudentManager.Thins > 1) || (EyeType == "Serious" && StudentManager.Seriouses > 1) || (EyeType == "Round" && StudentManager.Rounds > 1) || (EyeType == "Sad" && StudentManager.Sads > 1) || (EyeType == "Mean" && StudentManager.Means > 1) || (EyeType == "Smug" && StudentManager.Smugs > 1) || (EyeType == "Gentle" && StudentManager.Gentles > 1))
			{
				MyRenderer.SetBlendShapeWeight(8, MyRenderer.GetBlendShapeWeight(8) + (float)num);
				MyRenderer.SetBlendShapeWeight(9, MyRenderer.GetBlendShapeWeight(9) + (float)num);
				MyRenderer.SetBlendShapeWeight(10, MyRenderer.GetBlendShapeWeight(10) + (float)num);
				MyRenderer.SetBlendShapeWeight(12, MyRenderer.GetBlendShapeWeight(12) + (float)num);
			}
			Modified = true;
		}
	}

	public void DeactivateBullyAccessories()
	{
		if (StudentGlobals.FemaleUniform < 2 || StudentGlobals.FemaleUniform == 3)
		{
			RightWristband.SetActive(value: false);
			LeftWristband.SetActive(value: false);
		}
		Bookbag.SetActive(value: false);
		Hoodie.SetActive(value: false);
	}

	public void ActivateBullyAccessories()
	{
		if (StudentGlobals.FemaleUniform < 2 || StudentGlobals.FemaleUniform == 3)
		{
			RightWristband.SetActive(value: true);
			LeftWristband.SetActive(value: true);
		}
		Bookbag.SetActive(value: true);
		Hoodie.SetActive(value: true);
	}

	public void LoadCosmeticSheet(StudentCosmeticSheet mySheet)
	{
		if (Male != mySheet.Male)
		{
			return;
		}
		Accessory = mySheet.Accessory;
		Hairstyle = mySheet.Hairstyle;
		Stockings = mySheet.Stockings;
		BreastSize = mySheet.BreastSize;
		Start();
		ColorValue = mySheet.HairColor;
		HairRenderer.material.color = ColorValue;
		if (mySheet.CustomHair)
		{
			RightEyeRenderer.material.mainTexture = HairRenderer.material.mainTexture;
			LeftEyeRenderer.material.mainTexture = HairRenderer.material.mainTexture;
			FaceTexture = HairRenderer.material.mainTexture;
			LeftIrisLight.SetActive(value: false);
			RightIrisLight.SetActive(value: false);
			CustomHair = true;
		}
		CorrectColor = mySheet.EyeColor;
		RightEyeRenderer.material.color = CorrectColor;
		LeftEyeRenderer.material.color = CorrectColor;
		Student.Schoolwear = mySheet.Schoolwear;
		Student.ChangeSchoolwear();
		if (mySheet.Bloody)
		{
			Student.LiquidProjector.material.mainTexture = Student.BloodTexture;
			Student.LiquidProjector.enabled = true;
		}
		if (!Male)
		{
			Stockings = mySheet.Stockings;
			StartCoroutine(Student.Cosmetic.PutOnStockings());
			for (int i = 0; i < MyRenderer.sharedMesh.blendShapeCount; i++)
			{
				MyRenderer.SetBlendShapeWeight(i, mySheet.Blendshapes[i]);
			}
		}
	}

	public StudentCosmeticSheet CosmeticSheet()
	{
		StudentCosmeticSheet result = default(StudentCosmeticSheet);
		result.Blendshapes = new List<float>();
		result.Male = Male;
		result.CustomHair = CustomHair;
		result.Accessory = Accessory;
		result.Hairstyle = Hairstyle;
		result.Stockings = Stockings;
		result.BreastSize = BreastSize;
		result.CustomHair = CustomHair;
		result.Schoolwear = Student.Schoolwear;
		result.Bloody = Student.LiquidProjector.enabled && Student.LiquidProjector.material.mainTexture == Student.BloodTexture;
		result.HairColor = HairRenderer.material.color;
		result.EyeColor = RightEyeRenderer.material.color;
		if (!Male)
		{
			for (int i = 0; i < MyRenderer.sharedMesh.blendShapeCount; i++)
			{
				result.Blendshapes.Add(MyRenderer.GetBlendShapeWeight(i));
			}
		}
		return result;
	}
}
