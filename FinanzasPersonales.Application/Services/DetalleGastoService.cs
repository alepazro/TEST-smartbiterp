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
    public class DetalleGastoService : IDetalleGastoService
    {
        private readonly IDetalleGastoRepository _detalleGastoRepository;
        private readonly IMapper _mapper;

        public DetalleGastoService(IDetalleGastoRepository detalleGastoRepository, IMapper mapper)
        {
            _detalleGastoRepository = detalleGastoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetalleGastoDTO>> GetByRegistroIdAsync(int registroId)
        {
            var detalles = await _detalleGastoRepository.GetByRegistroIdAsync(registroId);
            return _mapper.Map<IEnumerable<DetalleGastoDTO>>(detalles);
        }
    }
}
