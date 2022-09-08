using EMarket.BLL.Comman_Class;
using EMarket.BLL.Interfaces.Customer;
using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarketDTO.Customer;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.BLL.EMarket_Service.Customer
{
    public class Customer_Profile_Service : ICustomer_Profile_Service
    {
        ICustomer_Profile_Repository _inter;
        int status = 0;
        PostgreSqlContext _context;
        ISql_Layer _sql;
        IError_Log _error;
        ValidationClass _valid = new ValidationClass();
        Db_Connection conn = new Db_Connection();
        public Customer_Profile_Service(PostgreSqlContext context, ISql_Layer sql, IError_Log error, ICustomer_Profile_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public Customer_ProfileDTO Get_Customer_Details(Customer_ProfileDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Profile_Service/Get_Customer_Details";
            var dbParams0 = new DbParameter[] { };

            var customerlist = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
            if (customerlist.Count > 0)
            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;
            }
            else
            {
                return dto;
            }


            try
            {
                // gender
                var dbParams = new DbParameter[]
                {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                };
                dbParams0 = dbParams;
                dto.procedure_name = "fn_gender";
                dto.genderlist = _sql.Get_Data(dto.procedure_name, dbParams);


                //get customer
                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("ccustomer_id", dto.customer_id),
                     };
                dbParams0 = dbParams1;
                dto.procedure_name = "fn_get_customer_profile";
                dto.customerlist = _sql.Get_Data(dto.procedure_name, dbParams1);


                //get country
                var dbParams2 = new DbParameter[]
                     {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                      };
                dbParams0 = dbParams2;
                dto.procedure_name = "fn_country";
                dto.countrylist = _sql.Get_Data(dto.procedure_name, dbParams2);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dbParams0);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }

            return dto;
        }
        public Customer_ProfileDTO Upadate_Customer_Details(Customer_ProfileDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            bool nama;
            List<string> ret_validation = new List<string>();
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Profile_Service/Upadate_Customer_Details";
            var Params = new DbParameter[] { };

            if (dto.first_name.Trim() == "" || dto.first_name.Trim() == null)
            {
                ret_validation.Add("Please Enter First Name");
            }
            if (dto.first_name.Trim().Length < 5 && dto.first_name.Trim() != "" && dto.first_name.Trim() != null)
            {
                ret_validation.Add("First Name  Min 3 Character");
            }
            if (dto.first_name.Trim().Length > 40 && dto.first_name.Trim() != "" && dto.first_name.Trim() != null)
            {
                ret_validation.Add("First Name  Max 40 Character");
            }
            if(dto.first_name.Trim() != "" && dto.first_name.Trim() != null)
            {
                nama = Regex.IsMatch(dto.first_name, @"^[a-zA-Z]+$");
                if (nama == false)
                {
                    ret_validation.Add("Please Enter Valid First Name");
                }
            }

            if (dto.second_name == "" || dto.second_name == null)
            {
                ret_validation.Add("Please Enter Second Name");

            }

            if (dto.second_name != "")
            {
               
                if (dto.second_name.Length > 40)
                {
                    ret_validation.Add("Second Name  Max 40 Character");
                }
                nama = Regex.IsMatch(dto.second_name, @"^[a-zA-Z]+$");
                if (nama == false)
                {
                    ret_validation.Add("Please Enter Valid Second Name");
                }
            }

            if (dto.email == "" || dto.email == null)
            {
                ret_validation.Add("Please Enter Email");

            }

            var eml = _valid.Is_Valid_Email(dto.email);
            if (eml == false)
            {
                ret_validation.Add("Please Enter Valid Email");

            }

            if (dto.mobile == 0 || dto.mobile == null)
            {
                ret_validation.Add("Please Enter Mobile Number");
            }
            var mob = _valid.Is_Valid_Mobile(dto.mobile);
            if (mob == false)
            {
                ret_validation.Add("Please Enter Valid Mobile Number");
            }
            if (dto.mobile.ToString().Length < 10)
            {
                ret_validation.Add("Please Enter 10 Digit Mobile Number");
            }


            if (dto.address.Trim() == "" || dto.address.Trim() == null)
            {
                ret_validation.Add("Please Enter Address");
            }
            if (dto.address.Trim().Length < 10)
            {
                ret_validation.Add("Address Min 10 Character");
            }
            string adressRegex = @"[0-9\\\/# ,a-zA-Z]+[ ,]+[0-9\\\/#, a-zA-Z]{1,}";
            Regex address = new Regex(adressRegex);
            if (!address.IsMatch(dto.address.ToString()))
            {
                ret_validation.Add("Please Enter Valid Address");
            }

            if (dto.city == "" || dto.city == null)
            {
                ret_validation.Add("Please Enter City");
            }
            if (dto.city.Length < 3)
            {
                ret_validation.Add("City Min 3 Character");
            }

            if (dto.pincode == 0 || dto.pincode == null)
            {
                ret_validation.Add("Please Enter Pincode");
            }
            if (dto.pincode.ToString().Length < 6)
            {
                ret_validation.Add("Please Enter 6 Digit Pincode");
            }
           
            if (dto.dob == null)
            {
                ret_validation.Add("Please Enter DOB");
            }
            //if (dto.alternative_mobile == 0 || dto.alternative_mobile == null)
            //{
            //    ret_validation.Add("Please Enter Alternative Mobile");
            //}
            //if (dto.alternative_mobile.ToString().Length < 10)
            //{
            //    ret_validation.Add("Please Enter 10 Digit Alternative Mobile Number");
            //}
            var mob1 = _valid.Is_Valid_Mobile(dto.mobile);
            if (mob1 == false)
            {
                ret_validation.Add("Please Enter Valid Alternative Mobile Number");
            }
            if (dto.mobile.ToString().Length < 10)
            {
                ret_validation.Add("Please Enter 10 Digit Alternative Mobile Number");
            }

            if (dto.gender_id == 0 || dto.gender_id == null)
            {
                ret_validation.Add("Please Select Gender");
            }
            var gend = _context.Master_Gender_con.Where(a => a.mg_id == dto.gender_id).ToList();
            if (gend.Count == 0)
            {
                ret_validation.Add("Please Select Valid Gender");
            }
           
            if (dto.country_id==0)
            {
                ret_validation.Add("Please Select Country");
            }
            var count = _context.Master_CountryDMO_con.Where(a => a.country_id == dto.country_id).ToList();
            if(count.Count==0)
            {
                ret_validation.Add("Please Select Valid Country");
            }           

            if (dto.state_id == 0)
            {
                ret_validation.Add("Please Select State");
            }
            var count1 = _context.Master_CountryDMO_con.Where(a => a.country_id == dto.country_id).ToList();
            if (count1.Count == 0)
            {
                ret_validation.Add("Please Select Valid State");
            }
            
            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }

            var customerlist = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
            if (customerlist.Count > 0)
            {
                var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                dto.customer_id = customer.customer_id;
            }

            try
            {

                _inter.Upadate_Customer_Details(dto);
            }
            catch (Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }


            return dto;
        }
        public Customer_ProfileDTO getstate(Customer_ProfileDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Profile_Service/getstate";
            if (dto.country_id == 0 || dto.country_id == null)
            {
                dto.statusflg = false;
                dto.messageflg = "Please Select Country";
                return dto;
            }
            try
            {
                var customerlist = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).ToList();
                if (customerlist.Count > 0)
                {
                    var customer = _context.Customer_Profile_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                    dto.customer_id = customer.customer_id;
                }

                var dbParams = new DbParameter[]
            {
                      DbHelper.CreateParameter("languageid", dto.language_id),
                      DbHelper.CreateParameter("countryid", Convert.ToInt64(dto.country_id))
             };
                Params = dbParams;
                dto.procedure_name = "fn_getstate";
                dto.statelist = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
            return dto;
        }

    }
}
