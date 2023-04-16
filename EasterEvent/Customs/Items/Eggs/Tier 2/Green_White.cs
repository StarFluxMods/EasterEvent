
using KitchenData;
using System.Collections.Generic;

namespace EasterEvent.Customs
{
	public class Green_White : Base_Egg
	{
		public override Item Color1 => RefVars.White_Dye;

		public override Item Color2 => RefVars.Green_Dye;

		public override string _Color1 => "White";

		public override string _Color2 => "Green";

		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				Duration = 1,
				IsBad = false,
				Process = RefVars.Chonkify,
				RequiresWrapper = false,
				Result = RefVars.Jumbo_Green_White,
			}
		};
	}
}
