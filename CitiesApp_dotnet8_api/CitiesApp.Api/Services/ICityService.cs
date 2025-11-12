using CitiesApp.Api.Models;

namespace CitiesApp.Api.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllAsync();
        Task<City?> GetByIdAsync(int id);
        Task AddAsync(City city);
        Task UpdateAsync(City city);
        Task DeleteAsync(int id);
    }
}
