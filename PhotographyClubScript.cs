using UnityEngine;

public class PhotographyClubScript : MonoBehaviour
{
	public GameObject CrimeScene;

	public GameObject InvestigationPhotos;

	public GameObject ArtsyPhotos;

	public GameObject StraightTables;

	public GameObject CrookedTables;

	private void Start()
	{
		if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
		{
			InvestigationPhotos.SetActive(value: true);
			ArtsyPhotos.SetActive(value: false);
			CrimeScene.SetActive(value: true);
			StraightTables.SetActive(value: true);
			CrookedTables.SetActive(value: false);
		}
		else
		{
			InvestigationPhotos.SetActive(value: false);
			ArtsyPhotos.SetActive(value: true);
			CrimeScene.SetActive(value: false);
			StraightTables.SetActive(value: false);
			CrookedTables.SetActive(value: true);
		}
	}
}
