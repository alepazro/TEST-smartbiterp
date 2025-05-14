using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Core.Entities;

namespace FinanzasPersonales.Core.Interfaces
{
    public interface IDetalleGastoRepository
    {
        Task<IEnumerable<DetalleGasto>> GetByRegistroIdAsync(int registroId);
    }
}
