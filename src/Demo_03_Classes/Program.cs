using Demo_03_Classes.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Demo_03_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new DemoDBContext();

            var customers = dbContext.Customers
                .Include(c => c.CustomerMetaData)
                .Include(c => c.PreferredLanguage)//removing this line will result in InvalidOperationException when accessing PreferredLanguage property
                .ToList();

            foreach (var c in customers)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName}");
                Console.WriteLine($"{c.CustomerMetaData?.DefaultTshirtSize}");
                Console.WriteLine($"{c.PreferredLanguage.Name}");

                foreach (var order in c.Orders)
                {
                    Console.WriteLine(order.Description);
                }
            }
        }
    }
}
