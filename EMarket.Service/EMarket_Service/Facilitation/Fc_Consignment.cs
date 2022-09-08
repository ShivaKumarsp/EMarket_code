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
    public class Fc_Consignment: IFc_Consignment
    {
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;
        comman_class cmm = new comman_class();

        public Fc_Consignment(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

        public Fc_ConsignmentDTO get_data(Fc_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_Consignment/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.facilitation_id = usernamm[0].facilitation_id;
                //gethub_consignment_list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id)
               };
                Params = dbParams;
               dto.procedure_name = "fn_get_fc_consignment_list_from_vendor";
                dto.fc_consignment_list_from_vendor = _sql.Get_Data(dto.procedure_name, dbParams);

                var dbParams1 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id)
              };
                Params = dbParams1;
                dto.procedure_name = "fn_get_fc_consignment_list_from_hub";
                dto.fc_consignment_list_from_hub = _sql.Get_Data(dto.procedure_name, dbParams1);






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

        //FC to CS
        public Fc_ConsignmentDTO get_data_fc_cs(Fc_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_Consignment/get_data_fc_cs";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.facilitation_id = usernamm[0].facilitation_id;
                //gethub_consignment_list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id),
                      DbHelper.CreateParameter("in_order_by", "ALL")
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_fc_to_cs_consignment_list";
                dto.fc_to_cs_consignment_list = _sql.Get_Data(dto.procedure_name, dbParams);


                //get executive
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id",dto.facilitation_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_delivery_executive_list_customer";
                dto.executive_list = _sql.Get_Data(dto.procedure_name, dbParams1);


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
        public Fc_ConsignmentDTO assign_delivery_to_customer(Fc_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            string methodname = "Assign_Consignment/assign_delivery_to_customer";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                var role = _context.Application_User_con.Where(a => a.user_id == dto.user_id).ToList();
                var deliveryuser = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.delivery_executive_id == dto.delivery_executive_id).ToList();
                var deliveryrole = _context.Application_User_con.Where(a => a.user_id == deliveryuser[0].user_id).ToList();

                Consignment_BatchDMO dmo = new Consignment_BatchDMO();
                dmo.send_by_role_id = 9;
                dmo.send_by_status_id = 1;
                dmo.receive_by_role_id = 7;
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
                    dmo1.send_by_role_id = 9;
                    dmo1.send_by_status_id = 1;
                    dmo1.receive_by_role_id =7;
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
                    string num = cmm.generatelinkid();
                    var otp = Convert.ToInt32(num);

                    Facilitation_To_CustomerDMO dmo2 = new Facilitation_To_CustomerDMO();
                    dmo2.consignment_id = item.consignment_id;
                    dmo2.tracking_id = item.tracking_id;
                    dmo2.batch_id = dmo.batch_id;
                    dmo2.first_hub_id = item.first_hub_id;
                    dmo2.last_hub_id = item.last_hub_id;
                    dmo2.first_facilitation_id = item.first_facilitation_id;
                    dmo2.last_facilitation_id = item.last_facilitation_id;
                    dmo2.delivery_executive_id = dto.delivery_executive_id;
                    dmo2.delivery_executive_status = "Pending";
                    dmo2.customer_id = item.customer_id;
                    dmo2.customer_otp = 123456;
                    dmo2.customer_status = "Pending";
                    dmo2.assigned_by = dto.user_id;
                    dmo2.assigned_on = DateTime.UtcNow;
                    _context.Add(dmo2);
                    
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
                         DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
                     };

                    Params = dbParams4;
                    var spName = "call sp_assign_consignment_from_fc_to_customer(:in_consignment_id,:in_user_id,:in_language_id)";
                   var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                    if (status == -1)
                    {
                        dto.status = "Update";

                    }
                    else
                    {
                        dto.status = "Failed";

                    }
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.facilitation_id = usernamm[0].facilitation_id;
                //gethub_consignment_list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id",  dto.facilitation_id),
                         DbHelper.CreateParameter("in_order_by", "ALL")
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_fc_to_cs_consignment_list";
                dto.fc_to_cs_consignment_list = _sql.Get_Data(dto.procedure_name, dbParams);


                //get executive
                var dbParams1 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id",usernamm[0].hub_id)
               };
                Params = dbParams1;
                dto.procedure_name = "fn_get_delivery_executive_list_customer";
                dto.executive_list = _sql.Get_Data(dto.procedure_name, dbParams1);
            }
            catch(Exception ex)
            {

            }
            return dto;
        }
        public Fc_ConsignmentDTO fc_cs_change_order_by(Fc_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_Consignment/fc_cs_change_order_by";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.facilitation_id = usernamm[0].facilitation_id;
                //gethub_consignment_list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id),
                      DbHelper.CreateParameter("in_order_by", dto.order_by)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_fc_to_cs_consignment_list";
                dto.fc_to_cs_consignment_list = _sql.Get_Data(dto.procedure_name, dbParams);


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

        public Fc_ConsignmentDTO accept_from_de(Fc_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_Consignment/accept_from_de";
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
                var spName = "call sp_accept_from_de(:in_user_id,:in_consignment_id,:in_language_id)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                if (status == -1)
                {
                    dto.status = "Accept";

                }
                else
                {
                    dto.status = "Failed";

                }




                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.facilitation_id = usernamm[0].facilitation_id;
                //gethub_consignment_list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_fc_consignment_list_from_vendor";
                dto.fc_consignment_list_from_vendor = _sql.Get_Data(dto.procedure_name, dbParams);

                var dbParams1 = new DbParameter[]
        {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id)
        };
                Params = dbParams1;
                dto.procedure_name = "fn_get_fc_consignment_list_from_hub";
                dto.fc_consignment_list_from_hub = _sql.Get_Data(dto.procedure_name, dbParams1);

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
        public Fc_ConsignmentDTO accept_data_from_hub(Fc_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_Consignment/accept_data_from_hub";
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
                var spName = "call sp_accept_from_hub(:in_user_id,:in_consignment_id,:in_language_id)";
                var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                if (status == -1)
                {
                    dto.status = "Accept";

                }
                else
                {
                    dto.status = "Failed";

                }




                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.facilitation_id = usernamm[0].facilitation_id;
                //gethub_consignment_list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_fc_consignment_list_from_vendor";
                dto.fc_consignment_list_from_vendor = _sql.Get_Data(dto.procedure_name, dbParams);

                var dbParams1 = new DbParameter[]
        {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id)
        };
                Params = dbParams1;
                dto.procedure_name = "fn_get_fc_consignment_list_from_hub";
                dto.fc_consignment_list_from_hub = _sql.Get_Data(dto.procedure_name, dbParams1);

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


        //FC to CS
        public Fc_ConsignmentDTO get_data_fc_hub(Fc_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Fc_Consignment/get_data_fc_hub";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.facilitation_id = usernamm[0].facilitation_id;
                //gethub_consignment_list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_fc_to_hub_consignment_list";
                dto.fc_to_hub_consignment_list = _sql.Get_Data(dto.procedure_name, dbParams);


              

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

        public Fc_ConsignmentDTO assign_fc_to_hub(Fc_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Assign_Consignment/assign_fc_to_hub";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            var Params = new DbParameter[] { };
            try
            {
               
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                var role = _context.Application_User_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.facilitation_id = usernamm[0].facilitation_id;

                //Consignment_BatchDMO dmo = new Consignment_BatchDMO();
                //dmo.send_by_role_id = 9;
                //dmo.send_by_status_id = 6;
                //dmo.receive_by_role_id = 8;
                //dmo.receive_by_status_id = 1;
                //dmo.created_by = dto.user_id;
                //dmo.created_on = DateTime.UtcNow;
                //_context.Add(dmo);
                //_context.SaveChanges();
                ////delivery_executive_id

                //foreach (var item in dto.consignment_fc_hub)
                //{
                //    Consignment_Batch_TxrDMO dmo1 = new Consignment_Batch_TxrDMO();
                //    dmo1.batch_id = dmo.batch_id;
                //    dmo1.consignment_id = item.consignment_id;
                //    dmo1.send_by_role_id = 9;
                //    dmo1.send_by_status_id = 6;
                //    dmo1.receive_by_role_id = 8;
                //    dmo1.receive_by_status_id = 1;
                //    dmo1.created_by = dto.user_id;
                //    dmo1.created_on = DateTime.UtcNow;
                //    _context.Add(dmo1);
                //    var ss = _context.SaveChanges();
                //    if (ss > 0)
                //    {
                //        dto.status = "Update";
                //    }
                //}

                foreach (var item in dto.consignment_fc_hub)
                {
                    var dbParams4 = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_tracking_id", item.tracking_id),
                    DbHelper.CreateParameter("in_batch_id", 0),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
                   };

                    Params = dbParams4;
                    var spName = "call sp_insert_facilitation_to_hub(:in_consignment_id,:in_tracking_id,:in_batch_id,:in_delivery_executive_id,:in_user_id,:in_language_id)";
                  var  status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);

                    if (status == -1)
                    {
                        dto.status = "Update";
                    }
                }


           

                foreach (var item in dto.consignment_fc_hub)
                {
                    var dbParams4 = new DbParameter[]
                     {
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                         DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
                     };

                    Params = dbParams4;
                    var spName = "call sp_assign_consignment_from_fc_to_hub(:in_consignment_id,:in_user_id,:in_language_id)";
                    var status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);
                    if (status == -1)
                    {
                        dto.status = "Update";

                    }
                    else
                    {
                        dto.status = "Failed";

                    }
                }



                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", dto.facilitation_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_fc_to_hub_consignment_list";
                dto.fc_to_hub_consignment_list = _sql.Get_Data(dto.procedure_name, dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
                dto.facilitation_id = usernamm[0].facilitation_id;
               
            }
            catch (Exception ex)
            {

            }
            return dto;
        }
    }
}
