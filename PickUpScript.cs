using UnityEngine;

public class PickUpScript : MonoBehaviour
{
	public RigidbodyConstraints OriginalConstraints;

	public BloodCleanerScript BloodCleaner;

	public IncineratorScript Incinerator;

	public Collider PoolClosureCollider;

	public Transform ExplosiveDevice;

	public BodyPartScript BodyPart;

	public TrashCanScript TrashCan;

	public OutlineScript[] Outline;

	public YandereScript Yandere;

	public Animation MyAnimation;

	public GameObject Explosion;

	public BucketScript Bucket;

	public RadioScript MyRadio;

	public PromptScript Prompt;

	public GloveScript Gloves;

	public ClockScript Clock;

	public MopScript Mop;

	public Mesh EightiesMesh;

	public Mesh ClosedBook;

	public Mesh OpenBook;

	public Rigidbody MyRigidbody;

	public Collider MyCollider;

	public MeshFilter MyRenderer;

	public Vector3 TrashPosition;

	public Vector3 TrashRotation;

	public Vector3 OriginalScale;

	public Vector3 HoldPosition;

	public Vector3 HoldRotation;

	public Color EvidenceColor;

	public Color OriginalColor;

	public bool ConcealedBodyPart;

	public bool CleaningProduct;

	public bool DisableAtStart;

	public bool GarbageBagBox;

	public bool LockRotation;

	public bool BeingLifted;

	public bool KeepGravity;

	public bool BrownPaint;

	public bool CanCollide;

	public bool Electronic;

	public bool Flashlight;

	public bool PuzzleCube;

	public bool StinkBombs;

	public bool Suspicious;

	public bool BangSnaps;

	public bool Blowtorch;

	public bool Clothing;

	public bool Evidence;

	public bool JerryCan;

	public bool LeftHand;

	public bool RedPaint;

	public bool Garbage;

	public bool Bleach;

	public bool Dumped;

	public bool Remote;

	public bool Usable;

	public bool Weight;

	public bool Radio;

	public bool Salty;

	public bool Sign;

	public bool Tarp;

	public int CarryAnimID;

	public int Strength;

	public int Period;

	public int Food;

	public float KinematicTimer;

	public float DumpTimer;

	public bool Empty = true;

	public GameObject[] FoodPieces;

	public WeaponScript StuckBoxCutter;

	public GameObject TarpObject;

	public AudioClip PickUpSound;

	public AudioSource MyAudio;

	public Texture EightiesTexture;

	private void Start()
	{
		Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		Clock = GameObject.Find("Clock").GetComponent<ClockScript>();
		if (!CanCollide)
		{
			Physics.IgnoreCollision(Yandere.GetComponent<Collider>(), MyCollider);
		}
		if (Outline.Length != 0)
		{
			OriginalColor = Outline[0].color;
		}
		OriginalScale = base.transform.localScale;
		if (MyRigidbody == null)
		{
			MyRigidbody = GetComponent<Rigidbody>();
		}
		Gloves = GetComponent<GloveScript>();
		if (DisableAtStart)
		{
			base.gameObject.SetActive(value: false);
		}
		if (GameGlobals.Eighties && EightiesMesh != null)
		{
			GetComponent<MeshFilter>().mesh = EightiesMesh;
			if (!Sign)
			{
				GetComponent<Renderer>().material.mainTexture = EightiesTexture;
			}
			else
			{
				GetComponent<Renderer>().materials[1].mainTexture = EightiesTexture;
			}
			if (Radio)
			{
				GetComponent<RadioScript>().OffTexture = EightiesTexture;
				GetComponent<RadioScript>().OnTexture = EightiesTexture;
			}
		}
	}

