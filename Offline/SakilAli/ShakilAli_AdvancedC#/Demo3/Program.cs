using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Demo3
{
    class ElementDynamicObject : DynamicObject
    {
        private XElement _element;
        private string _ns; 

        public ElementDynamicObject(XElement element, string ns)
        {
            _element = element;
            _ns = ns ;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _element.Element(XName.Get(binder.Name,_ns)).Value;
            return true;
        }
    }

    static class MyExtensions
    {
        public static IEnumerable<dynamic> GetDynamic ( this XElement doc, string elementName )
        {
            string ns = doc.GetDefaultNamespace().NamespaceName;
            IEnumerable<XElement> elements = doc.Descendants(XName.Get(elementName, ns));

            foreach (XElement element in elements)
            {
                yield return new ElementDynamicObject(element, ns);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //XElement doc = XElement.Load("books.xml"); // DOM Parser
            
            IEnumerable<dynamic> doc = XElement.Load("questions.xml").GetDynamic("question"); // DOM Parser
            //string ns = doc.GetDefaultNamespace().NamespaceName;

            //var query = from element in doc.Descendants(XName.Get("book", ns))
            //            where element.Element(XName.Get("author", ns)).Value == "a2"
            //            select element.Element(XName.Get("title", ns)).Value;

            var query = from element in doc
                        where element.answer == "2"
                        select element.statement;

            foreach (string title in query)
            {
        
                Console.WriteLine(title);
            }
        }
    }
}
