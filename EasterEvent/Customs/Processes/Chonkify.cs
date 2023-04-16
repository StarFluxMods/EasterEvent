using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;

namespace EasterEvent.Customs.Processes
{
	public class Chonkify : CustomProcess
	{
		public override string UniqueNameID => "Chonkify";
		public override GameDataObject BasicEnablingAppliance => RefVars.Egg_Chonkifier;
		public override int EnablingApplianceCount => 1;
		public override bool CanObfuscateProgress => true;
		public override string Icon => "<sprite name=\"Zap\">";
	}
}
