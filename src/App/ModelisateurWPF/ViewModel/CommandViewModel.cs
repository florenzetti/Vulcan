using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ModelisateurWPF.ViewModel
{
    class CommandViewModel : ViewModelBase
    {
        public ICommand Command { get; private set; }

        public CommandViewModel(string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            
            Command = command;
            DisplayName = displayName;
        }
    }
}