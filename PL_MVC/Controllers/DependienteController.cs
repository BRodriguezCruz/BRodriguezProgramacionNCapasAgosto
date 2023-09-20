using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DependienteController : Controller
    {
        // GET: Dependiente

        public ActionResult Delete(int idRecuperado)
        {
            ML.Result result = BL.Dependiente.DeleteEF(idRecuperado);

            if (result.Correct)
            {
                ViewBag.Message = "REGISTRO ELIMINADO EXITOSAMENTE";
            }
            else
            {
                ViewBag.Message = "FALLO AL ELIMINAR, REGISTRO NO ELIMINADO";
            }

            return PartialView("Modal");
        }
        
        
        [HttpGet]
        public ActionResult GetDependiente(string idEmpleado)
        {
            ML.Dependiente dependiente = new ML.Dependiente();
            ML.Result resultDependiente = BL.Dependiente.GetByIdEmpleado(idEmpleado);

            dependiente.Dependientes = resultDependiente.Objects;
            dependiente.Empleado = new ML.Empleado();
            dependiente.Empleado.IdEmpleado = idEmpleado;
            Session["idEmpleado"] = idEmpleado;

            return View(dependiente);
        }

        [HttpGet] 
       public ActionResult Form(string idEmpleado, int? idDependiente)
        {
            ML.Dependiente dependiente = new ML.Dependiente();
            dependiente.Empleado = new ML.Empleado();
            idEmpleado = (string)Session["idEmpleado"];
            dependiente.Empleado.IdEmpleado = idEmpleado;

            if(idEmpleado != null && idDependiente != null )
            {
                ML.Result result = BL.Dependiente.GetByIdEF(idDependiente.Value);
                if (result.Correct)
                {
                    dependiente = (ML.Dependiente)result.Object;
                }

            }
            return View(dependiente);
        }

        [HttpPost]
        public ActionResult Form(ML.Dependiente dependiente)
        {

            if(dependiente.IdDependiente == 0)
            {
                dependiente.Empleado.IdEmpleado = (string)Session["idEmpleado"];

                ML.Result result = BL.Dependiente.AddEF(dependiente);

                if (result.Correct)
                {
                    ViewBag.Message = "REGISTRO AGREGADO CON EXITO";
                    Session["idEmpleado"] = null;
                }
                else
                {
                    ViewBag.Message = "ERROR, REGISTRO NO AGREGADO";
                    Session["idEmpleado"] = null;
                }
            }
            else
            {
                ML.Result result = BL.Dependiente.UpdateEF(dependiente);

                if (result.Correct)
                {
                    ViewBag.Message = "REGISTRO ACTUALIZADO CON EXITO";
                    Session["idEmpleado"] = null;
                }
                else
                {
                    ViewBag.Message = "ERROR, REGISTRO NO ACTUALIZADO";
                    Session["idEmpleado"] = null;
                }
            }

            return RedirectToAction("GetDependiente", "Dependiente");
            //return PartialView("Modal");
        }

    }
}