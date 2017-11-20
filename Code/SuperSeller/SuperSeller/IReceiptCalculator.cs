using System;

namespace SuperSeller
{
    public interface IReceiptCalculator
    {
		void AddItem(int itemId);
		Receipt GenerateReceipt();
    }
}
