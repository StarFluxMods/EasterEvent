using EasterEvent.Customs.Settings;
using Kitchen;
using KitchenLib.Utils;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using Unity.Entities;

namespace EasterEvent.Customs
{
    [UpdateBefore(typeof(GrantUpgrades))]
	public class ProvideEasterSetting : FranchiseFirstFrameSystem, IModSystem
	{
		public static List<int> MenuOptions = new List<int>
		{
			GDOUtils.GetCustomGameDataObject<Easter_Setting>().ID
		};
		private EntityQuery EntitiesToActOn;
		public override void Initialise()
		{
			base.Initialise();
			EntitiesToActOn = GetEntityQuery(typeof(CSettingUpgrade));
		}
		public override void OnUpdate()
		{
			foreach (int id in MenuOptions)
			{
				bool found = false;
				using var ents = EntitiesToActOn.ToEntityArray(Allocator.Temp);

				foreach (var ent in ents)
				{
					CSettingUpgrade cUpgrade = EntityManager.GetComponentData<CSettingUpgrade>(ent);
					if (cUpgrade.SettingID == id)
					{
						found = true;
						break;
					}
				}
				if (!found)
				{
					Entity e = EntityManager.CreateEntity(typeof(CSettingUpgrade), typeof(CPersistThroughSceneChanges));
					EntityManager.SetComponentData<CSettingUpgrade>(e, new CSettingUpgrade { SettingID = id });
				}
			}
		}
	}
}
