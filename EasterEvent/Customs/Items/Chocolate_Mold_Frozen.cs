using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Chocolate_Mold_Frozen : CustomItemGroup
	{
		public override string UniqueNameID => "Chocolate_Mold_Frozen";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Chocolate_Mold_Frozen");
		public override Item SplitSubItem => RefVars.Chocolate_Egg_Half;
		public override int SplitCount => 9;
		public override bool IsIndisposable => true;
		public override List<Item> SplitDepletedItems => new List<Item>
		{
			RefVars.Chocolate_Mold_Empty
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Item item = (Item)gameDataObject;
			ObjectsSplittableView view = item.Prefab.AddComponent<ObjectsSplittableView>();

			FieldInfo info = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
			List<GameObject> list = new List<GameObject>();
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Chocolate_Half_Egg_Frozen_1"));
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Chocolate_Half_Egg_Frozen_2"));
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Chocolate_Half_Egg_Frozen_3"));
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Chocolate_Half_Egg_Frozen_4"));
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Chocolate_Half_Egg_Frozen_5"));
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Chocolate_Half_Egg_Frozen_6"));
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Chocolate_Half_Egg_Frozen_7"));
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Chocolate_Half_Egg_Frozen_8"));
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Chocolate_Half_Egg_Frozen_9"));
			info.SetValue(view, list);
		}
	}
}
