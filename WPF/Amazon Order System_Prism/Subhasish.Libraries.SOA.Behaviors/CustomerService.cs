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
    public class CustomerService : ICustomerService
    {
        private ICustomerBusinessService customerBusinessService=default(ICustomerBusinessService);

        public CustomerService(ICustomerBusinessService customerBusinessService)
        {
            this.customerBusinessService = customerBusinessService;
        }

        public bool AddNewCustomer(Customer customer)
        {
            var status = default(bool);
            var validationStatus = customerBusinessService != default(ICustomerBusinessService) && customer != default(Customer);
            try
            {
                if (validationStatus)
                {
                    status=this.customerBusinessService.AddNewCustomer(customer);
                }
            }
            catch (Exception exceptionObject)
            {
                exceptionObject.Log();
                throw exceptionObject.Transform(errorId: 4);
            }

            return status;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customerlist = default(IEnumerable<Customer>);

            var validationStatus = this.customerBusinessService != default(ICustomerBusinessService);

            try
            {
                if (validationStatus)
                {
                    customerlist = this.customerBusinessService.GetCustomers();
                }
            }
            catch (Exception exceptionObject)
            {
                exceptionObject.Log();
                throw exceptionObject.Transform(errorId: 1);
            }

            return customerlist;
        }

        public IEnumerable<Customer> GetCustomerByName(string customerName)
        {
            var customerlist = default(IEnumerable<Customer>);

            var validationStatus = this.customerBusinessService != default(ICustomerBusinessService);

            try
            {
                if (validationStatus)
                {
                    customerlist = this.customerBusinessService.GetCustomers(customerName);
                }
            }
            catch (Exception exceptionObject)
            {
                exceptionObject.Log();
                throw exceptionObject.Transform(errorId: 1);
            }

            return customerlist;
        }

        public Customer GetCustomerDetails(int customerId)
        {
            var filteredCustomer = default(Customer);
            var validationStatus = customerId != default(int) && customerBusinessService != default(ICustomerBusinessService);
            try
            {
                if (validationStatus)
                {
                    filteredCustomer = this.customerBusinessService.GetCustomerDetails(customerId);
                }
            }
            catch (Exception exceptionObject)
            {
                exceptionObject.Log();
                throw exceptionObject.Transform(errorId: 3);
            }

            return filteredCustomer;
        }
    }
}
