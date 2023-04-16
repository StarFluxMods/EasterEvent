using ApplianceLib.Api;
using EasterEvent.Customs;
using EasterEvent.Customs.Appliances;
using EasterEvent.Customs.Appliances.Providers;
using EasterEvent.Customs.Processes;
using EasterEvent.Customs.Settings;
using KitchenData;
using KitchenLib;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using EasterEvent.Customs.Cards;
using UnityEngine.TextCore;
using TMPro;

namespace EasterEvent
{
	public class Main : BaseMod
	{
		public const string MOD_ID = "easterevent";
		public const string MOD_NAME = "Easter Event";
		public const string MOD_AUTHOR = "StarFluxMods";
		public const string MOD_VERSION = "0.1.0";
		public const string MOD_BETA_VERSION = "";
		public const string MOD_COMPATIBLE_VERSIONS = ">=1.1.4";

		public static AssetBundle bundle;

		public Main() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_BETA_VERSION, MOD_COMPATIBLE_VERSIONS, Assembly.GetExecutingAssembly()) { }

		public override void OnPostActivate(Mod mod)
		{
			bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

			bundle.LoadAllAssets<Texture2D>();
			bundle.LoadAllAssets<Sprite>();
			var spriteAsset = bundle.LoadAsset<TMP_SpriteAsset>("ProcessIcons"); // use the name of your sprite ASSET here
			TMP_Settings.defaultSpriteAsset.fallbackSpriteAssets.Add(spriteAsset);
			spriteAsset.material = GameObject.Instantiate(TMP_Settings.defaultSpriteAsset.material);
			spriteAsset.material.mainTexture = bundle.LoadAsset<Texture2D>("ProcessIcons_Tex"); // use the name of your sprite TEXTURE here

			AddGameDataObject<Chocolate_Egg_Half>();
			AddGameDataObject<Chocolate_Egg>();

			AddGameDataObject<Blue_Dye_Provider>();
			AddGameDataObject<Blue_Dye>();
			AddGameDataObject<Green_Dye_Provider>();
			AddGameDataObject<Green_Dye>();
			AddGameDataObject<Purple_Dye_Provider>();
			AddGameDataObject<Purple_Dye>();
			AddGameDataObject<Red_Dye_Provider>();
			AddGameDataObject<Red_Dye>();
			AddGameDataObject<White_Dye_Provider>();
			AddGameDataObject<White_Dye>();
			AddGameDataObject<Yellow_Dye_Provider>();
			AddGameDataObject<Yellow_Dye>();

			AddGameDataObject<Egg_Chonkifier>();

			AddGameDataObject<Chonkify>();
			AddGameDataObject<Freeze>();

			AddGameDataObject<Egg_Basket>();
			AddGameDataObject<Basket_Stack>();

			AddGameDataObject<Chocolate_Mold_Empty>();
			AddGameDataObject<Chocolate_Mold_Raw>();
			AddGameDataObject<Chocolate_Mold_Frozen>();
			AddGameDataObject<Chocolate_Mold_Provider>();

			AddGameDataObject<Red_White>();
			AddGameDataObject<Red_Blue>();
			AddGameDataObject<Blue_White>();
			AddGameDataObject<Green_Blue>();
			AddGameDataObject<Green_White>();
			AddGameDataObject<Green_Red>();
			AddGameDataObject<Purple_White>();
			AddGameDataObject<Purple_Green>();
			AddGameDataObject<Purple_Yellow>();
			AddGameDataObject<Egg_Basket_Dirty>();
			AddGameDataObject<Easter_Setting>();

			AddGameDataObject<Grass_Easter>();

			AddGameDataObject<Purple_Yellow_Bush>();
			AddGameDataObject<Red_White_Bush>();
			AddGameDataObject<White_Green_Bush>();

			AddGameDataObject<Easter_Eggs_Dish>();
			AddGameDataObject<Egg_Shell>();
			
			AddGameDataObject<EasterCard>();
			AddGameDataObject<Jumbo_Red_White>();
			AddGameDataObject<Jumbo_Green_White>();
			AddGameDataObject<Jumbo_Purple_Yellow>();
			
			AddGameDataObject<Easter_Eggs_Tier2>();
			AddGameDataObject<Easter_Eggs_Tier3>();
			AddGameDataObject<Jumbo_Eggs>();
			
			AddGameDataObject<Uncut_Hot_Cross_Bun>();
			AddGameDataObject<Cut_Hot_Cross_Bun>();
			AddGameDataObject<Heated_Hot_Cross_Bun>();
			AddGameDataObject<Buttered_Hot_Cross_Bun>();
			AddGameDataObject<HotCrossBuns>();
			AddGameDataObject<HotCrossBunProvider>();

			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Red_White>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Red_Blue>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Blue_White>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Green_Blue>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Green_White>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Green_Red>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Purple_White>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Purple_Green>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Purple_Yellow>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Jumbo_Red_White>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Jumbo_Green_White>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Jumbo_Purple_Yellow>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Egg_Shell>().ID);

