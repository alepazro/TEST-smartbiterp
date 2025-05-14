using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Core.Entities;

namespace FinanzasPersonales.Core.Interfaces
{
    public interface IFondoMonetarioRepository
    {
        Task<IEnumerable<FondoMonetario>> GetAllAsync();
        Task<FondoMonetario?> GetByIdAsync(int id);
        Task AddAsync(FondoMonetario fondo);
        Task UpdateAsync(FondoMonetario fondo);
        Task DeleteAsync(int id);
    }
}
