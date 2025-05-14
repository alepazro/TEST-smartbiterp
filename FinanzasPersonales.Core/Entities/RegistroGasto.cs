using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Core.Entities
{
    public class RegistroGasto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public string Observaciones { get; set; }
        public string NombreComercio { get; set; }
        public string TipoDocumento { get; set; }
        public int UsuarioId { get; set; }

        public FondoMonetario FondoMonetario { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<DetalleGasto> DetallesGasto { get; set; }
    }
}
