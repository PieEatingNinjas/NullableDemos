using System.ComponentModel.DataAnnotations;

namespace Demo_03_Classes.EF.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public Country(string name, string countryCode)
        {
            Name = name;
            CountryCode = countryCode;
        }
    }
}
