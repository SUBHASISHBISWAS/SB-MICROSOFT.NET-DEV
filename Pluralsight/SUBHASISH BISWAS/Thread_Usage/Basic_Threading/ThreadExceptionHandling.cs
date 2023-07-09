using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class ThreadExceptionHandling
    {
        //public static void Main()
        //{
        //    //try
        //    //{
        //    //    Thread t = new Thread(Go);
        //    //    t.Start();
        //    //}
        //    //catch (Exception)
        //    //{

        //    //    Console.WriteLine("Exception");
        //    //}

        //    Thread t = new Thread(Go);
        //    t.Start();

        //}

        static void Go()
        {
            try
            {
                throw null;
            }
            catch (Exception)
            {

                Console.WriteLine("Exception");
            }
            
        }
    }
}
