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
    public class Fc_To_Hub_Delivery: IFc_To_Hub_Delivery
    {
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;

        public Fc_To_Hub_Delivery(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Fc_To_Hub_DeliveryDTO get_data(Fc_To_Hub_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_To_Hub_Delivery/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var delivery = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.user_id == dto.user_id).FirstOrDefault();
                dto.delivery_executive_id = delivery.delivery_executive_id;

                //get  list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_fc_to_hub_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                var dbParams1 = new DbParameter[]
             {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
             };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_fc_to_hub_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get drop list
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_drop_delivery_fc_to_hub_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams3);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Fc_To_Hub_DeliveryDTO accept_fc_to_hub(Fc_To_Hub_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_To_Hub_Delivery/accept_fc_to_hub";
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
                var spName = "call sp_accept_from_fc_to_hub(:in_user_id,:in_consignment_id)";
               var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }


                //get  list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_fc_to_hub_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                var dbParams1 = new DbParameter[]
             {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
             };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_fc_to_hub_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get drop list
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_drop_delivery_fc_to_hub_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Fc_To_Hub_DeliveryDTO reject_fc_to_hub(Fc_To_Hub_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_To_Hub_Delivery/reject_fc_to_hub";
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
                var spName = "call sp_reject_to_pickup_from_fc_to_hub(:in_user_id,:in_consignment_id,:in_delivery_executive_id,:in_reasion)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Reject";
                }
                else
                {
                    dto.status = "Failed";
                }


                //get  list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_fc_to_hub_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                var dbParams1 = new DbParameter[]
             {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
             };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_fc_to_hub_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get drop list
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_drop_delivery_fc_to_hub_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        public Fc_To_Hub_DeliveryDTO pickup_fc_to_hub(Fc_To_Hub_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_To_Hub_Delivery/accept_fc_to_hub";
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
                var spName = "call sp_pickup_from_fc_to_hub(:in_user_id,:in_consignment_id)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }


                //get  list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_fc_to_hub_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                var dbParams1 = new DbParameter[]
             {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
             };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_fc_to_hub_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get drop list
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_drop_delivery_fc_to_hub_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Fc_To_Hub_DeliveryDTO deliver_from_fc_to_hub(Fc_To_Hub_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_To_Hub_Delivery/deliver_from_fc_to_hub";
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
                var spName = "call sp_drop_from_fc_to_hub(:in_user_id,:in_consignment_id)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }

                //get  list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_request_delivery_fc_to_hub_list";
                dto.request_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                var dbParams1 = new DbParameter[]
             {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
             };
                Params = dbParams1;
                dto.procedure_name = "fn_get_pickup_delivery_fc_to_hub_list";
                dto.pickup_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                //get drop list
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_drop_delivery_fc_to_hub_list";
                dto.drop_delivery_list = _sql.fn_get_list(dto.procedure_name, dbParams4);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
       

    }
}
