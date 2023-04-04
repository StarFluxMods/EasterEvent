using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenData;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class White_Dye : CustomItem
	{
		public override string UniqueNameID => "White_Dye";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("White");
		public override Appliance DedicatedProvider => RefVars.White_Dye_Provider;
	}
}
