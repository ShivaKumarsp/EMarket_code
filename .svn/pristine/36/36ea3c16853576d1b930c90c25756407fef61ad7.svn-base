
using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarket.Entities.Admin;
using EMarketDTO.Customer;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Customer
{
    public class Landing_Repository : ILanding_Repository
    {

        PostgreSqlContext _context;
        comman_class cmm = new comman_class();
        IComman_Data _cmndata;
        IError_Log _error;
        ISql_Layer _sql;
      
        public Landing_Repository(PostgreSqlContext context, IComman_Data cmndata, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _cmndata = cmndata;
            _sql = sql;
            _error = error;          
    }
    

    }
}
