using Subhasish.Libraries.SOA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.Business.Interfaces
{
    public interface ICustomerBusinessService:IBusinessService
    {
        IEnumerable<Customer> GetCustomers(string customerName = default(String));

        Customer GetCustomerDetails(int customerId);

        bool AddNewCustomer(Customer customer);
    }
}
