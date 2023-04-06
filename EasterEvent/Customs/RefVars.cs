using EasterEvent.Customs.Appliances;
using EasterEvent.Customs.Appliances.Providers;
using EasterEvent.Customs.Processes;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;

namespace EasterEvent.Customs
{
    public static class RefVars
	{
		#region Vanilla
		public static Process Chop  => Find<Process>(ProcessReferences.Chop);
		public static Process Knead => Find<Process>(ProcessReferences.Knead);
		public static Process Cook => Find<Process>(ProcessReferences.Cook);
		#endregion

		#region EasterEvent
		//Items
		public static LayoutProfile EasterLayout => Find<LayoutProfile>(GDOUtils.GetCustomGameDataObject<EasterLayout>().ID);
		public static Item Chocolate_Egg => Find<Item>(GDOUtils.GetCustomGameDataObject<Chocolate_Egg>().ID);
		public static Item Chocolate_Egg_Half => Find<Item>(GDOUtils.GetCustomGameDataObject<Chocolate_Egg_Half>().ID);
		public static Item Egg_Basket_Dirty => Find<Item>(GDOUtils.GetCustomGameDataObject<Egg_Basket_Dirty>().ID);
		public static Item Egg_Basket => Find<Item>(GDOUtils.GetCustomGameDataObject<Egg_Basket>().ID);
		public static Item Chocolate_Mold_Empty => Find<Item>(GDOUtils.GetCustomGameDataObject<Chocolate_Mold_Empty>().ID);
		public static Item Chocolate_Mold_Raw => Find<Item>(GDOUtils.GetCustomGameDataObject<Chocolate_Mold_Raw>().ID);
		public static Item Chocolate_Mold_Frozen => Find<Item>(GDOUtils.GetCustomGameDataObject<Chocolate_Mold_Frozen>().ID);

		public static Item Blue_Dye => Find<Item>(GDOUtils.GetCustomGameDataObject<Blue_Dye>().ID);
		public static Item Green_Dye => Find<Item>(GDOUtils.GetCustomGameDataObject<Green_Dye>().ID);
		public static Item Purple_Dye => Find<Item>(GDOUtils.GetCustomGameDataObject<Purple_Dye>().ID);
		public static Item Red_Dye => Find<Item>(GDOUtils.GetCustomGameDataObject<Red_Dye>().ID);
		public static Item White_Dye => Find<Item>(GDOUtils.GetCustomGameDataObject<White_Dye>().ID);
		public static Item Yellow_Dye => Find<Item>(GDOUtils.GetCustomGameDataObject<Yellow_Dye>().ID);

		//Eggs

		public static Item Blue_White => Find<Item>(GDOUtils.GetCustomGameDataObject<Blue_White>().ID);
		public static Item Red_Blue => Find<Item>(GDOUtils.GetCustomGameDataObject<Red_Blue>().ID);
		public static Item Red_White => Find<Item>(GDOUtils.GetCustomGameDataObject<Red_White>().ID);

		public static Item Green_Blue => Find<Item>(GDOUtils.GetCustomGameDataObject<Green_Blue>().ID);
		public static Item Green_Red => Find<Item>(GDOUtils.GetCustomGameDataObject<Green_Red>().ID);
		public static Item Green_White => Find<Item>(GDOUtils.GetCustomGameDataObject<Green_White>().ID);

		public static Item Purple_Green => Find<Item>(GDOUtils.GetCustomGameDataObject<Purple_Green>().ID);
		public static Item Purple_White => Find<Item>(GDOUtils.GetCustomGameDataObject<Purple_White>().ID);
		public static Item Purple_Yellow => Find<Item>(GDOUtils.GetCustomGameDataObject<Purple_Yellow>().ID);

		//Processes
		public static Process Chonkify => Find<Process>(GDOUtils.GetCustomGameDataObject<Chonkify>().ID);
		public static Process Freeze => Find<Process>(GDOUtils.GetCustomGameDataObject<Freeze>().ID);

		//Appliances
		public static Appliance Basket_Stack => Find<Appliance>(GDOUtils.GetCustomGameDataObject<Basket_Stack>().ID);
		public static Appliance Egg_Chonkifier => Find<Appliance>(GDOUtils.GetCustomGameDataObject<Egg_Chonkifier>().ID);
		public static Appliance Blue_Dye_Provider => Find<Appliance>(GDOUtils.GetCustomGameDataObject<Blue_Dye_Provider>().ID);
		public static Appliance Green_Dye_Provider => Find<Appliance>(GDOUtils.GetCustomGameDataObject<Green_Dye_Provider>().ID);
		public static Appliance Purple_Dye_Provider => Find<Appliance>(GDOUtils.GetCustomGameDataObject<Purple_Dye_Provider>().ID);
		public static Appliance Red_Dye_Provider => Find<Appliance>(GDOUtils.GetCustomGameDataObject<Red_Dye_Provider>().ID);
		public static Appliance White_Dye_Provider => Find<Appliance>(GDOUtils.GetCustomGameDataObject<White_Dye_Provider>().ID);
		public static Appliance Yellow_Dye_Provider => Find<Appliance>(GDOUtils.GetCustomGameDataObject<Yellow_Dye_Provider>().ID);
		public static Appliance Chocolate_Mold_Provider => Find<Appliance>(GDOUtils.GetCustomGameDataObject<Chocolate_Mold_Provider>().ID);
		#endregion

		#region IngredientLib
		//Items
		public static Item Chocolate => Find<Item>(IngredientLib.References.GetIngredient("chocolate"));
		public static Item Chocolate_Sauce => Find<Item>(IngredientLib.References.GetIngredient("chocolate sauce"));
		#endregion








		internal static T Find<T>(int id) where T : GameDataObject
		{
			return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
		}

		internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
		{
			return GDOUtils.GetCastedGDO<T, C>();
		}

		internal static T Find<T>(string modName, string name) where T : GameDataObject
		{
			return GDOUtils.GetCastedGDO<T>(modName, name);
		}
	}
}
