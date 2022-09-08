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
using System.Linq;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Admin
{
    public class Product_Specification_Repository : IProduct_Specification_Repository
    {
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        ISql_Layer _sql;
        IError_Log _error;
        int return_int = 0;
        List<string> invalue = new List<string>();
        int status = 0;
        public Product_Specification_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }


        public Product_SpecificationDTO save_productspecification(Product_SpecificationDTO dto)
        {
            
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            foreach (var item in dto.additional_cat_array)
            {
                var dbParams = new DbParameter[]
              {
                    DbHelper.CreateParameter("in_specification_id", item.specification_id),
                    DbHelper.CreateParameter("in_product_id", dto.product_id),
                    DbHelper.CreateParameter("in_attribute_name_id", item.attributename_id),
                    DbHelper.CreateParameter("in_attribute_value_id", item.attributevalue_id),
                    DbHelper.CreateParameter("in_product_specification_id", 0)
                   };

                var spName = "call sp_add_product_specification(:in_specification_id,:in_product_id,:in_attribute_name_id,:in_attribute_value_id,:in_product_specification_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);

            }
            if (status == -1)
            {
                dto.msg_flg = "Update";
                dto.message = "Product Specification Saved Successfully";
            }
            else
            {
                dto.msg_flg = "Failed";
                dto.message = "Product Specification Not Added";
            }


            return dto;
        }

        public Product_SpecificationDTO save_productvariant(Product_SpecificationDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams = new DbParameter[]
      {
                    DbHelper.CreateParameter("in_variant_id", dto.variant_id),
                    DbHelper.CreateParameter("in_product_id", dto.product_id),
                    DbHelper.CreateParameter("in_attribute_name_id", dto.attributename_id),
                    DbHelper.CreateParameter("in_is_level", dto.is_level),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                
      };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
            dto.procedure_name = "call sp_save_product_variant(:in_variant_id,:in_product_id,:in_attribute_name_id, :in_is_level,:in_user_id)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
                if(dto.variant_id>0)
                {
                    dto.status = "Update";
                    dto.message = "Product Variant Updated Successfully.";
                }
                else
                {
                    dto.status = "Update";
                    dto.message = "Product Variant Saved Successfully.";
                }
               
            }
            else
            {
                dto.status = "Failed";
                dto.message = "'Product Variant Not Saved, Please Try Again',";
            }


            return dto;
        }
        public Product_SpecificationDTO delete_productvariant(Product_SpecificationDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams = new DbParameter[]
      {
                    DbHelper.CreateParameter("in_variant_id", dto.variant_id),
                    DbHelper.CreateParameter("in_product_id", dto.product_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)

      };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
            dto.procedure_name = "call sp_delete_product_variant(:in_variant_id,:in_product_id,:in_user_id)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
               
                    dto.status = "Delete";
                    dto.message = "Product Variant Deleted Successfully.";
                

            }
            else
            {
                dto.status = "Failed";
                dto.message = "'Product Variant Not Deleted, Please Try Again',";
            }


            return dto;
        }
    }
}
