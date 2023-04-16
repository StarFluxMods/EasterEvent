using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Policy;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Egg_Basket : CustomItem
	{
		public override string UniqueNameID => "Egg_Basket";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Egg_Basket_Tray");
		public override Appliance DedicatedProvider => RefVars.Basket_Stack;
		public override bool IsIndisposable => true;
		public override int MaxOrderSharers => 3;

		public override List<IItemProperty> Properties => new List<IItemProperty>
		{
			new CToolStorage
			{
				Capacity = 3
			},
			new CEquippableTool
			{
				CanHoldItems = false
			},
			new CEggBasketRestrictions
			{
				Key = "Egg_Basket"
			}
		};



		public override void OnRegister(Item item)
		{
			List<GameObject> storage = new List<GameObject>
			{
				GameObjectUtils.GetChildObject(item.Prefab, "Egg_1"),
				GameObjectUtils.GetChildObject(item.Prefab, "Egg_2"),
				GameObjectUtils.GetChildObject(item.Prefab, "Egg_3"),
			};
			ItemVariableStorageView obj = item.Prefab.AddComponent<ItemVariableStorageView>();
			obj.Storage = storage;

			
		}
	}
}
