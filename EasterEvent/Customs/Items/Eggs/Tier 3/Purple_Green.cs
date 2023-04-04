
using KitchenData;

namespace EasterEvent.Customs
{
	public class Purple_Green : Base_Egg
	{
		public override Item Color1 => RefVars.Purple_Dye;

		public override Item Color2 => RefVars.Green_Dye;

		public override string _Color1 => "Purple";

		public override string _Color2 => "Green";
	}
}
