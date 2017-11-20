using System;
using System.Collections.Generic;

namespace SuperSeller
{
    public interface IItemStore
    {
		IEnumerable<(int id, string name, decimal price)> GetItems(IEnumerable<int> itemIds);
	}
}
