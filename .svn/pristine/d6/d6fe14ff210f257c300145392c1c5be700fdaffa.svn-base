using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Customer;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarketDTO.Customer;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Customer
{
    public class Shopping_Cart_Service : IShopping_Cart_Service
    {
        IShopping_Cart_Repository _inter;
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        int return_int = 0;
        Db_Connection conn = new Db_Connection();

        public Shopping_Cart_Service(PostgreSqlContext context, ISqlClass sql, IErrorClass error,
            IShopping_Cart_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }


        public Shopping_CartDTO get_data(Shopping_CartDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Shopping Cart Service/get_data";

            try
            {
                var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();

                List<long> itemid = new List<long>();
                var cartlist = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.customer_id == user_list[0].customer_id).ToList();

                foreach (var item in cartlist)
                {
                    itemid.Add(item.item_id);
                }

                var allcartlist = (from a in _context.Master_Product_con
                                   from b in _context.Product_ItemDMO_con
                                   where itemid.Contains(b.item_id) && a.product_id == b.product_id
                                   select new Shopping_CartDTO
                                   {
                                       product_name = a.product_name,
                                       product_id = a.product_id,
                                       item_id = b.item_id,
                                       selling_price = b.listing_price,
                                       totquantity = b.min_quantity,
                                       imageurl = a.image_path,
                                   }).Distinct().ToList();

                foreach (var item in allcartlist)
                {
                    if (item.totquantity == 0)
                    {
                        var removecart = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.customer_id == user_list[0].customer_id && a.product_id == item.product_id && a.item_id == item.item_id).SingleOrDefault();
                        _context.Remove(removecart);
                    }

                }
                _context.SaveChanges();
                //===========

                //List<long> item_id1 = new List<long>();
                //var cartlist1 = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.customer_id == dto.customer_id).ToList();

                //foreach (var item in cartlist1)
                //{
                //    item_id1.Add(item.item_id);
                //}

                //dto.mycartlist = (from a in _context.Master_Product_con
                //                  from b in _context.Product_ItemDMO_con
                //                  where item_id1.Contains(b.item_id) && a.product_id == b.product_id
                //                  select new Shopping_CartDTO
                //                  {
                //                      product_name = a.product_name,
                //                      product_id = a.product_id,
                //                      item_id = b.item_id,
                //                      selling_price = b.listing_price,
                //                      totquantity = b.min_quantity,
                //                      imageurl = a.image_path,
                //                  }).Distinct().ToArray();

                //=================
                // get cart item
                var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_customer_id", user_list[0].customer_id),
                   };
                Params = dbParams;
                dto.procedure_name = "fn_get_cart_item";
                dto.mycartlist = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get hub list 1
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams4);

                 //get cal hub list 
                var dbParams5 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                 };
                Params = dbParams5;
                dto.procedure_name = "fn_get_calculate_hub_route";
                dto.hub_route_list = _sql.Get_Data(dto.procedure_name, dbParams5);



            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Shopping_CartDTO delete_item(Shopping_CartDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Profile_Service/Upadate_Customer_Details";
            var Params = new DbParameter[] { };

            try
            {
                _inter.delete_item(dto);
            }
            catch(Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
            return dto;
        }
        public Shopping_CartDTO checkout_qty_update(Shopping_CartDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Shopping Cart Service/checkout_qty_update";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;
                foreach (var item in dto.ordercartlist)
                {
                    var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_product_id", dto.product_id),
                    DbHelper.CreateParameter("in_item_id", dto.item_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_customer_id", dto.customer_id),
                    DbHelper.CreateParameter("in_quantity", item.quantity),

                    };
                    Params = dbParams;
                    var spName = "call sp_update_to_cartcheckout(:in_product_id, :in_item_id,:in_user_id,:in_customer_id,:in_quantity)";
                    return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                }
                if (return_int == -1)
                {
                    dto.msg_flg = "Insert";

                }
                else
                {
                    dto.msg_flg = "Failed";

                }


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        // Direct Checkout
        public Shopping_CartDTO single_checkout(Shopping_CartDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Shopping Cart Service/single_checkout";

            try
            {
                var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();

               
                // get cart item
                var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_customer_id", user_list[0].customer_id),
                   };
                Params = dbParams;
                dto.procedure_name = "fn_get_singlecart_item";
                dto.mycartlist = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get hub list 1
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams4);

                //get cal hub list 
                var dbParams5 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                 };
                Params = dbParams5;
                dto.procedure_name = "fn_get_calculate_hub_route";
                dto.hub_route_list = _sql.Get_Data(dto.procedure_name, dbParams5);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Shopping_CartDTO single_checkout_qty_update(Shopping_CartDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Shopping Cart Service/single_checkout_qty_update";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;

                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_product_id", dto.product_id),
                    DbHelper.CreateParameter("in_item_id", dto.item_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_customer_id", dto.customer_id),
                    DbHelper.CreateParameter("in_quantity", dto.quantity),

                    };
                Params = dbParams;
                var spName = "call sp_update_to_singlecheckout(:in_product_id, :in_item_id,:in_user_id,:in_customer_id,:in_quantity)";
                return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);

                if (return_int == -1)
                {
                    dto.msg_flg = "Insert";

                }
                else
                {
                    dto.msg_flg = "Failed";

                }


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }


        // public  Checkout
        public Shopping_CartDTO public_checkout(Shopping_CartDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Shopping Cart Service/public_checkout";

            try
            {
                var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();


                // get cart item
                var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_session_cart", dto.session_cart)
                   };
                Params = dbParams;
                dto.procedure_name = "fn_get_session_cart_item";
                dto.mycartlist = _sql.fn_get_list(dto.procedure_name, dbParams);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Shopping_CartDTO public_checkout_qty_update(Shopping_CartDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Shopping Cart Service/public_checkout_qty_update";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {

                foreach (var item in dto.ordercartlist)
                {
                    var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_product_id", item.productid),
                    DbHelper.CreateParameter("in_item_id", item.itemid),
                    DbHelper.CreateParameter("in_quantity", item.quantity),
                    DbHelper.CreateParameter("in_session_cart", dto.session_cart),

                    };
                    Params = dbParams;
                    var spName = "call sp_update_to_publiccheckout(:in_product_id, :in_item_id,:in_quantity,:in_session_cart)";
                    return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                }
                if (return_int == -1)
                {
                    dto.msg_flg = "Insert";

                }
                else
                {
                    dto.msg_flg = "Failed";

                }


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Shopping_CartDTO public_delete_item(Shopping_CartDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Shopping Cart Service/public_delete_item";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var dbParams2 = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_product_id", dto.product_id),
                    DbHelper.CreateParameter("in_item_id", dto.item_id),
                    DbHelper.CreateParameter("in_session_cart", dto.session_cart),

                    };
                    Params = dbParams2;
                    var spName = "call sp_delete_public_cart_item(:in_product_id, :in_item_id,:in_session_cart)";
                    return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams2);
                
                if (return_int == -1)
                {
                    dto.msg_flg = "Insert";

                }
                else

                {
                    dto.msg_flg = "Failed";

                }

                // get cart item
                var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_session_cart", dto.session_cart)
                   };
                Params = dbParams;
                dto.procedure_name = "fn_get_session_cart_item";
                dto.mycartlist = _sql.fn_get_list(dto.procedure_name, dbParams);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }

        // public  direct Checkout
        public Shopping_CartDTO public_direct_checkout(Shopping_CartDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Shopping Cart Service/public_direct_checkout";

            try
            {
              
                // get cart item
                var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_session_cart", dto.session_cart)
                   };
                Params = dbParams;
                dto.procedure_name = "fn_get_session_direct_cart_item";
                dto.mycartlist = _sql.fn_get_list(dto.procedure_name, dbParams);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Shopping_CartDTO public_direct_checkout_qty_update(Shopping_CartDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Shopping Cart Service/public_checkout_qty_update";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {

                foreach (var item in dto.ordercartlist)
                {
                    var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_product_id", item.productid),
                    DbHelper.CreateParameter("in_item_id", item.itemid),
                    DbHelper.CreateParameter("in_quantity", item.quantity),
                    DbHelper.CreateParameter("in_session_cart", dto.session_cart),

                    };
                    Params = dbParams;
                    var spName = "call sp_update_to_publiccheckout(:in_product_id, :in_item_id,:in_quantity,:in_session_cart)";
                    return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                }
                if (return_int == -1)
                {
                    dto.msg_flg = "Insert";

                }
                else
                {
                    dto.msg_flg = "Failed";

                }


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
    }
}
