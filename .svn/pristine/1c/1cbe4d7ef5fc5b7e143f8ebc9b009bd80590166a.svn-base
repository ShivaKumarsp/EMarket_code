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
    public class AdminDashboard: IAdminDashboard
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        public AdminDashboard(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;         
        }
       public AdminDashboardDTO get_data(AdminDashboardDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AdminDashboard/get_data";
            try
            {// all customer
                var dbParams = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_role", "Customer")             
              };
                Params = dbParams;
                dto.procedure_name = "fn_get_all_user_list";
                dto.user_list = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch(Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
    }
}
