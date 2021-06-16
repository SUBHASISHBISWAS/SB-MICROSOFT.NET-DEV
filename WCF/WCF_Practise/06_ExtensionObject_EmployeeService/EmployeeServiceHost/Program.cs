using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost host = new ServiceHost(typeof(EmployeeService.EmployeeService));
            host.Open();
            Console.WriteLine("Host Stated At:{0}",DateTime.Now.ToString());
            Console.ReadLine();
        }
    }
}
