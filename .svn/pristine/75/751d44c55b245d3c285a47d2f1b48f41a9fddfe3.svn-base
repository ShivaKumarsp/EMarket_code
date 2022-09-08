using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces;
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
    public class Verify_vendor_Profile_Repository : IVerify_vendor_profile_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        int status = 0;
        public Verify_vendor_Profile_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Verify_vendor_profileDTO Getdata(Verify_vendor_profileDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "verify_vendor_profile/Getdata";
            return dto;
        }

        public Verify_vendor_profileDTO VerifyProfile(Verify_vendor_profileDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "verify_vendor_profile/VerifyProfile";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            try
            {

                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_vendor_id",dto.vendor_id),
                        DbHelper.CreateParameter("in_approved_flg",dto.approved_flg),
                        
                    };
                    dto.procedure_name = "call sp_verify_vendor(:in_vendor_id,:in_approved_flg)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                    if (status == -1)
                    {
                        dto.msg_flg = "Save";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_saveupdate_masterhubs", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
    }
}
