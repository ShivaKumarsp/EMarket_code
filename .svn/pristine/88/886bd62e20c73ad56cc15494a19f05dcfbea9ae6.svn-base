using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces;
using EMarket.Entities;
using EMarketDTO.HubManager;
using EMarketDTO.Master;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Master
{
    public class hubtofacilitationcenter_Repository: Ihubtofacilitationcenter_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        int status = 0;
       
        public hubtofacilitationcenter_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

        public hubtofacilitationcenterDTO Get(hubtofacilitationcenterDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/Get";
            return dto;
        }
        //save transport
        public hubtofacilitationcenterDTO Save(hubtofacilitationcenterDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/Save";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            dto.max_volume = dto.length * dto.breadth * dto.height;
            var hid = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
            dto.hub_id = hid.hub_id;
            try
            {

                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_transport_id",dto.transport_id),
                        DbHelper.CreateParameter("in_transportor_name",dto.transportor_name),
                        DbHelper.CreateParameter("in_vehicle_registration_no",dto.vehicle_registration_no),
                        DbHelper.CreateParameter("in_contact_no",dto.contact_no),
                        DbHelper.CreateParameter("in_email_id",dto.email_id),
                        DbHelper.CreateParameter("in_hub_id",dto.hub_id),
                        DbHelper.CreateParameter("in_created_by",dto.userid),
                        DbHelper.CreateParameter("in_vehicle_type",dto.vehicle_type),
                        DbHelper.CreateParameter("in_max_volume",dto.max_volume),
                        DbHelper.CreateParameter("in_max_weight",dto.max_weight),
                        
                    };

                    dto.procedure_name = "call sp_save_localtransportation(:in_transport_id,:in_transportor_name,:in_vehicle_registration_no,:in_contact_no,:in_email_id,:in_hub_id,:in_created_by,:in_vehicle_type,:in_max_volume,:in_max_weight)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                    if (status == -1)
                    {
                        dto.msg_flg = "Save";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_save_localtransportation", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
        //save/create batch
        public hubtofacilitationcenterDTO Save_batch(hubtofacilitationcenterDTO dto)
        {
            
            var Params = new DbParameter[] { };
             var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/Save_batch";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            if (dto.send_by_roleid == 8)
            {
                var hid = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
                dto.send_by_id = hid.hub_id;
            }
            if (dto.send_by_roleid == 9)
            {
                var rid = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
                dto.receive_by_id = rid.hub_id;
            }
            try
            {
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
  
                        var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_sentbyid",dto.send_by_id),
                        DbHelper.CreateParameter("in_sendbyroleid",dto.send_by_roleid),
                        DbHelper.CreateParameter("in_sendbystatus",dto.send_by_status),
                        DbHelper.CreateParameter("in_receivebyid",dto.receive_by_id),
                        DbHelper.CreateParameter("in_receivebyroleid",dto.receive_by_roleid),
                        DbHelper.CreateParameter("in_receivebystatus",dto.receive_by_status),
                    };
                    dto.procedure_name = "fn_create_batch_id";
                    dto.rdata = _sql.Get_Data("fn_create_batch_id", dbParams);
                    //var exestatus = _dbHelper.ExecuteReder(dto.procedure_name, CommandType.StoredProcedure, dbParams);
                    //status = exestatus.RecordsAffected;
                    //if (status == -1)
                    //{
                    //    dto.msg_flg = "Save";
                    //}
                    //else
                    //{
                    //    dto.msg_flg = "Failed";
                    //}
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "fn_create_batch_id", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }

        //save_batch_consignment
        public hubtofacilitationcenterDTO save_batch_consignment(hubtofacilitationcenterDTO dto)
        {

            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/save_batch_consignment";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_batch_id",dto.batch_id),
                        DbHelper.CreateParameter("in_consignment_id",dto.consignment_id),
                        
                    };
                    dto.procedure_name = "call sp_insert_batch_consignment(:in_batch_id,:in_consignment_id)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
              
                    if (status == -1)
                    {
                        dto.msg_flg = "Save";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_insert_batch_consignment", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
        //update status of drop batch consignment
        public hubtofacilitationcenterDTO update_batch_consignment(hubtofacilitationcenterDTO dto)
        {

            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/update_batch_consignment";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            try
            {
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("out_batch_id",dto.batch_id),
                        //DbHelper.CreateParameter("in_consignment_id",dto.consignment_id),

                    };
                    dto.procedure_name = "call sp_update_batchconsignment_drop(:out_batch_id)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                    if (status == -1)
                    {
                        dto.msg_flg = "Save";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_update_batchconsignment", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
        //update status of pick up batch consignment
        public hubtofacilitationcenterDTO update_pbatch_consignment(hubtofacilitationcenterDTO dto)
        {

            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/update_pbatch_consignment";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("out_batch_id",dto.batch_id),
                    };
                    dto.procedure_name = "call sp_update_batchconsignment_pick(:out_batch_id)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                    if (status == -1)
                    {
                        dto.msg_flg = "Save";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_update_batchconsignment", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
        //schedulesave
        public hubtofacilitationcenterDTO schedulesave(hubtofacilitationcenterDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "hubtofacilitationcenter/schedulesave";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var hid = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
            dto.hub_id = hid.hub_id;
            try
            {
                
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                       
                        DbHelper.CreateParameter("assignedid",dto.assigned_id),
                        DbHelper.CreateParameter("transportorid",dto.transportor_id),
                        DbHelper.CreateParameter("facilitationid",dto.facilitation_id),
                        DbHelper.CreateParameter("hubid",dto.hub_id),
                        DbHelper.CreateParameter("scheduleddate",dto.scheduled_date),
                        DbHelper.CreateParameter("batchid",dto.batch_id),
                        DbHelper.CreateParameter("type_ofconsignment",dto.type_of_consignment)

                    };
                    dto.procedure_name = "call sp_saveupdate_hub_consignments(:assignedid,:transportorid,:facilitationid,:hubid,:scheduleddate,:batchid,:type_ofconsignment)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                    if (status == -1)
                    {
                        dto.msg_flg = "Save";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_saveupdate_hub_consignments", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
    }
}
