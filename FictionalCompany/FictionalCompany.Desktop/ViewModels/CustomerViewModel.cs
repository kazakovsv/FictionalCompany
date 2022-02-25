using System;
using System.Windows.Input;

using FictionalCompany.Desktop.Commands;
using FictionalCompany.Desktop.Models;
using FictionalCompany.Desktop.Repositories;

namespace FictionalCompany.Desktop.ViewModels
{
    public class CustomerViewModel : WorkspaceViewModel
    {
        private readonly CustomerInfo _customer;
        private readonly CustomerRepository _customerRepository;
        private bool _isSelected;

        public CustomerViewModel(CustomerInfo customer, CustomerRepository customerRepository)
        {
            _customer = customer
                ?? throw new ArgumentNullException(nameof(customer));
            _customerRepository = customerRepository
                ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public string Name
        {
            get => _customer.Name;
            set
            {
                if (_customer.Name == value)
                    return;

                _customer.Name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _customer.Surname;
            set
            {
                if (_customer.Surname == value)
                    return;

                _customer.Surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _customer.Email;
            set
            {
                if (_customer.Email == value)
                    return;

                _customer.Email = value;
                OnPropertyChanged();
            }
        }

        public decimal Sales
        {
            get => _customer.Sales;
            set
            {
                if (_customer.Sales == value)
                    return;

                _customer.Sales = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value)
                    return;

                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; private set; }

        public override string Text => IsNewCustomer
            ? "New Customer" : $"{_customer.Name}, {_customer.Surname}";

        public bool IsNewCustomer => !_customerRepository.ContainsCustomer(_customer);

        protected override void RegisterCommands()
        {
            base.RegisterCommands();

            SaveCommand = new DelegateCommand(OnSave, CanSave);
        }

        private bool CanSave()
        {
            return true;
        }

        private void OnSave()
        {
            if (IsNewCustomer)
                _customerRepository.AddCustomer(_customer);

            OnPropertyChanged(nameof(Text));
        }
    }
}
