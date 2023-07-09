using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;

namespace AsyncWebExample
{
    public class MyAsyncHandler : IHttpAsyncHandler
    {
        public bool IsReusable { get { return false; } }
        public void ProcessRequest(HttpContext context) { throw new NotSupportedException(); }



        public async Task ProcessRequestAsync(HttpContext context)
        {
            string symbol = context.Request.QueryString["symbol"];
            Quote quote = await Quote.GetQuote(symbol);

            var ser = new DataContractJsonSerializer(typeof(Quote));

            context.Response.ContentType = "application/json";
            ser.WriteObject(context.Response.OutputStream, quote);
        }

        public IAsyncResult BeginProcessRequest(
            HttpContext context, AsyncCallback cb, object extraData)
        {
            var getTask = ProcessRequestAsync(context);
            var tcs = new TaskCompletionSource<object>(extraData);
            getTask.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        tcs.SetException(t.Exception.InnerExceptions);
                    }
                    else
                    {
                        tcs.SetResult(null);
                    }
                    if (cb != null)
                    {
                        cb(tcs.Task);
                    }
                });
            return tcs.Task;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            var t = (Task) result;
            t.Wait();
        }
    }
}