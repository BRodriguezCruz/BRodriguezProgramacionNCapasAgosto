using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAllEF(ML.Empleado empleadoBusqueda)// (int idEmpresa, string nombre) 
        { 
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.EmpleadoGetAll(empleadoBusqueda.Empresa.IdEmpresa, empleadoBusqueda.Nombre);
                    //var query = context.EmpleadoGetAll(idEmpresa, nombre).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.IdEmpleado = registro.IdEmpleado;
                            empleado.RFC = registro.RFC;
                            empleado.Nombre = registro.Nombre;
                            empleado.ApellidoPaterno = registro.ApellidoPaterno;
                            empleado.ApellidoMaterno = registro.ApellidoMaterno;
                            empleado.Email = registro.Email;
                            empleado.Telefono = registro.Telefono;
                            empleado.FechaNacimiento = registro.FechaNacimiento;
                            empleado.NSS = registro.NSS;
                            empleado.FechaIngreso = registro.FechaIngreso;
                            empleado.Foto = registro.Foto;
                            //Instancia para prop de navegcion
                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.IdEmpresa = registro.IdEmpresa;
                            empleado.Empresa.Nombre = registro.NombreEmpresa;

                            result.Objects.Add(empleado); //guardamos los valores de empleado en lista de OBJETO(S)
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
        public static ML.Result AddEF(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.EmpleadoAdd(empleado.IdEmpleado, empleado.RFC, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Email,
                                                    empleado.Telefono, empleado.FechaNacimiento, empleado.NSS, empleado.FechaIngreso, 
                                                    empleado.Foto, empleado.Empresa.IdEmpresa);
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
            catch(Exception ex) 
            { 
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ML.Result UpdateEF(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.EmpleadoUpdate(empleado.IdEmpleado, empleado.RFC, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Email,
                                                    empleado.Telefono, empleado.FechaNacimiento, empleado.NSS, empleado.FechaIngreso,
                                                    empleado.Foto, empleado.Empresa.IdEmpresa);
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

        public static ML.Result GetById(string idEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.EmpleadoGetById(idEmpleado).FirstOrDefault();


                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.RFC = query.RFC;
                        empleado.Email = query.Email;
                        empleado.Telefono = query.Telefono;
                        empleado.FechaNacimiento = query.FechaNacimiento;
                        empleado.NSS = query.NSS;
                        empleado.FechaIngreso = query.FechaIngreso;
                        empleado.Foto = query.Foto;
                        empleado.Empresa = new ML.Empresa(); //instancia para usar la prop de navegacion y almacenar datos
                        empleado.Empresa.IdEmpresa = query.IdEmpresa;

                        result.Object = empleado;

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
        public static ML.Result DeleteEF(string idEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.EmpleadoDelete(idEmpleado);

                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else 
                    { 
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar al empleado";
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
