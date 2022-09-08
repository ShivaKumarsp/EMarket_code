using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;


namespace EMarket.DLL.EMarket_Repository.Vendor
{
    public class Vendor_Document_Repository: IVendor_Document_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        int status = 0;
        public Vendor_Document_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Vendor_DocumentDTO getdata(Vendor_DocumentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Document_Repository/getdata";
            return dto;
        }
        public Vendor_DocumentDTO save_vendor_documents(Vendor_DocumentDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Document_Repository/save_vendor_documents";
            var vendorid = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
            dto.vendor_id = vendorid.vendor_id;
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                {
                    var dbParams = new DbParameter[]
                    {
                        DbHelper.CreateParameter("p_vdocid",dto.vdoc_id),
                        DbHelper.CreateParameter("p_vendorid",dto.vendor_id),
                        DbHelper.CreateParameter("p_userid",dto.userid),
                        DbHelper.CreateParameter("p_mdid",dto.md_id),
                        DbHelper.CreateParameter("p_documentno",dto.md_document_no),
                        DbHelper.CreateParameter("p_filename",dto.vdoc_filename),
                        DbHelper.CreateParameter("p_fileurl",dto.vdoc_fileurl),
                        DbHelper.CreateParameter("p_description",dto.vdoc_description),
                        DbHelper.CreateParameter("p_vdocstatus",1),

                    };
                    dto.procedure_name = "call sp_saveupdate_vendor_document(:p_vdocid,:p_vendorid,:p_userid,:p_mdid,:p_documentno,:p_filename,:p_fileurl,:p_description,:p_vdocstatus)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                    //saved = status == 1;
                    if (status == -1)
                    {
                        dto.msg_flg = "Update";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }
                }
                
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "sp_save_vendor_document", page_form);
            }
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }

        //update
        //public Vendor_DocumentDTO update_vendor_documents(Vendor_DocumentDTO dto)
        //{
        //    var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
        //    string methodname = "Vendor_Document_Repository/update_vendor_documents";
        //    IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
        //    try
        //    {
        //        using (var conn = new NpgsqlConnection(cmm.ConnectionString))
        //        {
        //            var dbParams = new DbParameter[]
        //            {
        //                DbHelper.CreateParameter("p_vdocid", dto.vdoc_id),
        //                DbHelper.CreateParameter("p_documentno", dto.md_document_no)
        //            };
        //            dto.procedure_name = "call sp_update_vendor_document(:p_vdocid,:p_documentno)";
        //            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
        //            saved = status == 1;
        //            if (status == -1)
        //            {
        //                dto.msg_flg = "Update";
        //            }
        //            else
        //            {
        //                dto.msg_flg = "Failed";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, "update_vendor_documents", page_form);
        //    }
        //    _error.audit_log_txr(dto.userid, methodname, page_form);
        //    return dto;
        //}
    }
}
