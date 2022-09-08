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
using System.Text.RegularExpressions;

namespace EMarket.BLL.EMarket_Service.Vendor
{
   public class VendorDashboard: IVendorDashboard
    {
        IVendorDashboard_Repository _inter;
           PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        public VendorDashboard(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IVendorDashboard_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }
        public Vendor_DashBoardDTO get_data(Vendor_DashBoardDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_DashBoard/get_data";
            try
            {
                dto.vendor_id = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault().vendor_id;

                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "Pending")
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_vendor_all_order_list";
                dto.pending_order_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get all vendor list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "All")
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_vendor_all_order_list";
                dto.all_order_count = _sql.Get_Data(dto.procedure_name, dbParams1);

                var dbParams2 = new DbParameter[]
             {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "Accept")
             };
                Params = dbParams2;
                dto.procedure_name = "fn_get_vendor_all_order_list";
                dto.accept_order_count = _sql.Get_Data(dto.procedure_name, dbParams2);

                var dbParams3 = new DbParameter[]
            {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "Reject")
            };
                Params = dbParams3;
                dto.procedure_name = "fn_get_vendor_all_order_list";
                dto.reject_order_count = _sql.Get_Data(dto.procedure_name, dbParams3);


                //get consignment_list
                var dbParams4 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_consignment_list";
                dto.consignment_list = _sql.Get_Data(dto.procedure_name, dbParams4);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }

        public Vendor_All_Order_ListDTO update_order(Vendor_All_Order_ListDTO dto)
        {
            List<string>validation = new List<string>();
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_DashBoard/update_order";
            string num = @"^[1-9][0-9]*$";
            Regex number = new Regex(num);
            string w = @"^[0-9]\d*(\.\d+)?$";
            Regex weight = new Regex(w);
            if (dto.order_accept_status == null)
            {
                validation.Add("please enter Order Accept Status");
            }
             else if (dto.item_b==0)
            {
                validation.Add("please enter item breadth");
            }
            else if (!number.IsMatch(dto.item_b.ToString()))
            {
                validation.Add("please enter valid item breadth");
            }
            else if (dto.item_h==0)
            {
                dto.message = "please enter item height";
            }
            else if (!number.IsMatch(dto.item_h.ToString()))
            {
                validation.Add("please enter valid item height");
            }
            else if (dto.item_l == 0)
            {
                validation.Add("please enter item length");
            }
            else if (!number.IsMatch(dto.item_l.ToString()))
            {
                validation.Add("please enter valid item length");
            }
            else if (dto.item_w==0)
            {
                validation.Add("please enter item weight");
            }
            else if (!weight.IsMatch(dto.item_w.ToString()))
            {
                validation.Add("please enter valid item weight");
            }
            if (validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = validation.ToArray();
                return dto;
            }
            try
            {
                dto.vendor_id = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault().vendor_id;

                _inter.update_order(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            try
            {
                //get all vendor list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "Pending")
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_vendor_all_order_list";
                dto.pending_order_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get all vendor list
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "All")
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_vendor_all_order_list";
                dto.all_order_count = _sql.Get_Data(dto.procedure_name, dbParams1);

                var dbParams2 = new DbParameter[]
             {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "Accept")
             };
                Params = dbParams2;
                dto.procedure_name = "fn_get_vendor_all_order_list";
                dto.accept_order_count = _sql.Get_Data(dto.procedure_name, dbParams2);

                var dbParams3 = new DbParameter[]
            {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                       DbHelper.CreateParameter("in_flg", "Reject")
            };
                Params = dbParams3;
                dto.procedure_name = "fn_get_vendor_all_order_list";
                dto.reject_order_count = _sql.Get_Data(dto.procedure_name, dbParams3);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
    }
}
