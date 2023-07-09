using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    //class ThreadForegroungAndBackground
    //{
    //    public static void Main(string[] args)
    //    {
    //        Thread t = new Thread(() => Console.ReadLine());
    //        if (args.Length>0)
    //        {
    //            t.IsBackground = true;
    //        }
    //        t.Start();

    //        Console.WriteLine("Main Exist");
    //    }

    //    public static Int32 Max(Int32 val1, Int32 val2)
    //    {
    //        return (val1 < val2) ? val2 : val1;
    //    }
    //}

    //class Program
    //{

    //    volatile bool _loop = true;
    //    //static void Main(string[] args)
    //    //{
    //    //    Program o1 = new Program();
    //    //    Thread t1 = new Thread(SomeThread);
    //    //    t1.Start(o1);
    //    //    Thread.Sleep(2000);
    //    //    o1._loop = false;
    //    //    Console.WriteLine("Value Set to false");
    //    //}
    //    private static void SomeThread(object o1)
    //    {
    //        Program o = (Program)o1;
    //        Console.WriteLine("Loop Starting...");
    //        while (o._loop)
    //        { }
    //        Console.WriteLine("Loop Stopping...");
    //    }
    //}
}
