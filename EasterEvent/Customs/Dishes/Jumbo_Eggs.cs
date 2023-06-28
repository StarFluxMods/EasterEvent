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
	public class Jumbo_Eggs : CustomDish
	{
		//CustomGameDataObject
		public override string UniqueNameID => "Jumbo_Eggs";
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
			RefVars.Green_Dye,
			RefVars.White_Dye,
			RefVars.Yellow_Dye,
			RefVars.Chocolate,
			RefVars.Chocolate_Mold_Empty,
			RefVars.Egg_Basket
		};


		public override HashSet<Process> RequiredProcesses => new HashSet<Process>
		{
			RefVars.Cook,
			RefVars.Freeze,
			RefVars.Chonkify
		};

		public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
		{
			new Dish.MenuItem
			{
				Item = RefVars.Jumbo_Red_White,
				Phase = MenuPhase.Main,
				Weight = 1,
				DynamicMenuType = DynamicMenuType.Static,
				DynamicMenuIngredient = null
			},
			new Dish.MenuItem
			{
				Item = RefVars.Jumbo_Green_White,
				Phase = MenuPhase.Main,
				Weight = 1,
				DynamicMenuType = DynamicMenuType.Static,
				DynamicMenuIngredient = null
			},
			new Dish.MenuItem
			{
				Item = RefVars.Jumbo_Purple_Yellow,
				Phase = MenuPhase.Main,
				Weight = 1,
				DynamicMenuType = DynamicMenuType.Static,
				DynamicMenuIngredient = null
			}
		};
		public override Dictionary<KitchenData.Locale, string> Recipe => new Dictionary<KitchenData.Locale, string>
		{
			{ KitchenData.Locale.English, "Paint your eggs, and give them a ZAP for growth!" }
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Dish dish = (Dish)gameDataObject;
			LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
			FieldInfo dictionary = ReflectionUtils.GetField<LocalisationObject<UnlockInfo>>("Dictionary");
			Dictionary<KitchenData.Locale, UnlockInfo> dict = new Dictionary<KitchenData.Locale, UnlockInfo>();
			dict.Add(KitchenData.Locale.English, new UnlockInfo
			{
				Name = "Jumbo Eggs",
				Description = "Adds Jumbo Eggs as a new variant for Eggs",
				FlavourText = "Careful! They're heavy"
			});
			dictionary.SetValue(info, dict);
			dish.Info = info;
		}
	}
}
