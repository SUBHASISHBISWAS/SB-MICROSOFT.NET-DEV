using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.UI.Infrastructure.Core
{
    public interface IApplicationService
    {
        void Shutdown();
        string UserName { get;}
    }
}
