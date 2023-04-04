using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEvent.Customs
{
	public class Yellow_Dye_Provider : Base_Dye_Provider
	{
		public override Item Dye => RefVars.Yellow_Dye;

		public override string DyeName => "Yellow";
	}
}
