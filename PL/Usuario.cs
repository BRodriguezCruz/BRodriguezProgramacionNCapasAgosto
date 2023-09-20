using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Escribe el nombre del usuario: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Escribe el USERNAME del usuario: ");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Escribe el Apellido Paterno del Usuario: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Escribe el Apellido Materno del Usuario ");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Escribe la fecha de nacimiento del usuario: ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Escribe el telefono del usuario: ");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Escribe el sexo del usuario: ");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Escribe el EMAIL del usuario: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Escribe LA CONTRASEÑA del usuario: ");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Escribe el CELULAR del usuario: ");
            usuario.Celular = Console.ReadLine(); 
            Console.WriteLine("Escribe el CURP del usuario: ");
            usuario.Curp = Console.ReadLine();
            //INSTANCIA PARA ALMACENAR DATOS DESDE AFUERA (1era vez que se utiliza)
            usuario.Rol = new ML.Rol();
            Console.WriteLine("Escribe el ID del rol: ");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.AddEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("USUARIO AGRAGADO EXITOSAMENTE");
            }
            else
            {
                Console.WriteLine($"El usuario no se agrego correctamente: {result.ErrorMessage}");
            }
            
        }
        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Escribe el ID del registro que quieres actualizar: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nombre del usuario: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Escribe el USERNAME del usuario: ");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Escribe el Apellido Paterno del Usuario: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Escribe el Apellido Materno del Usuario ");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Escribe la fecha de nacimiento del usuario: ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Escribe el telefono del usuario: ");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Escribe el sexo del usuario: ");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Escribe el EMAIL del usuario: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Escribe LA CONTRASEÑA del usuario: ");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Escribe el CELULAR del usuario: ");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Escribe el CURP del usuario: ");
            usuario.Curp = Console.ReadLine();
            //INSTANCIA PARA ALMACENAR DATOS DESDE AFUERA 
            usuario.Rol = new ML.Rol();
            Console.WriteLine("Escribe el ID del rol: ");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.UpdateEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("USUARIO ACTUALIZADO CORRECTAMENTE");
            }
            else
            {
                Console.WriteLine($"No se actualizo correctamente el usuario: {result.ErrorMessage}");
            }
            
        }
        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Escribe el ID del registro que quieres eliminar: ");
            int IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);
            
            if (result.Correct)
            {
                Console.WriteLine("Usuario Eliminado correctamente");
            }
            else
            {
                Console.WriteLine($"No se elimino el usuario: {result.ErrorMessage}");
            }       
        }
        /*
        public static void GetAll()
        {
            ML.Result result = BL.Usuario.GetAllEF();    // ESTO ES IGUAL A LO DE ABAJO PERO SIMPLIFICADO
            /*
            ML.Result result = new ML.Result();
            result = BL.Usuario.GetAll();
            

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("Lista generada exitosamente");
                    Console.WriteLine($"Nombre: {usuario.Nombre}");
                    Console.WriteLine($"Nombre: {usuario.UserName}");
                    Console.WriteLine($"Apellido Paterno: {usuario.ApellidoPaterno}");
                    Console.WriteLine($"Apellido Materno: {usuario.ApellidoMaterno}");
                    Console.WriteLine($"Fecha de nacimiento: {usuario.FechaNacimiento}");
                    Console.WriteLine($"Telefono: {usuario.Telefono}");
                    Console.WriteLine($"Sexo: {usuario.Email}");
                    Console.WriteLine($"Sexo: {usuario.Password}");
                    Console.WriteLine($"Sexo: {usuario.Celular}");
                    Console.WriteLine($"Sexo: {usuario.Curp}");
                    Console.WriteLine($"Id del Usuario: {usuario.IdUsuario}");
                    Console.WriteLine($"Id del ROL: {usuario.Rol.IdRol}");
                    Console.WriteLine($"Nombre de ROL: {usuario.Rol.Nombre}");
                    Console.WriteLine("--------------------------------------");
                }
            }
            else
            {
                Console.WriteLine($"La lista no pudo ser generada porque: {result.ErrorMessage}");
            }
        }
            */
        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Escriba el ID del usuario a encontrar: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetByIdLINQ(usuario); //Igualamos el objeto result al metodo GetById para acceder a la prop
            //                                              correct y hace una condicion cuando se cumpla

            if (result.Correct)
            {
                //Unboxing
                usuario = (ML.Usuario)result.Object;
                Console.WriteLine("Lista generada exitosamente");
                Console.WriteLine($"Nombre: {usuario.Nombre}");
                Console.WriteLine($"Nombre de Usuario (USERNAME): {usuario.UserName}");
                Console.WriteLine($"Apellido Paterno: {usuario.ApellidoPaterno}");
                Console.WriteLine($"Apellido Materno: {usuario.ApellidoMaterno}");
                Console.WriteLine($"Fecha de nacimiento: {usuario.FechaNacimiento}");
                Console.WriteLine($"Telefono: {usuario.Telefono}");
                Console.WriteLine($"Email: {usuario.Email}");
                Console.WriteLine($"Password: {usuario.Password}");
                Console.WriteLine($"Celuar: {usuario.Celular}");
                Console.WriteLine($"Curp: {usuario.Curp}");
                Console.WriteLine($"Id del Usuario: {usuario.IdUsuario}");
                Console.WriteLine($"Id del ROL: {usuario.Rol.IdRol}");
                Console.WriteLine($"Nombre del ROL: {usuario.Rol.Nombre}");
            }
            else 
            {
                Console.WriteLine($"Error al mostrar el usuario: {result.ErrorMessage}");
            }
        }
    }
}
