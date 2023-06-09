﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Blue_Dye : CustomItem
	{
		public override string UniqueNameID => "Blue_Dye";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Blue");
		public override Appliance DedicatedProvider => RefVars.Blue_Dye_Provider;
		public override string ColourBlindTag => "B";
	}
}
