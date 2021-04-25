using System;

namespace Demo_06_Oopsies
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime? VIPSince { get; set; }

        public Customer(int id, string firstname, string lastname)
            : this(id, firstname, lastname, null, null)
        { }

        public Customer(int id, string firstname, string lastname, string? middlename, DateTime? vipSince)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            MiddleName = middlename;
            VIPSince = vipSince;
        }

        public override string ToString()
        {
            string? postfix = null;

            if(VIPSince.HasValue)
            {
                postfix = $" | VIP since: {VIPSince.Value:dd/MM/yyyy}";
            }

            return $"[{Id}] {FirstName} {MiddleName} {LastName}{postfix}";
        }
    }
}
