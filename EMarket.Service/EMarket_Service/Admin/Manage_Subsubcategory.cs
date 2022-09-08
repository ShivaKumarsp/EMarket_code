using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class Manage_Subsubcategory : IManage_Subsubcategory
    {
        IManage_Subsubcategory_Repository _inter;

        int status = 0;
        bool saved = true;
        PostgreSqlContext _context;
        Db_Connection conn = new Db_Connection();
        ISqlClass _sql;
        IErrorClass _error;
        public Manage_Subsubcategory(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IManage_Subsubcategory_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public Manage_SubsubcategoryDTO getdata(Manage_SubsubcategoryDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Manage_Subsubcategory/getdata";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            try
            {
                var catlistdd = _context.Master_CategoryDMO_con.Where(a => a.language_id == dto.language_id).ToList();
                dto.category_dd = Newtonsoft.Json.JsonConvert.SerializeObject(catlistdd);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_sub_category", Params);
            }


            try
            {
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                };
                Params = dbParams1;
                dto.subsubcatlist_grid = _sql.Get_Data("fn_get_subsubcategory_list", dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_sub_category", Params);
            }


            return dto;
        }
        public Manage_SubsubcategoryDTO get_add_category(Manage_SubsubcategoryDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Manage_Subsubcategory/getdata";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            try
            {
                var dbParams = new DbParameter[]
                     {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_mc_id", dto.mc_id),
                     };
                Params = dbParams;
                dto.subcatlist_dd = _sql.Get_Data("fn_get_subcategory_dd", dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_sub_category", Params);
            }
            return dto;
        }
        public Manage_SubsubcategoryDTO savemanagesubcat(Manage_SubsubcategoryDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Manage_Subsubcategory/savemanagesubcat";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            if (dto.msc_id == 0)
            {
                dto.msg_flg = "Please Select Sub_Category";
                return dto;
            }
            if (dto.additional_cat_name == "" || dto.additional_cat_name == null)
            {
                dto.msg_flg = "Please Enter Additional Category Name";
                return dto;
            }
            
            try
            {

                dto.additional_cat_code = dto.additional_cat_name;
                string s = dto.additional_cat_code;
                bool fHasSpace = s.Contains(" ");
                if (fHasSpace == true)
                {
                    dto.additional_cat_code = (dto.additional_cat_code).ToString().Trim().Replace(" ", "-");
                    var checkslug = _context.Additional_Cat_con.Where(a => a.additional_cat_code == dto.additional_cat_code).ToList();
                    if (checkslug.Count > 0)
                    {
                        Random rnd = new Random();
                        int rndnum = rnd.Next(1, 100);
                        dto.additional_cat_code = dto.additional_cat_code + "-" + rndnum;
                    }
                    else
                    {

                    }


                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "linq", page_form);

            }

            try
            {
                _inter.savemanagesubcat(dto);
                var dbParams = new DbParameter[]
                          {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_mc_id", dto.mc_id),
                          };
                Params = dbParams;
                dto.subcatlist_dd = _sql.Get_Data("fn_get_subcategory_dd", dbParams);

                var dbParams1 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
              };
                Params = dbParams1;
                dto.subsubcatlist_grid = _sql.Get_Data("fn_get_subsubcategory_list", dbParams1);

            }
             
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "linq", page_form);
            }
            finally
            {

            }


            return dto;
        }
        public Manage_SubsubcategoryDTO deletemanagesubcat(Manage_SubsubcategoryDTO dto)
        {

            var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_mc_id", dto.mc_id),
                    };
       
            dto.subcatlist_dd = _sql.Get_Data("fn_get_subcategory_dd", dbParams);

            var dbParams1 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
              };
           
            dto.subsubcatlist_grid = _sql.Get_Data("fn_get_subsubcategory_list", dbParams1);

            return _inter.deletemanagesubcat(dto);
        }
        public Manage_SubsubcategoryDTO savemastercategory(Manage_SubsubcategoryDTO dto)
        {
            return _inter.savemastercategory(dto);
        }
    }
}
