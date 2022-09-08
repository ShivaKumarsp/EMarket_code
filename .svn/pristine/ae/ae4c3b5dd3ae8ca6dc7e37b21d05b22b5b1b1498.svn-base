using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarket.Entities.Customer;
using EMarketDTO.Customer;
using LiteX.DbHelper.Npgsql;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Customer
{
   public  class CartCheckPlaceOrder_Repository: ICartCheckPlaceOrder_Repository
    {

        string key = "rzp_test_seSShIuc8KMAn5";
        string secret = "2UoQ3KDbgeoNO61vX7jVscKZ";
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        ISql_Layer _sql;
        IError_Log _error;
        int status = 0;

        public CartCheckPlaceOrder_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
       

    }
}
