using Subhasish.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.DAL.Interfaces
{
    public interface ICustomerRepository:IRepository<Customer,int>
    {
        IEnumerable<Customer> GetCustomersByName(string customerName);
    }
}
