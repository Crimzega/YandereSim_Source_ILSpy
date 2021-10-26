using UnityEngine;

public class AlarmDiscScript : MonoBehaviour
{
	public AudioClip[] LongFemaleScreams;

	public AudioClip[] LongMaleScreams;

	public AudioClip[] FemaleScreams;

	public AudioClip[] MaleScreams;

	public AudioClip[] DelinquentScreams;

	public StudentScript Originator;

	public RadioScript SourceRadio;

	public StudentScript Student;

	public bool FocusOnYandere;

	public bool StudentIsBusy;

	public bool Delinquent;

	public bool NoScream;

	public bool Shocking;

	public bool Radio;

	public bool Male;

	public bool Long;

	public float Hesitation = 1f;

	public int Frame;

	private void Start()
	{
		Vector3 localScale = base.transform.localScale;
		localScale.x *= 2f - SchoolGlobals.SchoolAtmosphere;
		localScale.z = localScale.x;
		base.transform.localScale = localScale;
	}

	private void Update()
	{
		if (Frame > 0)
		{
			Object.Destroy(base.gameObject);
		}
		else if (!NoScream)
		{
			if (!Long)
			{
				if (Originator != null)
				{
					Male = Originator.Male;
				}
				if (!Male)
				{
					PlayClip(FemaleScreams[Random.Range(0, FemaleScreams.Length)], base.transform.position);
				}
				else if (Delinquent)
				{
					PlayClip(DelinquentScreams[Random.Range(0, DelinquentScreams.Length)], base.transform.position);
				}
				else
				{
					PlayClip(MaleScreams[Random.Range(0, MaleScreams.Length)], base.transform.position);
				}
			}
			else if (!Male)
			{
				PlayClip(LongFemaleScreams[Random.Range(0, LongFemaleScreams.Length)], base.transform.position);
			}
			else
			{
				PlayClip(LongMaleScreams[Random.Range(0, LongMaleScreams.Length)], base.transform.position);
			}
		}
		Frame++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			Student = other.gameObject.GetComponent<StudentScript>();
			if (Student != null)
			{
				Debug.Log("Student's ''Hurry'' is: " + Student.Hurry);
				if (Student.enabled && Student.DistractionSpot != new Vector3(base.transform.position.x, Student.transform.position.y, base.transform.position.z))
				{
					Object.Destroy(Student.Giggle);
					Student.InvestigationTimer = 0f;
					Student.InvestigationPhase = 0;
					Student.Investigating = false;
					Student.DiscCheck = false;
					Student.VisionDistance += 1f;
					Student.ChalkDust.Stop();
					Student.CleanTimer = 0f;
					if (!Radio)
					{
						if (Student != Originator)
						{
							if (Student.Clock.Period == 3 && Student.BusyAtLunch)
							{
								StudentIsBusy = true;
							}
							if ((Student.StudentID == 47 || Student.StudentID == 49) && Student.StudentManager.ConvoManager.Confirmed)
							{
								StudentIsBusy = true;
							}
							if (Student.StudentID == 7 && Student.Hurry)
							{
								Student.Distracted = false;
							}
							if (Student.StudentID == Student.StudentManager.RivalID || Student.StudentID == 1)
							{
								_ = Student.CurrentAction;
								_ = 10;
							}
							Debug.Log("An alarm disc has come into contact with: " + Student.Name);
							Debug.Log("The originator of this alarm disc is: " + Originator);
							if ((!Student.TurnOffRadio && Student.Alive && !Student.Pushed && !Student.Dying && !Student.Alarmed && !Student.Guarding && !Student.Wet && !Student.Slave && !Student.CheckingNote && !Student.WitnessedMurder && !Student.WitnessedCorpse && !Student.Emetic && !Student.Confessing && !StudentIsBusy && !Student.FocusOnYandere && !Student.Fleeing && !Student.Shoving && !Student.SentHome && Student.ClubActivityPhase < 16 && !Student.Vomiting && !Student.Lethal && !Student.Headache && !Student.Sedated && !Student.SenpaiWitnessingRivalDie && !Student.Hunted && !Student.Drowned && !Student.DramaticReaction && !Student.Blind && !Student.Yandere.Chased && !Student.ImmuneToLaughter && !Student.ListeningToReport) || (Student.Persona == PersonaType.Protective && Originator != null && Originator.StudentID == 11 && !Student.Hunted && !Student.Emetic))
							{
								Debug.Log("Nothing stopped " + Student.Name + " from reacting to an alarm disc.");
								_ = Student.Male;
								if (!Student.Struggling)
								{
									Student.Character.GetComponent<Animation>().CrossFade(Student.LeanAnim);
								}
								if (Originator != null)
								{
									if (Originator.WitnessedMurder)
									{
										Student.DistractionSpot = new Vector3(base.transform.position.x, Student.Yandere.transform.position.y, base.transform.position.z);
									}
									else if (Originator.Corpse == null)
									{
										Student.DistractionSpot = new Vector3(base.transform.position.x, Student.transform.position.y, base.transform.position.z);
									}
									else
									{
										Student.DistractionSpot = new Vector3(Originator.Corpse.transform.position.x, Student.transform.position.y, Originator.Corpse.transform.position.z);
									}
								}
								else
								{
									Student.DistractionSpot = new Vector3(base.transform.position.x, Student.transform.position.y, base.transform.position.z);
								}
								Student.DiscCheck = true;
								if (Shocking)
								{
									Student.Hesitation = 0.5f;
								}
								Student.Alarm = 200f;
								if (Originator != null && Originator.Attacked)
								{
									Debug.Log(Originator.Name + " spawned an Alarm Disc because they were attacked.");
								}
								if (Student.StudentID == 10 && Originator != null && Originator.StudentID == 11 && Originator.Attacked)
								{
									Debug.Log("Raibaru just became aware that Yandere-chan committed murder.");
									Student.AwareOfMurder = true;
								}
								if (!NoScream)
								{
									Student.Giggle = null;
									InvestigateScream();
								}
								if (FocusOnYandere)
								{
									Student.FocusOnYandere = true;
								}
								if (Hesitation != 1f)
								{
									Student.Hesitation = Hesitation;
								}
							}
						}
					}
					else
					{
						Debug.Log("A student just heard a radio...");
						if (Student.Giggle != null)
						{
							Student.StopInvestigating();
						}
						if (!Student.Nemesis && Student.Alive && !Student.Dying && !Student.Guarding && !Student.Alarmed && !Student.Wet && !Student.Slave && !Student.Headache && !Student.WitnessedMurder && !Student.WitnessedCorpse && !Student.Lethal && !Student.InEvent && !Student.Following && !Student.Distracting && Student.Actions[Student.Phase] != StudentActionType.Teaching && Student.Actions[Student.Phase] != StudentActionType.SitAndTakeNotes && !Student.GoAway && Student.Routine && !Student.CheckingNote && !Student.SentHome)
						{
							if (Student.CharacterAnimation != null && SourceRadio.Victim == null)
							{
								if (Student.StudentManager.LockerRoomArea.bounds.Contains(base.transform.position) || Student.StudentManager.WestBathroomArea.bounds.Contains(base.transform.position) || Student.StudentManager.EastBathroomArea.bounds.Contains(base.transform.position) || (Student.Club != ClubType.Delinquent && Student.StudentManager.IncineratorArea.bounds.Contains(base.transform.position)) || Student.StudentManager.HeadmasterArea.bounds.Contains(base.transform.position))
								{
									if (Student.Yandere.NotificationManager.NotificationParent.childCount < 5)
									{
										Student.Yandere.NotificationManager.CustomText = Student.Name + " ignored a radio.";
										if (Student.Yandere.NotificationManager.CustomText != Student.Yandere.NotificationManager.PreviousText)
										{
											Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
										}
									}
								}
								else
								{
									Debug.Log(Student.Name + " has just been alarmed by a radio!");
									Student.CharacterAnimation.CrossFade(Student.LeanAnim);
									Student.Pathfinding.canSearch = false;
									Student.Pathfinding.canMove = false;
									Student.EatingSnack = false;
									Student.Radio = SourceRadio;
									Student.TurnOffRadio = true;
									Student.Routine = false;
									Student.GoAway = false;
									bool flag = false;
									if (Student.Bento.activeInHierarchy && Student.StudentID > 1)
									{
										flag = true;
									}
									Student.EmptyHands();
									if (flag)
									{
										if (!Student.MyBento.Tampered)
										{
											Student.MyBento.enabled = true;
											Student.MyBento.Prompt.enabled = true;
										}
										Student.Bento.SetActive(value: true);
										Student.Bento.transform.parent = Student.transform;
										if (Student.Male)
										{
											Student.Bento.transform.localPosition = new Vector3(0f, 0.4266666f, -0.075f);
										}
										else
										{
											Student.Bento.transform.localPosition = new Vector3(0f, 0.461f, -0.075f);
										}
										Student.Bento.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
										Student.Bento.transform.parent = null;
									}
									Student.SpeechLines.Stop();
									Student.ChalkDust.Stop();
									Student.CleanTimer = 0f;
									Student.RadioTimer = 0f;
									Student.ReadPhase = 0;
									SourceRadio.Victim = Student;
									if (Student.StudentID == 97 && SchemeGlobals.GetSchemeStage(5) == 3)
									{
										SchemeGlobals.SetSchemeStage(5, 4);
										Student.Yandere.PauseScreen.Schemes.UpdateInstructions();
										base.enabled = false;
									}
									Student.Yandere.NotificationManager.CustomText = Student.Name + " hears the radio.";
									Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
								}
							}
						}
						else if (Student.Yandere.NotificationManager.NotificationParent.childCount < 5)
						{
							if (Student.Routine)
							{
								Student.Yandere.NotificationManager.CustomText = Student.Name + " is in an event right now!";
								Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
							}
							Student.Yandere.NotificationManager.CustomText = Student.Name + " ignored a radio.";
							if (Student.Yandere.NotificationManager.CustomText != Student.Yandere.NotificationManager.PreviousText)
							{
								Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
							}
						}
					}
				}
			}
		}
		Student = null;
	}

	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = 5f;
		audioSource.maxDistance = 10f;
		audioSource.spatialBlend = 1f;
		audioSource.volume = 0.5f;
		if (Student != null)
		{
			Student.DeathScream = gameObject;
		}
	}

	private void InvestigateScream()
	{
		if (Student.Clock.Period == 3 && Student.BusyAtLunch)
		{
			StudentIsBusy = true;
		}
		if (!Student.YandereVisible && !Student.Alarmed && !Student.Distracted && !Student.Wet && !Student.Slave && !Student.WitnessedMurder && !Student.WitnessedCorpse && !Student.InEvent && !Student.Following && !Student.Confessing && !Student.Meeting && !Student.TurnOffRadio && !Student.Fleeing && !Student.Distracting && !Student.GoAway && !Student.FocusOnYandere && !StudentIsBusy && Student.Actions[Student.Phase] != StudentActionType.Teaching && Student.Actions[Student.Phase] != StudentActionType.SitAndTakeNotes && Student.Actions[Student.Phase] != StudentActionType.Graffiti && Student.Actions[Student.Phase] != StudentActionType.Bully && !Student.Headache)
		{
			Student.Character.GetComponent<Animation>().CrossFade(Student.IdleAnim);
			GameObject giggle = Object.Instantiate(Student.EmptyGameObject, new Vector3(base.transform.position.x, Student.transform.position.y, base.transform.position.z), Quaternion.identity);
			Student.Giggle = giggle;
			if (Student.Pathfinding != null && !Student.Nemesis)
			{
				Student.Pathfinding.canSearch = false;
				Student.Pathfinding.canMove = false;
				Student.InvestigationPhase = 0;
				Student.InvestigationTimer = 0f;
				Student.Investigating = true;
				Student.EatingSnack = false;
				Student.SpeechLines.Stop();
				Student.ChalkDust.Stop();
				Student.DiscCheck = true;
				Student.Routine = false;
				Student.CleanTimer = 0f;
				Student.ReadPhase = 0;
				Student.StopPairing();
				Student.EmptyHands();
				Student.HeardScream = true;
			}
		}
	}
}
