using System;

namespace Demo_02_EnableNullable
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter customer id");

                var input = Console.ReadLine();

                Customer? customer = null;

                if (int.TryParse(input, out int id))
                {
                    customer = CustomerRepository.GetCustomer(id);

                    if (customer is not null)
                    {
                        PrintCustomer(customer);
                    }
                }

                Console.Read();
            }
        }

        private static void PrintCustomer(Customer customer)
        {
            if (HasMiddleName(customer))
            {
                //Null-forgiving needed as analyzer doesn't understand the 'HasMiddleName' method does a null check
                //Alternatively could call customer.HasMiddleName which, thanks to the MemberNotNull attribute, understands
                //that MiddleName is not null when returning true, so in that case we can remove the null forgiving operator.
                //Works also for properties.
                Console.WriteLine($"{customer.FirstName} {customer.MiddleName!.ToUpper()} {customer.LastName}");
            }
            else
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");

            if (customer.VIPSince.HasValue)
                Console.WriteLine(customer.VIPSince.Value.ToString("dd/MM/yyyy"));
        }

        private static bool HasMiddleName(Customer customer)
            => customer.MiddleName is not null;
    }
}
