using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.UI.Utilities.Interfaces
{
    public interface IContainerManager
    {
        T GetInstance<T>();

        object GetInstance(Type serviceType);

        T GetInstance<T>(string serviceName);

        object GetInstance(Type serviceType, string serviceName);
    }
}
