using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.UI.Infrastructure.Core
{
    public interface IUserInteractionService
    {
        bool ShowConfirmation(string message, string title = default(string));
    }
}
