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
	public class HotCrossBunProvider : CustomAppliance
	{
		public override string UniqueNameID => "HotCrossBunProvider";
		public override int BaseGameDataObjectID => ApplianceReferences.SourceApple;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>($"Provider - Hot Cross Buns");
		public override PriceTier PriceTier => PriceTier.Medium;
		public override bool SellOnlyAsDuplicate => true;
		public override bool IsPurchasable => true;
		public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
		public override List<(KitchenData.Locale, ApplianceInfo)> InfoList => new List<(KitchenData.Locale, ApplianceInfo)>
		{
			(
				KitchenData.Locale.English,
				new ApplianceInfo
				{
					Name = $"Hot Cross Buns",
					Description = $"Provides Hot Cross Buns"
				}
			)
		};
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			KitchenPropertiesUtils.GetUnlimitedCItemProvider(RefVars.Uncut_Hot_Cross_Bun.ID)
		};

		public override void OnRegister(Appliance gameDataObject)
		{
		}
	}
}
