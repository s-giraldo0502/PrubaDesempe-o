using Filtro.Models;

namespace Filtro.Services
{
    public interface IVetRepository
    {
        Task<IEnumerable<Vet>> GetAllAsync();
        Task<Vet> GetByIdAsync(int id);
        Task AddAsync(Vet vet);
        Task UpdateAsync(Vet vet);
    }
}