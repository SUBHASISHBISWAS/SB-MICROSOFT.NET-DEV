using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ReportServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ReportService.ReportService));
            host.Open();
            Console.WriteLine("Stated AT {0}",DateTime.Now.ToString());
            Console.ReadLine();
        }
    }
}
