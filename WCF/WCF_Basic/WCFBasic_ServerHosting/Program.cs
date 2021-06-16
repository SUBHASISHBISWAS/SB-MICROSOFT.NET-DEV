using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace WCFBasic_ServerSelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost _host = new ServiceHost(typeof(WCFBasic_ServiceLib.TestService));
            _host.Open();
            Console.Read();
        }
    }
}
