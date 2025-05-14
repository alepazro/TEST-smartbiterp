using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Application.Interfaces
{
    public interface IFondoMonetarioService
    {
        Task<IEnumerable<FondoMonetarioDTO>> GetAllAsync();
        Task<FondoMonetarioDTO?> GetByIdAsync(int id);
        Task AddAsync(FondoMonetarioDTO fondo);
        Task UpdateAsync(FondoMonetarioDTO fondo);
        Task DeleteAsync(int id);
    }
}
