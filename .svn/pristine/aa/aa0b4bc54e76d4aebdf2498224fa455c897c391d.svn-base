using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarket.Entities.Admin;
using EMarketDTO.Admin;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class Hub_Route: IHub_Route
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        int status = 0;
        List<string> ret_validation = new List<string>();
        IHub_Route_Repository _inter;
        public Hub_Route(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IHub_Route_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public Hub_RouteDTO get_data(Hub_RouteDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_Route/get_data";
            var Params = new DbParameter[] { };
            try
            {


                //get hub list 1
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list_1 = _sql.Get_Data(dto.procedure_name, dbParams);

                //get all list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_hub_route_list";
                dto.hub_route_list = _sql.Get_Data(dto.procedure_name, dbParams2);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Hub_RouteDTO get_transport_type(Hub_RouteDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_Route/get_transport_type";
            var Params = new DbParameter[] { };
            try
            {


                //get hub list 1
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", dto.source_hub_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_transportation_type";
                dto.transportation_type_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get hub list 2
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                       DbHelper.CreateParameter("in_source_hub_id", dto.source_hub_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list_2 = _sql.Get_Data(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Hub_RouteDTO save_hub_route(Hub_RouteDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_Route/save_hub_route";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            if (dto.source_hub_id == 0 || dto.source_hub_id == null)
            {
                ret_validation.Add("Please Select Source Hub");
            }
            if (dto.destination_hub_id == 0 || dto.destination_hub_id == null)
            {
                ret_validation.Add("Please Select Destination Hub");
            }
            if (dto.transport_id == 0 || dto.transport_id == null)
            {
                ret_validation.Add("Please Select Transport Type");
            }
            if (dto.distance == 0 || dto.distance == null)
            {
                ret_validation.Add("Please Enter Distance");
            }
            if (dto.departure_time == null)
            {
                ret_validation.Add("Please Enter Departure Time");
            }
            if (dto.travel_time_hour==0)
            {
                if (dto.travel_time_minute == 0 || dto.travel_time_minute == null)
                {
                    ret_validation.Add("Please Enter Travel Time");
                }
            }
            
           
            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }



            try
            {

                _inter.save_hub_route(dto);
                //    var dbParams = new DbParameter[]
                //       {
                //        DbHelper.CreateParameter("in_hub_route_id", dto.hub_route_id),
                //        DbHelper.CreateParameter("in_source_hub_id", dto.source_hub_id),
                //        DbHelper.CreateParameter("in_destination_hub_id", dto.destination_hub_id),
                //        DbHelper.CreateParameter("in_transport_id", dto.transport_id),
                //        DbHelper.CreateParameter("in_distance", dto.distance),
                //        DbHelper.CreateParameter("in_travel_time_hour", dto.travel_time_hour),
                //        DbHelper.CreateParameter("in_travel_time_minute", dto.travel_time_minute),
                //        DbHelper.CreateParameter("in_departure_time",dto.departure_time),
                //        DbHelper.CreateParameter("in_language_id", dto.language_id),

                //};
                //    Params = dbParams;
                //    var spName = "call sp_save_hub_route(:in_hub_route_id, :in_source_hub_id,:in_destination_hub_id,:in_transport_id,:in_distance,:in_travel_time_hour, :in_travel_time_minute,:in_departure_time,:in_language_id)";
                //    status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);


                //if (status == -1)
                //{
                //    if (dto.hub_route_id > 0)
                //    {
                //        dto.status = "Insert";
                //        dto.message = "Hub Route Updated Successfully";
                //    }
                //    else
                //    {
                //        dto.status = "Insert";
                //        dto.message = "Hub Route Inserted Successfully";
                //    }

                //}
                //else
                //{
                //    dto.status = "Failed";
                //    dto.message = "Hub Route Inserte/Update Failed";
                //}


                //get hub list 1
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                        DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list_1 = _sql.Get_Data(dto.procedure_name, dbParams1);


              
                //get all list
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_hub_route_list";
                dto.hub_route_list = _sql.Get_Data(dto.procedure_name, dbParams3);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Hub_RouteDTO delete_hub_route(Hub_RouteDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_Route/delete_hub_route";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
         

            try
            {
                _inter.delete_hub_route(dto);


                //get hub list 1
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                        DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list_1 = _sql.Get_Data(dto.procedure_name, dbParams1);



                //get all list
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_hub_route_list";
                dto.hub_route_list = _sql.Get_Data(dto.procedure_name, dbParams3);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
    }
}
