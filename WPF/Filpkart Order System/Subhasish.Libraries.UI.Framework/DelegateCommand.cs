using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Subhasish.Libraries.UI.Framework
{
    public class DelegateCommand : ICommand
    {
        private Action action = default(Action);
        private Predicate<object> condition = default(Predicate<object>);

        public DelegateCommand(Action action,Predicate<object> predicate=default(Predicate<Object>))
        {
            this.action = action;
            this.condition = predicate;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.condition == default(Predicate<object>) ? true : this.condition(parameter);
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
