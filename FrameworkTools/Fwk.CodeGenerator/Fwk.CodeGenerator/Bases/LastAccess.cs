using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;


namespace Fwk.CodeGenerator
{
    [Serializable]
    internal  class LastAccess
    {
        private LastISVC _LastISVC = new LastISVC();
        private string _LastTemplateSettingFileName = String.Empty;

        public LastAccess()
        {
            _LastISVC = new LastISVC();
        }
        internal LastISVC LastISVC
        {
            get { return _LastISVC; }
            set { _LastISVC = value; }
        }


        public string LastTemplateSettingFileName
        {
            get { return _LastTemplateSettingFileName; }
            set { _LastTemplateSettingFileName = value; }
        }
        

     

    }
    [Serializable]
    internal class LastISVC
    {
        string _XSDReqPath = String.Empty;
        string _XSDResPath = String.Empty;
        string _XSDPath = String.Empty;

        public string XSDPath
        {
            get { return _XSDPath; }
            set { _XSDPath = value; }
        }
        
        public string XSDReqPath
        {
            get { return _XSDReqPath; }
            set { _XSDReqPath = value; }
        }
       

        public string XSDResPath
        {
            get { return _XSDResPath; }
            set { _XSDResPath = value; }
        }

    }

    
    public class LastAccessStorage
    {
        private const String LastAccessStorageName = "CodeGeneratorLastAccessStorage.set";
        private LastAccess _LastAccess;

        internal LastAccess LastAccess
        {
            get { return _LastAccess; }
            set { _LastAccess = value; }
        }

        public LastAccessStorage()
        {
            Load();
        }

        public void Save()
        {
            //creating a store
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(LastAccessStorageName, FileMode.Create, userStore);
            SerializeDictionary(userStream, _LastAccess);
        }


        #region Private methods
        /// <summary>
        /// Obtiene un objeto con la deserializacion en binario del IsolatedStorageFile
        /// </summary>
        void Load()
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();

            //If No data saved for this user
            if (userStore.GetFileNames(LastAccessStorageName).Length == 0)
            {
                _LastAccess = new LastAccess();
                return;
            }

            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(LastAccessStorageName, FileMode.Open, userStore);
            try
            {
                _LastAccess = (LastAccess) DeSerializeDictionary(userStream);
            }
            catch (System.Runtime.Serialization.SerializationException )
            {
                _LastAccess = new LastAccess();
            }
        }
      
        /// <summary>
        /// Serializa en binario el diccionario
        /// </summary>
        /// <param name="fs">FileStream</param>
        /// <param name="obj">Objeto a serializar</param>
         static void SerializeDictionary(FileStream fs, object obj)
        {
            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();
            // Use the BinaryFormatter object to serialize the data to the file
            bf.Serialize(fs, obj);
            // Close the file
            fs.Close();
        }
        /// <summary>
        /// Deserializa el objeto
        /// </summary>
        /// <param name="fs"></param>
        static object DeSerializeDictionary(FileStream fs)
        {
            object obj;
            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                // Use the BinaryFormatter object to serialize the data to the file
                obj = bf.Deserialize(fs);


            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                throw ex; 
            }
            finally
            {
                // Close the file
                fs.Close();
            }
            return obj;
        }
        #endregion
    }
}
