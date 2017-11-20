using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSeller.Tests
{
	internal class ItemStoreMock : IItemStore
	{
		internal List<(int id, string name, decimal price)> Items { get; set; } = new List<(int id, string name, decimal price)>();

		public IEnumerable<(int id, string name, decimal price)> GetItems(IEnumerable<int> itemIds) => itemIds.Select(id => Items.Where(i => i.id == id).Single());
	}
}
