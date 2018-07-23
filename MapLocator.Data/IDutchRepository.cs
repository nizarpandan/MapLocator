using System.Collections.Generic;
using MapLocator.Data.Entities;

namespace MapLocator.Data
{
	public interface IDutchRepository
	{
		IEnumerable<Product> GetAllProducts();
		IEnumerable<Product> GetProductsByCategory(string category);

		IEnumerable<Order> GetAllOrders(bool includeItems);
		Order GetOrderById(int id);
		
		bool SaveAll();
		void AddEntity(object model);
	}
}