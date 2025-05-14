using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Application.Interfaces
{
    public interface IPresupuestoService
    {
        Task<IEnumerable<PresupuestoDTO>> GetByUsuarioYMesAsync(int usuarioId, int mes);
        Task AddAsync(PresupuestoDTO presupuesto);
        Task UpdateAsync(PresupuestoDTO presupuesto);
        Task DeleteAsync(int id);
    }
}
