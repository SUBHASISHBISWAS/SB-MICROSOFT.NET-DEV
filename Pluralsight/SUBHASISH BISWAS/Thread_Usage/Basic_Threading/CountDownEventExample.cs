using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class CountDownEventExample
    {
        EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.AutoReset, "MyCompany.MyApp.SomeName");
        static CountdownEvent countdown = new CountdownEvent(3);
        static void Main()
        {
            new Thread(SaySomeThing).Start("I am thread 1");
            new Thread(SaySomeThing).Start("I am thread 2");
            new Thread(SaySomeThing).Start("I am thread 3");
            countdown.Wait();
            Console.WriteLine("All Thread have finished speaking");
        }

        static void SaySomeThing(object thing)
        {
            Thread.Sleep(1000);
            Console.WriteLine(thing);
            countdown.Signal();
        }
    }
}
