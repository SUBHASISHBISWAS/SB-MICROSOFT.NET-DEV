using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread_SynchronizationContextExample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var context = SynchronizationContext.Current;
            //if (context==null)
            //{
            //    MessageBox.Show("No Context For thos thread");
            //}
            //else
            //{
            //    MessageBox.Show("We got a context");
            //}
            //Form1 form = new Form1();

            //// let's check it again after creating a form
            //context = SynchronizationContext.Current;

            //if (context == null)
            //    MessageBox.Show("No context for this thread");
            //else
            //    MessageBox.Show("We got a context");

            //if (context == null)
            //    MessageBox.Show("No context for this thread");

            Application.Run(new Form1());

            
        }
    }
}
