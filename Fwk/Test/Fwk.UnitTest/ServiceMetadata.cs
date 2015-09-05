using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Bases;
using System.Configuration;
using Fwk.ConfigSection;
using Fwk.ServiceManagement;

namespace Fwk.UnitTest
{
    /// <summary>
    /// Summary description for ServiceMetadata
    /// </summary>
    [TestClass]
    public class ServiceMetadataTest
    {
        public ServiceMetadataTest()
        {

        }

        private TestContext testContextInstance;
        
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
       
        #endregion


        [TestMethod]
        public void UpdateAppConfig()
        {
            

            //ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            //map.ExeConfigFilename = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name + ".config";
            //System.Configuration.Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            //ServiceProviderSection config = (ServiceProviderSection)configuration.Sections["FwkServiceMetadata"]; 


            ServiceProviderElement p1 = new ServiceProviderElement ();
            p1.ApplicationId = "xxx";
            p1.Name = "p1";
            p1.SourceInfo = "";
            //config.Providers.Add(p1);
            //configuration.Save(ConfigurationSaveMode.Modified,true);
           
            ServiceMetadata.ProviderSection.AddNewProvider(p1);
        }
        //Solo para rellenar la base de datos
        [TestMethod]
        public void ImportToDB()
        {
            String strErrorResut = String.Empty;
            try
            {
                ServiceConfigurationCollection services = ServiceMetadata.GetAllServices("XML_test");

                if (ServiceMetadata.GetAllServices("Sql_test").Count == 0)
                {
                   
                        foreach (ServiceConfiguration s in services)
                        {
                            ServiceMetadata.AddServiceConfiguration("Sql_test", s);
                        }
                }
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
        }
        [TestMethod]
        public void XmlServiceConfigurationManager()
        {

            ServiceMetadata_Test("XML_test");
        }

        [TestMethod]
        public void DataServiceConfigurationManager()
        {

            ServiceMetadata_Test("Sql_test");

        }

        public void ServiceMetadata_Test(string providerName)
        {
            String strErrorResut = String.Empty;
            ServiceConfiguration wServiceConfigurationOriginal;
            ServiceConfiguration wServiceConfiguration;
            try
            {
                ServiceConfigurationCollection services = ServiceMetadata.GetAllServices(providerName);


                if (services.Count == 0)
                    Assert.Inconclusive("No existen servicios para realizar pruevas ");

                #region update
                wServiceConfigurationOriginal = ServiceMetadata.GetServiceConfiguration(providerName,services[0].Name);
                wServiceConfiguration = wServiceConfigurationOriginal.Clone();

                wServiceConfiguration.Audit = true;
                wServiceConfiguration.Name = wServiceConfigurationOriginal.Name + "_test";
                wServiceConfiguration.Description = wServiceConfigurationOriginal.Description + "_test";
                wServiceConfiguration.Request = wServiceConfigurationOriginal.Request + "_test";
                wServiceConfiguration.Response = wServiceConfigurationOriginal.Response + "_test";
                ServiceMetadata.SetServiceConfiguration(providerName,wServiceConfigurationOriginal.Name, wServiceConfiguration);
                #endregion

                #region CHEK update
                wServiceConfiguration = null;
                wServiceConfiguration = ServiceMetadata.GetServiceConfiguration(providerName, wServiceConfigurationOriginal.Name + "_test");

                if (!wServiceConfiguration.Name.Equals(string.Concat(wServiceConfigurationOriginal.Name, "_test"))
                   || !wServiceConfiguration.Response.Equals(string.Concat(wServiceConfigurationOriginal.Response, "_test"))
                   || !wServiceConfiguration.Request.Equals(string.Concat(wServiceConfigurationOriginal.Request, "_test"))
                    || !wServiceConfiguration.Description.Equals(string.Concat(wServiceConfigurationOriginal.Description, "_test")))
                {
                    Assert.Fail("La actualizacion en el metodo SetServiceConfiguration no se realizo con exito.-");
                }
                #endregion

                #region Add new service
                wServiceConfiguration = new ServiceConfiguration();

                wServiceConfiguration.Audit = true;
                wServiceConfiguration.Description = "desc_test";
                wServiceConfiguration.Name = "Name_test";
                wServiceConfiguration.Handler = "Handler_test";
                wServiceConfiguration.Request = "Request_test";
                wServiceConfiguration.Response = "Response_test";

                ServiceMetadata.AddServiceConfiguration(providerName, wServiceConfiguration);
                #endregion

                #region CHEK  Add new service
                wServiceConfiguration = null;

                wServiceConfiguration = ServiceMetadata.GetServiceConfiguration(providerName, "Name_test");

                if (wServiceConfiguration == null)
                {
                    Assert.Fail("La creacion del servicio por medio  del metodo AddServiceConfiguration no se realizo con exito.-");
                }


                #endregion



                ServiceMetadata.DeleteServiceConfiguration(providerName,"Name_test");
                try
                {
                    wServiceConfiguration = ServiceMetadata.GetServiceConfiguration(providerName, "Name_test");
                }
                catch (Exceptions.TechnicalException te)
                {
                    if (te.ErrorId.Equals("7002"))
                    { 

                    }
                }
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);


        }


        ServiceProviderSection _ServiceProviderSection;

        [TestMethod]
        public void Init_FwkServiceMetadata_Section()
        {

            if (_ServiceProviderSection == null)
            {
                _ServiceProviderSection = ConfigurationManager.GetSection("FwkServiceMetadata") as ServiceProviderSection;
            }

        }
        System.Configuration.Configuration configuration;
        [TestMethod]
        public void CheckProvider()
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name + ".config";
            configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);


            ServiceProviderElement provider = new ServiceProviderElement();
            provider.Name = "proividertest";
            provider.ApplicationId = "apptest";

            provider.ProviderType = ServiceProviderType.xml;
            AddNewProvider(provider);

        }
        void AddNewProvider(ServiceProviderElement newProvider)
        {

            ServiceProviderSection config = (ServiceProviderSection)configuration.Sections["FwkServiceMetadata"];
            config.Providers.Add(newProvider);
            configuration.Save(ConfigurationSaveMode.Minimal, true);

            ServiceMetadata.ProviderSection.Providers.Add(newProvider);
        }


    }
}
