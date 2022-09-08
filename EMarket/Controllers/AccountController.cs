using AutoMapper;
using DBHelpers;
using EMarket.BLL;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Customer;

using EMarket.Data;
using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.Entities;
using EMarket.Entities.Admin;
using EMarket.Entities.Entities;
using EMarket.Entities.LoginContext;
using EMarket.Entities.Models;
using EMarket.Helper;
using EMarket.Models;
using EMarket.Service;
using EMarketDTO.CommanDTO;
using EMarketDTO.Customer;
using EMarketDTO.LoginDTO;
using EMarketDTO.Master;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : APIBaseController
    {

       

        //IDbHelper _dbHelper = new NpgsqlHelper("Host=192.168.1.31;Port=5432;User ID=shivakumar;Password=Avani@002;Database=EMarket_v2;Pooling=true;");

        //DBHelper dbHelper = new SqlHelper("MyCN");
        int status = 0;
        ISqlClass _sql;
        IErrorClass _error;
        //private readonly ILanding_Service _intr;
        comman_class cmm = new comman_class();

        IComman_Data _business;
        ActionExecutingContext filterContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
      
        private readonly IAdminService _adminService;
        
        private readonly IAntiforgery _antiForgeryService;
        private IConfiguration _configuration;
        private JWTConfig _jWTConfig;
        private readonly IMapper _mapper;
        private PostgreSqlContext _serviceScope;
       // IAudit_Log _audit;
        public AccountController(UserManager<ApplicationUser> userManager, IAdminService adminService, SignInManager<ApplicationUser> signInManager,
             RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, JWTConfig jWTConfig, IMapper mapper, PostgreSqlContext serviceScope, IAntiforgery antiForgeryService, ISqlClass sql, IErrorClass error, IComman_Data business) 
        {
            _userManager = userManager; _signInManager = signInManager; _configuration = configuration; _jWTConfig = jWTConfig;
            _roleManager = roleManager;
            _mapper = mapper;
          
            _adminService = adminService;
        
            _serviceScope = serviceScope;
            _antiForgeryService = antiForgeryService;
            _sql = sql;
            _error = error;
            _business = business;
           //  _intr = intr;


        }

        //private void GetIpValue(out string ipAdd)
        //{
        //    ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //    if (string.IsNullOrEmpty(ipAdd))
        //    {
        //        ipAdd = Request.ServerVariables["REMOTE_ADDR"];
        //    }
        //    else
        //    {
        //        lblIPAddress.Text = ipAdd;
        //    }
        //}

       


        [HttpPost("CheckAvailable")]
        [AllowAnonymous]
        public async Task<UserLoginDto> CheckAvailable([FromBody] UserLoginDto dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "AccountController/CheckAvailable";
            var Params = new DbParameter[] { };
            try
            {
                if (dto != null && !string.IsNullOrEmpty(dto.Email) && !string.IsNullOrEmpty(dto.UserName))
                {
                    var rollist = _serviceScope.Application_Role_con.Where(a => a.role_name == dto.role).ToList();
                    if (rollist.Count == 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Somthing Wrong, Please Try Again";
                        return dto;
                    }
                    var usercheck = _serviceScope.Application_User_con.Where(a => a.username == dto.UserName && a.role_id==rollist[0].role_id).ToList();
                    if (usercheck.Count >0)
                    {
                        dto.status = "Failed";
                        dto.message = "User Name Already Exist. Please Enter Another Username";
                        return dto;
                    }

                    dto.UserName = dto.UserName;
                    dto.Password = dto.Password;

                    var existingEmail = _serviceScope.Application_User_con.Where(a => a.email == dto.Email && a.role_id == rollist[0].role_id).ToList();
                    if (existingEmail.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Email Id Already Exist, Please Try With Another Email Id";
                        return dto;
                    }
                    if(dto.role=="Vendor")
                    {
                        var _existingEmail = _serviceScope.Vendor_Profile_con.Where(a => a.vendor_email == dto.Email).ToList();
                        if (_existingEmail.Count > 0)
                        {
                            dto.status = "Failed";
                            dto.message = "Email Id Already Exist, Please Try With Another Email Id";
                            return dto;
                        }
                        var _existingrMobile = _serviceScope.Vendor_Profile_con.Where(a => a.vendor_mobile == Convert.ToInt64(dto.mobile)).ToList();
                        if (_existingrMobile.Count > 0)
                        {
                            dto.status = "Failed";
                            dto.message = "Mobile Number Already Exist, Please Try With Another Mobile Number";
                            return dto;
                        }
                    }

                    if (dto.role == "Customer")
                    {
                        var _existingEmail = _serviceScope.Customer_Profile_con.Where(a => a.email == dto.Email).ToList();
                        if (_existingEmail.Count > 0)
                        {
                            dto.status = "Failed";
                            dto.message = "Email Id Already Exist, Please Try With Another Email Id";
                            return dto;
                        }
                        var _existingrMobile = _serviceScope.Customer_Profile_con.Where(a => a.mobile == Convert.ToInt64(dto.mobile)).ToList();
                        if (_existingrMobile.Count > 0)
                        {
                            dto.status = "Failed";
                            dto.message = "Mobile Number Already Exist, Please Try With Another Mobile Number";
                            return dto;
                        }
                    }




                    if (dto.Email != "" || dto.Email != null)
                    {
                        string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                 @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                        Regex ere = new Regex(emailRegex);
                        if (!ere.IsMatch(dto.Email))
                        {
                            dto.status = "Failed";
                            dto.message = "Please Enter Valid Email";
                            return dto;
                        }
                    }

                    var existingmob = _serviceScope.Application_User_con.Where(a => a.phonenumber == dto.mobile && a.role_id == rollist[0].role_id).ToList();
                    if (existingmob.Count != 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Mobile Already Exist..";
                        return dto;
                    }
                    else if (dto.mobile == "9999999999" || dto.mobile == "8888888888" || dto.mobile == "7777777777" || dto.mobile == "6666666666")
                    {
                        dto.status = "Failed";
                        dto.message = "Please Enter Valid Mobile Number";
                        return dto;
                    }                    
                        string mobileRegex = @"^[6-9]{1}[0-9]{9}$";
                        Regex mre = new Regex(mobileRegex);
                        if (!mre.IsMatch(dto.mobile.ToString()))
                        {
                            dto.status = "Failed";
                            dto.message = "Please Enter Valid Mobile Number";
                            return dto;
                        } 
                    else
                    {
                        string num = cmm.generatelinkid();
                        dto.reg_otp = Convert.ToInt32(num);
                        cmm.sendOTPMSG(dto.mobile, num);
                        dto.email_return = dto.Email;
                        dto.status = "Success";
                    }
                }
                else
                {
                    dto.message = "Failed";
                }
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, 0, methodname, dto.ipAddress, dto.apitype, page_form, "Checkusername", Params);
            }
            return dto;
        }

        [HttpPost("Register")]
        [Authorize]
        [AllowAnonymous]
        public async Task<APIResponse<string>> Register(UserDto dto)
        {
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, INDIAN_ZONE);
            try
            {
            
                //21042022
                if (dto.Email != "" || dto.Email != null)
                {
                    string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    Regex ere = new Regex(emailRegex);
                    if (!ere.IsMatch(dto.Email))
                    {

                        return PrepareErrorResponse("Error", new Exception("Please Enter Valid Email Id"));
                    }

                }
                else
                {
                    return PrepareErrorResponse("Error", new Exception("Please Enter Email Id"));
                }

                if (dto.PhoneNumber == "9999999999" || dto.PhoneNumber == "8888888888" || dto.PhoneNumber == "7777777777" || dto.PhoneNumber == "6666666666")
                {
                    return PrepareErrorResponse("Error", new Exception("Please Enter Valid Mobile Number"));

                }
                if (dto.PhoneNumber != "" || dto.PhoneNumber != null)
                {
                    string mobileRegex = @"^[6-9]{1}[0-9]{9}$";
                    Regex mre = new Regex(mobileRegex);
                    if (!mre.IsMatch(dto.PhoneNumber.ToString()))
                    {
                        return PrepareErrorResponse("Error", new Exception("Please Enter Valid Mobile Number"));
                    }
                }
                else
                {
                    return PrepareErrorResponse("Error", new Exception("Please Enter Mobile Number"));
                }

                //

                //&& !string.IsNullOrEmpty(user.ConfirmPassword)
                if (dto != null && !string.IsNullOrEmpty(dto.Email) && !string.IsNullOrEmpty(dto.UserName) && !string.IsNullOrEmpty(dto.PhoneNumber) && !string.IsNullOrEmpty(dto.Password))
                {
                    var role = _serviceScope.Application_Role_con.Where(a => a.role_name == dto.Role).FirstOrDefault();

                   // var pwd = Encrypt(dto.Password);
                    try
                    {
                        var dbParams = new DbParameter[]
                     {
                    DbHelper.CreateParameter("in_role", dto.Role),
                    DbHelper.CreateParameter("in_username", dto.UserName),
                    DbHelper.CreateParameter("in_email", dto.Email),
                    DbHelper.CreateParameter("in_phonenumber", dto.PhoneNumber),
                    DbHelper.CreateParameter("in_password", dto.Password),
                    DbHelper.CreateParameter("in_mob", Convert.ToInt64(dto.PhoneNumber))
                     };
                        Params = dbParams;
                        var spName = "call sp_registration(:in_role, :in_username,:in_email,:in_phonenumber,:in_password,:in_mob)";
                        status = _dbHelper.ExecuteNonQuery(spName, CommandType.Text, dbParams);
                        if (status == -1)
                        {
                            return PrepareSuccessResponse();
                        }

                    }
                    catch (Exception ex)
                    {
                        var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                        string methodname = "Account/Register";
                        _error.errorlog(ex, 0, methodname, dto.ipAddress, "Web", page_form, "sp_registration", Params);
                    }

                }
                else
                    return PrepareErrorResponse("Error", new Exception("Invalid request"));
            }
            catch (Exception ex)
            {
                var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                string methodname = "Account/Register";
                _error.errorlog(ex, 0, methodname, dto.ipAddress, "Web", page_form, "sp_registration", Params);
            }
            return PrepareSuccessResponse();
        }

        [HttpPost("login")]
        [Authorize]
        [AllowAnonymous]
        public async Task<APIResponse<UserInfoDto>> Login(UserLoginDto model)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            string methodname = "AccountController/Login";
            var Params = new DbParameter[] { };
            Boolean isvalid = false;
            UserInfoDto userInfoDto = new UserInfoDto();
            List<UserLoginDto> dtonewtemp1 = new List<UserLoginDto>();
            List<UserLoginDto> dtonewtemp2 = new List<UserLoginDto>();
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, INDIAN_ZONE);

            if (model.UserName == "" || model.UserName == null)
            {
                return PrepareErrorResponse(new UserInfoDto(), new Exception("Invalid request"));
            }
            var result = -1;
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            if (model.role == "Admin")
            {
                model.role = "SuperAdmin";
            }
            try
            {
                

                if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
                {
                    var _role = _serviceScope.Application_Role_con.Where(a => a.role_name == model.role).ToList();
                    
                   
                    dynamic _user = new ExpandoObject();
                    _user = _serviceScope.Application_User_con.Where(a => a.username == model.UserName && a.role_id==_role[0].role_id).ToList();
                  if(_user.Count==0)
                    {
                        _user = _serviceScope.Application_User_con.Where(a => a.email == model.UserName && a.role_id == _role[0].role_id).ToList();
                    }

                    if (_user.Count== 0)
                    {
                        _user = _serviceScope.Application_User_con.Where(a => a.phonenumber == model.UserName && a.role_id == _role[0].role_id).ToList();
                    }

                    if (_role[0].role_id != _user[0].role_id)
                    {
                        return PrepareErrorResponse(new UserInfoDto(), new Exception("Invalid Role"));
                    }
                
                    if (_user.Count > 0)
                    {
                        var tkn = _serviceScope.Salt_StoreDMO_con.Where(a => a.token == model.salt_token).FirstOrDefault();

                        isvalid = _business.VerifySaltPassword(model.Password, tkn.salt, _user[0].passwordhash);
                    }
                    else
                    {
                        return PrepareErrorResponse(new UserInfoDto(), new Exception("Invalid User Name"));
                    }

                   

                    if (isvalid == true)
                    {
                       

                        var pwd = model.Password; 
                            userInfoDto.Token = TokenManager.GetToken(model.role, _user[0].username.ToString(), _jWTConfig);
                            userInfoDto.roleid = _user[0].role_id;

                            Application_Login_LogDMO log = new Application_Login_LogDMO();
                            log.user_id = _user[0].user_id;
                            log.login_datetime = indianTime;
                            log.device_details = "";
                            log.ip_address = model.ipAddress;
                            log.login_status = "Active";
                            log.guid = Guid.NewGuid().ToString();
                            _serviceScope.Add(log);
                            _serviceScope.SaveChanges();
                            HttpContext.Session.SetInt32("logid", Convert.ToInt32(log.log_id));
                            userInfoDto.log_id = Convert.ToInt32(log.log_id);

                            userInfoDto.Role = model.role;
                            userInfoDto.UserId = _user[0].user_id;
                            model.audit_details = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                        // var json = new JavaScriptSerializer().Serialize(model);

                      

                        _error.audit_log(userInfoDto.UserId, model.ipAddress, model.apitype, userInfoDto.Token);

                        if (model.role == "Customer")
                        {
                            long uuserid = _user[0].user_id;
                            var customer = _serviceScope.Customer_Profile_con.Where(a => a.user_id == uuserid).SingleOrDefault();

                            var check = _serviceScope.Cart_List_con.Where(a => a.session_cart== model.session_cart).ToList();
                            if (check.Count > 0)
                            {
                                var dbParams = new DbParameter[]
                              {
                             DbHelper.CreateParameter("in_user_id", _user[0].user_id),
                             DbHelper.CreateParameter("in_customer_id", customer.customer_id),
                             DbHelper.CreateParameter("in_session_cart", model.session_cart),
                         
                              };

                                model.procedure_name = "call sp_delete_to_cart(:in_user_id,:in_customer_id,:in_session_cart)";
                                status = _dbHelper.ExecuteNonQuery(model.procedure_name, CommandType.Text, dbParams);


                                foreach (var item in check)
                                {
                                    var dbParams1 = new DbParameter[]
                               {
                             DbHelper.CreateParameter("in_user_id", _user[0].user_id),
                             DbHelper.CreateParameter("in_customer_id", customer.customer_id),
                             DbHelper.CreateParameter("in_session_cart", model.session_cart),
                              DbHelper.CreateParameter("in_item_id", item.item_id),
                             DbHelper.CreateParameter("in_cart_id", item.cart_id)
                               };

                                    model.procedure_name = "call sp_update_to_cart(:in_user_id,:in_customer_id,:in_session_cart,:in_item_id,:in_cart_id)";
                                    status = _dbHelper.ExecuteNonQuery(model.procedure_name, CommandType.Text, dbParams1);
                                }
                           
                              
                            }



                            var publiccheck = _serviceScope.Direct_CheckoutDMO_con.Where(a => a.session_cart == model.session_cart).ToList();
                            if (publiccheck.Count > 0)
                            {

                                foreach (var item in publiccheck)
                                {
                                    var dbParams2 = new DbParameter[]
                               {
                             DbHelper.CreateParameter("in_user_id", _user[0].user_id),
                             DbHelper.CreateParameter("in_customer_id", customer.customer_id),
                             DbHelper.CreateParameter("in_session_cart", model.session_cart),
                              DbHelper.CreateParameter("in_item_id", item.item_id),
                             DbHelper.CreateParameter("in_checkout_id", item.checkout_id)

                               };

                                    model.procedure_name = "call sp_update_to_publicdirect_cart(:in_user_id,:in_customer_id,:in_session_cart,:in_item_id,:in_checkout_id)";
                                    status = _dbHelper.ExecuteNonQuery(model.procedure_name, CommandType.Text, dbParams2);
                                }


                            }


                        }

                        if (model.role == "Vendor")
                        {
                            userInfoDto.is_vendor_doc = 0;
                            var vendor = _serviceScope.Vendor_Profile_con.Where(a => a.user_id == userInfoDto.UserId).FirstOrDefault();
                            userInfoDto.is_vendor_doc = vendor.is_verify;
                            userInfoDto.is_vendor_profile = vendor.approved_flg;
                        }

                        return PrepareSuccessRespnse(userInfoDto);

                    
                        
                    }
                    else
                    {
                        return PrepareErrorResponse(new UserInfoDto(), new Exception("Invalid Password"));
                    }
                }
                else
                    return PrepareErrorResponse(new UserInfoDto(), new Exception("Invalid request"));
            }
            catch (Exception ex)
            {
                Params = Params;
                _error.errorlog(ex, 0, methodname, model.ipAddress, "Web", page_form, "", Params);
                return PrepareErrorResponse(new UserInfoDto(), new Exception("Invalid request"));
            }
            finally
            {

            }
        }

        [HttpPost("login_with_otp")]
        [Authorize]
        [AllowAnonymous]
        public async Task<APIResponse<UserInfoDto>> login_with_otp(UserLoginDto model)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            string methodname = "AccountController/Login";
            var Params = new DbParameter[] { };
            Boolean isvalid = false;
            UserInfoDto userInfoDto = new UserInfoDto();
            List<UserLoginDto> dtonewtemp1 = new List<UserLoginDto>();
            List<UserLoginDto> dtonewtemp2 = new List<UserLoginDto>();
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, INDIAN_ZONE);

            if (model.UserName == "" || model.UserName == null)
            {
                return PrepareErrorResponse(new UserInfoDto(), new Exception("Invalid request"));
            }
            if (model.role == "Admin")
            {
                model.role = "SuperAdmin";
            }
            var _role = _serviceScope.Application_Role_con.Where(a => a.role_name == model.role).ToList();


            dynamic _user = new ExpandoObject();
            _user = _serviceScope.Application_User_con.Where(a => a.username == model.UserName && a.role_id == _role[0].role_id).ToList();
            if (_user.Count == 0)
            {
                _user = _serviceScope.Application_User_con.Where(a => a.email == model.UserName && a.role_id == _role[0].role_id).ToList();
            }

            if (_user.Count == 0)
            {
                _user = _serviceScope.Application_User_con.Where(a => a.phonenumber == model.UserName && a.role_id == _role[0].role_id).ToList();
            }

            if (_role[0].role_id != _user[0].role_id)
            {
                return PrepareErrorResponse(new UserInfoDto(), new Exception("Invalid Role"));
            }

            userInfoDto.Token = TokenManager.GetToken(model.role, _user[0].username.ToString(), _jWTConfig);
            userInfoDto.roleid = _user[0].role_id;

            Application_Login_LogDMO log = new Application_Login_LogDMO();
            log.user_id = _user[0].user_id;
            log.login_datetime = indianTime;
            log.device_details = "";
            log.ip_address = model.ipAddress;
            log.login_status = "Active";
            log.guid = Guid.NewGuid().ToString();
            _serviceScope.Add(log);
            _serviceScope.SaveChanges();
            HttpContext.Session.SetInt32("logid", Convert.ToInt32(log.log_id));
            userInfoDto.log_id = Convert.ToInt32(log.log_id);

            userInfoDto.Role = model.role;
            userInfoDto.UserId = _user[0].user_id;
            model.audit_details = Newtonsoft.Json.JsonConvert.SerializeObject(model);


            _error.audit_log(userInfoDto.UserId, model.ipAddress, model.apitype, userInfoDto.Token);
            if (model.role == "Vendor")
            {
                userInfoDto.is_vendor_doc = 0;
                var vendor = _serviceScope.Vendor_Profile_con.Where(a => a.user_id == userInfoDto.UserId).FirstOrDefault();
                userInfoDto.is_vendor_doc = vendor.is_verify;
                userInfoDto.is_vendor_profile = vendor.approved_flg;
            }

            if (model.role == "Customer")
            {
                long uuserid = _user[0].user_id;
                var customer = _serviceScope.Customer_Profile_con.Where(a => a.user_id == uuserid).SingleOrDefault();

                var check = _serviceScope.Cart_List_con.Where(a => a.session_cart == model.session_cart).ToList();
                if (check.Count > 0)
                {
                    var dbParams = new DbParameter[]
                  {
                             DbHelper.CreateParameter("in_user_id", _user[0].user_id),
                             DbHelper.CreateParameter("in_customer_id", customer.customer_id),
                             DbHelper.CreateParameter("in_session_cart", model.session_cart),

                  };

                    model.procedure_name = "call sp_delete_to_cart(:in_user_id,:in_customer_id,:in_session_cart)";
                    status = _dbHelper.ExecuteNonQuery(model.procedure_name, CommandType.Text, dbParams);


                    foreach (var item in check)
                    {
                        var dbParams1 = new DbParameter[]
                   {
                             DbHelper.CreateParameter("in_user_id", _user[0].user_id),
                             DbHelper.CreateParameter("in_customer_id", customer.customer_id),
                             DbHelper.CreateParameter("in_session_cart", model.session_cart),
                              DbHelper.CreateParameter("in_item_id", item.item_id),
                             DbHelper.CreateParameter("in_cart_id", item.cart_id)
                   };

                        model.procedure_name = "call sp_update_to_cart(:in_user_id,:in_customer_id,:in_session_cart,:in_item_id,:in_cart_id)";
                        status = _dbHelper.ExecuteNonQuery(model.procedure_name, CommandType.Text, dbParams1);
                    }


                }



                var publiccheck = _serviceScope.Direct_CheckoutDMO_con.Where(a => a.session_cart == model.session_cart).ToList();
                if (publiccheck.Count > 0)
                {

                    foreach (var item in publiccheck)
                    {
                        var dbParams2 = new DbParameter[]
                   {
                             DbHelper.CreateParameter("in_user_id", _user[0].user_id),
                             DbHelper.CreateParameter("in_customer_id", customer.customer_id),
                             DbHelper.CreateParameter("in_session_cart", model.session_cart),
                              DbHelper.CreateParameter("in_item_id", item.item_id),
                             DbHelper.CreateParameter("in_checkout_id", item.checkout_id)

                   };

                        model.procedure_name = "call sp_update_to_publicdirect_cart(:in_user_id,:in_customer_id,:in_session_cart,:in_item_id,:in_checkout_id)";
                        status = _dbHelper.ExecuteNonQuery(model.procedure_name, CommandType.Text, dbParams2);
                    }


                }


            }


            if (model.role == "Customer")
            {              
                var customer = _serviceScope.Customer_Profile_con.Where(a => a.user_id == userInfoDto.UserId).FirstOrDefault();
                userInfoDto.ret_username = customer.first_name + " " + customer.second_name;


            }

            return PrepareSuccessRespnse(userInfoDto);
        }

               
           

        [HttpPost("getmodule")]
        [AllowAnonymous]
        public Master_ModuleDTO Getmodule([FromHeader(Name = "userid")] string userid, [FromBody] Master_ModuleDTO dto)

        {
            dto.is_vendor_doc = 0;
           var Params = new DbParameter[] { };
            var ipv4 = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            string methodname = "Account/Getmodule";
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            if (userid != "null")
            {

                var username = _serviceScope.Application_User_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
                dto.userid = Convert.ToInt64(userid);
                IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
                dto.language_id = 1;
                var result1 = (from a in _serviceScope.Application_User_con
                               from b in _serviceScope.Application_Role_con
                               where a.role_id == b.role_id && a.user_id == dto.userid
                               select new Master_ModuleDTO
                               {
                                   rolename = b.role_name,
                                   roleid = a.role_id
                               }).FirstOrDefault();

                dto.roleid = result1.roleid;
                dto.role = result1.rolename;
                dto.get_token = TokenManager.GetToken(dto.role, username.username.ToString(), _jWTConfig);

                if (result1.rolename == "Admin")
                {
                    dto.roleid = 1;

                }
                else
                {
                    if (result1.rolename == "Customer")
                    {
                        var cus = _serviceScope.Customer_Profile_con.Where(a => a.user_id == dto.userid).ToList();
                        if (cus.Count > 0)
                        {
                            dto.cartlist = _serviceScope.Cart_List_con.Where(a => a.userid == dto.userid && a.customer_id == cus[0].customer_id).ToArray();
                        }
                        // category list
                        var dbParams = new DbParameter[]
                           {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                           };
                        Params = dbParams;
                        dto.procedure_name = "fn_get_nav_category";
                        dto.category_list = _sql.Get_Data(dto.procedure_name, dbParams);

                        // subcategory list
                        var dbParams1 = new DbParameter[]
                           {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                           };
                        Params = dbParams1;
                        dto.procedure_name = "fn_get_nav_subcategory";
                        dto.subcategory_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                        // addcategory list
                        var dbParams2 = new DbParameter[]
                           {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                           };
                        Params = dbParams2;
                        dto.procedure_name = "fn_get_nav_addcategory";
                        dto.addcategory_list = _sql.Get_Data(dto.procedure_name, dbParams2);


                    }

                }
            }

            else
            {
                dto.roleid = 6;
                dto.language_id = 1;

                dto.cartlist = _serviceScope.Cart_List_con.Where(a =>a.session_cart==dto.session_cart).ToArray();

                var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                   };
                Params = dbParams;
                dto.procedure_name = "fn_get_nav_category";
                dto.category_list = _sql.Get_Data(dto.procedure_name, dbParams);

                // subcategory list
                var dbParams1 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                   };
                Params = dbParams1;
                dto.procedure_name = "fn_get_nav_subcategory";
                dto.subcategory_list = _sql.Get_Data(dto.procedure_name, dbParams1);

                // addcategory list
                var dbParams2 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                   };
                Params = dbParams2;
                dto.procedure_name = "fn_get_nav_addcategory";
                dto.addcategory_list = _sql.Get_Data(dto.procedure_name, dbParams2);

            }
            try
            {
                if (dto.role != "Vendor")
                {
                    var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_roleid", dto.roleid),
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                   };
                    Params = dbParams;
                    dto.getmodulelist = _sql.fn_get_list("fn_get_module", dbParams);

                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_roleid", dto.roleid),
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                    };
                    Params = dbParams1;
                    dto.getpagelist = _sql.fn_get_list("fn_get_page", dbParams1);
                }
                else
                {
                    var vendor = _serviceScope.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
                    dto.is_vendor_doc = vendor.is_verify;
                    dto.is_vendor_profile = vendor.approved_flg;
                    var dbParams = new DbParameter[]
                 {
                      DbHelper.CreateParameter("in_roleid", dto.roleid),
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_user_id", dto.userid)
                 };
                    Params = dbParams;
                    dto.getmodulelist = _sql.fn_get_list("fn_get_module_vendor", dbParams);

                    var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_roleid", dto.roleid),
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                       DbHelper.CreateParameter("in_user_id", dto.userid)
                    };
                    Params = dbParams1;
                    dto.getpagelist = _sql.fn_get_list("fn_get_page_vendor", dbParams1);
                }
            }

            catch (Exception ex)
            {

                _error.errorlog(ex, 0, methodname, ipv4, "Web", page_form, "", Params);
            }

            finally
            {
                _error.audit_log_txr(dto.userid, methodname, page_form);
            }

            if(dto.role== "Vendor")
            {

            }
           else if (dto.role == "Delivery")
            {

            } 
            else if (dto.role == "HubManager")
            {
               // dto.user_details_list
            }
            else if (dto.role == "FacilitationCenter")
            {

            }
            return dto;
        }

        [Route("logout/{id:int}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<APIResponse<UserLoginDto>> logout([FromHeader(Name = "userid")] string userid, int id)
        {
            var Params = new DbParameter[] { };
            var ipv4 = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            UserLoginDto dto = new UserLoginDto();
            dto.userid = Convert.ToInt64(userid);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(id);
            string methodname = "Account/Logout";
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, INDIAN_ZONE);
            try
            {
                // dto.log_id = Convert.ToInt32(HttpContext.Session.GetInt32("logid"));
                dto.log_id = id;
                var result = _serviceScope.Application_Login_Log_con.Where(a => a.log_id == dto.log_id).SingleOrDefault();
                result.log_out_time = indianTime;
                result.login_status = "LogOut";
                _serviceScope.Update(result);
                _serviceScope.SaveChanges();
            }

            catch (Exception ex)
            {
                _error.errorlog(ex, 0, methodname, ipv4, "Web", page_form, "", Params);
            }
            finally

            {
                _error.audit_log_txr_logout(dto.userid, methodname, page_form);
            }


            return PrepareSuccessRespnse(dto);

        }

        [Route("set_salt/{id:int}")]
        [AllowAnonymous]
        public async Task<APIResponse<UserLoginDto>> set_salt(int id)
        {
            var Params = new DbParameter[]{ };
            UserLoginDto dto = new UserLoginDto();
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, INDIAN_ZONE);
            var ipv4 = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            try
            {
                var salt_md5 = _business.CreateSalt(5);
                dto.salt = _business.GetMD5(salt_md5);
                dto.salt_token = TokenManager.GetToken("Salt", dto.salt, _jWTConfig);
                Salt_StoreDMO dmo = new Salt_StoreDMO();
                dmo.salt = dto.salt;
                dmo.token = dto.salt_token;
                dmo.create_on = indianTime;
                _serviceScope.Add(dmo);
                _serviceScope.SaveChanges();
            }
            catch (Exception ex)
            {
                var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                string methodname = "Account/get_salt";
                _error.errorlog(ex, 0, methodname, ipv4, "Web", page_form, "", Params);
            }
            return PrepareSuccessRespnse(dto);

        }

        [HttpPost("resend_otp")]
        [AllowAnonymous]
        public async Task<UserLoginDto> resend_otp([FromBody] UserLoginDto dto)
        {
            try
            {
                if (!string.IsNullOrEmpty(dto.UserName))
                {
                    if (dto.role == "Admin")
                    {
                        dto.role = "SuperAdmin";
                    }

                    var rollist = _serviceScope.Application_Role_con.Where(a => a.role_name == dto.role).ToList();
                    if (rollist.Count == 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Somthing Wrong, Please Try Again";
                        return dto;
                    }

                    dto.UserName = dto.UserName;
                  
                    var existingUser = _serviceScope.Application_User_con.Where(a => a.username == dto.UserName || a.email==dto.UserName || a.phonenumber==dto.UserName && a.role_id==rollist[0].role_id).ToList();
                    if (existingUser.Count == 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Please Enter Valied User Name";
                        return dto;
                    }

                    else
                    {
                        string num = cmm.generatelinkid();
                        dto.reg_otp = Convert.ToInt32(num);
                        cmm.sendOTPMSG(existingUser[0].phonenumber, num);
                        dto.email_return = existingUser[0].email;
                        dto.status = "Success";
                    }

                }
                else

                {
                    dto.message = "Invalied User Name";
                    dto.status = "Failed";
                }
            }
            catch (Exception ex)
            {

            }
            return dto;
        }

        [HttpPost("resend_registration_otp")]
        [AllowAnonymous]
        public async Task<UserLoginDto> resend_registration_otp([FromBody] UserLoginDto dto)
        {
            try
            {
                if (!string.IsNullOrEmpty(dto.UserName))
                {
                    if (dto.role == "Admin")
                    {
                        dto.role = "SuperAdmin";
                    }

                    var rollist = _serviceScope.Application_Role_con.Where(a => a.role_name == dto.role).ToList();
                    if (rollist.Count == 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Somthing Wrong, Please Try Again";
                        return dto;
                    }

                    dto.UserName = dto.UserName;

                   
                   
                        string num = cmm.generatelinkid();
                        dto.reg_otp = Convert.ToInt32(num);
                        cmm.sendOTPMSG(dto.mobile, num);
                        dto.email_return = dto.Email;
                        dto.status = "Success";
                    

                }
                else

                {
                    dto.message = "Invalied User Name";
                    dto.status = "Failed";
                }
            }
            catch (Exception ex)
            {

            }
            return dto;
        }



        [HttpPost("checkusername")]
        [AllowAnonymous]
        public async Task<UserLoginDto> checkusername([FromBody] UserLoginDto dto)
        {
            try
            {
                if (!string.IsNullOrEmpty(dto.UserName))
                {
                    dto.UserName = dto.UserName;
                    var rollist = _serviceScope.Application_Role_con.Where(a => a.role_name == dto.role).ToList();
                    if(rollist.Count==0)
                    {
                        dto.status = "Failed";
                        dto.message = "Somthing Wrong, Please Try Again";
                        return dto;
                    }

                    var existingUser = _serviceScope.Application_User_con.Where(a => a.username == dto.UserName || a.email == dto.UserName || a.phonenumber == dto.UserName && a.role_id== rollist[0].role_id).ToList();
                    if (existingUser.Count == 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Please Enter Valied User Name";
                        return dto;
                    }

                    else
                    {
                        string num = cmm.generatelinkid();
                        dto.reg_otp = Convert.ToInt32(num);
                        cmm.sendOTPMSG(existingUser[0].phonenumber, num);
                        dto.email_return = existingUser[0].email;
                        dto.status = "Success";
                    }

                }
                else

                {
                    dto.message = "Invalied User Name";
                    dto.status = "Failed";
                }
            }
            catch (Exception ex)
            {

            }
            return dto;
        }

        [HttpPost("changepassword")]
        [AllowAnonymous]
        public async Task<UserLoginDto> changepassword([FromBody] UserLoginDto dto)
        {
            try
            {
                var rollist = _serviceScope.Application_Role_con.Where(a => a.role_name == dto.role).ToList();
                if (rollist.Count == 0)
                {
                    dto.status = "Failed";
                    dto.message = "Somthing Wrong, Please Try Again";
                    return dto;
                }

                var result = _serviceScope.Application_User_con.Where(a => a.username == dto.UserName ||a.email==dto.UserName || a.phonenumber==dto.UserName && a.role_id== rollist[0].role_id).SingleOrDefault();
                result.passwordhash = dto.Password;
                _serviceScope.Update(result);
               var ss= _serviceScope.SaveChanges();
                if (ss>0)
                {
                    dto.message = "Password Successfully Changed";
                    dto.status = "Success";
                }
                else

                {
                    dto.message = "Invalied User Name";
                    dto.status = "Failed";
                }
            }
            catch (Exception ex)
            {

            }
            return dto;
        }

        //private async Task<bool> ValidateAntiForgeryToken()
        //{
        //    try
        //    {
        //        await _antiForgeryService.ValidateRequestAsync(this.HttpContext);
        //        return true;
        //    }
        //    catch (Microsoft.AspNetCore.Antiforgery.AntiforgeryValidationException)
        //    {
        //        return false;
        //    }
        //}

        //[HttpPost("sendotp")]
        //[AllowAnonymous]
        //public UserLoginDto sendotp(UserLoginDto dto)
        //{

        //    try
        //    {


        //        dto.UserName = Convert.ToString(HttpContext.Session.GetString("UserName"));
        //        dto.userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        //        dto.vendor_id = Convert.ToInt32(HttpContext.Session.GetInt32("vendorid"));
        //        dto.roleid = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
        //        dto.rolename = Convert.ToString(HttpContext.Session.GetString("RoleName"));

        //        string num = cmm.generatelinkid();
        //        dto.forget_pwd_otp = Convert.ToInt32(num);
        //        cmm.sendOTPMSG(dto.mobile, num);
        //        dto.email_return = dto.Email;
        //        dto.message = "Success";

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return dto;
        //}

        //[HttpPost("sendotpreg")]
        //[AllowAnonymous]
        //public UserLoginDto sendotpreg(UserLoginDto dto)
        //{

        //    try
        //    {
        //        dto.UserName = Convert.ToString(HttpContext.Session.GetString("UserName"));
        //        dto.userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        //        dto.vendor_id = Convert.ToInt32(HttpContext.Session.GetInt32("vendorid"));
        //        dto.roleid = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
        //        dto.rolename = Convert.ToString(HttpContext.Session.GetString("RoleName"));

        //        string num = cmm.generatelinkid();
        //        dto.reg_otp = Convert.ToInt32(num);
        //        cmm.sendOTPMSG(dto.mobile, num);
        //        dto.email_return = dto.Email;
        //        dto.message = "Success";

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return dto;
        //}



        //[HttpPost("changepassword")]
        //[AllowAnonymous]
        //public async Task<APIResponse<string>> changepassword(UserLoginDto dto)
        //{
        //    try
        //    {
        //        dto.UserName = Convert.ToString(HttpContext.Session.GetString("UserName"));
        //        dto.userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        //        dto.vendor_id = Convert.ToInt32(HttpContext.Session.GetInt32("vendorid"));
        //        dto.roleid = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
        //        dto.rolename = Convert.ToString(HttpContext.Session.GetString("RoleName"));



        //        var user = await _userManager.FindByEmailAsync(dto.Email);
        //        if (user == null)
        //            PrepareErrorResponse("Error", new Exception("Invalid request"));

        //        var dd = await _userManager.GeneratePasswordResetTokenAsync(user);

        //        var resetPassResult = await _userManager.ResetPasswordAsync(user, dd, dto.Password);
        //        if (!resetPassResult.Succeeded)
        //        {
        //            Dictionary<string, string> errors = new Dictionary<string, string>();
        //            foreach (var error in resetPassResult.Errors)
        //            {
        //                errors.Add(error.Code, error.Description);
        //            }
        //            return PrepareErrorResponse("Error", new Exception("An error occured"), errors);
        //        }
        //        return PrepareSuccessResponse();
        //    }
        //    catch (Exception ex)
        //    {
        //        return PrepareErrorResponse("Error", ex);
        //    }
        //}

        //[HttpGet("checkwish/{id:int}")]
        //[AllowAnonymous]
        //public UserLoginDto checkwish(int id)
        //{
        //    UserLoginDto dto = new UserLoginDto();
        //    try
        //    {
        //        HttpContext.Session.Remove("UserId");
        //        HttpContext.Session.Remove("UserName");
        //        HttpContext.Session.Remove("RoleId");
        //        HttpContext.Session.Remove("RoleName");
        //        HttpContext.Session.Remove("vendorid");
        //        HttpContext.Session.Remove("customerid");

        //        dto.UserName = Convert.ToString(HttpContext.Session.GetString("UserName"));
        //        dto.userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        //        dto.vendor_id = Convert.ToInt32(HttpContext.Session.GetInt32("vendorid"));
        //        dto.roleid = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
        //        dto.rolename = Convert.ToString(HttpContext.Session.GetString("RoleName"));


        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return dto;
        //}

        //[Route("clearsession/{id:int}")]
        //[AllowAnonymous]
        //public UserLoginDto clearsession(int id)
        //{
        //    UserLoginDto dto = new UserLoginDto();
        //    try
        //    {

        //        HttpContext.Session.Remove("UserId");
        //        HttpContext.Session.Remove("UserName");
        //        HttpContext.Session.Remove("RoleId");
        //        HttpContext.Session.Remove("RoleName");
        //        HttpContext.Session.Remove("vendorid");
        //        HttpContext.Session.Remove("customerid");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return dto;
        //}

        ////========== Login creation=====
        //[Route("getlogindata/{id:int}")]
        //[AllowAnonymous]
        //public AdminOrSupport_user_detailsDTO getlogindata(int id)
        //{
        //    AdminOrSupport_user_detailsDTO dto = new AdminOrSupport_user_detailsDTO();
        //    try
        //    {
        //        dto.all_login_list = (from a in _serviceScope.AspNetUserRole_con
        //                              from b in _serviceScope.AspNetRoles_con
        //                              from c in _serviceScope.AspNetUsers_con
        //                              from d in _serviceScope.Adminorsupport_user_details_con
        //                              where (a.RoleId == b.Id && a.UserId == c.Id && c.userid == d.userid)
        //                              select new AdminOrSupport_user_detailsDTO
        //                              {
        //                                  id = d.id,
        //                                  roleid = b.roleid,
        //                                  Role = b.Name,
        //                                  UserName = c.UserName,
        //                                  userid = c.userid,
        //                                  first_name = d.first_name,
        //                                  second_name = d.second_name,
        //                                  mobile = d.mobile,
        //                                  Email = d.email,
        //                                  address = d.address,
        //                                  pincode = d.pincode,
        //                                  aadhar_no = d.aadhar_no,
        //                                  gender = d.gender,
        //                                  dob = d.dob,
        //                                  alternative_mobile = d.alternative_mobile,
        //                                  Password = c.PasswordHash,
        //                              }).ToArray();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return dto;
        //}

        ////[HttpPost("check_avail")]
        ////[AllowAnonymous]
        ////public async Task<AdminOrSupport_user_detailsDTO> check_avail([FromBody] AdminOrSupport_user_detailsDTO dto)
        ////{
        ////    try
        ////    {

        ////        if (dto != null && !string.IsNullOrEmpty(dto.Email))
        ////        {

        ////            //user.Password = TokenManager.getPassword();
        ////            dto.UserName = dto.Email;


        ////            var existingUser = await _userManager.FindByEmailAsync(dto.UserName);
        ////            if (existingUser != null)
        ////            {
        ////                dto.user_available = 2;
        ////            }

        ////            else
        ////            {

        ////                dto.user_available = 1;
        ////            }

        ////        }
        ////        else

        ////        {
        ////            dto.message = "Failed";
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////       
        ////    }
        ////    return dto;
        ////}

        ////[HttpPost("create_login")]
        ////[AllowAnonymous]
        ////public async Task<APIResponse<string>> create_login(AdminOrSupport_user_detailsDTO user)
        ////{
        ////    try
        ////    {

        ////        if (user != null && !string.IsNullOrEmpty(user.Email))
        ////        {
        ////            user.CustomerCode = "";
        ////            //user.Password = TokenManager.getPassword();
        ////            user.UserName = user.Email;
        ////            user.Password = user.Password;
        ////            Startup.CustomerCode = user.CustomerCode;
        ////            var existingUser = await _userManager.FindByEmailAsync(user.UserName);
        ////            if (existingUser != null)
        ////                if (existingUser.CustomerCode == user.CustomerCode) return PrepareErrorResponse("Error", new Exception("User already exists"));

        ////            // Check user role is exist
        ////            var dbRoles = await _roleManager.FindByNameAsync(user.Role);
        ////            if (dbRoles == null)

        ////                return PrepareErrorResponse("Error", new Exception("User role not exists"));

        ////            //var userNew = new ApplicationUser { UserName = user.UserName, Email = user.Email, CustomerCode = user.CustomerCode };
        ////            var userNew = new ApplicationUser { UserName = user.UserName, Email = user.Email };
        ////            userNew.EmailConfirmed = true;
        ////            userNew.LockoutEnabled = false;
        ////            //userNew.Id = Guid.NewGuid().ToString();
        ////            // userNew.CustomerCode = user.CustomerCode;
        ////            userNew.PhoneNumber = user.PhoneNumber;
        ////            var result = await _userManager.CreateAsync(userNew, user.Password);
        ////            if (result.Succeeded)
        ////            {


        ////                // Add role to user
        ////                var userRoles = await _userManager.AddToRoleAsync(userNew, user.Role);

        ////                var rolid = _serviceScope.AspNetRoles_con.Where(a => a.Name == user.Role).SingleOrDefault();
        ////                var usrid = _serviceScope.AspNetUsers_con.Where(a => a.Id == userNew.Id.ToString()).SingleOrDefault();

        ////                Adminorsupport_user_detailsDMO dm = new Adminorsupport_user_detailsDMO();
        ////                dm.userid = usrid.userid;
        ////                dm.first_name = user.first_name;
        ////                dm.second_name = user.second_name;
        ////                dm.email = user.Email;
        ////                dm.dob = user.dob;
        ////                dm.mobile = Convert.ToInt64(user.PhoneNumber);
        ////                dm.alternative_mobile = user.alternative_mobile;
        ////                dm.aadhar_no = user.aadhar_no;
        ////                dm.address = user.address;
        ////                dm.pincode = user.pincode;
        ////                dm.gender = user.gender;
        ////                _serviceScope.Add(dm);
        ////                _serviceScope.SaveChanges();


        ////                ApplicationUserRolesDMO dmo = new ApplicationUserRolesDMO();
        ////                dmo.RoleId = rolid.roleid;
        ////                dmo.UserId = usrid.userid;
        ////                _serviceScope.ApplicationUserRoles_con.Add(dmo);
        ////                _serviceScope.SaveChanges();

        ////                return PrepareSuccessResponse();
        ////            }
        ////            else
        ////            {
        ////                Dictionary<string, string> errors = new Dictionary<string, string>();
        ////                foreach (var error in result.Errors)
        ////                {
        ////                    errors.Add(error.Code, error.Description);
        ////                }

        ////                return PrepareErrorResponse("Error", new Exception("An error occured"), errors);
        ////            }
        ////        }
        ////        else
        ////            return PrepareErrorResponse("Error", new Exception("Invalid request"));
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return PrepareErrorResponse("Error", ex);
        ////    }
        ////}

        //[HttpPost("update_login")]
        //[AllowAnonymous]
        //public AdminOrSupport_user_detailsDTO update_login([FromBody] AdminOrSupport_user_detailsDTO user)
        //{
        //    try
        //    {
        //        var dm = _serviceScope.Adminorsupport_user_details_con.Where(a => a.id == user.id).SingleOrDefault();
        //        dm.first_name = user.first_name;
        //        dm.second_name = user.second_name;
        //        dm.email = user.Email;
        //        dm.dob = user.dob;
        //        dm.mobile = Convert.ToInt64(user.PhoneNumber);
        //        dm.alternative_mobile = user.alternative_mobile;
        //        dm.aadhar_no = user.aadhar_no;
        //        dm.address = user.address;
        //        dm.pincode = user.pincode;
        //        dm.gender = user.gender;
        //        _serviceScope.Update(dm);
        //        var ss = _serviceScope.SaveChanges();
        //        if (ss > 0)
        //        {
        //            user.message = "Success";
        //        }
        //        else
        //        {
        //            user.message = "Failed";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //       
        //    }
        //    return user;
        //}


        //==================================================================
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "ASWIN33R33ASHOK333MAHANTESH333SACHIN333";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "ASWIN33R33ASHOK333MAHANTESH333SACHIN333";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


    }
}
