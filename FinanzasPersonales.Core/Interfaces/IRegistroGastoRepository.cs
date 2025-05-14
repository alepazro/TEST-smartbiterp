using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Core.Entities;

namespace FinanzasPersonales.Core.Interfaces
{
    public interface IRegistroGastoRepository
    {
        Task<RegistroGasto?> GetByIdAsync(int id);
        Task<IEnumerable<RegistroGasto>> GetByUsuarioAsync(int usuarioId);
        Task AddAsync(RegistroGasto registro, IEnumerable<DetalleGasto> detalles);
    }
}
