using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncWebExample
{
    public class Quote
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double LastTrade { get; set; }

        public static async Task<Quote> GetQuote(string id)
        {
            string url = "http://finance.yahoo.com/d/quotes.csv?s=" + id + "&f=snl1";
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
}