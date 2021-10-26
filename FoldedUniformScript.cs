using UnityEngine;

public class FoldedUniformScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject SteamCloud;

	public bool InPosition = true;

	public bool Clean;

	public bool Spare;

	public float Timer;

	public int Type;

	public GameObject[] Uniforms;

	private void Start()
	{
		for (int i = 1; i < Uniforms.Length; i++)
		{
			Uniforms[i].SetActive(value: false);
		}
		if (Uniforms.Length != 0)
		{
			Uniforms[StudentGlobals.FemaleUniform].SetActive(value: true);
		}
		if (Prompt != null && Prompt.Yandere != null)
		{
			Yandere = Prompt.Yandere;
		}
		else
		{
			GameObject gameObject = GameObject.Find("YandereChan");
			if (gameObject != null)
			{
				Yandere = gameObject.GetComponent<YandereScript>();
			}
		}
		bool flag = false;
		if (Spare && !GameGlobals.SpareUniform)
		{
			Object.Destroy(base.gameObject);
			flag = true;
		}
		if (!flag && Clean && Prompt.Button[0] != null)
		{
			Prompt.HideButton[0] = true;
			Yandere.StudentManager.NewUniforms++;
			Yandere.StudentManager.UpdateStudents();
			Yandere.StudentManager.Uniforms[Yandere.StudentManager.NewUniforms] = base.transform;
			Debug.Log("A new uniform has appeared. There are now " + Yandere.StudentManager.NewUniforms + " new uniforms at school.");
		}
		base.gameObject.name = "School Uniform";
	}

	private void Update()
	{
		if (!Clean)
		{
			return;
		}
		InPosition = Yandere.StudentManager.LockerRoomArea.bounds.Contains(base.transform.position);
		if (Yandere.MyRenderer.sharedMesh != Yandere.Towel || Yandere.Bloodiness != 0f || !InPosition)
		{
			Prompt.HideButton[0] = true;
		}
		else
		{
			Prompt.HideButton[0] = false;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Object.Instantiate(SteamCloud, Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			Yandere.Character.GetComponent<Animation>().CrossFade("f02_stripping_00");
			Yandere.CurrentUniformOrigin = 2;
			Yandere.Stripping = true;
			Yandere.CanMove = false;
			Timer += Time.deltaTime;
		}
		if (Timer > 0f)
		{
			Timer += Time.deltaTime;
			if (Timer > 1.5f)
			{
				Yandere.Schoolwear = 1;
				Yandere.ChangeSchoolwear();
				Object.Destroy(base.gameObject);
			}
		}
	}
}
