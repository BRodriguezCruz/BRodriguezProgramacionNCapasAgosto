using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        public ActionResult Cargar()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            return View(result);
        }

        [HttpPost]
        public ActionResult Cargar(ML.Result result)
        {

            HttpPostedFileBase file = Request.Files["Excel"]; //nombre o ID de mi archivo en la vista
                                                              // linea usada para obtener el archivo subido y almacenarlo en un objeto 

            if (Session["pathExcel"] == null)
            {

                if (file != null)
                {
                    string extensionArchivo = Path.GetExtension(file.FileName).ToLower(); //obtenemos nombre del archivo junto con su extension
                    string extensionValida = ConfigurationManager.AppSettings["TipoExcel"]; //obtenemos la extension del archivo y validamos en el web.config

                    if (extensionArchivo == extensionValida) //validamos que sean iguales las extensiones 
                    {

                        string rutaProyecto = Server.MapPath("~/CargaMasiva/"); //"ruta relativa", encontramos la direccion del proyecto hasta la carpeta CargaMasiva 
                        string filePath = rutaProyecto + Path.GetFileNameWithoutExtension(file.FileName) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                        // concatenamos la ruta del proyecto (donde se guardara la copia) y creamos el nombre de la copia diferenciada por el momento en el que fue creada
                        //hasta este momento aun no se crea la copia, solo se ha hecha la ruta y el nombre con el que se guardara

                        if (!System.IO.File.Exists(filePath)) //si la existencia de la copia es false entonces:
                        {
                            file.SaveAs(filePath); //aqui se copia el archivo a traves de "file", y se guarda en la rura "filePath" con lasa caracteristicas
                                                   //que previamente se declararon arriba (en este momento YA SE CREA LA COPIA)

                            string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filePath;
                            //configuramos cadena de conexion con OLEDB y le concatenamos la ruta de la copia del archivo (que sera la fuente de datos)
                            //para completar la cadena de conexion pues en la ""connectionString => dataSource" de webConfig no esta completa.


                            ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString); //igualamos un objeto result al metodo creado en BL para leer el excel
                                                                                               // el cual me regresa un lista de objectos para usarse en la validacion abajo
                            if (resultUsuarios.Correct)
                            {
                                ML.Result resultValidacion = BL.Usuario.ValidarExcel(resultUsuarios.Objects); // validamos que no vengan espacios en blanco
                                                                                                              //y me regresa una lista de objetos (errores) en casa de traer 

                                if (resultValidacion.Objects.Count == 0) //si la lista de objetos es igual a 0, significa que no tiene errroes 
                                {
                                    result.Correct = true;
                                    Session["pathExcel"] = filePath; //creamos Session para guardar la ubicacion del archivo copia y no perderlo luego de la validacion

                                }

                                return View(resultValidacion);
                            }
                            else
                            {
                                ViewBag.Message = "El excel no tiene registros";
                                return PartialView("Modal");
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Message = "No selecciono un archivo con extension .xlsx, verifique nuevamente";
                        return PartialView("Modal");

                    }
                }
                else
                {
                    ViewBag.Message = "No seleciono ningun archivo, verifique";
                    return PartialView("Modal");
                }

                return View(result);
                
            }
            else // SI NO ES NULA, ENTONCES YA EXISTIA Y VIENE ACA
            {
                string filePath = Session["pathExcel"].ToString(); //Guardamos la session una variable

                if (filePath != null) //validamos que 
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filePath; 
                    ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString);

                    if (resultUsuarios.Correct)
                    {

                        foreach (ML.Usuario usuario in resultUsuarios.Objects)
                        {
                            ML.Result result1 = BL.Usuario.AddEF(usuario);

                            if (!result1.Correct)
                            {
                                //PENDIENTE CREAR UN TXT CON LOS ERRORES 
                            }
                            Session["pathExcel"] = null; //limpiamos la session para que al terminar de usar el archivo copia, se borre y se puede reusar la session

                        }
                    }

                }
                else
                {

                }
            }
            return View(result);
        }
    }
}