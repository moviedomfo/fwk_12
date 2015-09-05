using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Fwk.Blocking;
namespace Fwk.Blocking.Test
{
    public  class BlockingEngineArchivosGraficos :BlockingEngineBase
    {
        public BlockingEngineArchivosGraficos()
            : base("BlockingArchivosGraficos") { }

        protected override List<SqlParameter> GetCustomParametersUserExist(IBlockingMark pIBlockingMark)
        {
            BlockingMarkArchivosGraficos wBlockingMarkClass = (BlockingMarkArchivosGraficos)pIBlockingMark;

            List<SqlParameter> wSqlParameterCollection = new List<SqlParameter>();

            /// Crea los parámetros del Stored Procedure
            SqlParameter wParam = new SqlParameter();

            //CodigoNota
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigosNotas";
            wParam.SqlDbType = SqlDbType.VarChar;
            if (string.IsNullOrEmpty(wBlockingMarkClass.ListaCodigoNotas))
                wParam.Value = null;
            else
                wParam.Value = wBlockingMarkClass.ListaCodigoNotas;

            //CodigoNota
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoNota";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoNota;

            //CodigoPagina
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoPagina";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoPagina;

            //IdArchivo

            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@IdArchivo";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.IdArchivo;

            return wSqlParameterCollection;
        }

        protected override List<SqlParameter> GetCustomParametersToInsert(IBlockingMark pIBlockingMark)
        {
            BlockingMarkArchivosGraficos wBlockingMarkClass = (BlockingMarkArchivosGraficos)pIBlockingMark;

            List<SqlParameter> wSqlParameterCollection = new List<SqlParameter>();

            /// Crea los parámetros del Stored Procedure
            SqlParameter wParam = new SqlParameter();

            //CodigoNota
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoNota";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoNota;

            //CodigoPagina
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoPagina";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoPagina;

            //IdArchivo
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@IdArchivo";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.IdArchivo;

            


            return wSqlParameterCollection;




         
        }

        /// <summary>
        /// para llamar al sp [BlockingArchivosGraficos_s]
        /// </summary>
        /// <param name="pIBlockingMark"></param>
        /// <returns></returns>
        protected override List<SqlParameter> GetCustomParametersToGetByParams(IBlockingMark pIBlockingMark)
        {
            BlockingMarkArchivosGraficos wBlockingMarkClass = (BlockingMarkArchivosGraficos)pIBlockingMark;

            List<SqlParameter> wSqlParameterCollection = new List<SqlParameter>();

            /// Crea los parámetros del Stored Procedure
            SqlParameter wParam = new SqlParameter();

            //CodigoNota
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoNota";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoNota;

            //CodigoPagina
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@CodigoPagina";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.CodigoPagina;


            //IdArchivo
            wParam = new SqlParameter();
            wSqlParameterCollection.Add(wParam);
            wParam.ParameterName = "@IdArchivo";
            wParam.SqlDbType = SqlDbType.Int;
            wParam.Value = wBlockingMarkClass.IdArchivo;
        

         


            return wSqlParameterCollection;





        }
    }
}
