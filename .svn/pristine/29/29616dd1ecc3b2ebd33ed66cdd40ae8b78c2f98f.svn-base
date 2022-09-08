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
using System.Linq;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Admin
{
   public class Manage_Subsubcategory_Repository: IManage_Subsubcategory_Repository
    {
        int status = 0;
        bool saved = true;
        PostgreSqlContext _context;
        comman_class cmm = new comman_class();
        ISql_Layer _sql;
        IError_Log _error;
        List<string> invalue = new List<string>();
        public Manage_Subsubcategory_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

        
        public Manage_SubsubcategoryDTO savemanagesubcat(Manage_SubsubcategoryDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var dbParams = new DbParameter[]
     {
                    DbHelper.CreateParameter("p_additionalcatid", dto.additional_cat_id),
                    DbHelper.CreateParameter("p_mscid", dto.msc_id),
                    DbHelper.CreateParameter("p_additionalcatname", dto.additional_cat_name),
                    DbHelper.CreateParameter("p_additionalcatcode", dto.additional_cat_code),
                    DbHelper.CreateParameter("p_languageid", dto.language_id),
                       DbHelper.CreateParameter("p_imageurl", dto.image_url),
                       DbHelper.CreateParameter("p_user_id", dto.userid),
                       DbHelper.CreateParameter("p_description", dto.description),
                       DbHelper.CreateParameter("p_mc_id", dto.mc_id),
     };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
            dto.procedure_name = "fn_add_product";

            var spName = "call sp_save_additional_category(:p_additionalcatid, :p_mscid,:p_additionalcatname,:p_additionalcatcode,:p_languageid,:p_imageurl,:p_user_id,:p_description,:p_mc_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.status = "Insert";
                    dto.message = "Insert/Updated Successfully";
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Not Insert/Updated Successfully";
                }

            
            return dto;
        }
        public Manage_SubsubcategoryDTO deletemanagesubcat(Manage_SubsubcategoryDTO dto)
        {
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
                //    try
                //    {




                //        using (var conn = new NpgsqlConnection(cmm.ConnectionString))
                //        {
                //            NpgsqlCommand cmd = new NpgsqlCommand("call sp_delete_additionalcat(:in_additionalcatid)", conn);
                //            cmd.Parameters.AddWithValue("in_additionalcatid", DbType.Int64).Value = dto.additional_cat_id;
                //            //cmd.Parameters.AddWithValue("p_mscid", DbType.Int64).Value = dto.msc_id;
                //            //cmd.Parameters.AddWithValue("p_additionalcatname", DbType.String).Value = dto.additional_cat_name;
                //            //cmd.Parameters.AddWithValue("p_additionalcatcode", DbType.String).Value = dto.additional_cat_code;
                //            //cmd.Parameters.AddWithValue("p_languageid", DbType.Int64).Value = dto.language_id;

                //            conn.Open();
                //            var affectcount = cmd.ExecuteNonQuery();
                //            saved = affectcount == 1;
                //            if (affectcount == -1)
                //            {
                //                dto.msg_flg = "Delete";
                //            }
                //            else
                //            {
                //                dto.msg_flg = "Failed";
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //       _error.errorlog1(ex, dto.userid);
                //    }
                //    finally
                //    {

                //    //}
                try
                {




                    var dbParams = new DbParameter[]
         {
                    DbHelper.CreateParameter("in_additionalcatid", dto.additional_cat_id)

         };
                    var spName = "call sp_delete_additionalcat(:in_additionalcatid)";
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
            }
            catch (Exception ex)
            {

            }
            return dto;
        }

        public Manage_SubsubcategoryDTO savemastercategory(Manage_SubsubcategoryDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                var dbParams = new DbParameter[]
         {
                    DbHelper.CreateParameter("in_mcid", dto.mc_id),
                    DbHelper.CreateParameter("in_categoryname", dto.category_name),
                    DbHelper.CreateParameter("in_categorycode", dto.category_code),
                    DbHelper.CreateParameter("in_description", dto.description),
                    DbHelper.CreateParameter("in_imageurl", dto.image_url),
                    DbHelper.CreateParameter("in_languageid", dto.language_id)
              };

                var spName = "call sp_save_mastercategory(:in_mcid,:p_mscid, :in_categoryname,:in_categorycode,:in_description,:in_imageurl,:in_languageid)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                if (status == -1)
                {
                    dto.msg_flg = "Update";
                }
                else
                {
                    dto.msg_flg = "Failed";
                }

                

                //using (var conn = new NpgsqlConnection(cmm.ConnectionString))
                //{
                //    NpgsqlCommand cmd = new NpgsqlCommand("call sp_save_mastercategory(:in_mcid,:p_mscid, :in_categoryname,:in_categorycode,:in_description,:in_imageurl,:in_languageid)", conn);
                //    cmd.Parameters.AddWithValue("in_mcid", DbType.Int64).Value = dto.mc_id;
                //    cmd.Parameters.AddWithValue("in_categoryname", DbType.String).Value = dto.category_name;
                //    cmd.Parameters.AddWithValue("in_categorycode", DbType.String).Value = dto.category_code;
                //    cmd.Parameters.AddWithValue("in_description", DbType.String).Value = dto.description;
                //    cmd.Parameters.AddWithValue("in_imageurl", DbType.String).Value = dto.image_url;
                //    cmd.Parameters.AddWithValue("in_languageid", DbType.Int64).Value = dto.language_id;

                //    conn.Open();
                //    var affectcount = cmd.ExecuteNonQuery();
                //    saved = affectcount == 1;
                //    if (affectcount == -1)
                //    {
                //        dto.msg_flg = "Update";
                //    }
                //    else
                //    {
                //        dto.msg_flg = "Failed";
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
            return dto;
        }
    }
}
