using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Customer;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarketDTO.Customer;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Customer
{
    public class search_result : Isearch_result_service
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Isearch_result_Repository _inter;
        public search_result(Isearch_result_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Search_resultDTO getresult(Search_resultDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "search_result/getresult";
            _error.audit_log_txr(dto.userid, methodname, page_form);

            //search
            try
            {
                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("searchstring",dto.searchstring)
                    };
                Params = dbParams1;
                dto.resultlist = _sql.Get_Data("fn_search", Params);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_search", Params);
            }
            return _inter.getresult(dto);
        }
    }
}
