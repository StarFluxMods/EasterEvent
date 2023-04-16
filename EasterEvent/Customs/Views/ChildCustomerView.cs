using Kitchen;
using KitchenData;
using KitchenLib.Preferences;
using KitchenLib.Utils;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.Entities;
using UnityEngine;
using MessagePack;
using Unity.Collections;
using EasterEvent.Systems;

namespace EasterEvent.Customs
{
	public class ChildCustomerView : UpdatableObjectView<ChildCustomerView.ViewData>
	{
		#region ECS View System (Runs on host and updates views to be broadcasted to clients)
		public class UpdateView : IncrementalViewSystemBase<ViewData>, IModSystem
		{
			private EntityQuery Views;

			public override void Initialise()
			{
				base.Initialise();

				Views = GetEntityQuery(new QueryHelper()
					.All(typeof(CChildCustomer), typeof(CLinkedView)));
			}

			public override void OnUpdate()
			{
				using var entities = Views.ToEntityArray(Allocator.Temp);
				using var views = Views.ToComponentDataArray<CLinkedView>(Allocator.Temp);

				for (var i = 0; i < views.Length; i++)
				{
					
					var view = views[i];

					bool active = false;
					bool seated = false;
					if (Require(entities[i], out CChildCustomer	 itemProvider))
					{
						active = itemProvider.isChild;
					}
					if (Require(entities[i], out CCustomerState cCustomer))
					{
						if (cCustomer.CurrentState == CCustomerState.State.AtTable)
						{
							seated = true;
						}
					}
					ViewData data = new ViewData
					{
						isChild = active,
						isSeated = seated
					};

					SendUpdate(view, data);
				}
			}
		}
		#endregion




		#region Message Packet
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(1)] public bool isChild;
			[Key(2)] public bool isSeated;

			public IUpdatableObject GetRelevantSubview(IObjectView view) => view.GetSubView<ChildCustomerView>();

			public bool IsChangedFrom(ViewData cached)
			{
				return isChild != cached.isChild || isSeated != cached.isSeated;
			}
		}
		#endregion
		
		private float _defaultY = 0f;
		public Transform transform;
		public override void UpdateData(ViewData view_data)
		{
			if (_defaultY == 0f)
			{
				_defaultY = transform.position.y;
			}
			if (view_data.isChild && view_data.isSeated)
			{
				transform.position = new Vector3(transform.position.x, 0.227f, transform.position.z);
			}
			else
			{
				transform.position = new Vector3(transform.position.x, _defaultY, transform.position.z);
			}
		}

		void Update()
		{
		}
	}
}