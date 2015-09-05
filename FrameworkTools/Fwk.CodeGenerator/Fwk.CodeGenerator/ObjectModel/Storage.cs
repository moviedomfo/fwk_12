using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;
using Fwk.DataBase;


namespace Fwk.CodeGenerator
{
    /// <summary>
    /// Clase que almacena y recupera info de secion del usuario en la Isolated Storage del usuario.-
    /// Por lo general almacena en la siguiente ruta:
    /// C:\Documents and Settings\[LoginUser]\Configuracion local\Datos de programa\IsolatedStorage\4qor0vtm.wrs\yxyme100.sns\Url.odwtwkfxvowjc5dju2ujfrdujodlkavm\AssemFiles
    /// </summary>
    public class Storage
    {
        #region [Members & Constructors]
        private const String EnvDTESetting = "EnvDTESetting.set";
        private  CnnString _CnnString;
        public CnnString CnnString
        {
            get { return _CnnString; }
            set { _CnnString = value; }
        }
       

        public Storage()
        {
            _CnnString = new CnnString();
        }

        #endregion

        /// <summary>
        /// Almacena los diccionarios serializados en UserIsolatedStorage
        /// </summary>
        public void SaveStorage()
        {
        
            Store();
        }

        /// <summary>
        /// Carga los diccionarios serializados almacenados desde UserIsolatedStorage
        /// </summary>
        public void LoadStorage()
        {
            Load();
         
        }

        /// <summary>
        /// Crear in IsolatedStorageFile con la serializacion en binario del diccionario ConfigManager.-
        /// Este diccionario contiene el par [NombreArchivo,Ruta]
        /// </summary>
         void Store()
        {
            //creating a store
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(EnvDTESetting, FileMode.Create, userStore);
            SerializeDictionary(userStream, _CnnString);
        }

       

        /// <summary>
        /// Obtiene un diccionario ConfigManager con la deserializacion en binario del IsolatedStorageFile
        /// Este diccionario contiene el par [NombreArchivo,Ruta]
        /// </summary>
         void Load()
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();

            //If No data saved for this user
            if (userStore.GetFileNames(EnvDTESetting).Length == 0)
            {
                _CnnString = new CnnString();
                return;
            }

            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(EnvDTESetting, FileMode.Open, userStore);
            _CnnString = DeSerializeDictionary(userStream);
        }
 
       

        /// <summary>
        /// Serializa en binario el diccionario
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="dict"></param>
        private static void SerializeDictionary(FileStream fs, CnnString dict)
        {
            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();
            // Use the BinaryFormatter object to serialize the data to the file
            bf.Serialize(fs, dict);
            // Close the file
            fs.Close();
        }

        /// <summary>
        /// Deserializa en binario el diccionario
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="dict"></param>
        private static CnnString DeSerializeDictionary(FileStream fs)
        {
            CnnString dict;
            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                // Use the BinaryFormatter object to serialize the data to the file
                dict = (CnnString) bf.Deserialize(fs);

               
            }
            catch(System.Runtime.Serialization.SerializationException)
            {
                dict = new CnnString();
            }
            finally
            {
                // Close the file
                fs.Close();
            }
            return dict;
        }
    }
}
