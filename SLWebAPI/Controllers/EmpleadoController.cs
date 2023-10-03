using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLWebAPI.Controllers
{

    [RoutePrefix("api/empleado")] //RUTA GLOBAL
    public class EmpleadoController : ApiController
    {

        [Route("")]
        [HttpPost] //añade
        public IHttpActionResult Add (ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.AddEF(empleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{idEmpleado}")]
        [HttpPut]//actualiza solo si existe, si no error.
        public IHttpActionResult Update (string idEmpleado, [FromBody] ML.Empleado empleado)
        {
            empleado.IdEmpleado = idEmpleado; //igualacion ya que viene NULO en el modelo

            ML.Result result = BL.Empleado.UpdateEF(empleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.Accepted, result);
            }
            else
            { 
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{idEmpleado}")]
        [HttpDelete]
        public IHttpActionResult Delete (string idEmpleado)
        {
            ML.Result result = BL.Empleado.DeleteEF(idEmpleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.Accepted, result);
            }
            else
            { 
                return Content(HttpStatusCode.BadRequest, result);
            }
        }


        [Route("{idEmpresa?}/{nombreEmpleado?}")]
        [HttpGet]
        public IHttpActionResult GetAll(int? idEmpresa, string nombreEmpleado) //puede ser la validacion de abajo o desde aqui hacerlo (int? idEmpresa = 0)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();

            if (nombreEmpleado == null)
            {
                nombreEmpleado = "";
               
            }
            if (idEmpresa == null)
            {
                idEmpresa = 0;
                empleado.Empresa.IdEmpresa = idEmpresa.Value;
            }   
            
            empleado.Nombre = nombreEmpleado;

           ML.Result result = BL.Empleado.GetAllEF(empleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.Accepted, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }

        }

        [Route("{idEmpleado}")]
        [HttpGet]
        public IHttpActionResult GetById(string idEmpleado)
        {

            ML.Result result = BL.Empleado.GetById(idEmpleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.Accepted, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }

        }
    }
}
