using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LINQ_TO_XML
{
    class Program
    {
        //static void Main(string[] args)
        //{

        //    XElement config = XElement.Parse(@"<configuration><client enabled='true'><timeout>30</timeout></client></configuration>");

        //    XElement client = config.Element("client");
        //    bool enabled = (bool)client.Attribute("enabled");// Read attribute
        //    Console.WriteLine(enabled);// True
            
        //    client.Attribute("enabled").SetValue(!enabled);// Update attribute

        //    int timeout = (int)client.Element("timeout");// Read element
        //    Console.WriteLine(timeout);

        //    client.Element("timeout").SetValue(timeout * 2);// Update element

        //    client.Add(new XElement("reteries", "3"));// Add new element

        //    Console.WriteLine(config); // Implicitly call config.ToString()

        //}
    }
}
