using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Logging;

namespace Modularity
{
    public class CallBackLogger:ILoggerFacade
    {
        private Queue<Tuple<String,Category,Priority>> savedLogs=new Queue<Tuple<string, Category, Priority>>();
        private Action<String, Category, Priority> callback;

        public Action<string, Category, Priority> Callback
        {
            get
            {
                return callback;
            }
            set
            {
                callback = value;
            }
        }

        public void Log(string message, Category category, Priority priority)
        {
            if( Callback!=null )
            {
                Callback( message, category, priority );
            }
            else
            {
                savedLogs.Enqueue(new Tuple<String, Category, Priority>(message, category, priority));
            }
        }

        public void ReplySavedLogs()
        {
            if( Callback!=null )
            {
                while( savedLogs.Count>0 )
                {
                    var log = savedLogs.Dequeue();
                    Callback( log.Item1, log.Item2, log.Item3 );
                }
            }
        }
    }
}
