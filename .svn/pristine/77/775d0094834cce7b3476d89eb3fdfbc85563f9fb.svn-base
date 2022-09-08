using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service
{
    public class Vendortohub: IVendortohub
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        IVendortohub_Repository _inter;
        public Vendortohub(IVendortohub_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }

    
    }
}
