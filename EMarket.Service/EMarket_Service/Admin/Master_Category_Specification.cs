using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.EMarket_Repository.Admin;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class Master_Category_Specification: IMaster_Category_Specification
    {
        Master_Category_Specification_Repository _inter;
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        
        public Master_Category_Specification(IMaster_Category_Specification_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = (Master_Category_Specification_Repository)inter;
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Master_Category_SpecificationDTO getdata(Master_Category_SpecificationDTO dto)
        {
            //IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification/getdata";
            try
            {
                try
                {
                    //aditional category
                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      //DbHelper.CreateParameter("in_msc_id", 17),
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
                    //master attribute
                    var dbParams2 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                    };
                    Params = dbParams2;
                    dto.attributelist = _sql.fn_get_list("fn_get_masterattributename", dbParams2);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_category", Params);
                }
                try
                {
                    var dbParams3 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_additionalcatid", dto.additional_cat_id),
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_flg", dto.flag),
                    };
                    Params = dbParams3;
                    dto.specificationlist = _sql.fn_get_list("fn_get_masterspecificationlist", dbParams3);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_category", Params);
                }
                try
                {
                    var dbParams4 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                    };
                    Params = dbParams4;
                    dto.mastercatspeclist = _sql.fn_get_list("fn_get_mastercategoryspecification", dbParams4);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_category", Params);
                }
            }
            catch(Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_category", Params);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return _inter.getdata(dto);
        }
        public Master_Category_SpecificationDTO savemasterspecification(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification/savemasterspecification";
            if (dto.additional_cat_id == 0)
            {
                dto.msg_flg = "Pleses Select Additional Category";
                return dto;
            }
            if (dto.specification_id == 0)
            {
                dto.msg_flg = "Please Select Specification";
                return dto;
            }
            if (dto.attribute_name_id == 0)
            {
                dto.msg_flg = "Please Select Attribute Name";
                return dto;
            }

            try
            {
                _inter.savemasterspecification(dto);
          
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }

            try
            {
                var dbParams = new DbParameter[]
                 {
                    DbHelper.CreateParameter("in_additionalcatid", dto.additional_cat_id),
                    DbHelper.CreateParameter("in_languageid", dto.language_id),
                    DbHelper.CreateParameter("in_flg", "list")
                    };
                Params = dbParams;
                dto.specificationlist = _sql.fn_get_list("fn_get_masterspecificationlist", dbParams);

                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                };
                Params = dbParams1;
                dto.mastercatspeclist = _sql.fn_get_list("fn_get_mastercategoryspecification", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_mastercategoryspecification", Params);
            }

            return dto;
        }
        public Master_Category_SpecificationDTO deletemasterspecification(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification/deletemasterspecification";
            return _inter.deletemasterspecification(dto);
        }
        public Master_Category_SpecificationDTO getattributelist(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification/getattributelist";
            try
            {
                var dbParams = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_languageid", dto.language_id),
                    DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                    DbHelper.CreateParameter("in_flg", dto.flag),
                    DbHelper.CreateParameter("in_additionalcat_id", dto.additional_cat_id),
                };
                Params = dbParams;
                dto.attributelist = _sql.fn_get_list("fn_get_specattributelist",dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_specattributelist", Params);
            }
            return _inter.getattributelist(dto);
        }
        public Master_Category_SpecificationDTO getspecification(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification/getspecification";
            try
            {
                var dbParams = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_additionalcatid", dto.additional_cat_id),
                    DbHelper.CreateParameter("in_languageid", dto.language_id),
                    DbHelper.CreateParameter("in_flg", dto.flag)
                };
                Params = dbParams;
                dto.specificationlist = _sql.fn_get_list("fn_get_masterspecificationlist", dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_masterspecificationlist", Params);
            }

            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                };
                Params = dbParams1;
                dto.mastercatspeclist = _sql.fn_get_list("fn_get_mastercategoryspecification", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_mastercategoryspecification", Params);
            }
            return _inter.getspecification(dto);
        }
        public Master_Category_SpecificationDTO editmasterspecification(Master_Category_SpecificationDTO dto)
        {
            return _inter.editmasterspecification(dto);
        }
        public Master_Category_SpecificationDTO getattributelist_edit(Master_Category_SpecificationDTO dto)
        {
            return _inter.getattributelist_edit(dto);
        }


        // category variant map

        public Master_Category_SpecificationDTO getvariantdata(Master_Category_SpecificationDTO dto)
        {
            return _inter.getvariantdata(dto);
        }
        public Master_Category_SpecificationDTO save_cat_variant(Master_Category_SpecificationDTO dto)
        {
            return _inter.save_cat_variant(dto);
        }
        public Master_Category_SpecificationDTO get_variant_list(Master_Category_SpecificationDTO dto)
        {
            return _inter.get_variant_list(dto);
        }
        public Master_Category_SpecificationDTO delete_cat_variant(Master_Category_SpecificationDTO dto)
        {
            return _inter.delete_cat_variant(dto);
        }
    }
}
