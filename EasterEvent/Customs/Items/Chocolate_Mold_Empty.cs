using KitchenData;
using KitchenLib.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Chocolate_Mold_Empty : CustomItem
	{
		public override string UniqueNameID => "Chocolate_Mold_Empty";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Chocolate_Mold_Empty");
		public override Appliance DedicatedProvider => RefVars.Chocolate_Mold_Provider;
		public override bool IsIndisposable => true;
	}
}
