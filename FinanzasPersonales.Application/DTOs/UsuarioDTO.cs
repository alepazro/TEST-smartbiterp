using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Application.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        // Relación: un Usuario puede tener muchos Presupuestos
        //public ICollection<PresupuestoDTO> Presupuestos { get; set; } = new List<PresupuestoDTO>();

        // Relación: un Usuario puede tener muchos RegistrosGastos
        public ICollection<RegistroGastoDTO> RegistrosGastos { get; set; } = new List<RegistroGastoDTO>();

        // Relación: un Usuario puede tener muchos Depositos
        public ICollection<DepositoDTO> Depositos { get; set; } = new List<DepositoDTO>();
    }
}
