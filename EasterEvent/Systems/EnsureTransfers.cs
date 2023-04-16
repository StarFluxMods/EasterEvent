using ApplianceLib.Api;
using EasterEvent.Customs;
using Kitchen;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using Unity.Entities;

namespace EasterEvent.Systems
{
	[UpdateInGroup(typeof(ItemTransferEarlyPrune))]
	public class EnsureTransfers : GameSystemBase, IModSystem
	{
		private EntityQuery cItemTransferProposal;
		public override void Initialise()
		{
			cItemTransferProposal = GetEntityQuery(typeof(CItemTransferProposal));
		}

		public override void OnUpdate()
		{
			NativeArray<Entity> entities = cItemTransferProposal.ToEntityArray(Allocator.Temp);
			NativeArray<CItemTransferProposal> components = cItemTransferProposal.ToComponentDataArray<CItemTransferProposal>(Allocator.Temp);

			for (int i = 0; i < entities.Length; i++)
			{
				Entity entity = entities[i];
				CItemTransferProposal citemTransferProposal = components[i];

				if (citemTransferProposal.Status != ItemTransferStatus.Pruned)
				{
					
					if (Require(citemTransferProposal.Destination, out CToolUser user))
					{
						if (Require(user.CurrentTool, out CEggBasketRestrictions restrictions))
						{
							if (!RestrictedItemTransfers.IsAllowed(restrictions.Key.ToString(), citemTransferProposal.ItemType))
							{
								citemTransferProposal.Status = ItemTransferStatus.Pruned;
							}
						}
						else if (Main.JumboTypes.Contains(citemTransferProposal.ItemType))
						{
							citemTransferProposal.Status = ItemTransferStatus.Pruned;
						}
					}
					else if (Require(citemTransferProposal.Destination, out CItemHolder holer))
					{
						if (Require(holer.HeldItem, out CEggBasketRestrictions restrictions))
						{
							if (!RestrictedItemTransfers.IsAllowed(restrictions.Key.ToString(), citemTransferProposal.ItemType))
							{
								citemTransferProposal.Status = ItemTransferStatus.Pruned;
							}
						}
					}
				}

				if (citemTransferProposal.Status == ItemTransferStatus.Pruned)
				{
					citemTransferProposal.PrunedBy = this;
				}
				SetComponent(entities[i], citemTransferProposal);
			}
		}
	}

}
