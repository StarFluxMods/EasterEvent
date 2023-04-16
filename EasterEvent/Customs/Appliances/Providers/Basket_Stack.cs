using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEvent.Customs.Appliances.Providers
{
    public class Basket_Stack : CustomAppliance
    {
        public override string UniqueNameID => "Basket_Stack";
        //public override int BaseGameDataObjectID => ApplianceReferences.PotStack;
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Basket_Stack");
        public override PriceTier PriceTier => PriceTier.Medium;
		public override bool IsPurchasable => true;
		public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;

		public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (
                Locale.English,
                new ApplianceInfo
                {
                    Name = "Basket Stack",
                    Description = "Provides Egg Baskets"
                }
            )
        };
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemProvider
            {
                Available = 3,
                Maximum = 3,
                Item = RefVars.Egg_Basket.ID
            }
        };

        public override void OnRegister(Appliance gameDataObject)
        {
            LimitedItemSourceView view = gameDataObject.Prefab.AddComponent<LimitedItemSourceView>();
            view.DisplayedItems = 2;
            view.Items = new List<GameObject>
            {
                gameDataObject.Prefab.GetChild("Egg_Basket"),
                gameDataObject.Prefab.GetChild("Egg_Basket (1)"),
                gameDataObject.Prefab.GetChild("Egg_Basket (2)")
            };
        }
    }
}
