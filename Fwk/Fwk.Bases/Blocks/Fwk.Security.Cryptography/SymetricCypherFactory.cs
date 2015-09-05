using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Fwk.Exceptions;
using Fwk.Security.Cryptography.Config;
using Fwk.Bases.Properties;

namespace Fwk.Security.Cryptography

{



    /// <summary>
    /// Fabrica de SymetriCypher. Crea todo los algoritmos de tipo RijndaelManaged
    /// </summary>
    public static class SymetricCypherFactory
    {

       
        static Dictionary<string, ISymetriCypher> CypherProviders;
        static CypherProviderSection _CypherProviders;
 
        /// <summary>
        /// Crea el diccionario de ISymetriCypher
        /// </summary>
        static SymetricCypherFactory()
        {
         
        }
         static void InitializeProviders()
        {
            if (CypherProviders != null) return;
            CypherProviders = new Dictionary<string, ISymetriCypher>();
            String k = String.Empty;
            TechnicalException te;
            try
            {
                _CypherProviders = System.Configuration.ConfigurationManager.GetSection("FwkCypherProvider") as CypherProviderSection;
                if (_CypherProviders == null)
                {
                    te = new TechnicalException(String.Format(Fwk.Bases.Properties.Resources.setting_section_not_found, "FwkCypherProvider" ));
                    te.ErrorId = String.Empty;

                    throw te;
                }
                var wFullFileName = String.Empty;
                foreach (CypherProviderElement provider in _CypherProviders.Providers)
                {

                    if (provider.Type.Equals("file"))
                    {
                        if (System.IO.File.Exists(provider.Source))
                        {
                            wFullFileName = provider.Source;
                         
                        }
                        else
                        {
                            wFullFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), provider.Source);
                            
                        }
                        if (!System.IO.File.Exists(wFullFileName))
                        {
                            te = new TechnicalException(String.Format(Fwk.Bases.Properties.Resources.security_provider_keyfile_not_found, provider.Source, provider.Name));
                            throw te;
                        }
                        k = Fwk.HelperFunctions.FileFunctions.OpenTextFile(wFullFileName);
                    }
                    Add<RijndaelManaged>(provider.Name, k);
                    
                }
            }
            catch (System.Exception ex)
            {

                //te = new TechnicalException(ex);
                //ExceptionHelper.SetTechnicalException<SymetriCypher_EntLibs<T>>(te);
                //te.ErrorId = "";
                throw ex;
            }
        }

        /// <summary>
        /// Utiliza el SymetriCypher por defecto configurado en el .config
        /// </summary>
        /// <returns></returns>
        public static ISymetriCypher Cypher()
        {
            return Cypher(String.Empty);
        }

        /// <summary>
        /// Busca un cryptographer determinado por medio de su nombre  
        /// </summary>
        /// <param name="providerName">nombre proveedor configurado en el .config</param>
        /// <returns>Argoritmo ISymetriCypher</returns>
        public static ISymetriCypher Cypher(string providerName)
        {
            InitializeProviders();

            if (String.IsNullOrEmpty(providerName))
                providerName = _CypherProviders.DefaultProviderName;

            ISymetriCypher symetriCypher = null;


            //Busca el SymetriCypher en el diccionario
            if (CypherProviders.ContainsKey(providerName))
                symetriCypher = (ISymetriCypher)CypherProviders[providerName];
         
            else
            {

                TechnicalException te = new TechnicalException(String.Format(Fwk.Bases.Properties.Resources.setting_provider_not_found, providerName, "FwkCypherProvider"));
                te.ErrorId = "4401";
                throw te;
            }
            return symetriCypher;
        }

     
        /// <summary>
        /// Busca un cryptographer determinado por medio de su nombre de archivo de encriptacion y tipo de algoritmo simetrico
        /// </summary>
        /// <typeparam name="T">Tipo de algoritmo simetrico</typeparam>
        /// <param name="providerName">Nombre de proveedor de encriptación</param>
        /// <param name="key">Clave de encriptacion</param>
        /// <returns>Argoritmo</returns>
        static SymetriCypher<T> Add<T>(string providerName, string key) where T : SymmetricAlgorithm
        {
            if (String.IsNullOrEmpty(providerName))
                providerName = _CypherProviders.DefaultProviderName;

            if (string.IsNullOrEmpty(key))
            {
                TechnicalException te = new TechnicalException("La clave de encriptacion no puede ser nula");
                te.ErrorId = "4401";
                throw te;
            }

            SymetriCypher<T> symetriCypher = null;
            //Busca el SymetriCypher en el diccionario
            if (CypherProviders.ContainsKey(providerName))
                symetriCypher = (SymetriCypher<T>)CypherProviders[providerName];
            else
            {
                symetriCypher = new SymetriCypher<T>(key);

                CypherProviders.Add(providerName, symetriCypher);
            }

            return symetriCypher;
        }



     
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static String GenNewKey() 
        {
          SymetriCypher<RijndaelManaged> c =new SymetriCypher<RijndaelManaged> ();
          return c.GeneratetNewK();
        }

    }


    
}
