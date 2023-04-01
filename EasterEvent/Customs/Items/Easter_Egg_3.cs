using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Easter_Egg_3 : CustomItemGroup
	{
		public override string UniqueNameID => "Easter_Egg_3";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Easter_Egg_3");

		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
		{
			new ItemGroup.ItemSet
			{
				IsMandatory = true,
				Items = new List<Item>
				{
					(Item)GDOUtils.GetCustomGameDataObject<Chocolate_Egg>().GameDataObject
				},
				Max = 1,
				Min = 1
			},
			new ItemGroup.ItemSet
			{
				IsMandatory = false,
				Items = new List<Item>
				{
					(Item)GDOUtils.GetCustomGameDataObject<Red_Dye>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<Blue_Dye>().GameDataObject
				},
				Max = 2,
				Min = 2
			}
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			ItemGroup item = (ItemGroup)gameDataObject;
			ItemGroupView view = item.Prefab.GetComponent<ItemGroupView>();

			view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
			{
				new ItemGroupView.ComponentGroup
				{
					Item = (Item)GDOUtils.GetCustomGameDataObject<Blue_Dye>().GameDataObject,
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Pattern_3/Blue"),
					DrawAll = true
				},
				new ItemGroupView.ComponentGroup
				{
					Item = (Item)GDOUtils.GetCustomGameDataObject<Red_Dye>().GameDataObject,
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Pattern_3/Red"),
					DrawAll = true
				}
			};
		}
	}
}
