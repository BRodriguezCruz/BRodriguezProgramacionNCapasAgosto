using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOperacionesService" in both code and config file together.
    [ServiceContract]
    public interface IOperacionesService
    {

        [OperationContract] // indica que es un metodo de WCF
        int Suma(int valor1, int valor2); //en la interfaz solo se declaran las firmas de los metodos

        [OperationContract]
        int Resta(int valor1, int valor2); 

        [OperationContract]
        double Divicion(double valor1, double valor2); 

        [OperationContract]
        int Multiplicacion(int valor1, int valor2);
    }
}
