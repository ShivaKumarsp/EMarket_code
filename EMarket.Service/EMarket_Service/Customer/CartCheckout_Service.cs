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
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.BLL.EMarket_Service.Customer
{
    public class CartCheckout_Service : ICartCheckout_Service
    {
        ICartCheckout_Repository _inter;

        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;
        int return_int = 0;
        long return_long = 0;
        string return_string = "";
        ValidationClass _valid = new ValidationClass();
        int status = 0;
        public CartCheckout_Service(PostgreSqlContext context, ISqlClass sql, IErrorClass error, ICartCheckout_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public CartCheckoutDTO get_data(CartCheckoutDTO dto)
        {
            List<CartCheckoutDTO> dtontemp = new List<CartCheckoutDTO>();
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CartCheckout_Service/get_date";
            List<long> itemid = new List<long>();
            var Params = new DbParameter[] { };
            try
            {
                var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.customer_id = user_list[0].customer_id;

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

                // get cart_item
                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_customer_id", dto.customer_id),
                    };
                Params = dbParams;
                dto.procedure_name = "fn_get_cart_item";
                dto.mycartlist = _sql.fn_get_list(dto.procedure_name, dbParams);

                dto.shipping_address_list = _context.Customer_Shipping_Address_DMO_con.Where(a => a.user_id == dto.user_id).OrderByDescending(a => a.shippingaddress_id).ToArray();
                // 
                var dbParams5 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_user_id", dto.user_id)

                };
                Params = dbParams5;
                var spName = "fn_find_invoice_address";
                var retObject1 = new List<dynamic>();
                using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams5))
                {
                    while (dataReader.Read())
                    {
                        var dataRow = new ExpandoObject() as IDictionary<string, object>;
                        dtontemp.Add(new CartCheckoutDTO
                        {
                            invoice_count1 = Convert.ToInt64(dataReader["check_count"])

                        });
                    }
                }
                dto.invoice_count = dtontemp[0].invoice_count1;
                
                    //get all vendor list
                    var dbParams6 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                   };
                    Params = dbParams6;
                    dto.procedure_name = "fn_country";
                    dto.country_list = _sql.fn_get_list(dto.procedure_name, dbParams6);

                    var dbParams7 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                    };
                    Params = dbParams7;
                    dto.procedure_name = "fn_gender";
                    dto.gender_list = _sql.fn_get_list(dto.procedure_name, dbParams7);
                    //get customer billing address
                    var dbParams8 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_user_id", dto.user_id)
                    };
                    Params = dbParams8;
                    dto.procedure_name = "fn_get_invoice_address";
                    dto.invoice_list = _sql.fn_get_list(dto.procedure_name, dbParams8);

                var dbParams9 = new DbParameter[]
            {

                         DbHelper.CreateParameter("in_user_id", dto.user_id),
                         DbHelper.CreateParameter("in_language_id", dto.language_id),
            };
                Params = dbParams9;
                dto.procedure_name = "fn_get_invoice_list";
                dto.user_invoice_list = _sql.fn_get_list(dto.procedure_name, dbParams9);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public CartCheckoutDTO save_shipping_address(CartCheckoutDTO dto)
        {
            bool nama;
            List<string> ret_validation = new List<string>();
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CartCheckout_Service/save_shipping_address";
            if (dto.name.Trim() == "" || dto.name.Trim() == null || dto.name.Trim() == "0")
            {
                ret_validation.Add("Please Enter Name");
            }
          

            if (dto.mobile == null || dto.mobile == 0)
            {
                ret_validation.Add("Please Enter Mobile");
            }

            if (dto.mobile == 9999999999 || dto.mobile == 8888888888 || dto.mobile == 7777777777 || dto.mobile == 6666666666)
            {
                ret_validation.Add("Please Enter Valid Mobile");
            }
            var mob = _valid.Is_Valid_Mobile(dto.mobile);
            if (mob == false)
            {
                ret_validation.Add("Please Enter Valid Mobile Number");
            }


            if (dto.email == "" || dto.email == null || dto.email == "0")
            {
                ret_validation.Add("Please Enter Email");
            }
            if (dto.email != "" || dto.email != null)
            {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex ere = new Regex(emailRegex);
                if (!ere.IsMatch(dto.email))
                {
                    ret_validation.Add("Please Enter Valid Email");
                }

            }


            if (dto.address_line_1.Trim() == "" || dto.address_line_1.Trim() == null || dto.address_line_1.Trim() == "0")
            {
                ret_validation.Add("Please Enter Address Line1");
            }
            if (dto.address_line_2.Trim() == "" || dto.address_line_2.Trim() == null || dto.address_line_2.Trim() == "0")
            {
                ret_validation.Add("Please Enter Address Line2");
            }

            if (dto.city.Trim() == "" || dto.city.Trim() == null || dto.city.Trim() == "0")
            {
                ret_validation.Add("Please Enter City");
            }

            if (dto.land_mark.Trim() == "" || dto.land_mark.Trim() == null || dto.land_mark.Trim() == "0")
            {
                ret_validation.Add("Please Enter Landmark");
            }
            if (dto.pincode == 0 || dto.pincode ==null)
            {
                ret_validation.Add("Please Enter Pincode");
            }

            if (ret_validation.Count > 0)
            {
                dto.msg_flg = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }

            try
            {
                _inter.save_shipping_address(dto);
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
        public CartCheckoutDTO change_shipping_address(CartCheckoutDTO dto)
        {
            return _inter.change_shipping_address(dto);
        }

        //Cart Payment Method

        public CartCheckoutDTO get_payment_data(CartCheckoutDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CartCheckout_Service/get_payment_data";
                    var Params = new DbParameter[] { };
            var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
            dto.customer_id = user_list[0].customer_id;

            var cartlist = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.customer_id == dto.customer_id).ToList();
            dto.cartcount = cartlist.Count;

            try
            {
                _inter.get_payment_data(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            try
            {
                // get cart_item
                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_customer_id", dto.customer_id),
                    };
                Params = dbParams;
                dto.procedure_name = "fn_get_cart_item";
                dto.mycartlist = _sql.fn_get_list(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }

            return dto;
        }

        // Direct Checkout
        public CartCheckoutDTO get_data_directcart(CartCheckoutDTO dto)
        {
            List<CartCheckoutDTO> dtontemp = new List<CartCheckoutDTO>();
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CartCheckout_Service/get_data_directcart";
            List<long> itemid = new List<long>();
            var Params = new DbParameter[] { };
            try
            {
                var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.customer_id = user_list[0].customer_id;


        
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


                dto.shipping_address_list = _context.Customer_Shipping_Address_DMO_con.Where(a => a.user_id == dto.user_id).OrderByDescending(a => a.shippingaddress_id).ToArray();

             
                var dbParams7 = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams7;
                dto.procedure_name = "fn_gender";
                dto.gender_list = _sql.fn_get_list(dto.procedure_name, dbParams7);

                var dbParams8 = new DbParameter[]
              {
                     
                         DbHelper.CreateParameter("in_user_id", dto.user_id),
                         DbHelper.CreateParameter("in_language_id", dto.language_id),
              };
                Params = dbParams8;
                dto.procedure_name = "fn_get_invoice_list";
                dto.user_invoice_list = _sql.fn_get_list(dto.procedure_name, dbParams8);

                var dbParams5 = new DbParameter[]
         {
                    DbHelper.CreateParameter("in_user_id", dto.user_id)

         };
                    Params = dbParams5;
                    var spName = "fn_find_invoice_address";
                    var retObject1 = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams5))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                        dtontemp.Add(new CartCheckoutDTO
                            {
                                invoice_count1 = Convert.ToInt64(dataReader["check_count"])

                            });
                        }
                    }
                dto.invoice_count = dtontemp[0].invoice_count1;

               
                    //get all vendor list
                    var dbParams6 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                   };
                    Params = dbParams6;
                    dto.procedure_name = "fn_country";
                    dto.country_list = _sql.fn_get_list(dto.procedure_name, dbParams6);
                


                dto.shipping_address_list = _context.Customer_Shipping_Address_DMO_con.Where(a => a.user_id == dto.user_id).OrderByDescending(a => a.shippingaddress_id).ToArray();

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }

        public CartCheckoutDTO get_payment_data_directcart(CartCheckoutDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CartCheckout_Service/get_payment_data_directcart";
            var Params = new DbParameter[] { };
            var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
            dto.customer_id = user_list[0].customer_id;

            try
            {
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
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            finally
            {
             
            }

            return dto;
        }

        public CartCheckoutDTO save_invoice_address(CartCheckoutDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CartCheckout_Service/save_invoice_address";
            var Params = new DbParameter[] { };
            var user_list = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
            dto.customer_id = user_list[0].customer_id;

            try
            {
                var dbParams = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_address_id", dto.address_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_first_name", dto.first_name),
                    DbHelper.CreateParameter("in_second_name", dto.second_name),
                    DbHelper.CreateParameter("in_gender_id", dto.gender_id),
                    DbHelper.CreateParameter("in_email", dto.email),
                    DbHelper.CreateParameter("in_mobile", dto.mobile),
                    DbHelper.CreateParameter("in_address", dto.address),
                    DbHelper.CreateParameter("in_city", dto.city),
                    DbHelper.CreateParameter("in_state_id", dto.state_id),
                    DbHelper.CreateParameter("in_country_id", dto.country_id),
                    DbHelper.CreateParameter("in_pincode", dto.pincode)
                        };

                Params = dbParams;
                var spName = "call sp_save_invoice_address(:in_address_id,:in_user_id,:in_first_name,:in_second_name,:in_gender_id,:in_email,:in_mobile,:in_address,:in_city,:in_state_id,:in_country_id,:in_pincode)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                        dto.status = "Insert";
                        dto.message = "Invoice Address Insert Successfully";
                   
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Invoice Address Insert Failed";
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            finally
            {
            }

            return dto;
        }

        public CartCheckoutDTO get_state(CartCheckoutDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CartCheckout_Service/get_state";
            var Params = new DbParameter[] { };
            try
            {


                //get state
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("languageid", dto.language_id),
                      DbHelper.CreateParameter("countryid", dto.country_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_getstate";
                dto.state_list = _sql.fn_get_list(dto.procedure_name, dbParams);



            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        public CartCheckoutDTO checkpincode(CartCheckoutDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "CartCheckout_Service/checkpincode";
            var Params = new DbParameter[] { };
            try
            {


                //get state
                var dbParams = new DbParameter[]
               {
                  DbHelper.CreateParameter("in_pincode", dto.vpincode)
                
               };
                Params = dbParams;
                dto.procedure_name = "fn_check_pincode";
                dto.checkpincode = _sql.Get_ExecuteScalar(dto.procedure_name, dbParams);

                if(dto.checkpincode=="0")
                {
                    dto.status = "Failed";
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
