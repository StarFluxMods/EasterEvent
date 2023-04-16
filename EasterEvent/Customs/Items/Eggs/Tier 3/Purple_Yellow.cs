using KitchenData;
using System.Collections.Generic;

namespace EasterEvent.Customs
{
	public class Purple_Yellow : Base_Egg
	{
		public override Item Color1 => RefVars.Purple_Dye;

		public override Item Color2 => RefVars.Yellow_Dye;

		public override string _Color1 => "Purple";

		public override string _Color2 => "Yellow";

		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				Duration = 1,
				IsBad = false,
				Process = RefVars.Chonkify,
				RequiresWrapper = false,
				Result = RefVars.Jumbo_Purple_Yellow,
			}
		};
	}
}
