using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Vendor
{
    public class CancelOrderRequest : ICancelOrderRequest
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        int status = 0;
        Db_Connection conn = new Db_Connection();
        public CancelOrderRequest(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;

        }
        public CancelOrderRequestDTO get_data(CancelOrderRequestDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CancelOrderRequest/get_data";
            var Params = new DbParameter[] { };
            try
            {
                dto.vendor_id = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault().vendor_id;

                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "All")
               };
                Params = dbParams; 
                dto.procedure_name = "fn_get_cancel_request_list";
                dto.cancel_request_list = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
           
            return dto;
        }
        public CancelOrderRequestDTO update_order(CancelOrderRequestDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CancelOrderRequest/update_order";
            var Params = new DbParameter[] { };
            try
            {
                dto.vendor_id = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault().vendor_id;
                IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

                var dbParams = new DbParameter[]
     {
                    DbHelper.CreateParameter("in_cancel_item_id", dto.cancel_item_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_order_id", dto.order_id),
                    DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                    DbHelper.CreateParameter("in_cancel_request_status", dto.cancel_request_status),
                    DbHelper.CreateParameter("in_cancel_request_reasion", dto.cancel_request_reasion),
     };
                Params = dbParams;

                dto.procedure_name = "call sp_update_cancel_request(:in_cancel_item_id,:in_order_item_id,:in_order_id,:in_vendor_id,:in_cancel_request_status,:in_cancel_request_reasion)";
                status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.status = "Update";
                    dto.message = "Order/Item '" + dto.cancel_request_status + "' ";
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Order/Item Not Accept/Reject, Please Try Again";
                }





                //get all vendor list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "All")
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_cancel_request_list";
                dto.cancel_request_list = _sql.Get_Data(dto.procedure_name, dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        // Return
        public CancelOrderRequestDTO get_data_return(CancelOrderRequestDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CancelOrderRequest/get_data_return";
            var Params = new DbParameter[] { };
            try
            {
                dto.vendor_id = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault().vendor_id;

                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "All")
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_return_request_list";
                dto.return_request_list = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public CancelOrderRequestDTO update_order_return(CancelOrderRequestDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CancelOrderRequest/update_order_return";
            var Params = new DbParameter[] { };
            try
            {
                dto.vendor_id = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault().vendor_id;
                IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

                var dbParams = new DbParameter[]
     {
                    DbHelper.CreateParameter("in_return_item_id", dto.return_item_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_order_id", dto.order_id),
                    DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                    DbHelper.CreateParameter("in_return_request_status", dto.return_request_status),
                    DbHelper.CreateParameter("in_return_request_reasion", dto.return_request_reasion),
     };
                Params = dbParams;

                dto.procedure_name = "call sp_update_return_request(:in_return_item_id,:in_order_item_id,:in_order_id,:in_vendor_id,:in_return_request_status,:in_return_request_reasion)";
                status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.status = "Update";
                    dto.message = "Order/Item '" + dto.cancel_request_status + "' ";
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Order/Item Not Accept/Reject, Please Try Again";
                }





                //get all vendor list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "All")
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_return_request_list";
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