			AssetReference.ThematicSetting = GDOUtils.GetCustomGameDataObject<Easter_Setting>().ID;
			AssetReference.ThematicLayout = LayoutProfileReferences.ExtendedLayout;

			JumboTypes.Add(GDOUtils.GetCustomGameDataObject<Jumbo_Red_White>().ID);
			JumboTypes.Add(GDOUtils.GetCustomGameDataObject<Jumbo_Green_White>().ID);
			JumboTypes.Add(GDOUtils.GetCustomGameDataObject<Jumbo_Purple_Yellow>().ID);

		}

		public static List<int> JumboTypes = new List<int>();

		public override void OnInitialise()
		{
			GameObject go = null;
			foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
			{
				if (gameObject.name == "Customer")
				{
					if (gameObject.transform.childCount == 4)
					{
						go = gameObject;
						break;
					}
				}
			}
			Transform tra = go.transform.GetChild(1);
			ChildCustomerView view = go.AddComponent<ChildCustomerView>();
			view.transform = tra;

			
			GameData.Main.Get<Appliance>(ApplianceReferences.Freezer).Processes.Add(
			new Appliance.ApplianceProcesses()
			{
				Process = RefVars.Freeze,
				Speed = 1,
				IsAutomatic = true
			});

			GameData.Main.Get<Unlock>(UnlockCardReferences.AllYouCanEat).BlockedBy.Add(RefVars.EasterCard);
			GameData.Main.Get<Unlock>(UnlockCardReferences.AllYouCanEatIncrease).BlockedBy.Add(RefVars.EasterCard);
			GameData.Main.Get<Unlock>(UnlockCardReferences.ChangeOrdersAfterOrdering).BlockedBy.Add(RefVars.EasterCard);

			GameData.Main.Get<PlayerCosmetic>(PlayerCosmeticReferences.BunnyEarHat).CustomerSettings.Add((RestaurantSetting)GDOUtils.GetCustomGameDataObject<Easter_Setting>().GameDataObject);
			GameData.Main.Get<PlayerCosmetic>(PlayerCosmeticReferences.BunnyHat).CustomerSettings.Add((RestaurantSetting)GDOUtils.GetCustomGameDataObject<Easter_Setting>().GameDataObject);

		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void LogInfo(string message)
		{
			Debug.Log($"[{MOD_NAME}] " + message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void LogWarning(string message)
		{
			Debug.LogWarning($"[{MOD_NAME}] " + message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void LogError(string message)
		{
			Debug.LogError($"[{MOD_NAME}] " + message);
		}

		private void LogFields(Type type, object instance, int indent, ref List<string> log)
		{
			if (indent >= 10)
			{
				return;
			}
			string indentString = new string('\t', indent);

			//if type is a list or array, iterate through the elements
			if (type.IsArray)
			{
				Array array = (Array)instance;
				for (int i = 0; i < array.Length; i++)
				{
					Main.LogInfo($"{indentString}{array.GetType().GetElementType()}:");
					log.Add($"{indentString}{array.GetType().GetElementType()}:");
					LogFields(array.GetType().GetElementType(), array.GetValue(i), indent + 1, ref log);
				}
			}
			else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
			{
				IList list = (IList)instance;
				for (int i = 0; i < list.Count; i++)
				{
					Main.LogInfo($"{indentString}{list[i].GetType()}:");
					log.Add($"{indentString}{list[i].GetType()}:");
					LogFields(list[i].GetType(), list[i], indent + 1, ref log);
				}
			}
			else
			{
				//otherwise, iterate through the fields

				foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
				{
					object value = field.GetValue(instance);
					if (value == null)
					{
						Main.LogInfo($"{indentString}{field.Name} = null");
						log.Add($"{indentString}{field.Name} = null");
					}
					else if (value.GetType().IsPrimitive || value is string)
					{
						Main.LogInfo($"{indentString}{field.Name} = {value}");
						log.Add($"{indentString}{field.Name} = {value}");
					}
					else
					{
						Main.LogInfo($"{indentString}{field.Name} = {value.GetType().Name}");
						log.Add($"{indentString}{field.Name} = {value.GetType().Name}");
						LogFields(value.GetType(), value, indent + 1, ref log);
					}

				}

			}

		}
	}
}