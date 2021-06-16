using Subhasish.Libraries.SOA.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsung.Libraries.SOA.Proxies.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderSystemServiceProxy = new OrderSystemServiceProxy();

            var customers = orderSystemServiceProxy.GetAllCustomers();

            foreach (var customer in customers)
                Console.WriteLine(customer.ToString());

            Console.WriteLine();

            var orders = orderSystemServiceProxy.GetOrdersByCustomerId(1);
            foreach (var order in orders)
                Console.WriteLine(order.ToString());

            Console.WriteLine("End of App!");
            Console.ReadLine();
        }
    }
}
