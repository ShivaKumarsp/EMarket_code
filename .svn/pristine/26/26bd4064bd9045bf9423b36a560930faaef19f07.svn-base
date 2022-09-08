using EMarket.BLL.Comman_Class;
using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.Comman_Data;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarket.Entities.Delivery;
using EMarket.Entities.HubManager;
using EMarketDTO.Admin;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class UserCreation : IUserCreation
    {
        SqlHelper sqlHelper = new SqlHelper();
        string return_string = "";
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        Db_Connection conn = new Db_Connection();
        int status = 0;
        ValidationClass _valid = new ValidationClass();
        IUser_Creation_Repository _inter;
        public UserCreation(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IUser_Creation_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }
        public UserCreationDTO get_data(UserCreationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/get_data";
            var dbParams0 = new DbParameter[] { };

            try
            {
                var usermob = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();

                // gender
                var dbParams = new DbParameter[]
              {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
               };
                dbParams0 = dbParams;
                dto.procedure_name = "fn_gender";
                dto.genderlist = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get country
                var dbParams2 = new DbParameter[]
                     {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                      };
                dbParams0 = dbParams2;
                dto.procedure_name = "fn_country";
                dto.countrylist = _sql.fn_get_list(dto.procedure_name, dbParams2);

                //get hub list 
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                dbParams0 = dbParams3;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.fn_get_list(dto.procedure_name, dbParams3);


                var dbParams8 = new DbParameter[]
                    {
                        //DbHelper.CreateParameter("in_language_id", dto.language_id)
                    };
                dbParams0 = dbParams8;
                dto.procedure_name = "fn_hub_manager_list";
                dto.hubmanagerlist = _sql.Get_Data(dto.procedure_name, dbParams8);

                var dbParams9 = new DbParameter[]
                    {
                        //DbHelper.CreateParameter("in_language_id", dto.language_id)
                    };
                dbParams0 = dbParams9;
                dto.procedure_name = "fn_facilitation_list";
                dto.facilitymanagerlist = _sql.Get_Data(dto.procedure_name, dbParams9);



                //get executive list
                // var dbParams5 = new DbParameter[]
                //{
                //       DbHelper.CreateParameter("in_language_id", dto.language_id),
                //       DbHelper.CreateParameter("in_hub_id", usermob[0].hub_id)
                //};
                // dbParams0 = dbParams5;
                // dto.procedure_name = "fn_get_delivery_executive_list";
                // dto.executive_list = _sql.fn_get_list(dto.procedure_name, dbParams5);


                //get facility center
                // var dbParams6 = new DbParameter[]
                //{
                //       DbHelper.CreateParameter("in_language_id", dto.language_id),
                //       DbHelper.CreateParameter("in_hub_id", usermob[0].hub_id)
                //};
                // dbParams0 = dbParams6;
                // dto.procedure_name = "fn_get_facility_center_list";
                // dto.facility_center_list = _sql.Get_Data(dto.procedure_name, dbParams6);

                //get vehicle type
                //var dbParams7 = new DbParameter[]
                //     {
                //       DbHelper.CreateParameter("in_language_id", dto.language_id)
                //      };
                //dbParams0 = dbParams7;
                //dto.procedure_name = "fn_get_vehicle_type";
                //dto.vehicle_type_list = _sql.Get_Data(dto.procedure_name, dbParams7);



                if (usermob.Count > 0)
                {
                    var dbParams4 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id",dto.language_id),
                      DbHelper.CreateParameter("in_hub_id",usermob[0].hub_id)
                   };
                    dbParams0 = dbParams4;
                    dto.procedure_name = "fn_get_hu_pincode";
                    dto.pincodelist = _sql.Get_Data(dto.procedure_name, dbParams4);
                }

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
        public UserCreationDTO get_state(UserCreationDTO dto)
        {
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/get_state";
            if (dto.country_id == 0 || dto.country_id == null)
            {
                dto.status = "Failed";
                dto.message = "Please Select Country";
                return dto;
            }
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
                _error.audit_log_txr(dto.user_id, methodname, page_form);
            }
            return dto;
        }
        public UserCreationDTO create_user(UserCreationDTO dto)
        {
            List<UserCreationDTO> dtonewtemp1 = new List<UserCreationDTO>();
            var usernamm = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
            List<string> ret_validation = new List<string>();
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/create_user";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            bool nama;

            if (dto.first_name.Trim() == "" || dto.first_name.Trim() == null)
            {
                ret_validation.Add("Please Enter First Name");
            }
            if (dto.first_name.Trim().Length < 3 && dto.first_name.Trim() != "" && dto.first_name.Trim() != null)
            {
                ret_validation.Add("First Name  Min 3 Character");
            }
            if (dto.first_name.Trim().Length > 40 && dto.first_name.Trim() != "" && dto.first_name.Trim() != null)
            {
                ret_validation.Add("First Name  Max 40 Character");
            }
           


            if (dto.second_name != "")
            {
                if (dto.second_name.Length < 3)
                {
                    ret_validation.Add("Second Name  Min 3 Character");
                }
                if (dto.second_name.Length > 40)
                {
                    ret_validation.Add("Second Name  Max 40 Character");
                }
                nama = Regex.IsMatch(dto.second_name, @"^[a-zA-Z]+$");
             
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
            if (dto.address.Trim().Length < 3)
            {
                ret_validation.Add("Address Min 3 Character");
            }

            if (dto.city == "" || dto.city == null)
            {
                ret_validation.Add("Please Enter City");
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


            if (dto.alternative_mobile == 0 || dto.alternative_mobile == null)
            {
                ret_validation.Add("Please Enter Alternative Mobile");
            }
            if (dto.alternative_mobile.ToString().Length < 10)
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

            if (dto.country_id == 0)
            {
                ret_validation.Add("Please Select Country");
            }
            if (dto.state_id == 0)
            {
                ret_validation.Add("Please Select State");
            }

           
          
            if (dto.own_vehicle == 1)
            {
                if (dto.vehicle_reg_number == null || dto.vehicle_reg_number == "")
                {
                    ret_validation.Add("Please Enter Vehicle Reg Number");
                }
                if (dto.vehicle_details == null || dto.vehicle_details == "")
                {
                    ret_validation.Add("Please Enter Vehicle Details");
                }
                

                if (dto.vehicle_type_id == 0)
                {
                    ret_validation.Add("Please Select Vehicle Type");
                }
               
            }

            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }



            var usernn = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();
            try
            {
                if (dto.delivery_executive_id == 0)
                {
                    var useremail = _context.Application_User_con.Where(a => a.email == dto.email && a.role_id == 7).ToList();
                    if (useremail.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Email Id Already Exist, Please Enter Another Email";
                        return dto;
                    }

                    var usermob = _context.Application_User_con.Where(a => a.phonenumber == Convert.ToString(dto.mobile) && a.role_id == 7).ToList();
                    if (usermob.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Mobile Number Already Exist, Please Enter Another Mobile Number";
                        return dto;
                    }
                    if (dto.own_vehicle == 1)
                    {
                        var checkreg1 = _context.Delivery_Executive_Vehicle_DetailsDMO_con.Where(a => a.vehicle_reg_number.Trim() == dto.vehicle_reg_number).ToList();

                        if (checkreg1.Count > 0)
                        {
                            dto.status = "Failed";
                            dto.message = "Vehicle Reg Number Already Exist, Please Enter Another Reg Number";
                            return dto;
                        }
                    }


                    var dbParams12 = new DbParameter[]
                         {
                    DbHelper.CreateParameter("in_email", dto.email),
                     DbHelper.CreateParameter("in_mobile", dto.mobile.ToString()),
                    DbHelper.CreateParameter("in_password", dto.Password)
                         };
                    Params = dbParams12;
                    var spName = "fn_delivery_executive_user_creation";
                    var retObject1 = new List<dynamic>();
                    using (var dataReader = _dbHelper.ExecuteReder(spName, CommandType.StoredProcedure, dbParams12))
                    {
                        while (dataReader.Read())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            dtonewtemp1.Add(new UserCreationDTO
                            {
                                user_id = Convert.ToInt64(dataReader["user_id"])

                            });
                        }
                    }
                    if (dtonewtemp1[0].user_id != 0)
                    {
                        Delivery_Executive_DetailsDMO dmo = new Delivery_Executive_DetailsDMO();
                        dmo.user_id = dtonewtemp1[0].user_id;
                        dmo.first_name = dto.first_name;
                        dmo.second_name = dto.second_name;
                        dmo.email = dto.email;
                        dmo.mobile = dto.mobile;
                        dmo.address = dto.address;
                        dmo.city = dto.city;
                        dmo.state_id = dto.state_id;
                        dmo.country_id = dto.country_id;
                        dmo.pincode = dto.pincode;
                        dmo.dob = dto.dob;
                        dmo.alternative_mobile = dto.alternative_mobile;
                        dmo.gender_id = dto.gender_id;
                        dmo.image_url = dto.image_url;
                        dmo.hub_id = usernn[0].hub_id;
                        dmo.facilitation_id = dto.facilitation_id;
                        dmo.belongs_to = dto.belongs_to;
                        dmo.own_vehicle = dto.own_vehicle;
                        _context.Add(dmo);
                        var sss = _context.SaveChanges();

                        Delivery_Executive_Vehicle_DetailsDMO dm2 = new Delivery_Executive_Vehicle_DetailsDMO();
                        dm2.executive_id = dmo.delivery_executive_id;
                        dm2.vehicle_type_id = dto.vehicle_type_id;
                        dm2.vehicle_reg_number = dto.vehicle_reg_number;
                        dm2.vehicle_details = dto.vehicle_details;
                        //dm2.max_weight_kg = dto.max_weight_kg;
                        //dm2.max_volumetric_weight = dto.max_volumetric_weight;
                        //dm2.weight_type = dto.weight_type;
                        //dm2.volumetric_weight = dto.volumetric_weight;
                        _context.Add(dm2);
                        var sss1 = _context.SaveChanges();

                        foreach (var item in dto.pincode_array)
                        {
                            Deliver_Executive_Pincode_MappingDMO dd = new Deliver_Executive_Pincode_MappingDMO();
                            dd.delivery_executive_id = dmo.delivery_executive_id;
                            dd.pincode_id = item.pincode_id;
                            _context.Add(dd);
                            _context.SaveChanges();
                        }
                        if (sss == 1)
                        {



                            dto.status = "Insert";
                            dto.message = "User ID Created Successfully";
                        }
                        else
                        {
                            dto.status = "Failed";
                            dto.message = "User ID Created Failed";
                        }

                    }

                }
                else
                {
                    var d_usrid = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.delivery_executive_id == dto.delivery_executive_id).FirstOrDefault().user_id;
                    var useremail = _context.Application_User_con.Where(a => a.email == dto.email && a.role_id == 7 && a.user_id != d_usrid).ToList();
                    if (useremail.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Email Id Already Exist, Please Enter Another Email";
                        return dto;
                    }

                    var usermob = _context.Application_User_con.Where(a => a.phonenumber == Convert.ToString(dto.mobile) && a.role_id == 7 && a.user_id != d_usrid).ToList();
                    if (usermob.Count > 0)
                    {
                        dto.status = "Failed";
                        dto.message = "Mobile Number Already Exist, Please Enter Another Mobile Number";
                        return dto;
                    }

                    var checkreg = _context.Delivery_Executive_Vehicle_DetailsDMO_con.Where(a => a.executive_id == dto.delivery_executive_id).SingleOrDefault();
                    if(checkreg!=null)
                    {
                        var checkreg1 = _context.Delivery_Executive_Vehicle_DetailsDMO_con.Where(a => a.executive_id != dto.delivery_executive_id && a.vehicle_reg_number.Trim()==dto.vehicle_reg_number).ToList();

                        if (checkreg1.Count>0)
                        {
                            dto.status = "Failed";
                            dto.message = "Vehicle Reg Number Already Exist, Please Enter Another Reg Number";
                            return dto;
                        }
                    }

                    var dmo = _context.Delivery_Executive_DetailsDMO_con.Where(a => a.delivery_executive_id == dto.delivery_executive_id).SingleOrDefault();
                    dmo.first_name = dto.first_name;
                    dmo.second_name = dto.second_name;
                    dmo.email = dto.email;
                    dmo.mobile = dto.mobile;
                    dmo.address = dto.address;
                    dmo.city = dto.city;
                    dmo.state_id = dto.state_id;
                    dmo.country_id = dto.country_id;
                    dmo.pincode = dto.pincode;
                    dmo.dob = dto.dob;
                    dmo.alternative_mobile = dto.alternative_mobile;
                    dmo.gender_id = dto.gender_id;
                    dmo.image_url = dto.image_url;
                    dmo.facilitation_id = dto.facilitation_id;
                    dmo.belongs_to = dto.belongs_to;
                    dmo.own_vehicle = dto.own_vehicle;
                    _context.Update(dmo);
                    var sss = _context.SaveChanges();


                    var result = _context.Delivery_Executive_Vehicle_DetailsDMO_con.Where(a => a.executive_id == dto.delivery_executive_id).SingleOrDefault();
                    if (result != null)
                    {
                       result.executive_id = dmo.delivery_executive_id;
                       result.vehicle_type_id = dto.vehicle_type_id;
                       result.vehicle_reg_number = dto.vehicle_reg_number;
                       result.vehicle_details = dto.vehicle_details;
                       //result.max_weight_kg = dto.max_weight_kg;
                       //result.max_volumetric_weight = dto.max_volumetric_weight;
                       //result.weight_type = dto.weight_type;
                       // result.volumetric_weight = dto.volumetric_weight;
                        _context.Update(result);
                        var sss1 = _context.SaveChanges();
                    }
                    else
                    {
                        Delivery_Executive_Vehicle_DetailsDMO dm2 = new Delivery_Executive_Vehicle_DetailsDMO();
                        dm2.executive_id = dmo.delivery_executive_id;
                        dm2.vehicle_type_id = dto.vehicle_type_id;
                        dm2.vehicle_reg_number = dto.vehicle_reg_number;
                        dm2.vehicle_details = dto.vehicle_details;
                        //dm2.max_weight_kg = dto.max_weight_kg;
                        //dm2.max_volumetric_weight = dto.max_volumetric_weight;
                        //dm2.weight_type = dto.weight_type;
                        //dm2.volumetric_weight = dto.volumetric_weight;
                        _context.Add(dm2);
                        var sss1 = _context.SaveChanges();
                    }

                    foreach (var item in dto.pincode_array)
                    {
                        var rmv = _context.Deliver_Executive_Pincode_MappingDMO_con.Where(a => a.delivery_executive_id == dto.delivery_executive_id && a.pincode_id == item.pincode_id).SingleOrDefault();
                        if (rmv != null)
                        {
                            _context.Remove(rmv);
                            _context.SaveChanges();
                        }
                    }

                    foreach (var item in dto.pincode_array)
                    {
                        Deliver_Executive_Pincode_MappingDMO dd = new Deliver_Executive_Pincode_MappingDMO();
                        dd.delivery_executive_id = dmo.delivery_executive_id;
                        dd.pincode_id = item.pincode_id;
                        _context.Add(dd);
                        _context.SaveChanges();
                    }
                    if (sss == 1)
                    {



                        dto.status = "Update";
                        dto.message = "User ID Created Successfully";
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "User ID Created Failed";
                    }

                }


                var dbParams5 = new DbParameter[]
                     {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", usernamm[0].hub_id)
                     };
                Params = dbParams5;
                dto.procedure_name = "fn_get_delivery_executive_list";
                dto.executive_list = _sql.fn_get_list(dto.procedure_name, dbParams5);

                var dbParams = new DbParameter[]
            {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
             };
                Params = dbParams;
                dto.procedure_name = "fn_gender";
                dto.genderlist = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get country
                var dbParams2 = new DbParameter[]
                     {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                      };
                Params = dbParams2;
                dto.procedure_name = "fn_country";
                dto.countrylist = _sql.fn_get_list(dto.procedure_name, dbParams2);

                var dbParams4 = new DbParameter[]
                 {
                      DbHelper.CreateParameter("in_language_id",dto.language_id),
                      DbHelper.CreateParameter("in_hub_id",usernamm[0].hub_id)
                 };
                Params = dbParams4;
                dto.procedure_name = "fn_get_hu_pincode";
                dto.pincodelist = _sql.Get_Data(dto.procedure_name, dbParams4);



                //get facility center
                var dbParams6 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", usernamm[0].hub_id)
                   };
                Params = dbParams6;
                dto.procedure_name = "fn_get_facility_center_list";
                dto.facility_center_list = _sql.Get_Data(dto.procedure_name, dbParams6);

                //get vehicle type
                var dbParams7 = new DbParameter[]
                     {
                       DbHelper.CreateParameter("in_language_id", dto.language_id)
                      };
                Params = dbParams7;
                dto.procedure_name = "fn_get_vehicle_type";
                dto.vehicle_type_list = _sql.Get_Data(dto.procedure_name, dbParams7);

                dto.procedure_name = "";
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;

        }
        public UserCreationDTO create_hub_manager_user(UserCreationDTO dto)
        {
            List<string> ret_validation = new List<string>();
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/create_user";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            bool nama;

            if (dto.first_name.Trim() == "" || dto.first_name.Trim() == null)
            {
                ret_validation.Add("Please Enter First Name");
            }
            if (dto.first_name.Trim().Length < 3 && dto.first_name.Trim() != "" && dto.first_name.Trim() != null)
            {
                ret_validation.Add("First Name  Min 3 Character");
            }
            if (dto.first_name.Trim().Length > 40 && dto.first_name.Trim() != "" && dto.first_name.Trim() != null)
            {
                ret_validation.Add("First Name  Max 40 Character");
            }
            if (dto.first_name.Trim() != "" && dto.first_name.Trim() != null)
            {
                nama = Regex.IsMatch(dto.first_name, @"^[a-zA-Z]+$");
                if (nama == false)
                {
                    ret_validation.Add("Please Enter Valid First Name");
                }
            }


            if (dto.second_name != "")
            {
                if (dto.second_name.Length < 3)
                {
                    ret_validation.Add("Second Name  Min 3 Character");
                }
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
            if (dto.address.Trim().Length < 3)
            {
                ret_validation.Add("Address Min 3 Character");
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


            if (dto.alternative_mobile == 0 || dto.alternative_mobile == null)
            {
                ret_validation.Add("Please Enter Alternative Mobile");
            }
            if (dto.alternative_mobile.ToString().Length < 10)
            {
                ret_validation.Add("Please Enter 10 Digit Alternative Mobile Number");
            }

            if (dto.gender_id == 0 || dto.gender_id == null)
            {
                ret_validation.Add("Please Select Gender");
            }
            if (dto.hub_id == 0 || dto.hub_id == null)
            {
                ret_validation.Add("Please Select Hub");
            }

            var gend = _context.Master_Gender_con.Where(a => a.mg_id == dto.gender_id).ToList();
            if (gend.Count == 0)
            {
                ret_validation.Add("Please Select Valid Gender");
            }

            if (dto.country_id == 0)
            {
                ret_validation.Add("Please Select Country");
            }
            var count = _context.Master_CountryDMO_con.Where(a => a.country_id == dto.country_id).ToList();
            if (count.Count == 0)
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

            var useremail = _context.Application_User_con.Where(a => a.email == dto.email && a.role_id == 7).ToList();
            if (useremail.Count > 0)
            {
                dto.status = "Failed";
                dto.message = "Email Id Already Exist, Please Enter Another Email";
                return dto;
            }
            var usermob = _context.Application_User_con.Where(a => a.phonenumber == Convert.ToString(dto.mobile) && a.role_id == 7).ToList();
            if (usermob.Count > 0)
            {
                dto.status = "Failed";
                dto.message = "Mobile Number Already Exist, Please Enter Another Mobile Number";
                return dto;
            }

            try
            {
                var dbParams = new DbParameter[]
        {
                               DbHelper.CreateParameter("in_hub_user_id", dto.hub_user_id),
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
                               DbHelper.CreateParameter("in_Password",  dto.Password),
                               DbHelper.CreateParameter("in_hub_id",  dto.hub_id),
        };
                Params = dbParams;

                dto.procedure_name = "call sp_hub_user_creation(:in_hub_user_id,:in_user_id,:in_first_name,:in_second_name,:in_email,:in_mobile,:in_address,:in_city,   :in_state_id,:in_country_id,:in_pincode,:in_dob,:in_alternative_mobile,:in_gender_id,:in_image_url,:in_Password,:in_hub_id)";
                status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);


                if (status == -1)
                {

                    dto.status = "Insert";
                    dto.message = "User ID Created Successfully";
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "User ID Created Failed";
                }

                // gender
                var dbParams1 = new DbParameter[]
              {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
               };
                Params = dbParams;
                dto.procedure_name = "fn_gender";
                dto.genderlist = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get country
                var dbParams2 = new DbParameter[]
                     {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                      };
                Params = dbParams2;
                dto.procedure_name = "fn_country";
                dto.countrylist = _sql.fn_get_list(dto.procedure_name, dbParams2);

                //get hub list 
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.fn_get_list(dto.procedure_name, dbParams3);



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
        public UserCreationDTO get_edit_data(UserCreationDTO dto)
        {
            List<string> ret_validation = new List<string>();
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/get_edit_data";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            bool nama;


            try
            {

                var dbParams = new DbParameter[]
            {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_delivery_executive_id", dto.delivery_executive_id)
             };
                Params = dbParams;
                dto.procedure_name = "fn_get_edit_pincode_list";
                dto.get_pincode_list = _sql.Get_Data(dto.procedure_name, dbParams);

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
        public UserCreationDTO get_facilitation(UserCreationDTO dto)
        {
            List<string> ret_validation = new List<string>();
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/get_facilitation";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            bool nama;


            try
            {

                var dbParams = new DbParameter[]
            {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id)
             };
                Params = dbParams;
                dto.procedure_name = "fn_get_facilitation_list";
                dto.facilitation_list = _sql.Get_Data(dto.procedure_name, dbParams);

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
        public UserCreationDTO create_facilitation(UserCreationDTO dto)
        {
            List<string> ret_validation = new List<string>();
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/create_facilitation";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            bool nama;





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
            if (dto.address.Trim().Length < 3)
            {
                ret_validation.Add("Address Min 3 Character");
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


            if (dto.hub_id == 0 || dto.hub_id == null)
            {
                ret_validation.Add("Please Select Hub");
            }
            if (dto.facilitation_id == 0 || dto.facilitation_id == null)
            {
                ret_validation.Add("Please Facilitation Center");
            }

            if (dto.country_id == 0)
            {
                ret_validation.Add("Please Select Country");
            }

            if (dto.state_id == 0)
            {
                ret_validation.Add("Please Select State");
            }

            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }

            var useremail = _context.Application_User_con.Where(a => a.email == dto.email && a.role_id == 9).ToList();
            if (useremail.Count > 0)
            {
                dto.status = "Failed";
                dto.message = "Email Id Already Exist, Please Enter Another Email";
                return dto;
            }
            var usermob = _context.Application_User_con.Where(a => a.phonenumber == Convert.ToString(dto.mobile) && a.role_id == 9).ToList();
            if (usermob.Count > 0)
            {
                dto.status = "Failed";
                dto.message = "Mobile Number Already Exist, Please Enter Another Mobile Number";
                return dto;
            }

            try
            {
                var dbParams = new DbParameter[]
        {
                               DbHelper.CreateParameter("in_facilitation_user_id", dto.facilitation_user_id),
                               DbHelper.CreateParameter("in_user_id",  dto.user_id),
                               DbHelper.CreateParameter("in_email",  dto.email),
                               DbHelper.CreateParameter("in_mobile",   Convert.ToInt64(dto.mobile)),
                               DbHelper.CreateParameter("in_address",  dto.address),
                               DbHelper.CreateParameter("in_city",  dto.city),
                               DbHelper.CreateParameter("in_state_id",  dto.state_id),
                               DbHelper.CreateParameter("in_country_id",  dto.country_id),
                               DbHelper.CreateParameter("in_pincode",  Convert.ToInt64(dto.pincode)),
                               DbHelper.CreateParameter("in_Password",  dto.Password),
                               DbHelper.CreateParameter("in_hub_id",  dto.hub_id),
                               DbHelper.CreateParameter("in_facilitation_id",  dto.facilitation_id),
        };
                Params = dbParams;

                dto.procedure_name = "call sp_facilitation_user_creation(:in_facilitation_user_id,:in_user_id,:in_email,:in_mobile,:in_address,:in_city,:in_state_id,:in_country_id,:in_pincode,:in_Password,:in_hub_id,:in_facilitation_id)";
                status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);


                if (status == -1)
                {

                    dto.status = "Insert";
                    dto.message = "User ID Created Successfully";
                }
                else
                {
                    dto.status = "Failed";
                    dto.message = "User ID Created Failed";
                }

                // gender
                var dbParams1 = new DbParameter[]
              {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
               };
                Params = dbParams;
                dto.procedure_name = "fn_gender";
                dto.genderlist = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get country
                var dbParams2 = new DbParameter[]
                     {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                      };
                Params = dbParams2;
                dto.procedure_name = "fn_country";
                dto.countrylist = _sql.fn_get_list(dto.procedure_name, dbParams2);

                //get hub list 
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                Params = dbParams3;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.fn_get_list(dto.procedure_name, dbParams3);



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

        // create vehicle
        public UserCreationDTO get_vehicle_data(UserCreationDTO dto)
        {
            List<string> ret_validation = new List<string>();
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/create_facilitation";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            bool nama;

            var result = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();

            try
            {
               
                //get vehicle list
                var dbParams = new DbParameter[]
                     {
                      DbHelper.CreateParameter("in_hub_id", result.hub_id),
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_vehicle";
                dto.hub_vehicle_list = _sql.Get_Data(dto.procedure_name, dbParams);

                //get vehicle type
                var dbParams1 = new DbParameter[]
                     {
                       DbHelper.CreateParameter("in_language_id", dto.language_id)
                      };
                Params = dbParams1;
                dto.procedure_name = "fn_get_vehicle_type";
                dto.vehicle_type_list = _sql.Get_Data(dto.procedure_name, dbParams1);




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
        public UserCreationDTO save_vehicle_data(UserCreationDTO dto)
        {
            List<string> ret_validation = new List<string>();
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/create_facilitation";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            bool nama;
           
                if (dto.vehicle_reg_number == null || dto.vehicle_reg_number == "")
                {
                    ret_validation.Add("Please Enter Vehicle Reg Number");
                }
                if (dto.vehicle_details == null || dto.vehicle_details == "")
                {
                    ret_validation.Add("Please Enter Vehicle Details");
                }
               

               
               
            

            if (ret_validation.Count > 0)
            {
                dto.status = "Validation";
                dto.validation_list = ret_validation.ToArray();
                return dto;
            }

            var useremail = _context.Application_User_con.Where(a => a.email == dto.email && a.role_id == 9).ToList();
            if (useremail.Count > 0)
            {
                dto.status = "Failed";
                dto.message = "Email Id Already Exist, Please Enter Another Email";
                return dto;
            }
            var usermob = _context.Application_User_con.Where(a => a.phonenumber == Convert.ToString(dto.mobile) && a.role_id == 9).ToList();
            if (usermob.Count > 0)
            {
                dto.status = "Failed";
                dto.message = "Mobile Number Already Exist, Please Enter Another Mobile Number";
                return dto;
            }

            try
            {
                if (dto.belongs_to == "HUB")
                {
                    var result = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();
                    dto.hub_id =result.hub_id;
                }

              
                    var dbParams = new DbParameter[]
              {
                      DbHelper.CreateParameter("in_hub_vehicle_id", dto.hub_vehicle_id),
                      DbHelper.CreateParameter("in_vehicle_reg_number", dto.vehicle_reg_number),
              };
                    Params = dbParams;

                    var exedata = _sql.Get_ExecuteScalar("fn_check_hub_vehicle", dbParams);
                    if (exedata != "0")
                    {
                    dto.status = "Failed";
                    dto.message = "Vehicle Registration Number Already Exist";
                    return dto;
                }

                var result1 = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).SingleOrDefault();

                dto.hub_id = result1.hub_id;
                _inter.save_vehicle_data(dto);
                //get country
                var dbParams1 = new DbParameter[]
                     {
                      DbHelper.CreateParameter("in_hub_id", dto.hub_id),
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      };
                Params = dbParams1;
                dto.procedure_name = "fn_get_hub_vehicle";
                dto.hub_vehicle_list = _sql.Get_Data(dto.procedure_name, dbParams1);


                //get vehicle type
                var dbParams2 = new DbParameter[]
                     {
                       DbHelper.CreateParameter("in_language_id", dto.language_id)
                      };
                Params = dbParams2;
                dto.procedure_name = "fn_get_vehicle_type";
                dto.vehicle_type_list = _sql.Get_Data(dto.procedure_name, dbParams2);


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

        public UserCreationDTO get_hub(UserCreationDTO dto)
        {
            List<string> ret_validation = new List<string>();
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/get_hub";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            bool nama;



            try
            {
                var usermob = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();


                //get vehicle list
                var dbParams = new DbParameter[]
                     {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_hub_type", dto.hub_type),
                      };
                Params = dbParams;
                dto.procedure_name = "fn_get_hub_or_fc";
                dto.hub_or_fc_list = _sql.Get_Data(dto.procedure_name, dbParams);

                var dbParams4 = new DbParameter[]
                  {
                      DbHelper.CreateParameter("in_language_id",dto.language_id),
                      DbHelper.CreateParameter("in_hub_id",usermob[0].hub_id),
                      DbHelper.CreateParameter("in_facilitation_id",0)
                  };
                dbParams = dbParams4;
                dto.procedure_name = "fn_get_hu_pincode";
                dto.pincodelist = _sql.Get_Data(dto.procedure_name, dbParams4);

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

        public UserCreationDTO get_de_data(UserCreationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/get_de_data";
            var dbParams0 = new DbParameter[] { };

            try
            {
                var usermob = _context.Hub_User_DetailsDMO_con.Where(a => a.user_id == dto.user_id).ToList();

                // gender
                var dbParams = new DbParameter[]
              {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
               };
                dbParams0 = dbParams;
                dto.procedure_name = "fn_gender";
                dto.genderlist = _sql.fn_get_list(dto.procedure_name, dbParams);

                //get country
                var dbParams2 = new DbParameter[]
                     {
                      DbHelper.CreateParameter("planguageid", dto.language_id),
                      };
                dbParams0 = dbParams2;
                dto.procedure_name = "fn_country";
                dto.countrylist = _sql.fn_get_list(dto.procedure_name, dbParams2);

                //get hub list 
                var dbParams3 = new DbParameter[]
               {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_source_hub_id", 0)
               };
                dbParams0 = dbParams3;
                dto.procedure_name = "fn_get_hub";
                dto.hub_list = _sql.fn_get_list(dto.procedure_name, dbParams3);



               // get executive list
                 var dbParams5 = new DbParameter[]
                {
                       DbHelper.CreateParameter("in_language_id", dto.language_id),
                       DbHelper.CreateParameter("in_hub_id", usermob[0].hub_id)
                };
                dbParams0 = dbParams5;
                dto.procedure_name = "fn_get_delivery_executive_list";
                dto.executive_list = _sql.fn_get_list(dto.procedure_name, dbParams5);


                //get facility center
                 var dbParams6 = new DbParameter[]
                {
                       DbHelper.CreateParameter("in_language_id", dto.language_id),
                       DbHelper.CreateParameter("in_hub_id", usermob[0].hub_id)
                };
                dbParams0 = dbParams6;
                dto.procedure_name = "fn_get_facility_center_list";
                dto.facility_center_list = _sql.Get_Data(dto.procedure_name, dbParams6);

               // get vehicle type
                var dbParams7 = new DbParameter[]
                     {
                       DbHelper.CreateParameter("in_language_id", dto.language_id)
                      };
                dbParams0 = dbParams7;
                dto.procedure_name = "fn_get_vehicle_type";
                dto.vehicle_type_list = _sql.Get_Data(dto.procedure_name, dbParams7);



                if (usermob.Count > 0)
                {
                    var dbParams4 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id",dto.language_id),
                      DbHelper.CreateParameter("in_hub_id",usermob[0].hub_id),
                      DbHelper.CreateParameter("in_facilitation_id",0)
                   };
                    dbParams0 = dbParams4;
                    dto.procedure_name = "fn_get_hu_pincode";
                    dto.pincodelist = _sql.Get_Data(dto.procedure_name, dbParams4);
                }

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


        //mukta 17-8-2022
        public UserCreationDTO change_password(UserCreationDTO dto)
        {
            List<string> ret_validation = new List<string>();
            var Params = new DbParameter[] { };
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "UserCreation/change_password";
            IDbHelper _dbHelper = new NpgsqlHelper(conn.ConnectionString);
            //string password = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            Regex pass = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$");
            if (!pass.IsMatch(dto.Password.ToString()))
            {
                dto.messageflg = "Please Enter Valid Password";
                return dto;
            }

            _inter.change_password(dto);
            return dto;
        }

    }
}
