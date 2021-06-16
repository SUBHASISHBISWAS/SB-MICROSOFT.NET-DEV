using Subhasish.Libraries.UI.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Subhasish.Libraries.UI.Infrastructure.WPF
{
    public class WPFUserInteractionService : IUserInteractionService
    {
        public bool ShowConfirmation(string message, string title = null)
        {
            var caption = string.IsNullOrEmpty(title) ? "Confirmation" : title;
            var messageBoxResult = MessageBox.Show(message, caption, MessageBoxButton.OKCancel);

            return messageBoxResult == MessageBoxResult.OK;
        }
    }
}
