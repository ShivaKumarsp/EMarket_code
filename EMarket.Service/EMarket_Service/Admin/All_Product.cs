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
using System.Text;
using System.Linq;
using EMarket.BLL.Comman_Class.Interface;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class All_Product : IAll_Product
    {
        IAll_Product_Repository _inter;    
        IErrorClass _error;
        ISqlClass _sql;
        PostgreSqlContext _context;

        public All_Product(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IAll_Product_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }
        public All_ProductDTO get_data(All_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
                    var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_product_service/get_data";

            try
            {
                var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                   };
                Params = dbParams;
                dto.all_product_list = _sql.Get_Data("fn_get_all_productlist", dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_get_all_productlist", Params);
            }
            finally
            {

            }
            return dto;
        }

        //Edit Product
        public All_ProductDTO get_edit_data(All_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_product_service/get_edit_data";
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
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_get_category", Params);
            }
            try
            {
                // get producttype
                var dbParams1 = new DbParameter[]
                     {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                     };
                Params = dbParams1;
                dto.product_type_list = _sql.fn_get_list("fn_producttype", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_producttype", Params);
            }
            try
            {
                // get brand
                var dbParams2 = new DbParameter[]
                 {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                 };
                Params = dbParams2;
                dto.brand_list = _sql.fn_get_list("fn_get_brand", dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_get_brand", Params);
            }
            try
            {
                // get uom
                var dbParams3 = new DbParameter[]
                 {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                 };
                Params = dbParams3;
                dto.uom_list = _sql.fn_get_list("fn_get_uom", dbParams3);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_get_uom", Params);
            }
            try
            {

                // get single product list
                var dbParams4 = new DbParameter[]
                 {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id)
                 };
                Params = dbParams4;
                dto.single_product_list = _sql.fn_get_list("fn_get_signle_productlist", dbParams4);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_get_signle_productlist", Params);
            }

            finally
            {

            }
            return dto;
        }
        public All_ProductDTO Update_Product(All_ProductDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_product/update_product";

            if (dto != null && !string.IsNullOrEmpty(dto.product_name) && !string.IsNullOrEmpty(dto.product_code) && !string.IsNullOrEmpty(dto.short_description) && !string.IsNullOrEmpty(dto.hsn_code) && !string.IsNullOrEmpty(dto.ian_code) && !string.IsNullOrEmpty(dto.image_path) && dto.category_id == 0 && dto.sub_category_id == 0 && dto.special_category_id == 0 && dto.product_type_id == 0 && dto.brand_id == 0 && dto.uom_id == 0 && dto.uom_size == 0 && dto.uom_weight == 0 && dto.product_weight == 0 && dto.base_price == 0)
            {
                dto.msg_flg = "Failed";
                dto.message = "Please Select/Enter Mandatory Field";
                return dto;
            }
            else
            {
                try
                {
                    _inter.Update_Product(dto);
                }
                catch (Exception ex)
                {
                    _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, dto.procedure_name, dto.inputvalue);
                }
            }

            return dto;
        }

        //Edit Product Specification
        public All_ProductDTO get_specific_edit_data(All_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_product_service/get_specific_edit_data";

            dto.product_name = _context.Master_Product_con.Where(a => a.product_id == dto.product_id && a.language_id == dto.language_id).SingleOrDefault().product_name.TrimEnd();
            try
            {
                // get attribute
                var dbParams = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_languageid", dto.language_id)

                };
                Params = dbParams;
                dto.attribute_value_list = _sql.fn_get_list("fn_attribute_value", dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_attribute_value", Params);

            }
            try
            {
                // get product specification
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id)

                };
                Params = dbParams1;
                dto.product_specification_list = _sql.fn_get_list("fn_get_product_specification", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_get_product_specification", Params);

            }

            return dto;
        }
        public All_ProductDTO update_attribute(All_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_product/update_attribute";
            try
            {
                _inter.update_attribute(dto);
            }

            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, dto.procedure_name, dto.inputvalue);
            }
            try
            {
                var dbParams1 = new DbParameter[]
           {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id)
           };
                Params = dbParams1;
                dto.product_specification_list = _sql.fn_get_list("fn_get_product_specification", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_get_product_specification", Params);
            }
            return dto;
        }


        //Product Question Set For vendor
        public All_ProductDTO get_questionsetdata(All_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_product/get_questionsetdata";

            dto.product_name = _context.Master_Product_con.Where(a => a.product_id == dto.product_id && a.language_id == dto.language_id).SingleOrDefault().product_name.TrimEnd();

            try
            {
                var dbParams = new DbParameter[]
                 {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                 };
                Params = dbParams;
                dto.specificationlist = _sql.fn_get_list("fn_get_masterspecification", dbParams);
            }
            catch(Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_get_masterspecification", Params);
            }

            try { 
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
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_get_masterproductspecification", Params);
            }
            return dto;
        }
        public All_ProductDTO getproductattributelist(All_ProductDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_product_service/getproductattributelist";
            try
            {                var dbParams = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                      DbHelper.CreateParameter("in_productid", dto.product_id),
                };
                Params = dbParams;
                dto.productattributelist = _sql.fn_get_list("fn_get_productattribute", dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, "fn_get_productattribute", Params);
            }
            return dto;
        }
        public All_ProductDTO saveproductspecification(All_ProductDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_product/saveproductspecification";
            try
            {
                _inter.saveproductspecification(dto);
            }
            catch(Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, dto.procedure_name, dto.inputvalue);
            }
            return dto;
        }
        public All_ProductDTO deletemasterproductspecification(All_ProductDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_product/deletemasterproductspecification";
            try
            {
                _inter.deletemasterproductspecification(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, "Web", page_form, dto.procedure_name, dto.inputvalue);
            }
            return dto;
        }

    }
}
