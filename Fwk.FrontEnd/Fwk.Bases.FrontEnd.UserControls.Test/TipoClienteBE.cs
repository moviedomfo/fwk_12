using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace Fwk.Bases.FrontEnd.Controls.Test
{
    [XmlInclude(typeof(TipoClienteBE)), Serializable]
    public class TipoClienteBE : Entity
    {
        int m_IdTipoCliente;

        public int IdTipoCliente
        {
            get { return m_IdTipoCliente; }
            set { m_IdTipoCliente = value; }
        }
        string m_Descripcion;

        public string Descripcion
        {
            get { return m_Descripcion; }
            set { m_Descripcion = value; }
        }

        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto TipoClienteBE apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>TipoClienteBE</returns>
        public static TipoClienteBE GetTipoClienteBEFromXml(String pXml)
        {
            return Entity.GetFromXml<TipoClienteBE>( pXml);
        }

        public override string ToString()
        {
            return m_Descripcion;
        }
        #endregion
    }

    [XmlRoot("TipoClienteBEList"), SerializableAttribute]
    public class TipoClienteBEList : Entities<TipoClienteBE>
    {
        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto TipoClienteBEList apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>ClienteBECollection</returns>
        public static TipoClienteBEList GetTipoClienteBEListFromXml(String pXml)
        {
            return TipoClienteBEList.GetFromXml<TipoClienteBEList>(pXml);
        }
        #endregion
    }

}
