using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
   public class Item_Specification_Mapping: IItem_Specification_Mapping
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        IItem_Specification_Mapping_Repository _inter;
        public Item_Specification_Mapping(IItem_Specification_Mapping_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }

        public Item_Specification_MappingDTO deleteitemspecification(Item_Specification_MappingDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Item_Specification_Mapping/deleteitemspecification";
            return _inter.deleteitemspecification(dto);
        }

        public Item_Specification_MappingDTO getattributelist(Item_Specification_MappingDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Item_Specification_Mapping/getattributelist";
            try
            {
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                      DbHelper.CreateParameter("in_additionalcat_id", dto.additional_cat_id),
                      DbHelper.CreateParameter("in_flag", "List"),
                };
                Params = dbParams1;
                dto.attributelist = _sql.fn_get_list("fn_get_attributelist", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_attributelist", Params);
            }

            return dto;
        }

        public Item_Specification_MappingDTO getattribute_edit_list(Item_Specification_MappingDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Item_Specification_Mapping/getattribute_edit_list";
            try
            {
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                      DbHelper.CreateParameter("in_additionalcat_id", dto.additional_cat_id),
                      DbHelper.CreateParameter("in_flag", "List"),
                };
                Params = dbParams1;
                dto.attributelist = _sql.fn_get_list("fn_get_attributenamelist", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_attributenamelist", Params);
            }
            return dto;
        }

        public Item_Specification_MappingDTO getdata(Item_Specification_MappingDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Item_Specification_Mapping/getdata";
            try
            {
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                };
                Params = dbParams1;
                dto.additionalcategorylist = _sql.fn_get_list("fn_get_additional_category", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_category", Params);
            }

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
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masterspecification", Params);
            }

            try
            {
                var ss = 0;
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", ss),
                };
                Params = dbParams1;
                dto.itemcategoryspecificationlist = _sql.fn_get_list("fn_get_masteritemspecificationlist", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masterspecification", Params);
            }
             return dto;
        }

        public Item_Specification_MappingDTO getspecification(Item_Specification_MappingDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Item_Specification_Mapping/getspecification";
            try
            {
                var dbParams = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                };
                Params = dbParams;
                dto.specificationlist = _sql.fn_get_list("fn_get_map_specification_dd", dbParams);

                var dbParams1 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
              };
                Params = dbParams1;
                dto.itemcategoryspecificationlist = _sql.fn_get_list("fn_get_masteritemspecificationlist", dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masteritemspecificationlist", Params);
            }

            return dto;
        }

        public Item_Specification_MappingDTO saveitemspecification(Item_Specification_MappingDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Item_Specification_Mapping/saveitemspecification";
            try
            {
                _inter.saveitemspecification(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masteritemspecificationlist", Params);
            }
            try
            {
                var dbParams = new DbParameter[]
                 {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                 };
                Params = dbParams;
                dto.specificationlist = _sql.fn_get_list("fn_get_map_specification_dd", dbParams);


                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                };
                Params = dbParams1;
                dto.itemcategoryspecificationlist = _sql.fn_get_list("fn_get_masteritemspecificationlist", dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masteritemspecificationlist", Params);
            }
            return dto;
        }
    }
}
