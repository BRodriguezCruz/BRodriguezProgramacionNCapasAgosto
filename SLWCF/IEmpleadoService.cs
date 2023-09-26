using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmpleadoService" in both code and config file together.
    [ServiceContract]
    public interface IEmpleadoService
    {

        [OperationContract]
        SLWCF.Result Add(ML.Empleado empleado); //en la interfaz solo la firma del metodo, "tipo de retorno" -> "nombre metodo" -> "firma con o sin parametros"

        // ML.Result Add(ML.Empleado empleado); ==> "ML.Result" ya que mis metodos me devuelven un ML.Result pero se cambio por un rsult capaz de serializar o deserializar

        [OperationContract]
        SLWCF.Result Update(ML.Empleado empleado);

        [OperationContract]
        SLWCF.Result Delete(string idEmpleado);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Empleado))]
        SLWCF.Result GetAll(ML.Empleado empleado);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Empleado))]
        SLWCF.Result GetById(string idEmpleado);

    }
}
