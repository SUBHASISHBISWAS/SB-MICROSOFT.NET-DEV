using Subhasish.Libraries.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subhasish.Libraries.SOA.Contracts.Data;

namespace Subhasish.Libraries.DAL.Impl
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomersByName(string customerName)
        {
            var customers = default(IEnumerable<Customer>);

            using (var context=DbContextManager.GetContext())
            {

                customers = (from customer in context.Customers
                             where customer.CustomerName.Contains(customerName)
                             select customer).ToList();
            }

            return customers;
        }

        public IEnumerable<Customer> GetEntities()
        {
            var customers = default(IEnumerable<Customer>);

            using (var context = DbContextManager.GetContext())
            {
                customers = context.Customers.ToList();
            }

            return customers;
        }

        public Customer GetEntityByKey(int entityKey)
        {
            var filteredCustomer = default(Customer);

            using (var context = DbContextManager.GetContext())
            {
                filteredCustomer =
                    (from customer in context.Customers
                     where customer.CustomerId == entityKey
                     select customer).FirstOrDefault();
            }

            return filteredCustomer;
        }
    }
}
