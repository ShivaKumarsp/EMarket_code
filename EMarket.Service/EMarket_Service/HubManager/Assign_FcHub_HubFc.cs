using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.HubManager;
using EMarket.Entities;
using EMarket.Entities.Facilitation;
using EMarketDTO.HubManager;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.HubManager
{
    public class Assign_FcHub_HubFc : IAssign_FcHub_HubFc
    {
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;

        public Assign_FcHub_HubFc(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }


        public Assign_FcHub_HubDTO get_data(Assign_FcHub_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_FcHub_Hub/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;


                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_executive_list_dd";
                dto.executive_list_dd = _sql.Get_Data(dto.procedure_name, dbParams);

                //hub vehicle_list
                var dbParams1 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub_vehicle_list_dd";
                dto.hub_vehicle_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //fc to hub  list
                var dbParams2 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_consignment_fc_to_hub";
                dto.consignment_fc_hub_list = _sql.fn_get_list(dto.procedure_name, dbParams2);

                //hub to fc  list
                var dbParams3 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_consignment_hub_to_fc";
                dto.consignment_hub_fc_list = _sql.fn_get_list(dto.procedure_name, dbParams3);


                //hub to fc  list
                var dbParams4 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams4;
                dto.procedure_name = "fn_get_facilitation_data";
                dto.facilitation_list = _sql.Get_Data(dto.procedure_name, dbParams4);


               

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
        public Assign_FcHub_HubDTO save_fchub_hubfc(Assign_FcHub_HubDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_FcHub_Hub/save_fchub_hubfc";
            var Params = new DbParameter[] { };
            try
            {
                if (dto.hub_vehicle_id == 0)
                {
                    dto.own_vehicle = 1;
                }
                else
                {
                    dto.own_vehicle = 0;
                }
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;
     

                Consignment_BatchDMO dmo12 = new Consignment_BatchDMO();
                dmo12.send_by_role_id = 9;
                dmo12.send_by_status_id = 6;
                dmo12.receive_by_role_id = 8;
                dmo12.receive_by_status_id = 1;
                dmo12.created_by = dto.user_id;
                dmo12.created_on = DateTime.UtcNow;
                _context.Add(dmo12);
                _context.SaveChanges();

                if (dto.consignment_array_fc_hub != null)
                {
                   

                    foreach (var item in dto.consignment_array_fc_hub)
                    {
                        Consignment_Batch_TxrDMO con_txr = new Consignment_Batch_TxrDMO();
                        con_txr.batch_id = dmo12.batch_id;
                        con_txr.consignment_id = item.consignment_id;
                        con_txr.send_by_role_id = 9;
                        con_txr.send_by_status_id = 6;
                        con_txr.receive_by_role_id = 8;
                        con_txr.receive_by_status_id = 1;
                        con_txr.created_by = dto.user_id;
                        con_txr.created_on = DateTime.UtcNow;
                        _context.Add(con_txr);
                        var ss = _context.SaveChanges();

                        var dbParams4 = new DbParameter[]
                         {
                    DbHelper.CreateParameter("in_batch_id", dmo12.batch_id),
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_tracking_id", item.tracking_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_own_vehicle", dto.own_vehicle),
                    DbHelper.CreateParameter("in_hub_vehicle_id", dto.hub_vehicle_id)
                         };

                        Params = dbParams4;
                        var spName = "call sp_picku_assign_from_fc_to_hub(:in_batch_id,:in_consignment_id,:in_tracking_id,:in_delivery_executive_id,:in_user_id,:in_language_id,:in_own_vehicle,:in_hub_vehicle_id)";
                        var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                        if (status == -1)
                        {
                            dto.status = "Insert";
                            dto.message = "Item Assigned Successfully";

                        }
                        else
                        {
                            dto.status = "Failed";
                            dto.message = "Failed To Item Assign";

                        }
                    }
                }

                Consignment_BatchDMO dmo = new Consignment_BatchDMO();
                dmo.send_by_role_id = 8;
                dmo.send_by_status_id = 6;
                dmo.receive_by_role_id = 9;
                dmo.receive_by_status_id = 1;
                dmo.created_by = dto.user_id;
                dmo.created_on = DateTime.UtcNow;
                _context.Add(dmo);
                _context.SaveChanges();

                if (dto.consignment_array_hub_fc != null)
                {
                   
                    //delivery_executive_id

                    foreach (var item in dto.consignment_array_hub_fc)
                    {
                        Consignment_Batch_TxrDMO dmo1 = new Consignment_Batch_TxrDMO();
                        dmo1.batch_id = dmo.batch_id;
                        dmo1.consignment_id = item.consignment_id;
                        dmo1.send_by_role_id = 8;
                        dmo1.send_by_status_id = 6;
                        dmo1.receive_by_role_id = 9;
                        dmo1.receive_by_status_id = 1;
                        dmo1.created_by = dto.user_id;
                        dmo1.created_on = DateTime.UtcNow;
                        _context.Add(dmo1);
                        var ss = _context.SaveChanges();
                        if (ss > 0)
                        {
                            dto.status = "Update";
                        }




                        var dbParams4 = new DbParameter[]
                         {
                    DbHelper.CreateParameter("in_batch_id", dmo.batch_id),
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_tracking_id", item.tracking_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_own_vehicle", dto.own_vehicle),
                    DbHelper.CreateParameter("in_hub_vehicle_id", dto.hub_vehicle_id)
                         };

                        Params = dbParams4;
                        var spName = "call sp_picku_assign_from_hub_to_fc(:in_batch_id,:in_consignment_id,:in_tracking_id,:in_delivery_executive_id,:in_user_id,:in_language_id,:in_own_vehicle,:in_hub_vehicle_id)";
                        var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                        if (status == -1)
                        {
                            dto.status = "Insert";
                            dto.message = "Batch Assigned Successfully";

                        }
                        else
                        {
                            dto.status = "Failed";
                            dto.message = "Failed To Batch Assign";

                        }
                    }
                }

                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_executive_list_dd";
                dto.executive_list_dd = _sql.Get_Data(dto.procedure_name, dbParams);

                //hub vehicle_list
                var dbParams1 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub_vehicle_list_dd";
                dto.hub_vehicle_list_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

                //hub vehicle_list
                var dbParams2 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_consignment_fc_to_hub";
                dto.consignment_fc_hub_list = _sql.fn_get_list(dto.procedure_name, dbParams2);


                //hub to fc  list
                var dbParams3 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_consignment_hub_to_fc";
                dto.consignment_hub_fc_list = _sql.fn_get_list(dto.procedure_name, dbParams3);

                // fc  list
                var dbParams6 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams6;
                dto.procedure_name = "fn_get_facilitation_data";
                dto.facilitation_list = _sql.Get_Data(dto.procedure_name, dbParams6);


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
        public Assign_FcHub_HubDTO hub_get_data(Assign_FcHub_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_FcHub_Hub/hub_get_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;

                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_received_consignment_list";
                dto.received_hub_item_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //hub to fc  list
                var dbParams5 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams5;
                dto.procedure_name = "fn_get_pt_to_hub_list";
                dto.received_item_pt_to_hub_list = _sql.Get_Data(dto.procedure_name, dbParams5);


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
        public Assign_FcHub_HubDTO accept_from_fc(Assign_FcHub_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_FcHub_Hub/hub_get_data";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var Params = new DbParameter[] { };
            try
            {

                var dbParams4 = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                         DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
                    };

                Params = dbParams4;
                var spName = "call sp_accept_from_fc(:in_user_id,:in_consignment_id,:in_language_id)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                if (status == -1)
                {
                    dto.status = "Accept";

                }
                else
                {
                    dto.status = "Failed";

                }



                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;

                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_received_consignment_list";
                dto.received_hub_item_list = _sql.Get_Data(dto.procedure_name, dbParams);


                //hub to fc  list
                var dbParams5 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams5;
                dto.procedure_name = "fn_get_pt_to_hub_list";
                dto.received_item_pt_to_hub_list = _sql.Get_Data(dto.procedure_name, dbParams5);


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
        public Assign_FcHub_HubDTO facilitation_wise_data(Assign_FcHub_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_FcHub_Hub/facilitation_wise_data";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var Params = new DbParameter[] { };
            List<long> facilitationid = new List<long>();
            List<long> consignmentid = new List<long>();
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;
                var consignment = _context.Hub_To_FacilitationDMO_con.ToList();

                foreach (var item in dto.get_data_list)
                {
                    facilitationid.Add(item.facilitation_id);
                }

                foreach (var item in consignment)
                {
                    consignmentid.Add(item.consignment_id);
                }

                dto.consignment_fc_hub_list = (from a in _context.Facilitation_To_HubDMO_con
                                               from b in _context.Master_FacilitationDMO_con
                                               from c in _context.Consignment_DMO_con
                                               from d in _context.Product_ItemDMO_con
                                               where a.first_facilitation_id == b.facilitation_id
                                               && c.consignment_id == a.consignment_id && d.item_id == c.item_id
                                               && a.first_hub_id == dto.hub_id
                                               && a.facilitation_status == "Ready To Handover"
                                               && a.hub_status == "Pending" && facilitationid.Contains(a.first_facilitation_id)
                                               select new Assign_FcHub_HubDTO
                                               {
                                                   is_check = false,
                                                   batch_id = a.batch_id,
                                                   first_facilitation_id = a.first_facilitation_id,
                                                   first_hub_id = a.first_hub_id,
                                                   facilitation_name = b.facilitation_name,
                                                   address = b.address,
                                                   pincode = b.pincode,
                                                   consignment_id = a.consignment_id,
                                                   tracking_id = a.tracking_id,
                                                   item_name = d.item_name,
                                                   consignment_l = c.consignment_l,
                                                   consignment_b = c.consignment_b,
                                                   consignment_h = c.consignment_h,
                                                   volumetric_weight = (c.consignment_l * c.consignment_b * c.consignment_h),
                                                   weight = c.weight
                                               }).OrderBy(a => a.facilitation_name).ToArray();

                // dto.consignment_fc_hub_list = Newtonsoft.Json.JsonConvert.SerializeObject(data1);

                dto.consignment_hub_fc_list = (from a in _context.Hub_ConsignmentDMO_con
                                               from b in _context.Master_FacilitationDMO_con
                                               from c in _context.Consignment_DMO_con
                                               from d in _context.Product_ItemDMO_con
                                               where a.last_facilitation_id == b.facilitation_id
                                               && c.consignment_id == a.consignment_id && d.item_id == c.item_id
                                               && a.first_hub_id == dto.hub_id && facilitationid.Contains(a.last_facilitation_id)
                                               && !consignmentid.Contains(a.consignment_id) 
                                              && a.last_hub_id == dto.hub_id
                                               select new Assign_FcHub_HubDTO
                                               {
                                                   is_check = false,
                                                   consignment_id = a.consignment_id,
                                                   tracking_id = a.tracking_id,
                                                   last_facilitation_id = a.last_facilitation_id,
                                                   facilitation_name = b.facilitation_name,
                                                   address = b.address,
                                                   pincode = b.pincode,
                                                   item_name = d.item_name,
                                                   consignment_l = c.consignment_l,
                                                   consignment_b = c.consignment_b,
                                                   consignment_h = c.consignment_h,
                                                   volumetric_weight = (c.consignment_l * c.consignment_b * c.consignment_h),
                                                   weight = c.weight
                                               }).OrderBy(a => a.facilitation_name).ToArray();
                //dto.consignment_hub_fc_list= Newtonsoft.Json.JsonConvert.SerializeObject(data2);

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
        public Assign_FcHub_HubDTO get_accept_pt_to_hub_data(Assign_FcHub_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_FcHub_Hub/get_accept_pt_to_hub_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;

                //executive_list_dd
                var dbParams = new DbParameter[]
               {                  
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                      DbHelper.CreateParameter("in_batch_id", dto.batch_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id),
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_accept_all_item_from_pt_to_hub_details";
                dto.accept_all_item_details = _sql.Get_Data(dto.procedure_name, dbParams);

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
        public Assign_FcHub_HubDTO accept_from_pt_to_hub(Assign_FcHub_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_FcHub_Hub/accept_from_pt_to_hub";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;


                var dbParams4 = new DbParameter[]
                    {
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_hub_id", dto.hub_id)
                    };

                Params = dbParams4;
                var spName = "call sp_accept_from_pt_to_hub(:in_user_id,:in_consignment_id,:in_language_id,:in_delivery_executive_id,:in_hub_id)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                if (status == -1)
                {
                    dto.status = "Accept";

                }
                else
                {
                    dto.status = "Failed";

                }



                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_received_consignment_list";
                dto.received_hub_item_list = _sql.Get_Data(dto.procedure_name, dbParams);


                //hub to fc  list
                var dbParams5 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams5;
                dto.procedure_name = "fn_get_pt_to_hub_list";
                dto.received_item_pt_to_hub_list = _sql.Get_Data(dto.procedure_name, dbParams5);



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
        public Assign_FcHub_HubDTO accept_all_data_from_pt_to_hub(Assign_FcHub_HubDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_FcHub_Hub/accept_all_data_from_pt_to_hub";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.hub_id = usernamm[0].hub_id;

                foreach (var item in dto.consignment_list_array)
                {

                    var dbParams4 = new DbParameter[]
                        {
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_hub_id", dto.hub_id)
                        };

                    Params = dbParams4;
                    var spName = "call sp_accept_from_pt_to_hub(:in_user_id,:in_consignment_id,:in_language_id,:in_delivery_executive_id,:in_hub_id)";
                    var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                    if (status == -1)
                    {
                        dto.status = "Accept";

                    }
                    else
                    {
                        dto.status = "Failed";

                    }
                }


                //executive_list_dd
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_received_consignment_list";
                dto.received_hub_item_list = _sql.Get_Data(dto.procedure_name, dbParams);


                //hub to fc  list
                var dbParams5 = new DbParameter[]
               {
                DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
               };
                Params = dbParams5;
                dto.procedure_name = "fn_get_pt_to_hub_list";
                dto.received_item_pt_to_hub_list = _sql.Get_Data(dto.procedure_name, dbParams5);



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
