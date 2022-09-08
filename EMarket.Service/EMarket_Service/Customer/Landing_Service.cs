using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Customer;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarketDTO.Customer;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Customer
{
    public class Landing_Service: ILanding_Service
    {
        private readonly ILanding_Repository _repo;
        IDuplicateCheck _dup;       
        PostgreSqlContext _context;
        Db_Connection conn = new Db_Connection();
        IErrorClass _error;
        ISqlClass _sql;

        public Landing_Service(PostgreSqlContext context,  ISqlClass sql, IErrorClass error,
            ILanding_Repository repo, IDuplicateCheck dup)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _repo = repo;
            _dup = dup;
        }

        public PublicLandingDTO getdata(PublicLandingDTO dto)
        {
            bool check;
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Service/getdata";
            var Params = new DbParameter[] { };
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, INDIAN_ZONE);
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            //try
            //{
            //    dto.userid = 10000003;
            //    check = _duplicate.check_doubleclick(methodname, dto.userid);
            //    if(!check)
            //    {
            //        return dto;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _error.errorlog(ex, 0, methodname, dto.ipAddress, "Web", page_form, "fn_check_double_click", Params);
            //}
           

            try
            {
                // Check And Update Quantity
                var dddd = DateTime.Now.AddMinutes(-2);
                var resultqty = _context.Payment_Order_QtyDMO_con.Where(a => a.order_on <= dddd).ToList();
                if (resultqty.Count > 0)
                {
                    foreach (var item in resultqty)
                    {
                        var dbParams5 = new DbParameter[]
                  {
                    DbHelper.CreateParameter("in_payment_order_id", item.payment_order_id),
                    DbHelper.CreateParameter("in_item_id", item.item_id),
                    DbHelper.CreateParameter("in_quantity", item.quantity),
                    DbHelper.CreateParameter("in_order_on", item.order_on)
                  };
                        Params = dbParams5;
                        var spName = "call buy_quantity_update(:in_payment_order_id, :in_item_id,:in_quantity,:in_order_on)";
                    _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams5);
                    }
                }

                // category wise product
                var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                   };
                Params = dbParams;
                dto.procedure_name = "fn_get_category_wise_product";
                dto.category_list = _sql.fn_get_list(dto.procedure_name, dbParams);
           

                // get all product
                var dbParams1 = new DbParameter[]
                        {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                        };
                Params = dbParams1;
                dto.procedure_name = "fn_get_all_product";
                dto.product_list = _sql.fn_get_list(dto.procedure_name, dbParams1);

                // item view
                var dbParams2 = new DbParameter[]
            {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id",Convert.ToInt64(201)),
                      DbHelper.CreateParameter("in_orderby", "")
             };
                Params = dbParams;
                dto.procedure_name = "fn_get_itemview_addcat";
                dto.itemslist_1 = _sql.Get_Data(dto.procedure_name, dbParams2);

                // item view
                var dbParams3 = new DbParameter[]
            {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_additional_cat_id", Convert.ToInt64(198)),
                      DbHelper.CreateParameter("in_orderby", "")
             };
                Params = dbParams3;
                dto.procedure_name = "fn_get_itemview_addcat";
                dto.itemslist_2 = _sql.Get_Data(dto.procedure_name, dbParams3);

                // banner list
                var dbParams4 = new DbParameter[]
                        {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                        };
                Params = dbParams4;
                dto.procedure_name = "fn_get_banner_list";
                dto.banner_list = _sql.Get_Data(dto.procedure_name, dbParams4);
            }


            catch (Exception ex)
            {
                _error.errorlog(ex, 0, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public PublicLandingDTO get_specification(PublicLandingDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Service/get_specification";
            var Params = new DbParameter[] { };

            try
            {
                var dbParams = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id),
                };
                Params = dbParams;
                dto.procedure_name = "fn_get_specification";
                dto.specification_list = _sql.fn_get_list(dto.procedure_name, dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, 0, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public PublicLandingDTO get_specification_details(PublicLandingDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Service/get_specification";
            var Params = new DbParameter[] { };
        
            try
            {
                var dbParams = new DbParameter[]
                {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id),
                      DbHelper.CreateParameter("in_specification_id", dto.Specification_id),
                };
                Params = dbParams;
                dto.procedure_name = "fn_get_specification_details";
                dto.specification_details_list = _sql.fn_get_list(dto.procedure_name, dbParams);



            }
            catch (Exception ex)
            {
                _error.errorlog(ex, 0, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public PublicLandingDTO get_public_productdetails(PublicLandingDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Service/get_public_productdetails";
            var Params = new DbParameter[] { };
            try
            {

                //dto.product_list = (from a in _context.Master_Products_con
                //                    from b in _context.Product_Variant_con
                //                    where a.visibletoeveryone == true && a.product_id == b.product_id && a.product_id == dto.product_id
                //                    && b.variant_id==dto.variant_id
                //                    select new PublicLandingDTO
                //                    {
                //                        product_id = a.product_id,
                //                        variant_id = b.variant_id,
                //                        mc_id = a.mc_id,
                //                        product_name = a.product_name,
                //                        vp_mrpprice = b.mrp,
                //                        vp_quantity = b.remain_quantity,
                //                        vp_sellingprice = b.selling_price,
                //                        imageurl = a.image_url,
                //                        vp_shortdescription = a.short_description,
                //                        vp_longdescription = a.long_description,
                //                        additional_feature=b.additional_feature
                //                    }).ToArray();


                //dto.public_gallery_list = (from b in _context.Products_Imagesgallery_con
                //                           where b.product_id == dto.product_id
                //                           select new PublicLandingDTO
                //                           {
                //                               galleryurl = b.image_url
                //                           }).ToArray();

                //dto.similarproductlist = (from a in _context.Master_Products_con
                //                          from c in _context.Product_Variant_con
                //                          where a.mc_id == dto.mc_id && a.product_id == c.product_id
                //                          select new PublicLandingDTO
                //                          {
                //                              product_id = a.product_id,
                //                              variant_id = c.variant_id,
                //                              mc_id = a.mc_id,
                //                              product_name = a.product_name,
                //                              vp_mrpprice = c.mrp,
                //                              vp_quantity = c.remain_quantity,
                //                              vp_sellingprice = c.selling_price,
                //                              imageurl = a.image_url
                //                          }).Distinct().ToArray();

                //dto.reviewlistall = (from a in _context.Rating_Features_con
                //                     where a.product_id == dto.product_id && a.variant_id == dto.variant_id
                //                     select new PublicLandingDTO
                //                     {
                //                         rating_id = a.rating_id,
                //                         rating_number = a.rating_number
                //                     }).Distinct().ToArray();

                //dto.reviewlist = (from a in _context.Rating_Features_con
                //                  from b in _context.AspNetUsers_con
                //                  where a.product_id == dto.product_id && a.userid == b.userid && a.variant_id == dto.variant_id
                //                  select new PublicLandingDTO
                //                  {
                //                      rating_id = a.rating_id,
                //                      comments = a.comments,
                //                      username = b.UserName,
                //                      rating_number = a.rating_number
                //                  }).OrderByDescending(a => a.rating_id).Distinct().ToArray();

                //dto.product_varient_list = (from a in _context.Product_Variant_con
                //                            where a.product_id == dto.product_id && a.variant_id == dto.variant_id
                //                            select new PublicLandingDTO
                //                            {
                //                                product_id = a.product_id,
                //                                variant_id = a.variant_id,
                //                                attribute_details = a.attribute_details
                //                            }).ToArray();

                //dto.product_all_varient_list = (from a in _context.Product_Variant_con
                //                                from b in _context.Master_Products_con
                //                                where a.product_id == dto.product_id && a.product_id == b.product_id
                //                                select new Customer_LandingpageDTO
                //                                {
                //                                    product_id = a.product_id,
                //                                    variant_id = a.variant_id,
                //                                    mc_id = b.mc_id,
                //                                    attribute_details = a.attribute_details,
                //                                    imageurl = b.image_url
                //                                }).ToArray();

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, 0, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public PublicLandingDTO attributecheck(PublicLandingDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Service/get_public_productdetails";
            var Params = new DbParameter[] { };
            try
            {
                //dto.product_listdetails = (from a in _context.Master_Products_con
                //                           from c in _context.Product_Variant_con
                //                           where a.product_id == dto.product_id && a.product_id == c.product_id && c.variant_id == dto.variant_id
                //                           select new Customer_LandingDetailsDTO
                //                           {
                //                               product_id = a.product_id,
                //                               variant_id = c.variant_id,
                //                               mc_id = a.mc_id,
                //                               product_name = a.product_name,
                //                               vp_mrpprice = c.mrp,
                //                               vp_quantity = c.remain_quantity,
                //                               vp_sellingprice = c.selling_price,
                //                               imageurl = a.image_url,
                //                               vp_shortdescription = a.short_description,
                //                               vp_longdescription = a.long_description,
                //                               additional_feature = c.additional_feature
                //                           }).ToArray();

                //dto.product_listgallery = (from b in _context.Products_Imagesgallery_con
                //                           where b.product_id == dto.product_id
                //                           select new Customer_LandingDetailsDTO
                //                           {
                //                               galleryurl = b.image_url
                //                           }).ToArray();

                //dto.reviewlist = (from a in _context.Rating_Features_con
                //                  from b in _context.AspNetUsers_con
                //                  where a.userid == b.userid && a.product_id == dto.product_id && a.userid == dto.userid && a.variant_id == dto.variant_id
                //                  select new Customer_LandingDetailsDTO
                //                  {
                //                      rating_id = a.rating_id,
                //                      comments = a.comments,
                //                      username = b.UserName,
                //                      rating_number = a.rating_number
                //                  }).OrderByDescending(a => a.rating_id).ToArray();

                //dto.similarproductlist = (from a in _context.Master_Products_con
                //                          from c in _context.Product_Variant_con
                //                          where a.mc_id == dto.mc_id && a.product_id == c.product_id
                //                          select new Customer_LandingDetailsDTO
                //                          {
                //                              product_id = a.product_id,
                //                              variant_id = c.variant_id,
                //                              mc_id = a.mc_id,
                //                              product_name = a.product_name,
                //                              vp_mrpprice = c.mrp,
                //                              vp_quantity = c.remain_quantity,
                //                              vp_sellingprice = c.selling_price,
                //                              imageurl = a.image_url

                //                          }).Distinct().ToArray();

                //dto.reviewlistall = (from a in _context.Rating_Features_con
                //                     where a.product_id == dto.product_id && a.variant_id == dto.variant_id
                //                     select new Customer_LandingDetailsDTO
                //                     {
                //                         rating_id = a.rating_id,
                //                         rating_number = a.rating_number
                //                     }).Distinct().ToArray();
                //dto.cartlist = _context.Product_Cartlist_con.Where(a => a.userid == dto.userid && a.customer_id == dto.userid).ToArray();
                //dto.wishlist = _context.Product_Wishlist_con.Where(a => a.userid == dto.userid && a.customer_id == dto.userid).ToArray();

                //dto.product_varient_list = (from a in _context.Product_Variant_con
                //                            where a.product_id == dto.product_id && a.variant_id == dto.variant_id
                //                            select new Customer_LandingpageDTO
                //                            {
                //                                product_id = a.product_id,
                //                                variant_id = a.variant_id,
                //                                attribute_details = a.attribute_details
                //                            }).ToArray();

                //dto.product_all_varient_list = (from a in _context.Product_Variant_con
                //                                from b in _context.Master_Products_con
                //                                where a.product_id == dto.product_id && a.product_id == b.product_id
                //                                select new Customer_LandingpageDTO
                //                                {
                //                                    product_id = a.product_id,
                //                                    variant_id = a.variant_id,
                //                                    mc_id = b.mc_id,
                //                                    attribute_details = a.attribute_details,
                //                                    imageurl = b.image_url
                //                                }).ToArray();
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, 0, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public PublicLandingDTO get_subcategory(PublicLandingDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Service/get_subcategory";
            var Params = new DbParameter[] { };
            try
            {
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_mc_id", dto.mc_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_subcategory_dd";
                dto.subcategory_list = _sql.Get_Data(dto.procedure_name, dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, 0, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public PublicLandingDTO get_addcategory(PublicLandingDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Service/get_subcategory";
            var Params = new DbParameter[] { };
            try
            {
                var dbParams = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_mc_id", dto.mc_id),
                      DbHelper.CreateParameter("in_msc_id", dto.msc_id)
               };
                Params = dbParams;
                dto.procedure_name = "fn_get_addcategory_list";
                dto.addcategory_list = _sql.Get_Data(dto.procedure_name, dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, 0, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }

        public PublicLandingDTO getdata_footer(PublicLandingDTO dto)
        {
            bool check;
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Landing_Service/getdata_footer";
            var Params = new DbParameter[] { };
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, INDIAN_ZONE);
           

            try
            {
                // category wise product
                var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                   };
                Params = dbParams;
                dto.procedure_name = "fn_get_category_wise_product";
                dto.category_list = _sql.fn_get_list(dto.procedure_name, dbParams);



            }


            catch (Exception ex)
            {
                _error.errorlog(ex, 0, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
    }
}
