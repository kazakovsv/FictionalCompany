using System;
using System.Collections.Generic;

using FictionalCompany.Desktop.Models;

namespace FictionalCompany.Desktop.Repositories
{
    public class CustomerRepository
    {
        private readonly List<CustomerInfo> _customers;

        public CustomerRepository()
        {
            _customers = new List<CustomerInfo>
            {
                CustomerInfo.Create("Name 1", "Surname 1", "Email 1", 100M),
                CustomerInfo.Create("Name 2", "Surname 2", "Email 2", 200M),
                CustomerInfo.Create("Name 3", "Surname 3", "Email 3", 300M),
                CustomerInfo.Create("Name 4", "Surname 4", "Email 4", 400M),
                CustomerInfo.Create("Name 5", "Surname 5", "Email 5", 500M),
            };
        }

        public event EventHandler<CustomerAddedEventArgs> CustomerAdded;

        protected virtual void OnCustomerAdded(CustomerAddedEventArgs e)
        {
            CustomerAdded?.Invoke(this, e);
        }

        public IEnumerable<CustomerInfo> GetCustomers()
        {
            foreach (CustomerInfo customer in _customers)
            {
                yield return customer;
            }
        }

        public void AddCustomer(CustomerInfo customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            if (_customers.Contains(customer))
            {
                return;
            }

            _customers.Add(customer);
            OnCustomerAdded(new CustomerAddedEventArgs(customer));
        }

        public bool ContainsCustomer(CustomerInfo customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            return _customers.Contains(customer);
        }
    }
}
