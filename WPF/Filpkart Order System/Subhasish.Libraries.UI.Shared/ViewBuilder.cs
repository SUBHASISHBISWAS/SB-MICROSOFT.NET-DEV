using Subhasish.Libraries.UI.Framework;
using Subhasish.Libraries.UI.Utilities.Impl;
using Subhasish.Libraries.UI.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Subhasish.Libraries.UI.Shared
{
    public class ViewBuilder
    {
        public static T Build<T>(string viewName, bool isViewModelAvailable = default(bool))
            where T : FrameworkElement
        {
            var containerManager = ContainerManager.Current;
            var viewObject = default(Window);

            if (!string.IsNullOrEmpty(viewName) &&
               containerManager != default(IContainerManager))
            {
                viewObject = containerManager.GetInstance<Window>(viewName);
                if (viewObject != default(Window) && isViewModelAvailable)
                {
                    var viewModelName = string.Format(@"{0}Model", viewName);
                    var viewModel = containerManager.GetInstance<BaseViewModel>(viewModelName);
                    if (viewModel != default(BaseViewModel))
                    {
                        viewObject.DataContext = viewModel;
                    }
                }
            }

            return viewObject as T;
        }
    }
}
