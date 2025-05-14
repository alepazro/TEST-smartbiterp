using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinanzasPersonales.Application.DTOs;
using FinanzasPersonales.Application.Interfaces;
using FinanzasPersonales.Core.Entities;
using FinanzasPersonales.Core.Interfaces;

namespace FinanzasPersonales.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }

        public async Task<UsuarioDTO> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException($"Usuario con ID {id} no encontrado.");

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> CreateAsync(UsuarioDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            await _usuarioRepository.AddAsync(usuario);

            // Si no tienes una forma de obtener el usuario insertado (por ID, Login, etc.), 
            // esto podría romperse. Asegúrate de tener ID cargado o mecanismo de recuperación.
            var creado = await _usuarioRepository.GetByIdAsync(usuario.Id);
            if (creado == null)
                throw new Exception("No se pudo recuperar el usuario después del guardado.");

            return _mapper.Map<UsuarioDTO>(creado);
        }

        public async Task<UsuarioDTO> UpdateAsync(UsuarioDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.UpdateAsync(usuario);
            return usuarioDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
            return true;
        }
    }


}
