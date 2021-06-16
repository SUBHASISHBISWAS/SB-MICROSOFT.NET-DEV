using Subhasish.Libraries.SOA.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var customerServiceProxy=new CustomerServiceProxy())
            {
                var filteredCustomer = customerServiceProxy.GetCustomerByName("wind");

                foreach (var item in filteredCustomer)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.ReadLine();
            }

            using (var orderServiceProxy=new OrderServiceProxy())
            {
                var filteredOrder = orderServiceProxy.GetOrdersByCustomerId(2);
                foreach (var item in filteredOrder)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadLine();
            }
        }
    }
}
