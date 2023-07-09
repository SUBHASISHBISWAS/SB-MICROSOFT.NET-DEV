using SenderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;

// for MEF
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Demo5
{
    class Intermediate : MarshalByRefObject
    {
        [ImportMany(typeof(ISender))]
        public List<ISender> Senders { get; set; }

        public void Start()
        {
            Compose();
            //Assembly asm = Assembly.LoadFile(Environment.CurrentDirectory + @"\sender\EmailSenderLibrary.dll");
            //Type type = asm.GetType("EmailSenderLibrary.EmailSender");
            //Sender = Activator.CreateInstance(type) as ISender;
          
            while (true)
            {
                for (int i = 0; i < Senders.Count; i++)
                {
                    Console.WriteLine("{0}: {1}", i + 1, Senders[i].GetName());
                }

                Console.Write("Select the sender: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the message: ");
                string message = Console.ReadLine();

                Senders[choice - 1].SendMessage(message);
            }
        }

        public void Compose()
        {
            DirectoryCatalog dir = new DirectoryCatalog("sender");
            CompositionContainer container = new CompositionContainer(dir);
            container.ComposeParts(this);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            AppDomain ad1 = AppDomain.CreateDomain("ad1");
            Intermediate proxy = ad1.CreateInstanceAndUnwrap("Demo5", "Demo5.Intermediate")
                                as Intermediate;

            //bool result = RemotingServices.IsTransparentProxy(it);
            //Console.WriteLine(result);
            //AppDomain.Unload(ad1);


            proxy.Start();

            AppDomain.Unload(ad1);
        }
    }
}
