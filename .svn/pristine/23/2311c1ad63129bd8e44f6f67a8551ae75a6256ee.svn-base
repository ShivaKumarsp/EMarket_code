using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Master;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Master
{
    public class Map_Specification_Attribute : IMap_Specification_Attribute
    {
        IMap_Specification_Attribute_Repository _inter;
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;

        public Map_Specification_Attribute(IMap_Specification_Attribute_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
        }

        public Master_SpecificationDTO get_data(Master_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Specification_Attribute/getdata";

            try
            {
                //specification
                var dbParams = new DbParameter[]
                {
               DbHelper.CreateParameter("in_language_id", dto.language_id),
                
                };
                Params = dbParams;
                dto.procedure_name = "fn_get_specification_dd";
                dto.specification_dd = _sql.Get_Data(dto.procedure_name, dbParams);
                long spec = 0;
                //specification attribute name list
                var dbParams1 = new DbParameter[]
                {
               DbHelper.CreateParameter("in_language_id", dto.language_id),
               DbHelper.CreateParameter("in_specification_id", Convert.ToInt64(spec)),
               DbHelper.CreateParameter("in_flg", "list"),
                };
                Params = dbParams1;
                dto.procedure_name = "fn_get_specification_attribute_grid";
                dto.specification_attribute_list = _sql.Get_Data(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Master_SpecificationDTO get_attribute_name(Master_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Specification_Attribute/get_attribute_name";

            try
            {
                //attribute name
                var dbParams = new DbParameter[]
                {
               DbHelper.CreateParameter("in_language_id", dto.language_id),
               DbHelper.CreateParameter("in_specification_id", dto.specification_id),
               DbHelper.CreateParameter("in_attributename_id",Convert.ToInt64(0))
                };
                Params = dbParams;
                dto.procedure_name = "fn_get_attribute_name_dd";
                dto.attribute_name_dd = _sql.Get_Data(dto.procedure_name, dbParams);
               
                //specification attribute name list
                var dbParams1 = new DbParameter[]
                {
               DbHelper.CreateParameter("in_language_id", dto.language_id),
               DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                DbHelper.CreateParameter("in_flg", "data")
                };
                Params = dbParams1;
                dto.procedure_name = "fn_get_specification_attribute_grid";
                dto.specification_attribute_list = _sql.Get_Data(dto.procedure_name, dbParams1);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Master_SpecificationDTO get_attribute_name_edit(Master_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Specification_Attribute/get_attribute_name_edit";

            try
            {
                //attribute name
                var dbParams = new DbParameter[]
                {
               DbHelper.CreateParameter("in_language_id", dto.language_id),
               DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                  DbHelper.CreateParameter("in_attributename_id",dto.attribute_name_id)

                };
                Params = dbParams;
                dto.procedure_name = "fn_get_attribute_name_dd";
                dto.attribute_name_dd = _sql.Get_Data(dto.procedure_name, dbParams);

               
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Master_SpecificationDTO save_data(Master_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Specification_Attribute/save_specification";

            if (dto.specification_id ==0)
            {
                dto.status = "Failed";
                dto.message = "Please Select Specification Name";
                return dto;
            }
            if (dto.attribute_name_id == 0)
            {
                dto.status = "Failed";
                dto.message = "Please Select Attribute Name";
                return dto;
            }
            try
            {
                _inter.save_data(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            try
            {
                //specification attribute name list
                var dbParams = new DbParameter[]
                {
               DbHelper.CreateParameter("in_language_id", dto.language_id),
                DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                DbHelper.CreateParameter("in_flg", "data"),
                };
                Params = dbParams;
                dto.procedure_name = "fn_get_specification_attribute_grid";
                dto.specification_attribute_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //attribute name
                var dbParams1 = new DbParameter[]
                {
               DbHelper.CreateParameter("in_language_id", dto.language_id),
               DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                   DbHelper.CreateParameter("in_attributename_id",Convert.ToInt64(0))
                };
                Params = dbParams1;
                dto.procedure_name = "fn_get_attribute_name_dd";
                dto.attribute_name_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

          finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
           
            return dto;
        }
        public Master_SpecificationDTO delete_spec_attribute(Master_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Map_Specification_Attribute/delete_spec_attribute";

            if (dto.specification_id == 0)
            {
                dto.status = "Failed";
                dto.message = "Please Select Specification Name";
                return dto;
            }
            if (dto.attribute_name_id == 0)
            {
                dto.status = "Failed";
                dto.message = "Please Select Attribute Name";
                return dto;
            }
            try
            {
                var result = _context.product_item_specificationDMO_con.Where(a => a.specification_id == dto.specification_id && a.attribute_name_id == dto.attribute_name_id).ToList();
                if(result.Count>0)
                {
                    dto.status = "Failed";
                    dto.message = "You Can't Delete, Already Mapped with Product";
                    return dto;
                }

                _inter.delete_spec_attribute(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            try
            {
                //specification attribute name list
                var dbParams = new DbParameter[]
                {
               DbHelper.CreateParameter("in_language_id", dto.language_id),
                DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                DbHelper.CreateParameter("in_flg", "data"),
                };
                Params = dbParams;
                dto.procedure_name = "fn_get_specification_attribute_grid";
                dto.specification_attribute_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //attribute name
                var dbParams1 = new DbParameter[]
                {
               DbHelper.CreateParameter("in_language_id", dto.language_id),
               DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                   DbHelper.CreateParameter("in_attributename_id",Convert.ToInt64(0))
                };
                Params = dbParams1;
                dto.procedure_name = "fn_get_attribute_name_dd";
                dto.attribute_name_dd = _sql.Get_Data(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }

            return dto;
        }
    }
}
