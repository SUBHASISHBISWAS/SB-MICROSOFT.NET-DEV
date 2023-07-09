using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ad1=AppDomain.CreateDomain("Ad1");
        }
    }
}
