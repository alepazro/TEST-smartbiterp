using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Core.Entities;

namespace FinanzasPersonales.Core.Interfaces
{
    public interface IDepositoRepository
    {
        Task<IEnumerable<Deposito>> GetByUsuarioAsync(int usuarioId);
        Task AddAsync(Deposito deposito);
    }
}
