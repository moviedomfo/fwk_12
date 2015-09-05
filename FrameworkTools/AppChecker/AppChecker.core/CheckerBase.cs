using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.IO;
using AppChecker.core.Properties;

namespace AppChecker.core
{
    
    public  class CheckerBase : AppChecker.core.ICheckerBase
    {
        public event CheckEven StartEvent;
        public event CheckEven FinalizeEvent;
        public event CheckEven MessageEvent;
        protected void OnStartEvent(string msg)
        {
            if (StartEvent != null) StartEvent(new CheckMesage(msg, Resources.play));
        }
        protected void OnFinalizeEvent(string msg, Image image)
        {
            if (FinalizeEvent != null) FinalizeEvent(new CheckMesage(msg, null));
        }
        protected void OnMessageEvent(string msg,Image image2,Image image3)
        {

            
            if (MessageEvent != null) MessageEvent(new CheckMesage(msg,null, image2,image3));
        }


        public virtual void Run() { }


        public bool Contain(DirectoryInfo[] directorios,string str )
        {
            foreach (DirectoryInfo d in directorios)
            {
                if (d.Name.Contains(str)) return true;

            }
             return false;
        }
    }
}
