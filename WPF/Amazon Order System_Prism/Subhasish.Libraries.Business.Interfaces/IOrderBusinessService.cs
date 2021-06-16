using Subhasish.Libraries.SOA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.Business.Interfaces
{
    public interface IOrderBusinessService:IBusinessService
    {
        IEnumerable<Order> GetOrders(int customerId = default(int));

        Order GetOrderDetails(int orderId);
    }
}
