using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        // GET: Aseguradora
        public ActionResult GetAll()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            ML.Result result = new ML.Result();
            result = BL.Aseguradora.AseguradoraGetAll();

            if (result.Correct)
            {
                aseguradora.Aseguradoras = result.Objects;
                return View(aseguradora);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Form(int? idAseguradora) //el nombre del ID debe ser el mismo escrito en el href de mi vista getAll
                                                   // Un ? significa que puede estar lleno o no ese campo
        {
            ML.Result result = new ML.Result(); //instanciamos objeto result para acceder a sus prop
            result = BL.Aseguradora.AseguradoraGetAll(); //igualamos el metodo en BL de Usuarios para traer todos los datos de "usuario" y guardarlos en las prop de RESULT


            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario(); // instanciamos propiedad de navegacion para poder almacenar nuevos datos 

            if(idAseguradora != null)
            {
                ML.Result resultAseguradora = BL.Aseguradora.AseguradoraGetById(idAseguradora.Value); //value forza a tener o escoger un valor 

                if (resultAseguradora.Correct)
                {
                    aseguradora = (ML.Aseguradora)resultAseguradora.Object;
                    aseguradora.Usuario.Usuarios = result.Objects;
                }
            }
            else //mostrar vista vacia
            {
                aseguradora.Usuario.Usuarios = result.Objects; //igualo la prop ojects (con datos) a la propiedad de navegacion en su campo usuarios para mostrarlos
            }

            return View(aseguradora);               
        }

        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {
            if (aseguradora.IdAseguradora == 0)
            {
                ML.Result result = BL.Aseguradora.AseguradoraAddEF(aseguradora);
                if (result.Correct)
                {
                    ViewBag.Message = "Se Agrego correctamente la aseguradora";
                }
                else
                {
                    ViewBag.Message = "No se pudo agregar la Aseguradora";
                }
            }
            else
            {
                ML.Result result = BL.Aseguradora.AseguradoraUpdate(aseguradora);

                if (result.Correct)
                {
                    ViewBag.Message = "SE ACTUALIZO CORRECTAMENTE LA ASEGURADORA";
                }
                else
                {
                    ViewBag.Message = "NO SE LOGRO ACTUALIZAR LA ASEGURADORA";
                }
            }

            return PartialView("Modal");
        }

        public ActionResult Delete(int idRecuperado) //El nombre del id debe ser igual al declaado en la vista 
        {
            ML.Result result = new ML.Result();
            result = BL.Aseguradora.AseguradoraDelete(idRecuperado);

            if(result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente la aseguradora";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error, no se elimino la aseguradora"
;           }
            return PartialView("Modal"); // SE REGRESA UNA PARTIALVIEW y no una VIEW
        }
    }
}