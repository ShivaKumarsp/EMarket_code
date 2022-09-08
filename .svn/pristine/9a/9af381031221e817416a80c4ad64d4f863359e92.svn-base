using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.DLL.EMarket_Repository.Vendor
{
    public class Vendor_Profile_Repository: IVendor_Profile_Repository
    {
        bool saved = true;
        PostgreSqlContext _context;
        comman_class cmm = new comman_class();
        ISql_Layer _sql;
        IError_Log _error;
        int status = 0;
       
        public Vendor_Profile_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;

        }

        public Vendor_ProfileDTO getdata(Vendor_ProfileDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Profile_Repository/getdata";
            _error.audit_log_txr(dto.userid, methodname, page_form);
            return dto;
        }
        public Vendor_ProfileDTO UpdateProfile(Vendor_ProfileDTO dto)
        {
            List<string> ret_validation = new List<string>();
            var Params = new DbParameter[] { };
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Profile_Repository/UpdateProfile";
            try
            {
                //vendor_id
                var vendorid = _context.Vendor_Profile_con.Where(a => a.user_id == dto.userid).FirstOrDefault();
                dto.vendor_id = vendorid.vendor_id;
                var existingumobuser = _context.Application_User_con.Where(a => a.user_id == dto.userid).ToList();

                
                var existingumob = _context.Application_User_con.Where(a => a.phonenumber == dto.vendor_mobile.ToString() && a.user_id != dto.userid && a.role_id==existingumobuser[0].role_id).ToList();
                if (existingumob.Count != 0)
                {
                    ret_validation.Add("Mobile Number Already Exist..");
                }

                var existingmob = _context.Vendor_Profile_con.Where(a => a.vendor_mobile == dto.vendor_mobile && a.vendor_id != dto.vendor_id).ToList();
                if (existingmob.Count != 0)
                {
                    ret_validation.Add("Mobile Number Already Exist..");
                  
                }
                var existinguemail = _context.Application_User_con.Where(a => a.email == dto.vendor_email && a.user_id != dto.userid && a.role_id == existingumobuser[0].role_id).ToList();
                if (existinguemail.Count != 0)
                {
                  
                    ret_validation.Add("Email Id Already Exist..");
                  
                }
                var existingemail = _context.Vendor_Profile_con.Where(a => a.vendor_email == dto.vendor_email && a.vendor_id != dto.vendor_id).ToList();
                if (existingemail.Count != 0)
                {
                    ret_validation.Add("Email Id Already Exist..");
           
                }
                if (dto.vendor_name.Trim() == "" || dto.vendor_name.Trim() == null)
                {
                    ret_validation.Add("Please Enter Name");
             
                }
                
                if (dto.vendor_name.Trim() != null)
                {
                    string nameRegex = @"^[a-zA-Z\s]+$";
                    Regex nre = new Regex(nameRegex);
                    if (!nre.IsMatch(dto.vendor_name.ToString()))
                    {
                        ret_validation.Add("Please Enter Valid  Name");
                    
                    }
                }
                else
                {
                    ret_validation.Add("Please Enter Name");
                 
                }
                if (dto.vendor_name.Trim().Length<3)
                {
                    
                        ret_validation.Add("Vendor Name Minimun 3 Character");

                    
                }

                if (dto.vendor_email != "" || dto.vendor_email != null)
                {
                    string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    Regex ere = new Regex(emailRegex);
                    if (!ere.IsMatch(dto.vendor_email))
                    {
                        ret_validation.Add("Please Enter Valid Email Id");
                       
                    }

                }
                else
                {
                    ret_validation.Add("Please Enter Email Id");
                 
                }
                if (dto.vendor_mobile == 9999999999 || dto.vendor_mobile == 8888888888 || dto.vendor_mobile == 7777777777 || dto.vendor_mobile == 6666666666)
                {
                    ret_validation.Add("Please Enter Valid Mobile Number");
                  
                }
                var mob = cmm.Is_Valid_Mobile(dto.vendor_mobile);
                if (mob == false)
                {
                    ret_validation.Add("Please Enter Valid Mobile Number");
                }

                if (dto.vendor_country_id == 0)
                {
                    ret_validation.Add("Please Select Country");
                
                }
               
                if (dto.vendor_state_id == 0)
                {
                    ret_validation.Add("Please Select State");
                
                }
                
                if (dto.vendor_city.Trim() == "" || dto.vendor_city.Trim() == null)
                {
                    ret_validation.Add("Please Enter City");
               
                }
                if (dto.vendor_city.Trim().Length<3)
                {
                    ret_validation.Add("City Name Minimun 3 Character");

                }

                if (dto.vendor_address.Trim() == "" || dto.vendor_address.Trim() == null)
                {
                    ret_validation.Add("Please Enter Address");
                   
                }

                if (dto.vendor_address.Trim().Length < 5)
                {
                    ret_validation.Add("Address Minimun 5 Character");

                }

                if (dto.business_address.Trim() == "" || dto.business_address.Trim() == null)
                {
                    ret_validation.Add("Please Enter Business Address");
                 
                }
                if (dto.business_address.Trim().Length < 5)
                {
                    ret_validation.Add("Business Address Minimun 5 Character");

                }

                if (dto.vendor_businessname.Trim() == "" || dto.vendor_businessname.Trim() == null)
                {
                    ret_validation.Add("Please Enter Business Name");
                 
                }
               
                if (dto.business_country_id == 0)
                {
                    ret_validation.Add("Please Select Country");
                    
                }
                
                if (dto.business_state_id == 0)
                {
                    ret_validation.Add("Please Select State");
                   
                }
              
                //if (dto.vendor_panno != "" || dto.vendor_panno != null)
                //{
                //    string mobileRegex = @"^[A-Z]{5}[0-9]{4}[A-Z]{1}$";
                //    Regex mre = new Regex(mobileRegex);
                //    if (!mre.IsMatch(dto.vendor_panno))
                //    {
                //        dto.messageflg = "Please Enter Valid PAN Number";
                //        return dto;
                //    }
                //}
                //else
                //{
                //    dto.messageflg = "Please Enter PAN Number";
                //    return dto;
                //}
                if (dto.vendor_pincode != 0)
                {
                    string pincodeRegex = @"^[1-9]{1}[0-9]{2}\s{0,1}[0-9]{3}$";
                    Regex mre = new Regex(pincodeRegex);
                    if (!mre.IsMatch(dto.vendor_pincode.ToString()))
                    {
                        ret_validation.Add("Please Enter Valid Pincode");
                    
                    }
                }
                else
                {
                    dto.messageflg = "Please Enter Pincode";
                    return dto;
                }
                if (dto.business_pincode != 0)
                {
                    string pincode1Regex = @"^[1-9]{1}[0-9]{2}\s{0,1}[0-9]{3}$";
                    Regex mre = new Regex(pincode1Regex);
                    if (!mre.IsMatch(dto.business_pincode.ToString()))
                    {
                        ret_validation.Add("Please Enter Valid Pincode");
                      
                    }
                }
                else
                {
                    ret_validation.Add("Please Enter Pincode");
                    
                }

                if (ret_validation.Count > 0)
                {
                    dto.msg_flg = "Validation";
                    dto.validation_list = ret_validation.ToArray();
                    return dto;
                }


                try
                {
                    //using (var conn = new NpgsqlConnection(cmm.ConnectionString))
                    //{
                    //    NpgsqlCommand cmd = new NpgsqlCommand("call sp_update_vendor_profile(:in_user_id,:in_vendor_id, :in_vendor_name,:in_vendor_email,:in_vendor_mobile, :in_vendor_dob,:in_vendor_panno,:in_vendor_address, :in_vendor_city,:in_vendor_state_id,:in_vendor_country_id, :in_vendor_pincode,:in_mg_id,:in_vendor_businessname, :in_business_address,:in_business_state_id,:in_business_country_id, :in_business_pincode,:in_business_termscondiction,:in_vendor_gst_available, :in_business_type,:in_legal_name,:in_registration_no, :in_business_pan_no,:in_updated_by,:in_image)", conn);
                    //    cmd.Parameters.AddWithValue("in_user_id", DbType.Int64).Value = dto.userid;
                    //    cmd.Parameters.AddWithValue("in_vendor_id", DbType.Int64).Value = dto.vendor_id;
                    //    cmd.Parameters.AddWithValue("in_vendor_name", DbType.String).Value = dto.vendor_name;
                    //    cmd.Parameters.AddWithValue("in_vendor_email", DbType.String).Value = dto.vendor_email;
                    //    cmd.Parameters.AddWithValue("in_vendor_mobile", DbType.Int64).Value = dto.vendor_mobile;
                    //    cmd.Parameters.AddWithValue("in_vendor_dob", DbType.DateTime).Value = dto.vendor_dob;
                    //    cmd.Parameters.AddWithValue("in_vendor_panno", DbType.String).Value = dto.vendor_panno;
                    //    cmd.Parameters.AddWithValue("in_vendor_address", DbType.String).Value = dto.vendor_address;
                    //    cmd.Parameters.AddWithValue("in_vendor_city", DbType.String).Value = dto.vendor_city;
                    //    cmd.Parameters.AddWithValue("in_vendor_state_id", DbType.Int32).Value = dto.vendor_state_id;
                    //    cmd.Parameters.AddWithValue("in_vendor_country_id", DbType.Int32).Value = dto.vendor_country_id;
                    //    cmd.Parameters.AddWithValue("in_vendor_pincode", DbType.Int32).Value = dto.vendor_pincode;
                    //    cmd.Parameters.AddWithValue("in_mg_id", DbType.Int64).Value = dto.mg_id;
                    //    cmd.Parameters.AddWithValue("in_vendor_businessname", DbType.String).Value = dto.vendor_businessname;
                    //    cmd.Parameters.AddWithValue("in_business_address", DbType.String).Value = dto.business_address;
                    //    cmd.Parameters.AddWithValue("in_business_state_id", DbType.Int32).Value = dto.business_state_id;
                    //    cmd.Parameters.AddWithValue("in_business_country_id", DbType.Int32).Value = dto.business_country_id;
                    //    cmd.Parameters.AddWithValue("in_business_pincode", DbType.Int32).Value = dto.business_pincode;
                    //    cmd.Parameters.AddWithValue("in_business_termscondiction", DbType.Boolean).Value = dto.business_termscondiction;
                    //    cmd.Parameters.AddWithValue("in_vendor_gst_available", DbType.Boolean).Value = dto.vendor_gst_available;
                    //    cmd.Parameters.AddWithValue("in_business_type", DbType.Int64).Value = 1;
                    //    cmd.Parameters.AddWithValue("in_legal_name", DbType.String).Value = dto.legal_name;
                    //    cmd.Parameters.AddWithValue("in_registration_no", DbType.String).Value = dto.registration_no;
                    //    cmd.Parameters.AddWithValue("in_business_pan_no", DbType.String).Value = dto.business_pan_no;
                    //    cmd.Parameters.AddWithValue("in_updated_by", DbType.Int64).Value = dto.userid;
                    //    cmd.Parameters.AddWithValue("in_image", DbType.String).Value = dto.vendor_image;
                    //    conn.Open();
                    //    var affectcount = cmd.ExecuteNonQuery();
                    //    saved = affectcount == 1;
                    //    if (affectcount == -1)
                    //    {
                    //        dto.msg_flg = "Update";
                    //    }
                    //    else
                    //    {
                    //        dto.msg_flg = "Failed";
                    //    }
                    //}




                    //update
                    using (var cnn = new NpgsqlConnection(cmm.ConnectionString))
                    {
                        var dbParams = new DbParameter[]
                        {
                        DbHelper.CreateParameter("in_user_id", dto.userid),
                        DbHelper.CreateParameter("in_vendor_id", dto.vendor_id),
                        DbHelper.CreateParameter("in_vendor_name", dto.vendor_name.Trim()),
                        DbHelper.CreateParameter("in_vendor_email", dto.vendor_email.Trim()),
                        DbHelper.CreateParameter("in_vendor_mobile", dto.vendor_mobile),
                        DbHelper.CreateParameter("in_vendor_dob", dto.vendor_dob),
                        DbHelper.CreateParameter("in_vendor_address", dto.vendor_address.Trim()),
                        DbHelper.CreateParameter("in_vendor_city", dto.vendor_city.Trim()),
                        DbHelper.CreateParameter("in_vendor_state_id", dto.vendor_state_id),
                        DbHelper.CreateParameter("in_vendor_country_id", dto.vendor_country_id),
                        DbHelper.CreateParameter("in_vendor_pincode", dto.vendor_pincode),
                        DbHelper.CreateParameter("in_mg_id", dto.mg_id),
                        DbHelper.CreateParameter("in_vendor_businessname", dto.vendor_businessname.Trim()),
                        DbHelper.CreateParameter("in_business_address", dto.business_address.Trim()),
                        DbHelper.CreateParameter("in_business_state_id", dto.business_state_id),
                        DbHelper.CreateParameter("in_business_country_id",dto.business_country_id),
                        DbHelper.CreateParameter("in_business_pincode", dto.business_pincode),
                        DbHelper.CreateParameter("in_business_termscondiction", dto.business_termscondiction),
                        DbHelper.CreateParameter("in_vendor_gst_available", dto.vendor_gst_available),
                        DbHelper.CreateParameter("in_business_type", 1),
                        DbHelper.CreateParameter("in_legal_name", dto.legal_name.Trim()),
                        DbHelper.CreateParameter("in_registration_no", dto.registration_no.Trim()),
                        DbHelper.CreateParameter("in_business_pan_no",dto.business_pan_no.Trim()),
                        //DbHelper.CreateParameter("in_updated_by", dto.userid),
                        DbHelper.CreateParameter("in_image", dto.vendor_image),
                        };
                        
                                                  
                        dto.procedure_name = "call sp_update_vendor_profile(:in_user_id,:in_vendor_id, :in_vendor_name,:in_vendor_email,:in_vendor_mobile, :in_vendor_dob,:in_vendor_address, :in_vendor_city,:in_vendor_state_id,:in_vendor_country_id, :in_vendor_pincode,:in_mg_id,:in_vendor_businessname, :in_business_address,:in_business_state_id,:in_business_country_id, :in_business_pincode,:in_business_termscondiction,:in_vendor_gst_available, :in_business_type,:in_legal_name,:in_registration_no, :in_business_pan_no,:in_image)";
                        status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
                        if (status == -1)
                        {
                            dto.msg_flg = "Update";
                        }
                        else
                        {
                            dto.msg_flg = "Failed";
                        }

                    }
                }
                catch (Exception ex)
                {
                    _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "sp_update_vendor_profile", Params);
                }
            }

            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, "UpdateProfile", Params);
            }
            finally
            {
                _error.audit_log_txr(dto.userid, methodname, page_form);
            }

            return dto;
        }
        public Vendor_ProfileDTO getstate(Vendor_ProfileDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Profile_Repository/getstate";
            return dto;
        }
        public Vendor_ProfileDTO getstate1(Vendor_ProfileDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Vendor_Profile_Repository/getstate1";
            return dto;
        }
    }
}
