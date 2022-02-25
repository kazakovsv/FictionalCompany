using System;
using System.Windows.Input;

using FictionalCompany.Desktop.Commands;

namespace FictionalCompany.Desktop.ViewModels
{
    public abstract class WorkspaceViewModel : BaseViewModel
    {
        protected WorkspaceViewModel()
        {
            RegisterCommands();
        }

        #region RequestClose Event

        public event EventHandler RequestClose;

        protected virtual void OnRequestClose(EventArgs e)
        {
            RequestClose?.Invoke(this, e);
        }

        #endregion

        public ICommand CloseCommand { get; private set; }

        protected virtual void RegisterCommands()
        {
            CloseCommand = new DelegateCommand(OnClose);
        }

        private void OnClose()
        {
            OnRequestClose(EventArgs.Empty);
        }
    }
}
