using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenData;
using KitchenLib.Customs;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Buttered_Hot_Cross_Bun : CustomItemGroup
	{
		public override string UniqueNameID => "Buttered_Hot_Cross_Bun";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("ButteredHotCrossBun");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;	
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
		{
			new ItemGroup.ItemSet
			{
				IsMandatory = false,
				Items = new List<Item>
				{
					RefVars.Heated_Hot_Cross_Bun,
					RefVars.Butter
				},
				Max = 2,
				Min = 2,
				OrderingOnly = false,
				RequiresUnlock = false
			}
		};
	}
}
