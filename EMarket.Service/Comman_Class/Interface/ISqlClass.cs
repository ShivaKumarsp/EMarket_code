using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.Comman_Class.Interface
{
    public interface ISqlClass
    {
        Array fn_get_list(string query, params DbParameter[] dbParams);
        string Get_ExecuteScalar(string query, params DbParameter[] dbParams);
        string Get_Data(string query, params DbParameter[] dbParams);


    }
}
