using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Application.DTOs
{
    public class PresupuestoDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TipoGastoId { get; set; }
        public int Mes { get; set; }
        public decimal Monto { get; set; }

        // Relación: un presupuesto está asociado a un usuario
        public UsuarioDTO Usuario { get; set; }

        // Relación: un presupuesto está asociado a un tipo de gasto
        public TipoGastoDTO TipoGasto { get; set; }
    }
}
