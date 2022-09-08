using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.EMarket_Repository.Admin;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class Document_verification: IDocument_verification
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        IDocument_verification_Repository _inter;
        public Document_verification(IDocument_verification_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter= inter;
            _context = context;
            _sql = sql;
            _error = error;
        }

        public Document_verificationDTO getdocuments(Document_verificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Document_verification/getdocuments";
            _error.audit_log_txr(dto.userid, methodname, page_form);
            //var vendorid = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
            //dto.vendor_id = vendorid.vendor_id;
            try
            {
                // documents
                try
                {
                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("languageid",dto.language_id),
                    };
                    Params = dbParams1;
                    dto.alldocumentlist = _sql.Get_Data("fn_get_documents", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_vendor_documents", Params);
                }
                //status
                try
                {
                    //var dbParams2 = new DbParameter[]
                    //{
                    //    DbHelper.CreateParameter("in_languageid",  dto.language_id),
                    //};
                    //Params = dbParams2;
                    dto.statuslist = _sql.Get_Data("fn_status");
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_status", Params);
                }
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "getdocuments", Params);
            }
            return _inter.getdocuments(dto);
        }

        public Document_verificationDTO save_documents(Document_verificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Document_verification/save_documents";
            if (dto.vdoc_status!=0)
            {
                dto.messageflg = "Please select status";

            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return _inter.save_documents(dto);
        }
    }
}
