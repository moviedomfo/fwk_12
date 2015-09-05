using System;
using System.Collections.Generic;

using System.Text;
using System.Configuration;
using AppChecker.core.Properties;
using System.IO;
using System.Drawing;

namespace AppChecker.core
{
    public class Check_SQLServerAccess : CheckerBase
    {
        public override void Run()
        {
            OnStartEvent("Start: Checking Connection String ");

            //DirectoryInfo di = new DirectoryInfo(System.Reflection.Assembly.GetExecutingAssembly(). Location );
            String[] files = Directory.GetFiles(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "*exe.config");
            if (files.Length > 0)
            {
                foreach (String f in files)
                {
                    ProcFile(f);
                }
            }
            else
            {
                OnMessageEvent("       No config files exit in current directory", Resources.Symbol_Information_2, null);
            }
            OnFinalizeEvent("", Resources.stop);
        }


        private void ProcFile(String file)
        {
            OnMessageEvent("   Check file: " + Path.GetFileName(file), Resources.file_apply, null);
            ConnectionStringSettingsCollection wConnectionStrings = GetCnnstrings(file);
            CnnString cnn;
            if (wConnectionStrings != null)
            {

                foreach (ConnectionStringSettings c in wConnectionStrings)
                {
                    if (!c.Name.Equals("LocalSqlServer", StringComparison.OrdinalIgnoreCase))
                    {
                        cnn = new CnnString(c.Name, c.ConnectionString);

                        if (cnn.TestConnection())
                        {
                            OnMessageEvent("       Connection: " + c.Name + " OK ", null, Resources.apply);
                        }
                        else
                        {
                            OnMessageEvent("       Connection: " + c.Name + " not found ", null, Resources.del);
                        }
                    }
                }
            }


        }


        ConnectionStringSettingsCollection GetCnnstrings(string pFullFileName)
        {


            String strFileName = System.IO.Path.GetFileName(pFullFileName);

            ConnectionStringSettingsCollection wConnectionStrings = null;

            Configuration wConfiguration = null;
            try
            {
                ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
                configFile.ExeConfigFilename = pFullFileName;

                wConfiguration = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);

                wConnectionStrings = wConfiguration.ConnectionStrings.ConnectionStrings;


            }
            catch (System.Configuration.ConfigurationErrorsException wConfigurationErrorsException)
            {
                OnMessageEvent("        " + wConfigurationErrorsException.Message, null, Resources.Symbol_Information_2);
                return null;
            }
            if (wConnectionStrings == null)
            {
                OnMessageEvent("        " + Path.GetFileName(pFullFileName) + " not contain onnection strings ", null,Resources.Symbol_Information_2);
            }
            if (wConnectionStrings.Count == 1)
            {
                if (wConnectionStrings[0].Name.Equals("LocalSqlServer", StringComparison.OrdinalIgnoreCase))
                    OnMessageEvent("        " + Path.GetFileName(pFullFileName) + " not contain connection strings ", null, Resources.Symbol_Information_2);

            }
            return wConnectionStrings;
        }

    }
}

