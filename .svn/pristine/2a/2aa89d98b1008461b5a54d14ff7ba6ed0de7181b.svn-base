using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Comman_Services
{
    public  class SqlHelper
    {
        commanclass cmm = new commanclass();

        //public string postgreconnection()
        //{
        //    return "Host=192.168.1.31;Port=5432;User ID=shivakumar;Password=Avani@002;Database=EMarket_v2;Pooling=true;";
        //}

        public string ExecuteNonQueryFunction_Single(string query, params NpgsqlParameter[] parameters)
        {

            string retval = "";
            NpgsqlConnection cnn = new NpgsqlConnection(cmm.ConnectionString);
            NpgsqlCommand cmd = new NpgsqlCommand(query, cnn);
            cmd.CommandTimeout = 3000;
            NpgsqlTransaction trans = null;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i <= parameters.Length - 1; i++)
            {
                cmd.Parameters.Add(parameters[i]);
            }
            var retObject = new List<dynamic>();
            try
            {
                cnn.Open();
                //trans = BeginTransaction(IsolationLevel.ReadCommitted);
                //cmd.Transaction = trans;
                //retval = cmd.ExecuteNonQuery();
                //trans.Commit();

                //using (var dataReader = cmd.ExecuteReader())
                //{
                //    while (dataReader.Read())
                //    {
                //        var dataRow = new ExpandoObject() as IDictionary<string, object>;

                //        retval = Convert.ToInt64(dataReader["out_productid"]);
                //    }
                //}

                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var dataRow = new ExpandoObject() as IDictionary<string, object>;
                        for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                        {
                            dataRow.Add(
                                dataReader.GetName(iFiled),
                                dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                            );
                        }

                        retObject.Add((ExpandoObject)dataRow);
                    }
                }
                var uom_list = retObject.ToList();

                var output = JsonConvert.SerializeObject(uom_list[0]);

                retval = output;

            }
            catch (Exception ex)
            {

                trans.Rollback();
                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return retval;
        }

        public int ExecuteNonQueryProcedure(string query, params NpgsqlParameter[] parameters)
        {
           
            int retval = 0;
            NpgsqlConnection cnn = new NpgsqlConnection(cmm.ConnectionString);
            NpgsqlCommand cmd = new NpgsqlCommand(query, cnn);
            cmd.CommandTimeout = 3000;
            NpgsqlTransaction trans = null;
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i <= parameters.Length - 1; i++)
            {
                cmd.Parameters.Add(parameters[i]);
            }
            try
            {
                cnn.Open();
                trans = BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = trans;
                retval = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {

                trans.Rollback();
                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return retval;
        }
        public int ExecuteNonQueryFunction(string query, params NpgsqlParameter[] parameters)
        {

            int retval = 0;
            NpgsqlConnection cnn = new NpgsqlConnection(cmm.ConnectionString);
            NpgsqlCommand cmd = new NpgsqlCommand(query, cnn);
            cmd.CommandTimeout = 3000;
            NpgsqlTransaction trans = null;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i <= parameters.Length - 1; i++)
            {
                cmd.Parameters.Add(parameters[i]);
            }
            try
            {
                cnn.Open();
                trans = BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = trans;
                retval = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {

                trans.Rollback();
                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return retval;
        }

        public NpgsqlTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return PrepareTransaction(isolationLevel);
        }

        private NpgsqlTransaction PrepareTransaction(IsolationLevel isolationLevel)
        {
            NpgsqlConnection connection = new NpgsqlConnection(cmm.ConnectionString);
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.Open();
            }

            return connection.BeginTransaction(isolationLevel);
        }


    }
}
