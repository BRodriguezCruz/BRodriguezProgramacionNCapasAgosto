using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OperacionesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OperacionesService.svc or OperacionesService.svc.cs at the Solution Explorer and start debugging.
    public class OperacionesService : IOperacionesService
    {
        public int Suma(int valor1, int valor2)
        {
            return valor1 + valor2;
        }

        public int Resta(int valor1, int valor2)
        {
            return valor1 - valor2;
        }

        public double Divicion(double valor1, double valor2)
        {
            return (valor1 / valor2);
        }

        public int Multiplicacion(int valor1, int valor2)
        {
            return valor1 * valor2;
        }
    }
}
