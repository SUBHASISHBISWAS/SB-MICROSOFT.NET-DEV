using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFBasic_FirstPrismEx
{
    public class ConsoleOutputService:IOutputService
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
