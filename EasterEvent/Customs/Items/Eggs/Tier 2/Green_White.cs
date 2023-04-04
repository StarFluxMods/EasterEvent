
using KitchenData;

namespace EasterEvent.Customs
{
	public class Green_White : Base_Egg
	{
		public override Item Color1 => RefVars.White_Dye;

		public override Item Color2 => RefVars.Green_Dye;

		public override string _Color1 => "White";

		public override string _Color2 => "Green";
	}
}
