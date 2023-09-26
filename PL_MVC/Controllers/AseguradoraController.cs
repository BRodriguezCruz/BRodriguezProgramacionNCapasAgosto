using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {

        /* public ActionResult GetAll()
         {
             ML.Aseguradora aseguradora = new ML.Aseguradora();

             ML.Result result = new ML.Result();
             result = BL.Aseguradora.GetAll();


             if (result.Correct)
             {
                 aseguradora.Aseguradoras = result.Objects;
                 return View(aseguradora);
             }
             else
             {
                 return View();
             }
         }*/

        /*
        [HttpGet]
        //Creacion de nuevo Get, que comunica con el servidor (WCF)
        public ActionResult GetAll()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            ServiceReferenceAseguradora.AseguradoraServiceClient serviceWCF = new ServiceReferenceAseguradora.AseguradoraServiceClient(); //instancia para acceder al servicio y lo relacionado a el
            var resultado = serviceWCF.GetAll(); //aqui se llama al GETALL en el servicio, no al de BL, yse pasan sus caracteristicas a la variable para trabaajr con ellas aqui

            if (resultado.Correct)
            {
                aseguradora.Aseguradoras = resultado.Objects.ToList();
            }
            return View(aseguradora);
        }
        */

        [HttpGet]
        //Creacion de nuevo Get, que comunica con el servidor (WEB API)
        public ActionResult GetAll()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Aseguradoras = new List<object>(); 

            //LLAMADO AL SERVICIO
            ML.Result result   = new ML.Result();

            using (var cliente = new HttpClient()) //variable que puede acceder a los servicios 
            {
                cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]); //hacer el llamado a el APP SETTING 
                var respondeTask = cliente.GetAsync("aseguradora");
                respondeTask.Wait(); //espera por respuesta

                var resultServicio = respondeTask.Result;   //igualamos el resultado de la respuesta a una variable 

                if(resultServicio.IsSuccessStatusCode) // si el resultado del servicio es exitoso 
                {
                    var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultAseguradora in readTask.Result.Objects)
                    {
                        ML.Aseguradora resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Aseguradora>(resultAseguradora.ToString());
                        aseguradora.Aseguradoras.Add(resultItemList);
                    }
                }

            }

                return View(aseguradora);
        }


        /* METODOS PARA CONSUMIR DIRECTAMENTE EL BL Y SERVICIOS WCF
        [HttpGet]
        public ActionResult Form(int? idAseguradora) //el nombre del ID debe ser el mismo escrito en el href de mi vista getAll
                                                   // Un ? significa que puede estar lleno o no ese campo
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";

            ML.Result result = new ML.Result(); //instanciamos objeto result para acceder a sus prop
            result = BL.Usuario.GetAllEF(usuario); //igualamos el metodo en BL de Usuarios para traer todos los datos de "usuario" y guardarlos en las prop de RESULT


            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario(); // instanciamos propiedad de navegacion para poder almacenar nuevos datos 

            if(idAseguradora != null)
            {
                ML.Result resultAseguradora = BL.Aseguradora.GetById(idAseguradora.Value); //value forza a tener o escoger un valor 

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
        */

        [HttpGet] //FORM PARA WEB API 
        public ActionResult Form(int? idAseguradora) //el nombre del ID debe ser el mismo escrito en el href de mi vista getAll
                                                     // Un ? significa que puede estar lleno o no ese campo
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";

            ML.Result result = new ML.Result(); //instanciamos objeto result para acceder a sus prop
            result = BL.Usuario.GetAllEF(usuario); //igualamos el metodo en BL de Usuarios para traer todos los datos de "usuario" y guardarlos en las prop de RESULT

            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario(); // instanciamos propiedad de navegacion para poder almacenar nuevos datos 

            if (idAseguradora != null)
            {
                using (var cliente = new HttpClient()) //variable para accder a los servicios HTTP 
                {
                    cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);
                    var responseTask = cliente.GetAsync("aseguradora/" + idAseguradora);
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Aseguradora resultItemsList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Aseguradora>(readTask.Result.Object.ToString());
                        
                        aseguradora = resultItemsList;

                    }
                }
                    aseguradora.Usuario.Usuarios = result.Objects;             
            }
            else //mostrar vista vacia
            {
                aseguradora.Usuario.Usuarios = result.Objects; //igualo la prop ojects (con datos) a la propiedad de navegacion en su campo usuarios para mostrarlos
            }

            return View(aseguradora);
        }

        /* METODOS PARA CONSUMIR DIRECTAMENTE EL BL Y SERVICIOS WCF
        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {
            if (aseguradora.IdAseguradora == 0)
            {
                //ML.Result result = BL.Aseguradora.AddEF(aseguradora); "aqui conecta diractamente con BL" es por eso que se comenta
                //WCF:
                ServiceReferenceAseguradora.AseguradoraServiceClient aseguradoraWCF = new ServiceReferenceAseguradora.AseguradoraServiceClient();
                //WCF:
                var result = aseguradoraWCF.Add(aseguradora); //creamos variable con el mismo nombre anterior "result" para igularle las caracteristicas del objeto del servicio

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
                //ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);
                ServiceReferenceAseguradora.AseguradoraServiceClient aseguradoraWCF = new ServiceReferenceAseguradora.AseguradoraServiceClient();
                //WCF:
                var result = aseguradoraWCF.Update(aseguradora); //creamos variable con el mismo nombre anterior "result" para igularle las caracteristicas del objeto del servicio

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
        */


        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {
            if (aseguradora.IdAseguradora == 0)
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);

                    //HTTP POST
                    var postTask = cliente.PostAsJsonAsync("aseguradora", aseguradora);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se Agrego correctamente la aseguradora";
                    }
                    else
                    {
                        ViewBag.Message = "No se pudo agregar la Aseguradora";
                    }
                }
            }
            else
            {
                using (var cliente = new HttpClient()) 
                {
                    int idAseguradora = aseguradora.IdAseguradora;

                    cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);

                    var putTask = cliente.PutAsJsonAsync("aseguradora/" + idAseguradora, aseguradora);
                    putTask.Wait(); 

                    var result = putTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "SE ACTUALIZO CORRECTAMENTE LA ASEGURADORA";
                    }
                    else
                    {
                        ViewBag.Message = "NO SE LOGRO ACTUALIZAR LA ASEGURADORA";
                    }
                }               
            }

            return PartialView("Modal");
        }


        /* METODOS PARA CONSUMIR DIRECTAMENTE EL BL Y SERVICIOS WCF
        public ActionResult Delete(int idRecuperado) //El nombre del id debe ser igual al declaado en la vista 
        {
            //ML.Result result = new ML.Result(); se comento para agregar la conexcion con el servicio web 
            //result = BL.Aseguradora.DeleteEF(idRecuperado);

            //WCF:
            ServiceReferenceAseguradora.AseguradoraServiceClient aseguradoraWCF = new ServiceReferenceAseguradora.AseguradoraServiceClient();
            //WCF:
            var result = aseguradoraWCF.Delete(idRecuperado);
            
            if(result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente la aseguradora";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error, no se elimino la aseguradora";
;           }

            return PartialView("Modal"); // SE REGRESA UNA PARTIALVIEW y no una VIEW
        }
        */

        public ActionResult Delete(int idRecuperado) //El nombre del id debe ser igual al declaado en la vista 
        {
            using(var cliente = new HttpClient()) 
            {
                cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);

                var deleteTask = cliente.DeleteAsync("aseguradora/" + idRecuperado);
                deleteTask.Wait();

                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se elimino correctamente la aseguradora";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error, no se elimino la aseguradora"
;                }
            
            }

            return PartialView("Modal"); // SE REGRESA UNA PARTIALVIEW y no una VIEW
        }
    }
}