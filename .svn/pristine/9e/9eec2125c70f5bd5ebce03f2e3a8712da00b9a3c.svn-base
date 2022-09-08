using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
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
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class AddProduct : IAddProduct
    {
        IAddProduct_Repository _inter;
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        IDuplicateCheck _duplicate;
     
        int status = 0;
        string return_string = "";

        public AddProduct(IAddProduct_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error, IDuplicateCheck duplicate)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
            _duplicate = duplicate;
        }

        public Master_ProductDTO get_data(Master_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AddProduct/get_data";

            // category list
            try
            {
                var dbParams = new DbParameter[]
                                  {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                                  };
                Params = dbParams;
                dto.category_list = _sql.fn_get_list("fn_get_category", dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_category", Params);
            }


            // product type
            try
            {
                var dbParams1 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                   };
                Params = dbParams1;
                dto.product_type_list = _sql.fn_get_list("fn_producttype", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_producttype", Params);
            }
            
            try
            {
                var dbParams2 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                   };
                Params = dbParams2;
                dto.brand_list = _sql.fn_get_list("fn_get_brand", dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_brand", Params);
            }

            // Uom
            try
            {
                var dbParams3 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                   };
                Params = dbParams3;
                dto.uom_list = _sql.fn_get_list("fn_get_uom", dbParams3);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_uom", Params);
            }

            return dto;
        }
        public Master_ProductDTO get_sub_category(Master_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AddProduct/get_sub_category";
            if (dto.category_id == 0 || dto.category_id == null)
            {
                dto.msg_flg = "Failed";
                dto.message = "Please Select Category Name";
                return dto;
            }
            try
            {
                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_mc_id", dto.category_id),
                    };
                Params = dbParams;
                dto.sub_category_list = _sql.fn_get_list("fn_get_subcategory_dd", dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_sub_category", Params);
            }
            finally
            {

            }
            return dto;
        }
        public Master_ProductDTO get_spl_category(Master_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AddProduct/get_spl_category";

            if (dto.sub_category_id == 0 || dto.sub_category_id == null)
            {
                dto.status = "Failed";
                dto.message = "Please Select Sub Category Name";
                return dto;
            }
            try
            {
                var dbParams = new DbParameter[]
                 {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_msc_id", dto.sub_category_id),
                 };
                Params = dbParams;
                dto.additional_category_list = _sql.fn_get_list("fn_get_additional_category_dd", dbParams);
            }
            catch (Exception ex)
            {

                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_additional_category", Params);

            }
            return dto;
        }
        public Master_ProductDTO Save_Product(Master_ProductDTO dto)
        {
            List<string> ret_validation = new List<string>();
              
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AddProduct/Save_Product";
            _error.audit_log_txr(dto.user_id, methodname, page_form);
            if (dto.category_id == 0)
            {
                ret_validation.Add("Please Select Category");

            }


            if (dto.sub_category_id == 0)
            {
                ret_validation.Add("Please Select Sub Category");
                
            }
            if (dto.additional_cat_id == 0)
            {
                ret_validation.Add("Please Select Additional-Category");
               
            }
            if (dto.product_type_id == 0)
            {
                ret_validation.Add("Please Select Product Type");
               
            }
            if (dto.product_name.Trim() == "" || dto.product_name.Trim() == null )
            {
                ret_validation.Add("Please Enter Product Name");
                
            }
            string nameRegex = @"^[a-zA-Z\s]+$";
            Regex nre = new Regex(nameRegex);
            if (!nre.IsMatch(dto.product_name.ToString()))
            {
                ret_validation.Add("Product Name is invalid!");
            }
            if (dto.base_price == 0)
            {
                ret_validation.Add("Please Enter Base Price");
                
            }
            if (dto.hsn_code.Trim() == "" || dto.hsn_code.Trim() == null)
            {
                ret_validation.Add("Please Enter HSN Code");
                
            }

            if (dto.ian_code.Trim() == "" || dto.ian_code.Trim() == null)
            {
                ret_validation.Add("Please Enter IAN Code");
               
            }
            if (dto.uom_id == 0)
            {
                ret_validation.Add("Please Set Product Unit");
               
            }
            if (dto.image_path == "" || dto.image_path == null)
            {
                ret_validation.Add("Please Select Product Image");
               
            }
            if (dto.short_description.Trim() == "" || dto.short_description.Trim() == null)
            {
                ret_validation.Add("Please Write Product Short Description");
               
            }
            string shortregex = @"^[a-zA-Z0-9\s]+$";
            Regex desc = new Regex(shortregex);
            if (!desc.IsMatch(dto.short_description.ToString()))
            {
                ret_validation.Add("short_description is invalid!");
            }
            
            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }
            dto.product_code = dto.product_name;
            string s = dto.product_code;
            bool fHasSpace = s.Contains(" ");
            if (fHasSpace == true)
            {
                dto.product_code = (dto.product_code).ToString().Trim().Replace(" ", "-");
                var checkslug = _context.Master_Product_con.Where(a => a.product_code == dto.product_code).ToList();
                if (checkslug.Count > 0)
                {
                    Random rnd = new Random();
                    int rndnum = rnd.Next(1, 100);
                    dto.product_code = dto.product_code + "-" + rndnum;
                }
                else
                {

                }


            }
            else
            {

            }

            bool check_dup = false;
            check_dup = _duplicate.check_product(dto);
            if (!check_dup)
            {
                try
                {
                    _inter.Save_Product(dto);
                }
                catch (Exception ex)
                {
                    _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
                }
            }
            else
            {
                dto.status = "Failed";
                dto.message = "Product Already Exist";
            }

            return dto;
        }




        //Product Question Set For vendor
        public Master_ProductDTO get_questionsetdata(Master_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AddProduct/get_questionsetdata";
                     // get product
            try
            {
                var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                    };
                Params = dbParams;
                dto.productlist = _sql.fn_get_list("fn_get_product", dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_product", Params);
            }
            // master specification
            try
            {
                var dbParams1 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
                   };
                Params = dbParams1;
                dto.specificationlist = _sql.fn_get_list("fn_get_masterspecification", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masterspecification", Params);
            }

            try
            {
                // master specification
                var dbParams2 = new DbParameter[]
                       {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
                       };
                Params = dbParams2;
                dto.masterproductspeclist = _sql.fn_get_list("fn_get_masterproductspecification", dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masterproductspecification", Params);
            }

            return dto;
        }
        public Master_ProductDTO getproductattributelist(Master_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AddProduct/getproductattributelist";
        
            try
            {
                var dbParams2 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                      DbHelper.CreateParameter("in_productid", dto.product_id)
                   };
                Params = dbParams2;
                dto.productattributelist = _sql.fn_get_list("fn_get_productattribute", dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_productattribute", Params);
            }
            return dto;
        }
        public Master_ProductDTO edit_getproductattributelist(Master_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AddProduct/getproductattributelist";

            try
            {
                var dbParams2 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                      DbHelper.CreateParameter("in_productid", dto.product_id)
                   };
                Params = dbParams2;
                dto.productattributelist = _sql.fn_get_list("fn_get_edit_productattribute", dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_productattribute", Params);
            }
            return dto;
        }
        public Master_ProductDTO saveproductspecification(Master_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AddProduct/saveproductspecification";
            _error.audit_log_txr(dto.user_id, methodname, page_form);
     

            if (dto.specification_id == 0)
            {
                dto.status = "Please Select Specification";
                return dto;
            }
            if (dto.attribute_name_id == 0)
            {
                dto.status = "Please Select Attribute Name";
                return dto;
            }
            if (dto.product_specid > 0)
            {
                var result = _context.Specification_for_VendorDMO_con.Where(a => a.product_id == dto.product_id && a.specification_id == dto.specification_id && a.attribute_name_id == dto.attribute_name_id && a.product_specid!=dto.product_specid).ToList();
                if (result.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "Data Already Exist";
                    return dto;
                }
            }
            else
            {
                var result = _context.Specification_for_VendorDMO_con.Where(a => a.product_id == dto.product_id && a.specification_id == dto.specification_id && a.attribute_name_id == dto.attribute_name_id ).ToList();
                if (result.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "Data Already Exist";
                    return dto;
                }
            }
           
                try
                {
                    _inter.saveproductspecification(dto);
                }


                catch (Exception ex)
                {
                    _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
                }
            
            try
            {
                var dbParams1 = new DbParameter[]
                  {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id)
                  };
                Params = dbParams1;
                dto.masterproductspeclist = _sql.fn_get_list("fn_get_masterproductspecification", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masterproductspecification", Params);
            }
            return dto;
        }
        public Master_ProductDTO deletemasterproductspecification(Master_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AddProduct/deletemasterproductspecification";
            _error.audit_log_txr(dto.user_id, methodname, page_form);
            try
            {
                _inter.deletemasterproductspecification(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }

            try
            {
                var dbParams = new DbParameter[]
                {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id)
                };
                Params = dbParams;
                dto.masterproductspeclist = _sql.fn_get_list("fn_get_masterproductspecification", dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masterproductspecification", Params);
            }
            finally
            {

            }
            return dto;
        }
    }
}
