using Subhasish.Libraries.UI.Framework;
using Subhasish.Libraries.UI.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Subhasish.Libraries.UI.Bootstrappers
{
    public class OrderSystemBootstrapper : Bootstrapper
    {
        private string mainViewName = default(string);

        public override DependencyObject CreateMainWindow()
        {
            var mainView = default(Window);

            if (!string.IsNullOrEmpty(mainViewName))
            {
                mainView = ViewBuilder.Build<Window>(mainViewName, isViewModelAvailable: true);
                if (mainView != default(Window))
                    mainView.Show();
            }

            return mainView;
        }

        public override void Initialize()
        {
            this.mainViewName = ConfigurationManager.AppSettings["MainViewName"];
        }
    }
}
