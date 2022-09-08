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
    public class Hub_To_Fc_Delivery: IHub_To_Fc_Delivery
    {

        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;

        public Hub_To_Fc_Delivery(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Hub_To_Fc_DeliveryDTO get_data(Hub_To_Fc_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_To_Fc_Delivery/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;

                //get assign list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_hub_to_fc_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get pickup list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_fc_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get drop list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_fc_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Hub_To_Fc_DeliveryDTO accept_hub_to_fc(Hub_To_Fc_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_To_Fc_Delivery/accept_hub_to_fc";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;


                var dbParams3 = new DbParameter[]
              {
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id)

              };
                Params = dbParams3;
                var spName = "call sp_accept_to_pickup_from_hub_to_fc(:in_user_id,:in_consignment_id)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }


                //get assign list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_hub_to_fc_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get pickup list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_fc_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get drop list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_fc_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);



            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Hub_To_Fc_DeliveryDTO reject_hub_to_fc(Hub_To_Fc_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_To_Fc_Delivery/reject_hub_to_fc";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;


                var dbParams3 = new DbParameter[]
              {
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_reasion", dto.reasion)

              };
                Params = dbParams3;
                var spName = "call sp_reject_from_hub_to_fc(:in_user_id,:in_consignment_id,:in_delivery_executive_id,:in_reasion)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Reject";
                }
                else
                {
                    dto.status = "Failed";
                }


                //get assign list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_hub_to_fc_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get pickup list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_fc_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get drop list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_fc_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);



            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Hub_To_Fc_DeliveryDTO pickup_hub_to_fc(Hub_To_Fc_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_To_Fc_Delivery/pickup_hub_to_fc";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;


                var dbParams3 = new DbParameter[]
              {
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id)

              };
                Params = dbParams3;
                var spName = "call sp_pickup_to_pickup_from_hub_to_fc(:in_user_id,:in_consignment_id)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }


                //get assign list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_hub_to_fc_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get pickup list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_fc_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get drop list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_fc_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams2);



            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Hub_To_Fc_DeliveryDTO deliver_from_hub_to_fc(Hub_To_Fc_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_To_Fc_Delivery/deliver_from_hub_to_fc";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;


                var dbParams3 = new DbParameter[]
              {
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id)

              };
                Params = dbParams3;
                var spName = "call sp_drop_from_hub_to_fc(:in_user_id,:in_consignment_id)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }



                //get assign list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_hub_to_fc_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get pickup list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_fc_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get drop list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_drop_delivery_hub_to_fc_list";
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
