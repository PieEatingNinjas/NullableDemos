using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_04_Dtos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private IEnumerable<WeatherForecast> Search(string city, string country)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                City = city.ToUpper(),
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WeatherForecast>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            string json = "{ \"CountryCode\":\"Be\" }";
            var searchDto = System.Text.Json.JsonSerializer.Deserialize<WeatherForecastSearchDto>(json);

            if (IsValid(searchDto))
            {
                var country = searchDto.Country;

                if (country is null) 
                {
                    if (searchDto.CountryCode is not null)
                    {
                        var normalizedCode = NormalizeCountryCode(searchDto.CountryCode);

                        if (TryGetCountryForCode(normalizedCode, out country))
                        {
                            //Found country by code
                        }
                    }
                    ThrowWhenNoCountry(country is null);

                }

                return Ok(Search(searchDto.City, country));
            }

            return BadRequest();
        }

        //Return will not be null if the given parameter wasn't null
        [return: NotNullIfNotNull("code")]
        private string? NormalizeCountryCode(string? code)
            => code?.ToUpper();

        //If we pass-in 'true', the method will not return. Ideal for Exception helper classes or Assertion libraries
        private void ThrowWhenNoCountry([DoesNotReturnIf(true)] bool hasNoCountry)
        {
            if (hasNoCountry)
                throw new ArgumentException();
        }

        //If 'true' is returned, we assure the compiler that the given country parameter was not null
        private bool TryGetCountryForCode(string countryCode, [NotNullWhen(true)] out string? country)
        {
            if (countryCode == "be")
                country = "Belgium";
            else
                country = null;

            return country != null;
        }

        //When we return 'true', we assure the compiler the given parameter was not null
        private bool IsValid([NotNullWhen(true)] WeatherForecastSearchDto? dto)
        {
            bool isValid = true;

            if (dto is not null)
            {
                if (dto.City is null || (dto.Country is null && dto.CountryCode is null))
                    isValid = false;
            }
            else
                isValid = false;

            return isValid;
        }
    }

    public class WeatherForecastSearchDto
    {
        //In nullable annotations context, required attribute can be removed.
        //Non-nullable reference type properties are required
        public string City { get; set; } = default!;
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
    }
}
