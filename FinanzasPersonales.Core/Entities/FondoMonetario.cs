using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Core.Entities
{
    public class FondoMonetario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public ICollection<RegistroGasto> RegistrosGastos { get; set; }
        public ICollection<Deposito> Depositos { get; set; }
    }
}
