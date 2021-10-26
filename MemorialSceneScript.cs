using UnityEngine;

public class MemorialSceneScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public GameObject[] Canvases;

	public UITexture[] Portraits;

	public GameObject CanvasGroup;

	public GameObject FlowerVase;

	public GameObject Headmaster;

	public GameObject Counselor;

	public int MemorialStudents;

	public float BloomIntensity = 1f;

	public float BloomRadius = 4f;

	public float Speed;

	public bool Eulogized;

	public bool FadeOut;

	public GameObject YoungHeadmaster;

	public Material Transparency;

	public GameObject[] HeadmasterMesh;

	public GameObject CounselorMother;

	public GameObject[] CounselorMesh;

	private void Start()
	{
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			int profile = GameGlobals.Profile;
			int @int = PlayerPrefs.GetInt("SaveSlot");
			StudentGlobals.MemorialStudents = PlayerPrefs.GetInt("Profile_" + profile + "_Slot_" + @int + "_MemorialStudents");
		}
		MemorialStudents = StudentGlobals.MemorialStudents;
		if (MemorialStudents % 2 == 0)
		{
			CanvasGroup.transform.localPosition = new Vector3(-0.5f, 0f, -2f);
		}
		int num = 0;
		int i;
		for (i = 1; i < 10; i++)
		{
			Canvases[i].SetActive(value: false);
		}
		string text = "";
		if (GameGlobals.Eighties)
		{
			text = "1989";
			TurnYoung();
		}
		i = 0;
		while (MemorialStudents > 0)
		{
			i++;
			Canvases[i].SetActive(value: true);
			if (MemorialStudents == 1)
			{
				num = StudentGlobals.MemorialStudent1;
			}
			else if (MemorialStudents == 2)
			{
				num = StudentGlobals.MemorialStudent2;
			}
			else if (MemorialStudents == 3)
			{
				num = StudentGlobals.MemorialStudent3;
			}
			else if (MemorialStudents == 4)
			{
				num = StudentGlobals.MemorialStudent4;
			}
			else if (MemorialStudents == 5)
			{
				num = StudentGlobals.MemorialStudent5;
			}
			else if (MemorialStudents == 6)
			{
				num = StudentGlobals.MemorialStudent6;
			}
			else if (MemorialStudents == 7)
			{
				num = StudentGlobals.MemorialStudent7;
			}
			else if (MemorialStudents == 8)
			{
				num = StudentGlobals.MemorialStudent8;
			}
			else if (MemorialStudents == 9)
			{
				num = StudentGlobals.MemorialStudent9;
			}
			WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + text + "/Student_" + num + ".png");
			Portraits[i].mainTexture = wWW.texture;
			GameObject gameObject = Object.Instantiate(FlowerVase, base.transform.position, Quaternion.identity);
			StudentJson studentJson = StudentManager.JSON.Students[num];
			Transform transform = StudentManager.Seats[studentJson.Class].List[studentJson.Seat];
			if (transform.position.x > 0f)
			{
				gameObject.transform.position = transform.position + new Vector3(0.33333f, 0.7711f, 0f);
			}
			else
			{
				gameObject.transform.position = transform.position + new Vector3(-0.33333f, 0.7711f, 0f);
				gameObject.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			}
			MemorialStudents--;
		}
	}

	private void Update()
	{
		Speed += Time.deltaTime;
		if (Speed > 1f)
		{
			if (!Eulogized)
			{
				StudentManager.Yandere.Subtitle.UpdateLabel(SubtitleType.Eulogy, 0, 8f);
				StudentManager.Yandere.PromptBar.Label[0].text = "Continue";
				StudentManager.Yandere.PromptBar.UpdateButtons();
				StudentManager.Yandere.PromptBar.Show = true;
				Eulogized = true;
			}
			StudentManager.MainCamera.position = Vector3.Lerp(StudentManager.MainCamera.position, new Vector3(38f, 4.125f, 68.825f), (Speed - 1f) * Time.deltaTime * 0.15f);
			if (Input.GetButtonDown("A"))
			{
				StudentManager.Yandere.PromptBar.Show = false;
				FadeOut = true;
			}
		}
		if (FadeOut)
		{
			BloomIntensity = Mathf.MoveTowards(BloomIntensity, 500f, Time.deltaTime * 500f);
			BloomRadius = Mathf.MoveTowards(BloomRadius, 7f, Time.deltaTime * 7f);
			CameraEffects.UpdateBloom(BloomIntensity);
			CameraEffects.UpdateBloomRadius(BloomRadius);
			if (BloomIntensity == 500f)
			{
				StudentManager.Yandere.Casual = !StudentManager.Yandere.Casual;
				StudentManager.Yandere.ChangeSchoolwear();
				StudentManager.Yandere.transform.position = new Vector3(12f, 0f, 72f);
				StudentManager.Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
				StudentManager.Yandere.HeartCamera.enabled = true;
				StudentManager.Yandere.RPGCamera.enabled = true;
				StudentManager.Yandere.CanMove = true;
				StudentManager.Yandere.HUD.alpha = 1f;
				StudentManager.Clock.BloomIntensity = BloomIntensity;
				StudentManager.Clock.BloomRadius = BloomRadius;
				StudentManager.Clock.UpdateBloom = true;
				StudentManager.Clock.ReduceKnee = false;
				StudentManager.Clock.Lerp = true;
				StudentManager.Clock.StopTime = false;
				StudentManager.Clock.PresentTime = 450f;
				StudentManager.Clock.HourTime = 7.5f;
				StudentManager.Unstop();
				StudentManager.SkipTo8();
				Headmaster.SetActive(value: false);
				Counselor.SetActive(value: false);
				base.enabled = false;
			}
		}
	}

	private void TurnYoung()
	{
		YoungHeadmaster.SetActive(value: true);
		HeadmasterMesh[1].SetActive(value: false);
		HeadmasterMesh[2].SetActive(value: false);
		HeadmasterMesh[3].SetActive(value: false);
		HeadmasterMesh[4].SetActive(value: false);
		HeadmasterMesh[5].SetActive(value: false);
		CounselorMother.SetActive(value: true);
		CounselorMesh[1].SetActive(value: false);
		CounselorMesh[2].SetActive(value: false);
		CounselorMesh[3].SetActive(value: false);
		CounselorMesh[4].SetActive(value: false);
		CounselorMesh[5].SetActive(value: false);
		CounselorMesh[6].SetActive(value: false);
		CounselorMesh[7].SetActive(value: true);
	}
}
