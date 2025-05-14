using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Core.Entities
{
    public class TipoGasto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        //public ICollection<Presupuesto> Presupuestos { get; set; }
        public ICollection<DetalleGasto> DetallesGastos { get; set; }
    }
}
