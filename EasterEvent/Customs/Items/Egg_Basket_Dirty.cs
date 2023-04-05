using KitchenData;
using KitchenLib.Customs;
using System.Security.Policy;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Egg_Basket_Dirty : CustomItem
	{
		public override string UniqueNameID => "Egg_Basket_Dirty";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Egg_Basket_Dirty");
		public override Item DisposesTo => RefVars.Egg_Basket;
	}
}
