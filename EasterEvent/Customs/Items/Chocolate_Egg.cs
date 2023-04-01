using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Chocolate_Egg : CustomItemGroup
	{
		public override string UniqueNameID => "Chocolate_Egg";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Chocolate_Egg");

		public override bool AutoCollapsing => true;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
		{
			new ItemGroup.ItemSet
			{
				IsMandatory = true,
				Items = new List<Item>
				{
					(Item)GDOUtils.GetCustomGameDataObject<Chocolate_Egg_Half>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<Chocolate_Egg_Half>().GameDataObject
				},
				Max = 2,
				Min = 2
			}
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
		}
	}
}
