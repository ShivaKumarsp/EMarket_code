using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Master;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Master
{
    public class masterdocument: Imasterdocument
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Imasterdocument_Repository _inter;
        public masterdocument(Imasterdocument_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }
        //get on load
        public masterdocumentDTO getdata(masterdocumentDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "masterdocument/getdata";
            try
            {
                //master documents
                try
                {
                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id",dto.language_id),
                    };
                    Params = dbParams1;
                    dto.masterdocumentlist = _sql.Get_Data("fn_masterdocuments", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_masterdocuments", Params);
                }
                            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "getdata", Params);
            }
            return _inter.getdata(dto);
        }
        
        //save
        public masterdocumentDTO save(masterdocumentDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "masterdocument/save";
            return _inter.save(dto);
        }


    }
}
