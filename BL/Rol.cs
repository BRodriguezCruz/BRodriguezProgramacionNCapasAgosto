using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.RolGetAll().ToList();

                    result.Objects = new List<object>(); //inicializo mi prop lista "objects" en mi clase result

                    if (query  != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Rol rol = new ML.Rol(); //instanciamos objeto rol para pasarle lo que hay en query, a las prop en clase rol

                            rol.IdRol = registro.IdROL;
                            rol.Nombre = registro.Nombre;

                            result.Objects.Add(rol);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
