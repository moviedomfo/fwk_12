using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Fwk.DataBase
{
    /// <summary>
    /// Mnejador de exepciones de Fwk.DataBase
    /// </summary>
    [Serializable()]
    public class DataBaseExeption : ApplicationException
    {
        /// <summary>
        /// 
        /// </summary>
        public enum ExeptionsEnums
        {
            /// <summary>
            /// 
            /// </summary>
            CryptographicException = 1,
            /// <summary>
            /// 
            /// </summary>
            FileNotFoundException = 2,
            /// <summary>
            /// 
            /// </summary>
            CryptographicFile = 3
        };

        #region [Miembros]
        private CnnString _CnnString = null;
        
        /// <summary>
        /// 
        /// </summary>
        protected string _Msg = String.Empty;
        #endregion

        #region [Propiedades]
        /// <summary>
        /// Reprecenta si la coneccion usa autentificacion de windows o no.-
        /// </summary>
        public CnnString CnnString
        {
            get
            {
                return _CnnString;
            }
        }

       

        /// <summary>
        /// Mensaje de error.
        /// </summary>
        public override string Message
        {
            get { return _Msg; }
        }

        /// <summary>
        /// Retorna la exepcion base.-
        /// </summary>
        /// <returns></returns>
        public override Exception GetBaseException()
        {
            return base.GetBaseException();

        }
        #endregion


         /// <summary>
         /// 
         /// </summary>
         /// <param name="pException"></param>
         /// <param name="pCnnString"></param>
        public DataBaseExeption(Exception pException, CnnString pCnnString)
        {
            _CnnString  = pCnnString;
            

            if (pException.GetType() == typeof(System.Security.Cryptography.CryptographicException))
            {

                _Msg = "La password encriptada en el archivo de configuracion fue violada. "
                    + Environment.NewLine + "Reescriba su clave y guarde su configuracion";
            }
            if (pException.GetType() == typeof(SqlException))
            {
                System.Data.SqlClient.SqlException ex = (System.Data.SqlClient.SqlException)pException;
                //ex.Number == 18456 Login fail
                _Msg = pException.Message + Environment.NewLine + "Vuelva a ingresar la informacion de conección";
            }
            if (pException.GetType() ==  typeof(System.IO.FileNotFoundException))
            {
                
                _Msg = pException.Message;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pException"></param>
        /// <param name="pExeptionsEnums"></param>
        public DataBaseExeption(Exception pException, ExeptionsEnums pExeptionsEnums)
        {
            if (pExeptionsEnums == ExeptionsEnums.CryptographicFile)
            {
                if (pException.GetType() ==  typeof(System.IO.FileNotFoundException))
                {

                    _Msg = "No es posible encontrar el archivo CnnCrypt.key " + Environment.NewLine + pException.Message;
                }

                if (pException.GetType() == typeof(System.Security.Cryptography.CryptographicException))
                {

                    _Msg = "La password encriptada en el archivo de configuracion fue violada. "
                        + Environment.NewLine + "Reescriba su clave y guarde su configuracion";
                }
            }
        }
    }
}
