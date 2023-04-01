using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Easter_Egg_1 : CustomItemGroup
	{
		public override string UniqueNameID => "Easter_Egg_1";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Easter_Egg_1");

		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
				Result = (Item)GDOUtils.GetCustomGameDataObject<Jumbo_Easter_Egg_1>().GameDataObject,
				Duration = 1,
				IsBad = false,
				RequiresWrapper = false
			}
		};

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
					(Item)GDOUtils.GetCustomGameDataObject<Purple_Dye>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<Yellow_Dye>().GameDataObject
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
					Item = (Item)GDOUtils.GetCustomGameDataObject<Purple_Dye>().GameDataObject,
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Pattern_1/Purple"),
					DrawAll = true
				},
				new ItemGroupView.ComponentGroup
				{
					Item = (Item)GDOUtils.GetCustomGameDataObject<Yellow_Dye>().GameDataObject,
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Pattern_1/Yellow"),
					DrawAll = true
				}
			};
		}
	}
}
