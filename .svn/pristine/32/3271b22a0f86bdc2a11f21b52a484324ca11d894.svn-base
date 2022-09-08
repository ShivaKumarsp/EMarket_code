using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.HubManager;
using EMarket.Entities;
using EMarketDTO.HubManager;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.HubManager
{
    public class Hub_Consignment: IHub_Consignment
    {
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;


        public Hub_Consignment(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

        public Hub_ConsignmentDTO get_data(Hub_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_Consignment/get_data";
            var Params = new DbParameter[] { };
            try
            {

                //gethub_consignment_list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.user_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_consignment_batch_list";
                dto.hub_consignment_list = _sql.Get_Data(dto.procedure_name, dbParams);

                

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
        public Hub_ConsignmentDTO get_route_data(Hub_ConsignmentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Hub_Consignment/get_route_data";
            var Params = new DbParameter[] { };
            try
            {

                //gethub_consignment_list
                var dbParams = new DbParameter[]
               {
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                     
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_route_details";
                dto.hub_route_details = _sql.Get_Data(dto.procedure_name, dbParams);



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
