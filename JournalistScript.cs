using Pathfinding;
using UnityEngine;

public class JournalistScript : MonoBehaviour
{
	public ParticleSystem PepperSprayEffect;

	public float DistanceToDestination;

	public float DistanceToPlayer;

	public float SpeechTimer;

	public float ThreatTimer;

	public float ChaseTimer;

	public float Timer;

	public Quaternion targetRotation;

	public AudioClip PepperSpraySFX;

	public AudioClip ChaseVoice;

	public Transform[] Destinations;

	public AudioClip[] SpeechClips;

	public AudioClip[] ThreatClips;

	public string[] SpeechLines;

	public string[] ThreatLines;

	public SubtitleScript Subtitle;

	public YandereScript Yandere;

	public GameObject PepperSpray;

	public Animation MyAnimation;

	public Transform LookTarget;

	public AIPath Pathfinding;

	public bool Chasing;

	public int SpeechID;

	public int ThreatID;

	public Transform Head;

	public LayerMask Mask;

	private void Start()
	{
		if (!GameGlobals.Eighties || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			Pathfinding.target = Destinations[0];
		}
		PepperSpray.SetActive(value: false);
	}

	private void Update()
	{
		if (!(base.transform.position.z > -95f))
		{
			return;
		}
		DistanceToDestination = Vector3.Distance(base.transform.position, Pathfinding.target.position);
		DistanceToPlayer = Vector3.Distance(base.transform.position, Yandere.transform.position);
		if (!Chasing)
		{
			if (DistanceToPlayer < 5f && CanSeeYandere())
			{
				MyAnimation.CrossFade("idleTough_00");
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				if (DistanceToPlayer > 1f)
				{
					SpeechTimer -= Time.deltaTime;
					if (SpeechTimer <= 0f && SpeechID < SpeechLines.Length)
					{
						AudioSource.PlayClipAtPoint(SpeechClips[SpeechID], base.transform.position);
						if (Subtitle.EventSubtitle.text == "" || Subtitle.EventSubtitle.transform.localScale.x < 1f)
						{
							Subtitle.CustomText = SpeechLines[SpeechID];
							Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
						}
						SpeechTimer = 5f;
						SpeechID++;
					}
				}
				else
				{
					ThreatTimer -= Time.deltaTime;
					if (ThreatTimer <= 0f && ThreatID < ThreatLines.Length)
					{
						AudioSource.PlayClipAtPoint(ThreatClips[ThreatID], base.transform.position);
						if (Subtitle.EventSubtitle.text == "" || Subtitle.EventSubtitle.transform.localScale.x < 1f)
						{
							Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
							Subtitle.CustomText = ThreatLines[ThreatID];
							Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
						}
						ThreatTimer = 5f;
						ThreatID++;
					}
					if (Yandere.Armed)
					{
						Chase();
					}
				}
			}
			else if (DistanceToDestination < 1f)
			{
				MyAnimation.CrossFade("leaning_00");
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				targetRotation = Quaternion.LookRotation(LookTarget.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				Timer += Time.deltaTime;
				if (Timer > 5f)
				{
					if (Pathfinding.target != Destinations[1])
					{
						Pathfinding.target = Destinations[1];
					}
					else
					{
						Pathfinding.target = Destinations[2];
					}
					Timer = 0f;
				}
			}
			else
			{
				MyAnimation.CrossFade("walkTough_00");
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
			}
			if (DistanceToPlayer < 15f && CanSeeYandere())
			{
				CheckBehavior();
			}
			return;
		}
		targetRotation = Quaternion.LookRotation(base.transform.position - Yandere.transform.position);
		Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, targetRotation, 10f * Time.deltaTime);
		ChaseTimer += Time.deltaTime;
		if (ChaseTimer > 1f)
		{
			if (DistanceToPlayer > 1f)
			{
				MyAnimation.CrossFade("sprint_00");
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
				Pathfinding.speed = 5f;
				return;
			}
			if (!Yandere.Sprayed)
			{
				AudioSource.PlayClipAtPoint(PepperSpraySFX, base.transform.position);
			}
			targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
			Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
			Yandere.SprayedByJournalist = true;
			Yandere.YandereVision = false;
			Yandere.NearSenpai = false;
			Yandere.Attacking = false;
			Yandere.FollowHips = true;
			Yandere.Punching = false;
			Yandere.CanMove = false;
			Yandere.Sprayed = true;
			Yandere.StudentManager.YandereDying = true;
			Yandere.StudentManager.StopMoving();
			Yandere.Jukebox.Volume = 0f;
			Yandere.Blur.Size = 1f;
			if (Yandere.DelinquentFighting)
			{
				Yandere.StudentManager.CombatMinigame.Stop();
			}
			MyAnimation.CrossFade("f02_sprayCouncilEdgy_00");
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
			Pathfinding.speed = 0f;
			PepperSpray.SetActive(value: true);
			if ((double)MyAnimation["f02_sprayCouncilEdgy_00"].time > 0.66666)
			{
				PepperSprayEffect.Play();
				if (Yandere.Armed)
				{
					Yandere.EquippedWeapon.Drop();
				}
				Yandere.EmptyHands();
				base.enabled = false;
			}
		}
		else
		{
			targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
		}
	}

	private void CheckBehavior()
	{
		if (Yandere.CanMove && !Yandere.Egg && ((Yandere.Armed && Yandere.EquippedWeapon.Bloody) || Yandere.Bloodiness > 0f || Yandere.Carrying || Yandere.Chased || Yandere.Chasers > 0 || Yandere.Dragging || (Yandere.PickUp != null && (bool)Yandere.PickUp.BodyPart)))
		{
			Chase();
		}
	}

	public bool CanSeeYandere()
	{
		Vector3 position = Head.position;
		Vector3 end = new Vector3(Yandere.transform.position.x, Yandere.Head.position.y, Yandere.transform.position.z);
		if (Physics.Linecast(position, end, out var hitInfo, Mask) && hitInfo.collider.gameObject == Yandere.gameObject)
		{
			return true;
		}
		return false;
	}

	private void Chase()
	{
		Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
		AudioSource.PlayClipAtPoint(ChaseVoice, Yandere.MainCamera.transform.position);
		Subtitle.CustomText = "I knew it was you!";
		Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
		MyAnimation.CrossFade("readyToFight_00");
		Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
		Yandere.CanMove = false;
		Pathfinding.target = Yandere.transform;
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		if (Yandere.Carrying)
		{
			Yandere.EmptyHands();
		}
		Chasing = true;
	}
}
