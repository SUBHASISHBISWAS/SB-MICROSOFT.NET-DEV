using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(SimpleService.SimpleService));
            host.Open();
            Console.WriteLine("Statred At {0}",DateTime.Now.ToString());
            Console.ReadLine();
        }
    }
}
