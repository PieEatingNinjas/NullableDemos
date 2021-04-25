using System;
using System.Diagnostics.CodeAnalysis;

namespace Demo_04_Dtos
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        private string? _summary;

        [DisallowNull]
        public string? Summary
        {
            get => _summary;
            set => _summary = value ?? "";
        }

        public string? City { get; set; }

        public string RequestId { get; private set; }

        public WeatherForecast(DateTime date, int tempC, string city)
        {
            ConstructorSharedCode(city);
            City = city;
            TemperatureC = tempC;
            Date = date;
        }

        public WeatherForecast()
        {
            ConstructorSharedCode();
        }

        [MemberNotNull(nameof(RequestId))]
        //Telling the compiler that upon exiting this method, the RequestId property will not be null
        //When calling this method from the constructor, the compiler will have the guarentee that the 
        //non-nullable RequestId property will have a non-null value upon instantiation of the object.
        private void ConstructorSharedCode(string? city = null)
        {
            RequestId = $"{city}-{DateTime.Now:dd-MM-yyyy HH:mm:ss}";
        }
    }
}
