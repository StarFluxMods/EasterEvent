using EasterEvent.Customs;
using KitchenLib;
using KitchenMods;
using System.Linq;
using System.Reflection;
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
			AddGameDataObject<Red_Dye_Provider>();
			AddGameDataObject<Red_Dye>();
			AddGameDataObject<Blue_Dye_Provider>();
			AddGameDataObject<Blue_Dye>();
			AddGameDataObject<Chocolate_Egg_Half>();
			AddGameDataObject<Easter_Egg>();
		}
	}
}