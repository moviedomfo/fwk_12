using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

using Fwk.DataBase;


namespace Fwk.CodeGenerator
{
    
    public delegate void FailWorkHandler(Exception error);
    public delegate void StartWorkHandler(String pMessage, String pOtherMsg);
    public delegate void FinishWorkHandler();

    public class LoadFromDatabaseWorker
    {
        
        #region [Eventos]
        private bool _ConnectionState = false;
        private event FailWorkHandler _FailWorkEvent;
        private event StartWorkHandler _StartWorkEvent ;
        private event FinishWorkHandler _FinishWorkEvent ;
        internal void OnFailWorkEvent(Exception e)
        {

            if (_FailWorkEvent != null)
                _FailWorkEvent(e);
        }
        private void OnStartWorkEvent(String pMessage,String pOtherMsg)
        {

            if (_StartWorkEvent != null)
                _StartWorkEvent(pMessage, pOtherMsg);
        }

        private void OnFinishWorkEvent()
        {

            if (_FinishWorkEvent != null)
                _FinishWorkEvent();
        }

        internal event FailWorkHandler FailtWorkEvent
        {
            add
            {
                _FailWorkEvent = (FailWorkHandler)Delegate.Combine(_FailWorkEvent, value);
            }
            remove
            {
                _FailWorkEvent = (FailWorkHandler)Delegate.Remove(_FailWorkEvent, value);
            }
        }

        internal event StartWorkHandler StartWorkEvent
        {
            add
            {
                _StartWorkEvent = (StartWorkHandler)Delegate.Combine(_StartWorkEvent, value);
            }
            remove
            {
                _StartWorkEvent = (StartWorkHandler)Delegate.Remove(_StartWorkEvent, value);
            }
        }

        internal event FinishWorkHandler FinishtWorkEvent
        {
            add
            {
                _FinishWorkEvent = (FinishWorkHandler)Delegate.Combine(_FinishWorkEvent, value);
            }
            remove
            {
                _FinishWorkEvent = (FinishWorkHandler)Delegate.Remove(_FinishWorkEvent, value);
            }
        }

        #endregion

        private Fwk.DataBase.Metadata _Metadata = null;
        internal Fwk.DataBase.Metadata Metadata
        {
            set { _Metadata = value; }
        }
        private CodeGeneratorCommon.SelectedObject m_SelectedObject;

        internal CodeGeneratorCommon.SelectedObject SelectedObject
        {
            get { return m_SelectedObject; }
            set { m_SelectedObject = value; }
        }


        internal void Start()
        {

            try
            {

                Thread wThreadTest = new Thread(new ThreadStart(TestCnn));
                wThreadTest.Start();


                OnStartWorkEvent("Waiting connection to SQL Server...",String.Empty);

                if (!_ConnectionState)
                    return;

                Thread wThread = new Thread(new ThreadStart(Load));
                wThread.Start();

                if (m_SelectedObject == CodeGeneratorCommon.SelectedObject.Tables)
                    OnStartWorkEvent("Loading Tables from database", String.Empty);

                if (m_SelectedObject == CodeGeneratorCommon.SelectedObject.StoreProcedures)
                    OnStartWorkEvent("Loading Store Procedures fron database", String.Empty);

            }
            catch (Exception ex)
            {
                string s;

                s = "No es posible conectarce a la base de datos, " + Environment.NewLine;
                s += "verifique la coneccion seleccionando la opcion indicada debajo en la " + Environment.NewLine;
                s += "barra de menu.- ";
                s += Environment.NewLine + "Inner Exeption: " + Environment.NewLine + ex.Message;

                throw new Exception(s);



            }


        }
        /// <summary>
        /// Este metodo es invocado por Start() y pertenece a otro hilo
        /// </summary>
        private void Load()
        {
            try
            {
                if (m_SelectedObject == CodeGeneratorCommon.SelectedObject.Schema) return;
                if (_Metadata == null)
                {
                    OnFinishWorkEvent();
                    return;
                }

                //_Metadata.RefreshConnection();
                if (m_SelectedObject == CodeGeneratorCommon.SelectedObject.Tables)
                {
                    //_Metadata.LoadTables();
                }

                if (m_SelectedObject == CodeGeneratorCommon.SelectedObject.StoreProcedures)
                {
                    //_Metadata.LoadStoreProcedures();
                }

                _Metadata.LoadUserDefinedTypes();

                OnFinishWorkEvent();
            }
            catch (Exception ex)
            {

               
                OnFailWorkEvent(ex);

            }

        }

        private void TestCnn()
        {
            try
            {
                _Metadata.TestConnection();
                _ConnectionState = true;
                OnFinishWorkEvent();
            }
            catch (Exception ex)
            {
                OnFinishWorkEvent();
                _ConnectionState = false;
                OnStartWorkEvent("Ocurrio un error al intentar conectarce a la base de datos " , ex.Message);
                ////OnFailWorkEvent(er);
                
            }
            finally
            {
               
            }
        }
    }
}
