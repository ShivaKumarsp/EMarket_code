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
    public class AddProduct_Repository : IAddProduct_Repository
    {
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        ISql_Layer _sql;
        IError_Log _error;     
        int status = 0;
        string return_string = "";
        List<string> invalue = new List<string>();
        List<Master_ProductDTO> dtonewtemp = new List<Master_ProductDTO>();
        public AddProduct_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
       
        }
            
        public Master_ProductDTO Save_Product(Master_ProductDTO dto)
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
                    dtonewtemp.Add(new Master_ProductDTO
                    {
                        out_productid = Convert.ToInt64(dataReader["out_productid"])

                    });
                }
            }
            dto.ret_product_id = dtonewtemp[0].out_productid;



            //NpgsqlParameter[] para = new NpgsqlParameter[25];
            //para[0] = new NpgsqlParameter("@in_product_id", Convert.ToInt64(dto.product_id));
            //para[1] = new NpgsqlParameter("@in_category_id", Convert.ToInt64(dto.category_id));
            //para[2] = new NpgsqlParameter("@in_sub_category_id", Convert.ToInt64(dto.sub_category_id));
            //para[3] = new NpgsqlParameter("@in_additional_cat_id", Convert.ToInt64(dto.additional_cat_id));
            //para[4] = new NpgsqlParameter("@in_brand_id", Convert.ToInt64(dto.brand_id));
            //para[5] = new NpgsqlParameter("@in_product_type_id", Convert.ToInt64(dto.product_type_id));
            //para[6] = new NpgsqlParameter("@in_product_name", dto.product_name);
            //para[7] = new NpgsqlParameter("@in_product_code", dto.product_code);
            //para[8] = new NpgsqlParameter("@in_base_price", Convert.ToDecimal(dto.base_price));
            //para[9] = new NpgsqlParameter("@in_hsn_code", dto.hsn_code);
            //para[10] = new NpgsqlParameter("@in_ian_code", dto.ian_code);
            //para[11] = new NpgsqlParameter("@in_uom_id", Convert.ToInt64(dto.uom_id));
            //para[12] = new NpgsqlParameter("@in_uom_weight_type_id", Convert.ToInt64(dto.uom_weight_type_id));
            //para[13] = new NpgsqlParameter("@in_product_weight", Convert.ToDecimal(dto.product_weight));
            //para[14] = new NpgsqlParameter("@in_uom_size_type_id", Convert.ToInt64(dto.uom_size_type_id));
            //para[15] = new NpgsqlParameter("@in_product_size_l", Convert.ToDecimal(dto.product_size_l));
            //para[16] = new NpgsqlParameter("@in_product_size_b", Convert.ToDecimal(dto.product_size_b));
            //para[17] = new NpgsqlParameter("@in_product_size_h", Convert.ToDecimal(dto.product_size_h));
            //para[18] = new NpgsqlParameter("@in_self_manufacturer", dto.self_manufacturer);
            //para[19] = new NpgsqlParameter("@in_is_perishable", dto.is_perishable);
            //para[20] = new NpgsqlParameter("@in_is_contains_bom", dto.is_contains_bom);
            //para[21] = new NpgsqlParameter("@in_short_description", dto.short_description);
            //para[22] = new NpgsqlParameter("@in_image_path", dto.image_path);
            //para[23] = new NpgsqlParameter("@in_userid", Convert.ToInt64(dto.user_id));
            //para[24] = new NpgsqlParameter("@in_language_id", Convert.ToInt64(dto.language_id));

            //foreach (var item in para)
            //{
            //    invalue.Add(item.ParameterName + ':' + item.Value);
            //}
            //dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
            //dto.procedure_name = "fn_add_product";
            //return_string = sqlHelper.ExecuteNonQueryFunction_Single("fn_add_product", para);          
            //using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(return_string)))
            //{
            //    // Deserialization from JSON
            //    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Master_ProductDTO));
            //    Master_ProductDTO bsObj2 = (Master_ProductDTO)deserializer.ReadObject(ms);
            //    dto.ret_product_id = bsObj2.out_productid;

            //}

            //Master_ProductDTO ss =  JsonSerializer.Deserialize<Master_ProductDTO>(return_string);
            if (dto.ret_product_id != 0)
            {
                dto.status = "Update";
                dto.message = "Product Insert Successfully";

            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed Product Insert";
            }

            return dto;
        }

        //Product Question Set For vendor    
        public Master_ProductDTO saveproductspecification(Master_ProductDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
           
                var dbParams = new DbParameter[]
        {
                    DbHelper.CreateParameter("in_prospecid", dto.product_specid),
                    DbHelper.CreateParameter("in_productid", dto.product_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                    DbHelper.CreateParameter("in_attributenameid", dto.attribute_name_id),
                    DbHelper.CreateParameter("in_languageid", dto.language_id),
                    DbHelper.CreateParameter("in_enable_custom_value", dto.enable_custom_value),
                     DbHelper.CreateParameter("in_is_variant_attribute", dto.is_variant_attribute)
        };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
            dto.procedure_name = "sp_save_masterproductspecification";
            var spName = "call sp_save_masterproductspecification(:in_prospecid,:in_productid, :in_specificationid,:in_attributenameid,:in_languageid,:in_enable_custom_value,:in_is_variant_attribute)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.status = "Update";
                    dto.message = "'Product Specification Saved Successfully.";
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "'Product Specification Not Saved, Please Try Again',";
                }              
            
            return dto;
        }
        public Master_ProductDTO deletemasterproductspecification(Master_ProductDTO dto)
        {   
            
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
                                

                        var dbParams = new DbParameter[]
             {
                    DbHelper.CreateParameter("in_prospecid", dto.product_specid)
             };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
            dto.procedure_name = "sp_delete_masterproductspecification";
            var spName = "call sp_delete_masterproductspecification(:in_prospecid)";
                        status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                        if (status == -1)
                        {
                            dto.status = "Delete";
                        }
                        else
                        {
                            dto.status = "Failed";
                        }                 


            return dto;
        }
    }
}
