using EMarket.DLL.Comman_Data;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
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
    public class User_Creation_Repository: IUser_Creation_Repository
    {
        PostgreSqlContext _context;
        comman_class conn = new comman_class();
        int status = 0;
        List<string> invalue = new List<string>();

        public User_Creation_Repository(PostgreSqlContext context)
        {
            _context = context;
        }

        public UserCreationDTO change_password(UserCreationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "User_Creation_Repository/change_password";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            var dbParams3 = new DbParameter[]
               {
                    DbHelper.CreateParameter("hubpass", dto.Password),
                    DbHelper.CreateParameter("userid", dto.hub_user_id),
               };
            Params = dbParams3;
            var spName = "call sp_change_hub_password(:hubpass,:userid)";
            status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
            if (status == -1)
            {
                    dto.status = "Update";
                    dto.message = "Updated Successfully";
            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed Update";
            }

            return dto;

        }

        public UserCreationDTO save_vehicle_data(UserCreationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "User_Creation_Repository/create_facilitation";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
          
            var dbParams3 = new DbParameter[]
               {
                    DbHelper.CreateParameter("in_hub_vehicle_id", dto.hub_vehicle_id),
                    DbHelper.CreateParameter("in_hub_id", dto.hub_id),
                    DbHelper.CreateParameter("in_vehicle_type_id", dto.vehicle_type_id),
                    DbHelper.CreateParameter("in_vehicle_reg_number", dto.vehicle_reg_number),
                    DbHelper.CreateParameter("in_vehicle_details", dto.vehicle_details),


                    DbHelper.CreateParameter("in_is_active", dto.is_active),
                    DbHelper.CreateParameter("in_belongs_to", dto.belongs_to),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
            Params = dbParams3;
            var spName = "call sp_save_hub_vehicle(:in_hub_vehicle_id,:in_hub_id, :in_vehicle_type_id,:in_vehicle_reg_number,:in_vehicle_details,:in_is_active,:in_belongs_to,:in_user_id,:in_language_id)";
            status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
            if (status == -1)
            {
                if (dto.hub_vehicle_id > 0)
                {
                    dto.status = "Insert";
                    dto.message = "Updated Successfully";
                }
                else
                {
                    dto.status = "Insert";
                    dto.message = "Created Successfully";
                }
            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed Create/Update";
            }

            return dto;
        }
    }
}
