using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.Common.DI.Interfaces
{
    public interface IObjectService
    {
        T GetObject<T>();

        object GetObject(Type serviceType);

    }
}
