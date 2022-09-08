using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Admin
{
    public class Product_Features_Repository : IProduct_Features_Repository
    {      
        comman_class cmm = new comman_class();
        SqlHelper sqlHelper = new SqlHelper();
        string return_string = "";
        List<string> invalue = new List<string>();
        int status = 0;
        public Product_Features_Repository()
        {
          
         
        }

        public product_featuresDTO save_productfeatures(product_featuresDTO dto)
        {
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams = new DbParameter[]
               {
                    DbHelper.CreateParameter("in_product_id", dto.product_id),
                    DbHelper.CreateParameter("in_product_title", dto.product_title),
                    DbHelper.CreateParameter("in_product_header", dto.product_header),
                    DbHelper.CreateParameter("in_product_subheader", dto.product_subheader),
                    DbHelper.CreateParameter("in_description", dto.description),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.userid),
                    DbHelper.CreateParameter("in_pfid", dto.pf_id)
                 
                    };

          
            var spName = "call sp_add_productfeature(:in_product_id,:in_product_title,:in_product_header,:in_product_subheader,:in_description,:in_language_id,:in_user_id,:in_pfid)";
            status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);


            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
          
            if (status ==-1)
            {
                dto.msg_flg = "Update";
                dto.message_flg = "Product Feature Saved Successfully";
            }
            else
            {
                dto.msg_flg = "Failed";
                dto.message_flg = "Product Feature Not Added";
            }


            return dto;
        }
    }
}
