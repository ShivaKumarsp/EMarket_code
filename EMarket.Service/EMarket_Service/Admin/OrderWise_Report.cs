using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class OrderWise_Report: IOrderWise_Report

    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        int status = 0;
        Db_Connection conn = new Db_Connection();
        public OrderWise_Report(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;

        }

        public OrderWise_ReportDTO get_data(OrderWise_ReportDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "OrderWise_Report/get_data";
            var Params = new DbParameter[] { };
            try
            {
                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_flg", "All"),
                       DbHelper.CreateParameter("in_from_date", dto.from_date),
                        DbHelper.CreateParameter("in_to_date", dto.to_date)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_orderwise_payment_list";
                dto.orderwise_payment_list = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public OrderWise_ReportDTO payment_details(OrderWise_ReportDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "OrderWise_Report/payment_details";
            var Params = new DbParameter[] { };
            try
            {
                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_payment_details";
                dto.payment_details = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        public OrderWise_ReportDTO get_payment_data(OrderWise_ReportDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "OrderWise_Report/get_payment_data";
            var Params = new DbParameter[] { };
            try
            {
                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_flg", "Date"),
                      DbHelper.CreateParameter("in_from_date",dto.from_date),
                        DbHelper.CreateParameter("in_to_date",dto.to_date)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_orderwise_payment_list";
                dto.orderwise_payment_list = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
    }
}
