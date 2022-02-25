using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using FictionalCompany.Desktop.Repositories;

namespace FictionalCompany.Desktop.ViewModels
{
    public class CustomersViewModel : WorkspaceViewModel
    {
        private readonly CustomerRepository _customerRepository;

        public CustomersViewModel(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository
                ?? throw new ArgumentNullException(nameof(customerRepository));

            _customerRepository.CustomerAdded += OnCustomerAdded;
            LoadCustomers();

            Text = "Customers";
        }

        public ObservableCollection<CustomerViewModel> Customers { get; private set; }

        private void OnCustomerAdded(object sender, CustomerAddedEventArgs e)
        {
            var customerViewModel = new CustomerViewModel(e.Customer, _customerRepository);
            Customers.Add(customerViewModel);
        }

        private void LoadCustomers()
        {
            List<CustomerViewModel> customers = _customerRepository
                .GetCustomers()
                .Select(customer => new CustomerViewModel(customer, _customerRepository))
                .ToList();

            Customers = new ObservableCollection<CustomerViewModel>(customers);
        }
    }
}
