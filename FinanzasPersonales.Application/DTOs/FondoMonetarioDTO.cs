using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Application.DTOs
{
    public class FondoMonetarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        // Relación: un fondo monetario puede tener muchos registros de gastos
        public ICollection<RegistroGastoDTO> RegistrosGastos { get; set; } = new List<RegistroGastoDTO>();

        // Relación: un fondo monetario puede tener muchos depósitos
        public ICollection<DepositoDTO> Depositos { get; set; } = new List<DepositoDTO>();
    }
}
