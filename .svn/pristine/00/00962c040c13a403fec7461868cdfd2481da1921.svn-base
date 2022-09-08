using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Admin
{
    public class Item_Verification_Repository: IItem_Verification_Repository
    {
        PostgreSqlContext _context;
        comman_class comm = new comman_class();
        ISql_Layer _sql;
        IError_Log _error;
        public Item_Verification_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
         

        public Item_VerificationDTO Upadate_Status(Item_VerificationDTO dto)
        {
            int result;
            IDbHelper _dbHelper = new NpgsqlHelper(comm.ConnectionString);
            var Params = new DbParameter[] { };
            var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_item_id", dto.item_id),
                    DbHelper.CreateParameter("in_verify_status_id", dto.verify_status),
                    DbHelper.CreateParameter("in_remarks", dto.remarks)
                                };
            Params = dbParams;
            //dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(Params);

            dto.procedure_name = "call sp_update_item_verify_status(:in_language_id,:in_item_id,:in_verify_status_id,:in_remarks)";
            result = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);


            if (result == -1)
            {
                dto.status = "Update";
                dto.message = "Item Verified Successfully";
            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed Verify, Please Try Again";
            }
            return dto;
        }
    }
}
