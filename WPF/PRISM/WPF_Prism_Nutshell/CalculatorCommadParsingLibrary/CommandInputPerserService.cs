using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFBasic_FirstPrismEx
{
    public class InputPerserService : IInputPerserService
    {
        public CommandTypes ParseCommand(string command)
        {
            return (CommandTypes) Enum.Parse(typeof (CommandTypes), command);
        }
    }
}
