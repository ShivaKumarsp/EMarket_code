using EMarket.BLL.Comman_Class.Interface;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Text;

namespace EMarket.BLL.Comman_Class.Services
{
    public class SqlClass: ISqlClass
    {
        Db_Connection conn = new Db_Connection();
        public Array fn_get_list(string query, params DbParameter[] dbParams)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var dataReader = _dbHelper.GetDataSet(query, CommandType.StoredProcedure, dbParams);

            DataTableReader rd = dataReader.Tables[0].CreateDataReader();
            var retObject = new List<dynamic>();
            while (rd.Read())
            {
                var dataRow = new ExpandoObject() as IDictionary<string, object>;
                for (var iFiled = 0; iFiled < rd.FieldCount; iFiled++)
                {
                    dataRow.Add(
                        rd.GetName(iFiled),
                        rd.IsDBNull(iFiled) ? null : rd[iFiled] // use null instead of {}
                    );
                }

                retObject.Add((ExpandoObject)dataRow);
            }
            var return_list = retObject.ToArray();
            return return_list;
        }

        public string Get_Data(string query, params DbParameter[] dbParams)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var dataReader = _dbHelper.GetDataSet(query, CommandType.StoredProcedure, dbParams);
            var listdata = Newtonsoft.Json.JsonConvert.SerializeObject(dataReader);

            return listdata;
        }

        public string Get_ExecuteScalar(string query, params DbParameter[] dbParams)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var exe_data = _dbHelper.ExecuteScalar(query, CommandType.StoredProcedure, dbParams);
            return exe_data.ToString();
        }

    }
}
