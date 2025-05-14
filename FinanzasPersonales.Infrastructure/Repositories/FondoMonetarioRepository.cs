using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Core.Entities;
using FinanzasPersonales.Core.Interfaces;
using FinanzasPersonales.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanzasPersonales.Infrastructure.Repositories
{
    public class FondoMonetarioRepository : IFondoMonetarioRepository
    {
        private readonly ApplicationDbContext _context;

        public FondoMonetarioRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<FondoMonetario>> GetAllAsync() => await _context.FondosMonetarios.ToListAsync();
        public async Task<FondoMonetario?> GetByIdAsync(int id) => await _context.FondosMonetarios.FindAsync(id);
        public async Task AddAsync(FondoMonetario fondo)
        {
            _context.FondosMonetarios.Add(fondo);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(FondoMonetario fondo)
        {
            _context.FondosMonetarios.Update(fondo);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var fondo = await _context.FondosMonetarios.FindAsync(id);
            if (fondo != null)
            {
                _context.FondosMonetarios.Remove(fondo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
