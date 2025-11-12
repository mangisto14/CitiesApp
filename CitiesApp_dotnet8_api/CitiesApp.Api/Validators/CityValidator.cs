using CitiesApp.Api.Models;

namespace CitiesApp.Api.Validators
{
    public class CityValidator
    {
        public void Validate(City city)
        {
            if (string.IsNullOrWhiteSpace(city.Name))
                throw new ArgumentException("City name is required.");
            if (city.Population < 0)
                throw new ArgumentException("Population cannot be negative.");
        }
    }
}
