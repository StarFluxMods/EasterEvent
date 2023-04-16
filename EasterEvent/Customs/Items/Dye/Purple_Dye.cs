using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenData;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Purple_Dye : CustomItem
	{
		public override string UniqueNameID => "Purple_Dye";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Purple");
		public override Appliance DedicatedProvider => RefVars.Purple_Dye_Provider;
		public override string ColourBlindTag => "P";
	}
}
