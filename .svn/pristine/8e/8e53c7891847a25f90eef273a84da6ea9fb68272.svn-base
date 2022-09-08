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
   public  class Landing_Item_Details_Service: ILanding_Item_Details_Service
    {
        ILanding_Item_Details_Repository _inter;      
        ISqlClass _sql;
        IErrorClass _error;
          PostgreSqlContext _context;
        Db_Connection conn= new Db_Connection();
        int return_int = 0;
        public Landing_Item_Details_Service(PostgreSqlContext context, ISqlClass sql, IErrorClass error,
            ILanding_Item_Details_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }


        public Landing_Item_DetailsDTO get_data(Landing_Item_DetailsDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Item_Details_Service/get_data";
            try
            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
                if(customer.Count>0)
                {
                    dto.customer_id = customer[0].customer_id;
                    dto.cartlist = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.customer_id == dto.customer_id).ToArray();
                }
              

                // Get Items Details
                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                  };
                dto.procedure_name = "fn_get_item_details";
                dto.item_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get specification

                var dbParams1 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                 };
                dto.procedure_name = "fn_get_specification";
                dto.specification_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                // Get similar item
                var dbParams5 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                  };
                dto.procedure_name = "fn_get_similar_items";
                dto.similar_item_list = _sql.Get_Data(dto.procedure_name, dbParams5);


                long pid = 0;
                var pidlist = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).ToList();
                if (pidlist.Count > 0)
                {
                    pid = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).SingleOrDefault().product_id;
                }
                else
                {
                    dto.msg_flg = "NoData";
                    dto.message = "No Data Found";
                    return dto;
                }



                // product Feature
                var dbParams2 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_product_id", pid),
                      DbHelper.CreateParameter("in_item_id", dto.item_id),
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
              };
                dto.procedure_name = "fn_get_productfeatures";
                dto.featurelist = _sql.fn_get_list(dto.procedure_name, dbParams2);


                // var attribute
                var dbParams3 = new DbParameter[]
              {      DbHelper.CreateParameter("in_language_id", dto.language_id),
                     DbHelper.CreateParameter("in_product_id", pid),
                     DbHelper.CreateParameter("in_item_id", dto.item_id)
            };
                dto.procedure_name = "fn_get_all_variant_attr";
                dto.all_variant_attr_list = _sql.fn_get_list(dto.procedure_name, dbParams3);
             


                // get single variant 
                var dbParams4 = new DbParameter[]
             {      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", pid),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
           };
                dto.procedure_name = "fn_get_single_variant_attr";
                dto.single_variant_attr = _sql.fn_get_list(dto.procedure_name, dbParams4);


                // var attribute
                var dbParams6 = new DbParameter[]
              {      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", pid),
                          DbHelper.CreateParameter("in_variant", 1)
                };
                dto.procedure_name = "fn_get_landing_product_variant_one";
                dto.all_product_variant_one = _sql.fn_get_list(dto.procedure_name, dbParams6);


                // var attribute
                var dbParams7 = new DbParameter[]
              {      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", pid),
                      DbHelper.CreateParameter("in_variant", 2)
            };
                dto.procedure_name = "fn_get_landing_product_variant_two";
                dto.all_product_variant_two = _sql.fn_get_list(dto.procedure_name, dbParams7);

                //  rating list
                var dbParams8 = new DbParameter[]
              {      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
            };
                dto.procedure_name = "fn_get_product_item_rating";
                dto.rating_list = _sql.fn_get_list(dto.procedure_name, dbParams8);


                //  rating list
                var dbParams9 = new DbParameter[]
              {      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
            };
                dto.procedure_name = "fn_get_multiple_image";
                dto.multiple_image_list = _sql.fn_get_list(dto.procedure_name, dbParams9);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Landing_Item_DetailsDTO get_data_pub(Landing_Item_DetailsDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Item_Details_Service/get_data_pub";
            try
            {

                // Get Items Details
                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                  };
                dto.procedure_name = "fn_get_item_details";
                dto.item_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get specification

                var dbParams1 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                 };
                dto.procedure_name = "fn_get_specification";
                dto.specification_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                var pid = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).SingleOrDefault().product_id;


                // product Feature
                var dbParams2 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_product_id", pid),
                      DbHelper.CreateParameter("in_item_id", dto.item_id),
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
              };
                dto.procedure_name = "fn_get_productfeatures";
                dto.featurelist = _sql.fn_get_list(dto.procedure_name, dbParams2);


                // var attribute
                var dbParams3 = new DbParameter[]
              {      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", pid)

            };
                dto.procedure_name = "fn_get_all_variant_attr";
                dto.all_variant_attr_list = _sql.fn_get_list(dto.procedure_name, dbParams3);



                // get single variant 
                var dbParams4 = new DbParameter[]
             {      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", pid),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)

           };
                dto.procedure_name = "fn_get_single_variant_attr";
                dto.single_variant_attr = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Landing_Item_DetailsDTO get_specification_details(Landing_Item_DetailsDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Item_Details_Service/get_specification_details";
            try

            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;

                var dbParams = new DbParameter[]
                {
                        DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id),
                      DbHelper.CreateParameter("in_specification_id", dto.specification_id)
                 };
                dto.procedure_name = "fn_get_specification_details";
                dto.specification_details_list = _sql.fn_get_list(dto.procedure_name, dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Landing_Item_DetailsDTO add_to_cart(Landing_Item_DetailsDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Item_Details_Service/add_to_cart";
            try
            {
                if (dto.user_id != 0)
                {
                    var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                    dto.customer_id = customer.customer_id;
                    //dto.cartlist = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.customer_id == dto.customer_id).ToArray();
                }
               

                if (dto != null && dto.product_id == 0 && dto.item_id == 0)
                {
                    dto.msg_flg = "Failed";
                    dto.message = "Somthing Wrong! Try Again";
                    return dto;
                }
                if (dto.user_id != 0)
                {
                    var check = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.customer_id == dto.customer_id && a.product_id == dto.product_id && a.item_id == dto.item_id).ToList();
                    if (check.Count != null && check.Count != 0)
                    {
                        dto.msg_flg = "Failed";
                        dto.message = "Product Already In cart";
                        return dto;
                    }
                }

                if (dto.user_id == 0)
                {
                    var check = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.session_cart == dto.session_cart && a.product_id == dto.product_id && a.item_id == dto.item_id).ToList();
                    if (check.Count != null && check.Count != 0)
                    {
                        dto.msg_flg = "Failed";
                        dto.message = "Product Already In cart";
                        return dto;
                    }
                }



                var check_item = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).FirstOrDefault();
                if (check_item.quantity > 0)
                {
                    _inter.add_to_cart(dto);
                }
                else
                {
                    dto.msg_flg = "Failed";
                    dto.message = "Out of Stock";
                }

                if (dto.user_id != 0)
                {
                   
                    dto.cartlist = _context.Cart_List_con.Where(a => a.userid == dto.user_id && a.customer_id == dto.customer_id).ToArray();
                }
                else
                {
                    dto.cartlist = _context.Cart_List_con.Where(a => a.session_cart==dto.session_cart).ToArray();
                }
             

            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
            return dto;
        }
        public Landing_Item_DetailsDTO single_checkout(Landing_Item_DetailsDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            string methodname = "Landing_Item_Details_Service/single_checkout";
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
               
                    };
                Params = dbParams;
                var spName = "call sp_add_to_singlecheckout(:in_product_id, :in_item_id,:in_user_id,:in_customer_id)";
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
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
            return dto;
        }

        public Landing_Item_DetailsDTO single_public_checkout(Landing_Item_DetailsDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            string methodname = "Landing_Item_Details_Service/single_public_checkout";
            try
            {
              

                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_product_id", dto.product_id),
                    DbHelper.CreateParameter("in_item_id", dto.item_id),
                   DbHelper.CreateParameter("in_session_cart", dto.session_cart),

                    };
                Params = dbParams;
                var spName = "call sp_add_to_public_singlecheckout(:in_product_id, :in_item_id,:in_session_cart)";
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
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
            return dto;
        }
    }
}
