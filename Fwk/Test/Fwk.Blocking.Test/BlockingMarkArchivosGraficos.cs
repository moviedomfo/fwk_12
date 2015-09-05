using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Blocking;

namespace Fwk.Blocking.Test
{
    public class BlockingMarkArchivosGraficos : BlockingMarkBase
    {
        private Int32? _CodigoPagina;
        private Int32? _IdArchivo;
        private Int32? _CodigoNota;
        private String  _ListaCodigoNotas;
        

        #region Properties

        public Int32? IdArchivo
        {
            get { return _IdArchivo; }
            set { _IdArchivo = value; }
        }
        public Int32? CodigoNota
        {
            get { return _CodigoNota; }
            set { _CodigoNota = value; }
        }
        public Int32? CodigoPagina
        {
            get { return _CodigoPagina; }
            set { _CodigoPagina = value; }
        }

        public String ListaCodigoNotas
        {
            get { return _ListaCodigoNotas; }
            set { _ListaCodigoNotas = value; }
        }
           


        #endregion

     

       


    }




  
}
