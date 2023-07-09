using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SenderLibrary
{
    public interface ISender
    {
        string GetName();
        void SendMessage(string message);
    }
}
