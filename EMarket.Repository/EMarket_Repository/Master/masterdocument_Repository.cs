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
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Master
{
   public class masterdocument_Repository: Imasterdocument_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        int status = 0;
        public masterdocument_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

        public masterdocumentDTO getdata(masterdocumentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "masterdocument_Repository/getdata";
            return dto;
        }
        //save
        public masterdocumentDTO save(masterdocumentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "masterdocument_Repository/save";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_md_id",dto.md_id),
                        DbHelper.CreateParameter("in_md_documentname",dto.md_documentname),
                        DbHelper.CreateParameter("in_md_description",dto.md_description),
                        DbHelper.CreateParameter("in_createdby",dto.userid),
                        DbHelper.CreateParameter("in_language_id",dto.language_id),
                        DbHelper.CreateParameter("in_pattern",dto.pattern),
                        DbHelper.CreateParameter("in_isrequired",dto.isrequired),
                        
                    };
                    dto.procedure_name = "call sp_saveupdate_masterdocuments(:in_md_id,:in_md_documentname,:in_md_description,:in_createdby,:in_language_id,:in_pattern,:in_isrequired)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                    if (status == -1)
                    {
                        dto.msg_flg = "Update";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_save_vendor_document", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }

    }
}
