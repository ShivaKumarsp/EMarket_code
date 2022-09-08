using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.Interfaces;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class verify_vendor_profile : IVerify_vendor_Profile
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        IVerify_vendor_profile_Repository _inter;
        public verify_vendor_profile(IVerify_vendor_profile_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Verify_vendor_profileDTO Getdata(Verify_vendor_profileDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "verify_vendor_profile/Getdata";
            //vendor details list
            try
            {
                var dbParams1 = new DbParameter[]
                {
                   //DbHelper.CreateParameter("parentid", dto.parent_id),

                };
                Params = dbParams1;
                dto.allvendor = _sql.Get_Data("fn_get_allvendor_details", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_allvendor_details", Params);
            }
            //status
            try
            {
                dto.statuslist = _sql.Get_Data("fn_status");
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_status", Params);
            }

            return _inter.Getdata(dto);
        }

        public Verify_vendor_profileDTO VerifyProfile(Verify_vendor_profileDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "verify_vendor_profile/VerifyProfile";

            return _inter.VerifyProfile(dto);
        }
    }
}
