using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	public class SFXController : MonoBehaviour
	{
		public enum Sounds
		{
			Countdown,
			MenuBack,
			MenuConfirm,
			ClockTick,
			DoorBell,
			GameFail,
			GameSuccess,
			Plate,
			PageTurn,
			MenuSelect,
			MaleCustomerGreet,
			MaleCustomerThank,
			MaleCustomerLeave,
			FemaleCustomerGreet,
			FemaleCustomerThank,
			FemaleCustomerLeave,
			MenuOpen
		}

		private static SFXController instance;

		[Reorderable]
		public SoundEmitters emitters;

		public static SFXController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Object.FindObjectOfType<SFXController>();
				}
				return instance;
			}
		}

		private void Awake()
		{
			if (Instance != this)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		public static void PlaySound(Sounds sound)
		{
			SoundEmitter emitter = Instance.GetEmitter(sound);
			AudioSource source = emitter.GetSource();
			if (!source.isPlaying || emitter.interupt)
			{
				source.clip = Instance.GetRandomClip(emitter);
				source.Play();
			}
		}

		private SoundEmitter GetEmitter(Sounds sound)
		{
			foreach (SoundEmitter emitter in emitters)
			{
				if (emitter.sound == sound)
				{
					return emitter;
				}
			}
			Debug.Log($"There is no sound emitter created for {sound}", this);
			return null;
		}

		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}
	}
}
