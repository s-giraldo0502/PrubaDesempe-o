using Filtro.Models;

namespace Filtro.Services
{
    public interface IQouteRepository
    {
        Task<IEnumerable<Qoute>> GetAllAsync();
        Task<Qoute> GetByIdAsync(int id);
        Task AddAsync(Qoute qoute);
        Task UpdateAsync(Qoute qoute);
    }
}