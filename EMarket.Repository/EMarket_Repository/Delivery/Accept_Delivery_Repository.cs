using EMarket.DLL.Comman_Data;
using EMarket.DLL.Interfaces.Delivery;
using EMarket.Entities;
using EMarketDTO.Delivery;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Delivery
{
    public class Accept_Delivery_Repository: IAccept_Delivery_Repository
    {
        PostgreSqlContext _context;
        comman_class conn = new comman_class();
        int status = 0;
        List<string> invalue = new List<string>();

        public Accept_Delivery_Repository(PostgreSqlContext context)
        {
            _context = context;
        }

        public Accept_DeliveryDTO update_accept_delivery(Accept_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Accept_Delivery_Repository/update_accept_delivery";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
           

                var dbParams3 = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                   };
                Params = dbParams3;
                var spName = "call sp_update_accept_delivery(:in_consignment_id, :in_order_item_id,:in_delivery_executive_id,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }

            return dto;
        }
        public Accept_DeliveryDTO update_accept_delivery_store(Accept_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Accept_Delivery_Repository/update_accept_delivery";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);

            foreach (var item in dto.connsignment_array)
            {

                var dbParams3 = new DbParameter[]
       {
                    DbHelper.CreateParameter("in_consignment_id", item.consignment_id),
                    DbHelper.CreateParameter("in_order_item_id", item.order_item_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                     DbHelper.CreateParameter("in_user_id", dto.user_id)
       };
                Params = dbParams3;
                var spName = "call sp_update_accept_delivery(:in_consignment_id, :in_order_item_id,:in_delivery_executive_id,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
            }
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }




            return dto;
        }
        public Accept_DeliveryDTO pickup_from_vendor(Accept_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Accept_Delivery_Repository/pickup_from_vendor";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
          
              
                var dbParams3 = new DbParameter[]
                   {
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
                   };
                Params = dbParams3;
                var spName = "call sp_item_pick_from_vendor(:in_consignment_id, :in_order_item_id,:in_delivery_executive_id,:in_language_id,:in_user_id)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
                if (status == -1)
                {
                    dto.status = "Accept";
                }
                else
                {
                    dto.status = "Failed";
                }

            return dto;
        }
        public Accept_DeliveryDTO update_reject_delivery(Accept_DeliveryDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Accept_Delivery_Repository/update_reject_delivery";
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);


            var dbParams3 = new DbParameter[]
               {
                    DbHelper.CreateParameter("in_consignment_id", dto.consignment_id),
                    DbHelper.CreateParameter("in_order_item_id", dto.order_item_id),
                    DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_reasion", dto.reasion)
               };
            Params = dbParams3;
            var spName = "call sp_reject_item_to_facilitation(:in_consignment_id, :in_order_item_id,:in_delivery_executive_id,:in_language_id,:in_user_id,:in_reasion)";
            status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams3);
            if (status == -1)
            {
                dto.status = "Reject";
            }
            else
            {
                dto.status = "Failed";
            }

            return dto;
        }

    }
}
