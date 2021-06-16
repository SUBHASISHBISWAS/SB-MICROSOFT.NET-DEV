using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFBasic_ServiceClient.ServiceReference1;

namespace WCFBasic_ServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TestServiceClient aProxyClient = new TestServiceClient("NetNamedPipeBinding_ITestService");
            var message = aProxyClient.EchoOperation("Hello wcf");
            Console.WriteLine(message);
            Console.Read();

        }
    }
}
