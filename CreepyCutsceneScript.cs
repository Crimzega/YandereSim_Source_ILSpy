using UnityEngine;

public class CreepyCutsceneScript : MonoBehaviour
{
	public StreetShopInterfaceScript ShopInterface;

	public TypewriterEffect Typewriter;

	public GameObject Jukebox;

	public UILabel Label;

	public string[] Lines;

	public int ID;

	private void Update()
	{
		if (!Input.GetButtonDown("A"))
		{
			return;
		}
		if (Typewriter.mCurrentOffset < Typewriter.mFullText.Length)
		{
			Typewriter.Finish();
			return;
		}
		ID++;
		if (ID < Lines.Length)
		{
			Typewriter.ResetToBeginning();
			Label.text = "";
			Typewriter.mFullText = Lines[ID];
			return;
		}
		GameGlobals.MetBarber = true;
		base.gameObject.SetActive(value: false);
		Jukebox.SetActive(value: true);
		ShopInterface.TransitionToCreepyCutscene = false;
		ShopInterface.Salon.EightiesBarber();
		ShopInterface.Jukebox.Play();
	}
}
