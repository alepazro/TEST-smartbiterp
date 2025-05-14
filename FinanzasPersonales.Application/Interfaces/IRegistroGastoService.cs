using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Application.Interfaces
{
    public interface IRegistroGastoService
    {
        Task<RegistroGastoDTO?> GetByIdAsync(int id);
        Task<IEnumerable<RegistroGastoDTO>> GetByUsuarioAsync(int usuarioId);
        Task AddAsync(RegistroGastoDTO registro, IEnumerable<DetalleGastoDTO> detalles);
    }
}
