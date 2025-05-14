using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Application.Interfaces
{
    public interface ITipoGastoService
    {
        Task<IEnumerable<TipoGastoDTO>> GetAllAsync();
        Task<TipoGastoDTO?> GetByIdAsync(int id);
        Task AddAsync(TipoGastoDTO tipoGasto);
        Task UpdateAsync(TipoGastoDTO tipoGasto);
        Task DeleteAsync(int id);
        Task<int> GetNextCodigoAsync();
    }
}
