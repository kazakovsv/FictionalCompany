using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

using FictionalCompany.Desktop.Commands;
using FictionalCompany.Desktop.Models;
using FictionalCompany.Desktop.Repositories;

namespace FictionalCompany.Desktop.ViewModels
{
    public class MainViewModel : WorkspaceViewModel
    {
        private readonly CustomerRepository _customerRepository;

        public MainViewModel(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository
                ?? throw new ArgumentNullException(nameof(customerRepository));

            Workspaces = new ObservableCollection<WorkspaceViewModel>();
            Commands = new ObservableCollection<CommandViewModel>();

            Initialize();
        }

        private void Initialize()
        {
            Commands.Add(new CommandViewModel(
                new DelegateCommand(OnShowCustomers),
                "Show Customers"));

            Commands.Add(new CommandViewModel(
                new DelegateCommand(OnCreatNewCustomer),
                "New Customer"));

            Workspaces.CollectionChanged += OnWorkspacesCollectionChanged;
        }

        private void OnWorkspacesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= OnWorkspaceRequestClose;
        }

        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            Workspaces.Remove(workspace);
        }

        public ObservableCollection<WorkspaceViewModel> Workspaces { get; }

        public ObservableCollection<CommandViewModel> Commands { get; }

        private void OnCreatNewCustomer()
        {
            CustomerInfo customer = CustomerInfo.Empty;
            CustomerViewModel workspace = new CustomerViewModel(
                customer, _customerRepository);
            Workspaces.Add(workspace);
            ActivateWorkspace(workspace);
        }

        private void OnShowCustomers()
        {
            CustomersViewModel workspace =
                Workspaces.FirstOrDefault(vm => vm is CustomersViewModel)
                as CustomersViewModel;

            if (workspace == null)
            {
                workspace = new CustomersViewModel(_customerRepository);
                Workspaces.Add(workspace);
            }

            ActivateWorkspace(workspace);
        }

        private void ActivateWorkspace(WorkspaceViewModel workspace)
        {
            ICollectionView collectionView = CollectionViewSource
                .GetDefaultView(Workspaces);

            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
    }
}
