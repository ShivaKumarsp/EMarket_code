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
   public class Shopping_Cart_Repository: IShopping_Cart_Repository
    {
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        ISql_Layer _sql;
        IError_Log _error;
        int return_int = 0;
        List<string> invalue = new List<string>();

        public Shopping_Cart_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        

        public Shopping_CartDTO delete_item(Shopping_CartDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Shopping_Cart_Repository/delete_item";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.customer_id = user_list[0].customer_id;

                var dbParams4 = new DbParameter[]
       {
                    DbHelper.CreateParameter("in_user_id",dto.user_id),
                     DbHelper.CreateParameter("in_customer_id", dto.customer_id),
                    DbHelper.CreateParameter("in_product_id",dto.product_id),
                    DbHelper.CreateParameter("in_item_id",dto.item_id),
                    DbHelper.CreateParameter("session_cart",dto.session_cart),

          };
                foreach (var item in dbParams4)
                {
                    invalue.Add(item.ParameterName + ':' + item.Value);
                }

                var spName = "call sp_delete_cart_item(:in_user_id, :in_customer_id,:in_product_id,:in_item_id)";
                return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);


                    if (return_int == -1)
                    {
                        dto.msg_flg = "Success";
                        dto.message = "Item Deteted Successfully";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                        dto.message = "Failed To Delete, Please try Again.";
                    }               

                var dbParams = new DbParameter[]
                 {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_customer_id", user_list[0].customer_id),
                 };
                dto.mycartlist = _sql.fn_get_list("fn_get_cart_item", dbParams);            

            }
            catch (Exception ex)
            {
               // _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form);

            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
            return dto;
        }

    }
}
