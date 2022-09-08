using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace EMarket.BLL.Comman_Class
{
    public class ValidationClass
    {
        public bool Is_Valid_Email(string emailaddress)
        {
            bool validation = true;
            string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                 @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex ere = new Regex(emailRegex);
            if (!ere.IsMatch(emailaddress))
            {
                validation = false;
            }
            return validation;
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
                string mobileRegex = @"^[6-9]{1}[0-9]{9}$";
                Regex mre = new Regex(mobileRegex);

                if (!mre.IsMatch(mobile.ToString()))
                {
                    ret = false;
                }
            }
            return ret;
        }
        public static bool Is_Valid_DOB(DateTime dtDOB) //assumes a valid date string
        {
            int age = GetAge(dtDOB);
            if (age < 18 || age > 150) { return false; }
            return true;
        }
        public static int GetAge(DateTime birthDate)
        {
            DateTime today = DateTime.Now;
            int age = today.Year - birthDate.Year;
            if (today.Month < birthDate.Month || (today.Month == birthDate.Month && today.Day < birthDate.Day)) { age--; }
            return age;
        }


       

    }
}
