using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Application.DTOs
{
    public class TipoGastoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        // Relación: un tipo de gasto puede tener muchos presupuestos
        //public ICollection<PresupuestoDTO> Presupuestos { get; set; } = new List<PresupuestoDTO>();

        // Relación: un tipo de gasto puede tener muchos detalles de gasto
        public ICollection<DetalleGastoDTO> DetallesGastos { get; set; } = new List<DetalleGastoDTO>();
    }
}
