using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class Product_Specification : IProduct_Specification
    {
        IProduct_Specification_Repository _inter;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        ISql_Layer _sql;
        IError_Log _error;
        int return_int = 0;
        public Product_Specification(PostgreSqlContext context, ISql_Layer sql, IError_Log error, IProduct_Specification_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public Product_SpecificationDTO get_specification_data(Product_SpecificationDTO dto)
        {
            dto.check_edit = false;
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Product_Specification_Service/get_specification_data";

            dto.product_name = _context.Master_Product_con.Where(a => a.product_id == dto.product_id && a.language_id == dto.language_id).SingleOrDefault().product_name.TrimEnd();
            if (dto.product_id > 0)
            {
                try
                {
                    //get specification
                    var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
               };
                    Params = dbParams;
                    
                    var exedata = _sql.Get_ExecuteScalar("fn_check_product_specification", dbParams);
                    if(exedata!="0")
                    {
                        dto.check_edit =true;
                    }
                   
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_product_specification", Params);
                }



                try
                {
                    //get specification
                    var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
               };
                    Params = dbParams;
                    dto.product_specification_list = _sql.fn_get_list("fn_get_product_specification", dbParams);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_product_specification", Params);
                }
                try
                {
                    //get Attribute name
                    var dbParams1 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
                   };
                    Params = dbParams1;
                    dto.attribute_name_list = _sql.fn_get_list("fn_product_attribute_name", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_product_attribute_name", Params);
                }
                try
                {
                    //get Attribute value
                    var dbParams2 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
                   };
                    Params = dbParams2;
                    dto.attribute_value_list = _sql.fn_get_list("fn_product_attribute_value", dbParams2);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_product_attribute_value", Params);
                }
            }

            return dto;
        }
        public Product_SpecificationDTO save_productspecification(Product_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Product_Specification_Service/save_productspecification";
            if (dto.product_id == 0)
            {
                dto.msg_flg = "Please Select Product";
                return dto;
            }           
            try
            {
                dto.product_name = _context.Master_Product_con.Where(a => a.product_id == dto.product_id && a.language_id == dto.language_id).SingleOrDefault().product_name.TrimEnd();

                //get cat specification
                var dbParams = new DbParameter[]
           {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
           };
                Params = dbParams;
                dto.additional_cat_specification_list = _sql.fn_get_list("fn_product_attribute_name", dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_product_attribute_name", Params);
            }
            try
            {
                //get Attribute value
                var dbParams1 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id)
                   };
                Params = dbParams1;
                dto.attribute_value_list = _sql.fn_get_list("fn_attribute_value", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_attribute_value", Params);
            }
            if (dto.product_id > 0)
            {
                try
                {
                    // Product specification
                    var dbParams4 = new DbParameter[]
                         {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
                     };
                    Params = dbParams4;
                    dto.product_specification_list = _sql.fn_get_list("fn_get_product_specification", dbParams4);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_product_specification", Params);
                }
            }

            if (dto.additional_cat_specification_list.Length == dto.additional_cat_array.Length)
            {
                try
                {
                    _inter.save_productspecification(dto);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_add_product_specification", Params);
                }
            }
            else
            {
                //dto.msg_flg = "Failed";
                dto.msg_flg = "Please Select Mandatory Fields";
            }
            try { 
            // Product specification
            var dbParams3 = new DbParameter[]
                 {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id)
               };
                Params = dbParams3;
            dto.product_specification_list = _sql.fn_get_list("fn_get_product_specification", dbParams3);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_product_specification", Params);
            }

            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
            return dto;
        }

        // Product Variant
        public Product_SpecificationDTO getvariantdata(Product_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Product_Specification_Service/getvariantdata";
            if (dto.product_id == 0)
            {
                dto.status = "Failed";
                dto.message = "Please Pass Product";
                return dto;
            }
            try
            {
                dto.product_name = _context.Master_Product_con.Where(a => a.product_id == dto.product_id && a.language_id == dto.language_id).SingleOrDefault().product_name.TrimEnd();

                //get Attribute
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_attributename_list";
                dto.attributename_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get valiant List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_variant_list";
                dto.variant_list = _sql.Get_Data(dto.procedure_name, dbParams1);

            }
            catch(Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Product_SpecificationDTO save_productvariant(Product_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Product_Specification_Service/save_productvariant";
            if (dto.product_id == 0)
            {
                dto.status = "Failed";
                dto.message = "Please Pass Product";
                return dto;
            }
            if (dto.attributename_id == 0)
            {
                dto.status = "Failed";
                dto.message = "Please Select Attribute";
                return dto;
            }
            try
            {
                _inter.save_productvariant(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            try
            {
                //get Attribute
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_attributename_list";
                dto.attributename_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get valiant List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_variant_list";
                dto.variant_list = _sql.Get_Data(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Product_SpecificationDTO delete_productvariant(Product_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Product_Specification_Service/delete_productvariant";
            if (dto.variant_id == 0)
            {
                dto.status = "Failed";
                dto.message = "Somthing Wrong, Please Try Again";
                return dto;
            }
           
            try
            {
                _inter.delete_productvariant(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            try
            {
                //get Attribute
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_attributename_list";
                dto.attributename_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get valiant List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_variant_list";
                dto.variant_list = _sql.Get_Data(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
    }
}
