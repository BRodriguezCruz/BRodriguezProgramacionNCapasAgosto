using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado

        /* METODO PARA CONSUMIR DIRACTAMENTE EL BL Y/O TAMBIEN CON SERVICIO WCF
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            empleado.Nombre = "";
            empleado.Empresa.IdEmpresa = 0; // se agrego para que el servicio web funcionara
           // ML.Result result = BL.Empleado.GetAllEF(empleado); comentada debido a que se implemento el WEB SERVICE

            //WCF:
            ServiceReferenceEmpleado.EmpleadoServiceClient empleadoWCF = new ServiceReferenceEmpleado.EmpleadoServiceClient();
            var result = empleadoWCF.GetAll(empleado);
            
            ML.Result resultEmpresa = BL.Empresa.GetAll();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects.ToList(); //SE PARSEA con "toList" PUES LA "var RESULT" devuelve un arreglo y empleados recibe una lista
                empleado.Empresa.Empresas = resultEmpresa.Objects;
                return View(empleado);
            }
            else
            {
                empleado.Empresa.Empresas = resultEmpresa.Objects;
                return View();
            }
        }
        */
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();

            empleado.Nombre = "";
            empleado.Empresa.IdEmpresa = 0; // se agrego para que el servicio web funcionara
                                            // ML.Result result = BL.Empleado.GetAllEF(empleado); comentada debido a que se implemento el WEB SERVICE
            empleado.Empleados = new List<object>();
            ML.Result resultEmpresa = BL.Empresa.GetAll();           

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);
                var respondeTask = cliente.GetAsync($"empleado?idEmpresa=&nombreEmpleado=");// ("empleado/" + empleado.Empresa.IdEmpresa + "/" + empleado.Nombre);
                respondeTask.Wait(); //pendiente que entre al controlador de SLWeb API

                var resultServicio = respondeTask.Result;

                if (resultServicio.IsSuccessStatusCode)
                {
                    var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultEmpleado in readTask.Result.Objects)
                    {
                        ML.Empleado resultListItems = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(resultEmpleado.ToString());

                        empleado.Empleados.Add(resultListItems);
                    }
                    //empleado.Empleados = result.Objects.ToList();
                    empleado.Empresa.Empresas = resultEmpresa.Objects;                  
                }
                else
                {
                    empleado.Empresa.Empresas = resultEmpresa.Objects;                 
                }
            }
            return View(empleado);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Empleado empleado)
        {
            if (empleado.Nombre == null)
            {
                empleado.Nombre = "";
            }

            ML.Result result = new ML.Result();
            result = BL.Empleado.GetAllEF(empleado);
            ML.Result resultEmpresa = new ML.Result();
            resultEmpresa = BL.Empresa.GetAll();

            empleado.Empleados = result.Objects;
            empleado.Empresa.Empresas = resultEmpresa.Objects;
            return View(empleado);
        }

        /*
        public ActionResult Delete(string idRecuperado)
        {
            //ML.Empleado empleado = new ML.Empleado(); "REVISAR SI SE OCUPA ESTA INSTANCIA"
           // ML.Result result = BL.Empleado.DeleteEF(idRecuperado); comentado debido aque se agrega el servicio WEB

            //WCF:
            ServiceReferenceEmpleado.EmpleadoServiceClient empleadoWCF = new ServiceReferenceEmpleado.EmpleadoServiceClient();
            var result = empleadoWCF.Delete(idRecuperado);

            if (result.Correct)
            {
                ViewBag.Message = "Se elimino correctamente al empleado";
            }
            else
            {
                ViewBag.Message = "No se elimino al empleado";
            }
            return PartialView("Modal");
        }
        */
        public ActionResult Delete(string idRecuperado)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);
                var deleteTask = cliente.DeleteAsync("empleado/" + idRecuperado);
                deleteTask.Wait();

                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)

                {
                    ViewBag.Message = "Se elimino correctamente al empleado";
                }
                else
                {
                    ViewBag.Message = "No se elimino al empleado";
                }
                return PartialView("Modal");
            }
        }

        /* METODO PARA CONSUMIR DIRACTAMENTE EL BL Y/O TAMBIEN CON SERVICIO WCF
       [HttpGet]
       public ActionResult Form(string idEmpleado)
       {
           ML.Empleado empleado = new ML.Empleado();
           empleado.Empresa = new ML.Empresa();

           ML.Result resultEmpresa = BL.Empresa.GetAll();

           if (idEmpleado == null)
           {
               empleado.Empresa.Empresas = resultEmpresa.Objects;
               empleado.Bandera = "add";
           }
           else
           {
               ML.Result result = BL.Empleado.GetById(idEmpleado);

               if (result.Correct)
               {
                   empleado = (ML.Empleado)result.Object;
                   empleado.Empresa.Empresas = resultEmpresa.Objects;
                   empleado.Bandera = "update";
               }
           }
           return View(empleado);
       }
        */

        [HttpGet]
        public ActionResult Form(string idEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();

            ML.Result resultEmpresa = BL.Empresa.GetAll();

            if (idEmpleado == null)
            {
                empleado.Empresa.Empresas = resultEmpresa.Objects;
                empleado.Bandera = "add";
            }
            else
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);
                    var responseTask = cliente.GetAsync("empleado/" +  idEmpleado);
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Empleado resultItemsList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(readTask.Result.Object.ToString());

                        empleado = resultItemsList;
                    }
                }            
                    //empleado = (ML.Empleado)result.Object;
                    empleado.Empresa.Empresas = resultEmpresa.Objects;
                    empleado.Bandera = "update";
            }
            return View(empleado);
        }


        /* METODO PARA CONSUMIR DIRACTAMENTE EL BL Y/O TAMBIEN CON SERVICIO WCF
       [HttpPost]
       public ActionResult Form(ML.Empleado empleado)
       {
           HttpPostedFileBase file = Request.Files["IdImagen"]; //conversion a base 64 de la imagen, ESTE DEBE SER EL MISMO ID que se le dio a la imagen en la vista
           if (file.ContentLength > 0)
           {
               empleado.Foto = ConvertirABase64(file);
           }

           if (empleado.Bandera == "add") // if (empleado.IdEmpleado == null)
           {
               //ML.Result result = BL.Empleado.AddEF(empleado); comentado debido a que se agrego el servicio web

               //WCF:
               ServiceReferenceEmpleado.EmpleadoServiceClient empleadoWCF = new ServiceReferenceEmpleado.EmpleadoServiceClient();
               var result = empleadoWCF.Add(empleado);            

               if (result.Correct)
               {
                   ViewBag.Message = "REGISTRO AGREGADO EXITOSAMENTE";
               }
               else
               {
                   ViewBag.Message = "FALLO AL REGISTRAR,REGISTRO NO AGREGADO:" + result.ErrorMessage;
               }
           }
           else
           {
               //ML.Result result = BL.Empleado.UpdateEF(empleado); comentado debido a que se agrego el servicio web
               ServiceReferenceEmpleado.EmpleadoServiceClient empleadoWCF = new ServiceReferenceEmpleado.EmpleadoServiceClient();
               var result = empleadoWCF.Update(empleado);

               if (result.Correct)
               {
                   ViewBag.Message = "REGISTRO ACTUALIZADO EXITOSAMENTE";
               }
               else
               {
                   ViewBag.Message = "FALLO AL ACTUALIZAR,REGISTRO NO AGREGADO:" + result.ErrorMessage;
               }

           }
           return PartialView("Modal");
       }
        */

        [HttpPost] //METODO PARA WEB SERVICE "WEB API"
        public ActionResult Form(ML.Empleado empleado)
        {
            HttpPostedFileBase file = Request.Files["IdImagen"]; //conversion a base 64 de la imagen, ESTE DEBE SER EL MISMO ID que se le dio a la imagen en la vista
            if (file.ContentLength > 0)
            {
                empleado.Foto = ConvertirABase64(file);
            }
            if (empleado.Bandera == "add") // if (empleado.IdEmpleado == null)
            {
                using (var cliente = new HttpClient() )
                {
                    cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);

                    //HTTP POST
                    var postTask = cliente.PostAsJsonAsync("empleado",empleado);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "REGISTRO AGREGADO EXITOSAMENTE";
                    }
                    else
                    {
                        ViewBag.Message = "FALLO AL REGISTRAR,REGISTRO NO AGREGADO";
                    }
                }
            }
            else
            {
                using(var cliente = new HttpClient() )
                {
                    cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);
                    var putTask = cliente.PutAsJsonAsync("empleado/" + empleado.IdEmpleado, empleado);
                    putTask.Wait();

                    var result = putTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "REGISTRO ACTUALIZADO EXITOSAMENTE";
                    }
                    else
                    {
                        ViewBag.Message = "FALLO AL ACTUALIZAR,REGISTRO NO AGREGADO";
                    }
                }
            }
            return PartialView("Modal");
        }
        public string ConvertirABase64(HttpPostedFileBase Foto) //metodo para convetir la imagen a base 64 y entre a la BD
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }
    }
}