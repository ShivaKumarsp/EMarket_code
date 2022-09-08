using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Vendor
{
    public class Add_Item_Specification_Repository: IAdd_Item_Specification_Repository
    {
        int status = 0;
        bool saved = false;
        PostgreSqlContext _context;
        comman_class cmm = new comman_class();
        ISql_Layer _sql;
        IError_Log _error;
        public Add_Item_Specification_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
      
        public Add_Item_SpecificationDTO savespecification(Add_Item_SpecificationDTO dto)
        {
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
                //    try
                //{

                //    using (var conn = new NpgsqlConnection(cmm.ConnectionString))
                //    {
                //        NpgsqlCommand cmd = new NpgsqlCommand("call sp_add_item_Specification(:in_itemspecificationid,:in_specificationid, :in_propertyname,:in_propertydetails,:in_itemid)", conn);
                //        cmd.Parameters.AddWithValue("in_itemspecificationid", DbType.Int64).Value = dto.item_specification_id;
                //        cmd.Parameters.AddWithValue("in_specificationid", DbType.Int64).Value = dto.specification_id;
                //        cmd.Parameters.AddWithValue("in_propertyname", DbType.String).Value = dto.property_name;
                //        cmd.Parameters.AddWithValue("in_propertydetails", DbType.String).Value = dto.property_details;
                //        cmd.Parameters.AddWithValue("in_itemid", DbType.Int64).Value = dto.item_id;

                //        conn.Open();
                //        var affectcount = cmd.ExecuteNonQuery();
                //        saved = affectcount == 1;
                //        if (affectcount == -1)
                //        {
                //            dto.msg_flg = "Update";
                //        }
                //        else
                //        {
                //            dto.msg_flg = "Failed";
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //   _error.errorlog1(ex, dto.userid);
                //}
                //finally
                //{

                //}
                try
                {

                    var dbParams = new DbParameter[]
         {
                    DbHelper.CreateParameter("in_itemspecificationid", dto.item_specification_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                    DbHelper.CreateParameter("in_propertyname", dto.property_name),
                    DbHelper.CreateParameter("in_propertydetails", dto.property_details),
                    DbHelper.CreateParameter("in_itemid", dto.item_id),
         };
                    var spName = "call sp_add_item_Specification(:in_itemspecificationid,:in_specificationid, :in_propertyname,:in_propertydetails,:in_itemid)";
                    status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
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

        public Add_Item_SpecificationDTO getitemspecification(Add_Item_SpecificationDTO dto)
        {
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
                //try
                //{
                //    using (var conn = new NpgsqlConnection(cmm.ConnectionString))
                //    {
                //        NpgsqlCommand cmd = new NpgsqlCommand("fn_get_itemspecification", conn);
                //        cmd.Parameters.Add(new NpgsqlParameter("@in_languageid", 1));
                //        cmd.Parameters.Add(new NpgsqlParameter("@in_item_id", dto.item_id));
                //        conn.Open();
                //        cmd.CommandType = CommandType.StoredProcedure;

                //        var retObject = new List<dynamic>();
                //        try
                //        {
                //            using (var dataReader = cmd.ExecuteReader())
                //            {
                //                while (dataReader.Read())
                //                {
                //                    var dataRow = new ExpandoObject() as IDictionary<string, object>;
                //                    for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                //                    {
                //                        dataRow.Add(
                //                            dataReader.GetName(iFiled),
                //                            dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                //                        );
                //                    }

                //                    retObject.Add((ExpandoObject)dataRow);
                //                }
                //            }
                //            dto.itemspecificationlist = retObject.ToArray();
                //        }
                //        catch (Exception ex)
                //        {
                //           
                //        }
                //        finally
                //        {
                //            conn.Close();
                //        }

                //    }
                //}
                //catch (Exception ex)
                //{
                //   _error.errorlog1(ex, dto.userid);
                //}
                //finally
                //{

                //}
                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                    };

                    var spName = "fn_get_itemspecification";
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
                        dto.itemspecificationlist = retObject.ToArray();

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
        public Add_Item_SpecificationDTO editspecification(Add_Item_SpecificationDTO dto)
        {
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
                //try
                //{
                //    using (var conn = new NpgsqlConnection(cmm.ConnectionString))
                //    {
                //        NpgsqlCommand cmd = new NpgsqlCommand("fn_get_itemspecification", conn);
                //        cmd.Parameters.Add(new NpgsqlParameter("@in_languageid", 1));
                //        cmd.Parameters.Add(new NpgsqlParameter("@in_item_id", dto.item_id));
                //        conn.Open();
                //        cmd.CommandType = CommandType.StoredProcedure;

                //        var retObject = new List<dynamic>();
                //        try
                //        {
                //            using (var dataReader = cmd.ExecuteReader())
                //            {
                //                while (dataReader.Read())
                //                {
                //                    var dataRow = new ExpandoObject() as IDictionary<string, object>;
                //                    for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                //                    {
                //                        dataRow.Add(
                //                            dataReader.GetName(iFiled),
                //                            dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                //                        );
                //                    }

                //                    retObject.Add((ExpandoObject)dataRow);
                //                }
                //            }
                //            dto.itemspecificationlist = retObject.ToArray();
                //        }
                //        catch (Exception ex)
                //        {
                //           
                //        }
                //        finally
                //        {
                //            conn.Close();
                //        }

                //    }
                //}
                //catch (Exception ex)
                //{
                //   _error.errorlog1(ex, dto.userid);
                //}
                //finally
                //{

                //}

                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                    };

                    var spName = "fn_get_itemspecification";
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
                        dto.itemspecificationlist = retObject.ToArray();

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

    }
}
