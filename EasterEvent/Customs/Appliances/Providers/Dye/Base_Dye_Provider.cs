using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EasterEvent.Customs
{
	public abstract class Base_Dye_Provider : CustomAppliance
	{
		public abstract Item Dye { get; }
		public abstract string DyeName { get; }
		public override string UniqueNameID => $"{DyeName}_Dye_Provider";
		public override int BaseGameDataObjectID => ApplianceReferences.SourceApple;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>($"{DyeName}_Dye_Station");
		public override PriceTier PriceTier => PriceTier.DecoCheap;
		public override bool SellOnlyAsDuplicate => true;
		public override bool IsPurchasable => true;
		public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
		public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
		{
			(
				Locale.English,
				new ApplianceInfo
				{
					Name = $"{DyeName} Dye",
					Description = $"Provides {DyeName} Dye"
				}
			)
		};
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			KitchenPropertiesUtils.GetUnlimitedCItemProvider(Dye.ID)
		};

		public override void OnRegister(Appliance gameDataObject)
		{
			GameObject gameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Dye_Station/Cup");
			MaterialUtils.ApplyMaterial(gameObject, new Material[] { GetMaterialFromColor(DyeName), MaterialUtils.GetExistingMaterial("Door Glass") });
		}

		private static Material GetMaterialFromColor(string name)
		{
			switch (name)
			{
				case "Blue":
					return MaterialUtils.GetExistingMaterial("Balloon - Blue");
				case "Green":
					return MaterialUtils.GetExistingMaterial("Balloon - Green");
				case "Purple":
					return MaterialUtils.GetExistingMaterial("Clothing Purple");
				case "Red":
					return MaterialUtils.GetExistingMaterial("Balloon - Red");
				case "White":
					return MaterialUtils.GetExistingMaterial("Egg - White");
				case "Yellow":
					return MaterialUtils.GetExistingMaterial("Bamboo Fried");
				default:
					return null;
			}
		}
	}
}
