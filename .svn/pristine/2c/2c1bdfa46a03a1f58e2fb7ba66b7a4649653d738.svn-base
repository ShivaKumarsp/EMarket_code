using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Customer
{
   public class search_result_Repository : Isearch_result_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        int status = 0;
        public search_result_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
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
            return dto;
        }
    }
}
