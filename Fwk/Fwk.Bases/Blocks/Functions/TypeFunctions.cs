using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Fwk.Bases;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Funciones de Tipos.
	/// </summary>
	/// <Date>13-05-2009</Date>
	/// <Author>Marcelo F. Oviedo</Author>
    public class TypeFunctions
    {
        /// <summary> 
        /// Valida si el valor pasado por parametro es un entero.-
        /// </summary>
        /// <param name="pValue">Texto a evaluar.-</param>
        /// <returns></returns>
        public static bool IsInteger(string pValue)
        {
            try
            {
                Convert.ToInt32(pValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida si el valor pasado por parametro es un numero.-
        /// </summary>
        /// <param name="pValue">Texto a evaluar.-</param>
        /// <returns></returns>
        public static bool IsNumeric(string pValue)
        {
            return Information.IsNumeric(pValue);
        }

        /// <summary>
        /// Se valida si la entrada de datos contiene solo Letras
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public static bool IsAlpha(string pInput)
        {
            string wLetters = "abcdefghijklmñnopqrstuvwxyzüáéíóú";
            pInput = pInput.Trim();

            string wCaracter = String.Empty;

            for (int i = 0; i < pInput.Length; i++)
            {
                wCaracter = pInput.Substring(i, 1);
                wCaracter = wCaracter.ToLower();

                if (wLetters.IndexOf(wCaracter) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Se valida si la entrada de datos contiene solo Letras y números
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(string pInput)
        {
            string wLetters = "abcdefghijklmñnopqrstuvwxyzüáéíóú1234567890";
            pInput = pInput.Trim();

            string wCaracter = String.Empty;

            for (int i = 0; i < pInput.Length; i++)
            {
                wCaracter = pInput.Substring(i, 1);
                wCaracter = wCaracter.ToLower();

                if (wLetters.IndexOf(wCaracter) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Verifica si existen caracteres no validos.
        /// en una cadena de texto.
        /// </summary>
        /// <param name="pValue">Texto a evaluar.</param>
        /// <returns>True: si existen caracteres invalidos.</returns>
        /// <Date>12-07-2009</Date>
        /// <Author>Marcelo Oviedo</Author>
        public static bool WrongCharacters(string pValue)
        {
            string wCaracteres = "%";
            string wCharacter;
            int wComparation;

            for (int i = 0; i < pValue.Length; i++)
            {
                wCharacter = pValue.Substring(i, 1);
                wComparation = wCaracteres.IndexOf(wCharacter);

                if (wComparation > -1) return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Size PixelToMillimeter(Control control, Size size)
        {
            float dpiX;
            float dpiY;

            Graphics g = control.CreateGraphics();
            dpiX = g.DpiX;
            dpiY = g.DpiY;
            g.Dispose();

            return PixelToMillimeter(dpiX, dpiY, size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpiX"></param>
        /// <param name="size"></param>
        /// <param name="dpiY"></param>
        /// <returns></returns>
        public static Size PixelToMillimeter(float dpiX, float dpiY, Size size)
        {
            return new Size((int)(dpiX * size.Width / 25.4f), (int)(dpiY * size.Height / 25.4f));
        }


        #region --[Validacion de Rut]--
        /// <summary>
        /// Valida si un Rut es valido.
        /// </summary>
        /// <param name="pRut">Rut a validar.</param>
        /// <returns>Resultado de la validacion.</returns>
        /// <Date>05-07-2009</Date>
        /// <Author>Marcelo F. Oviedo</Author>
        public static bool RutDVValidate(string pRut)
        {
            string wRutDV = pRut.Trim();

            if (wRutDV.IndexOf("-") != (wRutDV.Length - 2))
            {
                return false;
            }

            wRutDV = CleanStr(wRutDV);
            int wLargoRut = wRutDV.Length;
            string wRut = wRutDV.Substring(0, wLargoRut - 1);
            string wDV = wRutDV.Substring(wLargoRut - 1).ToUpper();

            if (RUTValidate(wRut, wDV))
            {
                pRut = RUTFormat(wRutDV);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Limpia el texto que recibe de caracteres adicionales
        /// ('.','-',' ').
        /// </summary>
        /// <param name="pStrSrc">Texto a limpiar.</param>
        /// <returns>El texto limpio.</returns>
        /// <Date>05-07-2009</Date>
        /// <Author>Marcelo F. Oviedo</Author>
        private static string CleanStr(string pStrSrc)
        {
            pStrSrc = pStrSrc.Replace(".", "");
            pStrSrc = pStrSrc.Replace("-", "");
            pStrSrc = pStrSrc.Replace(" ", "");
            return pStrSrc;
        }
        /// <summary>
        /// Valida si el Rut es valido.
        /// </summary>
        /// <param name="pRut">Rut a validar.</param>
        /// <param name="pDV">Digito Verificador.</param>
        /// <returns>Resultado de la validacion.</returns>
        /// <Date>05-07-2009</Date>
        /// <Author>Marcelo F. Oviedo</Author>
        private static bool RUTValidate(string pRut, string pDV)
        {

            if (pRut == "" || !IsNumeric(pRut) || pRut.Length > 9 || Convert.ToInt32(pRut) * 1 == 0)
            {
                //Rut Invalido
                return false;
            }
            else if ((!IsNumeric(pDV) && (pDV != "K")) || (pDV == ""))
            {
                //Dígito Verificador invalido
                return false;
            }
            else if (!M11Validate(pRut, pDV))
            {
                //Digito Verificador Erroneo
                return (false);
            }
            return (true);
        }
        /// <summary>
        /// Validacion del Modulo 11.
        /// </summary>
        /// <param name="pRut">Rut.</param>
        /// <param name="pDV">Digito Verificador.</param>
        /// <returns>Resultado de la validacion.</returns>
        /// <Date>05-07-2009</Date>
        /// <Author>Marcelo F. Oviedo</Author>
        private static bool M11Validate(string pRut, string pDV)
        {
            int suma = 0;
            int mul = 2;

            for (int i = pRut.Length - 1; i >= 0; i--)
            {
                suma = suma + Convert.ToInt32(pRut.Substring(i, 1)) * mul;
                mul = mul == 7 ? 2 : mul + 1;
            }
            string dvr = "" + Convert.ToString(11 - suma % 11);
            if (dvr == "10")
                dvr = "K";
            else if (dvr == "11")
                dvr = "0";
            if (dvr != pDV)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Formatea el string que se le entrega con formato de RUT. 
        /// </summary>
        /// <param name="pStr">El texto a formatear.</param>
        /// <returns>El texto formateado.</returns>
        /// <Date>05-07-2009</Date>
        /// <Author>Marcelo F. Oviedo</Author>
        private static string RUTFormat(string pStr)
        {
            int wLargo = pStr.Length;
            string auxInv = String.Empty;
            for (int i = (wLargo - 1), j = 0; i >= 0; i--, j++)
                auxInv = auxInv + pStr.Substring(i, 1);
            string auxStr = String.Empty;
            auxStr = auxStr + auxInv.Substring(0, 1);
            auxStr = auxStr + '-';
            int cnt = 0;
            for (int i = 1, j = 2; i < wLargo; i++, j++)
            {
                if (cnt == 3)
                {
                    auxStr = auxStr + '.';
                    j++;
                    auxStr = auxStr + auxInv.Substring(i, 1);
                    cnt = 1;
                }
                else
                {
                    auxStr = auxStr + auxInv.Substring(i, 1);
                    cnt++;
                }
            }
            auxInv = String.Empty;
            for (int i = (auxStr.Length - 1), j = 0; i >= 0; i--, j++)
                auxInv = auxInv + auxStr.Substring(i, 1);
            return auxInv;
        }
        /// <summary>
        /// Metodo para Crear el Digito Verificador.-
        /// </summary>
        /// <param name="pRut"></param>
        /// <returns></returns>
        public static string RutDVCreate(string pRut)
        {
            int suma = 0;
            int mul = 2;

            for (int i = pRut.Length - 1; i >= 0; i--)
            {
                if (pRut.Substring(i, 1) != " ")
                {
                    suma = suma + Convert.ToInt32(pRut.Substring(i, 1)) * mul;
                    mul = mul == 7 ? 2 : mul + 1;
                }
            }
            string dvr = "" + Convert.ToString(11 - suma % 11);
            if (dvr == "11")
                return "0";
            else
            {
                if (dvr == "10")
                    return "K";
                else
                    return dvr;
            }
        }
        #endregion

        /// <summary>
        /// Convierte un tipo de SQLServer a un System.SqlDbType
        /// </summary>
        /// <param name="Value">Tipo de SQLServer </param>
        /// <returns>SqlDbType</returns>
        /// <author>Marcelo F. Oviedo</author>
        public static SqlDbType ConvertSQLToDbSql(string Value)
        {
            SqlDbType oType = new SqlDbType();

            switch (Value.ToUpper())
            {
                case "NCHAR":
                    oType = SqlDbType.NChar;
                    break;
                case "VARCHAR":
                    oType = SqlDbType.VarChar;
                    break;
                case "NVARCHAR":
                    oType = SqlDbType.NVarChar;
                    break;
                case "INT":
                    oType = SqlDbType.Int;
                    break;
                case "BIGINT":
                    oType = SqlDbType.BigInt;
                    break;
                case "SMALLBIGINT":
                    oType = SqlDbType.SmallInt;
                    break;
                case "BIT":
                    oType = SqlDbType.Bit;
                    break;
                case "DATETIME":
                    oType = SqlDbType.DateTime;
                    break;
                case "SMALLDATETIME":
                    oType = SqlDbType.SmallDateTime;
                    break;
                case "FLOAT":
                    oType = SqlDbType.Float;
                    break;
                case "MONEY":
                    oType = SqlDbType.Money;
                    break;
                case "SMALLMONEY":
                    oType = SqlDbType.SmallMoney;
                    break;
                case "DECIMAL":
                    oType = SqlDbType.Decimal;
                    break;
                case "TEXT":
                    oType = SqlDbType.Text;
                    break;
                case "NTEXT":
                    oType = SqlDbType.NText;
                    break;
                case "IMAGE":
                    oType = SqlDbType.Image;
                    break;
                case "VARBINARY":
                    oType = SqlDbType.VarBinary;
                    break;
                case "BINARY":
                    oType = SqlDbType.Binary;
                    break;
            }
            return oType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string ConvertSqlToCSahrp(string Value)
        {
            string wTipo = String.Empty;
            switch (Value.ToUpper())
            {
                case "VARCHAR":
                case "NVARCHAR":
                    wTipo = "string";
                    break;
                case "INT":
                    wTipo = "int";
                    break;
                case "BIT":
                    wTipo = "bool";
                    break;
                case "DATETIME":
                case "SMALLDATETIME":
                    wTipo = "System.DateTime";
                    break;

            }

            return wTipo;

        }

        /// <summary>
        /// Convierte una  array of 8-bit a su equivalente  System.String,
        ///  codificado en base 64 digitos
        /// </summary>
        /// <returns></returns>
        public static string ConvertBytesToBase64String(Byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }
        /// <summary>
        /// Convierte una imagen que esta en la web a un objeto Image
        /// </summary>
        /// <param name="imageURL">url</param>
        /// <returns>Image</returns>
        /// <author>Marcelo F. Oviedo</author>
        public static Image ConvertImageFromURL_ToImage(string imageURL)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(imageURL);
            Image img = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(bytes);


            return img;
        }

        /// <summary>
        /// Convierte una imagen que esta en la web a un objeto Byte[]
        /// </summary>
        /// <param name="imageURL">url</param>
        /// <returns>Byte[]</returns>
        /// <author>Marcelo F. Oviedo</author>
        public static Byte[] ConvertImageFromURL_ToImageByte(string imageURL)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(imageURL);

            return bytes;

            
        }
        /// <summary>
        /// Convierte un Byte[] a un System.Drawing.Image -
        /// </summary>
        /// <param name="byteArray">Byte[] que tiene formato de imagen</param>
        /// <returns>Image</returns>
        /// <author>Marcelo F. Oviedo</author>
        public static Image ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null)
                return null;
            Image returnImage = null;
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }


        /// <summary>
        /// Convierte un System.Drawing.Image a Byte[]
        /// </summary>
        /// <param name="imageToConvert">Imagen</param>
        /// <param name="formatOfImage">Formato ej:System.Drawing.Imaging.ImageFormat.Gif</param>
        /// <returns>byte[]</returns>
        /// <author>Marcelo F. Oviedo</author>
        public static byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert,
            ImageFormat formatOfImage)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Utiliza ASCIIEncoding
        /// </summary>
        /// <param name="stringText"></param>
        /// <returns></returns>
        public static byte[] ConvertStringToByteArray(string stringText)
          
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(stringText);
        }

        /// <summary>
        ///  Utiliza ASCIIEncoding
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ConvertBytesToTextString(Byte[] bytes)
        {

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetString(bytes);
            
        }
        /// <summary>
        /// Convierte una secuencia de bytes (cualquier clase que herede de stream) a un string .-
        /// </summary>
        /// <param name="pStream">cualquier clase que herede de stream</param>
        /// <returns>string del binario</returns>
        /// <author>Marcelo F. Oviedo</author>
        public static string ConvertToBase64String(Stream pStream)
        {

            Byte[] arr = new Byte[pStream.Length];
            pStream.Read(arr, 0, Convert.ToInt32(pStream.Length));
            pStream.Close();
            return Convert.ToBase64String(arr);
        }
        /// <summary>
        /// Obtiene el string que reprecenta el Base64 del archivo.-
        /// </summary>
        /// <param name="pFullFileName">Nombre del archivo del cual se quiere obtener el Base64</param>
        /// <returns>string del binario en Base64</returns>
        /// <author>Marcelo F. Oviedo</author>
        public static string ConvertToBase64String(String pFullFileName)
        {
            FileStream fs = new FileStream(pFullFileName, FileMode.Open, FileAccess.Read);
            return ConvertToBase64String(fs);
        }

        /// <summary>
        /// Convierte un Base64 string en un array de bytes. 
        /// </summary>
        /// <param name="pBase64String">String con el Base64 del binario</param>
        /// <returns>Byte[]</returns>
        /// <author>Marcelo F. Oviedo</author>
        public static Byte[] ConvertFromBase64String(String pBase64String)
        {
            Byte[] arrWrite = Convert.FromBase64String(pBase64String);
            return arrWrite;
        }


        /// <summary>
        /// Convierte un Base64 string a un archivo binario.-
        /// </summary>
        /// <param name="pBase64String">String con el Base64 del binario</param>
        /// <param name="pFullFileName">Nombre del archivo</param>
        /// <returns>Byte array que reprecenta el archivo</returns>
        /// <author>Marcelo F. Oviedo</author>
        public static Byte[] ConvertFromBase64StringToFile(String pBase64String, String pFullFileName)
        {
            FileStream fw = new FileStream(pFullFileName, FileMode.Create, FileAccess.Write);
            Byte[] arrWrite = Convert.FromBase64String(pBase64String);
            fw.Write(arrWrite, 0, arrWrite.Length);
            fw.Close();
            return arrWrite;
        }

        ///// <summary>
        ///// Convierte cualqyuier objeto a Byte[]
        ///// </summary>
        ///// <param name="obj">Cualquier objeto</param>
        ///// <returns>Byte arrays</returns>
        //public static byte[] ConvertObjectToByteArray(Object obj)
        //{
        //    if (obj == null)
        //        return null;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    MemoryStream ms = new MemoryStream();
        //    bf.Serialize(ms, obj);
        //    return ms.ToArray();
        //}


        /// <summary>
        /// Toma los elementos de pEntitiCollection y los agrega a la coleccion TEntities
        /// </summary>
        /// <typeparam name="TEntities">Tipo de la coleccion de entidades</typeparam>
        /// <typeparam name="TEntity">Tipo TEntity</typeparam>
        /// <param name="pEntitiCollection">Coleccion de entidades</param>
        /// <param name="pIenumerableList">Clase de lin q con los elementos TEntity</param>
        public static void SetEntitiesFromIenumerable<TEntities, TEntity>(TEntities pEntitiCollection, IEnumerable<TEntity> pIenumerableList)
            where TEntities : Entities<TEntity>
            where TEntity : Entity
        {
            foreach (TEntity item in pIenumerableList)
            {
                pEntitiCollection.Add(item);
            }
        }
       
        /// <summary>
        /// Funcion que busca recurcivamente si Tsource hereda de Tbase
        /// </summary>
        /// <param name="Tsource">Tipo origen </param>
        /// <param name="Tbase">Tipo base del cual puede heredar el tipo origen</param>
        /// <returns></returns>
        public static bool TypeInheritFrom(Type Tsource, Type Tbase)
        {
            if (Tsource.BaseType == null) return false;
            if (Tsource.BaseType != Tbase)
                return TypeInheritFrom(Tsource.BaseType, Tbase);
            else
                return true;


        }
        /// <summary>
        /// Funcion que busca recurcivamente si Tsource hereda de Tbase
        /// </summary>
        /// <param name="pObject">Instancia del tipo origen </param>
        /// <param name="Tbase">Tipo base del cual puede heredar el tipo origen</param>
        /// <returns></returns>
        public static bool TypeInheritFrom<Tsource>(object pObject, Type Tbase)
        {
            if (typeof(Tsource).BaseType == null) return false;
            if (typeof(Tsource).BaseType != Tbase)
                return TypeInheritFrom(typeof(Tsource).BaseType, Tbase);
            else
                return true;


        }

       
        /// <summary>
        /// Give a string representation of a object, with use of reflection.
        /// </summary>
        /// <param name="o">O.</param>
        /// <returns></returns>
        public static string ToString(Object o)
        {
            StringBuilder sb = new StringBuilder();
            Type t = o.GetType();

            PropertyInfo[] pi = t.GetProperties();

            sb.Append(string.Concat("Properties for: " , o.GetType().Name , System.Environment.NewLine));
            foreach (PropertyInfo i in pi)
            {
                if (!(i.Name.CompareTo("CanUndo") == 0 ||
                    i.Name.CompareTo("CanRedo") == 0))
                {
                    try
                    {

                        sb.Append(string.Concat("\t" , i.Name , "(" , i.PropertyType.ToString() , "): "));
                        if (null != i.GetValue(o, null))
                        {
                            sb.Append(i.GetValue(o, null).ToString());
                        }

                    }
                    catch
                    {
                    }
                    sb.Append(System.Environment.NewLine);
                }
            }

            FieldInfo[] fi = t.GetFields();

            foreach (FieldInfo i in fi)
            {
                try
                {
                    sb.Append(string.Concat("\t" , i.Name , "(" , i.FieldType.ToString() , "): "));
                    if (null != i.GetValue(o))
                    {
                        sb.Append(i.GetValue(o).ToString());
                    }

                }
                catch
                {
                }
                sb.Append(System.Environment.NewLine);

            }

            return sb.ToString();
        }
    }
}
