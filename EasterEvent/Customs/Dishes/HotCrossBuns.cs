using KitchenData;
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
	public class HotCrossBuns : CustomDish
	{
		//CustomGameDataObject
		public override string UniqueNameID => "HotCrossBuns";
		public override int BaseGameDataObjectID => DishReferences.BurgerBase;

		//CustomUnlock
		public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
		public override bool IsUnlockable => true;
		public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
		public override CardType CardType => CardType.Default;
		public override int MinimumFranchiseTier => 0;
		public override bool IsSpecificFranchiseTier => false;
		public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
		public override float SelectionBias => 0;
		public override List<Unlock> HardcodedRequirements => new List<Unlock>
		{
			RefVars.Easter_Eggs_Dish
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
		public override DishType Type => DishType.Starter;

		public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
		{
			RefVars.Uncut_Hot_Cross_Bun,
			RefVars.Butter
		};


		public override HashSet<Process> RequiredProcesses => new HashSet<Process>
		{
			RefVars.Cook,
			RefVars.Chop,
		};

		public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
		{
			new Dish.MenuItem
			{
				Item = RefVars.Buttered_Hot_Cross_Bun,
				Phase = MenuPhase.Starter,
				Weight = 1,
				DynamicMenuType = DynamicMenuType.Static,
				DynamicMenuIngredient = null
			}
		};
		public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
		{
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Buttered_Hot_Cross_Bun,
				Ingredient = RefVars.Uncut_Hot_Cross_Bun
			},
			new Dish.IngredientUnlock
			{
				MenuItem = RefVars.Buttered_Hot_Cross_Bun,
				Ingredient = RefVars.Butter
			},
		};
		public override Dictionary<KitchenData.Locale, string> Recipe => new Dictionary<KitchenData.Locale, string>
		{
			{ KitchenData.Locale.English, "Cut, Warm, and Butter!" }
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Dish dish = (Dish)gameDataObject;
			LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
			FieldInfo dictionary = ReflectionUtils.GetField<LocalisationObject<UnlockInfo>>("Dictionary");
			Dictionary<KitchenData.Locale, UnlockInfo> dict = new Dictionary<KitchenData.Locale, UnlockInfo>();
			dict.Add(KitchenData.Locale.English, new UnlockInfo
			{
				Name = "Hot Cross Buns",
				Description = "Adds Hot Cross Buns as a Starter",
			});
			dictionary.SetValue(info, dict);
			dish.Info = info;
		}
	}
}
