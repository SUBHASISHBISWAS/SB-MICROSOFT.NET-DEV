using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class ThreadCommonDataSharing
    {
        bool done;

        //static void Main()
        //{
        //    ThreadCommonDataSharing aThreadCommonDataStaringinstance = new ThreadCommonDataSharing();//create a common instance
        //    Thread t = new Thread(aThreadCommonDataStaringinstance.Go);
        //    t.Start();
        //}

        void Go()
        {
            if (!done)
            {
                done = true;
                Console.WriteLine("Done");
            }
        }
    }
}
