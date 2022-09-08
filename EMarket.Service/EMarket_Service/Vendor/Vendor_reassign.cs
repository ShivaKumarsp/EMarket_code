using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Vendor;
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

    public class Vendor_reassign: IVendor_reassign
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        IVendor_reassign_Repository _inter;
        public Vendor_reassign(IVendor_reassign_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }
        //get
        public Vendor_reassignDTO get(Vendor_reassignDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_reassign/get";
            var vendorid = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
            dto.vendor_id = vendorid.vendor_id;
            try
            {
                //rejected orders
                try
                {
                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                      //DbHelper.CreateParameter("languageid",dto.language_id),
                    };
                    Params = dbParams1;
                    dto.vendorreassignlist = _sql.Get_Data("fn_getreassignorder_orderitem", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getreassignorder_orderitem", Params);
                }
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "getdata", Params);
            }
            return _inter.get(dto);
        }

        //getitemlist
        public Vendor_reassignDTO getitem(Vendor_reassignDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_reassign/getitem";
            var vendorid = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
            dto.vendor_id = vendorid.vendor_id;
            try
            {
                //vendor available item list
                try
                {
                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                      DbHelper.CreateParameter("in_product_id",dto.product_id),
                      DbHelper.CreateParameter("in_quantity",dto.quantity),
                    };
                    Params = dbParams1;
                    dto.vendoritemlist = _sql.Get_Data("fn_getreassignorder_itemavaliable", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getreassignorder_itemavaliable", Params);
                }
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "getdata", Params);
            }
            return _inter.get(dto);
        }

        public Vendor_reassignDTO reassigning(Vendor_reassignDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_reassign/reassigning";
            return _inter.reassigning(dto);
        }
    }
}
