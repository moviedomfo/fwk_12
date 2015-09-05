using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.CrearPatient;
using Health.Back;

namespace Health.Svc
{
    /// <summary>
    /// Crea Patient y perosna
    ///         o
    /// Crea Patient y asocia 
    /// </summary>
    public class CrearPatientService : BusinessService<CrearPatientReq, CrearPatientRes>
    {
        public override CrearPatientRes Execute(CrearPatientReq pServiceRequest)
        {
            CrearPatientRes wRes = new CrearPatientRes();
            //bool personaExiste = PersonasDAC.Exist(pServiceRequest.BusinessData.Patient.Persona.NroDocumento);

            //pServiceRequest.BusinessData.Patient.LastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);
            //pServiceRequest.BusinessData.Patient.Persona.LastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);


            //if (personaExiste)
            //{
            //    if (PatientsDAC.Persona_EstaAsociada(pServiceRequest.BusinessData.Patient.Persona.NroDocumento))
            //        throw new Fwk.Exceptions.FunctionalException(String.Format("El Nro documento {0} ya pertenece a otro paciente registrado", 
            //            pServiceRequest.BusinessData.Patient.Persona.NroDocumento));

            //    PatientsDAC.Asociar(pServiceRequest.BusinessData.Patient);
            //}
            //else
            //{
            //    PatientsDAC.Create(pServiceRequest.BusinessData.Patient);
            //}

            //wRes.BusinessData.IdPersona = pServiceRequest.BusinessData.Patient.IdPersona;
            //wRes.BusinessData.IdPatient = pServiceRequest.BusinessData.Patient.PatientId;

            //if(pServiceRequest.BusinessData.Mutuales!=null)
            //    ObraSocialDAC.Create_MutualPorPaciente(pServiceRequest.BusinessData.Mutuales,pServiceRequest.BusinessData.Patient.PatientId);
            return wRes;
        }


    }
}


