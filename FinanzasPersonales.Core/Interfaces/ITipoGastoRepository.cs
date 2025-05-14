using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Core.Entities;

namespace FinanzasPersonales.Core.Interfaces
{
    public interface ITipoGastoRepository
    {
        Task<IEnumerable<TipoGasto>> GetAllAsync();
        Task<TipoGasto?> GetByIdAsync(int id);
        Task AddAsync(TipoGasto tipoGasto);
        Task UpdateAsync(TipoGasto tipoGasto);
        Task DeleteAsync(int id);
        Task<int> GetNextCodigoAsync(); // Para generar el siguiente código automáticamente
    }
}
