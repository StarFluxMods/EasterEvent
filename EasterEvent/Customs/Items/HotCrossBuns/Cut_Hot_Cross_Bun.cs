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
	public class Cut_Hot_Cross_Bun : CustomItem
	{
		public override string UniqueNameID => "Cut_Hot_Cross_Bun";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CutHotCrossBun");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				Duration = 1,
				IsBad = false,
				Process = RefVars.Cook,
				RequiresWrapper = false,
				Result = RefVars.Heated_Hot_Cross_Bun
			}
		};
	}
}
