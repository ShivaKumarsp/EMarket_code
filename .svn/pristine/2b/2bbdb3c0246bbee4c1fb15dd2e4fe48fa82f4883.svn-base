using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Master
{
    public class Master_Transport: IMaster_Transport
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        ValidationClass _valid = new ValidationClass();
        int status = 0;
        List<string> ret_validation = new List<string>();
        public Master_Transport(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Master_TransportDTO get_data(Master_TransportDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Transport/get_data";
            var Params = new DbParameter[] { };
            try
            {
                //get hub list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get transport mode list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)                    
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_transport_mode";
                dto.transport_mode_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                //get transport  list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_transport_list";
                dto.transport_list = _sql.Get_Data(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Master_TransportDTO save_transport(Master_TransportDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Transport/save_transport";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            if (dto.source_hub_id == 0 || dto.source_hub_id == null)
            {
                ret_validation.Add("Please Select Source Hub");
            }
            if (dto.transport_mode_id == 0 || dto.transport_mode_id == null)
            {
                ret_validation.Add("Please Select Transport Mode");
            }
            if (dto.transport_contact_no == 0 || dto.transport_contact_no == null)
            {
                ret_validation.Add("Please Enter Transport Contact Number");
            }
            var mob = _valid.Is_Valid_Mobile(dto.transport_contact_no);
            if (mob == false)
            {
                ret_validation.Add("Please Enter Valid Mobile Number");
            }

            if (dto.transport_contact_email == "" || dto.transport_contact_email == null)
            {
                ret_validation.Add("Please Enter Transport Email");
            }
            var eml = _valid.Is_Valid_Email(dto.transport_contact_email);
            if (eml == false)
            {
                ret_validation.Add("Please Enter Valid Email");

            }

            if (dto.transport_person_name == "" || dto.transport_person_name == null)
            {
                ret_validation.Add("Please Enter Transport Persion Name");
            }
            if (dto.transport_registration_no == "" || dto.transport_registration_no == null)
            {
                ret_validation.Add("Please Enter Transport Registration number");
            }
           
            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }

            try
            {


                var dbParams4 = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_transport_id", dto.transport_id),
                    DbHelper.CreateParameter("in_source_hub_id", dto.source_hub_id),
                    DbHelper.CreateParameter("in_transport_mode_id", dto.transport_mode_id),
                    DbHelper.CreateParameter("in_transport_contact_no", dto.transport_contact_no),
                    DbHelper.CreateParameter("in_transport_contact_email", dto.transport_contact_email),
                    DbHelper.CreateParameter("in_transport_person_name", dto.transport_person_name),
                    DbHelper.CreateParameter("in_transport_registration_no", dto.transport_registration_no),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),

                };
                Params = dbParams4;
                var spName = "call sp_save_master_transport(:in_transport_id, :in_source_hub_id,:in_transport_mode_id,:in_transport_contact_no,:in_transport_contact_email,:in_transport_person_name,:in_transport_registration_no,:in_language_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                if (status == -1)
                {
                    if (dto.transport_id > 0)
                    {
                        dto.status = "Insert";
                        dto.message = "Transport Updated Successfully";
                    }
                    else
                    {
                        dto.status = "Insert";
                        dto.message = "Transport Inserted Successfully";
                    }

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Transport Inserte/Update Failed";
                }

                //get hub list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get transport mode list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_transport_mode";
                dto.transport_mode_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                //get transport  list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_transport_list";
                dto.transport_list = _sql.Get_Data(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Master_TransportDTO delete_transport(Master_TransportDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Transport/delete_transport";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            try
            {
                var dbParams4 = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_transport_id", dto.transport_id)

                };
                Params = dbParams4;
                var spName = "call sp_delete_master_transport(:in_transport_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                if (status == -1)
                {
                    dto.status = "Insert";
                    dto.message = "Pincode Deleted Successfully";

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Pincode Delete Failed";
                }
                //get hub list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get transport mode list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_transport_mode";
                dto.transport_mode_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                //get transport  list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_transport_list";
                dto.transport_list = _sql.Get_Data(dto.procedure_name, dbParams2);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
    }
}
