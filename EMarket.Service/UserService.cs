using EMarket.Entities;
using EMarket.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMarket.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _iUserRepository;

        public UserService(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }
        public async Task<long> AddUserDetails(UserDetails userDetails)
        {
            return await _iUserRepository.AddUserDetails(userDetails);
        }

        public UserDetails GetUserDetails(string userId)
        {
            return _iUserRepository.GetUserDetails(userId);
        }

        public async Task<string> UpdateUserDetails(UserDetails userDetails)
        {
            return await _iUserRepository.UpdateUserDetails(userDetails);
        }

        public List<UserDetails> GetMembers(string customerCode)
        {
            return _iUserRepository.GetMembers(customerCode);
        }

        public Task<string> ActivateDactivateUser(UserDetails userDetails)
        {
            return _iUserRepository.ActivateDactivateUser(userDetails);
        }

        public Task<string> DeleteUser(UserDetails userDetails)
        {
            return _iUserRepository.DeleteUser(userDetails);
        }

      
        //}
    }
}
