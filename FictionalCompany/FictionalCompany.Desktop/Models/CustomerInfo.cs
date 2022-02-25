namespace FictionalCompany.Desktop.Models
{
    public sealed class CustomerInfo
    {
        public static CustomerInfo Empty = new CustomerInfo();

        private CustomerInfo()
        {
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public decimal Sales { get; set; }

        public static CustomerInfo Create(
            string name,
            string surname,
            string email,
            decimal sales)
        {
            return new CustomerInfo
            {
                Name = name,
                Surname = surname,
                Email = email,
                Sales = sales
            };
        }
    }
}
