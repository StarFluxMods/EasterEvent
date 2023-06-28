using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;
using EasterEvent.Customs.Processes;
using UnityEngine.PlayerLoop;

namespace EasterEvent.Customs
{
	public class Egg_Chonkifier : CustomAppliance
	{
		public override string UniqueNameID => "Egg_Chonkifier";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Chonkifier");
		public override PriceTier PriceTier => PriceTier.Medium;
		public override bool IsPurchasable => true;
		public override bool SellOnlyAsDuplicate => true;
		public override ShoppingTags ShoppingTags => ShoppingTags.Automation;

		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			new CItemHolder()
		};

		public override List<(KitchenData.Locale, ApplianceInfo)> InfoList => new List<(KitchenData.Locale, ApplianceInfo)>
		{
			(
				KitchenData.Locale.English,
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

			MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "Chonkifier/Arm Hole", MaterialUtils.GetMaterialArray("Connector", "Connector"));
			MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "Chonkifier/Lever", MaterialUtils.GetMaterialArray("Rings", "Pipe"));
			MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "Chonkifier/Lever Thing", MaterialUtils.GetMaterialArray("Connector", "Hob Black"));
			MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "Chonkifier/Lower Pipe", MaterialUtils.GetMaterialArray("Pipe"));
			MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "Chonkifier/Upper Pipe", MaterialUtils.GetMaterialArray("Pipe"));
			MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "Chonkifier/Zap", MaterialUtils.GetMaterialArray("Bean"));
			MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "Chonkifier/Zap Blast", MaterialUtils.GetMaterialArray("Bean"));
			MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "Chonkifier/Zapper", MaterialUtils.GetMaterialArray("Connector", "Pipe", "Rings"));
		}
	}
}
