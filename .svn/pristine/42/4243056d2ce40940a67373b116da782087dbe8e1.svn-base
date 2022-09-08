using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarketDTO.Customer;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Customer
{
    public class Landing_Item_Details_Repository : ILanding_Item_Details_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class conn = new comman_class();
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        int return_int = 0;
        List<string> invalue = new List<string>();
        public Landing_Item_Details_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
    
        public Landing_Item_DetailsDTO add_to_cart(Landing_Item_DetailsDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Item_Details_Repository/add_to_cart";


            var dbParams = new DbParameter[]
        {
                    DbHelper.CreateParameter("in_user_id",dto.user_id),
                     DbHelper.CreateParameter("in_customer_id", dto.customer_id),
                    DbHelper.CreateParameter("in_product_id",dto.product_id),
                    DbHelper.CreateParameter("item_id",dto.item_id),
                    DbHelper.CreateParameter("session_cart",dto.session_cart),
                   
           };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }

            var spName = "call sp_add_to_cart(:in_user_id, :in_customer_id,:in_product_id,:item_id,:session_cart)";
            return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);

           
                if (return_int == -1)
                {
                    dto.msg_flg = "Insert";
                    dto.message = "Item Added To cart";

                }
                else
                {
                    dto.msg_flg = "Failed";
                    dto.message = "Somthing Wrong! Try Again";
                }
            
            return dto;
        }
    }
}
