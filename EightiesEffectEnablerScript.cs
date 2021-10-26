using RetroAesthetics;
using UnityEngine;

public class EightiesEffectEnablerScript : MonoBehaviour
{
	public RetroCameraEffect EightiesEffects;

	public CameraFilterPack_Colors_Adjust_PreFilters EightiesFilter;

	public int Eights;

	public void Start()
	{
		if (EightiesEffects != null)
		{
			EightiesEffects.enabled = GameGlobals.Eighties;
		}
		UpdateEightiesEffects();
	}

	public void UpdateEightiesEffects()
	{
		if (EightiesEffects != null)
		{
			EightiesEffects.useStaticNoise = !OptionGlobals.DisableStatic;
			EightiesEffects.useDisplacementWaves = !OptionGlobals.DisableDisplacement;
			EightiesEffects.useChromaticAberration = !OptionGlobals.DisableAbberation;
			EightiesEffects.useVignette = !OptionGlobals.DisableVignette;
			EightiesEffects.useRadialDistortion = !OptionGlobals.DisableDistortion;
			EightiesEffects.useScanlines = !OptionGlobals.DisableScanlines;
			EightiesEffects.useBottomNoise = !OptionGlobals.DisableNoise;
			EightiesEffects.useBottomStretch = !OptionGlobals.DisableNoise;
		}
		if (EightiesFilter != null)
		{
			EightiesFilter.enabled = !OptionGlobals.DisableTint;
		}
	}
}
