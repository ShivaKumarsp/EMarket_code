using EMarket.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMarket.Repository
{
    public interface IUserRepository
    {
        Task<long> AddUserDetails(UserDetails userDetails);

        UserDetails GetUserDetails(string userId);

        Task<string> UpdateUserDetails(UserDetails userDetails);

        List<UserDetails> GetMembers(string customerCode);

        Task<string> ActivateDactivateUser(UserDetails userDetails);

        Task<string> DeleteUser(UserDetails userDetails);

        //Task<long> AddUpdateUserTemplates(List<UserTemplates> userTemplates, string userId);
        //List<UserTemplates> GetUserTemplates(string userId, string customerCode);

    }
}
