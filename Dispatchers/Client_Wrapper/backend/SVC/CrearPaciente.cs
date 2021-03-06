﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;

namespace Health.Isvc.CreatePatient
{

    [Serializable]
    public class CreatePatientReq : Fwk.Bases.Request<Params>
    {

        public CreatePatientReq()
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
    public class CreatePatientRes : Fwk.Bases.Response<Result>
    {


    }
    public class Result : Fwk.Bases.Entity
    {
        public int IdPersona { get; set; }
        public int IdPatient { get; set; }
    }
}