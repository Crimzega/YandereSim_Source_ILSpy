using UnityEngine;

public class WeaponManagerScript : MonoBehaviour
{
	public WeaponScript[] DelinquentWeapons;

	public WeaponScript[] BroughtWeapons;

	public WeaponScript[] Weapons;

	public YandereScript Yandere;

	public JsonScript JSON;

	public int[] Victims;

	public int MisplacedWeapons;

	public int MurderWeapons;

	public int Fingerprints;

	public int YandereWeapon1 = -1;

	public int YandereWeapon2 = -1;

	public int YandereWeapon3 = -1;

	public int ReturnWeaponID = -1;

	public int ReturnStudentID = -1;

	public int OriginalEquipped = -1;

	public int OriginalWeapon = -1;

	public int WeaponsTouched;

	public int Frame;

	public Texture Flower;

	public Texture Blood;

	public bool YandereGuilty;

	public int BloodyWeapons;

	public void Start()
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			Weapons[i].GlobalID = i;
			if (WeaponGlobals.GetWeaponStatus(i) == 1)
			{
				Weapons[i].gameObject.SetActive(value: false);
			}
		}
		int bringingItem = PlayerGlobals.BringingItem;
		if (bringingItem > 0 && bringingItem < BroughtWeapons.Length)
		{
			BroughtWeapons[bringingItem].gameObject.SetActive(value: true);
		}
		ChangeBloodTexture();
	}

	public void UpdateLabels()
	{
		WeaponScript[] weapons = Weapons;
		foreach (WeaponScript weaponScript in weapons)
		{
			if (weaponScript != null)
			{
				weaponScript.UpdateLabel();
			}
		}
	}

	public void CheckWeapons()
	{
		MurderWeapons = 0;
		Fingerprints = 0;
		for (int i = 0; i < Victims.Length; i++)
		{
			Victims[i] = 0;
		}
		WeaponScript[] weapons = Weapons;
		foreach (WeaponScript weaponScript in weapons)
		{
			if (!(weaponScript != null) || !weaponScript.Blood.enabled || weaponScript.AlreadyExamined)
			{
				continue;
			}
			MurderWeapons++;
			if (weaponScript.FingerprintID <= 0)
			{
				continue;
			}
			Fingerprints++;
			for (int k = 0; k < weaponScript.Victims.Length; k++)
			{
				if (weaponScript.Victims[k])
				{
					Victims[k] = weaponScript.FingerprintID;
				}
			}
		}
	}

	public void CleanWeapons()
	{
		WeaponScript[] weapons = Weapons;
		foreach (WeaponScript weaponScript in weapons)
		{
			if (weaponScript != null)
			{
				weaponScript.Blood.enabled = false;
				weaponScript.FingerprintID = 0;
			}
		}
	}

	public void ChangeBloodTexture()
	{
		WeaponScript[] weapons = Weapons;
		foreach (WeaponScript weaponScript in weapons)
		{
			if (weaponScript != null)
			{
				if (!GameGlobals.CensorBlood)
				{
					weaponScript.Blood.material.mainTexture = Blood;
					weaponScript.Blood.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.5f));
				}
				else
				{
					weaponScript.Blood.material.mainTexture = Flower;
					weaponScript.Blood.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.5f));
				}
			}
		}
	}

	private void Update()
	{
		if (OriginalWeapon > -1)
		{
			Debug.Log("Re-equipping original weapon.");
			Yandere.WeaponMenu.Selected = OriginalEquipped;
			Yandere.WeaponMenu.Equip();
			OriginalWeapon = -1;
			Frame++;
		}
	}

	public void TrackDumpedWeapons()
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (Weapons[i] == null)
			{
				Debug.Log("Weapon #" + i + " was destroyed! Setting status to 1!");
			}
		}
	}

	public void SetEquippedWeapon1(WeaponScript Weapon)
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (Weapons[i] == Weapon)
			{
				YandereWeapon1 = i;
			}
		}
	}

	public void SetEquippedWeapon2(WeaponScript Weapon)
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (Weapons[i] == Weapon)
			{
				YandereWeapon2 = i;
			}
		}
	}

	public void SetEquippedWeapon3(WeaponScript Weapon)
	{
		for (int i = 0; i < Weapons.Length; i++)
		{
			if (Weapons[i] == Weapon)
			{
				YandereWeapon3 = i;
			}
		}
	}

	public void EquipWeaponsFromSave()
	{
		OriginalEquipped = Yandere.Equipped;
		if (Yandere.Equipped == 1)
		{
			OriginalWeapon = YandereWeapon1;
		}
		else if (Yandere.Equipped == 2)
		{
			OriginalWeapon = YandereWeapon2;
		}
		else if (Yandere.Equipped == 3)
		{
			OriginalWeapon = YandereWeapon3;
		}
		if (Yandere.Equipped > 0)
		{
			Yandere.Unequip();
		}
		if (Yandere.Weapon[1] != null)
		{
			Yandere.Weapon[1].Drop();
		}
		if (Yandere.Weapon[2] != null)
		{
			Yandere.Weapon[2].Drop();
		}
		if (YandereWeapon1 > -1)
		{
			Weapons[YandereWeapon1].Prompt.Circle[3].fillAmount = 0f;
			Weapons[YandereWeapon1].gameObject.SetActive(value: true);
			Weapons[YandereWeapon1].UnequipImmediately = true;
		}
		if (YandereWeapon2 > -1)
		{
			Weapons[YandereWeapon2].Prompt.Circle[3].fillAmount = 0f;
			Weapons[YandereWeapon2].gameObject.SetActive(value: true);
			Weapons[YandereWeapon2].UnequipImmediately = true;
		}
		if (YandereWeapon3 > -1)
		{
			Weapons[YandereWeapon3].Prompt.Circle[3].fillAmount = 0f;
			Weapons[YandereWeapon3].gameObject.SetActive(value: true);
			Weapons[YandereWeapon3].UnequipImmediately = true;
		}
	}

	public void UpdateDelinquentWeapons()
	{
		for (int i = 1; i < DelinquentWeapons.Length; i++)
		{
			if (DelinquentWeapons[i].DelinquentOwned)
			{
				DelinquentWeapons[i].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				DelinquentWeapons[i].transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			else
			{
				DelinquentWeapons[i].transform.parent = null;
			}
		}
	}

	public void RestoreWeaponToStudent()
	{
		if (ReturnWeaponID > -1)
		{
			Yandere.StudentManager.Students[ReturnStudentID].BloodPool = Weapons[ReturnWeaponID].transform;
			Yandere.StudentManager.Students[ReturnStudentID].BloodPool = Weapons[ReturnWeaponID].transform;
			Yandere.StudentManager.Students[ReturnStudentID].BloodPool = Weapons[ReturnWeaponID].transform;
			Yandere.StudentManager.Students[ReturnStudentID].CurrentDestination = Weapons[ReturnWeaponID].Origin;
			Yandere.StudentManager.Students[ReturnStudentID].Pathfinding.target = Weapons[ReturnWeaponID].Origin;
			Weapons[ReturnWeaponID].Prompt.Hide();
			Weapons[ReturnWeaponID].Prompt.enabled = false;
			Weapons[ReturnWeaponID].enabled = false;
			Weapons[ReturnWeaponID].Returner = Yandere.StudentManager.Students[ReturnStudentID];
			Weapons[ReturnWeaponID].transform.parent = Yandere.StudentManager.Students[ReturnStudentID].RightHand;
			Weapons[ReturnWeaponID].transform.localPosition = new Vector3(0f, 0f, 0f);
			Weapons[ReturnWeaponID].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Yandere.StudentManager.Students[ReturnStudentID].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		}
	}

	public void UpdateAllWeapons()
	{
		for (int i = 1; i < Weapons.Length; i++)
		{
			Weapons[i].SuspicionCheck();
		}
	}

	public void CountBloodyWeapons()
	{
		BloodyWeapons = 0;
		for (int i = 1; i < Weapons.Length; i++)
		{
			if (Weapons[i].Bloody)
			{
				BloodyWeapons++;
			}
		}
	}
}
