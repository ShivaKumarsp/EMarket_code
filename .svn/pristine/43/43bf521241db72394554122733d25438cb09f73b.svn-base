using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Master
{
    public class media_Repository: Imedia_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        int status=0;
        public media_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        //view by passing only id
        public mediaDTO view(mediaDTO dto)
        {
            //var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "media/view";
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
        //getmedia
        public mediaDTO get_media(mediaDTO dto)
        {
            //var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "media/get_media";
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
        // get all detail
        public mediaDTO get_allmedia(mediaDTO dto)
        {
            //var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "media/get_allmedia";
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }


        //save
        public mediaDTO save_media(mediaDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "media/save_media";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_media_id", dto.media_id),
                        DbHelper.CreateParameter("in_title",dto.title),
                        DbHelper.CreateParameter("in_media_type",  dto.media_type),
                        DbHelper.CreateParameter("in_media_data",  dto.media_data),
                        DbHelper.CreateParameter("in_created_by",  dto.userid),

                    };
                    dto.procedure_name = "call sp_insert_media(:in_media_id,:in_title,:in_media_type,:in_media_data,:in_created_by)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);

                    if (status == -1)
                    {
                        dto.status = "Insert";
                        dto.messageflg = "Updated Successfully";
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.messageflg = "Update Failed, Please Try Again";
                    }

                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }

        //Delete
        public mediaDTO Delete(mediaDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "media/Delete";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("mediaid", dto.media_id),
                        DbHelper.CreateParameter("createdby", dto.userid),
                        
                    };
                    dto.procedure_name = "call sp_delete_media(:mediaid,:createdby)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);

                    if (status == -1)
                    {
                        dto.status = "Delete";
                        dto.messageflg = "Deleted Successfully";
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.messageflg = "Delete Failed, Please Try Again";
                    }

                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }

    }
}
