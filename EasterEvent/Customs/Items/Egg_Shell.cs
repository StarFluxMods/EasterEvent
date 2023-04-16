using KitchenData;
using KitchenLib.Customs;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Egg_Shell : CustomItem
	{
		public override string UniqueNameID => "Egg_Shell";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Egg_Shell");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
	}
}
