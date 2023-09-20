using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.PaisGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Pais pais = new ML.Pais(registro.IdPais, registro.Nombre);
                            result.Objects.Add(pais);
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
