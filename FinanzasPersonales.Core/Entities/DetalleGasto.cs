using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Core.Entities
{
    public class DetalleGasto
    {
        public int Id { get; set; }
        public int RegistroGastoId { get; set; }
        public int TipoGastoId { get; set; }
        public decimal Monto { get; set; }

        public RegistroGasto RegistroGasto { get; set; }
        public TipoGasto TipoGasto { get; set; }
    }
}
