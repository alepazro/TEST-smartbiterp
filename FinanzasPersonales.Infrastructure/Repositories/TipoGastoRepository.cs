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
    public class TipoGastoRepository : ITipoGastoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoGastoRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<TipoGasto>> GetAllAsync() => await _context.TiposGasto.ToListAsync();
        public async Task<TipoGasto?> GetByIdAsync(int id) => await _context.TiposGasto.FindAsync(id);
        public async Task AddAsync(TipoGasto tipoGasto)
        {
            _context.TiposGasto.Add(tipoGasto);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TipoGasto tipoGasto)
        {
            _context.TiposGasto.Update(tipoGasto);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var tipo = await _context.TiposGasto.FindAsync(id);
            if (tipo != null)
            {
                _context.TiposGasto.Remove(tipo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetNextCodigoAsync()
        {
            return await _context.TiposGasto.MaxAsync(t => (int?)t.Id) + 1 ?? 1;
        }
    }
}
