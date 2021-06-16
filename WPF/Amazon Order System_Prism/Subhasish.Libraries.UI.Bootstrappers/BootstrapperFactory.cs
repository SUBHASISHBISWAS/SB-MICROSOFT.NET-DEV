using Microsoft.Practices.Prism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.UI.Bootstrappers
{
    public class BootstrapperFactory
    {
        public static Bootstrapper Create(BootstrapperType bootstrapperType)
        {
            var bootstrapper = default(Bootstrapper);

            switch (bootstrapperType)
            {
                case BootstrapperType.OrderSystem:
                    bootstrapper = new OrderSystemBootstrapper();
                    break;
                default:
                    throw new ArgumentException("Invalid Bootstrapper Type Specified!");
            }

            return bootstrapper;
        }
    }
}
