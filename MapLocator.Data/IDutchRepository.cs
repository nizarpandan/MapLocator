using System.Collections.Generic;
using MapLocator.Data.Entities;

namespace MapLocator.Data
{
	public interface IDutchRepository
	{
		IEnumerable<Product> GetAllProducts();
		IEnumerable<Order> GetAllOrders();
		Order GetOrderById(int id);
		IEnumerable<Product> GetProductsByCategory(string category);
		bool SaveAll();
		void AddEntity(object model);
	}
}