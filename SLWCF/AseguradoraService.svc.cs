using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AseguradoraService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AseguradoraService.svc or AseguradoraService.svc.cs at the Solution Explorer and start debugging.
    public class AseguradoraService : IAseguradoraService
    {

       public SLWCF.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.AddEF(aseguradora); //INSTANCIAMOS PARA ACCEDER A LAS PROP
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

        public SLWCF.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);
            SLWCF.Result resultSLWCF = new SLWCF.Result();

            resultSLWCF.ErrorMessage = result.ErrorMessage;
            resultSLWCF.Correct = result.Correct;
            resultSLWCF.Object = result.Object;
            resultSLWCF.Objects = result.Objects;
            result.Ex = result.Ex;

            return resultSLWCF;

        }
       
        public SLWCF.Result Delete(int idAseguradora)
        {
            ML.Result result = BL.Aseguradora.DeleteEF(idAseguradora);

            return new SLWCF.Result
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public SLWCF.Result GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();

            return new SLWCF.Result
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public SLWCF.Result GetById(int idAseguradora) 
        {
            ML.Result result = BL.Aseguradora.GetById(idAseguradora);
            SLWCF.Result resultWCF = new SLWCF.Result();

            resultWCF.ErrorMessage = result.ErrorMessage;
            resultWCF.Correct = result.Correct;
            resultWCF.Object = result.Object;   
            resultWCF.Objects = result.Objects; 
            resultWCF.Ex = result.Ex;

            return resultWCF;
        }
    }
}
