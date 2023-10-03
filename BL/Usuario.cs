    using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using System.Runtime.ExceptionServices;
using System.Data.Entity;
using DLEF;
using Microsoft.Win32;
using System.Data.Entity.Core.Objects;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.IO;
using System.Data.OleDb;
using System.ComponentModel.Design;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO Usuario VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Telefono, @Sexo)";

                    SqlCommand cmd = new SqlCommand(query, context);

                    SqlParameter[] collection = new SqlParameter[6];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;

                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;

                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;

                    collection[3] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                    collection[3].Value = usuario.FechaNacimiento;

                    collection[4] = new SqlParameter("@Telefono", SqlDbType.BigInt);
                    collection[4].Value = usuario.Telefono;

                    collection[5] = new SqlParameter("@Sexo", SqlDbType.Char);
                    collection[5].Value = usuario.Sexo;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Fallo al insertar usuario";
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
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DELETE FROM Usuario WHERE IdUsuario = @IdUsuario";

                    SqlCommand cmd = new SqlCommand(query, context);

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        //resultado = "Eliminado Exitoso"; Se cambia el return primitivo "string" por uno complejo "result"
                        //                                  que se creo de las clases Ml.Result = result
                        result.Correct = true;  //Indica que la propiedad fue correcta o 1
                    }
                    else
                    {
                        result.Correct = false; //Indica que fue falso o 0 las filas afectadas
                        result.ErrorMessage = "Error en la eliminacion";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false; //Indica que fue falso o 0 
                result.ErrorMessage = ex.Message; //Muestra msj en pantalla de la excepcion
                result.Ex = ex; //Muestra toda la excepcion generada a detalle para su analisis
            }
            return result; // retorna un ML.RESULT que es el tipo de dato necesario del metodo
        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string query = "UPDATE Usuario SET Nombre = @Nombre, ApellidoPaterno = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno , FechaNacimiento = @FechaNacimiento, Telefono = @Telefono, Sexo = @Sexo WHERE IdUsuario = @IdUsuario";

                    SqlCommand cmd = new SqlCommand(query, context);

                    SqlParameter[] collection = new SqlParameter[7];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;

                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;

                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;

                    collection[3] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                    collection[3].Value = usuario.FechaNacimiento;

                    collection[4] = new SqlParameter("@Telefono", SqlDbType.BigInt);
                    collection[4].Value = usuario.Telefono;

                    collection[5] = new SqlParameter("@Sexo", SqlDbType.Char);
                    collection[5].Value = usuario.Sexo;

                    collection[6] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[6].Value = usuario.IdUsuario;


                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        // resultado = "Actualizado Exitosamente"; Cambiamos un return primitivo "string" por uno complejo "return"
                        //                                         que viene de ML. Result = result.
                        result.Correct = true; //Indicamos que fue verdadera 0 , por lo tanto las filas afectadas estan correctas
                    }
                    else
                    {
                        //resultado = "Error en la actualizacion"; Cambiamos un return primitivo "string" por uno complejo "return"
                        //                                         que viene de ML. Result = result.

                        result.Correct = false;  //Indicamos que fue falsa o 0 
                        result.ErrorMessage = "Error en la actualizacion"; //Accedemos a la propiedad "errorMessage" atraves del 
                        //                                                  objeto creado 
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false; //Indicamos que fue falsa o 0 y esta en el catch
                result.ErrorMessage = ex.Message; // Accedemos a la propiedad ErrorMessage y la igualamos a ex para mostrar error en panatalla
                result.Ex = ex;                  //Accedemos a la propiedad Ex y la igualamos a ex para ver la excepcion generada a detalle
            }

            return result; //retornamos el tipo de dato que requiere el metodo
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SELECT Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Telefono, Sexo, IdUsuario FROM Usuario";

                    SqlCommand cmd = new SqlCommand(query, context); //Ejecuta lo necesario para la BD, querys y la conexion


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd); // lee y extrae
                    DataTable tablaUsuario = new DataTable(); //creo tabla
                    adapter.Fill(tablaUsuario); //Accedo al metodo de llenado atraves del objeto "adapter" y lleno la tabla con lo leido y extraido

                    if (tablaUsuario.Rows.Count > 0)
                    {
                        result.Objects = new List<object>(); //Inicializamos la lista de objetos
                        foreach (DataRow row in tablaUsuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario(); //Se declara aqui pues en el metodo no se hizo como parametro
                            usuario.Nombre = row[0].ToString(); // Ingresamos a la prop Nombre a traves de usuario y le asignamos el primer valor del recorrido
                            usuario.ApellidoPaterno = row[1].ToString();
                            usuario.ApellidoMaterno = row[2].ToString();
                            usuario.FechaNacimiento = DateTime.Parse(row[3].ToString());
                            usuario.Telefono = (row[4].ToString());
                            usuario.Sexo = row[5].ToString();
                            usuario.IdUsuario = int.Parse(row[6].ToString());

                            result.Objects.Add(usuario); //EL ADD METE o agrega mis parametros al command
                        }

                        result.Correct = true; //ya que verificamos que salio correcto, aseguramos que es verdadera
                                               // aun cuando este bien si no especificamos esto, saldra mal
                    }
                    else
                    {
                        //resultado = "Error en la actualizacion"; Cambiamos un return primitivo "string" por uno complejo "return"
                        //                                         que viene de ML. Result = result.

                        result.Correct = false;  //Indicamos que fue falsa o 0 
                        result.ErrorMessage = "Error al mostrar"; //Accedemos a la propiedad "errorMessage" atraves del 
                        //                                         OBJETO RESULT.
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result; // aqui ya sala todo el OBJECTS lleno y lo esta devolviendo
        }
        public static ML.Result GetById(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SELECT Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Telefono, Sexo, IdUsuario FROM Usuario WHERE IdUsuario = @IdUsuario";

                    SqlCommand cmd = new SqlCommand(query, context); //Ejecuta lo necesario para interactuar con BD

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd); //Lee y extrae datos de la BD
                    DataTable tablaUsuario = new DataTable(); //Creo tabla
                    adapter.Fill(tablaUsuario); //Accedo al metodo llenar atraves del objeto adapter y lleno la tabla con lo leido por DataAdapter

                    if (tablaUsuario.Rows.Count > 0)
                    {
                        DataRow row = tablaUsuario.Rows[0];

                        ML.Usuario usuarioResult = new ML.Usuario();
                        usuarioResult.Nombre = row[0].ToString();
                        usuarioResult.ApellidoPaterno = row[1].ToString();
                        usuarioResult.ApellidoMaterno = row[2].ToString();
                        usuarioResult.FechaNacimiento = DateTime.Parse(row[3].ToString());
                        usuarioResult.Telefono = row[4].ToString();
                        usuarioResult.Sexo = row[5].ToString();
                        usuarioResult.IdUsuario = int.Parse(row[6].ToString());

                        //Unboxing
                        result.Object = usuarioResult;

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false; //Indicamos que el resultado fue 0 y es falso
                result.ErrorMessage = ex.Message; //Mostramos error al usuario
                result.Ex = ex; //Igualamos la excepcio "ex" a la propiedas "Ex" para saber TODA la excepcion completa
            }
            return result;
        }
        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioAdd"; //Solo el nombre del Store Procedure
                    

                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure; //Se indica que es un procedimiento almacenado si no, lo toma
                                                                   // como una consulta cualaquiera y falla

                    SqlParameter[] collecction = new SqlParameter[7];

                    collecction[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collecction[0].Value = usuario.Nombre;
                    collecction[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collecction[1].Value = usuario.ApellidoPaterno;
                    collecction[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collecction[2].Value = usuario.ApellidoMaterno;
                    collecction[3] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                    collecction[3].Value = usuario.FechaNacimiento;
                    collecction[4] = new SqlParameter("@Telefono", SqlDbType.VarChar);
                    collecction[4].Value = usuario.Telefono;
                    collecction[5] = new SqlParameter("@Sexo", SqlDbType.Char);
                    collecction[5].Value = usuario.Sexo;
                    collecction[6] = new SqlParameter("@IdRol", SqlDbType.Int);
                    collecction[6].Value = usuario.Rol.IdRol;

                    cmd.Parameters.AddRange(collecction);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Fallo al insertar usuario";
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
        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioDelete";

                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure; //Indicamos que es prodedimiento almacenado

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open ();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if(RowsAffected > 0)
                    {
                        result.Correct = true;
                    }  
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el usuario";
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
        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioUpdate";
                    SqlCommand cmd = new SqlCommand (query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[8];

                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;

                    collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;

                    collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;

                    collection[4] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                    collection[4].Value = usuario.FechaNacimiento;

                    collection[5] = new SqlParameter("@Telefono", SqlDbType.BigInt);
                    collection[5].Value = usuario.Telefono;

                    collection[6] = new SqlParameter("@Sexo", SqlDbType.Char);
                    collection[6].Value = usuario.Sexo;

                    collection[7] = new SqlParameter("@IdRol", SqlDbType.Int);
                    collection[7].Value = usuario.Rol.IdRol;


                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if(RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el registro";
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
        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetAll"; //nombre del SP 

                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd); // lee y extrae
                    DataTable tablaUsuario = new DataTable(); //creo tabla
                    adapter.Fill(tablaUsuario); //Accedo al metodo de llenado atraves del objeto "adapter" y lleno la tabla con lo leido y extraido

                    if (tablaUsuario.Rows.Count > 0)
                    {
                        result.Objects = new List<object>(); //Inicializamos la lista de objetos
                        foreach (DataRow row in tablaUsuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario(); //Se declara aqui pues en el metodo no se hizo como parametro

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString(); // Ingresamos a la prop Nombre a traves de usuario y le asignamos el primer valor del recorrido
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.FechaNacimiento = DateTime.Parse(row[4].ToString());
                            usuario.Telefono = row[5].ToString();
                            usuario.Sexo = row[6].ToString();

                            //INSTANCIA
                            usuario.Rol = new ML.Rol(); 
                            usuario.Rol.IdRol = int.Parse(row[7].ToString());


                            result.Objects.Add(usuario); //EL ADD METE o agrega mis parametros al command
                        }

                        result.Correct = true; //ya que verificamos que salio correcto, aseguramos que es verdadera
                                               // aun cuando este bien si no especificamos esto, saldra mal
                    }
                    else
                    {
                        //resultado = "Error en la actualizacion"; Cambiamos un return primitivo "string" por uno complejo "return"
                        //                                         que viene de ML. Result = result.

                        result.Correct = false;  //Indicamos que fue falsa o 0 
                        result.ErrorMessage = "Error al mostrar"; //Accedemos a la propiedad "errorMessage" atraves del 
                        //                                         OBJETO RESULT.
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
        public static ML.Result GetByIdSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetById";

                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure; //Indicamos que es un comando de tipo Procedimiento almacenado

                    SqlParameter[] collection = new SqlParameter[1]; //Definimos parametros, nombre del arreglo y tamaño 
                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int); //Almacenamos en el indice 0 el IdUsuario requerido y su tipo de dato                                                                                
                    collection[0].Value = usuario.IdUsuario;//Igualamos el valor almacenado en el indice 0 a la propiedad en Idusuario

                    cmd.Parameters.AddRange(collection);//EL ADD mete o agrega mis parametros al command

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd); //Lee y extrae datos de la BD
                    DataTable tablaUsuario = new DataTable(); //Creo tabla
                    adapter.Fill(tablaUsuario); //Accedo al metodo llenar atraves del objeto adapter y lleno la tabla con lo leido por DataAdapter

                    if (tablaUsuario.Rows.Count > 0)
                    {
                        DataRow row = tablaUsuario.Rows[0];

                        ML.Usuario usuarioResult = new ML.Usuario();
                        usuarioResult.Nombre = row[0].ToString();
                        usuarioResult.ApellidoPaterno = row[1].ToString();
                        usuarioResult.ApellidoMaterno = row[2].ToString();
                        usuarioResult.FechaNacimiento = DateTime.Parse(row[3].ToString());
                        usuarioResult.Telefono = row[4].ToString();
                        usuarioResult.Sexo = row[5].ToString();
                        usuarioResult.IdUsuario = int.Parse(row[6].ToString());
                        //INSTANCIA (CREACION DE OBJECTO)PARA ALMACENAR O GUARDAR IDROL DE LA DB
                        usuarioResult.Rol = new ML.Rol();
                        usuarioResult.Rol.IdRol = int.Parse(row[7].ToString());

                        //Unboxing
                        result.Object = usuarioResult;
                        result.Correct = true;
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
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    //se crea una variable tipo objectParameter para la variable con el OUTPUT, y poder meterla en los parametros del SP
                    ObjectParameter filasAfectadas = new ObjectParameter("RowsAffected", typeof(int)); // "RowsAffected" es el nombre tal cual de la variable en el SP en SQL,
                                                                                                       //  y su tipo de dato
                    var query = context.UsuarioAdd(usuario.Nombre, usuario.UserName, usuario.ApellidoPaterno, usuario.ApellidoMaterno, 
                                                   usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Email,
                                                   usuario.Password, usuario.Celular, usuario.Curp, usuario.Rol.IdRol, usuario.Direccion.Calle,
                                                   usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia, 
                                                   filasAfectadas, usuario.Imagen);
                    //"UsuarioADD" esta identificado como metodo pero en realidad es el Stored Procedure de la DB
                    //El orden de declaracion SI importa, debe ser igual que en el SP

                    //if (query > 0)  si mi metodo del EF me regresa un INT puedo validar con este if
                    if ((int)filasAfectadas.Value == 2) // valida con las filas afectdas a partir del parametro de salida enviado por el OUTPUT en SQL, "2" pues son 2 querys en la transaccion
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se agrego el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false; //Validamos que es falso, o 0 
                result.ErrorMessage = ex.Message; //Error mostrado al usuario
                result.Ex = ex; //Excepcion completa a detalle para analizar
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
              //se crea una variable tipo objectParameter para la variable con el OUTPUT, y poder meterla en los parametros del SP
                    ObjectParameter filasAfectadas = new ObjectParameter("RowsAffected", typeof(int)); // "RowsAffected" es el nombre tal cual de la variable en el SP en SQL,
                                                                                                       //  y su tipo de dato
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.UserName, usuario.ApellidoPaterno,
                                                   usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono,
                                                   usuario.Email, usuario.Password, usuario.Celular, usuario.Curp, usuario.Rol.IdRol,
                                                   usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior,
                                                   usuario.Direccion.Colonia.IdColonia, filasAfectadas, usuario.Imagen);
                    //"UsuarioUpdate" esta identificado como metodo pero en realidad es el Stored Procedure de la DB
                    //El orden de declaracion SI importa, debe ser igual que en el SP

                   // if (query > 0)  si mi metodo del EF me regresa un INT puedo validar con este if
                    if ((int)filasAfectadas.Value == 2) // valida con las filas afectdas a partir del parametro de salida enviado por el OUTPUT en SQL, "2" pues son 2 querys en la transaccion
                    {
                        result.Correct = true; //validamos la ejecucion verdadera
                    }
                    else
                    {
                        result.Correct = false;  //validamos la ejecucion falsa
                        result.ErrorMessage = "No se logro actualizar el registro";
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
        public static ML.Result DeleteEF(int idUsuario)
        {
            ML.Result result = new ML.Result(); // creamos objeto de tipo ML.RESULT
            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
           //se crea una variable tipo objectParameter para la variable con el OUTPUT, y poder meterla en los parametros del SP
                    ObjectParameter filasAfectadas = new ObjectParameter("RowsAffected", typeof(int)); // "RowsAffected" es el nombre tal cual de la variable en el SP en SQL,
                                                                                                       //  y su tipo de dato
                    var query = context.UsuarioDelete(idUsuario, filasAfectadas);

                    //if (query > 0)
                    if ((int)filasAfectadas.Value == 2) // valida con las filas afectdas a partir del parametro de salida enviado por el OUTPUT en SQL, "2" pues son 2 querys en la transaccion
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al encontrar el usuario, intenta de nuevo";
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
        public static ML.Result GetAllEF(ML.Usuario usuarioBusqueda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.UsuarioGetAll(usuarioBusqueda.Nombre, usuarioBusqueda.ApellidoPaterno).ToList(); // Agregamos un To.List

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = registro.IdUsuario; 
                            usuario.Nombre = registro.Nombre;
                            usuario.UserName = registro.UserName;
                            usuario.ApellidoPaterno = registro.ApellidoPaterno;
                            usuario.ApellidoMaterno = registro.ApellidoMaterno;
                            usuario.FechaNacimiento = registro.FechaNacimiento;
                            usuario.Sexo = registro.Sexo;
                            usuario.Telefono = registro.Telefono;                          
                            usuario.Email = registro.Email;
                            usuario.Password = registro.Password;
                            usuario.Celular = registro.Celular;
                            usuario.Curp = registro.Curp;
                            usuario.Imagen = registro.Imagen;
                            usuario.Status = registro.Status;
                            // Instancia para alamcenar datos desde la BD
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = registro.IdRol;
                            usuario.Rol.Nombre = registro.NombreRol;
                            //DIRECCION
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = registro.IdDireccion;
                            usuario.Direccion.Calle = registro.Calle;
                            usuario.Direccion.NumeroInterior = registro.NumeroInterior;
                            usuario.Direccion.NumeroExterior = registro.NumeroExterior;
                            //COLONIA 
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = registro.IdColonia; 
                            usuario.Direccion.Colonia.Nombre = registro.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = registro.CodigoPostal;
                            //MUNICIPIO
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = registro.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.Nombre = registro.NombreMunicipio;
                            //ESTADO
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = registro.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = registro.NombreEstado;
                            //PAIS
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = registro.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = registro.NombrePais;
                            
                            
                            result.Objects.Add(usuario); //Mete los "nuevos" valores que ya tiene usuario a mi propiedad Objects
                        }
                        result.Correct = true;//Validamos que se mostro correctamente
                    }
                    else
                    {
                        result.Correct = false; // Validamos que no se mostro ya que esta vacio
                    }
                }
            }
            catch  (Exception ex) 
            { 
                result.Correct = false; //validamos la ejecucion incorrecta
                result.ErrorMessage = ex.Message; //mostramos al usuario el error
                result.Ex = ex; //Excepcion completa para verificar o analisis
            }
            return result; 
        }
        public static ML.Result GetByIdEF(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                   
                    var query = context.UsuarioGetById(idUsuario).SingleOrDefault(); //AGREGAMOS Single OR DEFAULT pues es valor unico el id

                   // result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Usuario usuarioResult = new ML.Usuario();
                    
                        usuarioResult.IdUsuario = query.IdUsuario;
                        usuarioResult.Nombre = query.Nombre;
                        usuarioResult.UserName = query.UserName;
                        usuarioResult.ApellidoPaterno = query.ApellidoPaterno;
                        usuarioResult.ApellidoMaterno = query.ApellidoMaterno;
                        usuarioResult.FechaNacimiento = query.FechaNacimiento;
                        usuarioResult.Telefono = query.Telefono;
                        usuarioResult.Sexo = query.Sexo;
                        usuarioResult.Email = query.Email;
                        usuarioResult.Password = query.Password;
                        usuarioResult.Celular = query.Celular;
                        usuarioResult.Curp = query.Curp;
                        usuarioResult.Imagen = query.Imagen;
                        usuarioResult.Status = query.Status;
                        //Instancia ya que almacenamos valor desde la BD 
                        usuarioResult.Rol = new ML.Rol();
                        usuarioResult.Rol.IdRol = query.IdRol;
                        usuarioResult.Rol.Nombre = query.NombreRol;
                        usuarioResult.Direccion = new ML.Direccion();
                        usuarioResult.Direccion.IdDireccion = query.IdDireccion;
                        usuarioResult.Direccion.Calle = query.Calle;
                        usuarioResult.Direccion.NumeroInterior = query.NumeroInterior;
                        usuarioResult.Direccion.NumeroExterior = query.NumeroExterior;
                        //COLONIA 
                        usuarioResult.Direccion.Colonia = new ML.Colonia();
                        usuarioResult.Direccion.Colonia.IdColonia = query.IdColonia;
                        usuarioResult.Direccion.Colonia.Nombre = query.NombreColonia;
                        usuarioResult.Direccion.Colonia.CodigoPostal = query.CodigoPostal;
                        //MUNICIPIO
                        usuarioResult.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuarioResult.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio;
                        usuarioResult.Direccion.Colonia.Municipio.Nombre = query.NombreMunicipio;
                        //ESTADO
                        usuarioResult.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuarioResult.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado;
                        usuarioResult.Direccion.Colonia.Municipio.Estado.Nombre = query.NombreEstado;
                        //PAIS
                        usuarioResult.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuarioResult.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais;
                        usuarioResult.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.NombrePais;

                        //Unboxing
                        result.Object = usuarioResult; //Se iguala a la PROPIEDAD OBJECT ya que es un solo objeto y no varios
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false; //validacion de no encontrado
                        result.ErrorMessage = "Usuario no encontrado";
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
        public static void CargaMasivaTxt()
        {
            string file = @"C:\Users\digis\OneDrive\Documents\RodriguezCruzBrianAlejandro\BRodriguezProgramacionNCapasAgosto\PL_MVC\Files\CargaMasivaUsuario.txt";

            if (File.Exists(file)) //validamos que el archivo exista 
            { 
                StreamReader streamReader = new StreamReader(file);//leemos el archivo y guardamos en un objeto
                
                string line = streamReader.ReadLine(); //lee linea por linea, y ademas aqui ya esta leyendo la primera del archivo, o sea, mis encabezados

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] row = line.Split('|'); //se crea arreglo string y le indicamos que lo obtenido en la linea se parte cada "paip" encontrado

                    ML.Usuario usuario = new ML.Usuario();

                    usuario.Nombre = row[0].ToString(); //puede usarse o no "ToString" ya que es un arreglo de strings 
                    usuario.ApellidoPaterno = row[1];
                    usuario.ApellidoMaterno = row[2];
                    usuario.FechaNacimiento = DateTime.Parse(row[3].ToString());
                    usuario.Telefono = row[4];
                    usuario.Sexo = row[5];
                    usuario.Rol = new ML.Rol(); // para la prop de navegacion
                    usuario.Rol.IdRol = int.Parse(row[6].ToString());
                    usuario.UserName = row[7];
                    usuario.Email = row[8];
                    usuario.Password = row[9];
                    usuario.Celular = row[10];
                    usuario.Curp = row[11];
                    if (row[12] == "null")
                    {
                        row[12] = "";
                        usuario.Imagen = row[12];
                    }
                    else
                    {
                        usuario.Imagen = row[12];
                    }

                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();
                    usuario.Direccion.Calle = row[13];
                    usuario.Direccion.NumeroInterior = row[14];
                    usuario.Direccion.NumeroExterior = row[15];
                    usuario.Direccion.Colonia.IdColonia = int.Parse(row[16].ToString());

                }
                Console.WriteLine("SE INGRESO UN USUARIO CORRECTAMENTE");
            }
        }
        public static ML.Result LeerExcel(string connectionString)
        {
            ML.Result result = new ML.Result();
            //codigo pero antes va el controlador, es igual que con SQLCLIENT pero con OleDb

            try
            {
                using(OleDbConnection context = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM [Sheet1$]"; //consulta en OleDB para leer o traer todos los registros de mi hoja 1 de excel
                                                       
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        //command ejecuta los procesos, y para hacerlo, éste necesita la conexion y la consulta a realizar

                        OleDbDataAdapter da = new OleDbDataAdapter(); //hace de puente entre los datos de la DB y los dataSet o tables para 
                                                                    //recuperar la info de la DB y llenar los dataSet o tables
                        da.SelectCommand = cmd; // seleciona la consulta a ejecutar 

                        DataTable tablaUsuario = new DataTable(); // creamos objeto con propiedades del las dataTables (creamos tabla)

                        da.Fill(tablaUsuario); //se ejecuta la consulta en "da, y se llena la tablaUsuario con los datos recuperados de esa consulta 

                        if (tablaUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tablaUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.Nombre = row[0].ToString();
                                usuario.ApellidoPaterno = row[1].ToString();
                                usuario.ApellidoMaterno = row[2].ToString();
                                usuario.FechaNacimiento = DateTime.Parse(row[3].ToString());
                                usuario.Telefono = row[4].ToString();
                                usuario.Sexo = row[5].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse (row[6].ToString());

                                usuario.UserName = row[7].ToString();
                                usuario.Email = row[8].ToString();
                                usuario.Password = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.Curp = row[11].ToString();
                                usuario.Imagen = row[12].ToString();

                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Direccion.Calle = row[13].ToString();
                                usuario.Direccion.NumeroInterior = row[14].ToString();
                                usuario.Direccion.NumeroExterior = row[15].ToString();
                                usuario.Direccion.Colonia.IdColonia = int.Parse(row[16].ToString());

                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;
                        }

                        result.Object = tablaUsuario;

                        if(tablaUsuario.Rows.Count > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No hay regsitros en la tabla";
                        }
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
        public static ML.Result ValidarExcel(List<object> usuarios)
        {
            ML.Result result = new ML.Result();

            try
            {
                result.Objects = new List<object>(); //inicializo lista de objetos result para guardar los registros incompletos
                int i = 1; //guarda el numero de la fila

                foreach (ML.Usuario usuario in usuarios) //recorremos la lista usuarios ingresada en el parametro y guradamos en usuario 
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();
                    error.IdRegistro = i++;

                    if (usuario.Nombre == "")
                    {
                        error.Mensaje += "Ingresar nombre por favor";
                    }

                    if (usuario.ApellidoPaterno == "")
                    {
                        error.Mensaje += "Ingresar Apellido Paterno ";
                    }
                    if (usuario.ApellidoMaterno == "")
                    {
                        error.Mensaje += "Ingresar Apellido Materno";
                    }
                    if ((usuario.FechaNacimiento).ToString() == "")
                    {
                        error.Mensaje += "Ingresar  Fecha de nacimiento";
                    }
                    if (usuario.Telefono == "")
                    {
                        error.Mensaje += "Ingresar Telefono  ";
                    }
                    if (usuario.Sexo == "")
                    {
                        error.Mensaje += "Ingresar sexo ";
                    }
                    //usuario.Rol = new ML.Rol();
                    if ((usuario.Rol.IdRol).ToString() == "")
                    {
                        error.Mensaje += "Ingresar ROL | ";
                    }
                    if (usuario.UserName == "")
                    {
                        error.Mensaje += "Ingresar nombre de usuario | ";
                    }
                    if (usuario.Email == "")
                    {
                        error.Mensaje += "Ingresar correo electronico | ";
                    }
                    if (usuario.Password == "")
                    {
                        error.Mensaje += "Ingresar contraseña | ";
                    }
                    if(usuario.Celular == "")
                    {
                        error.Mensaje += "Ingresar celular | ";
                    }
                    if(usuario.Curp == "")
                    {
                        error.Mensaje += "Ingresar curp | ";
                    }

                   // usuario.Direccion = new ML.Direccion();

                    if (usuario.Direccion.Calle == "")
                    {
                        error.Mensaje += "Ingresar calle | ";
                    }
                    if (usuario.Direccion.NumeroExterior == "")
                    {
                        error.Mensaje += "Ingresar No. Exterior | ";
                    }
                    if (usuario.Direccion.NumeroInterior == "")
                    {
                        error.Mensaje += "Ingresar No. Interior | ";
                    }

                    //usuario.Direccion.Colonia = new ML.Colonia();
                    if ((usuario.Direccion.Colonia.IdColonia).ToString() == "")
                    {
                        error.Mensaje += "Ingresar ID de la colonia | ";
                    }


                    if (error.Mensaje != null)
                    {
                        result.Objects.Add(error);
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result ChangeStatus(int IdIsuario, bool Status)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var rowsAffected = context.UsuarioChangeStatus(IdIsuario,Status);

                    if (rowsAffected > 0)
                    {
                        result.Correct=true;
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
        public static ML.Result GetByEmail(string email)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = context.UsuarioGetByEmail(email).FirstOrDefault();

                    if(query != null )
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.Email = query.Email;
                        usuario.Password = query.Password;

                        result.Object = usuario;

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
                result.Ex= ex;
            }
            return result;
        }
        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    DLEF.Usuario usuario1 = new DLEF.Usuario();
                    //paso de mi modelo "usuario" al modelo "usuario1" pero de entity
                    usuario1.Nombre = usuario.Nombre;
                    usuario1.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuario1.ApellidoMaterno = usuario.ApellidoPaterno;
                    usuario1.FechaNacimiento = usuario.FechaNacimiento;
                    usuario1.Telefono = usuario.Telefono;
                    usuario1.Sexo = usuario.Sexo;
 //"IdRol" se puede usar ya que ya esta instanciado en PL --- pero en usuario SI se debe usar la propiedad de navegacion .ROL
                    usuario1.IdRol = usuario.Rol.IdRol; 

                    context.Usuario.Add(usuario1); //CONTEXT conoce todo de su propio modelo creado por ENTITY, es por eso que se guarda
                                                   //  "usuario1" que tambien es un objeto de su propia clase "usuario" y no la mia
                    context.SaveChanges();//guarda cambios OUES ANTES DE ESTE METODO estan guardados temporalmente, y devuelve un INT 

                    result.Correct = true; //Validar resultado si no, no maarcara el exito de la insercion
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
        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = (from aliasUsuario in context.Usuario
                                 where aliasUsuario.IdUsuario == usuario.IdUsuario
                                 select aliasUsuario).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.FechaNacimiento = usuario.FechaNacimiento;
                        query.Telefono = usuario.Telefono;
                        query.Sexo = usuario.Sexo;
//"IdRol" se puede usar ya que ya esta instanciado en PL --- pero en usuario SI se debe usar la propiedad de navegacion .ROL
                        query.IdRol = usuario.Rol.IdRol;
                        context.SaveChanges();

                        result.Correct = true; //Se debe validar si no, no marca la correcta insercion
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo correctamente el usuario";
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
        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    // "aliasUsuario" es un alias para la tabla, y "Usuario" es el Modelo q creo ENTITY
                    var query = (from aliasUsuario in context.Usuario
                                 where aliasUsuario.IdUsuario ==  usuario.IdUsuario
                                 select aliasUsuario).First();

                    context.Usuario.Remove(query);
                    int RowsAffected = context.SaveChanges();

                    if(RowsAffected > 0 )
                    {
                        result.Correct = true; //validar la eliminacion correcta
                    }
                    else
                    {
                        result.Correct= false;
                        result.ErrorMessage = "No se encontro registro para eliminar";
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
        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = (from User in context.Usuario //foreach inverso, de context.usuario guardalos en User (user es una variable temporal)
                                 join Roll in context.Rol on User.IdRol equals Roll.IdRol
                                 select new { IdUsuarioUser = User.IdUsuario, NombreUsuario = User.Nombre, 
                                 ApellidoPaternoUsuario = User.ApellidoPaterno, ApellidoMaternoUsuario = User.ApellidoMaterno,
                                 FechaNacimientoUsuario = User.FechaNacimiento, TelefonoUsuario = User.Telefono,
                                 SexoUsuario = User.Sexo, IdRolJoin = User.IdRol, NombreRol = Roll.Nombre}).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            
                            usuario.IdUsuario = registro.IdUsuarioUser;
                            usuario.Nombre = registro.NombreUsuario;
                            usuario.ApellidoPaterno = registro.ApellidoPaternoUsuario;
                            usuario.ApellidoMaterno = registro.ApellidoMaternoUsuario;
                            usuario.FechaNacimiento = registro.FechaNacimientoUsuario;
                            usuario.Telefono = registro.TelefonoUsuario;
                            usuario.Sexo = registro.SexoUsuario;
                            //Instancia para almacenar desde la BD 
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = registro.IdRolJoin;
                            usuario.Rol.Nombre = registro.NombreRol;

                            result.Objects.Add(usuario); //Mete los "nuevos" valores que ya tiene usuario a mi propiedad Objects
                        }
                        result.Correct = true; //Validamos que se mostro correctamente
                    }
                    else
                    {
                        result.Correct = false; //Validamos que no se mostro
                        result.ErrorMessage = "No hay registros en la tabla";
                    }
                }
            }
            catch(Exception ex) 
            {
                result.Correct = false; //Valido el error
                result.ErrorMessage = ex.Message; // Muestra msj de la excepcion en pantalla
                result.Ex = ex; //Guarda toda la excepcion
            }
            return result;
        }
        public static ML.Result GetByIdLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.BRodriguezProgramacionNCapasAgostoEntities context = new DLEF.BRodriguezProgramacionNCapasAgostoEntities())
                {
                    var query = (from User in context.Usuario
                                  join Rolls in context.Rol on User.IdRol equals Rolls.IdRol
                                  where User.IdUsuario == usuario.IdUsuario
                                  select new {IdUsuarioUser = User.IdUsuario, NombreUsuario = User.Nombre,
                                  ApellidoPaternoUsuario = User.ApellidoPaterno, ApellidoMaternoUsuario = User.ApellidoMaterno,
                                  FechaNacimientoUsuario = User.FechaNacimiento, TelefonoUsuario = User.Telefono,
                                  SexoUsuario = User.Sexo,IdRolJoin = User.IdRol, NombreRol = Rolls.Nombre}).SingleOrDefault();         
                   
                    if(query != null)
                    {                
                            ML.Usuario usuarioResult = new ML.Usuario();

                            usuarioResult.IdUsuario = query.IdUsuarioUser;
                            usuarioResult.Nombre = query.NombreUsuario;
                            usuarioResult.ApellidoPaterno = query.ApellidoPaternoUsuario;
                            usuarioResult.ApellidoMaterno = query.ApellidoMaternoUsuario;
                            usuarioResult.FechaNacimiento = query.FechaNacimientoUsuario;
                            usuarioResult.Telefono = query.TelefonoUsuario;
                            usuarioResult.Sexo = query.SexoUsuario;
                            //Instancia para alamcenar valores
                            usuarioResult.Rol = new ML.Rol();
                            usuarioResult.Rol.IdRol = query.IdRolJoin;
                            usuarioResult.Rol.Nombre = query.NombreRol;

                            result.Object = usuarioResult;
                            result.Correct =  true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el regsitro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;//validamos el error
                result.ErrorMessage= ex.Message;
                result.Ex = ex;  //Guardamos toda la excepcion
            }
            return result;
        }
    }
}
