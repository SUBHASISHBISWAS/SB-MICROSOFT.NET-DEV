using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread_SynchronizationContextExample
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            Trace.WriteLine(String.Format("UI ThreadID:{0}", id));
            var uiContext = SynchronizationContext.Current;
            Thread thread = new Thread(Run);
            thread.Start(uiContext);
        }

        private void Run(object obj)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            Trace.WriteLine("Worker ThreadID: " + id);

            var uiContext = obj as SynchronizationContext;

            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(1000);
                try
                {
                    uiContext.Send(UpdateUI, "line" + i.ToString());
                }
                catch (Exception e)
                {

                    Trace.WriteLine(e.Message);
                    MessageBox.Show("Test");
                }
               
            }

        }

        private void UpdateUI(object state)
        {

            int id = Thread.CurrentThread.ManagedThreadId;
            Trace.WriteLine("UpdateUI on threadID:" + id);
            string text = state as string;
            listBox1.Items.Add(text);

            //throw new Exception("Boom");
        }
    }


   
}
