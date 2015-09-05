using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting;
using Fwk.Remoting;

namespace TestServicePerformance
{
    public delegate void CheckEven(string msg, int threadNumber, double average, double totalTime);
    public delegate void DelegateWithOutAndRefParameters(out Exception ex);
    public delegate void FinalizeHandler(string msg);
    public delegate void CallHandler();
    
    internal class RemotingWrapper_config
    {
        #region members & properties
        bool stop = false;
        private Object thisLock = new Object();
        public event CheckEven MessageEvent;
        public event FinalizeHandler FinalizeEvent;
        public event CallHandler CallEvent;
        public ManualResetEvent[] doneEvents;
        
        FwkRemoteObject _RemoteObj;

        internal Fwk.Remoting.FwkRemoteObject RemoteObj
        {
            get { return _RemoteObj; }
        }

        Fwk.Bases.IServiceContract isvcReq;
        Fwk.Bases.IServiceContract isvcRes;
        #endregion

        #region Init -->


        internal void Init()
        {

            _RemoteObj = CreateRemoteObject();

        }
        /// <summary>
        /// Crea en este caso SimpleFacaddeRemoteObject .-
        /// </summary>
        /// <returns>Instancia de SimpleFacaddeRemoteObject</returns>
        FwkRemoteObject CreateRemoteObject()
        {
            LoadRemotingConfigSettings();
            if (_RemoteObj == null)
                _RemoteObj = new FwkRemoteObject();
            return _RemoteObj;
        }

        /// <summary>
        /// Carga la configuracion de remoting en el archivo indicado por RemotingConfigFile_2
        /// </summary>
        void LoadRemotingConfigSettings()
        {
            if (!IsConfigured())
            {
                RemotingConfiguration.Configure("RemotingConfigFile_2.config", false);
            }
        }

        bool IsConfigured()
        {

            bool wResult = false;

            foreach (WellKnownClientTypeEntry wEntry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                if (wEntry.TypeName == typeof(FwkRemoteObject).FullName)
                {
                    wResult = true;
                    break;
                }
            }

            return wResult;

        }
        #endregion


        internal void Start(string xml)
        {
            stop = false;
            isvcReq = (Fwk.Bases.IServiceContract)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Request);
            isvcRes = (Fwk.Bases.IServiceContract)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Response);
            isvcReq.SetBusinessDataXml(xml);
            isvcReq.InitializeHostContextInformation();

            doneEvents = new ManualResetEvent[ControllerTest.Storage.StorageObject.Threads];

            for (int i = 0; i <= ControllerTest.Storage.StorageObject.Threads - 1; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(new WaitCallback(StartThread), i);
                if (stop) break;
            }


        }


        void StartThread(object threadNumber)
        {

            double sumTotalMilliseconds = 0;
            for (int i = 0; i <= ControllerTest.Storage.StorageObject.Calls - 1; i++)
            {
                if (stop) break;
                Stopwatch watch = new Stopwatch();
                watch.Start();
                isvcRes = _RemoteObj.ExecuteService(string.Empty, isvcReq);
                //System.Threading.Thread.Sleep(300);
                watch.Stop();

                if (isvcRes.Error != null)//--->  error FIN
                {
                    if (FinalizeEvent != null)
                        FinalizeEvent(isvcRes.Error.Message);
                    lock (thisLock)//seccion critica
                    {
                        stop = true;
                    }
                }
                if (CallEvent != null)// avisa que se ejecuto una llamada
                    CallEvent();
                sumTotalMilliseconds += watch.Elapsed.TotalMilliseconds;


            }

         
            double AVERAGE = sumTotalMilliseconds / ControllerTest.Storage.StorageObject.Calls;

            if (MessageEvent != null)
                MessageEvent("Thread Nº", (int)threadNumber, AVERAGE, sumTotalMilliseconds);

            doneEvents[(int)threadNumber].Set();

            if ((int)threadNumber + 1 == doneEvents.Length)
                if (FinalizeEvent != null)
                    FinalizeEvent("");
            
        }
    }
}

