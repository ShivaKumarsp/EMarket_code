using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Master
{
    public class Managehub_Repository : IManagehub_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        int status = 0;
        public Managehub_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        //get
        public ManagehubDTO get(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub_Repository/get";
            return dto;
        }
        //get state
        public ManagehubDTO get_state(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub_Repository/get_state";
            return dto;
        }
        //get city
        public ManagehubDTO get_city(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub_Repository/get_city";
            return dto;
        }
        //get_pincode
        public ManagehubDTO get_pincode(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub_Repository/get_pincode";
            return dto;
        }
        //save
        public ManagehubDTO save_hub(ManagehubDTO dto)
        {
            //NpgsqlConnection.GlobalTypeMapper.UseJsonNet();
            //conn.TypeMapper.UseJsonNet();

            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub_Repository/save_hub";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_hub_id",dto.hub_id),
                        DbHelper.CreateParameter("in_hub_name",dto.hub_name.Trim()),
                        DbHelper.CreateParameter("in_email",dto.email),
                        DbHelper.CreateParameter("in_contact_no",dto.contact_no),
                        DbHelper.CreateParameter("in_address",dto.address.Trim()),
                        DbHelper.CreateParameter("in_pincode_id",dto.pincode),
                        DbHelper.CreateParameter("in_hub_city",dto.hub_city),
                        DbHelper.CreateParameter("in_hub_state",dto.hub_state),
                        DbHelper.CreateParameter("in_hub_country",dto.hub_country),
                        DbHelper.CreateParameter("in_hub_type",dto.hub_type),
                        DbHelper.CreateParameter("in_parent_id",dto.parent_id),
                        DbHelper.CreateParameter("in_hub_type_id",dto.hub_type_id),
                        
                    };
                    dto.procedure_name = "call sp_saveupdate_masterhubs(:in_hub_id,:in_hub_name,:in_email,:in_contact_no,:in_address,:in_pincode_id,:in_hub_city,:in_hub_state,:in_hub_country,:in_hub_type,:in_parent_id,:in_hub_type_id)";
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
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_saveupdate_masterhubs", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
        //get servicable pincodes
        public ManagehubDTO get_servicablePincodes(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub_Repository/get_servicablePincodes";
            return dto;
        }
        //save servicable
        public ManagehubDTO save_servicablepin(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub_Repository/save_servicablepin";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {

                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_spin_id",dto.spin_id),
                        DbHelper.CreateParameter("in_pincode_id",dto.pincode_id),
                        DbHelper.CreateParameter("in_pincode",dto.pincode),
                        DbHelper.CreateParameter("in_hub_id",dto.hub_id),
                    };
                    dto.procedure_name = "call sp_saveupdate_deliverablePincode(:in_spin_id,:in_pincode_id ,:in_pincode,:in_hub_id)";
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
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_saveupdate_deliverablePincode", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
        public ManagehubDTO delete(ManagehubDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Managehub_Repository/delete";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {

                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_spin_id",dto.spin_id),
                        DbHelper.CreateParameter("in_hub_id",dto.hub_id),
                    };
                    dto.procedure_name = "call sp_delete_pincode(:in_spin_id,:in_hub_id)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                    if (status == -1)
                    {
                        dto.msg_flg = "delete";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_saveupdate_deliverablePincode", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }

    }
}
