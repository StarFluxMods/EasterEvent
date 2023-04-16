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
	public class Heated_Hot_Cross_Bun : CustomItem
	{
		public override string UniqueNameID => "Heated_Hot_Cross_Bun";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("HeatedHotCrossBun");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
	}
}
