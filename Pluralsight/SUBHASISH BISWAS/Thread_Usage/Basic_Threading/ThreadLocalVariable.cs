using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class ThreadLocalVariable
    {

        //public static void Main()
        //{
        //    Thread t = new Thread(Go);
        //    t.Start();
        //    Go();
        //}

        static void Go()
        {
            for (int cycle = 0; cycle < 5; cycle++)
            {
                Console.WriteLine("?");
            }
        }
    }
}
