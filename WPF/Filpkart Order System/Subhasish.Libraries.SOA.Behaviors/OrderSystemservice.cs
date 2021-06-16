using Subhasish.Libraries.SOA.Contracts.Services;
using Subhasish.Libraries.SOA.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Subhasish.Libraries.SOA.Contracts.Data;
using Subhasish.Libraries.DAL.Interfaces;
using Subhasish.Libraries.DAL.Impl;
using System.ServiceModel.Activation;

namespace Subhasish.Libraries.SOA.Behaviors
{
    [ServiceBehavior(
        Name = "OrderSystemService",
        Namespace = NamespaceConstants.BEHAVIORS)]
    [AspNetCompatibilityRequirements(RequirementsMode =AspNetCompatibilityRequirementsMode.Allowed)]
    public class OrderSystemService : IOrderSystemService
    {

        private ICustomerRepository customerRepository = default(ICustomerRepository);
        private IOrderRepository orderRepository = default(IOrderRepository);

        public OrderSystemService()
        {
            this.customerRepository = new CustomerRepository();
            this.orderRepository = new OrderRepository();
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            var customersList = default(IEnumerable<Customer>);

            try
            {
                customersList = customerRepository.GetEntities();
            }
            catch (Exception exceptionObject)
            {
                exceptionObject.Log();
                exceptionObject.To(errorId: 1);
                throw;
            }

            return customersList;
        }

        public Customer GetCustomerDetails(int customerId)
        {
            var customer = default(Customer);

            try
            {
                customer = this.customerRepository.GetEntityByKey(customerId);
            }
            catch (Exception exceptionObject)
            {
                exceptionObject.Log();

                throw exceptionObject.To(errorId: 3);
            }

            return customer;
        }

        public IEnumerable<Customer> GetCustomersByName(string customerName)
        {
            var customersList = default(IEnumerable<Customer>);

            try
            {
                customersList = this.customerRepository.GetCustomersByName(customerName);
            }
            catch (Exception exceptionObject)
            {
                exceptionObject.Log();

                throw exceptionObject.To(errorId: 2);
            }

            return customersList;
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            var ordersList = default(IEnumerable<Order>);

            try
            {
                ordersList = orderRepository.GetOrdersByCustomerId(customerId);
            }
            catch (Exception exceptionObject)
            {
                exceptionObject.Log();

                throw exceptionObject.To(errorId: 4);
            }

            return ordersList;
        }
    }
}
