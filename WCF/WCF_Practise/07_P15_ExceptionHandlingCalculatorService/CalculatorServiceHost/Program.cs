using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(CalculatorService.CalculatorService));
            host.Open();
            Console.WriteLine("Server Started At {0}",DateTime.Now.ToString());
            Console.ReadLine();

        }
    }
}
