using EMarket.Entities;
using EMarketDTO.LoginDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMarket.BLL.Interfaces.Customer
{
    public interface IUserService
    {
        Task<long> AddUserDetails(UserDetails userDetails);

        UserDetails GetUserDetails(string userId);

        Task<string> UpdateUserDetails(Master_ModuleDTO userDetails);

        List<UserDetails> GetMembers(string customerCode);

        Task<string> ActivateDactivateUser(UserDetails userDetails);

        Task<string> DeleteUser(UserDetails userDetails);

        //Task<long> AddUpdateUserTemplates(List<UserTemplates> userTemplates, string userId);
        //List<UserTemplates> GetUserTemplates(string userId, string customerCode);
    }
}
