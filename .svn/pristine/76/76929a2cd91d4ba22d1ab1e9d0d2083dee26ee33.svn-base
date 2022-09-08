using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.EMarket_Repository.Admin;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class Map_Category_Specification: IMap_Category_Specification
    {
        Map_Category_Specification_Repository _inter;
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        public Map_Category_Specification(IMap_Category_Specification_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = (Map_Category_Specification_Repository)inter;
            _context = context;
            _sql = sql;
            _error = error;

        }
        public Map_Category_SpecificationDTO getdata(Map_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/getdata";
            //additionalcategorylist
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                };
                Params = dbParams1;
                dto.procedure_name = "fn_get_additional_category";
                dto.additionalcategorylist = _sql.Get_Data(dto.procedure_name, dbParams1);
           
            //mapped category specification
           
                var dbParams2 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id)
                };
                Params = dbParams2;
                dto.procedure_name = "fn_get_mappedcategoryspecification";
                dto.mastercatspeclist = _sql.Get_Data(dto.procedure_name, dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Map_Category_SpecificationDTO savemappedspecification(Map_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/savemappedspecification";
            if (dto.additional_cat_id == 0)
            {
                dto.messageflg = "Please Select Category";
                return dto;
            }
            if (dto.specification_id == 0)
            {
                dto.messageflg = "Please Select Specification";
                return dto;
            }
            //master specification list
            try
            {
                _inter.savemappedspecification(dto);

                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id)
                };
                Params = dbParams1;
                dto.mastercatspeclist = _sql.Get_Data("fn_get_mappedcategoryspecification", dbParams1);

             
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_mappedcategoryspecification", Params);
            }
            //category specification
            try
            {
                var dbParams2 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_additionalcat_id", dto.additional_cat_id),
                    DbHelper.CreateParameter("in_languageid", dto.language_id),
                    DbHelper.CreateParameter("in_flg", dto.flag)
                };
                Params = dbParams2;
                dto.specificationlist = _sql.fn_get_list("fn_get_catspecification", dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_catspecification", Params);  
            }
            return dto;
        }
        public Map_Category_SpecificationDTO getspecification(Map_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/getspecification";
            //mastercatspeclist
            try
            {
                var dbParams1= new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id)
                };
                Params = dbParams1;
                dto.mastercatspeclist = _sql.Get_Data("fn_get_mappedcategoryspecification", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_mappedcategoryspecification", Params);
            }
            //category specification
            try
            {
                var dbParams2 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_additionalcat_id", dto.additional_cat_id),
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_flg", dto.flag)
                };
                Params = dbParams2;
                dto.specificationlist = _sql.fn_get_list("fn_get_catspecification", dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_catspecification", Params);
            }
            return _inter.getspecification(dto);
        }
        public Map_Category_SpecificationDTO deletecatspecification(Map_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/deletecatspecification";
            if (dto.cat_spe_map_id == 0)
            {
                dto.messageflg = "Please Select Category Specification";
                return dto;
            }
            try
            {
                _inter.deletecatspecification(dto);
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id)
                };
                Params = dbParams1;
                dto.mastercatspeclist = _sql.Get_Data("fn_get_mappedcategoryspecification", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_mappedcategoryspecification", Params);
            }
            return dto;
        }

        public Map_Category_SpecificationDTO getspecattribute(Map_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/getspecattribute";
            //specificationlist1
            try
            {
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_languageid", dto.language_id)
                };
                Params = dbParams1;
                dto.specificationlist1 = _sql.fn_get_list("fn_get_masterspecification", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masterspecification", Params);
            }
            //master spec attrlist
            try
            {
                var dbParams2 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                };
                Params = dbParams2;
                dto.masterspecattrlist = _sql.fn_get_list("fn_get_mappedspecificationattribute", dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_mappedspecificationattribute", Params);
            }
            return _inter.getspecattribute(dto);
        }
        public Map_Category_SpecificationDTO getattributelist(Map_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/getattributelist";
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                    DbHelper.CreateParameter("in_languageid", dto.language_id),
                    DbHelper.CreateParameter("in_flg", dto.flag)
                };
                Params = dbParams1;
                dto.attspecificationlist = _sql.fn_get_list("fn_get_specattribute", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_specattribute", Params);
            }

            try
            {
                var dbParams2 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id)
                };
                Params = dbParams2;
                dto.masterspecattrlist = _sql.fn_get_list("fn_get_mappedspecificationattribute", dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_mappedspecificationattribute", Params);
            }
            return _inter.getattributelist(dto);
        }
        public Map_Category_SpecificationDTO savemappedattribuename(Map_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/savemappedattribuename";
            if (dto.specification_id == 0)
            {
                dto.messageflg = "Please Select Specification";
                return dto;
            }
            if (dto.attribute_name_id == 0)
            {
                dto.messageflg = "Please Select Attribute Name";
                return dto;
            }
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                };
                Params = dbParams1;
                dto.masterspecattrlist = _sql.fn_get_list("fn_get_mappedspecificationattribute", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_mappedspecificationattribute", Params);
            }

            try
            {
                var dbParams2 = new DbParameter[]
                {
                   DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                   DbHelper.CreateParameter("in_languageid", dto.language_id)
                };
                Params = dbParams2;
                dto.attspecificationlist = _sql.fn_get_list("fn_get_specattribute",dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_specattribute", Params);
            }
            return _inter.savemappedattribuename(dto);
        }
        public Map_Category_SpecificationDTO deletespecattribute(Map_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/deletespecattribute";
            if (dto.spe_attr_id == 0)
            {
                dto.messageflg = "Please Select  Specification Attribute";
                return dto;
            }
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id)
                };
                Params = dbParams1;
                dto.masterspecattrlist = _sql.fn_get_list("fn_get_mappedspecificationattribute", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_mappedcategoryspecification", Params);
            }
            return _inter.deletespecattribute(dto);
        }
    }
}
