using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarketDTO.Customer;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Customer
{
    public class Customer_Order_Track_Repository: ICustomer_Order_Track_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        int return_int = 0;
        long return_long = 0;
        string return_string = "";
        int status = 0;

        public Customer_Order_Track_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
      

   


    }
}
