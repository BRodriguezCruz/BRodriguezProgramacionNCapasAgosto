using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Rol
    {
        [Display(Name = "Roles")]
        public int IdRol { get; set; }
        public string Nombre { get; set; }

        //Propiedad creada para guardar los datos de result.objects y mandarlos a la vista
        public List<object> Roles { get; set; }
    }
}
