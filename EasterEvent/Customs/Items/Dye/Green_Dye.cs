using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenData;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Green_Dye : CustomItem
	{
		public override string UniqueNameID => "Green_Dye";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Green");
		public override Appliance DedicatedProvider => RefVars.Green_Dye_Provider;
	}
}
