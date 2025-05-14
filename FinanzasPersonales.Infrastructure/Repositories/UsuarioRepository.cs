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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Usuario>> GetAllAsync() => await _context.Usuarios.ToListAsync();
        public async Task<Usuario?> GetByIdAsync(int id) => await _context.Usuarios.FindAsync(id);
        public async Task AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
