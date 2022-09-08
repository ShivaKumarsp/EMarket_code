using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Vendor;
using EMarket.DLL.EMarket_Repository.Vendor;
using EMarket.DLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Vendor
{
    public  class Vendor_Profile: IVendor_Profile
    {
        Vendor_Profile_Repository _inter;
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        
        public Vendor_Profile(IVendor_Profile_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = (Vendor_Profile_Repository)inter;
            _context = context;
            _sql = sql;
            _error = error;
            
        }

        public  Vendor_ProfileDTO getdata(Vendor_ProfileDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Profile/getdata";
            try
            {
                var vend = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
                dto.vendor_id = vend.vendor_id;
                //gender
                try
                {
                  var dbParams1 = new DbParameter[]
                  {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                  };
                    Params = dbParams1;
                    dto.genderlist = _sql.fn_get_list("fn_gender", dbParams1);
                }
                catch(Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_category", Params);
                }
                //states
                try 
                {
                    var dbParams2= new DbParameter[]
                  {
                      DbHelper.CreateParameter("pcountryid", dto.vendor_country_id),
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                  };
                    Params = dbParams2;
                    dto.statelist = _sql.fn_get_list("fn_states", dbParams2);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_states", Params);
                }
                //country
                try
                {
                    var dbParams3= new DbParameter[]
                  {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                  };
                    Params = dbParams3;
                    dto.countrylist = _sql.fn_get_list("fn_country", dbParams3);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_country", Params);
                }
                //vendorprofileupdate
                var vendorid = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
                dto.vendor_id = vendorid.vendor_id;
                try
                {
                    var dbParams4 = new DbParameter[]
                  {
                      DbHelper.CreateParameter("vendorid",dto.vendor_id),
                  };
                    Params = dbParams4;
                    dto.vendorprofileupdate = _sql.fn_get_list("fn_get_vendor_details", dbParams4);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_vendor_details", Params);
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "getdata", Params);
            }
            return _inter.getdata(dto);
        }
        public Vendor_ProfileDTO UpdateProfile(Vendor_ProfileDTO dto)
        {
            return _inter.UpdateProfile(dto);
        }
        public Vendor_ProfileDTO getstate(Vendor_ProfileDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Profile/getstate";

            try
            {
                var dbParams1 = new DbParameter[]
              {
                      DbHelper.CreateParameter("pcountryid",dto.country_id),
                      DbHelper.CreateParameter("planguageid",Convert.ToInt32(dto.language_id)),
              };
                Params = dbParams1;
                //Console.WriteLine(dbParams1);
                dto.statelist = _sql.fn_get_list("fn_states", dbParams1);
            }
                catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_states", Params);
            }

            return _inter.getstate(dto);
        }
        public Vendor_ProfileDTO getstate1(Vendor_ProfileDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Profile/getstate1";

            try
            {
                var dbParams1 = new DbParameter[]
              {
                      DbHelper.CreateParameter("pcountryid",dto.country_id),
                      DbHelper.CreateParameter("planguageid",Convert.ToInt32(dto.language_id)),
              };
                Params = dbParams1;
                dto.statelist = _sql.fn_get_list("fn_states", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_states", Params);
            }

            return _inter.getstate1(dto);
        }
    }
}
