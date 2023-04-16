using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEvent.Customs.Appliances.Providers
{
    public class Blue_Dye_Provider : Base_Dye_Provider
    {
        public override Item Dye => RefVars.Blue_Dye;

        public override string DyeName => "Blue";
    }
}
