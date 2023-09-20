using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            empleado.Nombre = "";

            ML.Result result = new ML.Result();
            result = BL.Empleado.GetAllEF(empleado);

            ML.Result resultEmpresa = new ML.Result();
            resultEmpresa = BL.Empresa.GetAll();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                empleado.Empresa.Empresas = resultEmpresa.Objects;
                return View(empleado);
            }
            else
            {
                empleado.Empresa.Empresas = resultEmpresa.Objects;
                return View();
            }
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
        public ActionResult Delete(string idRecuperado)
        {
            ML.Empleado empleado = new ML.Empleado();

            ML.Result result = BL.Empleado.DeleteEF(idRecuperado);

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
                ML.Result result = BL.Empleado.AddEF(empleado);

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
                ML.Result result = BL.Empleado.UpdateEF(empleado);

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

        public string ConvertirABase64(HttpPostedFileBase Foto) //metodo para convetir la imagen a base 64 y entre a la BD
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }
    }
}