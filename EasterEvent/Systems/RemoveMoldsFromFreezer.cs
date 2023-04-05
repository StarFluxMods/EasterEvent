using EasterEvent.Customs;
using Kitchen;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace EasterEvent.Systems
{
	public class RemoveMoldsFromFreezer : NightSystem, IModSystem
	{
		private EntityQuery Freezers;
		public override void Initialise()
		{
			base.Initialise();
			Freezers = GetEntityQuery(typeof(CPreservesContentsOvernight));
		}
		public override void OnUpdate()
		{
			var freezers = Freezers.ToEntityArray(Allocator.Temp);

			for (int i = 0; i < freezers.Length; i++)
			{
				if (Require(freezers[i], out CItemHolder cItemHolder))
				{
					Entity HeldItem = cItemHolder.HeldItem;
					if (HeldItem != null)
					{
						if (Require(HeldItem, out CItem cItem))
						{
							if (cItem.ID == RefVars.Chocolate_Mold_Empty.ID || cItem.ID == RefVars.Chocolate_Mold_Frozen.ID || cItem.ID == RefVars.Chocolate_Mold_Raw.ID)
							{
								EntityManager.DestroyEntity(HeldItem);
							}
						}
					}
				}
			}
		}
	}
}
