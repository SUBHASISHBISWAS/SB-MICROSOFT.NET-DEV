using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class ThreadDataPassing
    {
        //public static void Main()
        //{

        //    Thread t = new Thread(Print);
        //    t.Start("Hello From T");

        //}

        static void Print(object messageObj)
        {
            string message = (string)messageObj;// We need to cast here
            Console.WriteLine(message);
        }
    }
}
