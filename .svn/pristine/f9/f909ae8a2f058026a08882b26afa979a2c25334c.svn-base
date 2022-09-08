using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Admin
{
   public  class Document_verification_Repository: IDocument_verification_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        bool saved = true;
        int affectcount = 0;
        PostgreSqlContext _context;
        int status = 0;
        //List<string> invalue = new List<string>();
        public Document_verification_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
                
        Document_verificationDTO IDocument_verification_Repository.getdocuments(Document_verificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Document_verification/getdocuments";
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }

        Document_verificationDTO IDocument_verification_Repository.save_documents(Document_verificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Document_verification/save_document";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("vdocid", dto.vdoc_id),
                        //dto.vdoc_approveorreject_by
                        DbHelper.CreateParameter("rejectedby",  1),
                        DbHelper.CreateParameter("description",  dto.vdoc_approveorreject_description),
                        DbHelper.CreateParameter("vdocstatus",  dto.vdoc_status),

                    };
                    dto.procedure_name = "call sp_update_documentByadmin(:vdocid,:rejectedby,:description,:vdocstatus)";
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
    }
}
