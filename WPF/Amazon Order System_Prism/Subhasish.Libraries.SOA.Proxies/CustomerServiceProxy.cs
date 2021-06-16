using Subhasish.Libraries.SOA.Contracts.Services;
using Subhasish.Libraries.SOA.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Proxies
{
    public class CustomerServiceProxy : ICustomerService,IDisposable
    {
        private ICustomerService customerService = default(ICustomerService);
        private ChannelFactory<ICustomerService> customerChannelfactory = default(ChannelFactory<ICustomerService>);

        public CustomerServiceProxy()
        {
            var customerServiceUrl = ConfigurationManager.AppSettings["CustomerServiceUrl"];
            this.customerChannelfactory = new ChannelFactory<ICustomerService>
                (new BasicHttpBinding(BasicHttpSecurityMode.None), new EndpointAddress(customerServiceUrl));
            customerService = customerChannelfactory.CreateChannel();

        }
        public bool AddNewCustomer(Customer customer)
        {
            return this.customerService.AddNewCustomer(customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return this.customerService.GetAllCustomers();
        }

        public IEnumerable<Customer> GetCustomerByName(string customerName)
        {
            return this.customerService.GetCustomerByName(customerName);
        }

        public Customer GetCustomerDetails(int customerId)
        {
            return this.customerService.GetCustomerDetails(customerId);
        }

        public void Dispose()
        {
            if (customerChannelfactory!=default(ChannelFactory<ICustomerService>))
            {
                this.customerChannelfactory.Close();
            }
        }
    }
}
