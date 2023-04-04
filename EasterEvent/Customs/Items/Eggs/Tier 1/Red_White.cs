using KitchenData;

namespace EasterEvent.Customs
{
	public class Red_White : Base_Egg
	{
		public override Item Color1 => RefVars.Red_Dye;

		public override Item Color2 => RefVars.White_Dye;

		public override string _Color1 => "Red";

		public override string _Color2 => "White";
	}
}
