using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Master
{
   public class Map_Specification_Attribute_Repository: IMap_Specification_Attribute_Repository
    {
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        ISql_Layer _sql;
        IError_Log _error;
        int status = 0;
        string return_string = "";
        List<string> invalue = new List<string>();

        public Map_Specification_Attribute_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
             
        public Master_SpecificationDTO save_data(Master_SpecificationDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams = new DbParameter[]
            {
                    DbHelper.CreateParameter("in_specattrid", dto.spe_attr_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                    DbHelper.CreateParameter("in_attribtenameid", dto.attribute_name_id),
                     DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)                   
            
            };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
   
            dto.procedure_name = "call sp_save_mappedspecificationattribute(:in_specattrid,:in_specificationid, :in_attribtenameid,:in_user_id,:in_language_id)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
                if(dto.spe_attr_id>0)
                {
                    dto.status = "Update";
                    dto.message = "Updated Successfully.";
                }
                else
                {
                    dto.status = "Insert";
                    dto.message = "Inserted Successfully";
                }
               
            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed to Insert/Update";
            }

            return dto;
        }
        public Master_SpecificationDTO delete_spec_attribute(Master_SpecificationDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams = new DbParameter[]
    {
                    DbHelper.CreateParameter("in_specattrid", dto.spe_attr_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)

    };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);

            dto.procedure_name = "call sp_delete_mappedspecificationattribute(:in_specattrid,:in_language_id)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
                
                    dto.status = "Delete";
                    dto.message = "Deleted Successfully.";
               

            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed to Delete";
            }

            return dto;
        }
    }
}
