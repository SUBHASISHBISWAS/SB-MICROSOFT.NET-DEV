using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WPFBasic_FirstPrismEx;

namespace InputOutputLibrary
{
    public class MessageBoxOutputService:IOutputService
    {

        public void WriteMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
