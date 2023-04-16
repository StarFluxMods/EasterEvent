using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EasterEvent.Customs.Appliances
{
	public class Chocolate_Mold_Provider : CustomAppliance
	{
		public override string UniqueNameID => "Chocolate_Mold_Provider";
		public override int BaseGameDataObjectID => ApplianceReferences.Countertop;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Source_Chocolate_Mold");
		public override PriceTier PriceTier => PriceTier.Medium;
		public override bool SellOnlyAsDuplicate => true;
		public override bool IsPurchasable => true;
		public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;

		public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
		{
			(
				Locale.English,
				new ApplianceInfo
				{
					Name = "Chocolate Mold",
					Description = "Provides Chocolate Mold"
				}
			)
		};
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			new CItemHolder(),
			new CItemProvider
			{
				Available = 1,
				Maximum = 1,
				Item = RefVars.Chocolate_Mold_Empty.ID,
				AutoPlaceOnHolder = true
			}
		};

		public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses>
		{
			new Appliance.ApplianceProcesses
			{
				Process = RefVars.Chop,
				IsAutomatic = false,
				Speed = 0.75f,
				Validity = ProcessValidity.Generic
			},
			new Appliance.ApplianceProcesses
			{
				Process = RefVars.Knead,
				IsAutomatic = false,
				Speed = 0.75f,
				Validity = ProcessValidity.Generic
			}
		};

		public override void OnRegister(Appliance gameDataObject)
		{
			GameObject HoldPoint = GameObjectUtils.GetChild(gameDataObject.Prefab, "Block/HoldPoint");
			HoldPointContainer holdPointContainer = gameDataObject.Prefab.AddComponent<HoldPointContainer>();
			holdPointContainer.HoldPoint = HoldPoint.transform;

			LimitedItemSourceView view = gameDataObject.Prefab.AddComponent<LimitedItemSourceView>();
			view.DisplayedItems = 2;
			view.Items = new List<GameObject>
			{
				GameObjectUtils.GetChild(gameDataObject.Prefab, "Block/HoldPoint/Chocolate_Mold_Empty")
			};
		}
	}
}
