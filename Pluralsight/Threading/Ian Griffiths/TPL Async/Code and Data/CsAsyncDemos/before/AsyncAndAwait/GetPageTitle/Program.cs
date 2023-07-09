using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetPageTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = GetTitle(
                "http://www.pluralsight-training.net/microsoft/Products/Individual");
            Console.WriteLine(title);
        }

        static string GetTitle(string url)
        {
            using (var w = new WebClient())
            {
                string content = w.DownloadString(url);
                return ExtractTitle(content);
            }
        }

        private static string ExtractTitle(string content)
        {
            const string TitleTag = "<title>";
            var comp = StringComparison.InvariantCultureIgnoreCase;
            int titleStart = content.IndexOf(TitleTag, comp);
            if (titleStart < 0)
            {
                return null;
            }
            int titleBodyStart = titleStart + TitleTag.Length;
            int titleBodyEnd = content.IndexOf("</title>", titleBodyStart, comp);
            return content.Substring(titleBodyStart, titleBodyEnd - titleBodyStart);
        }
    }
}
