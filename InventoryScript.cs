using System.Globalization;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public GameObject ExplosiveDeviceSet;

	public bool FinishedHomework;

	public bool ModifiedUniform;

	public bool DirectionalMic;

	public bool DuplicateSheet;

	public bool AnswerSheet;

	public bool MaskingTape;

	public bool RivalPhone;

	public bool Narcotics;

	public bool LockPick;

	public bool Condoms;

	public bool Headset;

	public bool FakeID;

	public bool IDCard;

	public bool Book;

	public bool Cigs;

	public bool Ring;

	public bool Rose;

	public bool Sake;

	public bool Soda;

	public bool Bra;

	public bool AmnesiaBomb;

	public bool SmokeBomb;

	public bool StinkBomb;

	public bool LethalPoison;

	public bool ChemicalPoison;

	public bool EmeticPoison;

	public bool RatPoison;

	public bool HeadachePoison;

	public bool Tranquilizer;

	public bool Sedative;

	public bool CabinetKey;

	public bool CaseKey;

	public bool SafeKey;

	public bool ShedKey;

	public bool Ammonium;

	public bool Balloons;

	public bool Bandages;

	public bool Glass;

	public bool Hairpins;

	public bool Nails;

	public bool Paper;

	public bool PaperClips;

	public bool SilverFulminate;

	public bool WoodenSticks;

	public int MysteriousKeys;

	public int LethalPoisons;

	public int RivalPhoneID;

	public int SenpaiShots;

	public int PantyShots;

	public float Money;

	public bool[] ShrineCollectibles;

	public UILabel MoneyLabel;

	public bool ArrivedWithRatPoison;

	private void Start()
	{
		DirectionalMic = PlayerGlobals.DirectionalMic;
		Headset = PlayerGlobals.Headset;
		SenpaiShots = PlayerGlobals.SenpaiShots;
		PantyShots = PlayerGlobals.PantyShots;
		Money = PlayerGlobals.Money;
		if (PlayerGlobals.BringingItem == 4)
		{
			ArrivedWithRatPoison = true;
			RatPoison = true;
		}
		else if (PlayerGlobals.BringingItem == 5)
		{
			Sake = true;
		}
		else if (PlayerGlobals.BringingItem == 6)
		{
			Cigs = true;
		}
		else if (PlayerGlobals.BringingItem == 7)
		{
			Condoms = true;
		}
		else if (PlayerGlobals.BringingItem == 8)
		{
			LockPick = true;
		}
		else if (PlayerGlobals.BringingItem == 9)
		{
			Sedative = true;
		}
		else if (PlayerGlobals.BringingItem == 10)
		{
			Narcotics = true;
		}
		else if (PlayerGlobals.BringingItem == 11)
		{
			LethalPoison = true;
		}
		else if (PlayerGlobals.BringingItem == 12)
		{
			ExplosiveDeviceSet.SetActive(value: true);
		}
		UpdateMoney();
	}

	public void UpdateMoney()
	{
		MoneyLabel.text = "$" + Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}
}
