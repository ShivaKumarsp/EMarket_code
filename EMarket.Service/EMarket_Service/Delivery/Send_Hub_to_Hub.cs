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
    public class Send_Hub_to_Hub : ISend_Hub_to_Hub
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        int status = 0;

        public Send_Hub_to_Hub(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Send_Hub_to_HubDTO get_data(Send_Hub_to_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Send_Hub_to_Hub/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;

                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_hub";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);
                             


                //get all delivery list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_public_Transport";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);


                //get all accept list
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),

               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_hub_details";
                dto.pickup_delivery_list_details = _sql.fn_get_list(dto.procedure_name, dbParams3);

                
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),

               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_hub_details";
                dto.drop_delivery_list_details = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Send_Hub_to_HubDTO get_batch_data_details(Send_Hub_to_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Send_Hub_to_Hub/get_batch_data_details";
            var Params = new DbParameter[] { };
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;


                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                      DbHelper.CreateParameter("in_batch_id", dto.batch_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_details";
                dto.all_item_details = _sql.fn_get_list(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Send_Hub_to_HubDTO update_pickup_delivery(Send_Hub_to_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Send_Hub_to_Hub/update_pickup_delivery";
            var Params = new DbParameter[] { };
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;



                foreach (var item in dto.hub_to_hub_array)
                {
                    var dbParams7 = new DbParameter[]
                         {

                    DbHelper.CreateParameter("in_batch_id", dto.batch_id),
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                         };

                    Params = dbParams7;
                    var spName = "call sp_pickup_accept_from_hub_to_hub(:in_batch_id,:in_consignment_id,:in_delivery_executive_id,:in_user_id)";
                    var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams7);
                    if (status == -1)
                    {
                        dto.status = "Accept";
                        dto.message = "Batch Pickedup Successfully";

                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Failed To Batch Pickeup";

                    }

                }


                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_hub";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);



                //get all delivery list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_public_Transport";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);


                //get all accept list
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),

               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_hub_details";
                dto.pickup_delivery_list_details = _sql.fn_get_list(dto.procedure_name, dbParams3);


                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),

               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_hub_details";
                dto.drop_delivery_list_details = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Send_Hub_to_HubDTO update_drop_delivery(Send_Hub_to_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Send_Hub_to_Hub/update_drop_delivery";
            var Params = new DbParameter[] { };
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;

                foreach (var item in dto.hub_to_hub_array)
                {
                    var dbParams7 = new DbParameter[]
                         {

                    DbHelper.CreateParameter("in_batch_id", dto.batch_id),
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                         };

                    Params = dbParams7;
                    var spName = "call sp_drop_to_from_hub_to_public_transport(:in_batch_id,:in_consignment_id,:in_delivery_executive_id,:in_user_id)";
                    var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams7);
                    if (status == -1)
                    {
                        dto.status = "Accept";
                        dto.message = "Batch Drop Successfully";

                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Failed To Batch Drop";

                    }

                }


                //get all accept list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_hub";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);



                //get all delivery list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_public_Transport";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);


                //get all accept list
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),

               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_hub_details";
                dto.pickup_delivery_list_details = _sql.fn_get_list(dto.procedure_name, dbParams3);


                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),

               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_hub_details";
                dto.drop_delivery_list_details = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
    }
}
