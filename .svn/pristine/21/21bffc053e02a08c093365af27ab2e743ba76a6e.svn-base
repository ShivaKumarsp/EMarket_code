using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Vendor;
using EMarket.DLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Admin;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.BLL.EMarket_Service.Vendor
{
    public class Vendor_Add_Item : IVendor_Add_Item
    {
        IVendor_Add_Item_Repository _inter;

        ISqlClass _sql;
        IErrorClass _error;
        bool saved = false;
        PostgreSqlContext _context;
        Db_Connection conn = new Db_Connection();

        public Vendor_Add_Item(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IVendor_Add_Item_Repository inter)
        {
            _context = context;
            _sql = sql;
            _inter = inter;
            _error = error;
        }

        public Vendor_Add_ItemDTO getdata(Vendor_Add_ItemDTO dto)
        {
            var vend = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
            dto.vendor_id = vend.vendor_id;
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Add_Item/getdata";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                // product type
                    var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                                        };
                dto.procedure_name = "fn_producttype";
                Params = dbParams;
                    dto.producttypelist = _sql.fn_get_list(dto.procedure_name, dbParams);
                // country
                var dbParams1 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                   };
                Params = dbParams1;
                dto.procedure_name = "fn_country";
                dto.countrylist = _sql.fn_get_list(dto.procedure_name, dbParams1);

                // get product
                var dbParams2 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
                   };
                Params = dbParams2;
                dto.procedure_name = "fn_product";
                dto.productlist = _sql.fn_get_list(dto.procedure_name, dbParams2);

                // get store
                var dbParams3 = new DbParameter[]
                  {
                      DbHelper.CreateParameter("vendorid", dto.vendor_id),
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                  };
                dto.procedure_name = "fn_store";
                Params = dbParams3;
                dto.storelist = _sql.fn_get_list(dto.procedure_name, dbParams3);

                // get warrantyuom
                var dbParams4 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                    };
                dto.procedure_name = "fn_getwarrantyuom";
                Params = dbParams4;
                dto.warrantytypelist = _sql.fn_get_list(dto.procedure_name, dbParams4);

                // get currency
                var dbParams5 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                   };
                Params = dbParams5;
                dto.procedure_name = "fn_currency";
                dto.currencylist = _sql.fn_get_list(dto.procedure_name, dbParams5);

                Guid g = Guid.NewGuid();
                dto.item_code = dto.item_name + g;

            }

            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Vendor_Add_ItemDTO get_item_product_details(Vendor_Add_ItemDTO dto)
        {
            var vend = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
            dto.vendor_id = vend.vendor_id;
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Add_Item/get_item_product_details";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                // product details
                var dbParams7 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id)
               };
                Params = dbParams7;
                dto.procedure_name = "fn_get_verify_product_details";
                dto.product_details = _sql.Get_Data(dto.procedure_name, dbParams7);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Vendor_Add_ItemDTO saveproductitem(Vendor_Add_ItemDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Add_Item/saveproductitem";
            var Params = new DbParameter[] { };

            List<string> ret_validation = new List<string>();
            var vendor = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).SingleOrDefault();
            dto.vendor_id = vendor.vendor_id;
            
            if (dto.product_id == 0)
            {
                ret_validation.Add("Please Select Product");
                
            }
            if (dto.item_type_id == 0)
            {
                ret_validation.Add("Please Select Item Type");
               
            }

            if (dto.item_name.Trim() == "" || dto.item_name.Trim() == null)
            {
                ret_validation.Add("Please Enter Item Name");
                
            }
            if (dto.store_id == 0)
            {
                ret_validation.Add("Please Select Store");
             
            }
            if (dto.mrp == 0)
            {
                ret_validation.Add("Please Enter MRP");

            }

            if (dto.listing_price == 0)
            {
                ret_validation.Add("Please Enter Listing Price");

            }

            if (dto.currency_id == 0)
            {
                ret_validation.Add("Please Select Currency");
                
            }

            //if (dto.quantity == 0)
            //{
            //    ret_validation.Add("Please Enter Quantity");
               
            //}
            if (dto.min_quantity == 0)
            {
                ret_validation.Add("Please set Minimum Quantity");
                
            }

            if (dto.item_image == "" || dto.item_image == null)
            {
                ret_validation.Add("Please Upload Item Image");
              
            }
          
            string nameRegex = @"^[a-zA-Z ]+$";
            Regex nre = new Regex(nameRegex);
            string mrpRegex = @"^[0-9]*(\.[0-9]{0,2})?$";
            Regex mre = new Regex(mrpRegex);
            string qtypat = @"^\d+$";
            Regex qty = new Regex(qtypat);

           
            if (!mre.IsMatch(dto.quantity.ToString()))
            {
                ret_validation.Add("Please Enter Valid Quantity");
               
            }
            else if (!mre.IsMatch(dto.listing_price.ToString()))
            {
                ret_validation.Add("Please Enter Valid MRP");
             
            }
        
            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }
            try
            {
                _inter.saveproductitem(dto);
            }
            catch(Exception ex)
            {
                _error.errorlog_add(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            finally
            {
                _error.audit_log_txr(dto.userid, methodname, page_form);
            }

            return dto;
        }
        public Vendor_Add_ItemDTO get_specification_data(Vendor_Add_ItemDTO dto)
        {
            dto.edititem = false;
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Add_Item/get_specification_data";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var vend = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
                dto.vendor_id = vend.vendor_id;

                var itemcheck = _context.product_item_specificationDMO_con.Where(a => a.item_id == dto.item_id).ToList();
                if (itemcheck.Count > 0)
                {
                    dto.edititem = true;
                }
                var itmlist= _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).ToList();
                if(itmlist.Count>0)
                {
                    dto.ret_item_name = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).SingleOrDefault().item_name;
                }
                else
                    {
                    return dto;
                }
              

                //productitem_specification
                var dbParams = new DbParameter[]
                     {

                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_itemid", dto.item_id)
                     };
                dto.procedure_name = "fn_get_productitem_specification";
                Params = dbParams;
                dto.product_specification_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                // get item
                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id)
                    };
                dto.procedure_name = "fn_get_item";
                Params = dbParams1;
                dto.itemlist = _sql.fn_get_list(dto.procedure_name, dbParams1);

                // get att val
                var dbParams2 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id)
                   };
                dto.procedure_name = "fn_attribute_value";
                Params = dbParams2;
                dto.attribute_value_list = _sql.fn_get_list(dto.procedure_name, dbParams2);
              
                if (dto.item_id > 0)
                {
                    var dbParams3 = new DbParameter[]
                      {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_itemid", dto.item_id)
                      };
                    dto.procedure_name = "fn_get_Item_specification";
                    Params = dbParams3;
                   dto.item_specification_list = _sql.fn_get_list(dto.procedure_name, dbParams3);
                }
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Vendor_Add_ItemDTO save_itemspecification(Vendor_Add_ItemDTO dto)
        {
            dto.edititem = false;
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Add_Item/get_specification_data";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var vendor = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).SingleOrDefault();
                dto.vendor_id = vendor.vendor_id;
                _inter.save_itemspecification(dto);
            }
            catch (Exception ex)
            {
               
            }

            try
            {
                var vend = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
                dto.vendor_id = vend.vendor_id;

                var itemcheck = _context.product_item_specificationDMO_con.Where(a => a.item_id == dto.item_id).ToList();
                if (itemcheck.Count > 0)
                {
                    dto.edititem = true;
                }
                var itmlist = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).ToList();
                if (itmlist.Count > 0)
                {
                    dto.ret_item_name = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).SingleOrDefault().item_name;
                }
                else
                {
                    return dto;
                }


                //productitem_specification
                var dbParams = new DbParameter[]
                     {

                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_itemid", dto.item_id)
                     };
                dto.procedure_name = "fn_get_productitem_specification";
                Params = dbParams;
                dto.product_specification_list = _sql.fn_get_list(dto.procedure_name, dbParams);

                // get item
                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id)
                    };
                dto.procedure_name = "fn_get_item";
                Params = dbParams1;
                dto.itemlist = _sql.fn_get_list(dto.procedure_name, dbParams1);

                // get att val
                var dbParams2 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id)
                   };
                dto.procedure_name = "fn_attribute_value";
                Params = dbParams2;
                dto.attribute_value_list = _sql.fn_get_list(dto.procedure_name, dbParams2);

                if (dto.item_id > 0)
                {
                    var dbParams3 = new DbParameter[]
                      {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_itemid", dto.item_id)
                      };
                    dto.procedure_name = "fn_get_Item_specification";
                    Params = dbParams3;
                    dto.item_specification_list = _sql.fn_get_list(dto.procedure_name, dbParams3);
                }
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Vendor_Add_ItemDTO get_specific_edit_data(Vendor_Add_ItemDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Add_Item/get_specification_data";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                var vend = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
                dto.vendor_id = vend.vendor_id;

                var itmlist = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).ToList();
                if (itmlist.Count > 0)
                {
                    dto.ret_item_name = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).SingleOrDefault().item_name.TrimEnd();
                }
                else
                {
                    return dto;
                }


                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id)                 
                    };
                dto.procedure_name = "fn_attribute_value";
                Params = dbParams;
                dto.attribute_value_list = _sql.fn_get_list(dto.procedure_name, dbParams);


                //
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_itemid", dto.item_id)
                };
                dto.procedure_name = "fn_get_productitem_specificationlist";
                Params = dbParams1;
                dto.item_specification_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                var itemcheck = _context.product_item_specificationDMO_con.Where(a => a.item_id == dto.item_id).ToList();
                if (itemcheck.Count > 0)
                {
                    dto.edititem = true;
                }

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Vendor_Add_ItemDTO get_sku(Vendor_Add_ItemDTO dto)
        {
            var vendor = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).SingleOrDefault();
            dto.vendor_id = vendor.vendor_id;
            return _inter.get_sku(dto);
        }
        public Vendor_Add_ItemDTO generate_itemcode(Vendor_Add_ItemDTO dto)
        {
            var vendor = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).SingleOrDefault();
            dto.vendor_id = vendor.vendor_id;
            return _inter.generate_itemcode(dto);
        }
        public Vendor_Add_ItemDTO update_itemspecification(Vendor_Add_ItemDTO dto)
        {
            var vendor = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).SingleOrDefault();
            dto.vendor_id = vendor.vendor_id;
            return _inter.update_itemspecification(dto);
        }
        public Vendor_Add_ItemDTO get_product_details(Vendor_Add_ItemDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Add_Item/get_product_details";
            try
            {
                // get product
                var dbParams2 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id)
                   };
                Params = dbParams2;
                dto.procedure_name = "fn_get_vendor_product";
                dto.productlist = _sql.fn_get_list(dto.procedure_name, dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        //Mukta 09-08-2022
        public Vendor_Add_ItemDTO save_multiple_images(Vendor_Add_ItemDTO dto)
        {
            var vendor = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).SingleOrDefault();
            dto.vendor_id = vendor.vendor_id;
            if(dto.imageDetails == null)
            {
                dto.messageflg = "Please upload image";
            }
            return _inter.save_multiple_images(dto);
        }
        public itemfeaturesDTO getdata_feature(itemfeaturesDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Add_Item/getdata_feature";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try

            {
                var itmlist = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).ToList();
                if (itmlist.Count > 0)
                {
                    dto.ret_item_name = _context.Product_ItemDMO_con.Where(a => a.item_id == dto.item_id).SingleOrDefault().item_name.TrimEnd();
                }
                else
                {
                    return dto;
                }

           

                var dbParams1 = new DbParameter[]
         {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
         };
                dto.procedure_name = "fn_get_itemfeatures";
                Params = dbParams1;
                dto.feature_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public itemfeaturesDTO save_itemfeatures(itemfeaturesDTO dto)
        {
            return _inter.save_itemfeatures(dto);
        }
        

    }
}
