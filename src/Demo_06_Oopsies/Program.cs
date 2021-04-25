using System;

namespace Demo_06_Oopsies
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] values = new string[10];
                string s = values[0];
                Console.WriteLine(s.ToUpper());
            }
            catch (NullReferenceException)
            {
                // :-(
            }

            try
            {
                Person p = default;

                Console.WriteLine(p.Lastname.ToUpper());
            }
            catch (NullReferenceException)
            {
                // :-(
            }

            try
            {
                var c = new Customer(1, "Pieter", "Nijs");

                if (c.MiddleName is not null)
                {
                    DoSomethingSecret(c);
                    Console.WriteLine(c.MiddleName.ToUpper());
                }
            }
            catch (NullReferenceException)
            {
                // :-(
            }
        }

        private static void DoSomethingSecret(Customer c)
        {
            c.MiddleName = null;
        }
    }
}
