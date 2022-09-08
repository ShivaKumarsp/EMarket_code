using EMarket.Entities;

namespace EMarket.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IServiceScopeFactory<PostgreSqlContext> _serviceScope;

        public AdminRepository(IServiceScopeFactory<PostgreSqlContext> serviceScope) => _serviceScope = serviceScope;

        
        //public async Task<long> AddFunctionality(FunctionalityMapping functionality)
        //{
        //    using (var scope = _serviceScope.CreateScope())
        //    {
        //        var _context = scope.GetRequiredService();
        //        _context.FunctionalityMapping.Add(functionality);
        //        var result = await _context.SaveChangesAsync();
        //        return functionality.Id;
        //    }
        //}

        //public FunctionalityMapping GetFuncality(string roleId)
        //{
        //    using (var scope = _serviceScope.CreateScope())
        //    {
        //        var _context = scope.GetRequiredService();
        //        return _context.FunctionalityMapping.FirstOrDefault(t => t.RoleId == roleId);
        //    }
        //}
    }
}
