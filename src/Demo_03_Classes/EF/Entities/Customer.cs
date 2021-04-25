using System;
using System.Collections.Generic;

namespace Demo_03_Classes.EF.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime? VIPSince { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public int? CustomerMetaDataId { get; set; }
        //Nullable navigation properties can just be declared as nullable
        public CustomerMetaData? CustomerMetaData { get; set; }

        public int PreferredLanguageId { get; set; }

        Language? _preferredLanguage;
        public Language PreferredLanguage
        {
            get => _preferredLanguage ??
                 throw new InvalidOperationException($"Uninitialized non-nullable property {nameof(PreferredLanguage)}");
            set => _preferredLanguage = value;
        }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}