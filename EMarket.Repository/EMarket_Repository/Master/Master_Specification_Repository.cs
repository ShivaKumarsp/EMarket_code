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
    public class Master_Specification_Repository : IMaster_Specification_Repository
    {
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        int status = 0;
        List<string> invalue = new List<string>();
        public Master_Specification_Repository(PostgreSqlContext context)
        {
            _context = context;

        }
        public Master_SpecificationDTO save_specification(Master_SpecificationDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams = new DbParameter[]
    {
                    DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                    DbHelper.CreateParameter("in_specification_name", dto.specification_name.Trim()),
                    DbHelper.CreateParameter("in_specification_code", dto.specification_code.Trim()),
                     DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)

    };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);

            dto.procedure_name = "call sp_save_master_specification(:in_specification_id,:in_specification_name, :in_specification_code,:in_user_id,:in_language_id)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
                if (dto.specification_id > 0)
                {
                    dto.status = "Update";
                    dto.message = "Specification Update Successfully";
                }
                else
                {
                    dto.status = "Insert";
                    dto.message = "Specification  Inserted Successfully";
                }

            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed to Insert/Update";
            }

            return dto;
        }
        public Master_SpecificationDTO save_attrname(Master_SpecificationDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams = new DbParameter[]
    {
                    DbHelper.CreateParameter("in_attribute_name_id", dto.attribute_name_id),
                    DbHelper.CreateParameter("in_attribute_name", dto.attribute_name.Trim()),
                    DbHelper.CreateParameter("in_attribute_code", dto.attribute_code.Trim()),
                     DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)

    };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);

            dto.procedure_name = "call sp_save_master_attributename(:in_attribute_name_id,:in_attribute_name, :in_attribute_code,:in_user_id,:in_language_id)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
                if (dto.attribute_name_id > 0)
                {
                    dto.status = "Update";
                    dto.message = "Attribute Name Update Successfully";
                }
                else
                {
                    dto.status = "Insert";
                    dto.message = "Attribute Name  Inserted Successfully";
                }

            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed to Insert/Update";
            }

            return dto;
        }
        public Master_SpecificationDTO save_attrvalue(Master_SpecificationDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams = new DbParameter[]
    {
                    DbHelper.CreateParameter("in_attribute_value_id", dto.attribute_value_id),
                    DbHelper.CreateParameter("in_attribute_name_id", dto.attribute_name_id),
                    DbHelper.CreateParameter("in_attribute_value", dto.attribute_value.Trim()),
                    DbHelper.CreateParameter("in_attribute_code", dto.attribute_code.Trim()),
                     DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)

    };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);

            dto.procedure_name = "call sp_save_master_attributevalue(:in_attribute_value_id,:in_attribute_name_id,:in_attribute_value, :in_attribute_code,:in_user_id,:in_language_id)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
                if (dto.attribute_name_id > 0)
                {
                    dto.status = "Update";
                    dto.message = "Attribute Value Update Successfully";
                }
                else
                {
                    dto.status = "Insert";
                    dto.message = "Attribute Value  Inserted Successfully";
                }

            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed to Insert/Update";
            }

            return dto;
        }
        public Master_SpecificationDTO delete_specidfication(Master_SpecificationDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams = new DbParameter[]
    {
                    DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)

    };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);

            dto.procedure_name = "call sp_delete_master_specification(:in_specification_id,:in_language_id)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
                if (dto.specification_id > 0)
                {
                    dto.status = "Delete";
                    dto.message = "Specification Deleted Successfully";
                }
               

            }
            else
            {
                dto.status = "Failed";
                dto.message = "Failed to Insert/Update";
            }

            return dto;
        }
    }
}
