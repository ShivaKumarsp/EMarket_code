
using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Delivery;
using EMarket.DLL.Interfaces.Delivery;
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

namespace EMarket.BLL.EMarket_Repository.Delivery
{
    public class Accept_Delivery: IAccept_Delivery
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        int status = 0;
        IAccept_Delivery_Repository _inter;

        public Accept_Delivery(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IAccept_Delivery_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }
        public Accept_DeliveryDTO get_data(Accept_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Accept_Delivery/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;


                //get request list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all vendor list
                var dbParams1 = new DbParameter[]
               {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                var dbParams2 = new DbParameter[]
                {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
                };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);





                //get all accept list
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", 1),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_pending_delivery_store_list";
                dto.pending_delivery_store_list = _sql.fn_get_list(dto.procedure_name, dbParams4);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        public Accept_DeliveryDTO update_accept_delivery(Accept_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Accept_Delivery/update_accept_delivery";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;

                _inter.update_accept_delivery(dto);

                //get request list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all vendor list
                var dbParams1 = new DbParameter[]
               {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                var dbParams2 = new DbParameter[]
                {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
                };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);



                var dbParams4 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", 1),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
              };
                Params = dbParams4;
                dto.procedure_name = "fn_get_pending_delivery_store_list";
                dto.pending_delivery_store_list = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Accept_DeliveryDTO update_reject_delivery(Accept_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Accept_Delivery/update_reject_delivery";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;
                _inter.update_reject_delivery(dto);

                //get request list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all vendor list
                var dbParams1 = new DbParameter[]
               {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                var dbParams2 = new DbParameter[]
                {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
                };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);




                var dbParams4 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", 1),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
              };
                Params = dbParams4;
                dto.procedure_name = "fn_get_pending_delivery_store_list";
                dto.pending_delivery_store_list = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        public Accept_DeliveryDTO update_accept_delivery_store(Accept_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Accept_Delivery/update_accept_delivery";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;
                _inter.update_accept_delivery_store(dto);



                //get request list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all vendor list
                var dbParams1 = new DbParameter[]
               {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                var dbParams2 = new DbParameter[]
                {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
                };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);



                var dbParams4 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", 1),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
              };
                Params = dbParams4;
                dto.procedure_name = "fn_get_pending_delivery_store_list";
                dto.pending_delivery_store_list = _sql.fn_get_list(dto.procedure_name, dbParams4);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        public Accept_DeliveryDTO pickup_from_vendor(Accept_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Accept_Delivery/deliver_item";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;
                _inter.pickup_from_vendor(dto);

                //get request list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get all vendor list
                var dbParams1 = new DbParameter[]
               {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                var dbParams2 = new DbParameter[]
                {
                   DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
                };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);



                var dbParams4 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", 1),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
              };
                Params = dbParams4;
                dto.procedure_name = "fn_get_pending_delivery_store_list";
                dto.pending_delivery_store_list = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

      
    }
}
