#region [ Usings ]
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using Timer = System.Timers;

using Fwk.Blocking;
#endregion


namespace Fwk.Blocking.BlockingService
{
    /// <summary>
    /// Servicio demonio que realiza barridos a la base de datos de Blockin, 
    /// con el objeto de liberar marcas de  bloqueo.-
    /// </summary>
    partial class BlockingService : ServiceBase
    {

        #region [Globals]
        /// <summary>
        /// Este es el timer que maneja las llamadas al método
        /// que limpia las BlockingMarks.
        /// </summary>
        private System.Timers.Timer _Timer;
        private double _Interval = 0;
        private int _WaitForComplete = 0;
        #endregion

        public BlockingService()
        {
            InitializeComponent();

            Initialize();
        }
        
        static void Main()
        {
            ServiceBase[] ServicesToRun;

      
            ServicesToRun = new ServiceBase[] { new BlockingService() };

            ServiceBase.Run(ServicesToRun);
        }


        protected override void OnStart(string[] args)
        {
            /// Inicia el Timer.
            _Timer.Start();

            BlockingHelper.WriteLog("Servicio de blocking iniciado.", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            _Timer.Stop();

            BlockingHelper.WriteLog("Servicio de blocking detenido.", EventLogEntryType.Information);
        }


        #region --[Initialize]--

        /// <summary>
        /// Inicializa todas las variables y objetos privados del servicio.
        /// </summary>
        private void Initialize()
        {
            try
            {
                /// Controla que está configurado el intervalo de  ejecución
                /// del servicio.
                _Interval = Fwk.Blocking.BlockingService.Properties.Settings.Default.Interval;// ConfigurationManager.GetProperty("BlockingModel", "Interval");


                _WaitForComplete = Fwk.Blocking.BlockingService.Properties.Settings.Default.WaitForComplete;


                /// Inicializa el Timer
                _Timer = new Timer.Timer();

                /// Agrega el event handler para los intervalos del Timer.
                _Timer.Elapsed += new Timer.ElapsedEventHandler(_Timer_Elapsed);

                /// Setea el intervalo de  ejecución del Timer a partir
                /// del archivo de configuración.
                _Timer.Interval = _Interval * 1000;
            }
            catch (Exception ex)
            {
                BlockingHelper.WriteLog(
                    String.Concat("Se produjo una excepción al inicializar el servicio.\r\n\r\n" , Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex)),
                    EventLogEntryType.Error);

                throw ex;
            }
        }

        #endregion

        #region --[Timer]--

        /// <summary>
        /// Event Handler para los intervalos del Timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Timer_Elapsed(object sender, Timer.ElapsedEventArgs e)
        {
            _Timer.Stop();
            ClearBlockingMarks();
            _Timer.Start();
            //try
            //{
            /// Crea un thread para la  ejecución de ClearBlockingMarks.
            //Thread thread = new Thread(new ThreadStart(ClearBlockingMarks));
            //thread.Start();

            /// Espera hasta que se cumpla el tiempo estipulado
            /// de espera.
            //thread.Join(_WaitForComplete * 1000);

            ///// Si el thread todavía está vivo lo mata.
            //if (thread.IsAlive)
            //{
            //    BlockingHelper.WriteLog("\r\nHay un thread que ha superado el tiempo de espera estipulado.",
            //        EventLogEntryType.Error);

            //    thread.Abort();

            //    throw new Exception("\r\nHay un thread que ha superado el tiempo de espera estipulado.");
            //}
            //}
            //catch (Exception ex)
            //{

            //    BlockingHelper.WriteLog("\r\nSe produjo una excepción al llamar a " +
            //        "ClearBlockingMarks.\r\nDescripción  Técnica: " + ex.Message +
            //        "\r\n\r\n" + ex.ToString(), EventLogEntryType.Error);
            //}
        }

        private void ClearBlockingMarks()
        {
            try
            {
                /// Llama al método que limpia las marcas para las
                /// cuales se cumplióel TTL.
                BlockingEngineBase.ClearBlockingMarks();
            }
            catch (Exception ex)
            {
                BlockingHelper.WriteLog(
                      String.Concat("Excepción al intentar limpiar las marcas de bloqueo\r\n", Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex)),
                     EventLogEntryType.Error);
            }
        }

        #endregion
    }
}
