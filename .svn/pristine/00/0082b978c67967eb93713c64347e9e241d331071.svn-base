using EMarketDTO.CommanDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Npgsql;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using DBHelpers;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using System.Web;

namespace EMarket.Comman_Services
{
    public class Comman_Class
    {


        public readonly string ConnectionString = string.Empty;
        public string _ConnectionString { get => ConnectionString; }
        public Comman_Class()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            ConnectionString = root.GetSection("ConnectionStrings").GetSection("PostgreSql1").Value;

        }



        //===========

        ActionExecutingContext filterContext;
        Random numberGen = new Random();
        public string generatelinkid()
        {

            int otp = new Random().Next(999999);
            int noOfOtpDigit = 6;
            while (otp.ToString().Length != noOfOtpDigit)
            {
                otp = new Random().Next(999999);
            }
            int ss = otp;

            //int randomNumber = new Random().Next(000000, 999999);


            return ss.ToString();
        }

        private int Randamnumber()
        {
            List<int> randomList = new List<int>();
            int MyNumber = 0;
            MyNumber = numberGen.Next(0, 10);
            while (randomList.Contains(MyNumber))
                MyNumber = numberGen.Next(0, 10);
            return MyNumber;
        }

        public String sendOTPMSG(string strTo, string otp)
        {
            string respo = "Failed to Sent SMS";


            string smsurl = "https://smsstriker.com/API/unicodesms.php?username=avaniinfosoft&password=852730&from=AVINFT&to=" + strTo + "&msg=Avani Infosoft OTP for Mobile Application Registration is " + otp + ". Do not share it with anyone. &type=1&dnd_check=0& template_id=1707162332169302966";

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(smsurl);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            //string responseString2 = respStreamReader.BaseStream.ToString();
            string webrespo = responseString;
            if (webrespo != null)
            {
                respo = webrespo;
            }
            respStreamReader.Close();
            myResp.Close();
            return respo;
        }

        public string generate_ticket_id()
        {
            int otp = new Random().Next(999999);
            int noOfOtpDigit = 6;
            while (otp.ToString().Length != noOfOtpDigit)
            {
                otp = new Random().Next(999999);
            }
            int ss = otp;

            //int randomNumber = new Random().Next(000000, 999999);


            return ss.ToString();
        }
        
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

       

      
        
    }
}
