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
    public class All_Product_Repository: IAll_Product_Repository
    {
        comman_class cmm = new comman_class();
        IError_Log _error;
        ISql_Layer _sql;
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        int return_int = 0;
        long return_long = 0;
        string return_string = "";
        bool saved = false;
        List<string> invalue = new List<string>();
        List<All_ProductDTO> dtonewtemp = new List<All_ProductDTO>();
        public All_Product_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

     
        public All_ProductDTO Update_Product(All_ProductDTO dto)
        {

            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var Params = new DbParameter[] { };
            var dbParams = new DbParameter[]
              {
                DbHelper.CreateParameter("in_product_id", Convert.ToInt64(dto.product_id)),
                    DbHelper.CreateParameter("in_category_id", Convert.ToInt64(dto.category_id)),
                    DbHelper.CreateParameter("in_sub_category_id", Convert.ToInt64(dto.sub_category_id)),
                    DbHelper.CreateParameter("in_additional_cat_id", Convert.ToInt64(dto.additional_cat_id)),
                    DbHelper.CreateParameter("in_brand_id", Convert.ToInt64(dto.brand_id)),
                    DbHelper.CreateParameter("in_product_type_id", Convert.ToInt64(dto.product_type_id)),
                    DbHelper.CreateParameter("in_product_name", dto.product_name),
                    DbHelper.CreateParameter("in_product_code", dto.product_code),
                    DbHelper.CreateParameter("in_base_price", Convert.ToDecimal(dto.base_price)),
                    DbHelper.CreateParameter("in_hsn_code", dto.hsn_code),
                    DbHelper.CreateParameter("in_ian_code", dto.ian_code),
                    DbHelper.CreateParameter("in_uom_id", Convert.ToInt64(dto.uom_id)),
                    DbHelper.CreateParameter("in_uom_weight_type_id", Convert.ToInt64(dto.uom_weight_type_id)),
                    DbHelper.CreateParameter("in_product_weight", Convert.ToDecimal(dto.product_weight)),
                    DbHelper.CreateParameter("in_uom_size_type_id", Convert.ToInt64(dto.uom_size_type_id)),
                    DbHelper.CreateParameter("in_product_size_l", Convert.ToDecimal(dto.product_size_l)),
                    DbHelper.CreateParameter("in_product_size_b", Convert.ToDecimal(dto.product_size_b)),
                    DbHelper.CreateParameter("in_product_size_h", Convert.ToDecimal(dto.product_size_h)),
                    DbHelper.CreateParameter("in_self_manufacturer", dto.self_manufacturer),
                    DbHelper.CreateParameter("in_is_perishable", dto.is_perishable),
                    DbHelper.CreateParameter("in_is_contains_bom", dto.is_contains_bom),
                    DbHelper.CreateParameter("in_short_description", dto.short_description),
                    DbHelper.CreateParameter("in_image_path", dto.image_path),
                    DbHelper.CreateParameter("in_userid", Convert.ToInt64(dto.user_id)),
                    DbHelper.CreateParameter("in_language_id", Convert.ToInt64(dto.language_id)),

              };
            Params = dbParams;
            var spName = "fn_add_product";
            var retObject1 = new List<dynamic>();
            using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
            {
                while (dataReader.Read())
                {
                    var dataRow = new ExpandoObject() as IDictionary<string, object>;
                    dtonewtemp.Add(new All_ProductDTO
                    {
                        out_productid = Convert.ToInt64(dataReader["out_productid"])

                    });
                }
            }
            dto.ret_product_id = dtonewtemp[0].out_productid;



            if (dto.ret_product_id != 0)
                    {
                        dto.status = "Update";
                        dto.message = "Product Insert Successfully";
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Product Insert Successfully";
                    }               
           
            return dto;
        }
         public All_ProductDTO update_attribute(All_ProductDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams4 = new DbParameter[]
     {
                    DbHelper.CreateParameter("in_specification_id",dto.specification_id),
                     DbHelper.CreateParameter("in_product_id", dto.product_id),
                    DbHelper.CreateParameter("in_attribute_name_id",dto.attributename_id),
                    DbHelper.CreateParameter("in_attribute_value_id",dto.attributevalue_id),
                    DbHelper.CreateParameter("in_product_specification_id",dto.product_specification_id),

        };
            foreach (var item in dbParams4)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }

            var spName = "call sp_add_product_specification(:in_specification_id, :in_product_id,:in_attribute_name_id,:in_attribute_value_id,:in_product_specification_id)";
            return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);

                if (return_int == -1)
                {
                    dto.status = "Update";
                }
                else
                {
                    dto.status = "Failed";
                }

            return dto;
        }

        public All_ProductDTO saveproductspecification(All_ProductDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var dbParams4 = new DbParameter[]
     {
                    DbHelper.CreateParameter("in_prospecid",dto.product_specification_id),
                     DbHelper.CreateParameter("in_productid", dto.product_id),
                    DbHelper.CreateParameter("in_specificationid",dto.specification_id),
                    DbHelper.CreateParameter("in_attributenameid",dto.attribute_name_id),
                    DbHelper.CreateParameter("in_languageid",dto.language_id),
                    DbHelper.CreateParameter("in_enable_custom_value",dto.enable_custom_value),

        };
           
            foreach (var item in dbParams4)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }

            var spName = "call sp_save_masterproductspecification(:in_prospecid,:in_productid, :in_specificationid,:in_attributenameid,:in_languageid,:in_enable_custom_value)";
            return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
            if (return_int == -1)
            {
                dto.msg_flg = "Update";
            }
            else
            {
                dto.msg_flg = "Failed";
            }


            return dto;
        }
        public All_ProductDTO deletemasterproductspecification(All_ProductDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var dbParams4 = new DbParameter[]
     {
                    DbHelper.CreateParameter("in_prospecid",dto.product_specification_id),
                     

        };

            foreach (var item in dbParams4)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }

            var spName = "call sp_delete_masterproductspecification(:in_prospecid)";
            return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
            if (return_int == -1)
            {
                dto.msg_flg = "Delete";
            }
            else
            {
                dto.msg_flg = "Failed";
            }


            return dto;
        }

   
    }
}
