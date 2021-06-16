using Subhasish.Libraries.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subhasish.Libraries.SOA.Data;
using Subhasish.Libraries.ORM.Interfaces;

namespace Subhasish.Libraries.DAL.Implementation
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {

        private ICustomerSystemContext customerSystemContext = default(ICustomerSystemContext);



        public CustomerRepository(ICustomerSystemContext customerSystemContext)
        {
            this.customerSystemContext = customerSystemContext;
        }    

        public bool Add(Customer entity)
        {
            var status = default(bool);
            var validationStatus = entity != default(Customer) && 
                customerSystemContext != default(ICustomerSystemContext);

            if (validationStatus)
            {
                this.customerSystemContext.Customers.Add(entity);
                this.customerSystemContext.Commit();
                status = true;
            }
            return status;
        }
       

        public IEnumerable<Customer> GetAll()
        {
            var customerList = default(IEnumerable<Customer>);
            var validationStatus =customerSystemContext != default(ICustomerSystemContext);

            if (validationStatus)
            {
                customerList = customerSystemContext.Customers.ToList();
            }
            return customerList;
        }

        public Customer GetById(int entityKey)
        {
            var filteredCustomer = default(Customer);
            var validationStatus = this.customerSystemContext != default(ICustomerSystemContext);

            if (validationStatus)
            {
                filteredCustomer = customerSystemContext.Customers.Where(customer => customer.CustomerId.Equals(entityKey)).FirstOrDefault();
            }
            return filteredCustomer;
        }

        public IEnumerable<Customer> GetCustomersByName(string customeName)
        {
            var customerList = default(IEnumerable<Customer>);
            var validationStatus = !string.IsNullOrEmpty(customeName) && 
                customerSystemContext != default(ICustomerSystemContext);

            if (validationStatus)
            {
                var procedureName = "dbo.uspGetCustomers @customerName";
                var parameter = new Dictionary<string, object>
                {
                    {"@customerName",customeName }
                };

                customerList = customerSystemContext.ExecuteRoutine<Customer>(procedureName, parameter);
            }

            return customerList;
        }

        public void Dispose()
        {
            if (customerSystemContext != default(ICustomerSystemContext))
            {
                customerSystemContext.Dispose();
            }
        }
    }
}
