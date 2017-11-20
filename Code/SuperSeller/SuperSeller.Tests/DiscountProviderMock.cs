using System;

namespace SuperSeller.Tests
{
	internal class DiscountProviderMock : IDiscountProvider
	{
		internal decimal Discount { get; set; }
		internal bool GetDiscountCalled { get; set; }

		public decimal GetDiscount()
		{
			GetDiscountCalled = true;
			return Discount;
		}
	}
}
