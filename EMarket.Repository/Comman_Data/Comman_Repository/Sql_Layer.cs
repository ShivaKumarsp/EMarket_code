
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.IO;
using System.Text;

namespace EMarket.DLL.Comman_Data.Comman_Repository
{
    public class Sql_Layer: ISql_Layer
    {
      
        public readonly string ConnectionString = string.Empty;

        public string _ConnectionString { get => ConnectionString; }
        public Sql_Layer()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            ConnectionString = root.GetSection("ConnectionStrings").GetSection("PostgreSql1").Value;

        }

        public Array fn_get_list(string query, params DbParameter[] dbParams)
        {


            IDbHelper _dbHelper = new NpgsqlHelper(_ConnectionString);
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

        public string  Get_Data(string query, params DbParameter[] dbParams)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(_ConnectionString);
            var dataReader = _dbHelper.GetDataSet(query, CommandType.StoredProcedure, dbParams);           
            var listdata = Newtonsoft.Json.JsonConvert.SerializeObject(dataReader);    

            return listdata;
        }

        public string Get_ExecuteScalar(string query, params DbParameter[] dbParams)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(_ConnectionString);
            var exe_data = _dbHelper.ExecuteScalar(query, CommandType.StoredProcedure, dbParams);
            return exe_data.ToString();
        }
    }
}
