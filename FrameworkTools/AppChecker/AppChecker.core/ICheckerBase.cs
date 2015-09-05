using System;
namespace AppChecker.core
{
    public delegate void CheckEven(CheckMesage pCheckMesage);

    public interface ICheckerBase
    {
        /// <summary>
        /// Mensage de finalizacion
        /// </summary>
        event CheckEven FinalizeEvent;
        /// <summary>
        /// Mensage de algun evento ocurrido durante la ejecucion
        /// </summary>
        event CheckEven MessageEvent;

        /// <summary>
        /// Metodo de que realiza la tarea del checker
        /// </summary>
        void Run();

        /// <summary>
        /// Evento q informa el inicio
        /// </summary>
        event CheckEven StartEvent;
    }
}
