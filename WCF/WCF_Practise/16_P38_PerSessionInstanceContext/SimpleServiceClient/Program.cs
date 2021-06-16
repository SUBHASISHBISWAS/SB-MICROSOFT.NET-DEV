using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleService.SimpleServiceClient clinet = new SimpleService.SimpleServiceClient();
            int number = clinet.IncrementNumber();
            Console.WriteLine("Number After First Call {0}",number);
            number = clinet.IncrementNumber();
            Console.WriteLine("Number After Second Call {0}", number);
            number = clinet.IncrementNumber();
            Console.WriteLine("Number After Third Call {0}", number);

            clinet = new SimpleService.SimpleServiceClient();
            number = clinet.IncrementNumber();
            Console.WriteLine("Number After First Call {0}", number);
            number = clinet.IncrementNumber();
            Console.WriteLine("Number After Second Call {0}", number);
            number = clinet.IncrementNumber();
            Console.WriteLine("Number After Third Call {0}", number);

            Console.WriteLine("Session Id: {0}",clinet.InnerChannel.SessionId);
            Console.ReadLine();
        }
    }
}
