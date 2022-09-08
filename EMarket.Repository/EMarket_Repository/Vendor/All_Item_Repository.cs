using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Vendor;
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
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Vendor
{
    public class All_Item_Repository : IAll_Item_Repository
    {
        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        ISql_Layer _sql;
        IError_Log _error;
        int return_int = 0;
        string return_string = "";
        List<Vendor_Add_ItemDTO> dtonewtemp = new List<Vendor_Add_ItemDTO>();
        public All_Item_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

       

        // edit items

        public All_ItemDTO get_edit_data(All_ItemDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_Item_Repository/get_edit_data";
            try
            {
                var customer = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.vendor_id = customer.vendor_id;

                // get get item
                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),

                    };
                dto.edit_item_list = _sql.fn_get_list("fn_get_edit_item", dbParams);

                // product type
                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                    };
                dto.producttypelist = _sql.fn_get_list("fn_producttype", dbParams1);

                // country
                var dbParams2 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                    };
                dto.countrylist = _sql.fn_get_list("fn_country", dbParams2);

                // product
                var dbParams3 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                    };
                dto.productlist = _sql.fn_get_list("fn_product", dbParams3);

                // product details
                var dbParams7 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
               };
                dto.product_details = _sql.Get_Data("fn_get_verify_product", dbParams7);


                // store
                var dbParams4 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("vendorid", dto.vendor_id),
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                    };
                dto.storelist = _sql.fn_get_list("fn_store", dbParams4);

                // uom
                var dbParams5 = new DbParameter[]
                    {
                   
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                    };
                dto.warrantytypelist = _sql.fn_get_list("fn_getwarrantyuom", dbParams5);

                // fn_currency
                var dbParams6 = new DbParameter[]
                    {

                      DbHelper.CreateParameter("planguageid", dto.language_id)
                    };
                dto.currencylist = _sql.fn_get_list("fn_currency", dbParams6);

              

            }
            catch (Exception ex)
            {
               // _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
            return dto;
        }

        public All_ItemDTO saveproductitem(All_ItemDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_Item_Repository/saveproductitem";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try
            {
                var customer = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.vendor_id = customer.vendor_id;
                //if (!string.IsNullOrEmpty(dto.item_name) && !string.IsNullOrEmpty(dto.item_code) && dto.item_type_id != 0 && dto.currency_id != 0 && dto.product_id != 0
                //                    && dto.manufacture_date != null && !string.IsNullOrEmpty(dto.manufacture_details) && dto.country_origin_id != 0
                //                     && dto.language_id != 0 && dto.mrp != 0 && dto.listing_price != 0 && dto.min_quantity != 0 && dto.language_id != 0 && dto.store_id != 0)
                //{
                if (dto.product_id == 0)
                {
                    dto.messageflg = "Please Select Product";
                    return dto;
                }

                if (dto.item_type_id == 0)
                {
                    dto.messageflg = "Please Select Item Type";
                    return dto;
                }

                if (dto.item_code == "" || dto.item_code == null)
                {
                    dto.messageflg = "Please Enter Item Code";
                    return dto;
                }

                if (dto.item_name == "" || dto.item_name == null)
                {
                    dto.messageflg = "Please Enter Item Name";
                    return dto;
                }

                if (dto.store_id == 0)
                {
                    dto.messageflg = "Please Select Store";
                    return dto;
                }

                if (dto.mrp == 0)
                {
                    dto.messageflg = "Please Enter MRP";
                    return dto;
                }

                if (dto.listing_price == 0)
                {
                    dto.messageflg = "Please Enter Listing Price";
                    return dto;
                }

                if (dto.currency_id == 0)
                {
                    dto.messageflg = "Please Select Currency";
                    return dto;
                }

                if (dto.min_quantity == 0)
                {
                    dto.messageflg = "Please set minimum quantity";
                    return dto;
                }

                if (dto.manufacture_details == "" || dto.manufacture_details == null)
                {
                    dto.messageflg = "Please Enter Manufacture Details";
                    return dto;
                }

                if (dto.manufacture_date == null)
                {
                    dto.messageflg = "Please Select Manufacture Date";
                    return dto;
                }

                if (dto.country_origin_id == 0)
                {
                    dto.messageflg = "Please Select Country of Origin";
                    return dto;
                }

                if (dto.warranty_uom_id == 0)
                {
                    dto.messageflg = "Please Select Warranty Type";
                    return dto;
                }

                try
                {
                    var dbParams = new DbParameter[]
                 {
                    DbHelper.CreateParameter("p_vendorid", dto.vendor_id),
                     DbHelper.CreateParameter("p_itemname", dto.item_name),
                    DbHelper.CreateParameter("p_itemcode", dto.item_code),
                    DbHelper.CreateParameter("p_itemtypeid", dto.item_type_id),
                    DbHelper.CreateParameter("p_currencyid", dto.currency_id),
                    DbHelper.CreateParameter("p_productid", dto.product_id),
                    DbHelper.CreateParameter("p_expirydate", dto.expiry_date),
                    DbHelper.CreateParameter("p_manufacutredate", dto.manufacture_date),
                    DbHelper.CreateParameter("p_manufacturedetails", dto.manufacture_details),
                    DbHelper.CreateParameter("p_countryoriginid", dto.country_origin_id),
                    DbHelper.CreateParameter("p_warrantyumoid", dto.warranty_uom_id),
                    DbHelper.CreateParameter("p_warranty", dto.warranty),
                    DbHelper.CreateParameter("p_mrp", dto.mrp),
                    DbHelper.CreateParameter("p_listingprice", dto.listing_price),
                    DbHelper.CreateParameter("p_minquantity", dto.min_quantity),
                    DbHelper.CreateParameter("p_storeid", dto.store_id),
                    DbHelper.CreateParameter("p_createdby", dto.user_id),
                    DbHelper.CreateParameter("p_durabilityumo", dto.durability_umo),
                    DbHelper.CreateParameter("p_durability", dto.durability),
                    DbHelper.CreateParameter("p_checkdurability", dto.check_durability),
                    DbHelper.CreateParameter("p_itemid", dto.item_id),
                    DbHelper.CreateParameter("p_languageid", dto.language_id),
                    DbHelper.CreateParameter("p_itemimage", dto.item_image),
                    DbHelper.CreateParameter("p_sku", dto.sku),

                 };
                    Params = dbParams;
                    var spName = "fn_add_productitem";
                    var retObject1 = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            dtonewtemp.Add(new Vendor_Add_ItemDTO
                            {
                                out_itemid = Convert.ToInt64(dataReader["out_itemid"])

                            });
                        }
                    }


                    dto.ret_item_id = dtonewtemp[0].out_itemid;

                    //NpgsqlParameter[] para = new NpgsqlParameter[24];
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
                    //para[16] = new NpgsqlParameter("@p_createdby", Convert.ToInt64(dto.user_id));
                    //para[17] = new NpgsqlParameter("@p_durabilityumo", Convert.ToInt64(dto.durability_umo));
                    //para[18] = new NpgsqlParameter("@p_durability", Convert.ToDecimal(dto.durability));
                    //para[19] = new NpgsqlParameter("@p_checkdurability", Convert.ToBoolean(dto.check_durability));
                    //para[20] = new NpgsqlParameter("@p_itemid", Convert.ToInt64(dto.item_id));
                    //para[21] = new NpgsqlParameter("@p_languageid", Convert.ToInt64(dto.language_id));
                    //para[22] = new NpgsqlParameter("@p_itemimage", Convert.ToString(dto.item_image));
                    //para[23] = new NpgsqlParameter("@p_sku", Convert.ToString(dto.sku));

                    //return_string = sqlHelper.ExecuteNonQueryFunction_Single("fn_add_productitem", para);
                    //using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(return_string)))
                    //{
                    //    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Vendor_Add_ItemDTO));
                    //    Vendor_Add_ItemDTO bsObj2 = (Vendor_Add_ItemDTO)deserializer.ReadObject(ms);
                    //    dto.ret_item_id = bsObj2.out_itemid;

                    //}


                    if (dto.ret_item_id != 0)
                    {
                        dto.status = true;
                    }
                    else
                    {
                        dto.status = false;
                    }
                }
                catch (Exception ex)
                {
                   // _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form);
                }
                finally
                {

                }              


            }
            catch (Exception ex)
            {
               // _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);

            }
            return dto;
        }

        public All_ItemDTO get_specific_edit_data(All_ItemDTO dto)
        {

            try
            {
                dto.user_id = 10000002;
                var customer = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.vendor_id = customer.vendor_id;

                dto.item_name = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id && a.language_id == dto.language_id).SingleOrDefault().item_name.TrimEnd();

                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_languageid", dto.language_id)

               };
                dto.attribute_value_list = _sql.fn_get_list("fn_attribute_value", dbParams);

                var dbParams1 = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)

              };
                dto.item_specification_list = _sql.fn_get_list("fn_get_edititem_specification", dbParams1);

            

                //using (var cn = new NpgsqlConnection(cmm.ConnectionString))
                //{
                //    NpgsqlCommand cmd = new NpgsqlCommand("fn_attribute_value", cn);
                //    cmd.Parameters.Add(new NpgsqlParameter("@in_languageid", dto.language_id));


                //    cn.Open();
                //    cmd.CommandType = CommandType.StoredProcedure;

                //    var retObject = new List<dynamic>();
                //    try
                //    {
                //        using (var dataReader = cmd.ExecuteReader())
                //        {
                //            while (dataReader.Read())
                //            {
                //                var dataRow = new ExpandoObject() as IDictionary<string, object>;
                //                for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                //                {
                //                    dataRow.Add(
                //                        dataReader.GetName(iFiled),
                //                        dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                //                    );
                //                }

                //                retObject.Add((ExpandoObject)dataRow);
                //            }
                //        }
                //        dto.attribute_value_list = retObject.ToArray();
                //    }

                //    catch (Exception ex)
                //    {
                //        _error.errorlog1(ex, dto.user_id);

                //    }
                //    finally
                //    {
                //        cn.Close();
                //    }
                //}

                //using (var cn = new NpgsqlConnection(cmm.ConnectionString))
                //{
                //    NpgsqlCommand cmd = new NpgsqlCommand("fn_get_edititem_specification", cn);
                //    cmd.Parameters.Add(new NpgsqlParameter("@in_language_id", dto.language_id));
                //    cmd.Parameters.Add(new NpgsqlParameter("@in_item_id", dto.item_id));


                //    cn.Open();
                //    cmd.CommandType = CommandType.StoredProcedure;

                //    var retObject = new List<dynamic>();
                //    try
                //    {
                //        using (var dataReader = cmd.ExecuteReader())
                //        {
                //            while (dataReader.Read())
                //            {
                //                var dataRow = new ExpandoObject() as IDictionary<string, object>;
                //                for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                //                {
                //                    dataRow.Add(
                //                        dataReader.GetName(iFiled),
                //                        dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                //                    );
                //                }

                //                retObject.Add((ExpandoObject)dataRow);
                //            }
                //        }
                //        dto.item_specification_list = retObject.ToArray();
                //    }

                //    catch (Exception ex)
                //    {
                //        _error.errorlog1(ex, dto.user_id);

                //    }
                //    finally
                //    {
                //        cn.Close();
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
            return dto;
        }

        public All_ItemDTO update_attribute(All_ItemDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            try

            {
                var customer = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.vendor_id = customer.vendor_id;
                var dbParams = new DbParameter[]
             {
                    DbHelper.CreateParameter("in_itemid", dto.item_id),
                    DbHelper.CreateParameter("in_specification_id", dto.specification_id),
                    DbHelper.CreateParameter("in_attribute_name_id", dto.attributename_id),
                    DbHelper.CreateParameter("in_attribute_value_id", dto.attributevalue_id),
                    DbHelper.CreateParameter("in_item_specification_id", dto.itemspecification_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_attribute_value", ""),
                  };

                var spName = "call sp_add_item_specification(:in_itemid,:in_specification_id,:in_attribute_name_id,:in_attribute_value_id,:in_item_specification_id,:in_language_id,:in_attribute_value)";
                return_int = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);

                if (return_int == -1)
                {
                    dto.status = true;
                }
                else
                {
                    dto.status = false;
                }

                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)

                    };
                dto.item_specification_list = _sql.fn_get_list("fn_get_edititem_specification", dbParams1);

                //using (var cn = new NpgsqlConnection(cmm.ConnectionString))
                //{
                //    NpgsqlCommand cmd = new NpgsqlCommand("fn_get_edititem_specification", cn);
                //    cmd.Parameters.Add(new NpgsqlParameter("@in_language_id", dto.language_id));
                //    cmd.Parameters.Add(new NpgsqlParameter("@in_item_id", dto.item_id));


                //    cn.Open();
                //    cmd.CommandType = CommandType.StoredProcedure;

                //    var retObject = new List<dynamic>();
                //    try
                //    {
                //        using (var dataReader = cmd.ExecuteReader())
                //        {
                //            while (dataReader.Read())
                //            {
                //                var dataRow = new ExpandoObject() as IDictionary<string, object>;
                //                for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                //                {
                //                    dataRow.Add(
                //                        dataReader.GetName(iFiled),
                //                        dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                //                    );
                //                }

                //                retObject.Add((ExpandoObject)dataRow);
                //            }
                //        }
                //        dto.item_specification_list = retObject.ToArray();
                //    }

                //    catch (Exception ex)
                //    {
                //        _error.errorlog1(ex, dto.user_id);

                //    }
                //    finally
                //    {
                //        cn.Close();
                //    }
                //}
            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.user_id);

            }
            return dto;
        }
        public All_ItemDTO get_product_details(All_ItemDTO dto)
        {
            try


            {
                var customer = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.vendor_id = customer.vendor_id;

                // product details
                var dbParams7 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id)
               };
                dto.product_details = _sql.Get_Data("fn_get_product_details", dbParams7);

            }
            catch (Exception ex)
            {
                _error.errorlog1(ex, dto.user_id);

            }
            return dto;
        }
    }
}
