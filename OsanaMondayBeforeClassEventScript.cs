using System;
using UnityEngine;

public class OsanaMondayBeforeClassEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public EventManagerScript NextEvent;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript Rival;

	public Transform Destination;

	public AudioClip SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public GameObject[] Bentos;

	public bool EventActive;

	public bool HintGiven;

	public float Distance;

	public float Scale;

	public float Timer;

	public int SpeechPhase = 1;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		Bentos[1].SetActive(value: false);
		Bentos[2].SetActive(value: false);
		if (DateGlobals.Weekday != DayOfWeek.Monday || StudentGlobals.StudentSlave == RivalID || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || DateGlobals.Week > 1 || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Phase == 0)
		{
			if (Frame > 0)
			{
				if (Clock.Period == 1)
				{
					if (StudentManager.Students[RivalID] != null)
					{
						if (Rival == null)
						{
							Rival = StudentManager.Students[RivalID];
						}
						else if (Rival.enabled && Rival.Indoors && !Rival.Alarmed && !Rival.WitnessedCorpse && !Rival.WitnessedMurder)
						{
							Debug.Log("Osana's before class event has begun. Putting two bento boxes on her desk.");
							Rival.CharacterAnimation["f02_pondering_00"].speed = 0.65f;
							Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
							Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
							Rival.Pathfinding.target = Destination;
							Rival.CurrentDestination = Destination;
							Rival.Pathfinding.canSearch = true;
							Rival.Pathfinding.canMove = true;
							Rival.Routine = false;
							Rival.InEvent = true;
							if (Rival.Follower != null)
							{
								Rival.Follower.TargetDistance = 1.5f;
								Rival.Follower.InEvent = true;
								Rival.FollowTargetDestination.localPosition = new Vector3(1f, 0f, 1f);
								Rival.Follower.CurrentDestination = Rival.FollowTargetDestination;
								Rival.Follower.Pathfinding.target = Rival.FollowTargetDestination;
							}
							if (!HintGiven)
							{
								Yandere.PauseScreen.Hint.Show = true;
								Yandere.PauseScreen.Hint.QuickID = 13;
								HintGiven = true;
							}
							Phase++;
						}
					}
					else
					{
						base.enabled = false;
					}
				}
				else
				{
					base.enabled = false;
				}
			}
			Frame++;
		}
		else if (Phase == 1)
		{
			if (Rival.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(SpeechClip, Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				if (Rival.Follower != null)
				{
					Rival.Follower.CurrentDestination = Rival.transform;
					Rival.Follower.Pathfinding.target = Rival.transform;
				}
				Rival.CharacterAnimation.CrossFade("f02_pondering_00");
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Bentos[1].SetActive(value: true);
				Bentos[2].SetActive(value: true);
				Phase++;
			}
			if (Rival.Follower != null)
			{
				if (Rival.Follower.DistanceToDestination >= Rival.Follower.TargetDistance + 0.1f)
				{
					Rival.Follower.CharacterAnimation.CrossFade(Rival.Follower.WalkAnim);
				}
				else
				{
					Rival.Follower.CharacterAnimation.CrossFade(Rival.Follower.IdleAnim);
				}
			}
		}
		else
		{
			Rival.MoveTowardsTarget(Rival.CurrentDestination.position);
			Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
			if (Rival.Follower != null)
			{
				if (Rival.Follower.DistanceToDestination >= Rival.Follower.TargetDistance + 0.1f)
				{
					Rival.Follower.CharacterAnimation.CrossFade(Rival.Follower.WalkAnim);
				}
				else
				{
					Rival.Follower.CharacterAnimation.CrossFade(Rival.Follower.IdleAnim);
				}
			}
			Timer += Time.deltaTime;
			if (VoiceClip != null)
			{
				VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
			}
			if (SpeechPhase < SpeechTime.Length)
			{
				if (Timer > SpeechTime[SpeechPhase])
				{
					if (Rival.Follower == null)
					{
						EndEvent();
					}
					else
					{
						EventSubtitle.text = SpeechText[SpeechPhase];
						SpeechPhase++;
					}
				}
			}
			else if (Rival.CharacterAnimation["f02_pondering_00"].time > Rival.CharacterAnimation["f02_pondering_00"].length)
			{
				EndEvent();
			}
			if (Rival.Alarmed || Rival.Splashed || (Rival.Follower != null && Rival.Follower.DramaticReaction))
			{
				UnityEngine.Object.Instantiate(AlarmDisc, Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
				EndEvent();
			}
			else if (Rival.Dying)
			{
				EndEvent();
			}
			Distance = Vector3.Distance(Yandere.transform.position, Rival.transform.position);
			if (base.enabled)
			{
				if (Distance - 4f < 15f)
				{
					Scale = Mathf.Abs(1f - (Distance - 4f) / 15f);
					if (Scale < 0f)
					{
						Scale = 0f;
					}
					if (Scale > 1f)
					{
						Scale = 1f;
					}
					Jukebox.Dip = 1f - 0.5f * Scale;
					EventSubtitle.transform.localScale = new Vector3(Scale, Scale, Scale);
					if (VoiceClip != null)
					{
						VoiceClip.GetComponent<AudioSource>().volume = Scale;
					}
				}
				else
				{
					EventSubtitle.transform.localScale = Vector3.zero;
					if (VoiceClip != null)
					{
						VoiceClip.GetComponent<AudioSource>().volume = 0f;
					}
				}
			}
		}
		if (Phase > 0)
		{
			if (Clock.Period > 1 || Rival.Splashed)
			{
				EndEvent();
			}
			if (!Yandere.NoDebug && Input.GetKeyDown(KeyCode.LeftControl))
			{
				Bentos[1].SetActive(value: true);
				Bentos[2].SetActive(value: true);
				EndEvent();
			}
		}
	}

	public void EndEvent()
	{
		Debug.Log("Osana's before class event ended.");
		Bentos[1].GetComponent<BentoScript>().enabled = true;
		Bentos[2].GetComponent<BentoScript>().enabled = true;
		Bentos[1].GetComponent<PromptScript>().enabled = true;
		Bentos[2].GetComponent<PromptScript>().enabled = true;
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (!Rival.Alarmed)
		{
			Rival.CurrentDestination = Rival.Destinations[Rival.Phase];
			Rival.Pathfinding.target = Rival.Destinations[Rival.Phase];
			Rival.Pathfinding.canSearch = true;
			Rival.Pathfinding.canMove = true;
			Rival.Routine = true;
		}
		else
		{
			Debug.Log("The event ended specifically because Osana was alarmed.");
			Rival.Pathfinding.canSearch = false;
			Rival.Pathfinding.canMove = false;
		}
		Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		Rival.DistanceToDestination = 999f;
		Rival.Prompt.enabled = true;
		Rival.InEvent = false;
		Rival.Private = false;
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		Rival.CharacterAnimation["f02_pondering_00"].speed = 1f;
		Jukebox.Dip = 1f;
		if (Rival.Follower != null)
		{
			Rival.Follower.TargetDistance = 1f;
			Rival.Follower.InEvent = false;
			Rival.Follower.CurrentDestination = Rival.FollowTargetDestination;
			Rival.Follower.Pathfinding.target = Rival.FollowTargetDestination;
		}
		EventSubtitle.text = string.Empty;
		NextEvent.enabled = true;
		base.enabled = false;
	}
}
