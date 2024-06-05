using Microsoft.EntityFrameworkCore;
using Filtro.Data;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Services
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly BaseContext _context;

        public OwnerRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _context.Owners.ToListAsync();
        }
        

        public async Task<Owner> GetByIdAsync(int id)
        {
            return await _context.Owners.FirstOrDefaultAsync(b => b.OwnerId == id);
        }

        public async Task AddAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();  
        }

        public async Task UpdateAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
        }
    } 
}