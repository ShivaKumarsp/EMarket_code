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
    public class ReturnOrderVerify_Repository: IReturnOrderVerify_Repository
    {
        PostgreSqlContext _context;
        comman_class conn = new comman_class();
        int status = 0;
        List<string> invalue = new List<string>();
       
        public ReturnOrderVerify_Repository(PostgreSqlContext context)
        {
            _context = context;
        }
        public ReturnOrderVerifyDTO update_order(ReturnOrderVerifyDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_Route_Repository/delete_hub_route";
            var Params = new DbParameter[] { };

            var dbParams = new DbParameter[]
       {
                    DbHelper.CreateParameter("in_return_item_id", dto.return_item_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_order_id", dto.order_id),
                                       DbHelper.CreateParameter("in_return_request_status", dto.return_request_status),
                    DbHelper.CreateParameter("in_return_request_reasion", dto.return_request_reasion),
       };
            Params = dbParams;
            dto.procedure_name = "call sp_update_return_request_verify(:in_return_item_id,:in_order_item_id,:in_order_id,:in_return_request_status,:in_return_request_reasion)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
                dto.status = "Update";
                dto.message = "Order/Item '" + dto.return_request_status + "' ";
            }
            else
            {
                dto.status = "Failed";
                dto.message = "Order/Item Not Accept/Reject, Please Try Again";
            }

            return dto;
        }
    }
}
