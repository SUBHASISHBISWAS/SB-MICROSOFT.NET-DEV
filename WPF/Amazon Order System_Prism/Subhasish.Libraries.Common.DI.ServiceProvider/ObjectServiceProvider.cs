using Subhasish.Libraries.Common.DI.Interfaces;
using Subhasish.Libraries.DI.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.Common.DI.ServiceProvider
{
    public class ObjectServiceProvider
    {
        public static IObjectService GetObjectService()
        {
            return SubhasishObjectService.Current;
        }
    }
}
