using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El número es demasiado largo")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "Solo inicial(H o M)")]
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Correo Electronico")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Escriba un correo electronico valido")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [StringLength(10,MinimumLength = 4)]
        public string Password { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Range(1, 100)]
        public string Celular { get; set; }
        public string Curp { get; set; }

        //Propiedad para la imagen
        public string Imagen { get; set; }

        //Propiedad de Navegacion oara acceder a ROL
        public ML.Rol Rol { get; set; }

        //Propiedad usada para MVC y guardar los usuarios del getAll:
        public List<object> Usuarios { get; set; }

        //Propiedad de Navegacion para acceder a Direccion, es colocada aqui pues usuario es la tabla principal
        public ML.Direccion Direccion { get; set; }

        //Propiedad para el STATUS "BAJA LOGICA"
        public bool Status { get; set; }
    }
}
