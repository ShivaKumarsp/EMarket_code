using EMarket.DLL.Comman_Data;
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

namespace EMarket.DLL.EMarket_Repository.Admin
{
    public class Hub_Route_Repository: IHub_Route_Repository
    {
        PostgreSqlContext _context;
        comman_class conn = new comman_class();
        int status = 0;
        List<string> invalue = new List<string>();
        public Hub_Route_Repository(PostgreSqlContext context)
        {
            _context = context;

        }

        public Hub_RouteDTO save_hub_route(Hub_RouteDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_Route_Repository/save_hub_route";

            if (dto.hub_route_id > 0)
            {
                var result = _context.Hub_RouteDMO_con.Where(a => a.hub_route_id == dto.hub_route_id).SingleOrDefault();
                result.source_hub_id = dto.source_hub_id;
                result.destination_hub_id = dto.destination_hub_id;
                result.transport_id = dto.transport_id;
                result.distance = dto.distance;
                result.travel_time_hour = dto.travel_time_hour;
                result.travel_time_minute = dto.travel_time_minute;
                result.departure_time = dto.departure_time;
                _context.Update(result);
                var ss = _context.SaveChanges();
                if (ss == 1)
                {
                    dto.status = "Insert";
                    dto.message = "Hub Route Updated Successfully";

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Hub Route Update Failed";
                }

            }
            else
            {
                Hub_RouteDMO dmo = new Hub_RouteDMO();
                dmo.source_hub_id = dto.source_hub_id;
                dmo.destination_hub_id = dto.destination_hub_id;
                dmo.transport_id = dto.transport_id;
                dmo.distance = dto.distance;
                dmo.travel_time_hour = dto.travel_time_hour;
                dmo.travel_time_minute = dto.travel_time_minute;
                dmo.departure_time = dto.departure_time;
                _context.Add(dmo);
                var ss = _context.SaveChanges();
                if (ss == 1)
                {
                    dto.status = "Insert";
                    dto.message = "Hub Route Inserted Successfully";

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Hub Route Inserte Failed";
                }


            }

            return dto;
        }
        public Hub_RouteDTO delete_hub_route(Hub_RouteDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_Route_Repository/delete_hub_route";
            var Params = new DbParameter[] { };

            var dbParams = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_hub_route_id", dto.hub_route_id),

               };
            Params = dbParams;
            var spName = "call sp_delete_hub_route(:in_hub_route_id)";
            status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
            if (status == -1)
            {
                dto.status = "Insert";
                dto.message = "Hub Route Deleted Successfully";


            }
            else
            {
                dto.status = "Failed";
                dto.message = "Hub Route Delete Failed";
            }

            return dto;
        }
    }
}
