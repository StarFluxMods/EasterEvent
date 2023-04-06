using EasterEvent.Customs;
using Kitchen;
using KitchenData;
using KitchenLib.Utils;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;
using HarmonyLib;
using System.Deployment.Internal.Isolation;
using Unity.Collections;

namespace EasterEvent.Systems
{
	public class x : GameSystemBase, IModSystem
	{
		EntityQuery y;
		public override void Initialise()
		{
			y = GetEntityQuery(typeof(CSettingSelector));
		}
		public override void OnUpdate()
		{
			var ents = y.ToEntityArray(Allocator.Temp);

			for (int i = 0; i < ents.Length; i++)
			{
				if (Require(ents[i], out CSettingSelector selector))
				{
					selector.SettingID = 82131534
;
					EntityManager.SetComponentData(ents[i], selector);
					base.Set<HandleLayoutRequests.SLayoutRequest>(default(HandleLayoutRequests.SLayoutRequest));
				}
			}
		}
	}
}
