using UnityEngine;

public class BucketScript : MonoBehaviour
{
	public PhoneEventScript PhoneEvent;

	public ParticleSystem PourEffect;

	public ParticleSystem Sparkles;

	public YandereScript Yandere;

	public PickUpScript PickUp;

	public PromptScript Prompt;

	public GameObject WaterCollider;

	public GameObject BloodCollider;

	public GameObject GasCollider;

	[SerializeField]
	private GameObject BloodSpillEffect;

	[SerializeField]
	private GameObject BrownSpillEffect;

	[SerializeField]
	private GameObject GasSpillEffect;

	[SerializeField]
	private GameObject SpillEffect;

	[SerializeField]
	private GameObject Effect;

	[SerializeField]
	private GameObject[] Dumbbell;

	[SerializeField]
	private Transform[] Positions;

	public Renderer Water;

	public Renderer Blood;

	public Renderer Brown;

	public Renderer Gas;

	public float Bloodiness;

	public float FillSpeed = 1f;

	public float Timer;

	[SerializeField]
	private float Distance;

	[SerializeField]
	private float Rotate;

	public int Dumbbells;

	public bool UpdateAppearance;

	public bool DyedBrown;

	public bool Bleached;

	public bool Dippable;

	public bool Gasoline;

	public bool Dropped;

	public bool Poured;

	public bool Full;

	public bool Trap;

	public bool Fly;

	public AudioClip EmptyBucket;

	public AudioClip FillBucket;

	public AudioClip CrackSkull;

