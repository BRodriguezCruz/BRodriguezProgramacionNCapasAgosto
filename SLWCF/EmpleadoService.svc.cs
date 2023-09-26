using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmpleadoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmpleadoService.svc or EmpleadoService.svc.cs at the Solution Explorer and start debugging.
    public class EmpleadoService : IEmpleadoService
    {
        public SLWCF.Result Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.AddEF(empleado); //INSTANCIAMOS PARA ACCEDER A LAS PROP
                                                         //igualamos para ejecutar metodo y regrese un result ya sea exitoso, o no, con objetos o no, etc .. 

            return new SLWCF.Result //parseamos las propiedades ML.result a SLWCF.Result con las mismas prop pero con la capacidad de SERIALIZAR O DESERIALIZAR
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public SLWCF.Result Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.UpdateEF(empleado);
            SLWCF.Result resultSLWCF = new SLWCF.Result();
            
            resultSLWCF.ErrorMessage = result.ErrorMessage;
            resultSLWCF.Correct = result.Correct;
            resultSLWCF.Object = result.Object;
            resultSLWCF.Objects = result.Objects;
            result.Ex = result.Ex;

            return resultSLWCF;

        }

        public SLWCF.Result Delete(string idEmpleado)
        {
            ML.Result result =  BL.Empleado.DeleteEF(idEmpleado);

            return new SLWCF.Result
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public SLWCF.Result GetAll(ML.Empleado empleado) //recibe todo el objeto pero solo ocupa dos parametros para la busqueda abierta
        {
            ML.Result result = BL.Empleado.GetAllEF(empleado);

            return new SLWCF.Result
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public SLWCF.Result GetById(string idEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(idEmpleado);

            return new SLWCF.Result
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
    }
}
