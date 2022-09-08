using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarketDTO.Customer;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Linq;
using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;

namespace EMarket.DLL.EMarket_Repository.Customer
{
   public class Items_View_Repository: IItems_View_Repository
    {

        PostgreSqlContext _context;
        comman_class cmm = new comman_class();
        ISql_Layer _sql;
        IError_Log _error;
        public Items_View_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
     

    }
}
