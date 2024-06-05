using Microsoft.EntityFrameworkCore;
using Filtro.Data;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Services
{
    public class VetRepository : IVetRepository
    {
        private readonly BaseContext _context;

        public VetRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vet>> GetAllAsync()
        {
            return await _context.Vets.ToListAsync();
        }
        

        public async Task<Vet> GetByIdAsync(int id)
        {
            return await _context.Vets.FirstOrDefaultAsync(b => b.VetId == id);
        }

        public async Task AddAsync(Vet vet)
        {
            await _context.Vets.AddAsync(vet);
            await _context.SaveChangesAsync();  
        }

        public async Task UpdateAsync(Vet vet)
        {
            _context.Vets.Update(vet);
            await _context.SaveChangesAsync();
        }
    } 
}