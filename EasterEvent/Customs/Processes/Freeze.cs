using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;

namespace EasterEvent.Customs.Processes
{
	public class Freeze : CustomProcess
	{
		public override string UniqueNameID => "Freeze";
		public override GameDataObject BasicEnablingAppliance => (Appliance)GDOUtils.GetExistingGDO(ApplianceReferences.Freezer);
		public override int EnablingApplianceCount => 1;
		public override bool CanObfuscateProgress => true;
	}
}
