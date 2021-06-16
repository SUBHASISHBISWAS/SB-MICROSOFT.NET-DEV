using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CompanyServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(CompanyService.CompanyService));
            host.Open();
            Console.WriteLine("Host Started At:{0}",DateTime.Now.ToString());
            Console.ReadLine(); 
        }
    }
}
