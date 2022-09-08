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
    public class ReturnOrderVerify: IReturnOrderVerify
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        int status = 0;
        Db_Connection conn = new Db_Connection();
        IReturnOrderVerify_Repository _inter;
        public ReturnOrderVerify(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IReturnOrderVerify_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;

        }
        public ReturnOrderVerifyDTO get_data(ReturnOrderVerifyDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "ReturnOrderVerify/get_data";
            var Params = new DbParameter[] { };
            try
            {


                //get all return list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                       DbHelper.CreateParameter("in_flg", "All")
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_return_request_verify_list";
                dto.return_request_list = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public ReturnOrderVerifyDTO update_order(ReturnOrderVerifyDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "ReturnOrderVerify/update_order";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                _inter.update_order(dto);

                //get all return list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                                            DbHelper.CreateParameter("in_flg", "All")
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_return_request_verify_list";
                dto.return_request_list = _sql.Get_Data(dto.procedure_name, dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
    }
}
