using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
   public class Banner: IBanner
    {        
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        int status = 0;
        IBanner_Repository _inter;
        public Banner( PostgreSqlContext context, ISqlClass sql, IErrorClass error, IBanner_Repository inter)
        {
            _inter = inter;
               _context = context;
            _sql = sql;
            _error = error;
         
        }
        public BannerDTO get_data(BannerDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Banner/get_data";

            try
            {
                var dbParams = new DbParameter[]
                       {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                       };
                Params = dbParams;
                dto.procedure_name = "fn_get_banner_list";
                dto.banner_list = _sql.Get_Data(dto.procedure_name, dbParams);

                var dbParams1 = new DbParameter[]
                      {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      };
                Params = dbParams1;
                dto.procedure_name = "fn_get_page_list";
                dto.page_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                var dbParams3 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                   };
                Params = dbParams3;
                dto.procedure_name = "fn_get_banner_category";
                dto.category_list = _sql.Get_Data(dto.procedure_name, dbParams3);
            }
            catch(Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public BannerDTO save_banner(BannerDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Banner/save_banner";
            try
            {
                _inter.save_banner(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            try
            {

                var dbParams1 = new DbParameter[]
                       {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                       };
                Params = dbParams1;
                dto.procedure_name = "fn_get_banner_list";
                dto.banner_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                var dbParams2 = new DbParameter[]
                      {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      };
                Params = dbParams2;
                dto.procedure_name = "fn_get_page_list";
                dto.page_list = _sql.Get_Data(dto.procedure_name, dbParams2);

                var dbParams3 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                   };
                Params = dbParams3;
                dto.procedure_name = "fn_get_banner_category";
                dto.category_list = _sql.Get_Data(dto.procedure_name, dbParams3);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public BannerDTO delete_banner(BannerDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Banner/delete_banner";
            try
            {
                _inter.delete_banner(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            try
            {
                

                var dbParams1 = new DbParameter[]
                       {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                       };
                Params = dbParams1;
                dto.procedure_name = "fn_get_banner_list";
                dto.banner_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                var dbParams2 = new DbParameter[]
                      {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      };
                Params = dbParams2;
                dto.procedure_name = "fn_get_page_list";
                dto.page_list = _sql.Get_Data(dto.procedure_name, dbParams2);

                var dbParams3 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                    };
                Params = dbParams3;
                dto.procedure_name = "fn_get_banner_category";
                dto.category_list = _sql.Get_Data(dto.procedure_name, dbParams3);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
    }
}
