using Subhasish.Libraries.SOA.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subhasish.Libraries.SOA.Data;
using Subhasish.Libraries.Business.Interfaces;

namespace Subhasish.Libraries.SOA.Behaviors
{
    public class OrderService : IOrderService
    {
        private IOrderBusinessService orderBusinessService = default(IOrderBusinessService);

        public OrderService(IOrderBusinessService orderBusinessService)
        {
            this.orderBusinessService = orderBusinessService;
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            var orderList = default(IEnumerable<Order>);
            var validationStatus = orderBusinessService != default(IOrderBusinessService) && customerId != default(int);

            try
            {
                if (validationStatus)
                {
                    orderList = this.orderBusinessService.GetOrders(customerId);
                }
            }
            catch (Exception exceptionObject)
            {
                exceptionObject.Log();
                throw exceptionObject.Transform(errorId: 5);
            }

            return orderList;
        }
    }
}
