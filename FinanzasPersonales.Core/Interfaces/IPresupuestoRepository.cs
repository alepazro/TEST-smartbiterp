using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Core.Entities;

namespace FinanzasPersonales.Core.Interfaces
{
    public interface IPresupuestoRepository
    {
        Task<IEnumerable<Presupuesto>> GetByUsuarioYMesAsync(int usuarioId, int mes);
        Task AddAsync(Presupuesto presupuesto);
        Task UpdateAsync(Presupuesto presupuesto);
        Task DeleteAsync(int id);
    }
}
