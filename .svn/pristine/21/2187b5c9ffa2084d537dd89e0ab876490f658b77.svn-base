using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Vendor;
using EMarket.DLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Vendor
{
    public class All_Item: IAll_Item
    {
        IAll_Item_Repository _inter;
        Db_Connection conn = new Db_Connection();
        PostgreSqlContext _context;
        //SqlHelper sqlHelper = new SqlHelper();
        ISqlClass _sql;
        IErrorClass _error;
        int return_int = 0;
        string return_string = "";
        public All_Item(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IAll_Item_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public All_ItemDTO get_data(All_ItemDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "All_Item/get_date";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            try
            {
                // Check And Update Quantity
                var dddd = DateTime.Now.AddMinutes(-2);
                var resultqty = _context.Payment_Order_QtyDMO_con.Where(a => a.order_on <= dddd).ToList();
                if (resultqty.Count > 0)
                {
                    foreach (var item in resultqty)
                    {
                        var dbParams2 = new DbParameter[]
                  {
                    DbHelper.CreateParameter("in_payment_order_id", item.payment_order_id),
                    DbHelper.CreateParameter("in_item_id", item.item_id),
                    DbHelper.CreateParameter("in_quantity", item.quantity),
                    DbHelper.CreateParameter("in_order_on", item.order_on)
                  };
                        Params = dbParams2;
                        var spName = "call buy_quantity_update(:in_payment_order_id, :in_item_id,:in_quantity,:in_order_on)";
                      _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams2);
                    }
                }

                var customer = _context.Vendor_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.vendor_id = customer.vendor_id;

                // get All item
                var dbParams = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),

                    };
                Params = dbParams;
                dto.all_item_list = _sql.fn_get_list("fn_get_all_Itemlist", dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, "fn_get_all_Itemlist", Params);
            }
            return dto;
        }

        // edit items
        public All_ItemDTO get_edit_data(All_ItemDTO dto)
        {
            return _inter.get_edit_data(dto);
        }
        public All_ItemDTO saveproductitem(All_ItemDTO dto)
        {
            return _inter.saveproductitem(dto);
        }
        public All_ItemDTO get_specific_edit_data(All_ItemDTO dto)
        {
            return _inter.get_specific_edit_data(dto);
        }
        public All_ItemDTO update_attribute(All_ItemDTO dto)
        {
            return _inter.update_attribute(dto);
        }
         public All_ItemDTO get_product_details(All_ItemDTO dto)
        {
            return _inter.get_product_details(dto);
        }

    }
}
