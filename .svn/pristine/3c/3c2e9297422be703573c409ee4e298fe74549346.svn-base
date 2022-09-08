using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Customer;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarketDTO.Customer;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.BLL.EMarket_Service.Customer
{
    public class Customer_Address_Service: ICustomer_Address_Service
    {
        ICustomer_Address_Repository _inter;
       
        PostgreSqlContext _context;
        Db_Connection conn = new Db_Connection();
        ISqlClass _sql;
        IErrorClass _error;

        public Customer_Address_Service(PostgreSqlContext context, ISqlClass sql, IErrorClass error, ICustomer_Address_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public Customer_AddressDTO Get_Customer_Address(Customer_AddressDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Address_Service/Get_Customer_Address";

            try
            {
                // addresslist
                var dbParams = new DbParameter[]
                 {
                      DbHelper.CreateParameter("cuser_id", dto.user_id)                     
                 };
                Params = dbParams;
                dto.procedure_name = "fn_addresslist";
                dto.addresslist = _sql.fn_get_list(dto.procedure_name, dbParams);

                // get state
                var dbParams1 = new DbParameter[]
                 {
                      DbHelper.CreateParameter("languageid", dto.language_id),
                      DbHelper.CreateParameter("countryid", dto.country_id)
                 };
                Params = dbParams1;
                dto.procedure_name = "fn_getstate";
                dto.statelist = _sql.fn_get_list(dto.procedure_name, dbParams1);

                // get country
                var dbParams2 = new DbParameter[]
                 {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                     
                 };
                Params = dbParams2;
                dto.procedure_name = "fn_country";
                dto.countrylist = _sql.fn_get_list(dto.procedure_name, dbParams2);
          
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Customer_AddressDTO Upadate_Customer_Address(Customer_AddressDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Address_Service/Upadate_Customer_Address";

            if (dto.customer_name != null)
            {
                string fnameRegex = @"^[a-zA-Z\s]+$";
                Regex mre = new Regex(fnameRegex);
                if (!mre.IsMatch(dto.customer_name.ToString()))
                {
                    dto.messageflg = "Please Enter Valid  Name";
                    return dto;
                }
            }
            else
            {
                dto.messageflg = "Please Enter Name";
                return dto;
            }
            if (dto.pincode != 0)
            {
                string pincodeRegex = @"^[1-9]{1}[0-9]{2}\s{0,1}[0-9]{3}$";
                Regex mre = new Regex(pincodeRegex);
                if (!mre.IsMatch(dto.pincode.ToString()))
                {
                    dto.messageflg = "Please Enter Valid Pincode";
                    return dto;
                }
            }
            else
            {
                dto.messageflg = "Please Enter Pincode";
                return dto;
            }
            if (dto.mobile != 0)
            {
                string mobileRegex = @"^[6789]{1}[0-9]{9}$";
                Regex mre = new Regex(mobileRegex);
                if (!mre.IsMatch(dto.mobile.ToString()))
                {
                    dto.messageflg = "Please Enter Valid Mobile";
                    return dto;
                }
            }
            else
            {
                dto.messageflg = "Please Enter Mobile";
                return dto;
            }
            if (dto.email_id != null)
            {
                string mailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
                Regex mre = new Regex(mailRegex);
                if (!mre.IsMatch(dto.email_id.ToString()))
                {
                    dto.messageflg = "Please Enter Valid Email";
                    return dto;
                }
            }
            else
            {
                dto.messageflg = "Please Enter Email";
                return dto;
            }
            try
            {
                _inter.Upadate_Customer_Address(dto);
            }
            catch(Exception ex)
            {
                _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, page_form);
            }
            finally
            {
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
            return dto;
        }
        public Customer_AddressDTO get_address(Customer_AddressDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Address_Service/get_address";

            try
            {
                // addresslist
                var dbParams = new DbParameter[]
                 {
                      DbHelper.CreateParameter("cuser_id", dto.user_id),
                      DbHelper.CreateParameter("caddress_id", dto.address_id)
                 };
                Params = dbParams;
                dto.procedure_name = "fn_addresslist";
                dto.addresslist = _sql.fn_get_list(dto.procedure_name, dbParams);

            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }
        public Customer_AddressDTO getstate(Customer_AddressDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Customer_Address_Service/get_address";

            try
            {
                var dbParams = new DbParameter[]
                {
                      DbHelper.CreateParameter("languageid", dto.language_id),
                      DbHelper.CreateParameter("countryid", Convert.ToInt64(dto.country_id))
                };
                Params = dbParams;
                dto.procedure_name = "fn_getstate";
                dto.statelist = _sql.fn_get_list(dto.procedure_name, dbParams);

              
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            finally
            {

            }
            return dto;
        }
    }
}
