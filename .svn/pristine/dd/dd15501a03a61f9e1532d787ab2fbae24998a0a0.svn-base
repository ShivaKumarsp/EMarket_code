using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Admin
{
    public class Vendortohub_Repository: IVendortohub_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        int status = 0;
        public Vendortohub_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        //get source hub
        public VendortohubDTO sourcehub(VendortohubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendortohub_Repository/sourcehub";
            return dto;
        }
        //get destination hub
        public VendortohubDTO destinationhub(VendortohubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendortohub_Repository/destinationhub";
            return dto;
        }

        
    }
}
