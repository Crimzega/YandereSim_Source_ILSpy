using UnityEngine;

public class TranqDetectorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public DoorScript Door;

	public UIPanel Checklist;

	public Collider MyCollider;

	public UILabel KidnappingLabel;

	public UISprite TranquilizerIcon;

	public UISprite FollowerIcon;

	public UISprite BiologyIcon;

	public UISprite SyringeIcon;

	public UISprite DoorIcon;

	public bool StopChecking;

	public bool CannotKidnap;

	public int BasementPrisoner;

	public AudioClip[] TranqClips;

	private void Start()
	{
		Checklist.alpha = 0f;
		BasementPrisoner = SchoolGlobals.KidnapVictim;
	}

	private void Update()
	{
		if (!StopChecking)
		{
			if (MyCollider.bounds.Contains(Yandere.transform.position))
			{
				if (BasementPrisoner > 0)
				{
					KidnappingLabel.text = "There is no room for another prisoner in your basement.";
					CannotKidnap = true;
				}
				else
				{
					if (Yandere.Inventory.Tranquilizer || Yandere.Inventory.Sedative)
					{
						TranquilizerIcon.spriteName = "Yes";
					}
					else
					{
						TranquilizerIcon.spriteName = "No";
					}
					if (Yandere.Followers != 1)
					{
						FollowerIcon.spriteName = "No";
					}
					else if (Yandere.Follower.Male)
					{
						KidnappingLabel.text = "You cannot kidnap male students at this point in time.";
						FollowerIcon.spriteName = "No";
						CannotKidnap = true;
					}
					else
					{
						KidnappingLabel.text = "Kidnapping Checklist";
						FollowerIcon.spriteName = "Yes";
						CannotKidnap = false;
					}
					BiologyIcon.spriteName = ((Yandere.Class.BiologyGrade + Yandere.Class.BiologyBonus != 0) ? "Yes" : "No");
					if (!Yandere.Armed)
					{
						SyringeIcon.spriteName = "No";
					}
					else if (Yandere.EquippedWeapon.WeaponID != 3)
					{
						SyringeIcon.spriteName = "No";
					}
					else
					{
						SyringeIcon.spriteName = "Yes";
					}
					if (Door.Open || Door.Timer < 1f)
					{
						DoorIcon.spriteName = "No";
					}
					else
					{
						DoorIcon.spriteName = "Yes";
					}
				}
				Checklist.alpha = Mathf.MoveTowards(Checklist.alpha, 1f, Time.deltaTime);
			}
			else if (Checklist.alpha != 0f)
			{
				Checklist.alpha = Mathf.MoveTowards(Checklist.alpha, 0f, Time.deltaTime);
			}
		}
		else
		{
			Checklist.alpha = Mathf.MoveTowards(Checklist.alpha, 0f, Time.deltaTime);
			if (Checklist.alpha == 0f)
			{
				base.enabled = false;
			}
		}
	}

	public void TranqCheck()
	{
		if (!StopChecking && !CannotKidnap && TranquilizerIcon.spriteName == "Yes" && FollowerIcon.spriteName == "Yes" && BiologyIcon.spriteName == "Yes" && SyringeIcon.spriteName == "Yes" && DoorIcon.spriteName == "Yes")
		{
			AudioSource component = GetComponent<AudioSource>();
			component.clip = TranqClips[Random.Range(0, TranqClips.Length)];
			component.Play();
			Door.Prompt.Hide();
			Door.Prompt.enabled = false;
			Door.enabled = false;
			Yandere.Inventory.Tranquilizer = false;
			if (!Yandere.Follower.Male)
			{
				Yandere.CanTranq = true;
			}
			Yandere.EquippedWeapon.Type = WeaponType.Syringe;
			Yandere.AttackManager.Stealth = true;
			StopChecking = true;
		}
	}

	public void GarroteAttack()
	{
		AudioSource component = GetComponent<AudioSource>();
		component.clip = TranqClips[Random.Range(0, TranqClips.Length)];
		component.Play();
		Yandere.EquippedWeapon.Type = WeaponType.Syringe;
		Yandere.AttackManager.Stealth = true;
		StopChecking = true;
	}
}
