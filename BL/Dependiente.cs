using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Dependiente
    {
        public static ML.Result GetByIdEmpleado(string idEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.DependienteGetByIdEmpleado(idEmpleado);

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Dependiente dependiente = new ML.Dependiente();

                            dependiente.IdDependiente = registro.IdDependiente;
                            dependiente.Nombre = registro.Nombre;
                            dependiente.ApellidoPaterno = registro.ApellidoPaterno;
                            dependiente.ApellidoMaterno = registro.ApellidoMaterno;
                            dependiente.FechaNacimiento = registro.FechaNacimiento;
                            dependiente.EstadoCivil = registro.EstadoCivil;
                            dependiente.Genero = registro.Genero;
                            dependiente.Telefono = registro.Telefono;
                            dependiente.Rfc = registro.RFC;
                            dependiente.Empleado = new ML.Empleado();
                            dependiente.Empleado.IdEmpleado = registro.IdEmpleado;

                            result.Objects.Add(dependiente);

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
    
        public static ML.Result DeleteEF(int idDependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DLEF.BRodriguezProgramacionNCapasAgostoEntities  context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.DependienteDelete(idDependiente);

                    if(query > 0)
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;
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

        public static ML.Result AddEF(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.DependienteAdd(dependiente.Nombre, dependiente.ApellidoPaterno, dependiente.ApellidoMaterno, dependiente.FechaNacimiento,
                                                       dependiente.EstadoCivil, dependiente.Genero, dependiente.Telefono, dependiente.Rfc, dependiente.Empleado.IdEmpleado);

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

        public static ML.Result UpdateEF(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.DependienteUpdate(dependiente.IdDependiente, dependiente.Nombre, dependiente.ApellidoPaterno, dependiente.ApellidoMaterno,
                                                        dependiente.FechaNacimiento, dependiente.EstadoCivil, dependiente.Genero, dependiente.Telefono, dependiente.Rfc,
                                                        dependiente.Empleado.IdEmpleado);

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
        public static ML.Result GetByIdEF(int idDependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.DependienteGetById(idDependiente).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Dependiente dependiente = new ML.Dependiente();

                        dependiente.IdDependiente = query.IdDependiente;
                        dependiente.Nombre = query.Nombre;
                        dependiente.ApellidoPaterno = query.ApellidoPaterno;
                        dependiente.ApellidoMaterno = query.ApellidoMaterno;
                        dependiente.FechaNacimiento = query.FechaNacimiento;
                        dependiente.Telefono = query.Telefono;
                        dependiente.Genero = query.Genero;
                        dependiente.EstadoCivil = query.EstadoCivil;
                        dependiente.Rfc = query.RFC;
                        dependiente.Empleado = new ML.Empleado();
                        dependiente.Empleado.IdEmpleado = query.IdEmpleado;

                        result.Object = dependiente;
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
