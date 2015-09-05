using System;

using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.IO;
using Fwk.HelperFunctions;




namespace Fwk.Configuration.Common
{



    /// <summary>
    /// Es una clase de ayuda que abstrae al sistema de configuracion de complejidades tecnicas reutilizables.
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    public class Helper
    {
        [FlagsAttribute]
        public enum FileVersionStatus
        {
            Ok = 1,
            OptionalUpdate = 2,
            RequiredUpdate = 4
        }

        [FlagsAttribute]
        public enum FileStatus
        {
            Ok = 1,
            Expired = 2,
            Inconsistent = 4
        }



    }
}
