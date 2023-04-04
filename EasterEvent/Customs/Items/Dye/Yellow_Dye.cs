using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenData;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Yellow_Dye : CustomItem
	{
		public override string UniqueNameID => "Yellow_Dye";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Yellow");
		public override Appliance DedicatedProvider => RefVars.Yellow_Dye_Provider;
	}
}
