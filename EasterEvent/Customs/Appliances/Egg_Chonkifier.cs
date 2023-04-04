using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;
using EasterEvent.Customs.Processes;

namespace EasterEvent.Customs
{
	public class Egg_Chonkifier : CustomAppliance
	{
		public override string UniqueNameID => "Egg_Chonkifier";
		public override int BaseGameDataObjectID => ApplianceReferences.Hob;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Droppable_Counter");
		public override PriceTier PriceTier => PriceTier.Medium;

		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			new CItemHolder()
		};

		public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
		{
			(
				Locale.English,
				new ApplianceInfo
				{
					Name = "Egg Chonkifier",
					Description = "Chonkifies Easter Eggs"
				}
			)
		};

		public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses>()
		{
            new Appliance.ApplianceProcesses()
			{
				Process = RefVars.Chonkify,
				Speed = 1,
                IsAutomatic = true
            }
        };

		public override void OnRegister(Appliance gameDataObject)
		{
			GameObject HoldPoint = GameObjectUtils.GetChild(gameDataObject.Prefab, "HoldPoint");
			
			ApplianceProcessView view = gameDataObject.Prefab.AddComponent<ApplianceProcessView>();
			HoldPointContainer holdPointContainer = gameDataObject.Prefab.AddComponent<HoldPointContainer>();

			holdPointContainer.HoldPoint = HoldPoint.transform;
			view.Animator = gameDataObject.Prefab.GetComponent<Animator>();
		}
	}
}
