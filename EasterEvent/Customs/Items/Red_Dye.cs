using KitchenLib.Customs;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Red_Dye : CustomItem
	{
		public override string UniqueNameID => "Red_Dye";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Red");
		//public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<Roe_Provider>().GameDataObject;
	}
}
