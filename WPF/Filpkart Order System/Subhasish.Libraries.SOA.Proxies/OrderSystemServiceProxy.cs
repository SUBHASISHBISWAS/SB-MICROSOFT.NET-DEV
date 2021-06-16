using Subhasish.Libraries.SOA.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subhasish.Libraries.SOA.Contracts.Data;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;

namespace Subhasish.Libraries.SOA.Proxies
{
    public class OrderSystemServiceProxy : IOrderSystemService
    {
        private IOrderSystemService orderSystemService = default(IOrderSystemService);
        public OrderSystemServiceProxy()
        {
            var baseUrl = ConfigurationManager.AppSettings["BaseServiceUrl"];
            var channelFactory = new ChannelFactory<IOrderSystemService>(
               new WebHttpBinding(WebHttpSecurityMode.None),
               new EndpointAddress(baseUrl));
            channelFactory.Endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
            this.orderSystemService = channelFactory.CreateChannel();
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return this.orderSystemService.GetAllCustomers();
        }

        public Customer GetCustomerDetails(int customerId)
        {
            return this.orderSystemService.GetCustomerDetails(customerId);
        }

        public IEnumerable<Customer> GetCustomersByName(string customerName)
        {
            return this.orderSystemService.GetCustomersByName(customerName);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            return this.orderSystemService.GetOrdersByCustomerId(customerId);
        }
    }
}
