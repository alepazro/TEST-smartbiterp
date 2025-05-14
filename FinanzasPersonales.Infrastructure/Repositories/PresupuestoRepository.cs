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
    public class PresupuestoRepository : IPresupuestoRepository
    {
        private readonly ApplicationDbContext _context;

        public PresupuestoRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Presupuesto>> GetByUsuarioYMesAsync(int usuarioId, int mes)
        {
            return await _context.Presupuestos
                .Where(p => p.UsuarioId == usuarioId && p.Mes == mes)
                .Include(p => p.Usuario)   // Incluir la relación con Usuario
                .Include(p => p.TipoGasto) // Incluir la relación con TipoGasto
                .ToListAsync();
        }

        public async Task AddAsync(Presupuesto presupuesto)
        {
            _context.Presupuestos.Add(presupuesto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Presupuesto presupuesto)
        {
            _context.Presupuestos.Update(presupuesto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Presupuestos.FindAsync(id);
            if (item != null)
            {
                _context.Presupuestos.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
