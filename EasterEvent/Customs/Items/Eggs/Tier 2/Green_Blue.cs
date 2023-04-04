using KitchenData;

namespace EasterEvent.Customs
{
	public class Green_Blue : Base_Egg
	{
		public override Item Color1 => RefVars.Green_Dye;

		public override Item Color2 => RefVars.Blue_Dye;

		public override string _Color1 => "Green";

		public override string _Color2 => "Blue";
	}
}
