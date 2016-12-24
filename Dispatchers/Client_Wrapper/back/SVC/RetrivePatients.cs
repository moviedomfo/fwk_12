using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.RetrivePatients
{
    [Serializable]
    public class RetrivePatientsReq : Fwk.Bases.Request<Params>
    {
        public RetrivePatientsReq()
        {
            base.ServiceName = "RetrivePatientsService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? NroDocumento { get; set; }
        public int? Id { get; set; }
    }


    [Serializable]
    public class RetrivePatientsRes : Fwk.Bases.Response<PatientViewList>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Fwk.Bases.Entity
    {
        public PatientList ProfesionalList { get; set; }
    }
}
