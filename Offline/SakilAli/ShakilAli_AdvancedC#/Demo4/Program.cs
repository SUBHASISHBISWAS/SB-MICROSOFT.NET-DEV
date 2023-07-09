using System;
using System.Collections.Generic;

using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition; // ComposeParts Extension Method

using System.IO;
using System.Linq;
using System.Text;

using SenderLibrary; // for ISender

namespace Demo4
{
    class MessageSender
    {
        [ImportMany(typeof(ISender))]
        public List<ISender> Senders { get; set; }

        public void Start()
        {
            while (true)
            {
                for (int i = 0; i < Senders.Count ; i++)
                {
                    Console.WriteLine("{0}: {1}", i+1, Senders[i].GetName());
                }

                Console.Write("Select the sender: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the message: ");
                string message = Console.ReadLine();

                Senders[choice-1].SendMessage(message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DirectoryCatalog dir = new DirectoryCatalog("sender");
                CompositionContainer container = new CompositionContainer(dir);

                MessageSender sender = new MessageSender();
                container.ComposeParts(sender);

                sender.Start();
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Sender folder is not present");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Implementation Found...");
            }
        }
    }
}
