using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Subhasish.Libraries.UI.Framework
{
    public abstract class Bootstrapper
    {
        public abstract void Initialize();
        public abstract DependencyObject CreateMainWindow();

        public void Run()
        {
            Initialize();
            var mainWindow = CreateMainWindow() as Window;
            if (mainWindow!=default(Window))
            {
                Application.Current.MainWindow = mainWindow;
            }
        }
    }
}
