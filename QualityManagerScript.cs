using RetroAesthetics;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class QualityManagerScript : MonoBehaviour
{
	public CameraFilterPack_Colors_Adjust_PreFilters ColorGrading;

	public CameraFilterPack_Colors_Adjust_PreFilters Tint;

	public AntialiasingAsPostEffect PostAliasing;

	public StudentManagerScript StudentManager;

	public PostProcessingBehaviour Obscurance;

	public SettingsScript Settings;

	public NemesisScript Nemesis;

	public YandereScript Yandere;

	public Bloom BloomEffect;

	public GameObject Grass;

	public Light Sun;

	public ParticleSystem EastRomanceBlossoms;

	public ParticleSystem WestRomanceBlossoms;

	public ParticleSystem CorridorBlossoms;

	public ParticleSystem PlazaBlossoms;

	public ParticleSystem MythBlossoms;

	public ParticleSystem[] Fountains;

	public ParticleSystem[] Steam;

	public Renderer YandereHairRenderer;

	public Shader NewBodyShader;

	public Shader NewHairShader;

	public Shader Toon;

	public Shader ToonOverlay;

	public Shader ToonOutline;

	public Shader ToonOutlineOverlay;

	public Shader ToonRimLight;

	public Shader ToonRimLightOverlay;

	public Shader ToonOutlineRimLight;

	public Shader ToonOutlineRimLightOverlay;

	public BloomAndLensFlares ExperimentalBloomAndLensFlares;

	public DepthOfField34 ExperimentalDepthOfField34;

	public SSAOEffect ExperimentalSSAOEffect;

	public bool DoNothing;

	private static readonly int[] FPSValues = new int[4] { 2147483647, 30, 60, 120 };

	public static readonly string[] FPSStrings = new string[4] { "Unlimited", "30", "60", "120" };

	public RetroCameraEffect EightiesEffects;

	public void Start()
	{
		OptionGlobals.DisableOutlines = false;
		OptionGlobals.RimLight = true;
		if (OptionGlobals.DrawDistance == 0)
		{
			OptionGlobals.DrawDistanceLimit = 350;
			OptionGlobals.DrawDistance = 350;
		}
		if (SceneManager.GetActiveScene().name != "SchoolScene")
		{
			DoNothing = true;
		}
		if (!DoNothing)
		{
			if (OptionGlobals.ParticleCount == 0)
			{
				OptionGlobals.ParticleCount = 3;
			}
			if (OptionGlobals.DisableFarAnimations == 0)
			{
				OptionGlobals.DisableFarAnimations = 10;
			}
			if (OptionGlobals.Sensitivity == 0)
			{
				OptionGlobals.Sensitivity = 3;
			}
			if (ColorGrading == null)
			{
				CameraFilterPack_Colors_Adjust_PreFilters[] components = StudentManager.MainCamera.GetComponents<CameraFilterPack_Colors_Adjust_PreFilters>();
				ColorGrading = components[2];
			}
			Yandere.PauseScreen.NewSettings.Profile.depthOfField.enabled = OptionGlobals.DepthOfField;
			Yandere.PauseScreen.NewSettings.Profile.motionBlur.enabled = OptionGlobals.MotionBlur;
			StudentManager.TransparentWindows = false;
			StudentManager.SetWindowsOpaque();
			StudentManager.LateUpdate();
			ToggleRun();
			UpdateFog();
			DisplayFPS();
			UpdateHair();
			UpdateAnims();
			UpdateVsync();
			UpdateGrass();
			UpdateShadows();
			UpdateFPSIndex();
			UpdateDrawDistance();
			UpdateOpaqueWindows();
			UpdateLowDetailStudents();
			UpdateEightiesEffects();
		}
	}

	public void UpdateParticles()
	{
		if (OptionGlobals.ParticleCount > 3)
		{
			OptionGlobals.ParticleCount = 1;
		}
		else if (OptionGlobals.ParticleCount < 1)
		{
			OptionGlobals.ParticleCount = 3;
		}
		if (!DoNothing)
		{
			ParticleSystem.EmissionModule emission = EastRomanceBlossoms.emission;
			ParticleSystem.EmissionModule emission2 = WestRomanceBlossoms.emission;
			ParticleSystem.EmissionModule emission3 = CorridorBlossoms.emission;
			ParticleSystem.EmissionModule emission4 = PlazaBlossoms.emission;
			ParticleSystem.EmissionModule emission5 = MythBlossoms.emission;
			ParticleSystem.EmissionModule emission6 = Steam[1].emission;
			ParticleSystem.EmissionModule emission7 = Fountains[1].emission;
			ParticleSystem.EmissionModule emission8 = Fountains[2].emission;
			ParticleSystem.EmissionModule emission9 = Fountains[3].emission;
			emission.enabled = true;
			emission2.enabled = true;
			emission3.enabled = true;
			emission4.enabled = true;
			emission5.enabled = true;
			emission6.enabled = true;
			emission7.enabled = true;
			emission8.enabled = true;
			emission9.enabled = true;
			if (OptionGlobals.ParticleCount == 3)
			{
				emission.rateOverTime = 100f;
				emission2.rateOverTime = 100f;
				emission3.rateOverTime = 1000f;
				emission4.rateOverTime = 400f;
				emission5.rateOverTime = 100f;
				emission6.rateOverTime = 100f;
				emission7.rateOverTime = 100f;
				emission8.rateOverTime = 100f;
				emission9.rateOverTime = 100f;
			}
			else if (OptionGlobals.ParticleCount == 2)
			{
				emission.rateOverTime = 10f;
				emission2.rateOverTime = 10f;
				emission3.rateOverTime = 100f;
				emission4.rateOverTime = 40f;
				emission5.rateOverTime = 10f;
				emission6.rateOverTime = 10f;
				emission7.rateOverTime = 10f;
				emission8.rateOverTime = 10f;
				emission9.rateOverTime = 10f;
			}
			else if (OptionGlobals.ParticleCount == 1)
			{
				emission.enabled = false;
				emission2.enabled = false;
				emission3.enabled = false;
				emission4.enabled = false;
				emission5.enabled = false;
				emission6.enabled = false;
				emission7.enabled = false;
				emission8.enabled = false;
				emission9.enabled = false;
			}
		}
	}

	public void UpdateOutlines()
	{
		if (DoNothing)
		{
			return;
		}
		for (int i = 1; i < StudentManager.Students.Length; i++)
		{
			StudentScript studentScript = StudentManager.Students[i];
			if (!(studentScript != null))
			{
				continue;
			}
			if (OptionGlobals.DisableOutlines)
			{
				NewHairShader = Toon;
				NewBodyShader = ToonOverlay;
			}
			else
			{
				NewHairShader = ToonOutline;
				NewBodyShader = ToonOutlineOverlay;
			}
			if (!studentScript.Male)
			{
				studentScript.MyRenderer.materials[0].shader = NewBodyShader;
				studentScript.MyRenderer.materials[1].shader = NewBodyShader;
				studentScript.MyRenderer.materials[2].shader = NewBodyShader;
				studentScript.Cosmetic.RightStockings[0].GetComponent<Renderer>().material.shader = NewBodyShader;
				studentScript.Cosmetic.LeftStockings[0].GetComponent<Renderer>().material.shader = NewBodyShader;
				if (studentScript.Club == ClubType.Bully)
				{
					studentScript.Cosmetic.Bookbag.GetComponent<Renderer>().material.shader = NewHairShader;
					studentScript.Cosmetic.LeftWristband.GetComponent<Renderer>().material.shader = NewHairShader;
					studentScript.Cosmetic.RightWristband.GetComponent<Renderer>().material.shader = NewHairShader;
					studentScript.Cosmetic.HoodieRenderer.GetComponent<Renderer>().material.shader = NewHairShader;
				}
				if (studentScript.StudentID == 87)
				{
					studentScript.Cosmetic.ScarfRenderer.material.shader = NewHairShader;
				}
				else if (studentScript.StudentID == 90)
				{
					if (studentScript.Cosmetic.TeacherAccessories[studentScript.Cosmetic.Accessory] != null)
					{
						studentScript.Cosmetic.TeacherAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = NewHairShader;
					}
					if (studentScript.MyRenderer.materials.Length == 4)
					{
						studentScript.MyRenderer.materials[3].shader = NewBodyShader;
					}
				}
			}
			else
			{
				studentScript.MyRenderer.materials[0].shader = NewHairShader;
				studentScript.MyRenderer.materials[1].shader = NewHairShader;
				studentScript.MyRenderer.materials[2].shader = NewBodyShader;
			}
			studentScript.Armband.GetComponent<Renderer>().material.shader = NewHairShader;
			if (!studentScript.Male)
			{
				if (!studentScript.Teacher)
				{
					if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
					{
						if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
						{
							studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewHairShader;
						}
						else
						{
							studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = NewHairShader;
							studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = NewHairShader;
						}
					}
					if (studentScript.Cosmetic.Accessory > 0 && studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>() != null)
					{
						studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = NewHairShader;
					}
				}
				else
				{
					if (studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
					{
						studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewHairShader;
					}
					if (studentScript.Cosmetic.Accessory <= 0)
					{
					}
				}
			}
			else
			{
				if (studentScript.Cosmetic.Hairstyle > 0)
				{
					if (studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
					{
						studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewHairShader;
					}
					else
					{
						studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = NewHairShader;
						studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = NewHairShader;
					}
				}
				if (studentScript.Cosmetic.Accessory > 0)
				{
					Renderer component = studentScript.Cosmetic.MaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>();
					if (component != null)
					{
						component.material.shader = NewHairShader;
					}
				}
			}
			if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.Club != ClubType.Council && studentScript.Cosmetic.Club != ClubType.Bully && studentScript.Cosmetic.Club != ClubType.Delinquent && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null)
			{
				Renderer component2 = studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club].GetComponent<Renderer>();
				if (component2 != null)
				{
					component2.material.shader = NewHairShader;
				}
			}
		}
		Yandere.MyRenderer.materials[0].shader = NewBodyShader;
		Yandere.MyRenderer.materials[1].shader = NewBodyShader;
		Yandere.MyRenderer.materials[2].shader = NewBodyShader;
		for (int j = 1; j < Yandere.Hairstyles.Length; j++)
		{
			Renderer component3 = Yandere.Hairstyles[j].GetComponent<Renderer>();
			if (component3 != null)
			{
				YandereHairRenderer.material.shader = NewHairShader;
				component3.material.shader = NewHairShader;
			}
		}
		Nemesis.Cosmetic.MyRenderer.materials[0].shader = NewBodyShader;
		Nemesis.Cosmetic.MyRenderer.materials[1].shader = NewBodyShader;
		Nemesis.Cosmetic.MyRenderer.materials[2].shader = NewBodyShader;
		Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = NewHairShader;
	}

	public void UpdatePostAliasing()
	{
		if (!DoNothing)
		{
			PostAliasing.enabled = !OptionGlobals.DisablePostAliasing;
		}
	}

	public void UpdateBloom()
	{
		if (!DoNothing)
		{
			BloomEffect.enabled = !OptionGlobals.DisableBloom;
		}
	}

	public void UpdateOpaqueWindows()
	{
		if (!DoNothing)
		{
			if (OptionGlobals.OpaqueWindows)
			{
				StudentManager.TransparentWindows = false;
				StudentManager.SetWindowsOpaque();
			}
			else
			{
				StudentManager.WindowOccluder.open = true;
				StudentManager.TransparentWindows = true;
				StudentManager.SetWindowsTransparent();
			}
			StudentManager.LateUpdate();
		}
	}

	public void UpdateColorGrading()
	{
		if (!DoNothing)
		{
			ColorGrading.enabled = OptionGlobals.ColorGrading;
		}
	}

	public void UpdateGrass()
	{
		if (!DoNothing)
		{
			Grass.SetActive(OptionGlobals.ToggleGrass);
		}
	}

	public void UpdateHair()
	{
		if (!DoNothing)
		{
			StudentManager.UpdateDynamicBones(!OptionGlobals.HairPhysics);
		}
	}

	public void DisplayFPS()
	{
		if (!DoNothing)
		{
			StudentManager.UpdateFPSDisplay(OptionGlobals.DisplayFPS);
		}
	}

	public void UpdateLowDetailStudents()
	{
		if (OptionGlobals.LowDetailStudents > 10)
		{
			OptionGlobals.LowDetailStudents = 0;
		}
		else if (OptionGlobals.LowDetailStudents < 0)
		{
			OptionGlobals.LowDetailStudents = 10;
		}
		if (DoNothing)
		{
			return;
		}
		StudentManager.LowDetailThreshold = OptionGlobals.LowDetailStudents * 10;
		bool flag = false;
		flag = (((float)StudentManager.LowDetailThreshold > 0f) ? true : false);
		for (int i = 1; i < 101; i++)
		{
			if (StudentManager.Students[i] != null)
			{
				StudentManager.Students[i].LowPoly.enabled = flag;
				if (!flag && StudentManager.Students[i].LowPoly.MyMesh.enabled)
				{
					StudentManager.Students[i].LowPoly.MyMesh.enabled = false;
					StudentManager.Students[i].MyRenderer.enabled = true;
				}
			}
		}
	}

	public void UpdateAnims()
	{
		if (OptionGlobals.DisableFarAnimations > 20)
		{
			OptionGlobals.DisableFarAnimations = 1;
		}
		else if (OptionGlobals.DisableFarAnimations < 1)
		{
			OptionGlobals.DisableFarAnimations = 20;
		}
		if (!DoNothing)
		{
			StudentManager.FarAnimThreshold = OptionGlobals.DisableFarAnimations * 5;
			if ((float)StudentManager.FarAnimThreshold > 0f)
			{
				StudentManager.DisableFarAnims = true;
			}
			else
			{
				StudentManager.DisableFarAnims = false;
			}
		}
	}

	public void UpdateDrawDistance()
	{
		if (OptionGlobals.DrawDistance > OptionGlobals.DrawDistanceLimit)
		{
			OptionGlobals.DrawDistance = 10;
		}
		else if (OptionGlobals.DrawDistance < 1)
		{
			OptionGlobals.DrawDistance = OptionGlobals.DrawDistanceLimit;
		}
		if (!DoNothing)
		{
			Camera.main.farClipPlane = OptionGlobals.DrawDistance;
			RenderSettings.fogEndDistance = OptionGlobals.DrawDistance;
			Yandere.Smartphone.farClipPlane = OptionGlobals.DrawDistance;
		}
	}

	public void UpdateVsync()
	{
		if (!OptionGlobals.Vsync)
		{
			QualitySettings.vSyncCount = 0;
		}
		else
		{
			QualitySettings.vSyncCount = 1;
		}
	}

	public void UpdateFog()
	{
		if (DoNothing)
		{
			return;
		}
		if (GameGlobals.EightiesTutorial)
		{
			Debug.Log("The QualityManager script knows that we're in the tutorial, so it is manually enabling Fog.");
			OptionGlobals.Fog = true;
		}
		if (!OptionGlobals.Fog)
		{
			Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
			RenderSettings.fogMode = FogMode.Exponential;
			return;
		}
		Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogEndDistance = OptionGlobals.DrawDistance;
		if (GameGlobals.EightiesTutorial && DateGlobals.Week < 10)
		{
			Debug.Log("The QualityManager script is now manually changing the Fog settings.");
			RenderSettings.fogColor = new Color(1f, 1f, 1f, 1f);
			RenderSettings.fogMode = FogMode.Exponential;
			RenderSettings.fogDensity = 0.1f;
		}
	}

	public void UpdateShadows()
	{
		if (!DoNothing)
		{
			Sun.shadows = (OptionGlobals.EnableShadows ? LightShadows.Soft : LightShadows.None);
		}
	}

	public void ToggleRun()
	{
		if (!DoNothing)
		{
			Yandere.ToggleRun = OptionGlobals.ToggleRun;
		}
	}

	public void UpdateFPSIndex()
	{
		if (OptionGlobals.FPSIndex < 0)
		{
			OptionGlobals.FPSIndex = FPSValues.Length - 1;
		}
		else if (OptionGlobals.FPSIndex >= FPSValues.Length)
		{
			OptionGlobals.FPSIndex = 0;
		}
		Application.targetFrameRate = FPSValues[OptionGlobals.FPSIndex];
	}

	public void ToggleExperiment()
	{
		if (!DoNothing)
		{
			if (!ExperimentalBloomAndLensFlares.enabled)
			{
				ExperimentalBloomAndLensFlares.enabled = true;
				ExperimentalDepthOfField34.enabled = false;
				ExperimentalSSAOEffect.enabled = false;
				BloomEffect.enabled = true;
			}
			else
			{
				ExperimentalBloomAndLensFlares.enabled = false;
				ExperimentalDepthOfField34.enabled = false;
				ExperimentalSSAOEffect.enabled = false;
				BloomEffect.enabled = false;
			}
		}
	}

	public void UpdateOutlinesAndRimlight()
	{
		if (OptionGlobals.DisableOutlines)
		{
			if (OptionGlobals.RimLight)
			{
				NewHairShader = ToonRimLight;
				NewBodyShader = ToonRimLightOverlay;
			}
			else
			{
				NewHairShader = Toon;
				NewBodyShader = ToonOverlay;
			}
		}
		else if (OptionGlobals.RimLight)
		{
			NewHairShader = ToonOutlineRimLight;
			NewBodyShader = ToonOutlineRimLightOverlay;
		}
		else
		{
			NewHairShader = ToonOutline;
			NewBodyShader = ToonOutlineOverlay;
		}
		if (DoNothing)
		{
			return;
		}
		for (int i = 1; i < StudentManager.Students.Length; i++)
		{
			StudentScript studentScript = StudentManager.Students[i];
			if (!(studentScript != null))
			{
				continue;
			}
			studentScript.MyRenderer.materials[0].shader = NewBodyShader;
			studentScript.MyRenderer.materials[1].shader = NewBodyShader;
			studentScript.MyRenderer.materials[2].shader = NewBodyShader;
			AdjustRimLight(studentScript.MyRenderer.materials[0]);
			AdjustRimLight(studentScript.MyRenderer.materials[1]);
			AdjustRimLight(studentScript.MyRenderer.materials[2]);
			if (!studentScript.Male)
			{
				if (!studentScript.Teacher)
				{
					if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
					{
						if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
						{
							studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewBodyShader;
							AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
						}
						else
						{
							studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = NewBodyShader;
							studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = NewBodyShader;
							AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0]);
							AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1]);
						}
					}
					if (studentScript.Cosmetic.Accessory > 0 && studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>() != null)
					{
						studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = NewBodyShader;
						AdjustRimLight(studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material);
					}
				}
				else
				{
					studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewBodyShader;
					AdjustRimLight(studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material);
				}
			}
			else
			{
				if (studentScript.Cosmetic.Hairstyle > 0)
				{
					if (studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
					{
						studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewBodyShader;
						AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
					}
					else
					{
						studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = NewBodyShader;
						studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = NewBodyShader;
						AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0]);
						AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1]);
					}
				}
				if (studentScript.Cosmetic.Accessory > 0)
				{
					Renderer component = studentScript.Cosmetic.MaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>();
					if (component != null)
					{
						component.material.shader = NewBodyShader;
						AdjustRimLight(component.material);
					}
				}
			}
			if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.Club != ClubType.Council && studentScript.Cosmetic.Club != ClubType.Bully && studentScript.Cosmetic.Club != ClubType.Delinquent && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null)
			{
				Renderer component2 = studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club].GetComponent<Renderer>();
				if (component2 != null)
				{
					component2.material.shader = NewBodyShader;
					AdjustRimLight(component2.material);
				}
			}
		}
		Yandere.MyRenderer.materials[0].shader = NewBodyShader;
		Yandere.MyRenderer.materials[1].shader = NewBodyShader;
		Yandere.MyRenderer.materials[2].shader = NewBodyShader;
		AdjustRimLight(Yandere.MyRenderer.materials[0]);
		AdjustRimLight(Yandere.MyRenderer.materials[1]);
		AdjustRimLight(Yandere.MyRenderer.materials[2]);
		for (int j = 1; j < Yandere.Hairstyles.Length; j++)
		{
			Renderer component3 = Yandere.Hairstyles[j].GetComponent<Renderer>();
			if (component3 != null)
			{
				YandereHairRenderer.material.shader = NewBodyShader;
				component3.material.shader = NewBodyShader;
				AdjustRimLight(YandereHairRenderer.material);
				AdjustRimLight(component3.material);
			}
		}
		Nemesis.Cosmetic.MyRenderer.materials[0].shader = NewBodyShader;
		Nemesis.Cosmetic.MyRenderer.materials[1].shader = NewBodyShader;
		Nemesis.Cosmetic.MyRenderer.materials[2].shader = NewBodyShader;
		Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = NewBodyShader;
		AdjustRimLight(Nemesis.Cosmetic.MyRenderer.materials[0]);
		AdjustRimLight(Nemesis.Cosmetic.MyRenderer.materials[1]);
		AdjustRimLight(Nemesis.Cosmetic.MyRenderer.materials[2]);
		AdjustRimLight(Nemesis.NemesisHair.GetComponent<Renderer>().material);
	}

	public void UpdateObscurance()
	{
		if (!DoNothing)
		{
			Obscurance.enabled = !OptionGlobals.DisableObscurance;
		}
	}

	public void AdjustRimLight(Material mat)
	{
		if (!DoNothing)
		{
			mat.SetFloat("_RimLightIntensity", 5f);
			mat.SetFloat("_RimCrisp", 0.5f);
			mat.SetFloat("_RimAdditive", 0.5f);
		}
	}

	public void UpdateEightiesEffects()
	{
		EightiesEffects.useStaticNoise = !OptionGlobals.DisableStatic;
		EightiesEffects.useDisplacementWaves = !OptionGlobals.DisableDisplacement;
		EightiesEffects.useChromaticAberration = !OptionGlobals.DisableAbberation;
		EightiesEffects.useVignette = !OptionGlobals.DisableVignette;
		EightiesEffects.useRadialDistortion = !OptionGlobals.DisableDistortion;
		EightiesEffects.useScanlines = !OptionGlobals.DisableScanlines;
		EightiesEffects.useBottomNoise = !OptionGlobals.DisableNoise;
		EightiesEffects.useBottomStretch = !OptionGlobals.DisableNoise;
		if (Tint != null)
		{
			Tint.enabled = !OptionGlobals.DisableTint;
		}
	}
}
