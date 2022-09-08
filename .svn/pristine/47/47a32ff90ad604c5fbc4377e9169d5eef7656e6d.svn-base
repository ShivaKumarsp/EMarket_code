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
using System.Linq;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Customer
{
    public class Customer_Profile_Repository : ICustomer_Profile_Repository
    {
        int status = 0;
        PostgreSqlContext _context;
        comman_class cmm = new comman_class();        
        ISql_Layer _sql;
        IError_Log _error;
        List<string> invalue = new List<string>();
        public Customer_Profile_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;         

        }       

        public Customer_ProfileDTO Upadate_Customer_Details(Customer_ProfileDTO dto)
        {
            bool result = true;
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
            {
                    var dbParams = new DbParameter[]
     {
                               DbHelper.CreateParameter("in_customer_id", dto.customer_id),
                               DbHelper.CreateParameter("in_user_id",  dto.user_id),
                               DbHelper.CreateParameter("in_first_name",  dto.first_name),
                               DbHelper.CreateParameter("in_second_name",  dto.second_name),
                               DbHelper.CreateParameter("in_email",  dto.email),
                               DbHelper.CreateParameter("in_mobile",   Convert.ToInt64(dto.mobile)),
                               DbHelper.CreateParameter("in_address",  dto.address),
                               DbHelper.CreateParameter("in_city",  dto.city),
                               DbHelper.CreateParameter("in_state_id",  dto.state_id),
                               DbHelper.CreateParameter("in_country_id",  dto.country_id),
                               DbHelper.CreateParameter("in_pincode",  Convert.ToInt64(dto.pincode)),
                               DbHelper.CreateParameter("in_dob",  dto.dob),
                               DbHelper.CreateParameter("in_alternative_mobile",   Convert.ToInt64(dto.alternative_mobile)),
                               DbHelper.CreateParameter("in_gender_id",  dto.gender_id),
                               DbHelper.CreateParameter("in_image_url",  dto.image_url),
     };
                foreach (var item in dbParams)
                {
                    invalue.Add(item.ParameterName + ':' + item.Value);
                }
                dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);
              
                dto.procedure_name = "call sp_update_customer_profile(:in_customer_id,:in_user_id,:in_first_name,:in_second_name,:in_email,:in_mobile,:in_address,:in_city,   :in_state_id,:in_country_id,:in_pincode,:in_dob,:in_alternative_mobile,:in_gender_id,:in_image_url)";
                    status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);


                    if (status == -1)
                    {
                        dto.status = "Insert";
                        dto.messageflg = "Profile Updated Successfully";
                    }
                    else
                    {
                    dto.status = "Failed";
                    dto.messageflg = "Update Failed, Please Try Again";
                    }

            }
            return dto;
        }

     
    }
}