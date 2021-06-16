using Subhasish.Libraries.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subhasish.Libraries.SOA.Contracts.Data;

namespace Subhasish.Libraries.DAL.Impl
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetEntities()
        {
            var ordersList = default(IEnumerable<Order>);

            using (var context = DbContextManager.GetContext())
            {
                ordersList = context.Orders.ToList();
            }

            return ordersList;
        }

        public Order GetEntityByKey(int entityKey)
        {
            var filteredOrder = default(Order);

            using (var context = DbContextManager.GetContext())
            {
                filteredOrder = context.Orders.Where(
                    order => order.OrderId.Equals(entityKey)).FirstOrDefault();
            }

            return filteredOrder;
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            var ordersList = default(IEnumerable<Order>);

            using (var context = DbContextManager.GetContext())
            {
                ordersList =
                    (from order in context.Orders
                     where order.CustomerId == customerId
                     select order).ToList();
            }

            return ordersList;
        }
    }
}
