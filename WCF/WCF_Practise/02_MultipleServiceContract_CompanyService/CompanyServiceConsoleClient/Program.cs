using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyServiceConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyService.CompanyCofidentialServiceClient confClient = new CompanyService.CompanyCofidentialServiceClient("NetTcpBinding_ICompanyCofidentialService");
            Console.WriteLine(confClient.GetConfidentialInformation());

            Console.ReadLine();


            CompanyService.CompanyPublicServiceClient pubClient = new CompanyService.CompanyPublicServiceClient("BasicHttpBinding_ICompanyPublicService");
            Console.WriteLine(pubClient.GetPublicInformation());

            Console.ReadLine();


        }
    }
}
