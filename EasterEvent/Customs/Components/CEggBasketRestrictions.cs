using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace EasterEvent.Customs
{
	public struct CEggBasketRestrictions : IItemProperty, IAttachableProperty, IComponentData
	{
		public FixedString32 Key;
	}
}
