using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces;
using EMarket.DLL.Interfaces;
using EMarket.Entities;
using EMarketDTO.HubManager;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.BLL.EMarket_Service.HubManager
{
    public class hubtofacilitationcenter: Ihubtofacilitationcenter
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Ihubtofacilitationcenter_Repository _inter;
        public hubtofacilitationcenter(Ihubtofacilitationcenter_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }

        public hubtofacilitationcenterDTO Get(hubtofacilitationcenterDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/Get";
            var pid = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
            dto.parent_id = pid.hub_id;
            try
            {
                
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("parentid", dto.parent_id),
                    
                };
                Params = dbParams1;
                dto.facilitationcenterlist = _sql.Get_Data("fn_getfacilitation", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getfacilitation", Params);
            }
            //consignmentlist to drop
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("parentid", dto.parent_id),

                };
                Params = dbParams1;
                dto.consignmentlist = _sql.Get_Data("fn_getconsignments", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getconsignments", Params);
            }
            //local transport
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_hub_id", dto.parent_id),

                };
                Params = dbParams1;
                dto.locallist = _sql.Get_Data("fn_getlocaltransport", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getconsignments", Params);
            }
            //scedule batch to particular facilitation center
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    //DbHelper.CreateParameter("parentid", dto.parent_id),

                };
                Params = dbParams1;
                dto.facilitationschedulelist = _sql.Get_Data("fn_getfacilitationschedule", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getfacilitationschedule", Params);
            }
            //vehicle type
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    //DbHelper.CreateParameter("parentid", dto.parent_id),

                };
                Params = dbParams1;
                dto.vehicletypelist = _sql.Get_Data("fn_getvehicle_type", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getvehicle_type", Params);
            }
            //consignment list to pick
            try
            {
                var dbParams1 = new DbParameter[]
                {
                    DbHelper.CreateParameter("parentid", dto.parent_id),

                };
                Params = dbParams1;
                dto.pconsignmentlist = _sql.Get_Data("fn_getconsignments_pickup", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getconsignments_pickup", Params);
            }
            //batch list to drop
            try
            {
                var dbParams1 = new DbParameter[]
                {
                   // DbHelper.CreateParameter("parentid", dto.parent_id),

                };
                Params = dbParams1;
                dto.batchlist = _sql.Get_Data("get_batch_list", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getconsignments_pickup", Params);
            }
            return _inter.Get(dto);
        }

        public hubtofacilitationcenterDTO Save(hubtofacilitationcenterDTO dto)
        {
             var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/Save";
            string name = @"^[a-zA-Z0-9_ ]*$";
            Regex tname = new Regex(name);
            string email = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex mail = new Regex(email);
            string mobile = @"^[6-9]{1}[0-9]{9}$";
            Regex mobile_no = new Regex(mobile);
            string vehicle = @"^[A-Z]{2}[ -][0-9]{1,2}(?: [A-Z])?(?: [A-Z]*)? [0-9]{4}$";
            Regex reg_no = new Regex(vehicle);
            if (dto.transportor_name.Trim() == "" || dto.transportor_name.Trim() == null)
            {
                dto.messageflg = "Please Enter Transportor Name";
                return dto;
            }
            else if (!tname.IsMatch(dto.transportor_name))
            {
                dto.messageflg = "Please Enter Valid Transportor Name";
                return dto;
            }
            else if (dto.email_id.Trim() == "" || dto.email_id.Trim() == null)
            {
                dto.messageflg = "Please Enter Email";
                return dto;
            }
            else if (!mail.IsMatch(dto.email_id.Trim()))
            {
                dto.messageflg = "Please Enter Valid Email";
                return dto;
            }
            else if (dto.contact_no == 0)
            {
                dto.messageflg = "Please Enter Contact No";
                return dto;
            }
            else if (!mobile_no.IsMatch(dto.contact_no.ToString()))
            {
                dto.messageflg = "Please Enter Valid Contact no";
                return dto;
            }
            else if (dto.vehicle_registration_no.Trim() == null || dto.vehicle_registration_no.Trim() == "")
            {
                dto.messageflg = "Please Enter Vehicle Registarion No";
                return dto;
            }
            else if (!reg_no.IsMatch(dto.vehicle_registration_no.Trim()))
            {
                dto.messageflg = "Please Enter Valid Vehicle Registarion No";
                return dto;
            }

            return _inter.Save(dto);
        }
        //save_batch
        public hubtofacilitationcenterDTO Save_batch(hubtofacilitationcenterDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/Save_batch";

            return _inter.Save_batch(dto);
        }

        public hubtofacilitationcenterDTO save_batch_consignment(hubtofacilitationcenterDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/save_batch_consignment";
            return _inter.save_batch_consignment(dto);
        }

        public hubtofacilitationcenterDTO update_batch_consignment(hubtofacilitationcenterDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/update_batch_consignment";
            //if(dto.batch_id==0)
            //{
            //    dto.messageflg = "Please Select Scheduled Date";
            //    return dto;
            //}
            return _inter.update_batch_consignment(dto);
        }
        //save to schedule
        public hubtofacilitationcenterDTO schedulesave(hubtofacilitationcenterDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/Save";
            //if (dto.send_by_id == 0)
            //{
            //    dto.messageflg = "Please Select Facilitation Center Name";
            //    return dto;
            //}
            if (dto.transportor_id == 0)
            {
                dto.messageflg = "Please Select Transportor Name";
                return dto;
            }
            else if (dto.scheduled_date == null)
            {
                dto.messageflg = "Please Select Scheduled Date";
                return dto;
            }
            
            return _inter.schedulesave(dto);
        }

        public hubtofacilitationcenterDTO update_pbatch_consignment(hubtofacilitationcenterDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/update_pbatch_consignment";
            return _inter.update_pbatch_consignment(dto);
        }
    }
}
