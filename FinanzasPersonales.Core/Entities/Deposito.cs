using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Core.Entities
{
    public class Deposito
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public decimal Monto { get; set; }
        public int UsuarioId { get; set; }

        public FondoMonetario FondoMonetario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
