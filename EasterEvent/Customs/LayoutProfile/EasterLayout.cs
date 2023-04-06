using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterEvent.Customs
{
	public class EasterLayout : CustomLayoutProfile
	{
		public override string UniqueNameID => "EasterLayout";
		public override int BaseGameDataObjectID => -2045800810;

		//public override Appliance StreetPiece => (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.Bin);
	}
}
