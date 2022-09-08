using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Master;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.BLL.EMarket_Service.Master
{
    public class Managehub : IManagehub
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        IManagehub_Repository _inter;
        public Managehub(IManagehub_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }
        public ManagehubDTO get(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub/get";
            try
            {
                //All hubs
                try
                {
                    var dbParams1 = new DbParameter[]
                    {
                      //DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                      //DbHelper.CreateParameter("languageid",dto.language_id),
                    };
                    Params = dbParams1;
                    dto.hublist = _sql.Get_Data("fn_gethubs", dbParams1);

                    var dbParams2 = new DbParameter[]
                   {
                   };
                    Params = dbParams2;
                    dto.hub_type_list = _sql.Get_Data("fn_get_hub_type", dbParams2);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_gethubs", Params);
                }
                //master pincode
                try
                {
                    var dbParams1 = new DbParameter[]
                    {
                      //DbHelper.CreateParameter("in_city_id", dto.city_id),
                      //DbHelper.CreateParameter("languageid",dto.language_id),
                    };
                    Params = dbParams1;
                    dto.pincodelist = _sql.Get_Data("fn_getpincode", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getpincode", Params);
                }
                //master state
                try
                {

                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("pcountryid",1),
                      DbHelper.CreateParameter("planguageid",dto.language_id),
                    };
                    Params = dbParams1;
                    dto.statelist = _sql.Get_Data("fn_states", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_states", Params);
                }
                //master country
                try
                {
                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("planguageid",dto.language_id),
                    };
                    Params = dbParams1;
                    dto.countrylist = _sql.Get_Data("fn_country", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_country", Params);
                }
                //master city
                try
                {
                    var dbParams1 = new DbParameter[]
                    {
                      //DbHelper.CreateParameter("planguageid",dto.language_id),
                    };
                    Params = dbParams1;
                    dto.citylist = _sql.Get_Data("fn_city", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_country", Params);
                }
                //Servicable pincodes
                try
                { 
                    var dbParams1 = new DbParameter[]
                    {
                      //DbHelper.CreateParameter("in_hub_id",dto.hub_id),
                    };
                    Params = dbParams1;
                    dto.dpincodelist = _sql.Get_Data("fn_getservicablepincode", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getservicablepincode", Params);
                }
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "get", Params);
            }
            return _inter.get(dto);

        }

        public ManagehubDTO save_hub(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub/save_hub";
            //validation
            string mobileRegex = @"^[6-9]{1}[0-9]{9}$";
            Regex mre = new Regex(mobileRegex);
            string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex ere = new Regex(emailRegex);
            string nameRegex = @"^[a-zA-Z\s]+$";
            Regex nre = new Regex(nameRegex);
            if (!mre.IsMatch(dto.contact_no.ToString()))
            {
                dto.messageflg = "Please Enter Valid Mobile Number";
                return dto;
            }
            else if (!ere.IsMatch(dto.email))
            {
                dto.messageflg = "Please Enter Valid Email Id";
                return dto;
            }
            else if (!nre.IsMatch(dto.hub_name.ToString()))
            {
                dto.messageflg = "Please Enter Valid  Name";
                return dto;
            }
            else if(dto.hub_country==0)
            {
                dto.messageflg = "Please Select Country  Name";
                return dto;
            }
            else if (dto.hub_state == 0)
            {
                dto.messageflg = "Please Select state  Name";
                return dto;
            }
            else if (dto.hub_city == 0)
            {
                dto.messageflg = "Please Select City  Name";
                return dto;
            }
           
            else if (dto.address.Trim() ==" " || dto.address.Trim()==null)
            {
                dto.messageflg = "Please Select Address";
                return dto;
            }
            else if (dto.hub_type_id==0 || dto.hub_type_id== null)
            {
                dto.messageflg = "Please Select Hub Type";
                return dto;
            }
            return _inter.save_hub(dto);
        }
        //get servicable pincodes
        public ManagehubDTO get_servicablePincodes(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub/get_servicablePincodes";
            //Servicable pincodes
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_hub_id",dto.hub_id),
                };
                Params = dbParams1;
                dto.servicablepincodelist = _sql.Get_Data("fn_getservicablepincodes", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getservicablepincodes", Params);
            }

            return _inter.get_servicablePincodes(dto);
        }

        public ManagehubDTO save_servicablepin(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub/save_servicablepin";
            return _inter.save_servicablepin(dto);
        }

        public ManagehubDTO get_state(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub/get_state";
            //Servicable pincodes
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("pcountryid",dto.country_id),
                    DbHelper.CreateParameter("planguageid",dto.language_id),
                };
                Params = dbParams1;
                dto.statelists = _sql.Get_Data("fn_states", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getservicablepincodes", Params);
            }

            return _inter.get_state(dto);

        }

        public ManagehubDTO get_city(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub/get_city";
            //Servicable pincodes
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id",dto.language_id),
                    DbHelper.CreateParameter("in_country_id",dto.country_id),
                    DbHelper.CreateParameter("in_state_id",dto.state_id),
                };
                Params = dbParams1;
                dto.citylists = _sql.Get_Data("fn_get_city", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_city", Params);
            }

            return _inter.get_city(dto);

        }

        public ManagehubDTO get_pincode(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub/get_pincode";
            //Servicable pincodes
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_language_id",dto.language_id),
                    DbHelper.CreateParameter("in_country_id",dto.country_id),
                    DbHelper.CreateParameter("in_state_id",dto.state_id),
                    DbHelper.CreateParameter("in_city_id",dto.city_id),
                };
                Params = dbParams1;
                dto.hubpinlists = _sql.Get_Data("fn_get_pincode", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_pincode", Params);
            }

            return _inter.get_pincode(dto);

        }
        //delete
        public ManagehubDTO delete(ManagehubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub/delete";
            return _inter.delete(dto);
        }
    }
}
