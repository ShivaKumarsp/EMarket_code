using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Admin
{
    public class UserCreationDTO
    {
        public long user_id { get; set; }
        public long facilitation_user_id { get; set; }
        public long delivery_executive_id { get; set; }
        public long hub_user_id { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public long language_id { get; set; }
        public string hub_type { get; set; }
        public string apitype { get; set; }
        public long country_id { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public long customer_id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string email { get; set; }
        public long mobile { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public long state_id { get; set; }
        public long pincode { get; set; }
        public DateTime dob { get; set; }
        public long alternative_mobile { get; set; }
        public long gender_id { get; set; }
        public long facility_center_id { get; set; }
        public long hub_id { get; set; }
        public long facilitation_id { get; set; }
        public string image_url { get; set; }
        public string Password { get; set; }
        public bool statusflg { get; set; }
        public string messageflg { get; set; }
             public long own_vehicle { get; set; }
        public long hub_vehicle_id { get; set; }
        public long vehicle_type_id { get; set; }
        //session
        public string username { get; set; }
        public string vehicle_type { get; set; }
        public string vehicle_reg_number { get; set; }
        public string vehicle_details { get; set; }
        public string weight_type { get; set; }
        public string belongs_to { get; set; }
        public long max_weight_kg { get; set; }
        public decimal volumetric_weight { get; set; }
        public decimal max_volumetric_weight { get; set; }
        public decimal max_volumetric_length { get; set; }
        public decimal max_volumetric_breadth { get; set; }
        public decimal max_volumetric_height { get; set; }
        public decimal pickup_volumetric_length { get; set; }
        public decimal pickup_volumetric_breadth { get; set; }
        public decimal pickup_volumetric_height { get; set; }
        public bool is_active { get; set; }

        public long roleid { get; set; }
        public string rolename { get; set; }
        public string inputvalue { get; set; }
        public string pincodelist { get; set; }

        public Array validation_list { get; set; }
        public Array executive_list { get; set; }
        public Array statelist { get; set; }
        public Array genderlist { get; set; }
        public Array countrylist { get; set; }
        public Array hub_list { get; set; }
        public pincode_array1[] pincode_array { get; set; }
        public string get_pincode_list { get; set; }
        public string facilitation_list { get; set; }
        public string facility_center_list { get; set; }
        public string hub_vehicle_list { get; set; }
        public string hub_or_fc_list { get; set; }
        public string vehicle_type_list { get; set; }
        //Mukta 11-08-2022
        public string hubmanagerlist { get; set; }
        public string facilitymanagerlist { get; set; }
        //public long hubuser_id { get; set; }
        

    }
}


public class pincode_array1
{
    public long pincode_id { get; set; }
}