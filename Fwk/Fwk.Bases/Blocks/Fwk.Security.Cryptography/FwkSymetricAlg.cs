using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Fwk.Exceptions;

namespace Fwk.Security.Cryptography
{
    /// <summary>
    /// Por el momento solo hay soporte para estos algoritmos
    /// AesManaged
    /// RijndaelManaged
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SymetriCypher<T> : ISymetriCypher where T :SymmetricAlgorithm
    {
         T _SymmetricAlgorithm;

        //key,iv
         string keyName = String.Empty;//"SESshxdRu3p4ik3IOxM6/qAWmmTYUw8N1ZGIh1Pgh2w=$pQgQvA49Cmwn8s7xRUxHmA==";

        /// <summary>
        /// 
        /// </summary>
         public SymetriCypher()
         {
             CreateSymmetricAlgorithm();

         }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
         public SymetriCypher(string k)
        {
            keyName = k;

            //_SymmetricAlgorithm.Key = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["key"]);
            //_SymmetricAlgorithm.IV = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["IV"]);
            CreateSymmetricAlgorithm();

            _SymmetricAlgorithm.Key = Convert.FromBase64String(k.Split('$')[0]);
            _SymmetricAlgorithm.IV = Convert.FromBase64String(k.Split('$')[1]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GeneratetNewK()
        {

            //Create a new key and initialization vector.
            _SymmetricAlgorithm.GenerateKey();
            _SymmetricAlgorithm.GenerateIV();
            keyName = string.Concat(Convert.ToBase64String(_SymmetricAlgorithm.Key), "$", Convert.ToBase64String(_SymmetricAlgorithm.IV));
            return keyName;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string Encrypt(string plainText, string k)
        {
            return Encrypt(plainText, Convert.FromBase64String(k.Split('$')[0]), Convert.FromBase64String(k.Split('$')[1]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string Encrypt(string plainText)
        {
            return Encrypt(plainText, _SymmetricAlgorithm.Key, _SymmetricAlgorithm.IV);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="rgbKey"></param>
        /// <param name="rgbIV"></param>
        /// <returns></returns>
        public string Encrypt(string plainText, byte[] rgbKey, byte[] rgbIV)
        {
            //Get an encryptor.
            ICryptoTransform encryptor = _SymmetricAlgorithm.CreateEncryptor(rgbKey, rgbIV);


            //Encrypt the data.
            MemoryStream msEncrypt = new MemoryStream();


            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {

                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
                }
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string Dencrypt(string cipherText)
        {
            return Dencrypt(cipherText, _SymmetricAlgorithm.Key, _SymmetricAlgorithm.IV);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string Dencrypt(string cipherText, string k)
        {
            return Dencrypt(cipherText, Convert.FromBase64String(k.Split('$')[0]), Convert.FromBase64String(k.Split('$')[1]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="rgbKey"></param>
        /// <param name="rgbIV"></param>
        /// <returns></returns>
        public string Dencrypt(string cipherText, byte[] rgbKey, byte[] rgbIV)
        {
            byte[] cipherTextBin = Convert.FromBase64String(cipherText);

            ICryptoTransform decryptor = _SymmetricAlgorithm.CreateDecryptor(rgbKey, rgbIV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherTextBin))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }


        }



        #region ISymetriCypher Members
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CreateKeyFile()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Geenra un archivo binario con la clave de encriptacion 
        /// </summary>
        /// <param name="keyFileName"></param>
        /// <returns></returns>
        public string CreateKeyFile(string keyFileName)
        {

            
            if (!string.IsNullOrEmpty(keyFileName))
            {
                Fwk.HelperFunctions.FileFunctions.SaveBinaryFile(keyFileName, Convert.FromBase64String(GeneratetNewK()));
              
            }
            return keyFileName;
        }

        #endregion



        void CreateSymmetricAlgorithm()
        {
            if (_SymmetricAlgorithm != null) return;
            TechnicalException te;
            try
            {
                if (_SymmetricAlgorithm == null)
                {
                    if (typeof(T).AssemblyQualifiedName.Contains("TripleDES"))
                    {
                        te = new TechnicalException("Consider using the algorithm, Advanced Encryption Standard (AES) class and its derived classes instead of the TripleDES. Use TripleDES only for compatibility with legacy applications and data.  ");
                        te.ErrorId = "4400";
                        throw te;

                    }
                    ///No se puede crear una clase AesManaged por reflection.. Pide la System.Core  a pesar de que esta .. Seguramente hay que usar reflect por dll
                    //Utilizando esta forma de instanciar dio buen resultado 
                    if (typeof(T).AssemblyQualifiedName.Contains("AesManaged"))
                    {
                        AesManaged aes = new AesManaged();
                        _SymmetricAlgorithm = (T)((System.Security.Cryptography.SymmetricAlgorithm)aes);
                    }
                    else
                    {
                        _SymmetricAlgorithm = (T)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(typeof(T).AssemblyQualifiedName);
                    }
                }
            }
            catch (TechnicalException tech)
            { throw tech; }
            catch (Exception e)
            {
                //
                te = new TechnicalException(String.Format("Error al intentar crear {0} ", typeof(T).FullName), e);
                ExceptionHelper.SetTechnicalException<SymetriCypher<T>>(te);
                te.ErrorId = "4400";
                throw te;
            }

        }

    }

     class FwkSymetricAlg : ISymetriCypher
    {
         static RijndaelManaged _SymmetricAlgorithm;

        //key,iv
         string _k = "SESshxdRu3p4ik3IOxM6/qAWmmTYUw8N1ZGIh1Pgh2w=$pQgQvA49Cmwn8s7xRUxHmA==";
      
        static FwkSymetricAlg()
        {_SymmetricAlgorithm = new RijndaelManaged();}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        public FwkSymetricAlg(string k)
        {
            

            //_SymmetricAlgorithm.Key = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["key"]);
            //_SymmetricAlgorithm.IV = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["IV"]);

            _SymmetricAlgorithm.Key = Convert.FromBase64String(k.Split('$')[0]);
            _SymmetricAlgorithm.IV = Convert.FromBase64String(k.Split('$')[1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetNewK()
        {
            
            //Create a new key and initialization vector.
            _SymmetricAlgorithm.GenerateKey();
            _SymmetricAlgorithm.GenerateIV();

            return string.Concat(Convert.ToBase64String(_SymmetricAlgorithm.Key), "$", Convert.ToBase64String(_SymmetricAlgorithm.IV));

        }



        public  string Encrypt(string plainText, string k)
        {
            return Encrypt(plainText, Convert.FromBase64String(k.Split('$')[0]), Convert.FromBase64String(k.Split('$')[1]));
        }

        public  string Encrypt(string plainText)
        {
            return Encrypt(plainText, _SymmetricAlgorithm.Key, _SymmetricAlgorithm.IV);
        }

        public string Encrypt(string plainText, byte[] rgbKey, byte[] rgbIV)
        {
            //Get an encryptor.
            ICryptoTransform encryptor = _SymmetricAlgorithm.CreateEncryptor(rgbKey, rgbIV);


            //Encrypt the data.
            MemoryStream msEncrypt = new MemoryStream();


            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {

                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
                }
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }


        public  string Dencrypt(string cipherText)
        {
            return Dencrypt(cipherText, _SymmetricAlgorithm.Key, _SymmetricAlgorithm.IV);
        }
        public  string Dencrypt(string cipherText, string k)
        {
            return Dencrypt(cipherText, Convert.FromBase64String(k.Split('$')[0]), Convert.FromBase64String(k.Split('$')[1]));
        }

        public  string Dencrypt(string cipherText, byte[] rgbKey, byte[] rgbIV)
        {
            byte[] cipherTextBin = Convert.FromBase64String(cipherText);

            ICryptoTransform decryptor = _SymmetricAlgorithm.CreateDecryptor(rgbKey, rgbIV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherTextBin))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }


        }



        #region ISymetriCypher Members

        public string CreateKeyFile()
        {
            throw new NotImplementedException();
        }

        public string CreateKeyFile(string keyFileName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
