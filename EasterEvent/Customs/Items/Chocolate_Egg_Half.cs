using KitchenData;
using KitchenLib.Customs;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Chocolate_Egg_Half : CustomItem
	{
		public override string UniqueNameID => "Chocolate_Egg_Half";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Chocolate_Half_Egg");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
	}
}
