using Subhasish.Libraries.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subhasish.Libraries.SOA.Data;
using Subhasish.Libraries.DAL.Interfaces;

namespace Subhasish.Libraries.Business.Implementation
{
    public class OrderBusinessService : IOrderBusinessService
    {
        private IOrderRepository orderRepository = default(IOrderRepository);

        public OrderBusinessService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order GetOrderDetails(int orderId)
        {
            var filteredOrder = default(Order);
            var validationStatus = this.orderRepository != default(IOrderRepository) && orderId!=default(int);
            if (validationStatus)
            {
                filteredOrder = this.orderRepository.GetById(orderId);
            }
            return filteredOrder;
        }

        public IEnumerable<Order> GetOrders(int customerId = 0)
        {
            var orderList = default(IEnumerable<Order>);
            var validationStatus = this.orderRepository != default(IOrderRepository);

            if (validationStatus)
            {
                if (customerId==default(int))
                {
                    orderList = this.orderRepository.GetAll();
                }
                else
                {
                    orderList = this.orderRepository.GetOrdersByCustomerId(customerId);
                }
            }

            return orderList;
        }
    }
}
