using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.HubManager;
using EMarket.Entities;
using EMarket.Entities.Facilitation;
using EMarketDTO.HubManager;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.HubManager
{
    public class Assign_Hub_to_Hub: IAssign_Hub_to_Hub
    {
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;

        public Assign_Hub_to_Hub(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Assign_Hub_to_HubDTO get_data(Assign_Hub_to_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_Hub_to_Hub/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;

                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id),
                      DbHelper.CreateParameter("in_route_id", 0)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_to_hub_list";
                dto.hub_to_hub_list = _sql.Get_Data(dto.procedure_name, dbParams);


                //executive_list_dd
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub_executive_list_dd";
                dto.executive_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //hub vehicle_list
                var dbParams2 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_hub_vehicle_list_dd";
                dto.hub_vehicle_list_dd = _sql.Get_Data(dto.procedure_name, dbParams2);

                //hub transport
                var dbParams3 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_hub_transport_route";
                dto.hub_transport_route = _sql.Get_Data(dto.procedure_name, dbParams3);

               
                var dbParams6 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams6;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_hub_print_details";
                dto.batch_print_details = _sql.Get_Data(dto.procedure_name, dbParams6);


                var dbParams7 = new DbParameter[]
         {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
         };
                Params = dbParams7;
                dto.procedure_name = "fn_get_assign_pickup_from_pt_to_hub";
                dto.assign_pickup_from_pt_to_hub = _sql.Get_Data(dto.procedure_name, dbParams7);


                dto.procedure_name = "";

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
        public Assign_Hub_to_HubDTO get_route_data(Assign_Hub_to_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_Hub_to_Hub/get_route_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;

                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id),
                       DbHelper.CreateParameter("in_route_id", dto.route_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_to_hub_list";
                dto.hub_to_hub_list = _sql.Get_Data(dto.procedure_name, dbParams);



                dto.procedure_name = "";

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
        public Assign_Hub_to_HubDTO save_hub_to_hub(Assign_Hub_to_HubDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_Hub_to_Hub/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;

                Consignment_BatchDMO dmo12 = new Consignment_BatchDMO();
                dmo12.send_by_role_id = 8;
                dmo12.send_by_status_id = 6;
                dmo12.receive_by_role_id = 8;
                dmo12.receive_by_status_id = 1;
                dmo12.created_by = dto.user_id;
                dmo12.created_on = DateTime.UtcNow;
                _context.Add(dmo12);
                _context.SaveChanges();

              

                    foreach (var item in dto.hu_to_hub_array)
                    {
                        Consignment_Batch_TxrDMO con_txr = new Consignment_Batch_TxrDMO();
                        con_txr.batch_id = dmo12.batch_id;
                        con_txr.consignment_id = item.consignment_id;
                        con_txr.send_by_role_id = 8;
                        con_txr.send_by_status_id = 6;
                        con_txr.receive_by_role_id = 8;
                        con_txr.receive_by_status_id = 1;
                        con_txr.created_by = dto.user_id;
                        con_txr.created_on = DateTime.UtcNow;
                        _context.Add(con_txr);
                        var ss = _context.SaveChanges();

                   long vh = 0;
                        var dbParams4 = new DbParameter[]
                         {
                             
                    DbHelper.CreateParameter("in_batch_id", dmo12.batch_id),
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_tracking_id", item.tracking_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_hub_route_id", dto.hub_route_id),
                    DbHelper.CreateParameter("in_last_hub_id", item.last_hub_id),
                    DbHelper.CreateParameter("in_last_facilitation_id", item.last_facilitation_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_own_vehicle", vh),
                    DbHelper.CreateParameter("in_hub_vehicle_id", vh)
                         };

                        Params = dbParams4;
                        var spName = "call sp_pickup_assign_from_hub_to_hub(:in_batch_id,:in_consignment_id,:in_tracking_id,:in_delivery_executive_id,:in_hub_route_id,:in_last_hub_id,:in_last_facilitation_id,:in_user_id,:in_language_id,:in_own_vehicle,:in_hub_vehicle_id)";
                        var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                        if (status == -1)
                        {
                            dto.status = "Insert";
                            dto.message = "Item Assigned Successfully";

                        }
                        else
                        {
                            dto.status = "Failed";
                            dto.message = "Failed To Item Assign";

                        }
                    }
                



                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id),
                      DbHelper.CreateParameter("in_route_id", 0)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_to_hub_list";
                dto.hub_to_hub_list = _sql.Get_Data(dto.procedure_name, dbParams);


                //executive_list_dd
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub_executive_list_dd";
                dto.executive_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //hub vehicle_list
                var dbParams2 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_hub_vehicle_list_dd";
                dto.hub_vehicle_list_dd = _sql.Get_Data(dto.procedure_name, dbParams2);

                //hub transport
                var dbParams3 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_hub_transport_route";
                dto.hub_transport_route = _sql.Get_Data(dto.procedure_name, dbParams3);

                var dbParams6 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                       DbHelper.CreateParameter("in_hub_id", dto.hub_id)
              };
                Params = dbParams6;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_hub_print_details";
                dto.batch_print_details = _sql.Get_Data(dto.procedure_name, dbParams6);

                var dbParams7 = new DbParameter[]
        {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
        };
                Params = dbParams7;
                dto.procedure_name = "fn_get_assign_pickup_from_pt_to_hub";
                dto.assign_pickup_from_pt_to_hub = _sql.Get_Data(dto.procedure_name, dbParams7);


                dto.procedure_name = "";

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
        public Assign_Hub_to_HubDTO hub_to_hub_print_data(Assign_Hub_to_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_Hub_to_Hub/hub_to_hub_print_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;

                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id),
                      DbHelper.CreateParameter("in_batch_id", dto.batch_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_to_hub_print_list";
                dto.hub_to_hub_print_list = _sql.Get_Data(dto.procedure_name, dbParams);            
             

              
                dto.procedure_name = "";

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
        public Assign_Hub_to_HubDTO assign_pickup_from_pt_to_hub(Assign_Hub_to_HubDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_Hub_to_Hub/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;


                foreach (var item in dto.pt_to_hub_array)
                {                   

                    long vh = 0;
                    var dbParams4 = new DbParameter[]
                     {
                   
                    DbHelper.CreateParameter("in_batch_id", item.batch_id),
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id), 
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_own_vehicle", vh),
                    DbHelper.CreateParameter("in_hub_vehicle_id", vh)
                     };

                    Params = dbParams4;
                    var spName = "call sp_pickup_assign_from_pt_to_hub(:in_batch_id,:in_consignment_id,:in_delivery_executive_id,:in_user_id,:in_language_id,:in_own_vehicle,:in_hub_vehicle_id)";
                    var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                    if (status == -1)
                    {
                        dto.status = "Insert";
                        dto.message = "Item Assigned Successfully";

                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Failed To Item Assign";

                    }
                }




                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id),
                      DbHelper.CreateParameter("in_route_id", 0)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_to_hub_list";
                dto.hub_to_hub_list = _sql.Get_Data(dto.procedure_name, dbParams);


                //executive_list_dd
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub_executive_list_dd";
                dto.executive_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //hub vehicle_list
                var dbParams2 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_hub_vehicle_list_dd";
                dto.hub_vehicle_list_dd = _sql.Get_Data(dto.procedure_name, dbParams2);

                //hub transport
                var dbParams3 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_hub_transport_route";
                dto.hub_transport_route = _sql.Get_Data(dto.procedure_name, dbParams3);

                var dbParams6 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                       DbHelper.CreateParameter("in_hub_id", dto.hub_id)
              };
                Params = dbParams6;
                dto.procedure_name = "fn_get_pickup_delivery_hub_to_hub_print_details";
                dto.batch_print_details = _sql.Get_Data(dto.procedure_name, dbParams6);

                var dbParams7 = new DbParameter[]
        {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
        };
                Params = dbParams7;
                dto.procedure_name = "fn_get_assign_pickup_from_pt_to_hub";
                dto.assign_pickup_from_pt_to_hub = _sql.Get_Data(dto.procedure_name, dbParams7);


                dto.procedure_name = "";

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
