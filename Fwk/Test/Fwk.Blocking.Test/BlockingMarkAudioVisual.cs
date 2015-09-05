using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Blocking;

namespace Fwk.Blocking.Test
{
    public class BlockingMarkAudioVisual : BlockingMarkBase
    {
        
        #region CONSTRUCTOR

        public BlockingMarkAudioVisual(int pCodigoMedio, DateTime pFechaHoraInicioTransmision, DateTime pFechaHoraFinTransmision)
            
        {
            mi_CodigoMedio = pCodigoMedio;
            md_FechaHoraFinTransmision = pFechaHoraInicioTransmision;
            md_FechaHoraFinTransmision = pFechaHoraFinTransmision;
           
        }

        

        #endregion

        #region PRIVATE VARS


        private Int32? mi_CodigoBloque;
        private Int32? mi_CodigoMedio;
        private DateTime? md_FechaHoraInicioTransmision;
        private DateTime? md_FechaHoraFinTransmision;
        private Boolean? mb_EsOnline;
        private Boolean? mb_Objeto;
        private String msz_ProcessAux;

       

        #endregion

        #region PROPERTIES
        public bool? Objeto
        {
            get { return mb_Objeto; }
            set { mb_Objeto = value; }
        }
        public int? CodigoBloque
        {
            get { return mi_CodigoBloque; }
            set { mi_CodigoBloque = value; }
        }
        public int? CodigoMedio
        {
            get { return mi_CodigoMedio; }
            set { mi_CodigoMedio = value; }
        }

       

        public DateTime? FechaHoraInicioTransmision
        {
            get { return md_FechaHoraInicioTransmision; }
            set { md_FechaHoraInicioTransmision = value; }
        }


        public DateTime? FechaHoraFinTransmision
        {
            get { return md_FechaHoraFinTransmision; }
            set { md_FechaHoraFinTransmision = value; }
        }

        public bool? EsOnline
        {
            get { return mb_EsOnline; }
            set { mb_EsOnline = value; }
        }

        public String ProcessAux
        {
            get { return msz_ProcessAux; }
            set {msz_ProcessAux = value;}
        }

        #endregion

    }
}
