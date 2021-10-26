using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sulvic.Unity
{
	public class UnityHelper
	{
		private static List<Action<bool>> GetActions(params GameObject[] objs)
		{
			List<Action<bool>> list = new List<Action<bool>>();
			foreach (GameObject @object in objs)
			{
				list.Add(@object.SetActive);
			}
			return list;
		}

		private static void SetActives(bool active, params GameObject[] objs)
		{
			foreach (Action<bool> action in GetActions(objs))
			{
				action(active);
			}
		}

		public static void Activate(params GameObject[] objs)
		{
			SetActives(active: true, objs);
		}

		public static void Deactivate(params GameObject[] objs)
		{
			SetActives(active: false, objs);
		}
	}
}
