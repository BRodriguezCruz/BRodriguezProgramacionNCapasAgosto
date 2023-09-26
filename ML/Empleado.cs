using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        public string IdEmpleado { get; set; }
        public string RFC { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string NSS { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Foto { get; set; }

        //Propiedad de navegacion
        public ML.Empresa Empresa { get; set; }

        //Propiedad para alamacenar el nombre de los empleados
        public List<object> Empleados { get; set; }


        //Propiedad para validar el ID string de empleado
        public string Bandera { get; set; }
    }
}
