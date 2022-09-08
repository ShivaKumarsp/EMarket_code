using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Master;
using EMarket.DLL.Comman_Data;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Master
{
    public class Master_Vehicle_Type : IMaster_Vehicle_Type
    {
        SqlHelper sqlHelper = new SqlHelper();
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        int status = 0;
        ValidationClass _valid = new ValidationClass();
        IMaster_Vehicle_Type_Repository _inter;
        List<string> ret_validation = new List<string>();
        public Master_Vehicle_Type(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IMaster_Vehicle_Type_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }
        public Master_Vehicle_TypeDTO get_data(Master_Vehicle_TypeDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Vehicle_TypeDTO/get_data";
            var dbParams0 = new DbParameter[] { };

            try
            {
                //get executive list
                var dbParams5 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                dbParams0 = dbParams5;
                dto.procedure_name = "fn_get_vehicle_type_list";
                dto.vehicle_type_list = _sql.Get_Data(dto.procedure_name, dbParams5);



            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dbParams0);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }

            return dto;
        }
        public Master_Vehicle_TypeDTO save_vehicle_type(Master_Vehicle_TypeDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Vehicle_TypeDTO/save_vehicle_type";
            var dbParams0 = new DbParameter[] { };

            try
            {
                if (dto.vehicle_type == "" || dto.vehicle_type == null)
                {
                    ret_validation.Add("Enter Vehicle Type");
                }
                if (dto.vehicle_type_details == "" || dto.vehicle_type_details == null)
                {
                    ret_validation.Add("Enter Vehicle Type Details");
                }
                if (dto.max_weight <= 0)
                {
                    ret_validation.Add("Enter Max Weight");
                }
                if (dto.max_volumetric_length <= 0)
                {
                    ret_validation.Add("Enter Max Volumetric Length");
                }

                if (dto.max_volumetric_breadth <= 0)
                {
                    ret_validation.Add("Enter Max Volumetric Breadth");
                }
                if (dto.max_volumetric_height <= 0)
                {
                    ret_validation.Add("Enter Max Volumetric Height");
                }
                if (dto.pickup_type == "" || dto.pickup_type == null)
                {
                    ret_validation.Add("Select Pickup Type");
                }
                if (dto.pickup_volumetric_length <= 0)
                {
                    ret_validation.Add("Enter Pickup Volumetric Length");
                }
                if (dto.pickup_volumetric_breadth <= 0)
                {
                    ret_validation.Add("Enter Pickup Volumetric Breadth");
                }
                if (dto.pickup_volumetric_heigth <= 0)
                {
                    ret_validation.Add("Enter Pickup Volumetric Height");
                }



                if (ret_validation.Count > 0)
                {
                    dto.status = "Validation";
                    dto.validation_list = ret_validation.ToArray();
                    return dto;
                }


                _inter.save_vehicle_type(dto);

                var dbParams5 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                dbParams0 = dbParams5;
                dto.procedure_name = "fn_get_vehicle_type_list";
                dto.vehicle_type_list = _sql.Get_Data(dto.procedure_name, dbParams5);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dbParams0);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }

            return dto;
        }
    }
}
