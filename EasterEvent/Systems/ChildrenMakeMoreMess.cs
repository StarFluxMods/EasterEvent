using KitchenData;
using Kitchen;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using Unity.Collections;
using Kitchen.Layouts;
using UnityEngine;
using EasterEvent.Customs.Components;
using KitchenLib.References;
using EasterEvent.Customs;

namespace EasterEvent.Systems
{
	public class ChildrenMakeMoreMess : GroupHandleEating, IModSystem
	{
		private EntityQuery group;
		private EntityQuery customer;
		public override void Initialise()
		{
			group = GetEntityQuery(new ComponentType[]
			{
				ComponentType.ReadWrite<CGroupEating>(),
				ComponentType.ReadWrite<CGroupMealPhase>(),
				ComponentType.ReadWrite<CPatience>(),
				ComponentType.ReadWrite<CWaitingForItem>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CGroupMember>()
			});

			customer = GetEntityQuery(typeof(CCustomer));
		}

		public override void OnUpdate()
		{
			var entities = group.ToEntityArray(Allocator.Temp);

			for (int i = 0; i < entities.Length; i++)
			{
				if (!Has<CChildrensMessMade>(entities[i]))
				{
					if (DoesGroupContainChild(entities[i]))
					{
						if (Require(entities[i], out CPosition position))
						{
							EntityManager.AddComponent<CChildrensMessMade>(entities[i]);
							var nearBy = LayoutHelpers.AllNearby;
							foreach (LayoutPosition layoutPosition in nearBy)
							{
								Vector3 loc = (Vector3)layoutPosition + position.Position;
								Entity e = EntityManager.CreateEntity(typeof(CMessRequest), typeof(CPosition));
								EntityManager.SetComponentData(e, new CPosition(loc));
								EntityManager.SetComponentData(e, new CMessRequest
								{
									OverwriteOtherMesses = true,
									ID = ApplianceReferences.MessCustomer2
								});
							}
						}
					}
				}
			}
		}

		private bool DoesGroupContainChild(Entity group)
		{
			bool result = false;
			var entities = customer.ToEntityArray(Allocator.Temp);

			for (int i = 0; i < entities.Length; i++)
			{
				if (Require(entities[i], out CBelongsToGroup cBelongsToGroup))
				{
					if (Require(entities[i], out CChildCustomer test))
					{
						if (test.isChild)
						{
							if (cBelongsToGroup.Group == group)
							{
								result = true;
								break;
							}
						}
					}
				}
			}

			return result;
		}
	}
}
