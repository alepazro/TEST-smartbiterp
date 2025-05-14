using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO> GetByIdAsync(int id);
        Task<UsuarioDTO> CreateAsync(UsuarioDTO usuarioDto);
        Task<UsuarioDTO> UpdateAsync(UsuarioDTO usuarioDto);
        Task<bool> DeleteAsync(int id);
    }
}
