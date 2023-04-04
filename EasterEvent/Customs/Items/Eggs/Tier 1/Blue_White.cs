using KitchenData;

namespace EasterEvent.Customs
{
	public class Blue_White : Base_Egg
	{
		public override Item Color1 => RefVars.Blue_Dye;

		public override Item Color2 => RefVars.White_Dye;

		public override string _Color1 => "Blue";

		public override string _Color2 => "White";
	}
}
