using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";

            ML.Result result = new ML.Result();
            result = BL.Usuario.GetAllEF(usuario);

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            if (usuario.Nombre == null)
            {
                usuario.Nombre = "";
            }
            if (usuario.ApellidoPaterno == null)
            {
                usuario.ApellidoPaterno = "";
            }

            ML.Result result = new ML.Result();
            result = BL.Usuario.GetAllEF(usuario);

            usuario.Usuarios = result.Objects;
            return View(usuario);        
        }

        [HttpGet]
        public ActionResult Form(int? idUsuario) //el nombre del ID debe ser el mismo escrito en el href de mi vista getAll 
        {                                           // Un ? significa que puede estar lleno o no ese campo
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol(); //Instanciamos prop de navegacion           

            usuario.Direccion = new ML.Direccion(); //Instanciamos prop de navegacion hasta llegar a Pais
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            ML.Result resultRol = new ML.Result();
            resultRol = BL.Rol.GetAll();

            ML.Result resultPais = new ML.Result();
            resultPais = BL.Pais.GetAll();

            if (idUsuario != null) //si el IdRecuperado es diferente de null means que haremos un update pues ya existe el id
            {                         // y lo primero es precargar los datos del usuario

                ML.Result result = BL.Usuario.GetByIdEF(idUsuario.Value);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object; //unboxing para los DDL
                    usuario.Rol.Roles = resultRol.Objects;

                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Objects;
                    usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Objects;
                }
            }
            else //me retorna una vista vacia pues es para agregar 
            {
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (ModelState.IsValid) //para validar los DATA ANNOTATION
            {
                HttpPostedFileBase file = Request.Files["IdImagen"]; //conversion a base 64 de la imagen, ESTE DEBE SER EL MISMO ID que se le dio a la imagen
                if (file.ContentLength > 0)
                {
                    usuario.Imagen = ConvertirABase64(file);
                }

                if (usuario.IdUsuario == 0) //SI EL ID ES 0 MEANS QUE SE VA A AGREGAR PUES EL ID EN AGREGAR AUN NO EXITE
                {
                    ML.Result result = BL.Usuario.AddEF(usuario);

                    if (result.Correct) //VALIDAMOS
                    {
                        
                        ViewBag.Message = "SE INGRESO CORRECTAMENTE AL USUARIO";
                    }
                    else
                    {
                        
                        ViewBag.Message = "NO SE INGRESO CORRECTAMENTE AL USUARIO: " + result.ErrorMessage;
                    }
                }
                else //SI EL ID ES DIFERENTE DE 0 MEANS QUE YA EXISTE, POR LO TANTO SE VA A ACTUALIZAR
                {
                    ML.Result result = BL.Usuario.UpdateEF(usuario);

                    if (result.Correct) //VALIDAMOS
                    {
                        ViewBag.Message = "SE ACTUALIZO CORRECTAMENTE AL USUARIO";
                    }
                    else
                    {
                        ViewBag.Message = "NO SE ACTUALIZO CORRECTAMENTE AL USUARIO: " + result.ErrorMessage;
                    }
                }
                return PartialView("Modal");

            }
            else
            {
                ML.Result resultRol = BL.Rol.GetAll(); //instanciamos para traer los roles y paises a los DDL
                ML.Result resultPais = BL.Pais.GetAll();

                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Objects;
                usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Objects;
                usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Objects;

                return View(usuario); //regresa la vista cargada con los datos previos para no ser lenados nuevamente
            }
            
        }

        public ActionResult Delete(int idRecuperado)
        {
            ML.Result result = BL.Usuario.DeleteEF(idRecuperado);

            if (result.Correct)
            {
                ViewBag.Message = "Registro eliminado con exito";
            }
            else
            {
                ViewBag.Message = "Registro no eliminado" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

        public JsonResult EstadoGetByIdPais(int IdPais) //IdPais debe ser igual aqui y en la llave de la peticion en JSON del form en JQUERY
        {
            ML.Result result = BL.Estado.GetByIdPais(IdPais);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.GetByIdEstado(IdEstado); //IdEstado debe ser igual aqui y en la llave de la peticion en JSON del form
            return Json(result.Objects, JsonRequestBehavior.AllowGet); //el ".Objects" puede ser aqui, si no, tiene que ser en el each del jquery
                                                                       //ALLOWGET solo permite la obtencion de datos del JSON mas no otras acciones en ellos
        }
        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public string ConvertirABase64(HttpPostedFileBase Foto) //metodo para convetir la imagen a base 64 y entre a la BD
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }
        public JsonResult ChangeStatus(int IdUsuario, bool Status) //cambiar de STATUS al usuario "BAJA LOGICA"
        {
            ML.Result result = BL.Usuario.ChangeStatus(IdUsuario, Status);
            return Json(null);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string passwordName)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.GetByEmail(email);

            if (result.Correct)
            {
                ML.Usuario usuario = new ML.Usuario();

                //UNBOXING
                usuario = (ML.Usuario)result.Object;
                if (passwordName == usuario.Password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Login = true;
                    ViewBag.Message = "CONTRASEÑA INCORRECTA, INTENTA DE NUEVO";
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Login = true;
                ViewBag.Message = "USUARIO NO EXISTENTE";
                return PartialView("Modal");
            }
        }
    }
}