using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Text;
using System.Linq;
using EMarketDTO.Admin;

namespace EMarket.DLL.EMarket_Repository.Admin
{
    public class Map_Category_Specification_Repository: IMap_Category_Specification_Repository
    {
        int status = 0;
        bool saved = true;
        PostgreSqlContext _context;
        IDbHelper dbHelper;
        comman_class cmm = new comman_class();
        ISql_Layer _sql;
        IError_Log _error;
        public Map_Category_Specification_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
        }
       
        public Map_Category_SpecificationDTO savemappedspecification(Map_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/savemappedspecification";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                var dbParams = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_catspecid", dto.cat_spe_map_id),
                    DbHelper.CreateParameter("in_additionalcatid", dto.additional_cat_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                    DbHelper.CreateParameter("in_languageid", dto.language_id),
                    DbHelper.CreateParameter("in_userid", dto.userid)
                };
                var spName = "call sp_save_mappedcategoryspecification(:in_catspecid,:in_additionalcatid,:in_specificationid,:in_languageid,:in_userid)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.msg_flg = "Update";
                }
                else
                {
                    dto.msg_flg = "Failed";
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "sp_save_mappedcategoryspecification",Params);
            }             
           return dto;
        }
        public Map_Category_SpecificationDTO getspecification(Map_Category_SpecificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/getspecification";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            return dto;
        }
        public Map_Category_SpecificationDTO deletecatspecification(Map_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/deletecatspecification";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);        
            try
            {
                var dbParams = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_catspecid", dto.cat_spe_map_id),
                    DbHelper.CreateParameter("in_languageid", dto.language_id)
                };
                var spName = "call sp_delete_mappedcategotyspecification(:in_catspecid, :in_languageid)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.msg_flg = "Delete";
                }
                else
                {
                    dto.msg_flg = "Failed";
                }
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "sp_delete_mappedcategotyspecification", Params);
            }
            return dto;
        }
        public Map_Category_SpecificationDTO getspecattribute(Map_Category_SpecificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/getspecattribute";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            return dto;
        }
        public Map_Category_SpecificationDTO getattributelist(Map_Category_SpecificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/getattributelist";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            return dto;
        }
        public Map_Category_SpecificationDTO savemappedattribuename(Map_Category_SpecificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Category_Specification/savemappedattribuename";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                var dbParams = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_specattrid", dto.spe_attr_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                    DbHelper.CreateParameter("in_attribtenameid", dto.attribute_name_id),
                    DbHelper.CreateParameter("in_lanuageid", dto.language_id)
                };
                var spName = "call sp_save_mappedspecificationattribute(:in_specattrid, :in_specificationid,:in_attribtenameid,:in_lanuageid)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.msg_flg = "Update";
                }
                else
                {
                    dto.msg_flg = "Failed";
                }

            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.userid);
            }
            return dto;
        }
        public Map_Category_SpecificationDTO deletespecattribute(Map_Category_SpecificationDTO dto)
        {
          IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
           try
           {
            var dbParams = new DbParameter[]
            {
                DbHelper.CreateParameter("in_specattrid", dto.spe_attr_id),
                DbHelper.CreateParameter("in_languageid", dto.language_id)
            };
            var spName = "call sp_delete_mappedspecificationattribute(:in_specattrid, :in_languageid)";
            status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
            if (status == -1)
            {
                dto.msg_flg = "Delete";
            }
            else
            {
                dto.msg_flg = "Failed";
            }

            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.userid);
            }    
            return dto;
        }
    }
}
