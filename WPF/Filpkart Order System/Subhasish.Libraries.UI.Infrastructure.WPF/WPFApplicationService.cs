using Subhasish.Libraries.UI.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Subhasish.Libraries.UI.Infrastructure.WPF
{
    public class WPFApplicationService : IApplicationService
    {
        public string UserName
        {
            get
            {
                return Environment.UserName;
            }
        }

        public void Shutdown()
        {
            Application.Current.Shutdown();
        }
    }
}
