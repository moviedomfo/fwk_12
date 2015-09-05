using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace Fwk.Caching
{

   



    /// <summary>
    ///     Enumerates the levels of isolated storage scope that are supported by System.IO.IsolatedStorage.IsolatedStorage.
    /// </summary>
    [Serializable]
    [ComVisible(true)]
    [Flags]
    public enum FwkIsolatedStorageScope
    {
        /// <summary>
        ///Obtains machine-scoped isolated storage corresponding to the calling code's
        ///application identity.
             /// </summary>
        MachineStoreForApplication = 0,
       
        /// <summary>
        /// Obtains machine-scoped isolated storage corresponding to the application
        /// domain identity and the assembly identity.
        /// </summary>
        MachineStoreForAssembly = 1,
  
        /// <summary>
        ///Obtains machine-scoped isolated storage corresponding to the application
        ///domain identity and the assembly identity. 
        /// </summary>
        MachineStoreForDomain = 2,

        /// <summary>
        //Obtains user-scoped isolated storage corresponding to the calling code's
        //application identity. 
        /// </summary>
        UserStoreForApplication = 4,
      
        /// <summary>
        ///Obtains user-scoped isolated storage corresponding to the calling code's
        ///assembly identity. 
        /// </summary>
        UserStoreForAssembly = 8,

        /// <summary>
        ///Obtains user-scoped isolated storage corresponding to the application domain
        ///identity and assembly identity. 
        /// </summary>
        UserStoreForDomain = 16
        
       
    }
    
    



    /// <summary>
    /// Clase base que permite un almacenamiento en el IsolatedStorageFile.- 
    /// Esta clase no nececita configuracion de cache de ningun tipo.-
    /// </summary>
    /// <example>
    /// <para>Crear una clase que herede de FwkSimpleStorageBase para el caso en que deseemos implementar 
    /// una inicializacion personalizada de nuestro objeto.-
    /// </para> 
    /// <code>
    /// <![CDATA[
    ///     internal class MyStorageSetting : FwkSimpleStorageBase<Cliente>
    ///     {
    ///         public override void InitObject()
    ///         {
    ///             _Object = new Store();
    ///             _Object.Nombre = "Pepe";
    ///         }
    ///     }
    /// ]]>
    /// </code>   
    /// <para>Usar directamente la clase FwkSimpleStorageBase 
    /// </para> 
    /// <code>
    /// <![CDATA[
    /// 
    ///     public FwkSimpleStorageBase<Cliente> _Store = new FwkSimpleStorageBase<Cliente>();
    /// ]]>
    /// </code>    
    /// </example>
    [Serializable]
    public class FwkSimpleStorageBase<T>
    {
        string CONFIG_FILE = AppDomain.CurrentDomain.FriendlyName;
        FwkIsolatedStorageScope _IsolatedStorageScope = FwkIsolatedStorageScope.UserStoreForApplication;
       
        
        /// <summary>
        /// 
        /// </summary>
        public FwkSimpleStorageBase()
        { }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scope"></param>
        public FwkSimpleStorageBase(FwkIsolatedStorageScope scope)
        {
            _IsolatedStorageScope = scope;
        }

        T _Object;

        /// <summary>
        /// Reprecenta el objeto serializable que se almacena en la cache del sistema
        /// </summary>
        public T StorageObject
        {
            get
            {
                if (_Object == null)
                    Load();
                return _Object;
            }
            set { _Object = value; }
        }

        /// <summary>
        /// Permite cargar el almacenammiento del objeto.. Este metodo llama al metodo virtual InitObject.
        /// Generalmente se usa desde el Load del formulario
        /// <example>
        /// <code>
        /// <![CDATA[
        /// private void Form1_Load(object sender, EventArgs e)
        /// {
        ///     _Storage.Load();
        ///     txtNombre.Text= _Storage.StorageObject.Nombre;
        /// ]]>
        /// </code>    
        /// </example>
        /// </summary>
        public void Load()
        {
            try
            {
                IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();

                //Si no hay datos para este usuario
                if (userStore.GetFileNames(CONFIG_FILE).Length == 0)
                {
                    //Limpio el diccionario por si contien algo
                    InitObject();
                    return;

                }
                //Abro el stream con la informacion serializada del diccionario desde el IsolatedStorage
                IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(CONFIG_FILE, FileMode.Open, userStore);
                _Object = DeSerializeDictionary(userStream);
            }
            catch (FileNotFoundException)//si ocurre algun error construyo una coneccion por defecto
            {
                InitObject();

                Save();

            }

        }

        /// <summary>
        ///Domain 	    Isolated Storage Scoped to Application Domain Identity
        ///Assembly 	Isolated Storage Scoped to Identity of the Assembly
        ///Roaming 	The Isolated Storage Can roam.
        ///Application 	Isolated Storage Scoped to the Application
        ///
        /// User 	Isolated Storage scoped to User Identity
        ///Machine 	Isolated Storage Scoped to the Machine
        /// </summary>
        void Get_IsolatedStorageFile()
        {
            
            IsolatedStorageFile wIsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();

           
            switch (_IsolatedStorageScope)
            {
                case FwkIsolatedStorageScope.UserStoreForApplication:
                    {
                        wIsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
                        break;
                    }
                case FwkIsolatedStorageScope.UserStoreForAssembly:
                    {
                        wIsolatedStorageFile = IsolatedStorageFile.GetUserStoreForAssembly ();
                        break;
                    }
                case FwkIsolatedStorageScope.UserStoreForDomain:
                    {
                        wIsolatedStorageFile = IsolatedStorageFile.GetUserStoreForDomain();
                        break;
                    }
                case FwkIsolatedStorageScope.MachineStoreForApplication:
                    {
                        wIsolatedStorageFile = IsolatedStorageFile.GetMachineStoreForApplication();
                        break;
                    }
              case FwkIsolatedStorageScope.MachineStoreForAssembly:
                    {
                        wIsolatedStorageFile = IsolatedStorageFile.GetMachineStoreForAssembly();
                        break;
                    }
                    case FwkIsolatedStorageScope.MachineStoreForDomain:
                    {
                        wIsolatedStorageFile = IsolatedStorageFile.GetMachineStoreForDomain();
                        break;
                    }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            //_Object = null;
            Save();
        }

        /// <summary>
        /// Generalmente utilizado desde un FormClosing 
        /// <example>
        /// <code>
        /// <![CDATA[
        /// private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        /// {
        ///      _Storage.StorageObject.Nombre = txtNombre.Text;
        ///     _Storage.Save();
        ///     
        /// ]]>
        /// </code>    
        /// </example>
        /// </summary>
        public void Save()
        {

            // Crear archivo que se pueda almacenar en el Isolated Storage
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();

            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(CONFIG_FILE, FileMode.Create, userStore);

            //Serializa el diccionario y guarda el contenido binario en el stream
            SerializeDictionary(userStream, _Object);

        }

        /// <summary>
        /// Deserializa: Convierte el stream a una lista de coneciones
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="dict"></param>
        T DeSerializeDictionary(FileStream fs)
        {

            T obj;

            // Crea  un BinaryFormatter para realizar la serializacion
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                //Convierte el stream a un T
                obj = (T)bf.Deserialize(fs);

            }

            catch (System.Runtime.Serialization.SerializationException)
            {

                obj = (T)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(typeof(T).AssemblyQualifiedName);

            }

            finally
            {

                fs.Close();
            }

            return obj;

        }
        /// <summary>
        /// Serializa en binario el la lista de conecciones
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="dict"></param>
        private static void SerializeDictionary(FileStream fs, T dict)
        {
            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();
            // Use the BinaryFormatter object to serialize the data to the file
            bf.Serialize(fs, dict);
            // Close the file
            fs.Close();
        }


        /// <summary>
        /// Metodo que permite inicializar el objeto de manera personalizada al sobreescribirlo.- Si no se sobreescribe
        /// el meto solo realiza una instancioacion de <see cref="T"/>
        /// </summary>
        public virtual void InitObject()
        {
            //if (typeof(T).AssemblyQualifiedName.Contains("mscorlib"))
            //{
            //    System.Reflection.Assembly a = System.Reflection.Assembly.Load("Mscorlib.dll");
            //    _Object = (T)a.CreateInstance(typeof(T).Name, true);
            //    return;
            //}

            _Object = (T)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(typeof(T).AssemblyQualifiedName);
          
        }

    }
}
