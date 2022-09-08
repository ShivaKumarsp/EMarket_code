
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EMarket.DLL.Comman_Data.Comman_Repository
{
   public  class Comman_Data: IComman_Data
    {
      
        public readonly string ConnectionString = string.Empty;

        public string _ConnectionString { get => ConnectionString; }
        public Comman_Data()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            ConnectionString = root.GetSection("ConnectionStrings").GetSection("PostgreSql1").Value;

        }
        public string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public bool VerifyPassword(string enteredPassword, string salt, string pwd)

        {

            bool userValid = false;

            string plainTextInput = pwd;

            string newHashedPin = GetHash(plainTextInput, salt);

            if (newHashedPin.Equals(enteredPassword))

            {
                userValid = true;
            }
            else
            {
                userValid = false;
            }
            return userValid;
        }

        public bool VerifySaltPassword(string enteredPassword, string salt, string Dbpwd)

        {
            bool userValid = false;

            string newHashedPin = GetMD5(Dbpwd + salt);
            //string newHashedPin = GetSHA256(Dbpwd + salt);

            if (newHashedPin.Equals(enteredPassword))

            {
                userValid = true;
            }
            else
            {
                userValid = false;
            }
            return userValid;
        }
        private string GetHash(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        public string GetMD5(string pwd)
        {


            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;
            sSourceData = pwd;

            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            sSourceData = Convert.ToBase64String(tmpHash);
            return sSourceData;
        }

        public string GetSHA256(string pwd)
        {


            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;
            sSourceData = pwd;

            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            tmpHash = new SHA256CryptoServiceProvider().ComputeHash(tmpSource);
            sSourceData = Convert.ToBase64String(tmpHash);
            return sSourceData;
        }


    }
}
