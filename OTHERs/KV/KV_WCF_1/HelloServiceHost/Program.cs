using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using KV_WCF_1;

namespace HelloServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(HelloService));
            serviceHost.Open();
            Console.WriteLine("Host Started");
            Console.ReadLine();
        }
    }
}
