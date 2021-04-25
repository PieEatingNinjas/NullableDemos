using System;

namespace Demo_03_Classes.EF.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }

        Customer? _customer;
        public Customer Customer
        {
            get => _customer ??
                 throw new InvalidOperationException($"Uninitialized non-nullable property {nameof(Customer)}");
            set => _customer = value;
        }

        public Order(DateTime date, string description)
        {
            Date = date;
            Description = description;
        }
    }
}