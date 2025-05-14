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
    public class PresupuestoService : IPresupuestoService
    {
        private readonly IPresupuestoRepository _presupuestoRepository;
        private readonly IMapper _mapper;

        public PresupuestoService(IPresupuestoRepository presupuestoRepository, IMapper mapper)
        {
            _presupuestoRepository = presupuestoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PresupuestoDTO>> GetByUsuarioYMesAsync(int usuarioId, int mes)
        {
            var presupuestos = await _presupuestoRepository.GetByUsuarioYMesAsync(usuarioId, mes);
            return _mapper.Map<IEnumerable<PresupuestoDTO>>(presupuestos);
        }

        public async Task AddAsync(PresupuestoDTO presupuestoDto)
        {
            var presupuesto = _mapper.Map<Presupuesto>(presupuestoDto);
            await _presupuestoRepository.AddAsync(presupuesto);
        }

        public async Task UpdateAsync(PresupuestoDTO presupuestoDto)
        {
            var presupuesto = _mapper.Map<Presupuesto>(presupuestoDto);
            await _presupuestoRepository.UpdateAsync(presupuesto);
        }

        public async Task DeleteAsync(int id)
        {
            await _presupuestoRepository.DeleteAsync(id);
        }
    }
}
