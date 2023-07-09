using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Library10;

namespace Client10
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMath m1 = new MyMath();

            double result = m1.Sum(10, 20);

            Console.WriteLine(result);
        }
    }
}
