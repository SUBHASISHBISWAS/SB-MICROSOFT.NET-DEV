using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.ORM.Interfaces
{
    public interface  ISystemContext:IDisposable
    {
        IEnumerable<T> ExecuteRoutine<T>(string routineName, 
            IDictionary<string, object> parameter = default(IDictionary<string, object>));


        void Commit();
    }
}
