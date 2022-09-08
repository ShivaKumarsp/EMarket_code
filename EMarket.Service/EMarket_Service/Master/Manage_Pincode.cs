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
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Master
{
    public class Manage_Pincode : IManage_Pincode
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        int status = 0;
        List<string> ret_validation = new List<string>();
        public Manage_Pincode(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

        public Manage_PincodeDTO get_data(Manage_PincodeDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Manage_Pincode/get_data";
            var Params = new DbParameter[] { };
            try
            {


                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_country";
                dto.country_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get all pincode list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id",dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_all_pincode_list";
                dto.all_pincode_list = _sql.Get_Data(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Manage_PincodeDTO get_state(Manage_PincodeDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Manage_Pincode/get_state";
            var Params = new DbParameter[] { };
            try
            {


                //get state
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("languageid", dto.language_id),
                      DbHelper.CreateParameter("countryid", dto.country_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_getstate";
                dto.state_list = _sql.Get_Data(dto.procedure_name, dbParams);



            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Manage_PincodeDTO get_city(Manage_PincodeDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Manage_Pincode/get_city";
            var Params = new DbParameter[] { };
            try
            {


                //get state
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_country_id", dto.country_id),
                      DbHelper.CreateParameter("in_state_id", dto.state_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_city";
                dto.city_list = _sql.Get_Data(dto.procedure_name, dbParams);



            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        public Manage_PincodeDTO save_pincode(Manage_PincodeDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Manage_Pincode/save_pincode";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            if (dto.country_id == 0 || dto.country_id == null)
            {
                ret_validation.Add("Please Select Country");
            }
            if (dto.state_id == 0 || dto.state_id == null)
            {
                ret_validation.Add("Please Select State");
            }
            if (dto.city_id == 0 || dto.city_id == null)
            {
                ret_validation.Add("Please Select State");
            }
            if (dto.pincode == 0 || dto.pincode == null)
            {
                ret_validation.Add("Please Enter City");
            }
            if (dto.pincode.ToString().Length < 6)
            {
                ret_validation.Add("Please Enter 6 Digit Pincode");
            }
            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }

            try
            {
                if(dto.pincode_id>0)
                {
                    var result = _context.Master_PincodeDMO_con.Where(a => a.pincode == dto.pincode && a.pincode_id != dto.pincode_id && a.area!=dto.area).ToList();
                    if(result.Count>0)
                    {
                        dto.status = "Failed";
                        dto.message = "Pincode And Area Already Exist";
                        return dto;
                    }
                }
                if (dto.pincode_id == 0)
                {
                    var result = _context.Master_PincodeDMO_con.Where(a => a.pincode == dto.pincode && a.area==dto.area).ToList();
                    if (result.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Pincode And Area Already Exist";
                        return dto;
                    }
                }


                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_pincode_id", dto.pincode_id),
                    DbHelper.CreateParameter("in_pincode", dto.pincode),
                    DbHelper.CreateParameter("in_country_id", dto.country_id),
                    DbHelper.CreateParameter("in_state_id", dto.state_id),
                    DbHelper.CreateParameter("in_city_id", dto.city_id),
                    DbHelper.CreateParameter("in_area", dto.area),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),

                };
                Params = dbParams;
                var spName = "call sp_save_master_pincode(:in_pincode_id, :in_pincode,:in_country_id,:in_state_id,:in_city_id,:in_area, :in_language_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    if(dto.pincode_id>0)
                    {
                        dto.status = "Insert";
                        dto.message = "Pincode Updated Successfully";
                    }
                    else
                    {
                        dto.status = "Insert";
                        dto.message = "Pincode Inserted Successfully";
                    }
               
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Pincode Inserte/Update Failed";
                }
                //get all vendor list
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_country";
                dto.country_list = _sql.Get_Data(dto.procedure_name, dbParams4);

                //get all pincode list
                var dbParams5 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id",dto.language_id)
               };
                Params = dbParams5;
                dto.procedure_name = "fn_get_all_pincode_list";
                dto.all_pincode_list = _sql.Get_Data(dto.procedure_name, dbParams5);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Manage_PincodeDTO delete_pincode(Manage_PincodeDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Manage_Pincode/delete_pincode";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);         

            try
            {     
                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_pincode_id", dto.pincode_id)                 

                };
                Params = dbParams;
                var spName = "call sp_delete_master_pincode(:in_pincode_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
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
                //get all vendor list
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_country";
                dto.country_list = _sql.Get_Data(dto.procedure_name, dbParams4);

                //get all pincode list
                var dbParams5 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id",dto.language_id)
               };
                Params = dbParams5;
                dto.procedure_name = "fn_get_all_pincode_list";
                dto.all_pincode_list = _sql.Get_Data(dto.procedure_name, dbParams5);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
    }
}
