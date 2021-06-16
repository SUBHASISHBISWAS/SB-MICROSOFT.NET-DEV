using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientApp.HelloService.HelloServiceClient client = new ClientApp.HelloService.HelloServiceClient("NetTcpBinding_IHelloService");
            Console.WriteLine(client.GetMessage("Subhasish"));
            Console.ReadLine();
        }
    }
}
