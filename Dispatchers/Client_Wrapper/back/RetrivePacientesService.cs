using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetrivePatients;
using Health.Back;

using Health.BE;


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
            //if (String.IsNullOrEmpty(pServiceRequest.BusinessData.Nombre) && String.IsNullOrEmpty(pServiceRequest.BusinessData.Apellido) && pServiceRequest.BusinessData.Id.HasValue)
            //{
            //    PatientBE p = PatientsDAC.GetById(pServiceRequest.BusinessData.Id.Value);
            //    wRes.BusinessData.Add(p);
            //}
            //else
            //{
            //    wRes.BusinessData.AddRange(PatientsDAC.SearchByParams(pServiceRequest.BusinessData.Nombre, pServiceRequest.BusinessData.Apellido));
            //}
            return wRes;
        }
    }
}
