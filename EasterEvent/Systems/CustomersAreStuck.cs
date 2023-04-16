using Kitchen;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;

namespace EasterEvent.Systems
{
	public struct CGroupHasOrderedThree : IComponentData { }
	
	[UpdateBefore(typeof(GroupHandleEating))]
	public class CustomersAreStuck : GameSystemBase, IModSystem
	{
		EntityQuery leaving;
		public override void Initialise()
		{
			leaving = GetEntityQuery(typeof(CGroupHasRepeatedOrder));
		}

		public override void OnUpdate()
		{
			var entities = leaving.ToEntityArray(Unity.Collections.Allocator.Temp);

			for (int i = 0; i < entities.Length; i++)
			{
				if (!Has<CGroupHasOrderedThree>(entities[i]))
				{
					EntityManager.AddComponent<CGroupHasOrderedThree>(entities[i]);
					EntityManager.RemoveComponent<CGroupHasRepeatedOrder>(entities[i]);
				}
			}
		}
	}
}
