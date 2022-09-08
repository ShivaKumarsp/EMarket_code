using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Facilitation;
using EMarket.Entities;
using EMarketDTO.Facilitation;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Facilitation
{
    public class All_FC_Consignment_List: IAll_FC_Consignment_List
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        int status = 0;

        public All_FC_Consignment_List(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        public All_FC_Consignment_ListDTO get_data(All_FC_Consignment_ListDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_FC_Consignment_List/get_data";
            var Params = new DbParameter[] { };
            try
            {
                var usernamm = _context.Facilitation_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();

                //get all list
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_facilitation_id", usernamm[0].facilitation_id),
               };
                Params = dbParams;
                
                dto.procedure_name = "fn_get_all_consignment_list";
                dto.all_consignment_list = _sql.Get_Data(dto.procedure_name, dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
    }
}
