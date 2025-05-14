using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Core.Entities
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TipoGastoId { get; set; }
        public int Mes { get; set; }
        public decimal Monto { get; set; }

        public Usuario Usuario { get; set; }
        public TipoGasto TipoGasto { get; set; }
    }
}
