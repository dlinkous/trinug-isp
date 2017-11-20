using System;
using System.Collections.Generic;

namespace SuperSeller
{
    public class Receipt
    {
		internal Receipt() { }

		public IEnumerable<ReceiptItem> Items { get; internal set; }
		public decimal Discount { get; internal set; }
		public decimal Subtotal { get; internal set; }
		public decimal Taxes { get; internal set; }
		public decimal Total { get; internal set; }
    }
}
