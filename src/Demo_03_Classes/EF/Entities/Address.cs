using System;

namespace Demo_03_Classes.EF.Entities
{
    public class Address
    {
        public int Id { get; set; }
        //In nullable annotations context, we don't need the Required attribute to inform Entity Framework about the fact a property is required.
        //In nullable annotations context, EF will understand that a non-nullable reference type is required.
        public string FullAddress { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }

        public int CustomerId { get; set; }

        //Non-nullable navigation properties can have nullable backing field so we can throw a specific exception
        //The only way this could be null, is when the developer forgot this property to be included to be eagerly loaded (if you do eagerly loading of course)
        Customer? _customer;
        public Customer Customer
        {
            get => _customer ??
                throw new InvalidOperationException($"Uninitialized non-nullable property {nameof(Customer)}");
            set => _customer = value;
        }

        public int CountryId { get; set; }

        Country? _country;
        public Country Country
        {
            get => _country ??
                 throw new InvalidOperationException($"Uninitialized non-nullable property {nameof(Country)}");
            set => _country = value;
        }

        //EF constructor mapping
        public Address(string fullAddress, string description)
        {
            FullAddress = fullAddress;
            Description = description;
        }
    }
}