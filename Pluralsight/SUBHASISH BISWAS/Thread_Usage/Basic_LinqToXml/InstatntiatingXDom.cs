using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LINQ_TO_XML
{
    class InstatntiatingXDom
    {
        public static void Main()
        {
            //XElement lastName = new XElement("lastname", "Bloggs");
            //lastName.Add(new XComment("nice name"));

            //XElement customer = new XElement("customer");
            //customer.Add(new XAttribute("id", 123));
            //customer.Add(new XElement("firstname", "Joe"));
            //customer.Add(lastName);

            //Console.WriteLine(customer.ToString());

            XElement customer = new XElement("Customer", new XAttribute("id", "123"), 
                new XElement("firstName", "joe"), 
                new XElement("lastName", "hofer", new XComment("nice name")));

            var address = new XElement("address",
                      new XElement("street", "Lawley St"),
                      new XElement("town", "North Beach")
                  );

            var customer1 = new XElement("Customer", address);
            var customer2 = new XElement("customer2", address);

            Console.WriteLine(customer1.ToString());

            //XElement query =new XElement("customers",from c in dataContext.Customers select
            //            new XElement("customer", new XAttribute("id", c.ID),
            //            new XElement("firstname", c.FirstName), new XElement("lastname", c.LastName,
            //            new XComment("nice name"))));
        }
       
    }
}
