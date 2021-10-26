using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InventoryScript Inventory;

	public ClassScript Class;

	public GameObject BodyHidingLockers;

	public GameObject AlphabetTools;

	public GameObject Jukebox;

	public GameObject AmnesiaBomb;

	public GameObject SmokeBomb;

	public GameObject StinkBomb;

	public UILabel ChallengeFailed;

	public UILabel TargetLabel;

	public UILabel BombLabel;

	public UITexture BombTexture;

	public Transform LocalArrow;

	public Renderer MyRenderer;

	public Transform Yandere;

	public int RemainingBombs;

	public int CurrentTarget;

	public bool AlternateMusic;

	public bool StopMusic;

	public bool Began;

	public float LastTime;

	public float Timer;

	public int[] IDs;

	public int CurrentTrack;

	public AudioClip[] MusicTracks;

	public AudioSource MusicPlayer;

	private void Start()
	{
		if (GameGlobals.AlphabetMode)
		{
			TargetLabel.transform.parent.gameObject.SetActive(value: true);
			StudentManager.Yandere.NoDebug = true;
			BodyHidingLockers.SetActive(value: true);
			AlphabetTools.SetActive(value: true);
			Jukebox.SetActive(value: false);
			MyRenderer.enabled = true;
			Class.PhysicalGrade = 5;
			CurrentTrack = 1;
			UpdateText();
		}
		else
		{
			TargetLabel.transform.parent.gameObject.SetActive(value: false);
			BombLabel.transform.parent.gameObject.SetActive(value: false);
			AlphabetTools.SetActive(value: false);
			base.gameObject.SetActive(value: false);
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!Began && StudentManager.Yandere.CanMove)
		{
			MusicPlayer.Play();
			Began = true;
		}
		if (CurrentTarget >= IDs.Length)
		{
			return;
		}
		if (Input.GetKeyDown("m"))
		{
			if (MusicPlayer.isPlaying)
			{
				MusicPlayer.Stop();
				StopMusic = true;
				MusicPlayer.time = 0f;
				LastTime = 0f;
			}
			else
			{
				CurrentTrack++;
				if (CurrentTrack > 3)
				{
					CurrentTrack = 1;
				}
				MusicPlayer.clip = MusicTracks[CurrentTrack];
				MusicPlayer.Play();
				StopMusic = false;
			}
		}
		if (MusicPlayer.time < 600f && MusicPlayer.time > LastTime)
		{
			LastTime = MusicPlayer.time;
		}
		if (Began && !MusicPlayer.isPlaying && !StopMusic)
		{
			MusicPlayer.Play();
			MusicPlayer.time = LastTime;
		}
		if (StudentManager.Yandere.CanMove && (Input.GetButtonDown("LS") || Input.GetKeyDown(KeyCode.T)))
		{
			if (StudentManager.Yandere.Inventory.SmokeBomb)
			{
				Object.Instantiate(SmokeBomb, Yandere.position, Quaternion.identity);
				RemainingBombs--;
				BombLabel.text = string.Concat(RemainingBombs);
				if (RemainingBombs == 0)
				{
					StudentManager.Yandere.Inventory.SmokeBomb = false;
				}
			}
			else if (StudentManager.Yandere.Inventory.StinkBomb)
			{
				Object.Instantiate(StinkBomb, Yandere.position, Quaternion.identity);
				RemainingBombs--;
				BombLabel.text = string.Concat(RemainingBombs);
				if (RemainingBombs == 0)
				{
					StudentManager.Yandere.Inventory.StinkBomb = false;
				}
			}
			else if (StudentManager.Yandere.Inventory.AmnesiaBomb)
			{
				Object.Instantiate(AmnesiaBomb, Yandere.position, Quaternion.identity);
				RemainingBombs--;
				BombLabel.text = string.Concat(RemainingBombs);
				if (RemainingBombs == 0)
				{
					StudentManager.Yandere.Inventory.AmnesiaBomb = false;
				}
			}
		}
		LocalArrow.LookAt(StudentManager.Students[IDs[CurrentTarget]].transform.position);
		base.transform.eulerAngles = LocalArrow.eulerAngles - new Vector3(0f, StudentManager.MainCamera.transform.eulerAngles.y, 0f);
		if ((StudentManager.Yandere.Attacking && StudentManager.Yandere.TargetStudent.StudentID != IDs[CurrentTarget]) || (StudentManager.Yandere.Struggling && StudentManager.Yandere.TargetStudent.StudentID != IDs[CurrentTarget]) || StudentManager.Police.Show || StudentManager.Yandere.Noticed)
		{
			ChallengeFailed.enabled = true;
		}
		for (int i = CurrentTarget + 1; i < IDs.Length; i++)
		{
			if (!StudentManager.Students[IDs[i]].gameObject.activeInHierarchy)
			{
				ChallengeFailed.enabled = true;
			}
		}
		if (!StudentManager.Students[IDs[CurrentTarget]].Alive)
		{
			CurrentTarget++;
			if (CurrentTarget > 79)
			{
				TargetLabel.text = "Challenge Complete!";
				SceneManager.LoadScene("OsanaJokeScene");
			}
			else
			{
				UpdateText();
			}
		}
		if (ChallengeFailed.enabled)
		{
			Timer += Time.deltaTime;
			if (Timer > 3f)
			{
				SceneManager.LoadScene("LoadingScene");
			}
		}
	}

	public void UpdateText()
	{
		TargetLabel.text = "(" + CurrentTarget + "/79) Current Target: " + StudentManager.JSON.Students[IDs[CurrentTarget]].Name;
		if (RemainingBombs <= 0)
		{
			return;
		}
		BombLabel.transform.parent.gameObject.SetActive(value: true);
		if (BombTexture.color.a < 1f)
		{
			if (Inventory.StinkBomb)
			{
				BombTexture.color = new Color(0f, 0.5f, 0f, 1f);
			}
			else if (Inventory.AmnesiaBomb)
			{
				BombTexture.color = new Color(1f, 0.5f, 1f, 1f);
			}
			else
			{
				BombTexture.color = new Color(0.5f, 0.5f, 0.5f, 1f);
			}
		}
	}
}
