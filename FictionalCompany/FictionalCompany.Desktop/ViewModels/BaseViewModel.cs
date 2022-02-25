using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FictionalCompany.Desktop.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public virtual string Text { get; protected set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
