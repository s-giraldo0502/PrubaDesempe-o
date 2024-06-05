using Microsoft.EntityFrameworkCore;
using Filtro.Data;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Services
{
    public class QouteRepository : IQouteRepository
    {
        private readonly BaseContext _context;

        public QouteRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Qoute>> GetAllAsync()
        {
            return await _context.Qoutes.ToListAsync();
        }
        

        public async Task<Qoute> GetByIdAsync(int id)
        {
            return await _context.Qoutes.FirstOrDefaultAsync(b => b.QouteId == id);
        }

        public async Task AddAsync(Qoute Qoute)
        {
            await _context.Qoutes.AddAsync(Qoute);
            await _context.SaveChangesAsync();  
        }

        public async Task UpdateAsync(Qoute Qoute)
        {
            _context.Qoutes.Update(Qoute);
            await _context.SaveChangesAsync();
        }
    } 
}