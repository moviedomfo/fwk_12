using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetrivePatients;
using Health.Back;

using Health.BE;
using Fwk.Exceptions;

namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class RetrivePatientsService : BusinessService<RetrivePatientsReq, RetrivePatientsRes>
    {
        public override RetrivePatientsRes Execute(RetrivePatientsReq pServiceRequest)
        {
            RetrivePatientsRes wRes = new RetrivePatientsRes();
           
            PatientViewBE p = new PatientViewBE();
            p.FechaAlta = DateTime.Now;
            p.IdPersona = 3;
            p.PatientId = 1234;
            p.Nombre = "Facundo";
            p.Apellido = "Cabral";
            wRes.BusinessData.Add(p);
            p = new PatientViewBE();
            p.FechaAlta = DateTime.Now;
            p.IdPersona = 12312;
            p.PatientId = 12;
            p.Nombre = "Christopher";
            p.Apellido = "EchePler";
            wRes.BusinessData.Add(p);

            wRes.BusinessData.Add(p);
            p = new PatientViewBE();
            p.FechaAlta = DateTime.Now;
            p.IdPersona = 122;
            p.PatientId = 1222;
            p.Nombre = "Chris Blan";
            p.Apellido = "As perl";
            wRes.BusinessData.Add(p);
//            throw new TechnicalException("error en el svc");
            System.Threading.Thread.Sleep(2500);
            return wRes;
        }
    }
}
