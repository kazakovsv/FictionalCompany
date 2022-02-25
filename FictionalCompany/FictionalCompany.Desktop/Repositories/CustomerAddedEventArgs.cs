using System;

using FictionalCompany.Desktop.Models;

namespace FictionalCompany.Desktop.Repositories
{
    public class CustomerAddedEventArgs : EventArgs
    {
        public CustomerAddedEventArgs(CustomerInfo customer)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public CustomerInfo Customer { get; }
    }
}