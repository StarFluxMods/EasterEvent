using KitchenData;

namespace EasterEvent.Customs
{
	public class Green_Red : Base_Egg
	{
		public override Item Color1 => RefVars.Green_Dye;

		public override Item Color2 => RefVars.Red_Dye;

		public override string _Color1 => "Green";

		public override string _Color2 => "Red";
	}
}
