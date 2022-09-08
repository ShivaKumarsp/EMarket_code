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
    public class Master_Country : IMaster_Country
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        int status = 0;
        List<string> ret_validation = new List<string>();
        public Master_Country(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        // Country
        public Master_CountryDTO get_data_country(Master_CountryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Country/get_data_country";
            var Params = new DbParameter[] { };
            try
            {
                //get all Country List
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_country_list";
                dto.country_list = _sql.Get_Data(dto.procedure_name, dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Master_CountryDTO save_country(Master_CountryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Country/save_country";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            if (dto.country_name == "" || dto.country_name == null)
            {
                ret_validation.Add("Please Enter Country Name");
            }
            
            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }

            try
            {
                if (dto.country_id > 0)
                {
                    var result = _context.Master_CountryDMO_con.Where(a => a.country_name.ToLower() == dto.country_name.ToLower() && a.country_id != dto.country_id).ToList();
                    if (result.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Country Name Already Exist";
                        return dto;
                    }
                }
                if (dto.country_id == 0)
                {
                    var result = _context.Master_CountryDMO_con.Where(a => a.country_name.ToLower() == dto.country_name.ToLower()).ToList();
                    if (result.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Country Name Already Exist";
                        return dto;
                    }
                }


                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_country_id", dto.country_id),
                    DbHelper.CreateParameter("in_country_name", dto.country_name),
                    DbHelper.CreateParameter("in_activeflg", dto.activeflg),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                         };
                Params = dbParams;
                var spName = "call sp_save_master_country(:in_country_id, :in_country_name,:in_activeflg,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    if (dto.country_id > 0)
                    {
                        dto.status = "Insert";
                        dto.message = "Country Updated Successfully";
                    }
                    else
                    {
                        dto.status = "Insert";
                        dto.message = "Country Inserted Successfully";
                    }

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Country Inserte/Update Failed";
                }

                //get all Country List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_country_list";
                dto.country_list = _sql.Get_Data(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Master_CountryDTO delete_country(Master_CountryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Country/delete_country";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            try
            {
                var result = _context.Master_StateDMO_con.Where(a => a.country_id == dto.country_id).ToList();
                if (result.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "Country Name Already Mapped, You Can't Delete";
                    return dto;
                }

                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_country_id", dto.country_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
                };
                Params = dbParams;
                var spName = "call sp_delete_master_country(:in_country_id,:in_language_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.status = "Delete";
                    dto.message = "Country Deleted Successfully";

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Country Delete Failed";
                }

                //get all Country List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_country_list";
                dto.country_list = _sql.Get_Data(dto.procedure_name, dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        // State
        public Master_CountryDTO get_data_state(Master_CountryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Country/get_data_state";
            var Params = new DbParameter[] { };
            try
            {
                //get all Country List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_country";
                dto.country_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //get all State List
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_state_list";
                dto.state_list = _sql.Get_Data(dto.procedure_name, dbParams2);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Master_CountryDTO save_state(Master_CountryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Country/save_state";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            if (dto.state_name == "" || dto.state_name == null)
            {
                ret_validation.Add("Please Enter State Name");
            }
            if (dto.country_id == 0 || dto.country_id == null)
            {
                ret_validation.Add("Please Select Country");
            }

            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }

            try
            {
                if (dto.state_id > 0)
                {
                    var result = _context.Master_StateDMO_con.Where(a => a.country_id == dto.country_id && a.state_id != dto.state_id && a.state_name.ToLower() == dto.state_name.ToLower()).ToList();
                    if (result.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "State Name Already Exist";
                        return dto;
                    }
                }
                if (dto.state_id == 0)
                {
                    var result = _context.Master_StateDMO_con.Where(a => a.country_id == dto.country_id && a.state_name.ToLower() == dto.state_name.ToLower()).ToList();
                    if (result.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "State Name Already Exist";
                        return dto;
                    }
                }


                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_country_id", dto.country_id),
                    DbHelper.CreateParameter("in_state_id", dto.state_id),
                    DbHelper.CreateParameter("in_state_name", dto.state_name),
                    DbHelper.CreateParameter("in_activeflg", dto.activeflg),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                         };
                Params = dbParams;
                var spName = "call sp_save_master_state(:in_country_id, :in_state_id,:in_state_name,:in_activeflg,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    if (dto.state_id > 0)
                    {
                        dto.status = "Insert";
                        dto.message = "State Updated Successfully";
                    }
                    else
                    {
                        dto.status = "Insert";
                        dto.message = "State Inserted Successfully";
                    }

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "State Inserte/Update Failed";
                }
                //get all Country List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_country";
                dto.country_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //get all State List
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_state_list";
                dto.state_list = _sql.Get_Data(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Master_CountryDTO delete_state(Master_CountryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Country/delete_state";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            try
            {
                var result = _context.Master_CityDMO_con.Where(a => a.state_id == dto.state_id).ToList();
                if (result.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "State Name Already Mapped, You Can't Delete";
                    return dto;
                }

                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_state_id", dto.state_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
                };
                Params = dbParams;
                var spName = "call sp_delete_master_state(:in_state_id,:in_language_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.status = "Delete";
                    dto.message = "State Deleted Successfully";

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "State Delete Failed";
                }

                //get all Country List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_country";
                dto.country_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //get all State List
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_state_list";
                dto.state_list = _sql.Get_Data(dto.procedure_name, dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        // city
        public Master_CountryDTO get_data_city(Master_CountryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Country/get_data_city";
            var Params = new DbParameter[] { };
            try
            {
                //get all Country List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_country";
                dto.country_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //get all State List
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_city_list";
                dto.city_list = _sql.Get_Data(dto.procedure_name, dbParams2);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Master_CountryDTO get_state(Master_CountryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Country/get_state";
            var Params = new DbParameter[] { };
            try
            {
                //get all Country List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("pcountryid", dto.country_id),
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_states";
                dto.state_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Master_CountryDTO save_city(Master_CountryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Country/save_city";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            if (dto.city_name == "" || dto.city_name == null)
            {
                ret_validation.Add("Please Enter City Name");
            }
            if (dto.country_id == 0 || dto.country_id == null)
            {
                ret_validation.Add("Please Select Country");
            }
             if (dto.state_id == 0 || dto.state_id == null)
            {
                ret_validation.Add("Please Select State");
            }

            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }

            try
            {
                if (dto.city_id > 0)
                {
                    var result = _context.Master_CityDMO_con.Where(a => a.country_id == dto.country_id && a.state_id == dto.state_id && a.city_id!=dto.city_id && a.city_name.ToLower() == dto.city_name.ToLower()).ToList();
                    if (result.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "City Name Already Exist";
                        return dto;
                    }
                }
                if (dto.city_id == 0)
                {
                    var result = _context.Master_CityDMO_con.Where(a => a.country_id == dto.country_id && a.state_id==dto.state_id && a.city_name.ToLower() == dto.city_name.ToLower()).ToList();
                    if (result.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "City Name Already Exist";
                        return dto;
                    }
                }


                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_city_id", dto.city_id),
                    DbHelper.CreateParameter("in_country_id", dto.country_id),
                    DbHelper.CreateParameter("in_state_id", dto.state_id),
                    DbHelper.CreateParameter("in_city_name", dto.city_name),
                    DbHelper.CreateParameter("in_activeflg", dto.activeflg),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                         };
                Params = dbParams;
                var spName = "call sp_save_master_city(:in_city_id,:in_country_id,:in_state_id,:in_city_name,:in_activeflg,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    if (dto.state_id > 0)
                    {
                        dto.status = "Insert";
                        dto.message = "City Updated Successfully";
                    }
                    else
                    {
                        dto.status = "Insert";
                        dto.message = "City Inserted Successfully";
                    }

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "City Inserte/Update Failed";
                }

                //get all Country List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_country";
                dto.country_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //get all State List
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_city_list";
                dto.city_list = _sql.Get_Data(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Master_CountryDTO delete_city(Master_CountryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Country/delete_state";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            try
            {
                //var result = _context.Master_CityDMO_con.Where(a => a.state_id == dto.state_id).ToList();
                //if (result.Count > 0)
                //{
                //    dto.status = "Failed";
                //    dto.message = "City Name Already Mapped, You Can't Delete";
                //    return dto;
                //}

                var dbParams = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_city_id", dto.city_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
                };
                Params = dbParams;
                var spName = "call sp_delete_master_city(:in_city_id,:in_language_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.status = "Delete";
                    dto.message = "City Deleted Successfully";

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "City Delete Failed";
                }


                //get all Country List
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_country";
                dto.country_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //get all State List
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_city_list";
                dto.city_list = _sql.Get_Data(dto.procedure_name, dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
    }
}
