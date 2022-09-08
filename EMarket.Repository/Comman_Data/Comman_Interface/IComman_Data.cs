using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Comman_Data.Comman_Interface
{
    public interface IComman_Data
    {
        string CreateSalt(int size);
        bool VerifyPassword(string enteredPassword, string salt, string pwd);
        bool VerifySaltPassword(string enteredPassword, string salt, string pwd);
        string GetMD5(string pwd);
    }
}
