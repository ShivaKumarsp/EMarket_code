
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Master;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarket.Entities.Master;
using EMarketDTO.Master;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Master
{
    public class Master_Category: IMaster_Category
    {
        IMaster_Category_Repository _inter;
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        IDuplicateCheck _duplicate;
        int sts = 0;
        string return_string = "";

        public Master_Category(IMaster_Category_Repository inter, PostgreSqlContext context, ISqlClass sql, IErrorClass error, IDuplicateCheck duplicate)
        {
            _inter = inter;
            _context = context;
            _sql = sql;
            _error = error;
            _duplicate = duplicate;
        }
        // category
        public Master_CategoryDTO get_data_cat(Master_CategoryDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category/get_data_cat";

            try
            {
                var dbParams = new DbParameter[]
                               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                               };
                Params = dbParams;
                dto.category_list = _sql.Get_Data("fn_get_master_category_list", dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_master_category_list", Params);
            }
            return dto;
        }
        public Master_CategoryDTO save_cat(Master_CategoryDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category/save_cat";

            try
            {
                

                if (dto.mc_id > 0)
                {
                    var catname = _context.Master_CategoryDMO_con.Where(a => a.category_name == dto.category_name.Trim() && a.mc_id!=dto.mc_id).ToList();
                    if (catname.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Category Already Exist";
                        return dto;
                    }

                    var result = _context.Master_CategoryDMO_con.Where(a => a.mc_id == dto.mc_id).SingleOrDefault();
                    result.category_name = dto.category_name.Trim();
                    result.category_code = dto.category_code.Trim();
                    result.description = dto.description.Trim();
                    result.image_url = dto.image_url;
                    result.language_id = dto.language_id;
                    _context.Update(result);
                    sts = _context.SaveChanges();
                    if (sts == 1)
                    {
                        dto.status = "Insert";
                        dto.message = "Category Updated Successfully";
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Category Not Updated Successfully";
                    }

                }
                else
                {
                    var catname = _context.Master_CategoryDMO_con.Where(a => a.category_name == dto.category_name.Trim()).ToList();
                    if (catname.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Category Already Exist";
                        return dto;
                    }

                    Master_CategoryDMO dmo = new Master_CategoryDMO();
                    dmo.category_name = dto.category_name.Trim();
                    dmo.category_code = dto.category_code.Trim();
                    dmo.description = dto.description.Trim();
                    dmo.image_url = dto.image_url;
                    dmo.language_id = dto.language_id;
                    dmo.is_active = true;
                    _context.Add(dmo);
                    sts = _context.SaveChanges();
                    if (sts == 1)
                    {
                        dto.status = "Insert";
                        dto.message = "Category Insert Successfully";
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Category Not Insert Successfully";
                    }
                }
                
            }         

            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_master_category_list", Params);
            }

            try
            {
                var dbParams = new DbParameter[]
                               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                               };
                Params = dbParams;
                dto.category_list = _sql.Get_Data("fn_get_master_category_list", dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_master_category_list", Params);
            }
            return dto;
        }
        public Master_CategoryDTO delete_cat(Master_CategoryDTO dto)
        {
            int str = 0;
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category/delete_cat";

            try
            {
                var product = _context.Master_Product_con.Where(a => a.category_id == dto.mc_id).ToList();
                if (product.Count > 0)
                {
                    dto.status = "Duplicate";
                    dto.message = "Category Already Maped In Product, You can't Delete";
                    return dto;
                }
                else
                {
                    var result = _context.Master_CategoryDMO_con.Where(a => a.mc_id == dto.mc_id).SingleOrDefault();
                    _context.Remove(result);
                   str=  _context.SaveChanges();
                }
              
                if (str>0)
                {
                    dto.status = "Deleted";
                    dto.message = "Category Successfully Deleted";
                }
                else
                {
                    dto.status = "Deleted";
                    dto.message = "Somthing Wrong, Please Try Again";
                }
                try
                {
                    var dbParams = new DbParameter[]
                                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                                   };
                    Params = dbParams;
                    dto.category_list = _sql.Get_Data("fn_get_master_category_list", dbParams);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_master_category_list", Params);
                }

            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "Delete Category", page_form);
            }
            return dto;
        }

        // Sub category
        public Master_CategoryDTO get_data_subcat(Master_CategoryDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category/get_data_cat";

            try
            {
                var subcatlist = (from a in _context.Master_SubCategoryDMO_con
                                  from b in _context.Master_CategoryDMO_con
                                  where a.mc_id == b.mc_id && a.language_id == dto.language_id && b.language_id == dto.language_id
                                  select new Master_CategoryDTO
                                  {
                                      msc_id = a.msc_id,
                                      mc_id=b.mc_id,
                                      msc_name=a.msc_name,
                                     category_name=b.category_name,
                                      msc_description = a.msc_description,
                                      msc_imageurl=a.msc_imageurl
                                  }).OrderBy(a => a.msc_name).ToList();

                dto.subcategory_list = Newtonsoft.Json.JsonConvert.SerializeObject(subcatlist);

                var catlistdd = _context.Master_CategoryDMO_con.Where(a => a.language_id == dto.language_id).ToList();
                dto.category_dd = Newtonsoft.Json.JsonConvert.SerializeObject(catlistdd);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_master_category_list", Params);
            }
            return dto;
        }
        public Master_CategoryDTO save_subcat(Master_CategoryDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category/save_subcat";

            try
            {  
                if (dto.msc_id > 0)
                {
                    var catname = _context.Master_SubCategoryDMO_con.Where(a => a.msc_name.Trim() == dto.msc_name.Trim() && a.msc_id!=dto.msc_id).ToList();
                    if (catname.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Sub Category Already Exist";
                        return dto;
                    }

                    try
                    {
                        _inter.save_subcat(dto);
                    }
                    catch(Exception ex)
                    {
                        _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form,dto.inputvalue, page_form);
                    }

                }
                else
                {
                    var catname = _context.Master_SubCategoryDMO_con.Where(a => a.msc_name.Trim() == dto.msc_name.Trim()).ToList();
                    if (catname.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Sub Category Already Exist";
                        return dto;
                    }

                    if (dto.language_id == 1)
                    {
                        long result = 0;
                        var result1 = _context.Master_SubCategoryDMO_con.ToList();
                        if(result1.Count>0)
                        {
                            result = _context.Master_SubCategoryDMO_con.Max(a => a.msc_id);
                        }
                        else
                        {
                            result = 0;
                        }

                        Master_SubCategoryDMO dmo = new Master_SubCategoryDMO();
                        dmo.msc_id = result + 1;
                        dmo.mc_id = dto.mc_id;
                        dmo.msc_name = dto.msc_name;
                        dmo.msc_description = dto.description;
                        dmo.msc_imageurl = dto.image_url;
                        dmo.msc_activeflg = true;
                        dmo.language_id = dto.language_id;
                        dmo.insert_on = DateTime.Now;
                        dmo.insert_by = dto.user_id;
                        _context.Add(dmo);                   
                    }
                    else if(dto.language_id == 2)
                    {
                        var result = _context.Master_SubCategoryDMO_con.Where(a => a.msc_id == dto.msc_id && a.language_id==1).FirstOrDefault(); 
                        Master_SubCategoryDMO dmo = new Master_SubCategoryDMO();
                        dmo.msc_id = result.msc_id;
                        dmo.mc_id = dto.mc_id;
                        dmo.msc_name = dto.msc_name;
                        dmo.msc_description = dto.description;
                        dmo.msc_imageurl = dto.image_url;
                        dmo.msc_activeflg = true;
                        dmo.language_id = dto.language_id;
                        dmo.insert_on = DateTime.Now;
                        dmo.insert_by = dto.user_id;
                        _context.Add(dmo);
                    }
                    sts = _context.SaveChanges();
                    if (sts >0)
                    {
                        dto.status = "Insert";
                        dto.message = "Sub Category Insert Successfully";
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Sub Category Not Insert Successfully";
                    }
                }

            }

            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "linq", page_form);
            }

            try
            {
                var subcatlist = (from a in _context.Master_SubCategoryDMO_con
                                  from b in _context.Master_CategoryDMO_con
                                  where a.mc_id == b.mc_id && a.language_id == dto.language_id && b.language_id == dto.language_id
                                  select new Master_CategoryDTO
                                  {
                                      msc_id = a.msc_id,
                                      mc_id = b.mc_id,
                                      msc_name = a.msc_name,
                                      category_name = b.category_name,
                                      msc_description = a.msc_description,
                                      msc_imageurl = a.msc_imageurl
                                  }).OrderBy(a => a.msc_name).ToList();
                dto.subcategory_list = Newtonsoft.Json.JsonConvert.SerializeObject(subcatlist);

                var catlistdd = _context.Master_CategoryDMO_con.Where(a => a.language_id == dto.language_id).ToList();
                dto.category_dd = Newtonsoft.Json.JsonConvert.SerializeObject(catlistdd);
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "linq", page_form);
            }
            return dto;
        }
        public Master_CategoryDTO delete_subcat(Master_CategoryDTO dto)
        {
            int str = 0;
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_Category/delete_cat";

            try
            {
                var product = _context.Master_Product_con.Where(a => a.sub_category_id == dto.msc_id).ToList();
                if (product.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "SubCategory Already Maped In Product, You can't Delete";
                    return dto;
                }
                else
                {
                    var result = _context.Master_SubCategoryDMO_con.Where(a => a.msc_id == dto.msc_id).SingleOrDefault();
                    _context.Remove(result);
                    str = _context.SaveChanges();
                }

                if (str > 0)
                {
                    dto.status = "Insert";
                    dto.message = "Sub Category Successfully Deleted";
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "Somthing Wrong, Please Try Again";
                }
                try
                {
                    var subcatlist = (from a in _context.Master_SubCategoryDMO_con
                                      from b in _context.Master_CategoryDMO_con
                                      where a.mc_id == b.mc_id && a.language_id == dto.language_id && b.language_id == dto.language_id
                                      select new Master_CategoryDTO
                                      {
                                          msc_id = a.msc_id,
                                          mc_id = b.mc_id,
                                          msc_name = a.msc_name,
                                          category_name = b.category_name,
                                          msc_description = a.msc_description,
                                          msc_imageurl = a.msc_imageurl
                                      }).OrderBy(a=>a.msc_name).ToList();
                    dto.subcategory_list = Newtonsoft.Json.JsonConvert.SerializeObject(subcatlist);

                    var catlistdd = _context.Master_CategoryDMO_con.Where(a => a.language_id == dto.language_id).ToList();
                    dto.category_dd = Newtonsoft.Json.JsonConvert.SerializeObject(catlistdd);
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_master_category_list", Params);
                }

            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "linq", page_form);
            }
            return dto;
        }
    }
}
