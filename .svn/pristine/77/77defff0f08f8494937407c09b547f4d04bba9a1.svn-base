using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Vendor
{
    public class Vendor_reassign_Repository: IVendor_reassign_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        int status = 0;
        public Vendor_reassign_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        //get
        public Vendor_reassignDTO get(Vendor_reassignDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_reassign_Repository/get";
            return dto;
        }
        //get item
        public Vendor_reassignDTO getitem(Vendor_reassignDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_reassign_Repository/getitem";
            return dto;
        }

        public Vendor_reassignDTO reassigning(Vendor_reassignDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_reassign_Repository/reassigning";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_quantity",dto.quantity),
                        DbHelper.CreateParameter("in_order_item_id",dto.order_item_id),
                        DbHelper.CreateParameter("in_item_id",dto.item_id),
                        DbHelper.CreateParameter("in_order_accept_status",dto.order_accept_status),
                        DbHelper.CreateParameter("in_order_accept_comment",dto.order_accept_comment),
                    };
                    dto.procedure_name = "call sp_save_reassign_vendor(:in_quantity,:in_order_item_id,:in_item_id,:in_order_accept_status,:in_order_accept_comment)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                    //saved = status == 1;
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
