using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Red_Dye_Provider : Base_Dye_Provider
	{
		public override Item Dye => RefVars.Red_Dye;

		public override string DyeName => "Red";
	}
}

