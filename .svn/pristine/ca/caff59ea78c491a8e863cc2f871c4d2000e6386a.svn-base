using EMarket.BLL.Comman_Class.Interface;
using EMarketDTO.Admin;
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
   public class DuplicateCheck: IDuplicateCheck
    {
        Db_Connection conn = new Db_Connection();
        IErrorClass _error;
        public DuplicateCheck(IErrorClass error)
        {
            _error = error;
        }
        public bool check_product(Master_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            List<Master_ProductDTO> dtonewtemp1 = new List<Master_ProductDTO>();
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            bool valid = false;
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Duplicate_Check/check_product";
            try
            {
                var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_name", dto.product_name),
                      DbHelper.CreateParameter("in_product_code", dto.product_code),
                      DbHelper.CreateParameter("in_product_type_id", dto.product_type_id)
                    };
                Params = dbParams;
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
                _error.errorlog(ex, 0, methodname, "", "Web", page_form, "fn_check_duplicate_product", Params);
            }
            return valid;
        }
        public bool check_doubleclick(string methodname, long userid)
        {
            bool ret = false;
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var dbParams = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_methodname", methodname),
                     DbHelper.CreateParameter("in_userid", userid)

                };

            var spName = "fn_check_double_click";
            var dataReader = _dbHelper.ExecuteScalar(spName, CommandType.StoredProcedure, dbParams);
            ret = Convert.ToBoolean(dataReader);

            return ret;
        }
    }
}
