using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Comman_Class.Interface
{
   public interface IMasterClass
    {
        string CreateSalt(int size);
        bool VerifyPassword(string enteredPassword, string salt, string pwd);
        bool VerifySaltPassword(string enteredPassword, string salt, string pwd);
        string GetMD5(string pwd);
    }
}
