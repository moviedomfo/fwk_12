using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using AppChecker.core.Properties;

namespace AppChecker.core
{
   

    public class Check_DoNetFramework : CheckerBase
    {



        public override void Run()
        {
            OnStartEvent("Start: .net framework version check");
            string root = System.IO.Path.Combine( Environment.GetEnvironmentVariable("systemroot"), @"Microsoft.NET\Framework");

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(root);
            System.IO.DirectoryInfo[] directorios = di.GetDirectories();

            //if (directorios.Any<DirectoryInfo>(d => d.Name.Contains("v1.0"))) no se puede usar LinQ en proyecto compilado en 2.0
            if(Contain(directorios,"v1.0"))
            {
                OnMessageEvent("        Microsoft.NET version 1.0 --> installed", Resources.apply, null);
            }
            else
            {
                OnMessageEvent("        Microsoft.NET version 1.0 --> not installed", Resources.del,null);
            }

           if(Contain(directorios,"v1.1"))
            {
                OnMessageEvent("        Microsoft.NET version 1.1 --> installed", Resources.apply, null);
            }
            else
            {
                OnMessageEvent("        Microsoft.NET version 1.1 --> not installed", Resources.del, null);
            }

           if(Contain(directorios,"v2.0"))
            {
                OnMessageEvent("        Microsoft.NET version 2.0 --> installed", Resources.apply, null);
            }
            else
            {
                OnMessageEvent("        Microsoft.NET version 2.0 --> not installed", Resources.del, null);
            }
           if(Contain(directorios,"v3.0"))
            {
                OnMessageEvent("        Microsoft.NET version 3.0 --> installed", Resources.apply, null);
            }
            else
            {
                OnMessageEvent("        Microsoft.NET version 3.0 --> not installed", Resources.del, null);
            }
           if(Contain(directorios,"v3.5"))
            {
                OnMessageEvent("        Microsoft.NET version 3.5 --> installed", Resources.apply, null);
            }
            else
            {
                OnMessageEvent("        Microsoft.NET version 3.5  --> not installed", Resources.del, null);
            }
           if(Contain(directorios,"v4.0"))
            {
                OnMessageEvent("        Microsoft.NET version 4.0 --> installed", Resources.apply, null);
            }
            else
            {
                OnMessageEvent("        Microsoft.NET version 4.0 --> not installed", Resources.del, null);
            }
            OnFinalizeEvent("", Resources.stop);

        }
    }
}
