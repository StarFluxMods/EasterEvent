using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Chocolate_Egg : CustomItemGroup
	{
		public override string UniqueNameID => "Chocolate_Egg";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Chocolate_Egg");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

		public override bool AutoCollapsing => true;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
		{
			new ItemGroup.ItemSet
			{
				IsMandatory = true,
				Items = new List<Item>
				{
					RefVars.Chocolate_Egg_Half,
					RefVars.Chocolate_Egg_Half,
				},
				Max = 2,
				Min = 2
			}
		};
	}
}
