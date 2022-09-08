using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Admin;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class Product_Features : IProduct_Features
    {
        IProduct_Features_Repository _inter;
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();

        public Product_Features(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IProduct_Features_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public product_featuresDTO Get_productfeatures(product_featuresDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Product_Feature/Get_productfeatures";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);


            try
            {
                dto.product_name = _context.Master_Product_con.Where(a => a.product_id == dto.product_id && a.language_id == dto.language_id).SingleOrDefault().product_name.TrimEnd();

                var dbParams = new DbParameter[]
                    {

                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
                                      };
                Params = dbParams;
                dto.procedure_name = "fn_get_product_feature";
                dto.feature_list = _sql.fn_get_list(dto.procedure_name, dbParams);

            
            
                var dbParams1 = new DbParameter[]
                {
                    //DbHelper.CreateParameter("in_language_id", dto.language_id),
                };
                Params = dbParams1;
                dto.procedure_name = "fn_productslist";
                dto.productslist = _sql.fn_get_list(dto.procedure_name, dbParams1);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public product_featuresDTO save_productfeatures(product_featuresDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Product_Feature/save_productfeatures";

            if (dto.description.Trim() == "" || dto.description.Trim() == null)
            {
                dto.msg_flg = "Please Enter Product Description";
                return dto;
            }
            try
            {
                _inter.save_productfeatures(dto);
            }
            catch(Exception ex)
            {
                _error.errorlog_add(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            try
            {
                var dbParams = new DbParameter[]
                {                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_product_id", dto.product_id),
                };
                Params = dbParams;
                dto.feature_list = _sql.fn_get_list("fn_get_product_feature", dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_product_feature", Params);
            }

            return dto;
        }
    }
}
