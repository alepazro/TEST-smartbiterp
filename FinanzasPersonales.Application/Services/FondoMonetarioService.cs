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
    public class FondoMonetarioService : IFondoMonetarioService
    {
        private readonly IFondoMonetarioRepository _fondoRepository;
        private readonly IMapper _mapper;

        public FondoMonetarioService(IFondoMonetarioRepository fondoRepository, IMapper mapper)
        {
            _fondoRepository = fondoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FondoMonetarioDTO>> GetAllAsync()
        {
            var fondos = await _fondoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FondoMonetarioDTO>>(fondos);
        }

        public async Task<FondoMonetarioDTO?> GetByIdAsync(int id)
        {
            var fondo = await _fondoRepository.GetByIdAsync(id);
            return fondo == null ? null : _mapper.Map<FondoMonetarioDTO>(fondo);
        }

        public async Task AddAsync(FondoMonetarioDTO fondoDto)
        {
            var fondo = _mapper.Map<FondoMonetario>(fondoDto);
            await _fondoRepository.AddAsync(fondo);
        }

        public async Task UpdateAsync(FondoMonetarioDTO fondoDto)
        {
            var fondo = _mapper.Map<FondoMonetario>(fondoDto);
            await _fondoRepository.UpdateAsync(fondo);
        }

        public async Task DeleteAsync(int id)
        {
            await _fondoRepository.DeleteAsync(id);
        }
    }
}
