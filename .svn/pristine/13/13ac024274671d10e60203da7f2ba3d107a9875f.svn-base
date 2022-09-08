using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Master
{
    public class Test : ITest
    {
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;


        public Test(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

        public TestDTO get_data(TestDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Test/get_data";
            var Params = new DbParameter[] { };
            try
            {

                //get hub list 1
                var dbParams6 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams6;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.Get_Data(dto.procedure_name, dbParams6);

                //get cal hub list 
                var dbParams7 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                 };
                Params = dbParams7;
                dto.procedure_name = "fn_get_calculate_hub_route";
                dto.hub_route_list = _sql.Get_Data(dto.procedure_name, dbParams7);

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
