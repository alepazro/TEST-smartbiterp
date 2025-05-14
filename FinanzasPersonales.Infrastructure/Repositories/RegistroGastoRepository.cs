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
    public class RegistroGastoRepository : IRegistroGastoRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistroGastoRepository(ApplicationDbContext context) => _context = context;

        public async Task<RegistroGasto?> GetByIdAsync(int id)
        {
            return await _context.RegistrosGastos
                .Include(r => r.DetallesGasto)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RegistroGasto>> GetByUsuarioAsync(int usuarioId)
        {
            return await _context.RegistrosGastos
                .Include(r => r.DetallesGasto)
                .Where(r => r.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task AddAsync(RegistroGasto registro, IEnumerable<DetalleGasto> detalles)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.RegistrosGastos.Add(registro);
                await _context.SaveChangesAsync();

                foreach (var detalle in detalles)
                {
                    detalle.RegistroGastoId = registro.Id;
                    _context.DetallesGastos.Add(detalle);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
