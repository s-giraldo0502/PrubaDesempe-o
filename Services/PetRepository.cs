using Microsoft.EntityFrameworkCore;
using Filtro.Data;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Services
{
    public class PetRepository : IPetRepository
    {
        private readonly BaseContext _context;

        public PetRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            return await _context.Pets.ToListAsync();
        }
        

        public async Task<Pet> GetByIdAsync(int id)
        {
            return await _context.Pets.FirstOrDefaultAsync(b => b.PetId == id);
        }

        public async Task AddAsync(Pet pet)
        {
            await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();  
        }

        public async Task UpdateAsync(Pet pet)
        {
            _context.Pets.Update(pet);
            await _context.SaveChangesAsync();
        }
    } 
}