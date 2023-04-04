using KitchenData;

namespace EasterEvent.Customs
{
	public class Red_Blue : Base_Egg
	{
		public override Item Color1 => RefVars.Red_Dye;

		public override Item Color2 => RefVars.Blue_Dye;

		public override string _Color1 => "Red";

		public override string _Color2 => "Blue";
	}
}
