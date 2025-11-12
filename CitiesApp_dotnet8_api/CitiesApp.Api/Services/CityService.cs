using CitiesApp.Api.Data;
using CitiesApp.Api.Models;
using CitiesApp.Api.Validators;

namespace CitiesApp.Api.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repo;
        private readonly CityValidator _validator;

        public CityService(ICityRepository repo, CityValidator validator)
        {
            _repo = repo;
            _validator = validator;
        }

        public async Task AddAsync(City city)
        {
            _validator.Validate(city);
            await _repo.AddAsync(city);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<City?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(City city)
        {
            _validator.Validate(city);
            await _repo.UpdateAsync(city);
        }
    }
}
