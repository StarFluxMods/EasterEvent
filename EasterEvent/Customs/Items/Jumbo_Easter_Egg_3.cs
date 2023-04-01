using KitchenLib.Customs;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Jumbo_Easter_Egg_3 : CustomItem
	{
		public override string UniqueNameID => "Jumbo_Easter_Egg_3";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Jumbo_Easter_Egg_3");
	}
}
