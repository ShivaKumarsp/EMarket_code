using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Text;


namespace EMarket.DLL.Comman_Data.Comman_Repository
{
    public class Error_Log : IError_Log
    {
        int status = 0;
        comman_class cmm = new comman_class();

        public readonly string ConnectionString = string.Empty;

        public string _ConnectionString { get => ConnectionString; }
        public Error_Log()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            ConnectionString = root.GetSection("ConnectionStrings").GetSection("PostgreSql1").Value;

        }

        public void errorlog(Exception ex, long userid, string methodname, string ipAddress, string apitype, string page_form, string pname, params DbParameter[] dbParams1)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            List<string> inputvalue = new List<string>();
            foreach (var item in dbParams1)
            {
                inputvalue.Add(item.ParameterName + ':' + item.Value);
            }
            var invalue = Newtonsoft.Json.JsonConvert.SerializeObject(inputvalue);

            try
            {
                var dbParams = new DbParameter[]
             {
                DbHelper.CreateParameter("in_user_id", userid),
                DbHelper.CreateParameter("in_page_name", methodname),
                DbHelper.CreateParameter("in_error_message", ex.Message),
                DbHelper.CreateParameter("in_inner_exception", ex.InnerException),
                DbHelper.CreateParameter("in_page_form", page_form),
                DbHelper.CreateParameter("in_device_details", ""),
                DbHelper.CreateParameter("in_ip_address", ipAddress),
                DbHelper.CreateParameter("in_browser_type", apitype),
                DbHelper.CreateParameter("in_jwt", ""),
                DbHelper.CreateParameter("in_error_code", ex.HResult.ToString()),
                DbHelper.CreateParameter("in_pname", pname),
                DbHelper.CreateParameter("in_inputvalue", invalue),

             };
                var spName = "call sp_error_log(:in_user_id, :in_page_name,:in_error_message,:in_inner_exception,:in_page_form,:in_device_details,:in_ip_address,:in_browser_type,:in_jwt,:in_error_code,:in_pname,:in_inputvalue)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);


            }
            catch (Exception ex1)
            {

            }


        }
        public void errorlog_add(Exception ex, long userid, string methodname, string ipAddress, string apitype, string page_form, string pname, string inputvalue)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);           

            try
            {
                var dbParams = new DbParameter[]
             {
                DbHelper.CreateParameter("in_user_id", userid),
                DbHelper.CreateParameter("in_page_name", methodname),
                DbHelper.CreateParameter("in_error_message", ex.Message),
                DbHelper.CreateParameter("in_inner_exception", ex.InnerException),
                DbHelper.CreateParameter("in_page_form", page_form),
                DbHelper.CreateParameter("in_device_details", ""),
                DbHelper.CreateParameter("in_ip_address", ipAddress),
                DbHelper.CreateParameter("in_browser_type", apitype),
                DbHelper.CreateParameter("in_jwt", ""),
                DbHelper.CreateParameter("in_error_code", ex.HResult.ToString()),
                DbHelper.CreateParameter("in_pname", pname),
                DbHelper.CreateParameter("in_inputvalue", inputvalue),

             };
                var spName = "call sp_error_log(:in_user_id, :in_page_name,:in_error_message,:in_inner_exception,:in_page_form,:in_device_details,:in_ip_address,:in_browser_type,:in_jwt,:in_error_code,:in_pname,:in_inputvalue)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);


            }
            catch (Exception ex1)
            {

            }


        }

        public void errorlog1(Exception ex, long userid)
        {

            string hostName = Dns.GetHostName();
            var ip_list = Dns.GetHostAddressesAsync(hostName).Result[1].ToString();
            string myIP1 = "";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var dbParams = new DbParameter[]
            {
                    DbHelper.CreateParameter("in_user_id", userid),
                    DbHelper.CreateParameter("in_page_name", ""),
                    DbHelper.CreateParameter("in_error_message", ex.Message),
                    DbHelper.CreateParameter("in_device_details", ""),
                    DbHelper.CreateParameter("in_ip_address", myIP1),
                    DbHelper.CreateParameter("in_browser_type", "Web")
                 };

            var spName = "call sp_error_log(:in_user_id, :in_page_name,:in_error_message,:in_device_details,:in_ip_address,:in_browser_type)";
            status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
           

            //using (var cn = new NpgsqlConnection(cmm.ConnectionString))
            //{

            //    bool saved = false;
            //    NpgsqlCommand cmd = new NpgsqlCommand("call sp_error_log(:in_user_id, :in_page_name,:in_error_message,:in_device_details,:in_ip_address,:in_browser_type)", cn);

            //    cmd.Parameters.AddWithValue("in_user_id", DbType.Int64).Value = userid;
            //    cmd.Parameters.AddWithValue("in_page_name", DbType.String).Value = "";
            //    cmd.Parameters.AddWithValue("in_error_message", DbType.String).Value = ex.Message;
            //    cmd.Parameters.AddWithValue("in_device_details", DbType.String).Value = "";
            //    cmd.Parameters.AddWithValue("in_ip_address", DbType.String).Value = myIP1;
            //    cmd.Parameters.AddWithValue("in_browser_type", DbType.String).Value = "Web";
            //    //  cmd.Parameters.AddWithValue("in_browser_id", DbType.String).Value = sMacAddress;

            //    cmd.CommandType = CommandType.Text;
            //    cn.Open();
            //    var affectcount = cmd.ExecuteNonQuery();
            //    cn.Close();
            //    saved = affectcount == 1;
            //}
        }

        public void audit_log(long userid, string ipAddress, string apitype, string token)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var Params = new DbParameter[] { };
            try
            {
                var dbParams = new DbParameter[]
             {
                DbHelper.CreateParameter("in_user_id", userid),
                DbHelper.CreateParameter("in_ipaddress", ipAddress),
                DbHelper.CreateParameter("in_api_type", apitype),
                DbHelper.CreateParameter("in_token", token)
             };
                var spName = "call sp_save_audit_log(:in_user_id, :in_ipaddress,:in_api_type,:in_token)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);


            }
            catch (Exception ex)
            {

                string methodname1 = "Error_Log/audit_log";
                errorlog(ex, userid, methodname1, ipAddress, apitype, "call sp_save_audit_log", "call sp_save_audit_log", Params);
            }


        }
        public void audit_log_txr(long userid, string methodname, string page_form)
        {
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            string methodname1 = "Error_Log/audit_log_txr";
            try
            {
                var dbParams = new DbParameter[]
             {
                DbHelper.CreateParameter("in_user_id", userid),
                DbHelper.CreateParameter("in_mathod_details", methodname),
                DbHelper.CreateParameter("in_form_details", page_form)

             };
                var spName = "call sp_save_audit_log_txr(:in_user_id, :in_mathod_details,:in_form_details)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);


            }
            catch (Exception ex)
            {
                errorlog(ex, userid, methodname1, "", "", "sp_save_audit_log_txr", "sp_save_audit_log_txr", Params);
            }


        }
        public void audit_log_txr_logout(long userid, string methodname, string page_form)
        {
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            string methodname1 = "Error_Log/audit_log_txr_logout";
            try
            {
                var dbParams = new DbParameter[]
             {
                DbHelper.CreateParameter("in_user_id", userid),
                DbHelper.CreateParameter("in_mathod_details", methodname),
                DbHelper.CreateParameter("in_form_details", page_form)

             };
                Params = dbParams;
                var spName = "call sp_save_audit_log_txr_logout(:in_user_id, :in_mathod_details,:in_form_details)";
                status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);


            }
            catch (Exception ex)
            {
                errorlog(ex, userid, methodname1, "", "", "sp_save_audit_log_txr", "sp_save_audit_log_txr", Params);
            }


        }
               

    }
}
