using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pais
    {
        [Display(Name = "Pais")]
        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public List<object> Paises { get; set; }
        public Pais() //constructor vacio para instanciar en la propiedad de navegacion en BL
        { 
        }
        public Pais(int idPais, string nombre)
        {
            this.IdPais = idPais;
            this.Nombre = nombre;
        }

    }
}
