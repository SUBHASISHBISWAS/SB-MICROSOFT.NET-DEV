using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceHost
{
    public partial class HelloWindowsService : ServiceBase
    {
        ServiceHost host;
        public HelloWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(HelloService.HelloService));
            host.Open();
            Console.WriteLine("Host Started:{0}", DateTime.Now.ToString());
            Console.ReadLine();
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
