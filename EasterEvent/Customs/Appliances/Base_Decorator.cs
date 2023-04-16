using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Kitchen;

namespace EasterEvent.Customs
{
	public abstract class Base_Decorator : CustomAppliance
	{
		public abstract string EggName { get; }
		public override string UniqueNameID => EggName + "_Bush";
		public override int BaseGameDataObjectID => ApplianceReferences.TreeAutumn;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>(EggName + "_Bush");
		public override bool IsNonInteractive => true;
		public override bool PreventSale => false;
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			new CImmovable(),
			new CStatic()
		};
	}
	public class Purple_Yellow_Bush : Base_Decorator
	{
		public override string EggName => "Purple_Yellow";
	}
	public class Red_White_Bush : Base_Decorator
	{
		public override string EggName => "Red_White";
	}
	public class White_Green_Bush : Base_Decorator
	{
		public override string EggName => "White_Green";
	}
}
