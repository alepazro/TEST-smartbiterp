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
    public class RegistroGastoService : IRegistroGastoService
    {
        private readonly IRegistroGastoRepository _registroGastoRepository;
        private readonly IMapper _mapper;

        public RegistroGastoService(IRegistroGastoRepository registroGastoRepository, IMapper mapper)
        {
            _registroGastoRepository = registroGastoRepository;
            _mapper = mapper;
        }

        public async Task<RegistroGastoDTO?> GetByIdAsync(int id)
        {
            var registro = await _registroGastoRepository.GetByIdAsync(id);
            return registro == null ? null : _mapper.Map<RegistroGastoDTO>(registro);
        }

        public async Task<IEnumerable<RegistroGastoDTO>> GetByUsuarioAsync(int usuarioId)
        {
            var registros = await _registroGastoRepository.GetByUsuarioAsync(usuarioId);
            return _mapper.Map<IEnumerable<RegistroGastoDTO>>(registros);
        }

        public async Task AddAsync(RegistroGastoDTO registroDto, IEnumerable<DetalleGastoDTO> detallesDto)
        {
            var registro = _mapper.Map<RegistroGasto>(registroDto);
            var detalles = _mapper.Map<IEnumerable<DetalleGasto>>(detallesDto);

            await _registroGastoRepository.AddAsync(registro, detalles);
        }
    }
}
