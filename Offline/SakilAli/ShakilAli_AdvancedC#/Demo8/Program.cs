using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Demo8
{
    class WindowsLibrary
    {
        [DllImport("windowslibrary.dll")]
        public static extern double sum(double x, double y);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WindowsLibrary.sum(10.5, 20.5));
        }
    }
}
