using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Fwk.Blocking;


namespace Fwk.Blocking.Test
{
    public  class BlockingEngineAudioVisual :BlockingEngineBase
    {
        public BlockingEngineAudioVisual(): base("BlockingAudiovisuales") { }

        protected override List<SqlParameter> GetCustomParametersUserExist(IBlockingMark pIBlockingMark)
        {
            BlockingMarkAudioVisual wBlockingMarkClass = (BlockingMarkAudioVisual)pIBlockingMark;

            List<SqlParameter> wSqlParameterCollection = new List<SqlParameter>();

            /// Crea los parámetros del Stored Procedure
            SqlParameter wParam = new SqlParameter();



            //CodigoBloque
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoBloque";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoBloque;

            //CodigoMedio
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoMedio";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoMedio;

            //FechaHoraInicioTransmision
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@FechaHoraInicioTransmision";
            wParam.SqlDbType = SqlDbType.DateTime;
            wParam.Value = wBlockingMarkClass.FechaHoraInicioTransmision;

            //FechaHoraFinTransmision
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@FechaHoraFinTransmision";
            wParam.SqlDbType = SqlDbType.DateTime;
            wParam.Value = wBlockingMarkClass.FechaHoraFinTransmision;

           

            return wSqlParameterCollection;
        }

        protected override List<SqlParameter> GetCustomParametersToInsert(IBlockingMark pIBlockingMark)
        {
            BlockingMarkAudioVisual wBlockingMarkClass = (BlockingMarkAudioVisual)pIBlockingMark;

            List<SqlParameter> wSqlParameterCollection = new List<SqlParameter>();

            /// Crea los parámetros del Stored Procedure
            SqlParameter wParam = new SqlParameter();
            //CodigoBloque
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoBloque";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoBloque;

            //CodigoMedio
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoMedio";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoMedio;

            //FechaHoraInicioTransmision
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@FechaHoraInicioTransmision";
            wParam.SqlDbType = SqlDbType.DateTime;
            wParam.Value = wBlockingMarkClass.FechaHoraInicioTransmision;

            //FechaHoraFinTransmision
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@FechaHoraFinTransmision";
            wParam.SqlDbType = SqlDbType.DateTime;
            wParam.Value = wBlockingMarkClass.FechaHoraFinTransmision;

            //Objeto
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@Objeto";
            wParam.SqlDbType = SqlDbType.Bit;
            wParam.Value = wBlockingMarkClass.Objeto;

            //EsOnline
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@EsOnline";
            wParam.SqlDbType = SqlDbType.Bit;
            wParam.Value = wBlockingMarkClass.EsOnline;


            return wSqlParameterCollection;




         
        }

        protected override List<SqlParameter> GetCustomParametersToGetByParams(IBlockingMark pIBlockingMark)
        {
            BlockingMarkAudioVisual wBlockingMarkClass = (BlockingMarkAudioVisual)pIBlockingMark;

            List<SqlParameter> wSqlParameterCollection = new List<SqlParameter>();

            /// Crea los parámetros del Stored Procedure
            SqlParameter wParam = new SqlParameter();

            //CodigoMedio
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoMedio";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoMedio;

            //FechaHoraInicioTransmision
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@FechaHoraInicioTransmision";
            wParam.SqlDbType = SqlDbType.DateTime;
            wParam.Value = wBlockingMarkClass.FechaHoraInicioTransmision;

            //FechaHoraFinTransmision
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@FechaHoraFinTransmision";
            wParam.SqlDbType = SqlDbType.DateTime;
            wParam.Value = wBlockingMarkClass.FechaHoraFinTransmision;

            //Objeto
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@Objeto";
            wParam.SqlDbType = SqlDbType.Bit;
            wParam.Value = wBlockingMarkClass.Objeto;

            //EsOnline
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@EsOnline";
            wParam.SqlDbType = SqlDbType.Bit;
            wParam.Value = wBlockingMarkClass.EsOnline;


            return wSqlParameterCollection;





        }
    }

    public class BlockingEngineGeneric : BlockingEngineBase
    {
        public BlockingEngineGeneric(string pTableName) : base(pTableName) { }

        protected override List<SqlParameter> GetCustomParametersToInsert(IBlockingMark pBlockingMark)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override List<SqlParameter> GetCustomParametersToGetByParams(IBlockingMark pBlockingMark)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override List<SqlParameter> GetCustomParametersUserExist(IBlockingMark pBlockingMark)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
