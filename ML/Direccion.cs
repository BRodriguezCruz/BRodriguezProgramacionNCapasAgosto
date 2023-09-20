using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        [Display(Name = "No. Exterior")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string NumeroExterior { get; set; }

        [Display(Name = "No. Interior")]
        public string NumeroInterior { get; set; }
        public ML.Colonia Colonia { get; set; } //solo se crea prop de navegacion de COLONIA pues en usuario se creo la prop de navegacion a aqui
    }
}
