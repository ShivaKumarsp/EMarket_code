using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Vendar
{
    public class Vendor_DocumentDTO
    {
        public long vdoc_id { get; set; }
        public long vendor_id { get; set; }
        public long userid { get; set; }
        public long mg_id { get; set; }
        public string md_document_no { get; set; }
        public string vdoc_filename { get; set; }
        public string vdoc_fileurl { get; set; }
        
        public string vdoc_description { get; set; }
        public DateTime vdoc_uploaddate { get; set; }
        public string vdoc_status { get; set; }
        public long vdoc_approveorreject_by { get; set; }
        public DateTime vdoc_approveorreject_on { get; set; }
        public string vdoc_approveorreject_description { get; set; }
        public long re_upload { get; set; }
        public string documentlist { get; set; }
        public string vendordocumentlist { get; set; }
        public string username { get; set; }
        public string rolename { get; set; }
        public long roleid { get; set; }
        public string msg_flg { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public long is_doc_verify { get; set; }
        public bool is_profile_verify { get; set; }
        //
        public long md_id { get; set; }
        public string md_documentname { get; set; }
        public string md_description { get; set; }
        public bool md_activeflg { get; set; }
        public DateTime createdon { get; set; }
        public long createdby { get; set; }
        public DateTime updatedon { get; set; }
        public long updatedby { get; set; }
        public long language_id { get; set; }
        public string getdocumentlist { get; set; }
        public string messageflg { get; set; }
        public string procedure_name { get; set; }

        public int test { get; set; }
        //
        public docarray1[] doc_array { get; set; }
        public class docarray1
        {
            public long md_id { get; set; }
            public string documentno { get; set; }
            public string description { get; set; }
            
        }

        public class docVerify
        {
            public List<Table> Table { get; set; }
        }

        public class Table
        {
            public int mdid { get; set; }
            public string mddocumentname { get; set; }
            public string mdpattern { get; set; }
        }
        
    }
}
