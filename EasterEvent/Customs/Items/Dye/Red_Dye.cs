using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenData;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Red_Dye : CustomItem
	{
		public override string UniqueNameID => "Red_Dye";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Red");
		public override Appliance DedicatedProvider => RefVars.Red_Dye_Provider;
		public override string ColourBlindTag => "R";
	}
}
