using ApplianceLib.Api;
using EasterEvent.Customs;
using EasterEvent.Customs.Appliances;
using EasterEvent.Customs.Appliances.Providers;
using EasterEvent.Customs.Processes;
using KitchenData;
using KitchenLib;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

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
			AddGameDataObject<EasterLayout>();

			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Red_White>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Red_Blue>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Blue_White>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Green_Blue>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Green_White>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Green_Red>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Purple_White>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Purple_Green>().ID);
			RestrictedItemTransfers.AllowItem("Egg_Basket", GDOUtils.GetCustomGameDataObject<Purple_Yellow>().ID);
		}

		public override void OnInitialise()
		{
			GameData.Main.Get<Appliance>(ApplianceReferences.Freezer).Processes.Add(
			new Appliance.ApplianceProcesses()
			{
				Process = RefVars.Freeze,
				Speed = 1,
				IsAutomatic = true
			});
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
	}
}