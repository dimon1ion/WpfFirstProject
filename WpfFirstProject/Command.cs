using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfFirstProject
{
    abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual void OnCanExecuteChanged(EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }
        public void RiseOnCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }
        public virtual bool CanExecute()
        {
            return true;
        }
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }
        void ICommand.Execute(object parameter)
        {
            Execute();
        }
        public abstract void Execute();
    }


    class DelegateCommand : Command
    {
        static Func<bool> defaultCanExecuteChanged = () => true;
        Func<bool> canExecuteMethod;
        Action executeMethod;

        public DelegateCommand(Action executeMethod) : this(executeMethod, defaultCanExecuteChanged)
        {

        }
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public override bool CanExecute()
        {
            return canExecuteMethod();
        }
        public override void Execute()
        {
            executeMethod();
        }
    }
}