	private void Start()
	{
		Water.transform.localPosition = new Vector3(Water.transform.localPosition.x, 0f, Water.transform.localPosition.z);
		Water.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
		Water.material.color = new Color(Water.material.color.r, Water.material.color.g, Water.material.color.b, 0f);
		Blood.material.color = new Color(Blood.material.color.r, Blood.material.color.g, Blood.material.color.b, 0f);
		Gas.transform.localPosition = new Vector3(Gas.transform.localPosition.x, 0f, Gas.transform.localPosition.z);
		Gas.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
		Gas.material.color = new Color(Gas.material.color.r, Gas.material.color.g, Gas.material.color.b, 0f);
		Brown.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
		Brown.material.color = new Color(Brown.material.color.r, Brown.material.color.g, Brown.material.color.b, 0f);
		Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	private void Update()
	{
		if (PickUp.Clock.Period == 5)
		{
			PickUp.Suspicious = false;
		}
		else
		{
			PickUp.Suspicious = true;
		}
		if (Yandere.CanMove)
		{
			Distance = Vector3.Distance(base.transform.position, Yandere.transform.position);
			if (Distance < 1f)
			{
				RaycastHit hitInfo;
				if (Yandere.Bucket == null)
				{
					if (base.transform.position.y > Yandere.transform.position.y - 0.1f && base.transform.position.y < Yandere.transform.position.y + 0.1f && Physics.Linecast(base.transform.position, Yandere.transform.position + Vector3.up, out hitInfo) && hitInfo.collider.gameObject == Yandere.gameObject)
					{
						Yandere.Bucket = this;
					}
				}
				else
				{
					if (Physics.Linecast(base.transform.position, Yandere.transform.position + Vector3.up, out hitInfo) && hitInfo.collider.gameObject != Yandere.gameObject)
					{
						Yandere.Bucket = null;
					}
					if (base.transform.position.y < Yandere.transform.position.y - 0.1f || base.transform.position.y > Yandere.transform.position.y + 0.1f)
					{
						Yandere.Bucket = null;
					}
				}
			}
			else if (Yandere.Bucket == this)
			{
				Yandere.Bucket = null;
			}
		}
		if (Yandere.Bucket == this && Yandere.Dipping)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, Yandere.transform.position + Yandere.transform.forward * 0.55f, Time.deltaTime * 10f);
			Quaternion b = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 10f);
		}
		if (Yandere.PickUp != null)
		{
			if (Yandere.Mop != null)
			{
				if (!Yandere.Chased && Yandere.Chasers == 0 && Full && !Gasoline && Bleached && Bloodiness < 100f)
				{
					Prompt.Label[3].text = "     Dip";
					Dippable = true;
				}
				else
				{
					Prompt.Label[3].text = "     Carry";
					Dippable = false;
				}
			}
			else if (Yandere.PickUp.JerryCan)
			{
				if (!Full)
				{
					if (!Yandere.PickUp.Empty)
					{
						Prompt.Label[0].text = "     Pour Gasoline";
						Prompt.HideButton[0] = false;
					}
					else
					{
						Prompt.HideButton[0] = true;
					}
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else if (Yandere.PickUp.Bleach)
			{
				if (Full && !Gasoline && !Bleached)
				{
					Prompt.Label[0].text = "     Pour Bleach";
					Prompt.HideButton[0] = false;
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else if (Yandere.PickUp.BrownPaint)
			{
				if (Full && !Gasoline && Bloodiness == 0f)
				{
					Prompt.Label[0].text = "     Add Brown Paint";
					Prompt.HideButton[0] = false;
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else if (Dippable)
			{
				Prompt.Label[3].text = "     Carry";
				Dippable = false;
			}
		}
		else
		{
			if (Dippable)
			{
				Prompt.Label[3].text = "     Carry";
				Dippable = false;
			}
			if (Yandere.Equipped > 0 && Yandere.EquippedWeapon != null)
			{
				if (!Full)
				{
					if (Yandere.EquippedWeapon.WeaponID == 12)
					{
						if (Dumbbells < 5)
						{
							Prompt.Label[0].text = "     Place Dumbbell";
							Prompt.HideButton[0] = false;
						}
						else
						{
							Prompt.HideButton[0] = true;
						}
					}
					else
					{
						Prompt.HideButton[0] = true;
					}
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else if (Dumbbells == 0)
			{
				Prompt.HideButton[0] = true;
			}
			else
			{
				Prompt.Label[0].text = "     Remove Dumbbell";
				Prompt.HideButton[0] = false;
			}
		}
		if (Yandere.Mop != null && Dippable && Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.Circle[3].fillAmount = 1f;
			Yandere.Bucket = this;
			Yandere.Mop.Dip();
		}
		if (Dumbbells > 0)
		{
			if (Prompt.Yandere.Class.PhysicalGrade + Prompt.Yandere.Class.PhysicalBonus == 0)
			{
				Prompt.Label[3].text = "     Physical Stat Too Low";
				Prompt.Circle[3].fillAmount = 1f;
			}
			else
			{
				Prompt.Label[3].text = "     Carry";
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Prompt.Label[0].text == "     Place Dumbbell")
			{
				Dumbbells++;
				Dumbbell[Dumbbells] = Yandere.EquippedWeapon.gameObject;
				Yandere.EmptyHands();
				Dumbbell[Dumbbells].GetComponent<WeaponScript>().enabled = false;
				Dumbbell[Dumbbells].GetComponent<PromptScript>().enabled = false;
				Dumbbell[Dumbbells].GetComponent<PromptScript>().Hide();
				Dumbbell[Dumbbells].GetComponent<Collider>().enabled = false;
				Rigidbody component = Dumbbell[Dumbbells].GetComponent<Rigidbody>();
				component.useGravity = false;
				component.isKinematic = true;
				Dumbbell[Dumbbells].transform.parent = base.transform;
				Dumbbell[Dumbbells].transform.localPosition = Positions[Dumbbells].localPosition;
				Dumbbell[Dumbbells].transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
			else if (Prompt.Label[0].text == "     Remove Dumbbell")
			{
				Yandere.EmptyHands();
				Dumbbell[Dumbbells].GetComponent<WeaponScript>().enabled = true;
				Dumbbell[Dumbbells].GetComponent<PromptScript>().enabled = true;
				Dumbbell[Dumbbells].GetComponent<WeaponScript>().Prompt.Circle[3].fillAmount = 0f;
				Dumbbell[Dumbbells].GetComponent<Rigidbody>().isKinematic = false;
				Dumbbell[Dumbbells] = null;
				Dumbbells--;
			}
			else if (Prompt.Label[0].text == "     Pour Gasoline")
			{
				Gasoline = true;
				Fill();
			}
			else if (Prompt.Label[0].text == "     Add Brown Paint")
			{
				DyedBrown = true;
				Fill();
			}
			else
			{
				Sparkles.Play();
				Bleached = true;
			}
		}
		if (UpdateAppearance)
		{
			if (Full)
			{
				if (Gasoline)
				{
					Gas.transform.localScale = Vector3.Lerp(Gas.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * FillSpeed);
					Gas.transform.localPosition = new Vector3(Gas.transform.localPosition.x, Mathf.Lerp(Gas.transform.localPosition.y, 0.2f, Time.deltaTime * 5f * FillSpeed), Gas.transform.localPosition.z);
					Gas.material.color = new Color(Gas.material.color.r, Gas.material.color.g, Gas.material.color.b, Mathf.Lerp(Gas.material.color.a, 1f, Time.deltaTime * 5f));
				}
				else if (DyedBrown)
				{
					Brown.transform.localScale = Vector3.Lerp(Brown.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * FillSpeed);
					Brown.transform.localPosition = new Vector3(Brown.transform.localPosition.x, Mathf.Lerp(Brown.transform.localPosition.y, 0.21f, Time.deltaTime * 5f * FillSpeed), Brown.transform.localPosition.z);
					Brown.material.color = new Color(Brown.material.color.r, Brown.material.color.g, Brown.material.color.b, Mathf.Lerp(Brown.material.color.a, 1f, Time.deltaTime * 5f));
				}
				else
				{
					Water.transform.localScale = Vector3.Lerp(Water.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * FillSpeed);
					Water.transform.localPosition = new Vector3(Water.transform.localPosition.x, Mathf.Lerp(Water.transform.localPosition.y, 0.2f, Time.deltaTime * 5f * FillSpeed), Water.transform.localPosition.z);
					Water.material.color = new Color(Water.material.color.r, Water.material.color.g, Water.material.color.b, Mathf.Lerp(Water.material.color.a, 1f, Time.deltaTime * 5f));
				}
			}
			else
			{
				Water.transform.localScale = Vector3.Lerp(Water.transform.localScale, new Vector3(0.9f, 1f, 0.9f), Time.deltaTime * 5f);
				Water.transform.localPosition = new Vector3(Water.transform.localPosition.x, Mathf.Lerp(Water.transform.localPosition.y, 0f, Time.deltaTime * 5f), Water.transform.localPosition.z);
				Water.material.color = new Color(Water.material.color.r, Water.material.color.g, Water.material.color.b, Mathf.Lerp(Water.material.color.a, 0f, Time.deltaTime * 5f));
				Gas.transform.localScale = Vector3.Lerp(Gas.transform.localScale, new Vector3(0.9f, 1f, 0.9f), Time.deltaTime * 5f);
				Gas.transform.localPosition = new Vector3(Gas.transform.localPosition.x, Mathf.Lerp(Gas.transform.localPosition.y, 0f, Time.deltaTime * 5f), Gas.transform.localPosition.z);
				Gas.material.color = new Color(Gas.material.color.r, Gas.material.color.g, Gas.material.color.b, Mathf.Lerp(Gas.material.color.a, 0f, Time.deltaTime * 5f));
				Brown.transform.localPosition = new Vector3(Brown.transform.localPosition.x, Mathf.Lerp(Brown.transform.localPosition.y, 0f, Time.deltaTime * 5f), Brown.transform.localPosition.z);
				Brown.material.color = new Color(Brown.material.color.r, Brown.material.color.g, Brown.material.color.b, Mathf.Lerp(Brown.material.color.a, 0f, Time.deltaTime * 5f));
			}
			Blood.material.color = new Color(Blood.material.color.r, Blood.material.color.g, Blood.material.color.b, Mathf.Lerp(Blood.material.color.a, Bloodiness / 100f, Time.deltaTime));
			Blood.transform.localPosition = new Vector3(Blood.transform.localPosition.x, Water.transform.localPosition.y + 0.001f, Blood.transform.localPosition.z);
			Blood.transform.localScale = Water.transform.localScale;
			Timer = Mathf.MoveTowards(Timer, 5f, Time.deltaTime);
			if (Timer == 5f)
			{
				UpdateAppearance = false;
				Timer = 0f;
			}
		}
		if (Yandere.PickUp != null)
		{
			if (Yandere.PickUp.Bucket == this)
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
			else if (!Trap)
			{
				Prompt.enabled = true;
			}
		}
		else if (!Trap)
		{
			Prompt.enabled = true;
		}
		if (Fly)
		{
			if (Rotate < 360f)
			{
				if (Rotate == 0f)
				{
					if (Bloodiness < 50f)
					{
						if (Gasoline)
						{
							Effect = Object.Instantiate(GasSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
							Gasoline = false;
						}
						else if (DyedBrown)
						{
							Effect = Object.Instantiate(BrownSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
							DyedBrown = false;
						}
						else
						{
							Effect = Object.Instantiate(SpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
						}
					}
					else
					{
						Effect = Object.Instantiate(BloodSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
						Bloodiness = 0f;
					}
					if (Trap)
					{
						Effect.transform.LookAt(Effect.transform.position - Vector3.up);
					}
					else
					{
						Rigidbody component2 = GetComponent<Rigidbody>();
						component2.AddRelativeForce(Vector3.forward * 150f);
						component2.AddRelativeForce(Vector3.up * 250f);
						base.transform.Translate(Vector3.forward * 0.5f);
					}
				}
				Rotate += Time.deltaTime * 360f;
				base.transform.Rotate(Vector3.right * Time.deltaTime * 360f);
			}
			else
			{
				Sparkles.Stop();
				Rotate = 0f;
				Trap = false;
				Fly = false;
			}
		}
		if (Dropped && base.transform.position.y < 0.5f)
		{
			base.gameObject.layer = 15;
			Dropped = false;
		}
	}

	public void Empty()
	{
		if (SchemeGlobals.GetSchemeStage(1) == 2)
		{
			SchemeGlobals.SetSchemeStage(1, 1);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		AudioSource.PlayClipAtPoint(EmptyBucket, base.transform.position);
		UpdateAppearance = true;
		Bloodiness = 0f;
		Bleached = false;
		Gasoline = false;
		Sparkles.Stop();
		Full = false;
	}

	public void Fill()
	{
		if (SchemeGlobals.GetSchemeStage(1) == 1)
		{
			SchemeGlobals.SetSchemeStage(1, 2);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		AudioSource.PlayClipAtPoint(FillBucket, base.transform.position);
		UpdateAppearance = true;
		Full = true;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (!Dropped)
		{
			return;
		}
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null)
		{
			GetComponent<AudioSource>().Play();
			while (Dumbbells > 0)
			{
				Dumbbell[Dumbbells].GetComponent<WeaponScript>().enabled = true;
				Dumbbell[Dumbbells].GetComponent<PromptScript>().enabled = true;
				Dumbbell[Dumbbells].GetComponent<Collider>().enabled = true;
				Rigidbody component2 = Dumbbell[Dumbbells].GetComponent<Rigidbody>();
				component2.constraints = RigidbodyConstraints.None;
				component2.isKinematic = false;
				component2.useGravity = true;
				Dumbbell[Dumbbells].transform.parent = null;
				Dumbbell[Dumbbells] = null;
				Dumbbells--;
			}
			component.DeathType = DeathType.Weight;
			component.BecomeRagdoll();
			Dropped = false;
			GameObjectUtils.SetLayerRecursively(base.gameObject, 15);
			component.MapMarker.gameObject.layer = 10;
			Debug.Log(component.Name + "'s ''Alive'' variable is: " + component.Alive);
		}
	}
}
