using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSeller
{
	public class PrimaryReceiptCalculator : IReceiptCalculator
	{
		private readonly IItemStore itemStore;
		private readonly IDiscountProvider discountProvider;
		private readonly List<int> itemIds = new List<int>();

		public PrimaryReceiptCalculator(IItemStore itemStore, IDiscountProvider discountProvider)
		{
			this.itemStore = itemStore ?? throw new ArgumentNullException(nameof(itemStore));
			this.discountProvider = discountProvider ?? throw new ArgumentNullException(nameof(discountProvider));
		}

		public void AddItem(int itemId) =>
			itemIds.Add(itemId);

		public Receipt GenerateReceipt()
		{
			var receipt = new Receipt();
			receipt.Items = itemStore.GetItems(itemIds).Select(i => new ReceiptItem() { Id = i.id, Name = i.name, Price = i.price }).ToList();
			var itemsSum = receipt.Items.Sum(i => i.Price);
			const decimal discountThreshold = 50;
			if (itemsSum >= discountThreshold) receipt.Discount = discountProvider.GetDiscount();
			receipt.Subtotal = itemsSum - receipt.Discount;
			const decimal taxRate = 0.0475m;
			receipt.Taxes = receipt.Subtotal * taxRate;
			receipt.Total = receipt.Subtotal + receipt.Taxes;
			return receipt;
		}
	}
}
