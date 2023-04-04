using KitchenData;
using KitchenLib.Customs;
using System.Security.Policy;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Egg_Basket : CustomItem
	{
		public override string UniqueNameID => "Egg_Basket";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Egg_Basket");
		public override Appliance DedicatedProvider => RefVars.Basket_Stack;
		public override bool IsIndisposable => true;
	}
}
