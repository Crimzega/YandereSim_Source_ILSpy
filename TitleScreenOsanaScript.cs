using UnityEngine;

public class TitleScreenOsanaScript : MonoBehaviour
{
	public NewTitleScreenScript NewTitleScreen;

	public Animation CharacterAnimation;

	public GameObject BloodPool;

	public GameObject[] DeadOsanas;

	private void Start()
	{
		if (GameGlobals.SpecificEliminationID > 0)
		{
			NewTitleScreen.ExtrasLabel.alpha = 1f;
			Debug.Log("TitleScreenOsanaScript is enabling the Extras menu.");
			DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(value: true);
		}
		if (GameGlobals.Eighties)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
