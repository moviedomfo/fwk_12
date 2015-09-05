using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Fwk.Security.Cryptography
{

    /// <summary>
    /// Interfaz de encriptador simetrico del fwk .-
    /// </summary>
    public interface ISymetriCypher 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string CreateKeyFile();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyFileName"></param>
        /// <returns></returns>
        string CreateKeyFile(string keyFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        string Dencrypt(string val);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        string Encrypt(string val);
        //SymmetricAlgorithmProvider AlgorithmProvider { get; }
    }
}
