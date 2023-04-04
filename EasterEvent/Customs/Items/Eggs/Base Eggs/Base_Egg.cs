using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEvent.Customs
{
	public abstract class Base_Egg : CustomItemGroup
	{
		public abstract Item Color1 { get; }
		public abstract Item Color2 { get; }
		public abstract string _Color1 { get; }
		public abstract string _Color2 { get; }
		public override string UniqueNameID => $"{_Color1}_{_Color2}";
		
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>($"{_Color1}_{_Color2}");

		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
		{
			new ItemGroup.ItemSet
			{
				IsMandatory = true,
				Min = 1,
				Max = 1,
				Items = new List<Item>
				{
					RefVars.Chocolate_Egg
				}
			},
			new ItemGroup.ItemSet
			{
				Min = 2,
				Max = 2,
				Items = new List<Item>
				{
					Color1,
					Color2
				}
			}
		};
		

		public override void OnRegister(ItemGroup gameDataObject)
		{
			ItemGroupView view = gameDataObject.Prefab.GetComponent<ItemGroupView>();

			view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
			{
				new ItemGroupView.ComponentGroup
				{
					Item = Color1,
					GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Base"),
					DrawAll = true
				},

				new ItemGroupView.ComponentGroup
				{
					Item = Color2,
					GameObject = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "Details"),
					DrawAll = true
				}
			};
		}
	}
}
