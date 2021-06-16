using Subhasish.Libraries.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subhasish.Libraries.SOA.Data;
using Subhasish.Libraries.Business.Interfaces;

namespace Subhasish.Libraries.Business.Implementation
{
    public class CustomerBusinessService : ICustomerBusinessService
    {

        private ICustomerRepository customerRepository = default(ICustomerRepository);

        public CustomerBusinessService(ICustomerRepository customerRepository)
        {

            this.customerRepository = customerRepository;
            
        }

        public bool AddNewCustomer(Customer customer)
        {
            var status = default(bool);
            var validationStatus = customerRepository != default(ICustomerRepository) && customer != default(Customer);
            if (validationStatus)
            {
                status = this.customerRepository.Add(customer);
            }
            return status;
        }

        public Customer GetCustomerDetails(int customerId)
        {
            var filteredCustomer = default(Customer);
            var validationStatus = customerRepository != default(ICustomerRepository) && customerId != default(int);
            if (validationStatus)
            {
                filteredCustomer = this.customerRepository.GetById(customerId);
            }
            return filteredCustomer;
        }

        public IEnumerable<Customer> GetCustomers(string customerName = null)
        {
            var customeList = default(IEnumerable<Customer>);
            var validationStatus = this.customerRepository != default(ICustomerRepository);
            if (validationStatus)
            {
                if (string.IsNullOrEmpty(customerName))
                {
                    customeList = this.customerRepository.GetAll();
                }
                else
                {
                    customeList = this.customerRepository.GetCustomersByName(customerName);
                }
            }

            return customeList;
        }
    }
}