	private void LateUpdate()
	{
		if (CleaningProduct)
		{
			if (Clock.Period == 5)
			{
				Suspicious = false;
			}
			else
			{
				Suspicious = true;
			}
		}
		if (Weight)
		{
			Strength = Prompt.Yandere.Class.PhysicalGrade + Prompt.Yandere.Class.PhysicalBonus;
			if (Strength == 0)
			{
				Prompt.Label[3].text = "     Physical Stat Too Low";
				Prompt.Circle[3].fillAmount = 1f;
			}
			else
			{
				Prompt.Label[3].text = "     Carry";
			}
		}
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.Circle[3].fillAmount = 1f;
			if (Weight)
			{
				if (!Yandere.Chased && Yandere.Chasers == 0)
				{
					if (Yandere.PickUp != null)
					{
						Yandere.CharacterAnimation[Yandere.CarryAnims[Yandere.PickUp.CarryAnimID]].weight = 0f;
					}
					if (Yandere.Armed)
					{
						Yandere.CharacterAnimation[Yandere.ArmedAnims[Yandere.EquippedWeapon.AnimID]].weight = 0f;
					}
					Yandere.targetRotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, Yandere.transform.position.y, base.transform.position.z) - Yandere.transform.position);
					Yandere.transform.rotation = Yandere.targetRotation;
					Yandere.EmptyHands();
					base.transform.parent = Yandere.transform;
					base.transform.localPosition = new Vector3(0f, 0f, 0.79184f);
					base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					Yandere.Character.GetComponent<Animation>().Play("f02_heavyWeightLift_00");
					Yandere.HeavyWeight = true;
					Yandere.CanMove = false;
					Yandere.Lifting = true;
					MyAnimation.Play("Weight_liftUp_00");
					MyRigidbody.isKinematic = true;
					BeingLifted = true;
				}
			}
			else
			{
				BePickedUp();
			}
		}
		if (Yandere.PickUp == this)
		{
			base.transform.localPosition = HoldPosition;
			base.transform.localEulerAngles = HoldRotation;
		}
		if (Dumped)
		{
			DumpTimer += Time.deltaTime;
			if (DumpTimer > 1f)
			{
				if (Clothing)
				{
					Yandere.Incinerator.BloodyClothing++;
					if (RedPaint)
					{
						Yandere.Incinerator.ClothingWithRedPaint++;
					}
				}
				else if ((bool)BodyPart)
				{
					Yandere.Incinerator.BodyParts++;
				}
				Object.Destroy(base.gameObject);
			}
		}
		if (Yandere.PickUp != this && !MyRigidbody.isKinematic)
		{
			if (!KeepGravity)
			{
				KinematicTimer = Mathf.MoveTowards(KinematicTimer, 5f, Time.deltaTime);
			}
			if (KinematicTimer == 5f)
			{
				MyRigidbody.isKinematic = true;
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -71f && base.transform.position.x < -61f && base.transform.position.z > -37.5f && base.transform.position.z < -27.5f)
			{
				Yandere.NotificationManager.CustomText = "You can't drop that there!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				base.transform.position = new Vector3(-63f, 1f, -26.5f);
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -46f && base.transform.position.x < -18f && base.transform.position.z > 66f && base.transform.position.z < 78f)
			{
				base.transform.position = new Vector3(-16f, 5f, 72f);
				KinematicTimer = 0f;
			}
		}
		if (Weight && BeingLifted)
		{
			if (Yandere.Lifting)
			{
				if (Yandere.StudentManager.Stop)
				{
					Drop();
				}
			}
			else
			{
				BePickedUp();
			}
		}
		if (!Remote)
		{
			return;
		}
		if (Prompt.Carried)
		{
			Debug.Log("Supposed to be showing/hiding buttons...");
			Prompt.HideButton[0] = false;
			Prompt.HideButton[3] = true;
			if (Prompt.Circle[0].fillAmount != 0f)
			{
				return;
			}
			Prompt.Circle[0].fillAmount = 1f;
			if (!Suspicious)
			{
				if (!MyRadio.On)
				{
					MyRadio.TurnOn();
				}
				else
				{
					MyRadio.TurnOff();
				}
			}
			else if (ExplosiveDevice != null)
			{
				if (Vector3.Distance(Yandere.transform.position, ExplosiveDevice.position) < 4f || Vector3.Distance(Yandere.Senpai.position, ExplosiveDevice.position) < 4f)
				{
					Yandere.NotificationManager.CustomText = "Haha, nope.";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					Yandere.StudentManager.Police.EndOfDay.ExplosiveDeviceUsed = true;
					Object.Instantiate(Explosion, ExplosiveDevice.position, Quaternion.identity);
					Object.Destroy(ExplosiveDevice.gameObject);
				}
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
		}
	}

	public void BePickedUp()
	{
		if (Radio && SchemeGlobals.GetSchemeStage(5) == 2)
		{
			SchemeGlobals.SetSchemeStage(5, 3);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (Salty && SchemeGlobals.GetSchemeStage(4) == 4)
		{
			SchemeGlobals.SetSchemeStage(4, 5);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (CarryAnimID == 10)
		{
			MyRenderer.mesh = OpenBook;
			Yandere.LifeNotePen.SetActive(value: true);
		}
		if (MyAnimation != null)
		{
			MyAnimation.Stop();
		}
		Prompt.Circle[3].fillAmount = 1f;
		BeingLifted = false;
		if (Yandere.PickUp != null)
		{
			Yandere.PickUp.Drop();
		}
		if (Yandere.Equipped == 3)
		{
			Yandere.Weapon[3].Drop();
		}
		else if (Yandere.Equipped > 0)
		{
			Yandere.Unequip();
		}
		if (Yandere.Dragging)
		{
			Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		if (Yandere.Carrying)
		{
			Yandere.StopCarrying();
		}
		if (!LeftHand)
		{
			base.transform.parent = Yandere.ItemParent;
		}
		else
		{
			base.transform.parent = Yandere.LeftItemParent;
		}
		if (GetComponent<RadioScript>() != null && GetComponent<RadioScript>().On)
		{
			GetComponent<RadioScript>().TurnOff();
		}
		MyCollider.enabled = false;
		if (MyRigidbody != null)
		{
			MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
		if (!Usable)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			Yandere.NearestPrompt = null;
		}
		else
		{
			Prompt.Carried = true;
		}
		Yandere.PickUp = this;
		Yandere.CarryAnimID = CarryAnimID;
		OutlineScript[] outline = Outline;
		for (int i = 0; i < outline.Length; i++)
		{
			outline[i].color = new Color(0f, 0f, 0f, 1f);
		}
		if ((bool)BodyPart)
		{
			Yandere.NearBodies++;
		}
		Yandere.StudentManager.UpdateStudents();
		MyRigidbody.isKinematic = true;
		KinematicTimer = 0f;
		if (PickUpSound != null)
		{
			AudioSource.PlayClipAtPoint(PickUpSound, base.transform.position);
		}
	}

	public void Drop()
	{
		if (Salty && SchemeGlobals.GetSchemeStage(4) == 5)
		{
			SchemeGlobals.SetSchemeStage(4, 4);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if ((bool)TrashCan)
		{
			Yandere.MyController.radius = 0.2f;
		}
		if (CarryAnimID == 10)
		{
			MyRenderer.mesh = ClosedBook;
			Yandere.LifeNotePen.SetActive(value: false);
		}
		if (Weight)
		{
			Yandere.IdleAnim = Yandere.OriginalIdleAnim;
			Yandere.WalkAnim = Yandere.OriginalWalkAnim;
			Yandere.RunAnim = Yandere.OriginalRunAnim;
		}
		if (BloodCleaner != null)
		{
			BloodCleaner.enabled = true;
			BloodCleaner.Pathfinding.enabled = true;
		}
		if (Yandere.PickUp == this)
		{
			Yandere.PickUp = null;
		}
		if ((bool)BodyPart)
		{
			if (ConcealedBodyPart)
			{
				base.transform.parent = Yandere.Police.GarbageParent;
			}
			else
			{
				base.transform.parent = Yandere.LimbParent;
			}
		}
		else
		{
			base.transform.parent = null;
		}
		if (LockRotation)
		{
			base.transform.localEulerAngles = new Vector3(0f, base.transform.localEulerAngles.y, 0f);
		}
		if (MyRigidbody != null)
		{
			MyRigidbody.constraints = OriginalConstraints;
			MyRigidbody.isKinematic = false;
			MyRigidbody.useGravity = true;
		}
		if (Dumped)
		{
			base.transform.position = Incinerator.DumpPoint.position;
			MyCollider.enabled = false;
		}
		else
		{
			Prompt.enabled = true;
			MyCollider.enabled = true;
			MyCollider.isTrigger = false;
			if (!CanCollide)
			{
				Physics.IgnoreCollision(Yandere.GetComponent<Collider>(), MyCollider);
			}
		}
		Prompt.Carried = false;
		if (Remote)
		{
			Prompt.HideButton[3] = false;
		}
		OutlineScript[] outline = Outline;
		for (int i = 0; i < outline.Length; i++)
		{
			outline[i].color = (Evidence ? EvidenceColor : OriginalColor);
		}
		base.transform.localScale = OriginalScale;
		if ((bool)BodyPart)
		{
			Yandere.NearBodies--;
		}
		Yandere.StudentManager.UpdateStudents();
		if (Sign)
		{
			if (Clock.Period < 3 && PoolClosureCollider.bounds.Contains(base.transform.position))
			{
				Yandere.NotificationManager.CustomText = "Students will now avoid the pool";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				base.transform.position = PoolClosureCollider.transform.position;
				base.transform.eulerAngles = PoolClosureCollider.transform.eulerAngles;
				Prompt.Hide();
				Prompt.enabled = false;
				MyCollider.isTrigger = false;
				MyRigidbody.useGravity = false;
				MyRigidbody.isKinematic = true;
				base.enabled = false;
				Yandere.StudentManager.RemovePoolFromRoutines();
			}
			else
			{
				if (Clock.Period < 3)
				{
					Yandere.NotificationManager.CustomText = "Place sign at top of pool stairs";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					Yandere.NotificationManager.CustomText = "It's too late in the day for that";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				base.transform.eulerAngles = new Vector3(90f, 0f, 0f);
			}
		}
		if (StinkBombs || BangSnaps)
		{
			Prompt.Yandere.Arc.SetActive(value: false);
			Prompt.HideButton[3] = false;
			Prompt.HideButton[0] = true;
		}
	}

	public void DisableGarbageBag()
	{
		Prompt.Hide();
		Prompt.enabled = false;
		MyCollider.enabled = false;
		MyRigidbody.useGravity = false;
		MyRigidbody.isKinematic = true;
		base.enabled = false;
	}
}
