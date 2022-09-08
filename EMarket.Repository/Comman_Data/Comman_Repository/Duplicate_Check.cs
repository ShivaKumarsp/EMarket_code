using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarketDTO.Admin;
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
   public class Duplicate_Check: IDuplicate_Check
    {
        comman_class cmm = new comman_class();
        public readonly string ConnectionString = string.Empty;
        IError_Log _error;
        ISql_Layer _sql;
        public string _ConnectionString { get => ConnectionString; }
        public Duplicate_Check(IError_Log error, ISql_Layer sql)
        {
            _error = error;
            _sql = sql;
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            ConnectionString = root.GetSection("ConnectionStrings").GetSection("PostgreSql1").Value;

        }

        public bool check_product(Master_ProductDTO dto)
        {
            List<Master_ProductDTO> dtonewtemp1 = new List<Master_ProductDTO>();
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            bool valid = false;
            try
            {
                var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_name", dto.product_name),
                      DbHelper.CreateParameter("in_product_code", dto.product_code),
                      DbHelper.CreateParameter("in_product_type_id", dto.product_type_id)
                    };
                var dataReader = _dbHelper.GetDataSet("fn_check_duplicate_product", CommandType.StoredProcedure, dbParams);
                DataTableReader rd = dataReader.Tables[0].CreateDataReader();
                var retObject = new List<dynamic>();


                while (rd.Read())
                {
                    var dataRow = new ExpandoObject() as IDictionary<string, object>;
                    dtonewtemp1.Add(new Master_ProductDTO
                    {

                        getdata_count = Convert.ToInt32(rd["p_count"])

                    });
                }

                if (dtonewtemp1[0].getdata_count > 0)
                {
                    valid = true;
                }

            }
            catch (Exception ex)
            {
                var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                string methodname = "Duplicate_Check/check_product";
              
            }
            return valid;
        }
    }
}

