using EMarket.DLL.Comman_Data;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Master
{
   public class Master_Vehicle_Type_Repository: IMaster_Vehicle_Type_Repository
    {
        PostgreSqlContext _context;
        comman_class conn = new comman_class();
        int status = 0;
        List<string> invalue = new List<string>();

        public Master_Vehicle_Type_Repository(PostgreSqlContext context)
        {
            _context = context;
        }

        public Master_Vehicle_TypeDTO save_vehicle_type(Master_Vehicle_TypeDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Vehicle_Type_Repository/save_vehicle_type";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

           

                var dbParams = new DbParameter[]
       {
                    DbHelper.CreateParameter("in_vehicle_type_id", dto.vehicle_type_id),
                    DbHelper.CreateParameter("in_vehicle_type",dto.vehicle_type),
                    DbHelper.CreateParameter("in_vehicle_type_details", dto.vehicle_type_details),
                    DbHelper.CreateParameter("in_max_weight", dto.max_weight),
                    DbHelper.CreateParameter("in_max_volumetric_length", dto.max_volumetric_length),
                    DbHelper.CreateParameter("in_max_volumetric_breadth", dto.max_volumetric_breadth),
                    DbHelper.CreateParameter("in_max_volumetric_height", dto.max_volumetric_height),
                    DbHelper.CreateParameter("in_pickup_type", dto.pickup_type),
                    DbHelper.CreateParameter("in_pickup_volumetric_length", dto.pickup_volumetric_length),
                    DbHelper.CreateParameter("in_pickup_volumetric_breadth", dto.pickup_volumetric_breadth),
                    DbHelper.CreateParameter("in_pickup_volumetric_heigth", dto.pickup_volumetric_heigth),
                     DbHelper.CreateParameter("in_user_id", dto.user_id)
       };
                Params = dbParams;
                var spName = "call sp_save_vehicle_type(:in_vehicle_type_id, :in_vehicle_type,:in_vehicle_type_details,:in_max_weight,:in_max_volumetric_length,:in_max_volumetric_breadth,:in_max_volumetric_height,:in_pickup_type,:in_pickup_volumetric_length,:in_pickup_volumetric_breadth,:in_pickup_volumetric_heigth,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
            
            if (status == -1)
            {
                if(dto.vehicle_type_id>0)
                {
                    dto.status = "Insert";
                    dto.message = "Updated Successfully";

                }
                else
                {
                    dto.status = "Insert";
                    dto.message = "Inserted Successfully";

                }
            
            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed To Insert/Update";
            }

            return dto;
        }

    }
}
