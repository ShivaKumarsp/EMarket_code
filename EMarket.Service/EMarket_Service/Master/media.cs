using EMarket.BLL.Comman_Class.Interface;
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
    public class media: Imedia
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Imedia_Repository _inter;
        public media(Imedia_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }
        //fn_media
        public mediaDTO view(mediaDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "media/view";
            _error.audit_log_txr(dto.userid, methodname, page_form);

            // documents
            try
                {
                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("mediaid",dto.media_id),
                    };
                    Params = dbParams1;
                    dto.medialist = _sql.Get_Data("fn_media", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_media", Params);
                }
            return _inter.view(dto);
        }
        //get media
        public mediaDTO get_media(mediaDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "media/get_media";
            _error.audit_log_txr(dto.userid, methodname, page_form);

            // documents
            try
            {
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("mediaid",dto.media_id),
                };
                Params = dbParams1;
                dto.medialist1 = _sql.Get_Data("fn_get_media_detail", dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_media_detail", Params);
            }
            return _inter.get_media(dto);
        }

        //get all media
        public mediaDTO get_allmedia(mediaDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "media/get_allmedia";
            _error.audit_log_txr(dto.userid, methodname, page_form);

            // documents
            try
            {
                dto.allmedialist = _sql.Get_Data("fn_get_media_alldetail", Params);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_media_alldetail", Params);
            }
            return _inter.get_allmedia(dto);
        }


        //save
        public mediaDTO save_media(mediaDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "media/save_media";
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return _inter.save_media(dto);
        }

        //Delete
        public mediaDTO Delete(mediaDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "media/Delete";
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return _inter.Delete(dto);
        }
    }
}
