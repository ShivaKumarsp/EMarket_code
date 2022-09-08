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
    public class CartCheckout_Repository : ICartCheckout_Repository
    {
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        List<string> invalue = new List<string>();
        int status = 0;
        comman_class conn = new comman_class();
        public CartCheckout_Repository(PostgreSqlContext context)
        {
            _context = context;
          
        }
       
        public CartCheckoutDTO save_shipping_address(CartCheckoutDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CartCheckout_Service/save_shipping_address";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
              

                var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.customer_id = user_list[0].customer_id;

                var dbParams = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_shippingaddress_id",dto.shippingaddress_id),
                     DbHelper.CreateParameter("in_name", dto.name),
                    DbHelper.CreateParameter("in_email",dto.email),
                    DbHelper.CreateParameter("in_user_id",dto.user_id),
                    DbHelper.CreateParameter("in_mobile",dto.mobile),
                    DbHelper.CreateParameter("in_address_line_1",dto.address_line_1),
                    DbHelper.CreateParameter("in_address_line_2",dto.address_line_2),
                    DbHelper.CreateParameter("in_city",dto.city),
                    DbHelper.CreateParameter("in_land_mark",dto.land_mark),
                    DbHelper.CreateParameter("in_pincode",dto.pincode),
                    DbHelper.CreateParameter("in_language_id",dto.language_id),
                    DbHelper.CreateParameter("in_country_id",dto.country_id),
                    DbHelper.CreateParameter("in_state_id",dto.state_id)

                };
                var spName = "call sp_save_shipping_address(:in_shippingaddress_id,:in_name, :in_user_id,:in_email,:in_mobile,:in_address_line_1,:in_address_line_2,:in_city,:in_land_mark,:in_pincode,:in_language_id,:in_country_id,:in_state_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);



                //NpgsqlParameter[] para = new NpgsqlParameter[11];
                //para[0] = new NpgsqlParameter("@in_shippingaddress_id", Convert.ToInt64(dto.shippingaddress_id));
                //para[1] = new NpgsqlParameter("@in_name", dto.name);
                //para[2] = new NpgsqlParameter("@in_user_id", Convert.ToInt64(dto.user_id));
                //para[3] = new NpgsqlParameter("@in_email", dto.email);
                //para[4] = new NpgsqlParameter("@in_mobile", Convert.ToInt64(dto.mobile));
                //para[5] = new NpgsqlParameter("@in_address_line_1", dto.address_line_1);
                //para[6] = new NpgsqlParameter("@in_address_line_2", dto.address_line_2);
                //para[7] = new NpgsqlParameter("@in_city", dto.city);
                //para[8] = new NpgsqlParameter("@in_land_mark", dto.land_mark);
                //para[9] = new NpgsqlParameter("@in_pincode", Convert.ToInt64(dto.pincode));
                //para[10] = new NpgsqlParameter("@in_language_id", Convert.ToInt64(dto.language_id));
                //foreach (var item in para)
                //{
                //    invalue.Add(item.ParameterName + ':' + item.Value);
                //}
                //dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
                //dto.procedure_name = "sp_save_shipping_address";

                //status = sqlHelper.ExecuteNonQueryProcedure("call sp_save_shipping_address(:in_shippingaddress_id,:in_name, :in_user_id,:in_email,:in_mobile,:in_address_line_1,:in_address_line_2,:in_city,:in_land_mark,:in_pincode,:in_language_id)", para);

                if (status == -1)

                {
                    dto.msg_flg = "Update";
                }
                else
                {
                    dto.msg_flg = "Failed";
                }
                dto.shipping_address_list = _context.Customer_Shipping_Address_DMO_con.Where(a => a.user_id == dto.user_id).OrderByDescending(a => a.shippingaddress_id).ToArray();

            }



            catch (Exception ex)
            {
                
               // _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form);

            }
            return dto;
        }
        public CartCheckoutDTO change_shipping_address(CartCheckoutDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CartCheckout_Service/change_shipping_address";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
              

                var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.customer_id = user_list[0].customer_id;

                var dbParams = new DbParameter[]
                 {
                    DbHelper.CreateParameter("in_shippingaddress_id",dto.shippingaddress_id),
                     DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id",dto.language_id)
                   

                };
                var spName = "call sp_change_shipping_address(:in_shippingaddress_id,:in_user_id, :in_language_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);


                //NpgsqlParameter[] para = new NpgsqlParameter[3];
                //para[0] = new NpgsqlParameter("@in_shippingaddress_id", Convert.ToInt64(dto.shippingaddress_id));
                //para[1] = new NpgsqlParameter("@in_user_id", Convert.ToInt64(dto.user_id));
                //para[2] = new NpgsqlParameter("@in_language_id", Convert.ToInt64(dto.language_id));
                //foreach (var item in para)
                //{
                //    invalue.Add(item.ParameterName + ':' + item.Value);
                //}
                //dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
                //dto.procedure_name = "sp_change_shipping_address";

                //status = sqlHelper.ExecuteNonQueryProcedure("call sp_change_shipping_address(:in_shippingaddress_id, :in_user_id,:in_language_id)", para);
                if (status == -1)

                {
                    dto.msg_flg = "Update";
                }
                else
                {
                    dto.msg_flg = "Failed";
                }


                dto.shipping_address_list = _context.Customer_Shipping_Address_DMO_con.Where(a => a.user_id == dto.user_id).OrderByDescending(a => a.shippingaddress_id).ToArray();

            }



            catch (Exception ex)
            {
               

            }
            return dto;
        }

        public CartCheckoutDTO get_payment_data(CartCheckoutDTO dto)
        {
            try
            {
                var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.customer_id = user_list[0].customer_id;

                List<long> itemid = new List<long>();
                var cartlist = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.customer_id == dto.customer_id).ToList();

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
                        var removecart = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.customer_id == dto.customer_id && a.product_id == item.product_id && a.item_id == item.item_id).SingleOrDefault();
                        _context.Remove(removecart);
                    }

                }
                _context.SaveChanges();
           

              

            }
            catch (Exception ex)
            {

            }
            return dto;
        }
    }
}
