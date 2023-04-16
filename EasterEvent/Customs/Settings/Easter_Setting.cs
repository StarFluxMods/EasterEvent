using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasterEvent.Customs.Cards;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasterEvent.Customs.Settings
{
    public class Easter_Setting : CustomRestaurantSetting
    {
        public override int BaseGameDataObjectID => 2002876295;
        public override string UniqueNameID => "Easter_Setting";
		public override List<IDecorationConfiguration> Decorators => new List<IDecorationConfiguration>
		{
			new EasterDecorator.DecorationsConfiguration
			{
				Scatters = new List<EasterDecorator.DecorationsConfiguration.Scatter>
				{
					new EasterDecorator.DecorationsConfiguration.Scatter
					{
						Probability = 0.15f,
						Appliance = (Appliance)GDOUtils.GetCustomGameDataObject<Purple_Yellow_Bush>().GameDataObject
					},
					new EasterDecorator.DecorationsConfiguration.Scatter
					{
						Probability = 0.15f,
						Appliance = (Appliance)GDOUtils.GetCustomGameDataObject<Red_White_Bush>().GameDataObject
					},
					new EasterDecorator.DecorationsConfiguration.Scatter
					{
						Probability = 0.15f,
						Appliance = (Appliance)GDOUtils.GetCustomGameDataObject<White_Green_Bush>().GameDataObject
					}
				},
				Cobblestone = (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.Cobblestone),
				Fencing = (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.Fencing),
				BorderSpacing = 1,
				Ground = (Appliance)GDOUtils.GetCustomGameDataObject<Grass_Easter>().GameDataObject
			}
		};
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Easter");
		public override Unlock StartingUnlock => (UnlockCard)GDOUtils.GetCustomGameDataObject<EasterCard>().GameDataObject;

        public override List<(Locale, BasicInfo)> InfoList => new List<(Locale, BasicInfo)>
        {
            (
                Locale.English,
                new BasicInfo
                {
                    Name = "Easter",
                    Description = "Easter Setting"
                }
            )
        };

        public override void OnRegister(RestaurantSetting gameDataObject)
        {
            MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "EasterSnowglobe/Base", new Material[] { MaterialUtils.GetExistingMaterial("Lit") });
            MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "EasterSnowglobe/Ground", new Material[] { MaterialUtils.GetCustomMaterial("Easter_Grass") });
            MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "EasterSnowglobe/Small_Bush/Quad_1/Pair_1/Leaf", new Material[] { MaterialUtils.GetCustomMaterial("Easter_Grass") });
        }
    }
}
