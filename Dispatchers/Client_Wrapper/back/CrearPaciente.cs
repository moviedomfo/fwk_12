using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;

namespace Health.Isvc.CrearPatient
{

    [Serializable]
    public class CrearPatientReq : Fwk.Bases.Request<Params>
    {

        public CrearPatientReq()
        {
            base.ServiceName = "CrearPatientService";
        }
    }

    public class Params : Fwk.Bases.Entity
    {
      
        public PatientBE Patient { get; set; }

        public MutualPorPacienteList Mutuales { get; set; }
    }

    [Serializable]
    public class CrearPatientRes : Fwk.Bases.Response<Result>
    {


    }
    public class Result : Fwk.Bases.Entity
    {
        public int IdPersona { get; set; }
        public int IdPatient { get; set; }
    }
}