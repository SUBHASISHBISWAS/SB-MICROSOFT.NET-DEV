using Subhasish.Libraries.SOA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.DAL.Interfaces
{
    public interface IOrderRepository:IRepository<Order,int>
    {
        IEnumerable<Order> GetOrdersByCustomerId(int customerId);
    }
}
