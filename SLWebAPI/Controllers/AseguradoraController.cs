using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLWebAPI.Controllers
{

    [RoutePrefix("api/aseguradora")]
    public class AseguradoraController : ApiController
    {

        [Route("")] //ya que se comunica a traves de URL´s se le debe asignar una
                     //(se hizo una global arriba para acortar en las individusles)
                     //el "add, update, delete etc ..." se eliminan ya que le DECORADOR lo dice implicitamente
        [HttpPost]
        public IHttpActionResult Add(ML.Aseguradora aseguradora) //I = YA QUE tambien se trabaja con interdaces HTTPP = pues retornaran codigos de estado
        {

            ML.Result result = BL.Aseguradora.AddEF(aseguradora);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result); //se retorna el codigo de estado, y todo el modelo para saber o visuzlizar lo que paso
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }


        [Route("{idAseguradora}")]//ya que se comunica a traves de URL´s se le debe asignar una, aqui se asigna por la inf del header
        [HttpPut]
        public IHttpActionResult Update(int idAseguradora, [FromBody] ML.Aseguradora aseguradora) //I = YA QUE tambien se trabaja con interdaces
                                                                                                 //HTTPP = pues retornaran codigos de estado
                                                                                                 //FromBody = para indicar que esa parte viene del BODY 
        {
            aseguradora.IdAseguradora = idAseguradora; //igualamos ya que vienen por separado, uno viene del HEADER, y otro del BODY
            ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);

            if(result.Correct)
            {
                return Content(HttpStatusCode.OK, result); //se retorna el codigo de estado, y todo el modelo para saber o visuzlizar lo que paso
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }


        [Route("{idAseguradora}")] //AQUI SE INDICA QUE EL DATO O INFO. VIENE DEL HEADER
        [HttpDelete]
        public IHttpActionResult Delete (int idAseguradora)
        {
            ML.Result result = BL.Aseguradora.DeleteEF(idAseguradora);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else 
            { 
                return Content(HttpStatusCode.BadRequest, result);
            }
        }


        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();

             if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{idAseguradora}")]
        [HttpGet]
        public IHttpActionResult GetById(int idAseguradora)
        {
            ML.Result result = BL.Aseguradora.GetById(idAseguradora);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
