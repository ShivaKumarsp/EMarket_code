using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Admin
{
    public class Item_Specification_Mapping_Repository: IItem_Specification_Mapping_Repository
    {
        bool saved = true;
        PostgreSqlContext _context;
        comman_class cmm = new comman_class();
        ISql_Layer _sql;
        IError_Log _error;
        int status = 0;
        public Item_Specification_Mapping_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }
       
        public Item_Specification_MappingDTO saveitemspecification(Item_Specification_MappingDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Item_Specification_Mapping/saveitemspecification";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                var dbParams = new DbParameter[]
          {
                    DbHelper.CreateParameter("in_itemspecid", dto.master_item_spec_id),
                    DbHelper.CreateParameter("in_additionalcatid", dto.additional_cat_id),
                    DbHelper.CreateParameter("in_specificationid", dto.specification_id),
                    DbHelper.CreateParameter("in_attributenameid", dto.attribute_name_id),
                    DbHelper.CreateParameter("in_isrefiner", dto.is_refiners),
                    DbHelper.CreateParameter("in_isvisible", dto.is_visible)
               };

                var spName = "call sp_save_itemcategoryspecification(:in_itemspecid,:in_additionalcatid, :in_specificationid,:in_attributenameid,:in_isrefiner,:in_isvisible)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);

                if (status == -1)
                {
                    dto.msg_flg = "Update";
                }
                else
                {
                    dto.msg_flg = "Failed";
                }
           
                  
                //    using (var conn = new NpgsqlConnection(cmm.ConnectionString))
                //{
                //    NpgsqlCommand cmd = new NpgsqlCommand("call sp_save_itemcategoryspecification(:in_itemspecid,:in_additionalcatid, :in_specificationid,:in_attributenameid,:in_isrefiner,:in_isvisible)", conn);
                //    cmd.Parameters.AddWithValue("in_itemspecid", DbType.Int64).Value = dto.master_item_spec_id;
                //    cmd.Parameters.AddWithValue("in_additionalcatid", DbType.Int64).Value = dto.additional_cat_id;
                //    cmd.Parameters.AddWithValue("in_specificationid", DbType.Int64).Value = dto.specification_id;
                //    cmd.Parameters.AddWithValue("in_attributenameid", DbType.Int64).Value = dto.attribute_name_id;
                //    cmd.Parameters.AddWithValue("in_isrefiner", DbType.Boolean).Value = dto.is_refiners;
                //    cmd.Parameters.AddWithValue("in_isvisible", DbType.Boolean).Value = dto.is_visible;

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
            _error.errorlog1(ex, dto.userid);
        }
            return dto;
        }
        public Item_Specification_MappingDTO deleteitemspecification(Item_Specification_MappingDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Item_Specification_Mapping/deleteitemspecification";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
                {
                var dbParams = new DbParameter[]
         {
                    DbHelper.CreateParameter("in_itemspecid", dto.master_item_spec_id)
                
              };

                var spName = "call sp_delete_masteritemspecification(:in_itemspecid)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);

                if (status == -1)
                {
                    dto.msg_flg = "Delete";
                }
                else
                {
                    dto.msg_flg = "Failed";
                }


                //using (var conn = new NpgsqlConnection(cmm.ConnectionString))
                //{
                //    NpgsqlCommand cmd = new NpgsqlCommand("call sp_delete_masteritemspecification(:in_itemspecid)", conn);
                //    cmd.Parameters.AddWithValue("in_itemspecid", DbType.Int64).Value = dto.master_item_spec_id;
                //    conn.Open();
                //    var affectcount = cmd.ExecuteNonQuery();
                //    saved = affectcount == 1;
                //    if (affectcount == -1)
                //    {
                //        dto.msg_flg = "Delete";
                //    }
                //    else
                //    {
                //        dto.msg_flg = "Failed";
                //    }
                //}
            }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }
                
            return dto;
        }
       

      

       
    }
}
