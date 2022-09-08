using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace EMarket.DLL.Comman_Data
{
    public class comman_class
    {
        

        public readonly string ConnectionString = string.Empty;
        public string _ConnectionString { get => ConnectionString; }
        public comman_class()
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

        private static Random random = new Random();
        public  string RandomString(int length)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string RandomInt(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public bool Is_Valid_Mobile(long mobile)
        {
            bool ret = true;
            //if (mobile == 9999999999 || mobile == 8888888888 || mobile == 7777777777 || mobile == 6666666666)
            //{
            //    ret=false;
            //}
            //else
            if (mobile != 0)
            {
                string mobileRegex = @"^[7-9]{1}[0-9]{9}$";
                Regex mre = new Regex(mobileRegex);

                if (!mre.IsMatch(mobile.ToString()))
                {
                    ret = false;
                }
            }
            return ret;
        }

    }
}
