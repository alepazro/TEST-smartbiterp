using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinanzasPersonales.Application.DTOs;
using FinanzasPersonales.Core.Entities;

namespace FinanzasPersonales.Application.Mappings
{
    public class RegistroGastoProfile : Profile
    {
        public RegistroGastoProfile()
        {
            CreateMap<RegistroGasto, RegistroGastoDTO>().ReverseMap();
        }
    }
}
