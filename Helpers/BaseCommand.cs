using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERPNavi.Helpers
{
    public class BaseCommand : ICommand
    {
        private readonly Action _command;
    private readonly Func<bool> _canExecute;
    public BaseCommand(Action command, Func<bool> canExecute = null)
    {
        if (command == null)
            throw new ArgumentNullException("command");
        _canExecute = canExecute;
        _command = command;
    }
    public void Execute(object parameter)
    {
        _command();
    }
    public bool CanExecute(object parameter)
    {
        if (_canExecute == null)
            return true;
        return _canExecute();
    }
    public event EventHandler CanExecuteChanged;






    //#region  Command
    //public delegate void CommandDelegate();
    //protected BaseCommand GetCommand(BaseCommand baseCommand, CommandDelegate function)
    //{
    //    if (baseCommand == null)
    //    {
    //        baseCommand = new BaseCommand(() => function());
    //    }
    //    return baseCommand;
    //}
  //  #endregion  //Command
}
}
