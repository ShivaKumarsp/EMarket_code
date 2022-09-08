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
    public class Customer_List:ICustomer_List
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        int status = 0;
        Db_Connection conn = new Db_Connection();
        public Customer_List(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;

        }
        // Vendor List
        public Customer_ListDTO get_data_vendor(Customer_ListDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_List/get_data_vendor";
            var Params = new DbParameter[] { };
            try
            {
                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)                    
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_vendor_list";
                dto.vendor_list = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Customer_ListDTO view_vendor_store(Customer_ListDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_List/view_vendor_store";
            var Params = new DbParameter[] { };
            try
            {
                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_vendor_store_list";
                dto.vendor_store_list = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }

        // Customer List

        public Customer_ListDTO get_data_customer(Customer_ListDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_List/get_data_customer";
            var Params = new DbParameter[] { };
            try
            {
                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_customer_list";
                dto.customer_list = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
    }
}
