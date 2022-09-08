using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Facilitation;
using EMarket.DLL.Comman_Data;
using EMarket.Entities;
using EMarket.Entities.Facilitation;
using EMarketDTO.Facilitation;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Facilitation
{
    public class Assign_Consignment : IAssign_Consignment
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        General_Class _cal = new General_Class();
        int status = 0;
        List<string> ret_validation = new List<string>();
        comman_class cmm = new comman_class();
        public Assign_Consignment(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }


        public Assign_ConsignmentDTO get_data(Assign_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_Consignment/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                //get hub list 1
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", usernamm[0].facilitation_id),
                      DbHelper.CreateParameter("in_order_by","")
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_consignment_assign";
                dto.consignment_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get executive
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", usernamm[0].facilitation_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_delivery_executive_list_dd";
                dto.executive_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                //get assign list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", usernamm[0].facilitation_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_consignment_generared_list";
                dto.consignment_generared_list = _sql.Get_Data(dto.procedure_name, dbParams2);


                //get assign store list
                var dbParams3 = new DbParameter[]
               {
                       DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", usernamm[0].hub_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_consignment_assign_store";
                dto.consignment_store_list = _sql.Get_Data(dto.procedure_name, dbParams3);


                //get store list
                var dbParams4 = new DbParameter[]
               {
                 DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", usernamm[0].facilitation_id),
                     };
                Params = dbParams4;
                dto.procedure_name = "fn_get_consignment_store_list";
                dto.store_list = _sql.Get_Data(dto.procedure_name, dbParams4);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Assign_ConsignmentDTO assign_consignment(Assign_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_Consignment/assign_consignment";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var Params = new DbParameter[] { };
            try
            {

                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                var role = _context.Application_User_con.Where(a => a.user_id == dto.user_id).ToList();
                var deliveryuser = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.delivery_executive_id == dto.delivery_executive_id).ToList();
                var deliveryrole = _context.Application_User_con.Where(a => a.user_id == deliveryuser[0].user_id).ToList();

                Consignment_BatchDMO dmo = new Consignment_BatchDMO();
                dmo.send_by_role_id = 4;
                dmo.send_by_status_id = 1;
                dmo.receive_by_role_id = 9;
                dmo.receive_by_status_id = 1;
                dmo.created_by = dto.user_id;
                dmo.created_on = DateTime.UtcNow;
                _context.Add(dmo);
                _context.SaveChanges();
                //delivery_executive_id

                foreach (var item in dto.consignment_array)
                {
                    Consignment_Batch_TxrDMO dmo1 = new Consignment_Batch_TxrDMO();
                    dmo1.batch_id = dmo.batch_id;
                    dmo1.consignment_id = item.consignment_id;
                    dmo1.send_by_role_id = 4;
                    dmo1.send_by_status_id = 1;
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
                }



                foreach (var item in dto.consignment_array)
                {
                    var dbParams4 = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_tracking_id", item.tracking_id),
                    DbHelper.CreateParameter("in_batch_id", dmo.batch_id),
                    DbHelper.CreateParameter("in_vendor_id", item.vendor_id),
                    DbHelper.CreateParameter("in_store_id", item.store_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
                   };

                    Params = dbParams4;
                    var spName = "call sp_insert_vendor_to_facilitation(:in_consignment_id,:in_tracking_id,:in_batch_id,:in_vendor_id,:in_store_id,:in_delivery_executive_id,:in_user_id,:in_language_id)";
                    status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);

                    if (status == -1)
                    {
                        dto.status = "Update";
                    }
                }

                foreach (var item in dto.consignment_array)
                {
                    var dbParams5 = new DbParameter[]
                     {
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                         DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
                     };

                    Params = dbParams5;
                    var spName = "call sp_assign_consignment_from_vendor_to_de(:in_consignment_id,:in_user_id,:in_language_id)";
                    status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams5);
                    if (status == -1)
                    {
                        dto.status = "Update";

                    }
                    else
                    {
                        dto.status = "Failed";

                    }
                }



                //get hub list 1
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                         DbHelper.CreateParameter("in_facilitation_id", usernamm[0].facilitation_id),
                       DbHelper.CreateParameter("in_order_by","")
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_consignment_assign";
                dto.consignment_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get executive
                var dbParams1 = new DbParameter[]
             {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", usernamm[0].facilitation_id)
             };
                Params = dbParams1;
                dto.procedure_name = "fn_get_delivery_executive_list_dd";
                dto.executive_list = _sql.Get_Data(dto.procedure_name, dbParams1);


                //get assign list
                var dbParams2 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", usernamm[0].facilitation_id)
               };
                Params = dbParams2;
                dto.procedure_name = "fn_get_consignment_generared_list";
                dto.consignment_generared_list = _sql.Get_Data(dto.procedure_name, dbParams2);

                //get assign store list
                var dbParams3 = new DbParameter[]
               {
                       DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", usernamm[0].hub_id)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_consignment_assign_store";
                dto.consignment_store_list = _sql.Get_Data(dto.procedure_name, dbParams3);

                //get store list
                var dbParams6 = new DbParameter[]
               {
                 DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", usernamm[0].facilitation_id),

               };
                Params = dbParams6;
                dto.procedure_name = "fn_get_consignment_store_list";
                dto.store_list = _sql.Get_Data(dto.procedure_name, dbParams6);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Assign_ConsignmentDTO change_order_by(Assign_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_Consignment/change_order_by";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                //get hub list 1
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                       DbHelper.CreateParameter("in_facilitation_id", usernamm[0].facilitation_id),
                      DbHelper.CreateParameter("in_order_by",dto.order_by)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_consignment_assign";
                dto.consignment_list = _sql.fn_get_list(dto.procedure_name, dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        public Assign_ConsignmentDTO get_storewise_consignment_data(Assign_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_Consignment/get_storewise_consignment_data";
            var Params = new DbParameter[] { };
            List<long> storeid = new List<long>();
            List<long> consignmentid = new List<long>();
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();

                var vendor_to_fc = _context.Vendor_To_FacilitationDMO_con.ToList();

                foreach (var item in vendor_to_fc)
                {
                    consignmentid.Add(item.consignment_id);
                }

                foreach (var item in dto.get_data_list)
                {
                    storeid.Add(item.store_id);
                }

                dto.consignment_list = (from a in _context.Consignment_DMO_con
                                        from b in _context.Vendor_Store_DMO_con
                                        from c in _context.Consignment_StatusDMO_con
                                        from d in _context.Product_ItemDMO_con
                                        where a.store_id == b.store_id && a.hand_over == 0 && a.is_print == 1
                                            && c.consignment_status_id == a.consignment_status_id
                                            && a.is_ready_to_handover == true && d.item_id == a.item_id
                                            && a.assign_to_delivery_boy == 0 && b.language_id == 1
                                            && a.first_facilitation_id == usernamm[0].facilitation_id
                                            && !consignmentid.Contains(a.consignment_id) && storeid.Contains(a.store_id)
                                        select new Assign_ConsignmentDTO
                                        {
                                            store_id = a.store_id,
                                            store_name = b.store_name,
                                            consignment_id = a.consignment_id,
                                            consignment_l = a.consignment_l,
                                            consignment_b = a.consignment_b,
                                            consignment_h = a.consignment_h,
                                            weight = a.weight,
                                            first_hub_id = a.first_hub_id,
                                            last_hub_id = a.last_hub_id,
                                            hub_route_id = a.hub_route_id,
                                            status = c.status,
                                            order_item_id = a.order_item_id,
                                            hand_over = a.hand_over,
                                            is_check = false,
                                            hub_route = a.hub_route,
                                            vendor_id = a.vendor_id,
                                            tracking_id = a.tracking_id,
                                            volumetric_weight = (a.consignment_l * a.consignment_b * a.consignment_h),
                                            pickup_location = b.pickup_location,
                                            item_name = d.item_name,
                                            pincode = b.pincode
                                        }).Distinct().ToArray();

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

    }
}
