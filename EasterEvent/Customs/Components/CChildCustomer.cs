using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;

namespace EasterEvent.Customs
{
	public struct CChildCustomer : IComponentData
	{
		public bool isChild;

		public struct Marker : IComponentData
		{
		}
	}
}
