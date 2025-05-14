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
    public class DetalleGastoRepository : IDetalleGastoRepository
    {
        private readonly ApplicationDbContext _context;

        public DetalleGastoRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<DetalleGasto>> GetByRegistroIdAsync(int registroId)
        {
            return await _context.DetallesGastos
                .Where(d => d.RegistroGastoId == registroId)
                .ToListAsync();
        }
    }
}
