using System.Windows;

using FictionalCompany.Desktop.Repositories;
using FictionalCompany.Desktop.ViewModels;
using FictionalCompany.Desktop.Views;

namespace FictionalCompany.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CustomerRepository customerRepository = new CustomerRepository();

            MainView mainView = new MainView();
            MainViewModel mainViewModel = new MainViewModel(customerRepository);

            mainView.DataContext = mainViewModel;
            mainView.Show();
        }
    }
}
