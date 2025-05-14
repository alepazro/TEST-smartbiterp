using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Core.Entities
{
    public class Usuario
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

        //public ICollection<Presupuesto> Presupuestos { get; set; }
        public ICollection<RegistroGasto> RegistrosGastos { get; set; }
        public ICollection<Deposito> Depositos { get; set; }
    }
}
