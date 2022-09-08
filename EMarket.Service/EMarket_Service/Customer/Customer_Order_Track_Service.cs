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

namespace EMarket.BLL.EMarket_Service.Customer
{
   public  class Customer_Order_Track_Service: ICustomer_Order_Track_Service
    {
        ICustomer_Order_Track_Repository _inter;       
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;
               int return_int = 0;
        long return_long = 0;
        string return_string = "";
        int status = 0;
        List<Array> hub_details = new List<Array>();
        public Customer_Order_Track_Service(PostgreSqlContext context, ISqlClass sql, IErrorClass error,
            ICustomer_Order_Track_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public Customer_Order_TrackDTO get_data(Customer_Order_TrackDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Order_Track_Service/get_data";
            var Params = new DbParameter[] { };

            try
            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;

                //get customer order
                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id)
                    };
                Params = dbParams;
                dto.procedure_name = "fn_get_customer_order";
                dto.customer_order_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get customer
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("ccustomer_id", dto.customer_id),
                 };
                Params = dbParams1;
                dto.procedure_name = "fn_get_customer_profile";
                dto.customerlist = _sql.Get_Data(dto.procedure_name, dbParams1);
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
        public Customer_Order_TrackDTO get_item_data(Customer_Order_TrackDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Order_Track_Service/get_item_data";
            var Params = new DbParameter[] { };
            try
            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;

            


                //get customer order item list
                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id)
                    };
                Params = dbParams;
                dto.procedure_name = "fn_get_customer_order_item";
                dto.customer_order_item_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get customer order item list
                var dbParams5 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id)
                    };
                Params = dbParams5;
                dto.procedure_name = "fn_get_customer_order_details";
                dto.customer_order_details = _sql.Get_Data(dto.procedure_name, dbParams5);


                //get customer address
                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                      DbHelper.CreateParameter("in_address_type", "Invoice")
                    };
                Params = dbParams1;
                dto.procedure_name = "fn_get_customer_address";
                dto.customer_invoice_address = _sql.fn_get_list(dto.procedure_name, dbParams1);



                //get customer shipping address
                var dbParams2 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                      DbHelper.CreateParameter("in_address_type", "Shipping")
                    };
                Params = dbParams2;
                dto.procedure_name = "fn_get_customer_address";
                dto.customer_shipping_address = _sql.fn_get_list(dto.procedure_name, dbParams2);


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
        public Customer_Order_TrackDTO get_order_item_details(Customer_Order_TrackDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Order_Track_Service/get_order_item_details";
            var Params = new DbParameter[] { };
            try
            {
                
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;



                //get order item details
                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                    };
                Params = dbParams;
                dto.procedure_name = "fn_get_order_item_details";
                dto.order_item_details = _sql.fn_get_list(dto.procedure_name, dbParams);


                //get order item specification
                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                    };
                Params = dbParams1;
                dto.procedure_name = "fn_get_order_item_specification";
                dto.order_item_specification = _sql.fn_get_list(dto.procedure_name, dbParams1);


                //get customer address
                var dbParams2 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                      DbHelper.CreateParameter("in_address_type", "Shipping")
                    };
                Params = dbParams2;
                dto.procedure_name = "fn_get_customer_address";
                dto.customer_shipping_address = _sql.fn_get_list(dto.procedure_name, dbParams2);


                //get order item status
                var dbParams3 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                    };
                Params = dbParams3;
                dto.procedure_name = "fn_get_order_item_status";
                dto.order_item_status = _sql.fn_get_list(dto.procedure_name, dbParams3);

                //get cancel reasion
                var dbParams4 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                    };
                Params = dbParams4;
                dto.procedure_name = "fn_get_cancel_resion";
                dto.cancel_reasion = _sql.Get_Data(dto.procedure_name, dbParams4);

                //get return reasion
                var dbParams5 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                                   };
                Params = dbParams5;
                dto.procedure_name = "fn_get_return_resion";
                dto.return_reasion = _sql.Get_Data(dto.procedure_name, dbParams5);

                //get hub list 1
                var dbParams6 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams6;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams6);

                //get cal hub list 
                var dbParams7 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                 };
                Params = dbParams7;
                dto.procedure_name = "fn_get_calculate_hub_route";
                dto.hub_route_list = _sql.Get_Data(dto.procedure_name, dbParams7);

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
        public Customer_Order_TrackDTO get_delivery_time(Customer_Order_TrackDTO dto)
        {
            List<Customer_Order_TrackDTO> dtonewtemp1 = new List<Customer_Order_TrackDTO>();
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Order_Track_Service/get_delivery_time";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                hub_details.Clear();
                dto.totaltime = 0;
                foreach (var item in dto.allhub_max)
                {
                    var dbParams = new DbParameter[]
                 {
                    DbHelper.CreateParameter("in_first_hub", item.hub_1),
                    DbHelper.CreateParameter("in_last_hub", item.hub_2)

                 };
                    Params = dbParams;
                    var spName = "get_route_schedule";
                    var retObject1 = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            dtonewtemp1.Add(new Customer_Order_TrackDTO
                            {
                                first_hub = Convert.ToString(dataReader["first_hub"]),
                                last_hub = Convert.ToString(dataReader["last_hub"]),
                                transport_registration_no = Convert.ToString(dataReader["transport_registration_no"]),
                                travel_time = Convert.ToDouble(dataReader["travel_time"]),
                                departure_time = (TimeSpan)dataReader["departure_time"],
                                departure_date = (DateTime)dataReader["departure_date"],
                            
                            });
                        }
                    }

                }

                dto.schedule_list = dtonewtemp1.ToArray();
                foreach (var tm in dtonewtemp1)
                {
                    dto.totaltime = dto.totaltime + tm.travel_time;
                }

                DateTime dt1 = DateTime.Now.Date;

                DateTime dt = DateTime.Now.Date;
                dt = dt.AddMinutes(dto.finalHour);
                dto.delivery_date_time = dt.ToString("dd-MM-yyyy HH:mm tt");
                if (dt1.Date == dt.Date)
                {
                    TimeSpan ts = TimeSpan.FromMinutes(dto.finalHour);
                    var data = string.Format("Today : {0}", new DateTime(ts.Ticks).ToString("HH:mm tt"));
                    dto.delivery_date_time = data.ToString();
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

        public Customer_Order_TrackDTO order_item_cancel(Customer_Order_TrackDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Order_Track_Service/order_item_cancel";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;

                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_cancel_item_id",dto.cancel_item_id),
                    DbHelper.CreateParameter("in_order_id",dto.order_id),
                    DbHelper.CreateParameter("in_order_item_id",dto.order_item_id),
                    DbHelper.CreateParameter("in_item_id",dto.item_id),
                    DbHelper.CreateParameter("in_customer_id",dto.customer_id),
                    DbHelper.CreateParameter("in_cancel_reasion_id",dto.cancel_reasion_id),
                    DbHelper.CreateParameter("in_cancel_reasion",dto.cancel_reasion),
                    DbHelper.CreateParameter("in_user_id",dto.user_id),
                    DbHelper.CreateParameter("in_language_id",dto.language_id)
                };
                dto.procedure_name = "call sp_save_cancel_order_item(:in_cancel_item_id,:in_order_id,:in_order_item_id,:in_item_id,:in_customer_id,:in_cancel_reasion_id,:in_cancel_reasion,:in_user_id,:in_language_id)";
                status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                if(status==-1)
                {
                    dto.status = "Update";
                    dto.message = "Order Canceled Successfully";
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Failed To Order Cancel";
                }
                //get order item status
                var dbParams3 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                    };
                Params = dbParams3;
                dto.procedure_name = "fn_get_order_item_status";
                dto.order_item_status = _sql.fn_get_list(dto.procedure_name, dbParams3);


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

        public Customer_Order_TrackDTO order_item_return(Customer_Order_TrackDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Order_Track_Service/order_item_return";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;

                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_return_item_id",dto.return_item_id),
                    DbHelper.CreateParameter("in_order_id",dto.order_id),
                    DbHelper.CreateParameter("in_order_item_id",dto.order_item_id),
                    DbHelper.CreateParameter("in_item_id",dto.item_id),
                    DbHelper.CreateParameter("in_customer_id",dto.customer_id),
                    DbHelper.CreateParameter("in_return_reasion_id",dto.return_reasion_id),
                    DbHelper.CreateParameter("in_return_reasion",dto.return_reasion),
                    DbHelper.CreateParameter("in_user_id",dto.user_id),
                    DbHelper.CreateParameter("in_language_id",dto.language_id)
                };
                dto.procedure_name = "call sp_save_return_order_item(:in_return_item_id,:in_order_id,:in_order_item_id,:in_item_id,:in_customer_id,:in_return_reasion_id,:in_return_reasion,:in_user_id,:in_language_id)";
                status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.status = "Update";
                    dto.message = "Order Return Request Accepted";
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Failed To Order Return Request Accepted";
                }
                //get order item status
                var dbParams3 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                    };
                Params = dbParams3;
                dto.procedure_name = "fn_get_order_item_status";
                dto.order_item_status = _sql.fn_get_list(dto.procedure_name, dbParams3);


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
        public Customer_Order_TrackDTO save_rating_review(Customer_Order_TrackDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Order_Track_Service/save_rating_review";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;

                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_item_id",dto.item_id),
                    DbHelper.CreateParameter("in_user_id",dto.user_id),
                    DbHelper.CreateParameter("in_customer_id",dto.customer_id),
                    DbHelper.CreateParameter("in_rating_number",dto.rating_number),
                    DbHelper.CreateParameter("in_title",dto.title),
                    DbHelper.CreateParameter("in_comments",dto.comments),
                    DbHelper.CreateParameter("in_language_id",dto.language_id)
            
                };
                dto.procedure_name = "call sp_save_product_item_rating_review(:in_item_id,:in_user_id,:in_customer_id,:in_rating_number,:in_title,:in_comments,:in_language_id)";
                status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.status = "Update";
                    dto.message = "Thank You For Rating";
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Failed To Insert Rating";
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
        //Mukta 03-09-2022
        public Customer_Order_TrackDTO invoice_print_data(Customer_Order_TrackDTO dto) 
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Order_Track_Service/invoice_print_data";
            var Params = new DbParameter[] { };
            try
            {
                //get customer address
                var dbParams2 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                      DbHelper.CreateParameter("in_address_type", "Shipping")
                    };
                Params = dbParams2;
                dto.procedure_name = "fn_get_customer_address";
                dto.customer_shipping_address = _sql.fn_get_list(dto.procedure_name, dbParams2);
                //customer invoice address
                var dbParams10 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                };
                //invoice address
                Params = dbParams10;
                dto.procedure_name = "fn_get_invoice_print_data_three";
                dto.invoice_list_two = _sql.fn_get_list(dto.procedure_name, dbParams10);

                //data
                var dbParams9 = new DbParameter[]
               {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                   DbHelper.CreateParameter("in_order_id", dto.order_id),

               };
                Params = dbParams9;
                dto.procedure_name = "fn_get_customer_invoice";
                dto.customer_invoice = _sql.Get_Data(dto.procedure_name, dbParams9);

                //data
                var dbParams11 = new DbParameter[]
               {
                   DbHelper.CreateParameter("in_order_id", dto.order_id),
                   DbHelper.CreateParameter("in_item_id", dto.item_id),

               };
                Params = dbParams11;
                dto.procedure_name = "fn_get_customer_invoice_data";
                dto.customer_invoice_data = _sql.Get_Data(dto.procedure_name, dbParams11);


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
    }
}
