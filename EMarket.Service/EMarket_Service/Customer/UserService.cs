using EMarket.BLL.Interfaces.Customer;
using EMarket.DLL;
using EMarket.DLL.Interfaces.Customer;
using EMarket.Entities;
using EMarket.Repository;
using EMarketDTO.LoginDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMarket.BLL.EMarket_Service.Customer
{
    public class UserService : IUserService
    {
        private readonly DLL.Interfaces.Customer.IUserRepository _iUserRepository;

        public UserService(DLL.Interfaces.Customer.IUserRepository iUserRepository)
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

        public async Task<string> UpdateUserDetails(Master_ModuleDTO userDetails)
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
