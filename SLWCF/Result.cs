using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SLWCF
{

    [DataContract] //indica que los datos tienen la capacidad de serializarse y deserializarse (DATA CONTRACT) para toda la clase
    public class Result
    {
        [DataMember] //Indica que este miembro de datos puedes serializar y deserializar
        public string ErrorMessage { get; set; }

        [DataMember]
        public bool Correct { get; set; }

        [DataMember]
        public object Object { get; set; }

        [DataMember]
        public List<object> Objects { get; set; }

        [DataMember]
        public Exception Ex { get; set; }


    }
}