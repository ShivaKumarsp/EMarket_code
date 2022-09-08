using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Admin;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.DLL.EMarket_Repository.Vendor
{
   public class Vendor_Add_Item_Repository: IVendor_Add_Item_Repository
    {
        ISql_Layer _sql;
        IError_Log _error;
        bool saved = false;
        PostgreSqlContext _context;
        comman_class cmm = new comman_class();
        SqlHelper sqlHelper = new SqlHelper();
        int return_int = 0;
        long return_long = 0;
        string return_string = "";
        List<string> invalue = new List<string>();
        int status = 0;
        public Vendor_Add_Item_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

       


        public Vendor_Add_ItemDTO saveproductitem(Vendor_Add_ItemDTO dto)
        {
            List<Vendor_Add_ItemDTO> dtonewtemp1 = new List<Vendor_Add_ItemDTO>();
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Add_ItemServices/saveproductitem";
            try
            {
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

                var checksdup = _context.Product_ItemDMO_con.Where(a => a.item_name == dto.item_name.Trim() && a.vendor_id==dto.vendor_id && a.item_id!=dto.item_id).ToList();
                if(checksdup.Count>0)
                {
                    dto.status = "Failed";
                    dto.messageflg = "Item Already Exist";
                    return dto;
                }


                if (dto.item_id == 0)
                {
                    var checksku = _context.Product_ItemDMO_con.Where(a => a.sku == dto.sku.Trim() && a.vendor_id == dto.vendor_id).ToList();
                    if (checksku.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.messageflg = "SKU Already Exist";
                        return dto;
                    }
                }

                try
                {
                    dto.item_code = dto.item_name;
                    string s = dto.item_code;
                    bool fHasSpace = s.Contains(" ");
                    if (fHasSpace == true)
                    {
                        dto.item_code = (dto.item_code).ToString().Trim().Replace(" ", "-");
                        var checkslug = _context.Product_ItemDMO_con.Where(a => a.item_code == dto.item_code).ToList();
                        if (checkslug.Count > 0)
                        {
                            Random rnd = new Random();
                            int rndnum = rnd.Next(1, 100);
                            dto.item_code = dto.item_code + "-" + rndnum;
                        }
                        else
                        {
                            dto.messageflg = "alredy slug is present";
                        }
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
                    DbHelper.CreateParameter("p_vendorid", dto.vendor_id),
                    DbHelper.CreateParameter("p_itemname", dto.item_name.Trim()),
                    DbHelper.CreateParameter("p_itemcode", dto.item_code.Trim()),
                    DbHelper.CreateParameter("p_itemtypeid", dto.item_type_id),
                    DbHelper.CreateParameter("p_currencyid", dto.currency_id),
                    DbHelper.CreateParameter("p_productid", dto.product_id),
                    DbHelper.CreateParameter("p_expirydate", dto.expiry_date),
                    DbHelper.CreateParameter("p_manufacutredate", dto.manufacture_date),
                    DbHelper.CreateParameter("p_manufacturedetails", dto.manufacture_details.Trim()),
                    DbHelper.CreateParameter("p_countryoriginid", dto.country_origin_id),
                    DbHelper.CreateParameter("p_warrantyumoid", dto.warranty_uom_id),
                    DbHelper.CreateParameter("p_warranty", dto.warranty),
                    DbHelper.CreateParameter("p_mrp", dto.mrp),
                    DbHelper.CreateParameter("p_listingprice", dto.listing_price),
                    DbHelper.CreateParameter("p_minquantity", dto.min_quantity),
                    DbHelper.CreateParameter("p_storeid", dto.store_id),
                    DbHelper.CreateParameter("p_createdby", dto.userid),
                    DbHelper.CreateParameter("p_durabilityumo", dto.durability_umo),
                    DbHelper.CreateParameter("p_durability", dto.durability),
                    DbHelper.CreateParameter("p_checkdurability", dto.check_durability),
                    DbHelper.CreateParameter("p_itemid", dto.item_id),
                    DbHelper.CreateParameter("p_languageid", dto.language_id),
                    DbHelper.CreateParameter("p_itemimage", dto.item_image),
                    DbHelper.CreateParameter("p_sku", dto.sku.Trim()),
                    DbHelper.CreateParameter("p_quantity", dto.quantity),
                    DbHelper.CreateParameter("p_inthebox", dto.In_the_box.Trim()),

               };
                    foreach (var item in dbParams)
                    {
                        invalue.Add(item.ParameterName + ':' + item.Value);
                    }
                    var spName = "fn_add_productitem";
                    var retObject1 = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            dtonewtemp1.Add(new Vendor_Add_ItemDTO
                            {
                                item_id = Convert.ToInt64(dataReader["out_itemid"])

                            });
                        }
                    }

                    dto.ret_item_id = dtonewtemp1[0].item_id;

                    //NpgsqlParameter[] para = new NpgsqlParameter[26];
                    //para[0] = new NpgsqlParameter("@p_vendorid", Convert.ToInt64(dto.vendor_id));
                    //para[1] = new NpgsqlParameter("@p_itemname", Convert.ToString(dto.item_name));
                    //para[2] = new NpgsqlParameter("@p_itemcode", Convert.ToString(dto.item_code));
                    //para[3] = new NpgsqlParameter("@p_itemtypeid", Convert.ToInt64(dto.item_type_id));
                    //para[4] = new NpgsqlParameter("@p_currencyid", Convert.ToInt64(dto.currency_id));
                    //para[5] = new NpgsqlParameter("@p_productid", Convert.ToInt64(dto.product_id));
                    //para[6] = new NpgsqlParameter("@p_expirydate", Convert.ToDateTime(dto.expiry_date));
                    //para[7] = new NpgsqlParameter("@p_manufacutredate", Convert.ToDateTime(dto.manufacture_date));
                    //para[8] = new NpgsqlParameter("@p_manufacturedetails", Convert.ToString(dto.manufacture_details));
                    //para[9] = new NpgsqlParameter("@p_countryoriginid", Convert.ToInt64(dto.country_origin_id));
                    //para[10] = new NpgsqlParameter("@p_warrantyumoid", Convert.ToInt64(dto.warranty_uom_id));
                    //para[11] = new NpgsqlParameter("@p_warranty", Convert.ToInt32(dto.warranty));
                    //para[12] = new NpgsqlParameter("@p_mrp", Convert.ToDecimal(dto.mrp));
                    //para[13] = new NpgsqlParameter("@p_listingprice", Convert.ToDecimal(dto.listing_price));
                    //para[14] = new NpgsqlParameter("@p_minquantity", Convert.ToInt64(dto.min_quantity));
                    //para[15] = new NpgsqlParameter("@p_storeid", Convert.ToInt64(dto.store_id));
                    //para[16] = new NpgsqlParameter("@p_createdby", Convert.ToInt64(dto.userid));
                    //para[17] = new NpgsqlParameter("@p_durabilityumo", Convert.ToInt64(dto.durability_umo));
                    //para[18] = new NpgsqlParameter("@p_durability", Convert.ToDecimal(dto.durability));
                    //para[19] = new NpgsqlParameter("@p_checkdurability", Convert.ToBoolean(dto.check_durability));
                    //para[20] = new NpgsqlParameter("@p_itemid", Convert.ToInt64(dto.item_id));
                    //para[21] = new NpgsqlParameter("@p_languageid", Convert.ToInt64(dto.language_id));
                    //para[22] = new NpgsqlParameter("@p_itemimage", Convert.ToString(dto.item_image));
                    //para[23] = new NpgsqlParameter("@p_sku", Convert.ToString(dto.sku));
                    //para[24] = new NpgsqlParameter("@p_quantity", Convert.ToInt64(dto.quantity));
                    //para[25] = new NpgsqlParameter("@p_inthebox", dto.In_the_box);


                    //dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
                    //dto.procedure_name = "fn_add_productitem";
                    //return_string = sqlHelper.ExecuteNonQueryFunction_Single(dto.procedure_name, para);
                    //using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(return_string)))
                    //{
                    //    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Vendor_Add_ItemDTO));
                    //    Vendor_Add_ItemDTO bsObj2 = (Vendor_Add_ItemDTO)deserializer.ReadObject(ms);
                    //    dto.ret_item_id = bsObj2.out_itemid;
                    //}

                    if (dto.ret_item_id != 0)
                    {
                        dto.status = "Insert";
                    
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.messageflg = "Add Item Not Saved, Please Try Again";
                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog_add(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
                }
              
            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.userid);
            }
            finally
            {
                _error.audit_log_txr(dto.userid, methodname, page_form);
            }
            return dto;
        }

        
        public Vendor_Add_ItemDTO save_itemspecification(Vendor_Add_ItemDTO dto)
        {
            try
            {
                var Params = new DbParameter[] { };
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
                var itm = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).SingleOrDefault();
                dto.ret_item_name = itm.item_image;
                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_itemid", dto.item_id)
                    };

                    var spName = "fn_get_productitem_specification";
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
                        dto.product_specification_list = retObject.ToArray();

                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog1(ex, dto.userid);
                }

                try
                {
                    if (dto.product_specification_list.Length == dto.item_array.Length)
                    {
                        foreach (var item123 in dto.item_array)
                        {
                            if (item123.enable_custom_value == false)
                            {
                                if (item123.attribute_value_id == 0)
                                {
                                    dto.msg_flg = "Please Select Mandatory Fields";
                                    return dto;
                                }
                            }

                            if (item123.enable_custom_value == true)
                            {
                                if (item123.attribute_value == "")
                                {
                                    dto.msg_flg = "Please Select Mandatory Fields";
                                    return dto;
                                }
                            }

                        }
                        foreach (var item in dto.item_array)
                        {
                            var dbParams = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_itemid", dto.item_id),
                    DbHelper.CreateParameter("in_specification_id", item.specification_id),
                    DbHelper.CreateParameter("in_attribute_name_id", item.attribute_name_id),
                    DbHelper.CreateParameter("in_attribute_value_id", item.attribute_value_id),
                    DbHelper.CreateParameter("in_item_specification_id", 0),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_attribute_value", item.attribute_value),
                    DbHelper.CreateParameter("in_custom_value", item.enable_custom_value)
                   };
                             Params = dbParams;
                            var spName = "call sp_add_item_specification(:in_itemid, :in_specification_id,:in_attribute_name_id,:in_attribute_value_id,:in_item_specification_id,:in_language_id,:in_attribute_value,:in_custom_value)";
                            return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);

                        }
                        if (return_int == -1)
                        {
                            dto.msg_flg = "Update";
                        }
                        else
                        {
                            dto.msg_flg = "Failed";
                        }
                    }
                    else
                    {
                        dto.msg_flg = "Please Select Mandatory Fields";
                        return dto;
                    }

                }
                catch (Exception ex)
                {
                  
                }
                finally
                {

                }

                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_itemid", dto.item_id)
                    };
                    dto.item_specification_list = _sql.fn_get_list("fn_get_Item_specification", dbParams);

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
        public Vendor_Add_ItemDTO get_sku(Vendor_Add_ItemDTO dto)
        {
            try
            {
                var res = _context.Product_ItemDMO_con.Where(a => a.product_id == dto.product_id && a.vendor_id == dto.vendor_id && a.sku != null).ToList().FirstOrDefault();
                if (res != null)
                {
                    dto.ret_sku = res.sku;
                }

            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.userid);

            }
            return dto;
        }
        public Vendor_Add_ItemDTO generate_itemcode(Vendor_Add_ItemDTO dto)
        {
            try
            {
                Guid g = Guid.NewGuid();
                dto.item_code = dto.item_name + g;


            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.userid);

            }
            return dto;
        }

        public Vendor_Add_ItemDTO update_itemspecification(Vendor_Add_ItemDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var Params = new DbParameter[] { };
            try
            {
                var dbParams = new DbParameter[]
                  {
                    DbHelper.CreateParameter("in_itemid", dto.item_id),
                    DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                    DbHelper.CreateParameter("in_attribute_name_id", dto.attribute_name_id),
                    DbHelper.CreateParameter("in_attribute_value_id", dto.attribute_value_id),
                    DbHelper.CreateParameter("in_item_specification_id", dto.item_specification_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_attribute_value", dto.attribute_value),
                    DbHelper.CreateParameter("in_custom_value", dto.enable_custom_value)
                  };
                Params = dbParams;
                var spName = "call sp_add_item_specification(:in_itemid, :in_specification_id,:in_attribute_name_id,:in_attribute_value_id,:in_item_specification_id,:in_language_id,:in_attribute_value,:in_custom_value)";
                return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);

            
               if (return_int == -1)
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

            try
            {
                var dbParams = new DbParameter[]
                {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_itemid", dto.item_id)
                };
                dto.item_specification_list = _sql.fn_get_list("fn_get_Item_specification", dbParams);
                
            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.userid);
            }

            return dto;
        }

        //Edit Specification
     

      
        public itemfeaturesDTO save_itemfeatures(itemfeaturesDTO dto)

        {
            List<itemfeaturesDTO> dtonewtemp = new List<itemfeaturesDTO>();
            dto.item_name = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id && a.language_id == dto.language_id).SingleOrDefault().item_name.TrimEnd();
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            string methodname = "Item_Feature_Repository/save_itemfeatures";
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            var Params = new DbParameter[] { };
            try
            {
                
                    var dbParams4 = new DbParameter[]
         {
                    DbHelper.CreateParameter("in_item_id",dto.item_id),
                     DbHelper.CreateParameter("in_description", dto.description),
                    DbHelper.CreateParameter("in_language_id",dto.language_id),
                    DbHelper.CreateParameter("in_user_id",dto.userid),
                    DbHelper.CreateParameter("in_ifid",dto.if_id),
                  
            };
                var spName = "call sp_add_itemfeature(:in_item_id, :in_description,:in_language_id,:in_user_id,:in_ifid)";
                return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams4);

               

                if (return_int == -1)
                {
                    dto.msg_flg = "Update";
                    dto.message = "Item Feature Added Successfully";
                }
                else
                {
                    dto.msg_flg = "Failed";
                    dto.message = "Item Feature Not Added";
                }
                try
                {
                    var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id),
                    };

                    var spName1 = "fn_get_itemfeatures";
                    var retObject = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName1, CommandType.StoredProcedure, dbParams))
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
                        dto.feature_list = retObject.ToArray();

                    }
                }
                catch (Exception ex)
                {
                    //_error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form);
                }


            }
            catch (Exception ex)
            {
                //_error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form);

            }
            finally
            {
                _error.audit_log_txr(dto.userid, methodname, page_form);
            }
            return dto;
        }

        public Vendor_Add_ItemDTO save_multiple_images(Vendor_Add_ItemDTO dto)
        {

            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var Params = new DbParameter[] { };
            try
            {
                foreach(var image in dto.imageDetails)
                {
                    var dbParams = new DbParameter[]
                  {
                    DbHelper.CreateParameter("mul_imageid", dto.mul_image_id),
                    DbHelper.CreateParameter("itemid", dto.item_id),
                    DbHelper.CreateParameter("imageurl", image.image_url),
                    DbHelper.CreateParameter("createdby", dto.userid),
                  };
                    Params = dbParams;
                    var spName = "call sp_saveupdate_multipleimage(:mul_imageid,:itemid,:imageurl,:createdby)";
                    return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);

                }

                if (return_int == -1)
                {
                    dto.msg_flg = "Save";
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
            return dto;
        }
    }
}
