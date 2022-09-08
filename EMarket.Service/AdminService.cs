using EMarket.Repository;

namespace EMarket.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _iAdminRepository;

        public AdminService(IAdminRepository iAdminRepository)
        {
            _iAdminRepository = iAdminRepository;
        }
    

        //public FunctionalityMapping GetFuncality(string roleId)
        //{
        //    return _iAdminRepository.GetFuncality(roleId);
        //}

        //public Task<long> AddFunctionality(FunctionalityMapping functionality)
        //{
        //    return _iAdminRepository.AddFunctionality(functionality);
        //}

    }
}
