using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Delivery;
using EMarket.Entities;
using EMarketDTO.Delivery;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Delivery
{
    public class Delivery_to_Customer: IDelivery_to_Customer
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        int status = 0;

        public Delivery_to_Customer(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Delivery_to_CustomerDTO get_data(Delivery_to_CustomerDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Delivery_to_Customer/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;


                var deliverylist = _context.Facilitation_To_CustomerDMO_con.Where(a => a.delivery_executive_id == dto.delivery_executive_id && a.delivery_executive_status == "Received From Facilitation").ToList();
                foreach (var item in deliverylist)
                {
                    var updatedeliverylist = _context.Facilitation_To_CustomerDMO_con.Where(a => a.delivery_executive_id == dto.delivery_executive_id && a.consignment_id==item.consignment_id).SingleOrDefault();
                    updatedeliverylist.otp_status = "Pending";
                    _context.Update(updatedeliverylist);
                    _context.SaveChanges();
                }



                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_pending_delivery_customer_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_customer_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get all delivery list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_customer_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Delivery_to_CustomerDTO update_accept_delivery(Delivery_to_CustomerDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Delivery_to_Customer/update_accept_delivery";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;

                var dbParams3 = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                   };
                Params = dbParams3;
                var spName = "call sp_update_accept_delivery_customer(:in_consignment_id, :in_order_item_id,:in_delivery_executive_id,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }



                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_pending_delivery_customer_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_customer_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get all delivery list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_customer_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Delivery_to_CustomerDTO deliver_item(Delivery_to_CustomerDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Delivery_to_Customer/deliver_item";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;

                var dbParams3 = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                   };
                Params = dbParams3;
                var spName = "call sp_deliver_item_to_customer(:in_consignment_id, :in_order_item_id,:in_delivery_executive_id,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }

                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_pending_delivery_customer_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_customer_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get all delivery list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_customer_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Delivery_to_CustomerDTO update_reject_delivery(Delivery_to_CustomerDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Delivery_to_Customer/update_reject_delivery";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;

                var dbParams3 = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_reasion", dto.reasion)
                   };
                Params = dbParams3;
                var spName = "call sp_reject_item_to_customer(:in_consignment_id, :in_order_item_id,:in_delivery_executive_id,:in_language_id,:in_user_id,:in_reasion)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Reject";
                }
                else
                {
                    dto.status = "Failed";
                }

                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_pending_delivery_customer_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_customer_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get all delivery list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_customer_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Delivery_to_CustomerDTO update_pickup_delivery(Delivery_to_CustomerDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Delivery_to_Customer/update_pickup_delivery";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;

                var dbParams3 = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                   };
                Params = dbParams3;
                var spName = "call sp_update_pickup_delivery_customer(:in_consignment_id, :in_order_item_id,:in_delivery_executive_id,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }



                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_pending_delivery_customer_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_customer_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get all delivery list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_customer_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Delivery_to_CustomerDTO get_collect_amount(Delivery_to_CustomerDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Delivery_to_Customer/get_collect_amount";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;


                //get amount collect
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                      DbHelper.CreateParameter("in_order_id", dto.order_id),
                      DbHelper.CreateParameter("in_order_item_id", dto.order_item_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_amount_collect_list";
                dto.amount_collect_list = _sql.fn_get_list(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Delivery_to_CustomerDTO collect_amount(Delivery_to_CustomerDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Delivery_to_Customer/collect_amount";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;


                var dbParams3 = new DbParameter[]
                  {
                    DbHelper.CreateParameter("in_collected_amount", dto.collected_amount),
                    DbHelper.CreateParameter("in_order_id", dto.order_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                  };
                Params = dbParams3;
                var spName = "call sp_save_cod_amount_collect(:in_collected_amount,:in_order_id,:in_order_item_id,:in_delivery_executive_id,:in_consignment_id,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Received";
                }
                else
                {
                    dto.status = "Failed";
                }


                var dbParams7 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_order_id", dto.order_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_collected_amount", dto.collected_amount),
                };
                Params = dbParams7;
                var spName1 = "call sp_update_order_amount(:in_consignment_id,:in_order_id,:in_order_item_id,:in_language_id,:in_user_id,:in_collected_amount)";
                status = _dbHelper.ExecuteNonQuery(spName1, CommandType.Text, dbParams7);
                if (status == -1)
                {
                    dto.status = "Received";
                }
                else
                {
                    dto.status = "Failed";
                }



                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_pending_delivery_customer_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_customer_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get all delivery list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_customer_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Delivery_to_CustomerDTO update_received_otp(Delivery_to_CustomerDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Delivery_to_Customer/update_received_otp";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;


                var dbParams3 = new DbParameter[]
                  {
                
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                  };
                Params = dbParams3;
                var spName = "call sp_update_received_otp(:in_consignment_id,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }


                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_pending_delivery_customer_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_customer_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get all delivery list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_customer_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

    }
}
