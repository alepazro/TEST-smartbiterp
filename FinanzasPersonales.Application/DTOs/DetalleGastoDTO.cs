using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Application.DTOs
{
    public class DetalleGastoDTO
    {
        public int Id { get; set; }
        public int RegistroGastoId { get; set; }
        public int TipoGastoId { get; set; }
        public decimal Monto { get; set; }

        // Relación: un detalle de gasto está asociado a un registro de gasto
        //public RegistroGastoDTO RegistroGasto { get; set; }

        // Relación: un detalle de gasto está asociado a un tipo de gasto
        public TipoGastoDTO TipoGasto { get; set; }
    }
}
