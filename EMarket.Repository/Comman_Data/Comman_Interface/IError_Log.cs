using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.DLL.Comman_Data.Comman_Interface
{
   public interface IError_Log
    {
        void errorlog(Exception ex, long userid, string methodname, string ipAddress, string apitype, string page_form, string pname, params DbParameter[] dbParams);

        void errorlog_add(Exception ex, long userid, string methodname, string ipAddress, string apitype, string page_form, string pname, string inputvalue);
        void errorlog1(Exception ex, long userid);
        void audit_log(long userid, string ipAddress, string apitype, string token);
        void audit_log_txr(long userid, string methodname, string page_form);
        void audit_log_txr_logout(long userid, string methodname, string page_form);
    }
}
