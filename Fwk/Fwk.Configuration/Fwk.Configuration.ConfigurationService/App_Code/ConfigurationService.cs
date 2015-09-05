using System;
using System.Diagnostics;
using System.Threading;
using System.Web;
using System.Xml;
using System.Text;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Common = Fwk.Configuration.Common;

using Fwk.Configuration.Common;


/// <summary>
/// Summary description for ConfigurationService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ConfigurationService : System.Web.Services.WebService
{
    ConfigFileRegistrys _ConfigFileRegistrys;
    public ConfigurationService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public Int32 GetFileVersionStatus(string pFileName, string pClientVersion)
    {
        try
        {

            Common.Helper.FileVersionStatus wFileVersionStatus = Common.Helper.FileVersionStatus.Ok;
            InitConfigFileRegistry();
            ConfigFileRegistry cnfg = _ConfigFileRegistrys.GetFirstByName(pFileName);

            if (cnfg.CurrentVersion != pClientVersion)
            {
                if (cnfg.ForceUpdate)
                {
                    wFileVersionStatus = Common.Helper.FileVersionStatus.RequiredUpdate;
                }
                else
                {
                    wFileVersionStatus = Common.Helper.FileVersionStatus.OptionalUpdate;
                }
            }

            return (Int32)wFileVersionStatus;

        }
        catch (SoapException soex)
        {
            throw soex;
        }
    }


    [WebMethod]
    public string GetConfig(string pFileName)
    {
        try
        {
            InitConfigFileRegistry();

            ConfigFileRegistry wConfigFileRegistry = _ConfigFileRegistrys.GetFirstByName(pFileName);
            if (!wConfigFileRegistry.Available)
            {
                throw new Exception("El archivo de configuración solicitado no está disponible.");
            }
            ///TODO: analisar si se continbua utiilizando esta arquitectura
            return "";// Common.Helper.GetConfig(Server.MapPath(@"~/ConfigurationFiles/" + pFileName), wConfigFileRegistry).GetXml();
        }
        catch (SoapException soex)
        {
            throw soex;
        }

    }


    void InitConfigFileRegistry()
    {
        if (_ConfigFileRegistrys != null) return;
        string fileReg = Fwk.HelperFunctions.FileFunctions.OpenTextFile(Server.MapPath("~/ConfigurationFiles/FileReg.xml"));
        _ConfigFileRegistrys = new ConfigFileRegistrys();
        _ConfigFileRegistrys = ConfigFileRegistrys.GetFromXml<ConfigFileRegistrys>(fileReg);
    }
}

