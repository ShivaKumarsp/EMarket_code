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
    public class MasterFacilitation: IMasterFacilitation
    {
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;
        int status = 0;

        public MasterFacilitation(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

        // Master Facilitation
        public MasterFacilitationDTO get_data(MasterFacilitationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "MasterFacilitation/get_data";
            var Params = new DbParameter[] { };
            try
            {

                //country list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_country";
                dto.country_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //country list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_facilitation_grid";
                dto.facilitation_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                //Hub list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams2);


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
        public MasterFacilitationDTO get_state(MasterFacilitationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "MasterFacilitation/get_state";
            var Params = new DbParameter[] { };
            try
            {

                //country list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("languageid", dto.language_id),
                      DbHelper.CreateParameter("countryid", dto.country_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_getstate";
                dto.state_list = _sql.Get_Data(dto.procedure_name, dbParams);


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
        public MasterFacilitationDTO get_city(MasterFacilitationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "MasterFacilitation/get_city";
            var Params = new DbParameter[] { };
            try
            {

                //country list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_country_id", dto.country_id),
                      DbHelper.CreateParameter("in_state_id", dto.state_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_city";
                dto.city_list = _sql.Get_Data(dto.procedure_name, dbParams);


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
        public MasterFacilitationDTO get_pincode(MasterFacilitationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "MasterFacilitation/get_pincode";
            var Params = new DbParameter[] { };
            try
            {

                //country list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_country_id", dto.country_id),
                      DbHelper.CreateParameter("in_state_id", dto.state_id),
                      DbHelper.CreateParameter("in_city_id", dto.city_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_pincode";
                dto.pincode_list = _sql.Get_Data(dto.procedure_name, dbParams);


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
        public MasterFacilitationDTO save_facilitation(MasterFacilitationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "MasterFacilitation/save_facilitation";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {

                var dbParams5 = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id),                     
                        DbHelper.CreateParameter("in_hub_id",  dto.hub_id),
                        DbHelper.CreateParameter("in_facilitation_name",  dto.facilitation_name),
                        DbHelper.CreateParameter("in_email",  dto.email),
                        DbHelper.CreateParameter("in_contact_no",  dto.contact_no),
                        DbHelper.CreateParameter("in_address",  dto.address),
                        DbHelper.CreateParameter("in_pincode",  dto.pincode),
                        DbHelper.CreateParameter("in_city_id",  dto.city_id),
                        DbHelper.CreateParameter("in_state_id",  dto.state_id),
                        DbHelper.CreateParameter("in_country_id",  dto.country_id),
                        DbHelper.CreateParameter("in_user_id",  dto.user_id),

                    };
                dto.procedure_name = "call sp_save_facilitation(:in_facilitation_id,:in_hub_id,:in_facilitation_name,:in_email,:in_contact_no,:in_address,:in_pincode,:in_city_id,:in_state_id,:in_country_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams5);

                if (status == -1)
                {
                    if(dto.facilitation_id>0)
                    {
                        dto.status = "Update";
                        dto.message = "Facilitation Updated Successfully";
                    }
                    else
                    {
                        dto.status = "Insert";
                        dto.message = "Facilitation Inserted Successfully";
                    }
                  
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Failed to Facilitation Insert/Update, Please Try Again";
                }



                //country list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_country";
                dto.country_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //country list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_facilitation_grid";
                dto.facilitation_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                //Hub list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams2);


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


        // Map Facilitation and Pincode
        public MasterFacilitationDTO get_data_fc_map(MasterFacilitationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "MasterFacilitation/get_data_fc_map";
            var Params = new DbParameter[] { };
            try
            {
                //Hub list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams2);


                //facilitation hub list
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_map_facilitation_pincode_grid";
                dto.facilitation_pincode_list = _sql.Get_Data(dto.procedure_name, dbParams3);

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
        public MasterFacilitationDTO get_facilitation_dd(MasterFacilitationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "MasterFacilitation/get_facilitation_dd";
            var Params = new DbParameter[] { };
            try
            {
                //Facilitation list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id),
               };
                Params = dbParams;
                dto.procedure_name = "fn_getfacilitation_dd";
                dto.facilitation_dd = _sql.Get_Data(dto.procedure_name, dbParams);



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
        public MasterFacilitationDTO get_pincode_dd(MasterFacilitationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "MasterFacilitation/get_pincode_dd";
            var Params = new DbParameter[] { };
            try
            {
                //Facilitation list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id),
               };
                Params = dbParams;
                dto.procedure_name = "fn_pincode_dd";
                dto.pincode_dd = _sql.Get_Data(dto.procedure_name, dbParams);



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
        public MasterFacilitationDTO save_map_data(MasterFacilitationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "MasterFacilitation/save_map_data";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                foreach (var item in dto.pincode_array)
                {

                    var dbParams5 = new DbParameter[]
                       {
                        DbHelper.CreateParameter("in_spin_id", dto.spin_id),
                        DbHelper.CreateParameter("in_facilitation_id",  dto.facilitation_id),
                        DbHelper.CreateParameter("in_pincode_id",  item.pincode_id),
                        DbHelper.CreateParameter("in_user_id",  dto.user_id),


                       };
                    dto.procedure_name = "call sp_save_facilitation_pincode(:in_spin_id,:in_facilitation_id,:in_pincode_id,:in_user_id)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams5);
                }
                if (status == -1)
                {
                    if (dto.spin_id > 0)
                    {
                        dto.status = "Update";
                        dto.message = "Data Updated Successfully";
                    }
                    else
                    {
                        dto.status = "Insert";
                        dto.message = "Data Inserted Successfully";
                    }

                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Failed to Facilitation Insert/Update, Please Try Again";
                }




                //Hub list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams2);


                //facilitation hub list
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_map_facilitation_pincode_grid";
                dto.facilitation_pincode_list = _sql.Get_Data(dto.procedure_name, dbParams3);

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
