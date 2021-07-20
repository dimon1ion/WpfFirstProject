﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfFirstProject.Service.Command
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> exec, Func<bool> canExec)
        {
            this.exec = exec;
            this.canExec = canExec;
        }
        public RelayCommand(Action<object> exec)
        {
            this.exec = exec;
            this.canExec = () => true;
        }

        private Action<object> exec;
        private Func<bool> canExec;



        public bool CanExecute(object parameter)
        {
            return this.canExec();
        }

        public void Execute(object parameter)
        {
            this.exec(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
