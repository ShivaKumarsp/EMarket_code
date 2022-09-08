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
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
   public class CancelOrderVerify: ICancelOrderVerify
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        int status = 0;
        Db_Connection conn = new Db_Connection();
        ICancelOrderVerify_Repository _inter;
        public CancelOrderVerify(PostgreSqlContext context, ISqlClass sql, IErrorClass error, ICancelOrderVerify_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;

        }
        public CancelOrderVerifyDTO get_data(CancelOrderVerifyDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CancelOrderVerify/get_data";
            var Params = new DbParameter[] { };
            try
            {
              

                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),                     
                       DbHelper.CreateParameter("in_flg", "All")
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_cancel_request_verify_list";
                dto.cancel_request_list = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public CancelOrderVerifyDTO update_order(CancelOrderVerifyDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CancelOrderVerify/update_order";
            var Params = new DbParameter[] { };
            try
            {
                _inter.update_order(dto);
                //get all vendor list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                                            DbHelper.CreateParameter("in_flg", "All")
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_cancel_request_verify_list";
                dto.cancel_request_list = _sql.Get_Data(dto.procedure_name, dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
    }
}
