﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Easter_Eggs_Tier3 : CustomDish
	{
		//CustomGameDataObject
		public override string UniqueNameID => "Easter_Eggs_Tier3";
		public override int BaseGameDataObjectID => DishReferences.BurgerBase;

		//CustomUnlock
		public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
		public override bool IsUnlockable => true;
		public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
		public override CardType CardType => CardType.Default;
		public override int MinimumFranchiseTier => 0;
		public override bool IsSpecificFranchiseTier => false;
		public override DishCustomerChange CustomerMultiplier => DishCustomerChange.None;
		public override float SelectionBias => 0;
		public override List<Unlock> HardcodedRequirements => new List<Unlock>
		{
			RefVars.Easter_Eggs_Tier2
		};
		public override List<Unlock> HardcodedBlockers => new List<Unlock> { };
		public override GameObject IconPrefab => Main.bundle.LoadAsset<GameObject>("DishIcon");

		public override List<string> StartingNameSet => new List<string>
		{
			"Fresh outta clucks",
			"Chick me out!",
			"You're one funny chick",
			"You're a good egg",
			"What an egg-citing day",
			"Are you an Easter eggs-pert?",
			"Bunny, I’m home!",
			"Happy Eggs-ter!",
			"Hey there, hop stuff"
		};

		//CustomDish
		public override string AchievementName => "";
		public override DishType Type => DishType.Main;

		public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
		{
			RefVars.Purple_Dye,
			RefVars.White_Dye,
			RefVars.Yellow_Dye,
			RefVars.Green_Dye,
			RefVars.Chocolate,
			RefVars.Chocolate_Mold_Empty
		};


		public override HashSet<Process> RequiredProcesses => new HashSet<Process>
		{
			RefVars.Cook,
			RefVars.Freeze
		};

		public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
		{
			new Dish.MenuItem
			{
				Item = RefVars.Purple_Green,
				Phase = MenuPhase.Main,
				Weight = 1,
				DynamicMenuType = DynamicMenuType.Static,
				DynamicMenuIngredient = null
			},
			new Dish.MenuItem
			{
				Item = RefVars.Purple_White,
				Phase = MenuPhase.Main,
				Weight = 1,
				DynamicMenuType = DynamicMenuType.Static,
				DynamicMenuIngredient = null
			},
			new Dish.MenuItem
			{
				Item = RefVars.Purple_Yellow,
				Phase = MenuPhase.Main,
				Weight = 1,
				DynamicMenuType = DynamicMenuType.Static,
				DynamicMenuIngredient = null
			}
		};
		public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
		{
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_Green,
				Ingredient = RefVars.Purple_Dye
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_Green,
				Ingredient = RefVars.Green_Dye
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_Green,
				Ingredient = RefVars.Chocolate
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_White,
				Ingredient = RefVars.Purple_Dye
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_White,
				Ingredient = RefVars.White_Dye
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_White,
				Ingredient = RefVars.Chocolate
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_Yellow,
				Ingredient = RefVars.Purple_Dye
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_Yellow,
				Ingredient = RefVars.Yellow_Dye
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_Yellow,
				Ingredient = RefVars.Chocolate
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_Green,
				Ingredient = RefVars.Egg_Basket
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_White,
				Ingredient = RefVars.Egg_Basket
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Purple_Yellow,
				Ingredient = RefVars.Egg_Basket
			}
		};
		public override Dictionary<KitchenData.Locale, string> Recipe => new Dictionary<KitchenData.Locale, string>
		{
			{ KitchenData.Locale.English, "Melt Chocolate, Mold and Freeze. Add paint ready to serve!" }
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Dish dish = (Dish)gameDataObject;
			LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
			FieldInfo dictionary = ReflectionUtils.GetField<LocalisationObject<UnlockInfo>>("Dictionary");
			Dictionary<KitchenData.Locale, UnlockInfo> dict = new Dictionary<KitchenData.Locale, UnlockInfo>();
			dict.Add(KitchenData.Locale.English, new UnlockInfo
			{
				Name = "Purple Dye",
				Description = "Adds Purple Dye as a new color for Eggs",
				FlavourText = "Is that egg breathing?"
			});
			dictionary.SetValue(info, dict);
			dish.Info = info;
		}
	}
}
