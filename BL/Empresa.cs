using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.EmpresaGetAll().ToList();

                    result.Objects = new List<object>(); //inicializo mi prop lista "objects" en mi clase result

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Empresa empresa = new ML.Empresa(); //instanciamos objeto rol para pasarle lo que hay en query, a las prop en clase rol

                            empresa.IdEmpresa = registro.IdEmpresa;
                            empresa.Nombre = registro.Nombre;

                            result.Objects.Add(empresa);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
