using KitchenLib.Customs;
using KitchenLib.References;
using UnityEngine;
using KitchenData;
using KitchenLib.Utils;
using Kitchen;
using System.Collections.Generic;

namespace EasterEvent.Customs
{
	public class Grass_Easter : CustomAppliance
	{
		public override string UniqueNameID => "Grass_Easter";
		public override int BaseGameDataObjectID => ApplianceReferences.GrassAutumn;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Grass - Easter");
		public override bool IsNonInteractive => true;
		public override bool PreventSale => true;
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			new CImmovable(),
			new CStatic()
		};

		public override void OnRegister(Appliance gameDataObject)
		{
			MaterialUtils.ApplyMaterial(gameDataObject.Prefab, "GameObject", new Material[] { MaterialUtils.GetCustomMaterial("Easter_Grass") });
		}
	}
}
