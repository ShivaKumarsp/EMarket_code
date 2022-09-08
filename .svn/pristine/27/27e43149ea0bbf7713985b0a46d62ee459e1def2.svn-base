using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Text;
using System.Linq;

namespace EMarket.DLL.EMarket_Repository.Admin
{
  public  class Master_Category_Specification_Repository: IMaster_Category_Specification_Repository
    {
        int status = 0;
        bool saved = true;
        PostgreSqlContext _context;
        comman_class cmm = new comman_class();
        ISql_Layer _sql;
        IError_Log _error;
        List<string> invalue = new List<string>();
        public Master_Category_Specification_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
        public Master_Category_SpecificationDTO getdata(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification_Repository/getdata";
            return dto;
        }
        public Master_Category_SpecificationDTO savemasterspecification(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification_Repository/savemasterspecification";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);     
            try
            {
                var dbParams = new DbParameter[]
                {
                    DbHelper.CreateParameter("in_masteritemspec_id", dto.masteritemspec_id),
                    DbHelper.CreateParameter("in_additionalcatid", dto.additional_cat_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                    DbHelper.CreateParameter("in_attributenameid", dto.attribute_name_id),
                    DbHelper.CreateParameter("in_languageid", dto.language_id),
                    DbHelper.CreateParameter("in_isrefiner", dto.is_refiner),
                    DbHelper.CreateParameter("in_add_flg", "P"),
                    DbHelper.CreateParameter("in_isvisible", dto.is_visible)
                   
                };
                foreach (var item in dbParams)
                {
                    invalue.Add(item.ParameterName + ':' + item.Value);
                }
                dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
          
                dto.procedure_name = "call sp_save_mastercategoryspecification(:in_masteritemspec_id, :in_additionalcatid,:in_specificationid,:in_attributenameid,:in_languageid,:in_isrefiner,:in_add_flg,:in_isvisible)";
                status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.msg_flg = "Update";
                }
                else
                {
                    dto.msg_flg = "Failed";
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "sp_save_mastercategoryspecification", Params);
            }
            return dto;
        }
        public Master_Category_SpecificationDTO deletemasterspecification(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification_Repository/deletemasterspecification";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                var dbParams = new DbParameter[]
                {
                        DbHelper.CreateParameter("in_catspecid", dto.cat_specid),
                };
                var spName = "call sp_delete_mastercatspecification(:in_catspecid)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.msg_flg = "Delete";
                }
                else
                {
                    dto.msg_flg = "Failed";
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "sp_delete_mastercatspecification", Params);
            }
            return dto;
        }
        public Master_Category_SpecificationDTO getattributelist(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification_Repository/getattributelist";
            //IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            return dto;
        }
        public Master_Category_SpecificationDTO getspecification(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification_Repository/getspecification";
            //IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            return dto;
        }
        public Master_Category_SpecificationDTO getattributename(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category_Specification_Repository/getattributename";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            { 
                try
                {
                    var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                      DbHelper.CreateParameter("in_flg", dto.flag)
                    };

                    var spName = "fn_get_specattributelist";
                    var retObject = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                        dto.attributelist = retObject.ToArray();

                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }


            }
            catch (Exception ex)
            {

            }
            return dto;
        }
        public Master_Category_SpecificationDTO editmasterspecification(Master_Category_SpecificationDTO dto)
        {
            try
            {
                try
                {
                    var check = (from a in _context.Product_Specification_con
                                 from b in _context.Master_Product_con
                                 where a.specification_id == dto.specification_id && a.attribute_name_id == dto.attribute_name_id
                                 && a.product_id == b.product_id && b.additional_cat_id == dto.additional_cat_id
                                 select a).ToList();


                    if (check.Count > 0)
                    {
                        dto.msg_flg = "Failed";
                    }
                    else
                    {
                        dto.msg_flg = "Success";
                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }
                finally
                {

                }

            }
            catch (Exception ex)
            {

            }
            return dto;
        }
        public Master_Category_SpecificationDTO getattributelist_edit(Master_Category_SpecificationDTO dto)
        {
            var Params = new DbParameter[] { };
            try
            {
                var dbParams = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                      DbHelper.CreateParameter("in_additionalcat_id", dto.additional_cat_id),
                      DbHelper.CreateParameter("in_flag", "Edit")
                };
                Params = dbParams;
                dto.procedure_name = "fn_get_attributelist";
                dto.attributelist = _sql.fn_get_list(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.userid);
            }
            return dto;
        }

        // category variant map

        public Master_Category_SpecificationDTO getvariantdata(Master_Category_SpecificationDTO dto)
        {
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
                
                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                    };

                    var spName = "fn_get_additional_category";
                    var retObject = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                        dto.additionalcategorylist = retObject.ToArray();

                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }

                
                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                    };

                    var spName = "fn_get_cat_variant";
                    var retObject = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                        dto.variant_list = retObject.ToArray();

                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }


                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                    };

                    var spName = "fn_get_cat_variant_list";
                    var retObject = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                        dto.cat_variant_list = retObject.ToArray();

                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }
            }
            catch (Exception ex)
            {

            }
            return dto;
        }
        public Master_Category_SpecificationDTO save_cat_variant(Master_Category_SpecificationDTO dto)
        {
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
                if (dto.additional_cat_id == 0)
                {
                    dto.msg_flg = "Please Select Additional Category";
                    return dto;
                }
                if (dto.attribute_name_id == 0)
                {
                    dto.msg_flg = "Please Select Attribute Name";
                    return dto;
                }
                
                try
                {

                    var dbParams = new DbParameter[]
         {
                    DbHelper.CreateParameter("in_add_cat_variant_id", dto.add_cat_variant_id),
                    DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                    DbHelper.CreateParameter("in_attribute_name_id", dto.attribute_name_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
         };
                    var spName = "call sp_save_cat_variant(:in_add_cat_variant_id, :in_additional_cat_id,:in_attribute_name_id,:in_language_id)";
                    status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                    if (status == -1)
                    {
                        if(dto.add_cat_variant_id>0)
                        {
                            dto.status = "Update";
                            dto.message = "Variant Updated Successfully";
                        }
                        else
                        {
                            dto.status = "Update";
                            dto.message = "Variant Inserted Successfully";
                        }
                      
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }
                    var dbParams1 = new DbParameter[]
                  {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                  };

                    var spName1 = "fn_get_cat_variant_list";
                    var retObject = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName1, CommandType.StoredProcedure, dbParams1))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                        dto.cat_variant_list = retObject.ToArray();

                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }
                finally
                {

                }

                
                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                    };

                    var spName = "fn_get_cat_variant_list";
                    var retObject = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                        dto.cat_variant_list = retObject.ToArray();

                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }
            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.userid);

            }
            return dto;
        }
        public Master_Category_SpecificationDTO get_variant_list(Master_Category_SpecificationDTO dto)
        {
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                    };

                    var spName = "fn_get_cat_variant_list";
                    var retObject = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                        dto.cat_variant_list = retObject.ToArray();

                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }


                finally
                {

                }
            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.userid);

            }
            return dto;
        }

        public Master_Category_SpecificationDTO delete_cat_variant(Master_Category_SpecificationDTO dto)
        {
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
                               try
                {

                    var dbParams = new DbParameter[]
         {
                    DbHelper.CreateParameter("in_add_cat_variant_id", dto.add_cat_variant_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id)
         };
                    var spName = "call sp_delete_cat_variant(:in_add_cat_variant_id, :in_language_id)";
                    status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                    if (status == -1)
                    {
                        dto.msg_flg = "Delete";
                    }
                    else
                    {
                        dto.msg_flg = "Failed";
                    }

                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }
                finally
                {

                }

                                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id),
                    };

                    var spName = "fn_get_cat_variant_list";
                    var retObject = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                        dto.cat_variant_list = retObject.ToArray();

                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }


                finally
                {

                }

            }
            catch (Exception ex)
            {

            }
            return dto;
        }
    }
}
