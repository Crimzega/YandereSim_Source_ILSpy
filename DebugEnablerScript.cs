using UnityEngine;

public class DebugEnablerScript : MonoBehaviour
{
	public GameObject StandWeapons;

	public GameObject VoidGoddess;

	public GameObject MurderKit;

	public GameObject Memes;

	public GameObject Keys;

	public DebugMenuScript DebugMenu;

	public YandereScript Yandere;

	public PrayScript Turtle;

	public DoorScript MemeClosetDoor;

	public PromptScript Prompt;

	public bool Editor;

	public int Spaces;

	private void Start()
	{
		if (MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.LoveSick || (!GameGlobals.Eighties && DateGlobals.Week == 2))
		{
			Object.Destroy(base.gameObject);
		}
		if (GameGlobals.Debug || Editor)
		{
			Editor = true;
			EnableDebug();
		}
	}

	public void EnableDebug()
	{
		Yandere.Inventory.PantyShots = 100;
		StandWeapons.SetActive(value: true);
		VoidGoddess.SetActive(value: true);
		MurderKit.SetActive(value: true);
		Memes.SetActive(value: true);
		Keys.SetActive(value: true);
		DebugMenu.MissionMode = false;
		DebugMenu.NoDebug = false;
		Yandere.NoDebug = false;
		Turtle.enabled = true;
		MemeClosetDoor.Locked = false;
		Object.Destroy(base.gameObject);
	}
}
