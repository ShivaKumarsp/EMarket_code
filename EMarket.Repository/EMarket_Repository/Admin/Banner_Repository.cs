using EMarket.DLL.Comman_Data;
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

namespace EMarket.DLL.EMarket_Repository.Admin
{
    public class Banner_Repository: IBanner_Repository
    {
        comman_class conn = new comman_class();
        PostgreSqlContext _context;
        int status = 0;
        public Banner_Repository(PostgreSqlContext context)
        {
            _context = context;
        
        }

        public BannerDTO save_banner(BannerDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var Params = new DbParameter[] { };

            var dbParams = new DbParameter[]
               {
                    DbHelper.CreateParameter("in_banner_id", dto.banner_id),
                    DbHelper.CreateParameter("in_banner_title", dto.banner_title),
                    DbHelper.CreateParameter("in_banner_link", dto.banner_link),
                    DbHelper.CreateParameter("in_banner_details", dto.banner_details),
                    DbHelper.CreateParameter("in_page_id", dto.page_id),
                    DbHelper.CreateParameter("in_banner_image", dto.banner_image),
                    DbHelper.CreateParameter("in_is_active", dto.is_active),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_add_cat_id", dto.add_cat_id),
               };
            Params = dbParams;
            dto.procedure_name = "call sp_save_banner(:in_banner_id, :in_banner_title,:in_banner_link,:in_banner_details,:in_page_id,:in_banner_image,:in_is_active,:in_user_id,:in_language_id,:in_add_cat_id)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
                if (dto.banner_id > 0)
                {
                    dto.status = "Update";
                    dto.message = "Banner Updated Successfully";
                }
                else
                {
                    dto.status = "Insert";
                    dto.message = "Banner Inserted Successfully";
                }

            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed to Banner Inserte/Update";
            }
            return dto;
        }

        public BannerDTO delete_banner(BannerDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Banner/delete_banner";
           
                var dbParams = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_banner_id", dto.banner_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                   };
                Params = dbParams;
                dto.procedure_name = "call sp_delete_banner(:in_banner_id,:in_language_id)";
                status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.status = "Delete";
                    dto.message = "Banner Deleted Successfully";

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Failed to Banner Delete";
                }


            return dto;
        }
    }
}
