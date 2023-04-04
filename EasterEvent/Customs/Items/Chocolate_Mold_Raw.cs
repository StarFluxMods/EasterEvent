using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Chocolate_Mold_Raw : CustomItemGroup
	{
		public override string UniqueNameID => "Chocolate_Mold_Raw";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Chocolate_Mold_Raw");

		public override bool AutoCollapsing => true;
		public override bool IsIndisposable => true;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
		{
			new ItemGroup.ItemSet
			{
				IsMandatory = true,
				Items = new List<Item>
				{
					RefVars.Chocolate_Sauce,
					RefVars.Chocolate_Mold_Empty,
				},
				Max = 2,
				Min = 2
			}
		};

		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				Process = RefVars.Freeze,
				Result = RefVars.Chocolate_Mold_Frozen,
				Duration = 2,
				IsBad = false,
				RequiresWrapper = false
			}
		};
	}
}
