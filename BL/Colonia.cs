using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int idMunicipio)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.ColoniaGetByIdMunicipio(idMunicipio).ToList();

                    result.Objects = new List<object>(); //INICIALIZAMOS LISTA DE OBJECTOS PARA GUARDAR EL RESULTADO DEL QUERY ADELANTE

                    if (query != null)
                    {
                        foreach(var registro in query)
                        {
                            ML.Colonia colonia = new ML.Colonia(); // creacion de objecto colonia para guardar los valores del query 

                            colonia.IdColonia = registro.IdColonia;
                            colonia.Nombre = registro.Nombre;
                            colonia.CodigoPostal = registro.CodigoPostal;

                            result.Objects.Add(colonia);
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
