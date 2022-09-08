using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.HubManager;
using EMarket.Entities;
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
    public class Assign_FcHub_Hub: IAssign_FcHub_Hub
    {
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;

        public Assign_FcHub_Hub(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }


        public Assign_FcHub_HubDTO get_data(Assign_FcHub_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_FcHub_Hub/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;
                
                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_executive_list_dd";
                dto.executive_list_dd = _sql.Get_Data(dto.procedure_name, dbParams);

                //hub vehicle_list
                var dbParams1 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub_vehicle_list_dd";
                dto.hub_vehicle_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //hub vehicle_list
                var dbParams2 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_consignment_fc_to_hub";
                dto.consignment_fc_hub_list = _sql.fn_get_list(dto.procedure_name, dbParams2);





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
        public Assign_FcHub_HubDTO save_fchub_hubfc(Assign_FcHub_HubDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_FcHub_Hub/save_fchub_hubfc";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;


                foreach (var item in dto.consignment_array_fc_hub)
                {
                    var dbParams4 = new DbParameter[]
                     {
                    DbHelper.CreateParameter("in_batch_id", 0),
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_tracking_id", item.tracking_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
                     };

                    Params = dbParams4;
                    var spName = "call sp_picku_assign_from_fc_to_hub(:in_batch_id,:in_consignment_id,:in_tracking_id,:in_delivery_executive_id,:in_user_id,:in_language_id)";
                    var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                    if (status == -1)
                    {
                        dto.status = "Insert";
                        dto.message = "Batch Assigned Successfully";

                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Failed To Batch Assign";

                    }
                }


                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_executive_list_dd";
                dto.executive_list_dd = _sql.Get_Data(dto.procedure_name, dbParams);

                //hub vehicle_list
                var dbParams1 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub_vehicle_list_dd";
                dto.hub_vehicle_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //hub vehicle_list
                var dbParams2 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_consignment_fc_to_hub";
                dto.consignment_fc_hub_list = _sql.fn_get_list(dto.procedure_name, dbParams2);





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
