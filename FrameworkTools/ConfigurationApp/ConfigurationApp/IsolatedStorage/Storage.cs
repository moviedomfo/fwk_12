using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;


namespace ConfigurationApp.IsolatedStorage
{
    /// <summary>
    /// Clase que almacena y recupera info de secion del usuario en la Isolated Storage del usuario.-
    /// Por lo general almacena en la siguiente ruta:
    /// C:\Documents and Settings\[LoginUser]\Configuracion local\Datos de programa\IsolatedStorage\4qor0vtm.wrs\yxyme100.sns\Url.odwtwkfxvowjc5dju2ujfrdujodlkavm\AssemFiles
    /// </summary>
    internal class Storage
    {
        #region [Members & Constructors]

        private const String ConfigManagerFilesUserSettings = "ConfigManagerFilesUserSettings.set";
        private const String AppConfigFilesUserSettings = "AppConfigFilesUserSettings.set";

        private Dictionary<String, String> _ConfigManagerFiles = null;

        public Dictionary<String, String> ConfigManagerFiles
        {
            get { return _ConfigManagerFiles; }
            set { _ConfigManagerFiles = value; }
        }
        private Dictionary<String, String> _AppConfigFiles = null;

        public Dictionary<String, String> AppConfigFiles
        {
            get { return _AppConfigFiles; }
            set { _AppConfigFiles = value; }
        }

        public Storage()
        {
            _ConfigManagerFiles = new Dictionary<string, string>();
            _AppConfigFiles = new Dictionary<string, string>();
        }

        #endregion

        /// <summary>
        /// Almacena los diccionarios serializados en UserIsolatedStorage
        /// </summary>
        internal void CreateStorage()
        {
            StoreAppConfigFiles();
            StoreConfigManager();
        }

        /// <summary>
        /// Carga los diccionarios serializados almacenados desde UserIsolatedStorage
        /// </summary>
        internal void LoadStorage()
        {
            LoadConfigManager();
            LoadAppConfigFiles();
        }

        /// <summary>
        /// Crear in IsolatedStorageFile con la serializacion en binario del diccionario ConfigManager.-
        /// Este diccionario contiene el par [NombreArchivo,Ruta]
        /// </summary>
        private void StoreConfigManager()
        {
            //creating a store
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(ConfigManagerFilesUserSettings, FileMode.Create, userStore);
            SerializeDictionary(userStream, _ConfigManagerFiles);
        }

        /// <summary>
        /// Crear in IsolatedStorageFile con la serializacion en binario del diccionario AppConfigFiles.-
        /// Este diccionario contiene el par [NombreArchivo,Ruta]
        /// </summary>
        private void StoreAppConfigFiles()
        {
            //creating a store
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(AppConfigFilesUserSettings, FileMode.Create, userStore);

            SerializeDictionary(userStream, _AppConfigFiles);
        }

        /// <summary>
        /// Obtiene un diccionario ConfigManager con la deserializacion en binario del IsolatedStorageFile
        /// Este diccionario contiene el par [NombreArchivo,Ruta]
        /// </summary>
        private void LoadConfigManager()
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();

            //If No data saved for this user
            if (userStore.GetFileNames(ConfigManagerFilesUserSettings).Length == 0)
            {
                _ConfigManagerFiles.Clear();
                return;
            }

            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(ConfigManagerFilesUserSettings, FileMode.Open, userStore);
            _ConfigManagerFiles = DeSerializeDictionary(userStream);
        }
 
        /// <summary>
        /// Obtiene un diccionario AppConfigFiles con la deserializacion en binario del IsolatedStorageFile
        /// Este diccionario contiene el par [NombreArchivo,Ruta]
        /// </summary>
        private void LoadAppConfigFiles()
        {
            

            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            //If No data saved for this user
            if (userStore.GetFileNames(AppConfigFilesUserSettings).Length == 0)
            {
                _ConfigManagerFiles.Clear();
                return;
            }

            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(AppConfigFilesUserSettings, FileMode.Open, userStore);

            _AppConfigFiles = DeSerializeDictionary(userStream);

        }

        /// <summary>
        /// Serializa en binario el diccionario
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="dict"></param>
        private static void SerializeDictionary(FileStream fs, Dictionary<String, String> dict)
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
        private static Dictionary<String, String> DeSerializeDictionary(FileStream fs)
        {
            Dictionary<String, String> dict;
            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                // Use the BinaryFormatter object to serialize the data to the file
                dict = (Dictionary<String, String>) bf.Deserialize(fs);

               
            }
            catch(System.Runtime.Serialization.SerializationException)
            {
                dict = new Dictionary<string, string>();
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
