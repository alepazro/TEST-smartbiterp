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
    public class DepositoService : IDepositoService
    {
        private readonly IDepositoRepository _depositoRepository;
        private readonly IMapper _mapper;

        public DepositoService(IDepositoRepository depositoRepository, IMapper mapper)
        {
            _depositoRepository = depositoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepositoDTO>> GetByUsuarioAsync(int usuarioId)
        {
            var depositos = await _depositoRepository.GetByUsuarioAsync(usuarioId);
            return _mapper.Map<IEnumerable<DepositoDTO>>(depositos);
        }

        public async Task AddAsync(DepositoDTO depositoDto)
        {
            var deposito = _mapper.Map<Deposito>(depositoDto);
            await _depositoRepository.AddAsync(deposito);
        }
    }
}
