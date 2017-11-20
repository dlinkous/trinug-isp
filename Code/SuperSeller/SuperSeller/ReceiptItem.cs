using System;

namespace SuperSeller
{
    public class ReceiptItem
    {
		internal ReceiptItem() { }

		public int Id { get; internal set; }
		public string Name { get; internal set; }
		public decimal Price { get; internal set; }
    }
}
