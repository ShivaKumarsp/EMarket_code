using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Vendor;
using EMarket.DLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Npgsql;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using static EMarketDTO.Vendar.Vendor_DocumentDTO;

namespace EMarket.BLL.EMarket_Service.Vendor
{
    
    public class Vendor_Document: IVendor_Document
    {
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        IVendor_Document_Repository _inter;
        public Vendor_Document(IVendor_Document_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Vendor_DocumentDTO getdata(Vendor_DocumentDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Document/getdata";
            var vendorid = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
            dto.vendor_id = vendorid.vendor_id;
            dto.is_doc_verify = vendorid.is_verify;
            dto.is_profile_verify = vendorid.approved_flg;
            try
            {
           
               

                //vendor documents
                try
                {
                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("vendorid", dto.vendor_id),
                      DbHelper.CreateParameter("languageid",dto.language_id),
                    };
                    Params = dbParams1;
                    dto.vendordocumentlist = _sql.Get_Data("fn_get_vendor_documents", dbParams1);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_vendor_documents", Params);
                }
                //Master documents
                try
                {
                    var dbParams2 = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_languageid",  dto.language_id),
                   
                    };
                    Params = dbParams2;
                    dto.documentlist = _sql.Get_Data("fn_getmasterdocuments", dbParams2);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getmasterdocument", Params);
                }
                //vendor_profile list
                try
                {
                    var dbParams2 = new DbParameter[]
                    {
                        DbHelper.CreateParameter("in_languageid",  dto.language_id),

                    };
                    Params = dbParams2;
                    dto.documentlist = _sql.Get_Data("fn_getmasterdocuments", dbParams2);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getmasterdocument", Params);
                }
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "getdata", Params);
            }
            return _inter.getdata(dto);
        }
        public Vendor_DocumentDTO save_vendor_documents(Vendor_DocumentDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Document/save_vendor_documents";
            //Master documents
            try
            {
                var dbParams2 = new DbParameter[]
                {
                        DbHelper.CreateParameter("in_languageid",  dto.language_id),
                        DbHelper.CreateParameter("in_md_id",  dto.md_id),
                };
                Params = dbParams2;
                dto.documentlist = _sql.Get_Data("fn_getmasterdocument", dbParams2);
                
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_getmasterdocument", Params);
            }
            
            docVerify myDeserializedClass = JsonConvert.DeserializeObject<docVerify>(dto.documentlist);

            if (dto.md_documentname==myDeserializedClass.Table[0].mddocumentname)
            {
                //validation
                    //string panno = @"[A-Z]{5}[0-9]{4}[A-Z]{1}";
                    string panno = myDeserializedClass.Table[0].mdpattern;
                
                Regex panrx = new Regex(panno);
                if (!panrx.IsMatch(dto.md_document_no))
                {
                    dto.messageflg = "Please Enter Valid "+ myDeserializedClass.Table[0].mddocumentname;
                    return dto;
                }
                
            }
            return _inter.save_vendor_documents(dto);
        }
        //update
        //public Vendor_DocumentDTO update_vendor_documents(Vendor_DocumentDTO dto)
        //{
        //    var Params = new DbParameter[] { };
        //    var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
        //    string methodname = "Vendor_Document/update_vendor_documents";
        //    return _inter.update_vendor_documents(dto);
        //}

    }
}
