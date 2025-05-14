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
    public class TipoGastoService : ITipoGastoService
    {
        private readonly ITipoGastoRepository _tipoGastoRepository;
        private readonly IMapper _mapper;

        public TipoGastoService(ITipoGastoRepository tipoGastoRepository, IMapper mapper)
        {
            _tipoGastoRepository = tipoGastoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoGastoDTO>> GetAllAsync()
        {
            var tipos = await _tipoGastoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoGastoDTO>>(tipos);
        }

        public async Task<TipoGastoDTO?> GetByIdAsync(int id)
        {
            var tipo = await _tipoGastoRepository.GetByIdAsync(id);
            return tipo == null ? null : _mapper.Map<TipoGastoDTO>(tipo);
        }

        public async Task AddAsync(TipoGastoDTO tipoGastoDto)
        {
            var tipo = _mapper.Map<TipoGasto>(tipoGastoDto);
            await _tipoGastoRepository.AddAsync(tipo);
        }

        public async Task UpdateAsync(TipoGastoDTO tipoGastoDto)
        {
            var tipo = _mapper.Map<TipoGasto>(tipoGastoDto);
            await _tipoGastoRepository.UpdateAsync(tipo);
        }

        public async Task DeleteAsync(int id)
        {
            await _tipoGastoRepository.DeleteAsync(id);
        }

        public async Task<int> GetNextCodigoAsync()
        {
            return await _tipoGastoRepository.GetNextCodigoAsync();
        }
    }
}
