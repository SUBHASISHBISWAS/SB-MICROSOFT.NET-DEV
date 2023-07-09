using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetStockQuote
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = ShowQuotes(new[] { "MSFT", "GOOG" });
            task.Wait();
         }

        static async Task ShowQuotes(IEnumerable<string> symbols)
        {
            foreach (string symbol in symbols)
            {
                Quote q = await GetQuote(symbol);
                Console.WriteLine("{0} ('{1}'): {2}", q.Name, q.Symbol, q.LastTrade);
            }
        }


        static async Task<Quote> GetQuote(string id)
        {
            string url = "http://finance.yahoo.xcom/d/quotes.csv?s=" + id + "&f=snl1";
            string response = await new WebClient().DownloadStringTaskAsync(url);
            string[] parts = response.Split(',');
            return new Quote
            {
                Symbol = parts[0].Trim('\"'),
                Name = parts[1].Trim('\"'),
                LastTrade = double.Parse(parts[2])
            };
        }
    }

    class Quote
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double LastTrade { get; set; }
    }
}
