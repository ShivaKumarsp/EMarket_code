using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Home;
using EMarket.Entities;
using EMarketDTO.Customer;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Home
{
    public class Public_ItemsView: IPublic_ItemsView
    {
       
        PostgreSqlContext _context;
        Db_Connection conn = new Db_Connection();
        ISqlClass _sql;
        IErrorClass _error;

        public Public_ItemsView(PostgreSqlContext context, ISqlClass sql, IErrorClass error)
        {
            _context = context;
            _sql = sql;
            _error = error;
                  }

        public ItemViewDTO getdata(ItemViewDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Public_ItemView/getdata";
            var Params = new DbParameter[] { };
            try
            {
                var cat = _context.Master_CategoryDMO_con.Where(a => a.mc_id == dto.category_id).FirstOrDefault();
                dto.categoryname = cat.category_name;
                // item view
                var dbParams = new DbParameter[]
           {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_category_id", dto.category_id)
            };
                Params = dbParams;
                dto.procedure_name = "fn_itemview";
                dto.itemslist = _sql.fn_get_list(dto.procedure_name, dbParams);


                // attribute list
                var dbParams1 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_category_id", dto.category_id)
                 };
                Params = dbParams1;
                dto.procedure_name = "fn_get_sub_additional_cat_list";
                dto.sub_add_cat_list = _sql.Get_Data(dto.procedure_name, dbParams1);



                // attribute list
                var dbParams2 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_cat_id", dto.category_id)
                 };
                Params = dbParams2;
                dto.procedure_name = "fn_attributes_data_value";
                dto.attributevaluelist = _sql.fn_get_list(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public ItemViewDTO show_items(ItemViewDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Public_ItemView/show_items";

            try
            {
                List<long> nameid = new List<long>();
                List<long> valueid = new List<long>();
                foreach (var item in dto.list)
                {
                    if (item != null)
                    {
                        nameid.Add(item.attributename_id);
                    }
                }
                if (nameid.Count == 0)
                {
                    // item view
                    var dbParams = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id)
                 };

                    dto.procedure_name = "fn_get_itemview_addcat";
                    dto.itemslist = _sql.fn_get_list(dto.procedure_name, dbParams);

                    return dto;
                }
                foreach (var item in dto.list)
                {
                    if (item != null)
                    {
                        valueid.Add(item.attributevalue_id);
                    }

                }

                dto.itemslist = (from a in _context.Product_ItemDMO_con
                                 from b in _context.product_item_specificationDMO_con
                                 from c in _context.Master_Product_con
                                 where a.item_id == b.item_id && valueid.Contains(b.attribute_value_id) && nameid.Contains(b.attribute_name_id) && a.product_id == c.product_id && c.additional_cat_id == dto.additional_cat_id
                                 select new ItemViewDTO
                                 {
                                     itemcode = a.item_code,
                                     itemname = a.item_name,
                                     itemid=a.item_id,
                                     v_mrp = a.mrp,
                                     listingprice = a.listing_price,
                                     minquantity = a.min_quantity,
                                     itemimage = a.item_image,
                                 }).Distinct().ToArray();

            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, page_form);
            }
            finally
            {
                _error.audit_log_txr(dto.userid, methodname, page_form);
            }
            return dto;
        }

        public ItemViewDTO get_data_addcat(ItemViewDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Public_ItemView/get_data_addcat";
            var Params = new DbParameter[] { };
            try
            {
                var cat = _context.Additional_Cat_con.Where(a => a.additional_cat_id == dto.additional_cat_id).FirstOrDefault();
                dto.addcategoryname = cat.additional_cat_name;

                // item view
                var dbParams = new DbParameter[]
            {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", dto.additional_cat_id)
             };
                Params = dbParams;
                dto.procedure_name = "fn_get_itemview_addcat";
                dto.itemslist = _sql.fn_get_list(dto.procedure_name, dbParams);





                // attribute list
                var dbParams2 = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_addcat_id", dto.additional_cat_id)
                 };
                Params = dbParams2;
                dto.procedure_name = "fn_landing_attributes_name";
                dto.attributenamelist = _sql.Get_Data(dto.procedure_name, dbParams2);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
    }
}
