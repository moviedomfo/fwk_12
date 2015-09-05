//using System;
//using System.Security.Cryptography;
//using System.Text;
//using System.IO;
//using Fwk.Configuration;

//namespace Fwk.HelperFunctions
//{
   

   


//        /// <summary>
//        /// Framework Library Integration Facades
//        /// Usa --> Proveee una fachada estatica que no es instanciada por polyce injection .-
//        /// 
//        /// Esta clase nececita un proveedor de encriptacion simetrica configurado .-
//        /// 
//        /// <see cref="CryptographyManager"/>
//        /// </summary>
//        public class CryptographyFunctions
//        {


//            /// <summary>
//            /// Nombre del proveedor espesificado por mediode el archivo de configuracion
//            /// Ver:  securityCryptographyConfiguration -->hashProviders
//            /// </summary>
//            private const string HASH_PROVIDER = "FwkHashProvider";
//            /// <summary>
//            /// Nombre del proveedor espesificado por medio del arhivo de configuracion
//            /// Ver:  securityCryptographyConfiguration -->hashProviders
//            /// </summary>
//            private const string SYMM_PROVIDER = "FwkSympPovider";

//            private static void CreateKeys(string installPath, string symmKeyFileName)
//            {

//                string fileName = Path.Combine(installPath, symmKeyFileName);

//                ProtectedKey symmetricKey = KeyManager.GenerateSymmetricKey(typeof(RijndaelManaged), System.Security.Cryptography.DataProtectionScope.LocalMachine);
//                using (FileStream keyStream = new FileStream(fileName, FileMode.Create))
//                {
//                    KeyManager.Write(keyStream, symmetricKey);
//                }
//            }

//            public static string Encrypt(String inputText)
//            {
//                // CADELA ENCRIPTADA Base64 
//                return Cryptographer.EncryptSymmetric(SYMM_PROVIDER, inputText);
               
//            }

//            /// <summary>
//            /// Desencripta simetricamente con el provider "FwkSympPovider"
//            /// </summary>
//            /// <param name="cryptedText">Texto encriptado en base64</param>
//            /// <returns></returns>
//            public static String Decrypt(String cryptedText)
//            {

//                return Cryptographer.DecryptSymmetric(SYMM_PROVIDER, cryptedText);
//            }



//            // TODO: Comentar esta clase

//            /// <summary>
//            /// 
//            /// </summary>
//            public static class TripleDES
//            {
//                /// <summary>
//                /// 
//                /// </summary>
//                /// <param name="strKey"></param>
//                /// <param name="strData"></param>
//                /// <returns></returns>
//                public static string EncryptData(string strKey, string strData)
//                {
//                    string strResult;
//                    TripleDESCryptoServiceProvider tdescsp = new TripleDESCryptoServiceProvider();

//                    try
//                    {
//                        tdescsp.Mode = CipherMode.CFB;
//                        tdescsp.Key = ASCIIEncoding.ASCII.GetBytes(strKey);
//                        tdescsp.IV = ASCIIEncoding.ASCII.GetBytes(strKey.Substring(0, 8));

//                        ICryptoTransform desEncrypt = tdescsp.CreateEncryptor();

//                        MemoryStream mOut = new MemoryStream();
//                        CryptoStream encryptStream = new CryptoStream(mOut, desEncrypt, CryptoStreamMode.Write);

//                        byte[] rbData = UnicodeEncoding.Unicode.GetBytes(strData);
//                        try
//                        {
//                            encryptStream.Write(rbData, 0, rbData.Length);
//                        }
//                        catch
//                        {
//                        }

//                        encryptStream.FlushFinalBlock();

//                        if (mOut.Length == 0)
//                        {
//                            strResult = String.Empty;
//                        }
//                        else
//                        {
//                            byte[] buff = mOut.ToArray();
//                            strResult = Convert.ToBase64String(buff, 0, buff.Length);
//                        }

//                        try
//                        {
//                            encryptStream.Close();
//                        }
//                        catch
//                        {
//                        }

//                        return strResult;
//                    }
//                    catch (Exception ex)
//                    {
//                        throw new Exception("Cryptographic Error - TripleDES - Encrypt - " + ex.Message, ex);
//                    }
//                }

//                /// <summary>
//                /// Function to decrypt data
//                /// </summary>
//                /// <param name="strKey"></param>
//                /// <param name="strData"></param>
//                /// <returns></returns>
//                public static string DecryptData(string strKey, string strData)
//                {
//                    string strResult;
//                    TripleDESCryptoServiceProvider tdescsp = new TripleDESCryptoServiceProvider();

//                    try
//                    {
//                        tdescsp.Mode = CipherMode.CFB;
//                        tdescsp.Key = ASCIIEncoding.ASCII.GetBytes(strKey);
//                        tdescsp.IV = ASCIIEncoding.ASCII.GetBytes(strKey.Substring(0, 8));

//                        ICryptoTransform desDecrypt = tdescsp.CreateDecryptor();

//                        MemoryStream mOut = new MemoryStream();
//                        CryptoStream decryptStream = new CryptoStream(mOut, desDecrypt, CryptoStreamMode.Write);

//                        char[] carray = strData.ToCharArray();
//                        byte[] rbData = Convert.FromBase64CharArray(carray, 0, carray.Length);
//                        try
//                        {
//                            decryptStream.Write(rbData, 0, rbData.Length);
//                        }
//                        catch
//                        {
//                        }

//                        decryptStream.FlushFinalBlock();

//                        UnicodeEncoding aEnc = new UnicodeEncoding();
//                        strResult = aEnc.GetString(mOut.ToArray());

//                        try
//                        {
//                            decryptStream.Close();
//                        }
//                        catch
//                        {
//                        }

//                        return strResult;
//                    }
//                    catch (Exception ex)
//                    {
//                        throw new Exception("Cryptographic Error - TripleDES - Decrypt - " + ex.Message, ex);
//                    }
//                }
//            }
//        }
    
//}
