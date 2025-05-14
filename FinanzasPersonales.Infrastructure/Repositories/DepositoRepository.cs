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
    public class DepositoRepository : IDepositoRepository
    {
        private readonly ApplicationDbContext _context;

        public DepositoRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Deposito>> GetByUsuarioAsync(int usuarioId)
        {
            return await _context.Depositos
                .Include(d => d.FondoMonetario)
                .Where(d => d.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task AddAsync(Deposito deposito)
        {
            _context.Depositos.Add(deposito);
            await _context.SaveChangesAsync();
        }
    }
}
