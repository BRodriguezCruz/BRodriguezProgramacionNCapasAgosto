using DLEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result AddEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.AseguradoraAdd(aseguradora.Nombre, aseguradora.Usuario.IdUsuario);

                    if(query > 0)
                    {
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

        public static ML.Result UpdateEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.AseguradoraUpdate(aseguradora.IdAseguradora, aseguradora.Nombre, aseguradora.Usuario.IdUsuario);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct =false;
                result.ErrorMessage = ex.Message;   
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result DeleteEF(int idAseguradora)
        {
            ML.Result result= new ML.Result();
            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.AseguradoraDelete(idAseguradora);

                    if (query > 0)
                    {
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

        public static ML.Result GetAll() 
        { 
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.AseguradoraGetAll().ToList();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                       foreach (var registro in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();

                            aseguradora.IdAseguradora = registro.IdAseguradora;
                            aseguradora.Nombre = registro.Nombre;
                            aseguradora.FechaCreacion = registro.FechaCreacion;
                            aseguradora.FechaModificacion = registro.FechaModificacion;
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = registro.IdUsuario;
                            aseguradora.Usuario.Nombre = registro.NombreUsuario;

                            result.Objects.Add(aseguradora);
                        }
                       result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch( Exception ex )
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;       
        }

        public static ML.Result GetById(int idAseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.AseguradoraGetById(idAseguradora).SingleOrDefault();


                    if (query != null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();

                        aseguradora.IdAseguradora = query.IdAseguradora;
                        aseguradora.Nombre = query.Nombre;  
                        aseguradora.FechaCreacion = query.FechaCreacion;
                        aseguradora.FechaModificacion = query.FechaModificacion;
                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = query.IdUsuario;

                        result.Object = aseguradora;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch ( Exception ex )
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
