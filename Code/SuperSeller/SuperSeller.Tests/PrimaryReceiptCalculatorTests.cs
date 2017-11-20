using System;
using System.Linq;
using Xunit;

namespace SuperSeller.Tests
{
    public class PrimaryReceiptCalculatorTests
    {
		[Fact]
		public void WhenItemsBelowThreshold_DoNotCallGetDiscount()
		{
			var itemStoreMock = new ItemStoreMock();
			var discountProviderMock = new DiscountProviderMock();
			var calculator = new PrimaryReceiptCalculator(itemStoreMock, discountProviderMock);
			calculator.GenerateReceipt();
			Assert.False(discountProviderMock.GetDiscountCalled);
		}

		[Fact]
		public void WhenItemsAtThreshold_CallGetDiscount()
		{
			var itemStoreMock = new ItemStoreMock();
			var discountProviderMock = new DiscountProviderMock();
			var calculator = new PrimaryReceiptCalculator(itemStoreMock, discountProviderMock);
			itemStoreMock.Items.Add((1, String.Empty, 50));
			calculator.AddItem(1);
			calculator.GenerateReceipt();
			Assert.True(discountProviderMock.GetDiscountCalled);
		}

		[Fact]
		public void ExampleTest()
		{
			var itemStoreMock = new ItemStoreMock();
			var discountProviderMock = new DiscountProviderMock();
			var calculator = new PrimaryReceiptCalculator(itemStoreMock, discountProviderMock);
			itemStoreMock.Items.Add((1, "One", 1));
			itemStoreMock.Items.Add((2, "Two", 5));
			itemStoreMock.Items.Add((3, "Three", 10));
			itemStoreMock.Items.Add((4, "Four", 25));
			itemStoreMock.Items.Add((5, "Five", 50));
			discountProviderMock.Discount = 3;
			calculator.AddItem(5);
			calculator.AddItem(3);
			calculator.AddItem(1);
			var receipt = calculator.GenerateReceipt();
			Assert.True(discountProviderMock.GetDiscountCalled);
			var itemsList = receipt.Items.ToList();
			Assert.Equal(3, itemsList.Count);
			var item1 = itemsList[0];
			var item2 = itemsList[1];
			var item3 = itemsList[2];
			Assert.Equal(5, item1.Id);
			Assert.Equal(3, item2.Id);
			Assert.Equal(1, item3.Id);
			Assert.Equal("Five", item1.Name);
			Assert.Equal("Three", item2.Name);
			Assert.Equal("One", item3.Name);
			Assert.Equal(50, item1.Price);
			Assert.Equal(10, item2.Price);
			Assert.Equal(1, item3.Price);
			Assert.Equal(3, receipt.Discount);
			Assert.Equal(58, receipt.Subtotal);
			Assert.Equal(2.755m, receipt.Taxes);
			Assert.Equal(60.755m, receipt.Total);
		}
	}
}
