using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	public class FlipBook : MonoBehaviour
	{
		private static FlipBook instance;

		public List<FlipBookPage> flipBookPages;

		private int curPage;

		private bool canGoBack;

		private bool stopInputs;

		public static FlipBook Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Object.FindObjectOfType<FlipBook>();
				}
				return instance;
			}
		}

		private void Awake()
		{
			StartCoroutine(OpenBook());
		}

		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			FlipToPage(1);
		}

		private void Update()
		{
			if (!stopInputs && curPage > 1 && Input.GetButtonDown("B") && canGoBack)
			{
				FlipToPage(1);
			}
		}

		public void StopInputs()
		{
			stopInputs = true;
		}

		public void FlipToPage(int page)
		{
			SFXController.PlaySound(SFXController.Sounds.PageTurn);
			StartCoroutine(FlipToPageRoutine(page));
		}

		private IEnumerator FlipToPageRoutine(int page)
		{
			bool flag = curPage < page;
			canGoBack = false;
			if (flag)
			{
				while (curPage < page)
				{
					flipBookPages[curPage++].Transition(flag);
				}
				yield return new WaitForSeconds(0.4f);
				flipBookPages[curPage].ObjectActive();
			}
			else
			{
				flipBookPages[curPage].ObjectActive(toActive: false);
				while (curPage > page)
				{
					flipBookPages[--curPage].Transition(flag);
				}
				yield return new WaitForSeconds(0.6f);
				flipBookPages[curPage].ObjectActive();
			}
			canGoBack = true;
		}
	}
}
