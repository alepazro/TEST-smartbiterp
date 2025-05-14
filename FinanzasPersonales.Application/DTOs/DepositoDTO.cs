using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Application.DTOs
{
    public class DepositoDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public decimal Monto { get; set; }
        public int UsuarioId { get; set; }

        // Relación: un depósito está asociado a un fondo monetario
        //public FondoMonetarioDTO FondoMonetario { get; set; }

        // Relación: un depósito está asociado a un usuario
        public UsuarioDTO Usuario { get; set; }
    }
}
