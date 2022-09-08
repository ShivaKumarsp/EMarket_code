using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarketDTO.Customer;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.DLL.EMarket_Repository.Customer
{
    public class Customer_Address_Repository: ICustomer_Address_Repository
    {
        PostgreSqlContext _context;
        comman_class conn = new comman_class();
        ISql_Layer _sql;
        IError_Log _error;
        int status = 0;
        public Customer_Address_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;
        }

        public Customer_AddressDTO Upadate_Customer_Address(Customer_AddressDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            int result;
            var dbParams = new DbParameter[]
      {
                    DbHelper.CreateParameter("in_address_id", dto.address_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id),
                    DbHelper.CreateParameter("in_customer_name", dto.customer_name),
                    DbHelper.CreateParameter("in_address_line_1", dto.address_line_1),
                    DbHelper.CreateParameter("in_address_line_2", dto.address_line_2),
                    DbHelper.CreateParameter("in_city", dto.city),
                    DbHelper.CreateParameter("in_pincode", dto.pincode),
                    DbHelper.CreateParameter("in_land_mark", dto.land_mark),
                    DbHelper.CreateParameter("in_default_address", dto.default_address),
                    DbHelper.CreateParameter("in_mobile", dto.mobile),
                    DbHelper.CreateParameter("in_email_id", dto.email_id),
                    DbHelper.CreateParameter("in_country_id", dto.country_id),
                    DbHelper.CreateParameter("in_state_id", dto.state_id),
           };

            var spName = "call sp_saveupdate_customer_address(:in_address_id,:in_user_id,:in_customer_name,:in_address_line_1,:in_address_line_2,:in_city,:in_pincode,:in_land_mark,:in_default_address,:in_mobile,:in_email_id,:in_country_id,:in_state_id)";
            result = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);

            if (result == -1)
            {
                dto.statusflg = true;
                dto.messageflg = "Address Updated Successfully";
            }
            else
            {
                dto.statusflg = false;
                dto.messageflg = "Address updation Failed, Please Try Again";
            }

         

            

            //using (var cnn = new NpgsqlConnection(comm.ConnectionString))
            //        {
            //    dto.procedure_name = "sp_saveupdate_customer_address";
            //            NpgsqlCommand cmd = new NpgsqlCommand("call sp_saveupdate_customer_address(:in_address_id,:in_user_id,:in_customer_name,:in_address_line_1,:in_address_line_2,:in_city,:in_pincode,:in_land_mark,:in_default_address,:in_mobile,:in_email_id,:in_country_id,:in_state_id)", cnn);
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Parameters.AddWithValue("in_address_id", DbType.Int64).Value = dto.address_id;
            //            cmd.Parameters.AddWithValue("in_user_id", DbType.Int64).Value = dto.user_id;
            //            cmd.Parameters.AddWithValue("in_customer_name", DbType.String).Value = dto.customer_name;
            //            cmd.Parameters.AddWithValue("in_address_line_1", DbType.String).Value = dto.address_line_1;
            //            cmd.Parameters.AddWithValue("in_address_line_2", DbType.String).Value = dto.address_line_2;
            //            cmd.Parameters.AddWithValue("in_city", DbType.String).Value = dto.city;
            //            cmd.Parameters.AddWithValue("in_pincode", DbType.Int64).Value = dto.pincode;
            //            cmd.Parameters.AddWithValue("in_land_mark", DbType.String).Value = dto.land_mark;
            //            cmd.Parameters.AddWithValue("in_default_address", DbType.Boolean).Value = dto.default_address;
            //            cmd.Parameters.AddWithValue("in_mobile", DbType.Int64).Value = dto.mobile;
            //            cmd.Parameters.AddWithValue("in_email_id", DbType.String).Value = dto.email_id;
            //            cmd.Parameters.AddWithValue("in_country_id", DbType.Int64).Value = dto.country_id;
            //            cmd.Parameters.AddWithValue("in_state_id", DbType.Int64).Value = dto.state_id;
            //            cnn.Open();


            //    result = cmd.ExecuteNonQuery();
            //            if (result == -1)
            //            {
            //                dto.statusflg = true;
            //                dto.messageflg = "Address Updated Successfully";
            //            }
            //            else
            //            {
            //                dto.statusflg = false;
            //                dto.messageflg = "Address updation Failed, Please Try Again";
            //            }

            //        }


            return dto;
        }
       
    }
}
