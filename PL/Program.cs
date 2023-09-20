using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Por favor selecciona la opcion que requieres: ");
            Console.WriteLine(" 1) Añadir nuevo usuario");
            Console.WriteLine(" 2) Eliminar usuario");
            Console.WriteLine(" 3) Editar usuario");
            Console.WriteLine(" 4) Mostrar Lista de registros");
            Console.WriteLine(" 5) Mostrar usuario especifico"); 
            Console.WriteLine(" 6) INGRESAR POR CARGA MASIVA TXT");
            Console.WriteLine(" Presione ENTER despues de ingresar el numero de consulta");
            int x = int.Parse(Console.ReadLine());

            switch (x)
            {
                case 1:
                    PL.Usuario.Add();
                    Console.ReadKey();
                    break;

                case 2:
                    PL.Usuario.Delete();
                    Console.ReadKey();
                    break;

                case 3:
                    PL.Usuario.Update();
                    Console.ReadKey();
                    break;

                /*case 4:
                    PL.Usuario.GetAll();
                    Console.ReadKey();
                    break;*/

                case 5:
                    Console.WriteLine($"Tu ingresaste opcion numero {x}, por favor presiona ENTER para avanzar");
                    Console.ReadKey();
                    PL.Usuario.GetById();
                    Console.ReadKey();
                    break;

                case 6:
                    BL.Usuario.CargaMasivaTxt();
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("No existe esta opcion");
                    break;
            }
            
        }
    }
}
