using Kitchen;
using Kitchen.ShopBuilder;
using KitchenData;
using KitchenLib.Utils;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using Unity.Entities;
using EasterEvent.Customs;

namespace EasterEvent.Systems
{
	[UpdateAfter(typeof(CreateCustomerGroup))]
	public class ChildrenCustomers : GameSystemBase, IModSystem
	{
		public override void Initialise()
		{
			base.Initialise();
			ScheduledCustomers = GetEntityQuery(new ComponentType[]
			{
				typeof(CCustomer)
			});
		}

		public override void OnUpdate()
		{
			if (HasStatus((RestaurantStatus)VariousUtils.GetID("tripleordering")))
			{
				NativeArray<Entity> nativeArray = ScheduledCustomers.ToEntityArray(Allocator.Temp);

				for (int i = 0; i < nativeArray.Length; i++)
				{
					if (Require(nativeArray[i], out CCustomer cCustomer))
					{
						if (!Has<CChildCustomer.Marker>(nativeArray[i]))
						{
							if (!Has<CChildCustomer>(nativeArray[i]))
							{
								EntityManager.AddComponent<CChildCustomer>(nativeArray[i]);
							}

							float random = UnityEngine.Random.value;

							EntityManager.SetComponentData(nativeArray[i], new CChildCustomer
							{
								isChild = (random < 0.3f)
							});

							if (Require(nativeArray[i], out CChildCustomer cTest))
							{
								if (cTest.isChild)
								{
									cCustomer.Scale = 0.5f;
									EntityManager.SetComponentData(nativeArray[i], cCustomer);
								}
							}

							EntityManager.AddComponent<CChildCustomer.Marker>(nativeArray[i]);
						}
					}
				}
			}
		}

		private EntityQuery ScheduledCustomers;
		private EntityQuery ScheduledCustomers1;
	}
}
