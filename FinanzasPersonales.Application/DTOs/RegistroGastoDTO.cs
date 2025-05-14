using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Application.DTOs
{
    public class RegistroGastoDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public string Observaciones { get; set; }
        public string NombreComercio { get; set; }
        public string TipoDocumento { get; set; }
        public int UsuarioId { get; set; }

        // Relación: un registro de gasto está asociado a un fondo monetario
        public FondoMonetarioDTO FondoMonetario { get; set; }

        // Relación: un registro de gasto está asociado a un usuario
        public UsuarioDTO Usuario { get; set; }

        // Relación: un registro de gasto puede tener muchos detalles de gasto
        public ICollection<DetalleGastoDTO> DetallesGasto { get; set; } = new List<DetalleGastoDTO>();
    }
}
