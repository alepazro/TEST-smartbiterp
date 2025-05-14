using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Application.Interfaces
{
    public interface IDetalleGastoService
    {
        Task<IEnumerable<DetalleGastoDTO>> GetByRegistroIdAsync(int registroId);
    }
}
