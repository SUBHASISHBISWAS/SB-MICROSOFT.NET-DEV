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
    public class OrderServiceProxy : IOrderService,IDisposable
    {
        private IOrderService orderService = default(IOrderService);
        private ChannelFactory<IOrderService> orderChannelFactory = default(ChannelFactory<IOrderService>);
        public OrderServiceProxy()
        {
            var orderServiceUrl = ConfigurationManager.AppSettings["OrderServiceUrl"];
            this.orderChannelFactory = new ChannelFactory<IOrderService>(new BasicHttpBinding(BasicHttpSecurityMode.None),
                new EndpointAddress(orderServiceUrl));
            this.orderService = orderChannelFactory.CreateChannel();
        }
        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            return this.orderService.GetOrdersByCustomerId(customerId);
        }

        public void Dispose()
        {
            if (orderChannelFactory!=default(ChannelFactory<IOrderService>))
            {
                orderChannelFactory.Close();
            }
        }
    }
}
