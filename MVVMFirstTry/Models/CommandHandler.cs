using System;
using System.Windows.Input;

namespace MVVMFirstTry.Models
{
    public class CommandHandler : ICommand
    {
        Action<object> executeAction;
        Func<object, bool> canExecute;
        bool canExecuteCache;

        public CommandHandler(Action<object> _action,Func<object,bool> _func,bool canExec)
        {
            this.executeAction = _action;
            this.canExecute = _func;
            this.canExecuteCache=canExec;
        }
        public bool CanExecute(object? parameter)
        {
            if (canExecute == null)
            {
                return true;

            }
            else
            {
                return canExecute(parameter);
            }
        }
        public event EventHandler? CanExecuteChanged
        {
            add
            {

                CommandManager.RequerySuggested += value;

            }
            remove
            {

                CommandManager.RequerySuggested -= value;

            }
        }

        public void Execute(object? parameter)
        {
            executeAction(parameter);
        }
    }
}
