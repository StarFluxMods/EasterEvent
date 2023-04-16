using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EasterEvent.Customs
{
	public abstract class Base_Jumbo_Egg : CustomItem
	{
		public abstract Item Color1 { get; }
		public abstract Item Color2 { get; }
		public abstract string _Color1 { get; }
		public abstract string _Color2 { get; }
		public override string UniqueNameID => $"Jumbo_{_Color1}_{_Color2}";
		public override Item DirtiesTo => RefVars.Egg_Shell;

		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>($"Jumbo_{_Color1}_{_Color2}");


		public override void OnRegister(Item gameDataObject)
		{
		}
	}
}
