using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using WPFBasic_FirstPrismEx;

namespace InputOutputLibrary
{
    public class InputOutputModule:IModule
    {
        private IUnityContainer container;
        public InputOutputModule(IUnityContainer container)
        {
            this.container = container;
        }
        public void Initialize()
        {
            container.RegisterType<IInputService, ConsoleInputService>();
            container.RegisterType<IOutputService, ConsoleOutputService>("OutputService-1");
            container.RegisterType<IOutputService, MessageBoxOutputService>("OutputService-2");
        }
    }
}
