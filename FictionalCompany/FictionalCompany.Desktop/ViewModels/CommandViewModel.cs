using System;
using System.Windows.Input;

namespace FictionalCompany.Desktop.ViewModels
{
    public class CommandViewModel : BaseViewModel
    {
        public CommandViewModel(ICommand command, string text)
        {
            Command = command ?? throw new ArgumentNullException(nameof(command));
            Text = text;
        }

        public ICommand Command { get; }
    }
}
