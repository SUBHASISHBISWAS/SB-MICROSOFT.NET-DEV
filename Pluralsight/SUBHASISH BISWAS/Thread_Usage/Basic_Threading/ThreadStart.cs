using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class ThreadStart
    {
        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(WriteY);
        //    t.Start();
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Console.WriteLine("X");
        //    }
        //}

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Y");
            }
            
        }

    }
}
