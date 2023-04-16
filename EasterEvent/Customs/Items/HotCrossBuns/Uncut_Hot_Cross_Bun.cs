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
	public class Uncut_Hot_Cross_Bun : CustomItem
	{
		public override string UniqueNameID => "Uncut_Hot_Cross_Bun";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("UncutHotCrossBun");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
		public override Appliance DedicatedProvider => RefVars.HotCrossBunProvider;
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				Duration = 1,
				IsBad = false,
				Process = RefVars.Chop,
				RequiresWrapper = false,
				Result = RefVars.Cut_Hot_Cross_Bun
			}
		};
	}
}
