using EMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IServiceScopeFactory<PostgreSqlContext> _serviceScope;

        public UserRepository(IServiceScopeFactory<PostgreSqlContext> serviceScope) => _serviceScope = serviceScope;


        public async Task<long> AddUserDetails(UserDetails userDetails)
        {
            using (var scope = _serviceScope.CreateScope())
            {
                userDetails.IsActive = true;
                userDetails.IsArchived = false;
                var _context = scope.GetRequiredService();
                userDetails.createdon = DateTime.UtcNow;
                _context.UserDetails.Add(userDetails);
                var result = await _context.SaveChangesAsync();
                return result;
            }
        }

        public UserDetails GetUserDetails(string userId)
        {
            using (var scope = _serviceScope.CreateScope())
            {
                var _context = scope.GetRequiredService();
                return _context.UserDetails.FirstOrDefault(t => t.UserId == userId);
            }
        }

        public async Task<string> UpdateUserDetails(UserDetails userDetails)
        {
            using (var scope = _serviceScope.CreateScope())
            {
                var _context = scope.GetRequiredService();
                var dbUser = _context.UserDetails.FirstOrDefault(t => t.UserId == userDetails.UserId);
                if (dbUser != null)
                {
                    dbUser.Name = userDetails.Name;
                    dbUser.EMail = userDetails.EMail;
                    dbUser.AlternateMobile = userDetails.AlternateMobile;
                    //dbUser.DOB = userDetails.DOB;
                    //dbUser.IsActive = userDetails.IsActive;
                    //dbUser.IsArchived = userDetails.IsArchived;
                    dbUser.ImageBinary = userDetails.ImageBinary;
                    dbUser.WorkSpaceID = userDetails.WorkSpaceID;
                    dbUser.CompanyName = userDetails.CompanyName;
                    dbUser.CustomerCode  = userDetails.CustomerCode ;
                    dbUser.lastmodifiedby = userDetails.lastmodifiedby;
                    dbUser.lastmodifiedon = DateTime.UtcNow;
                    _context.UserDetails.Update(dbUser);
                    await _context.SaveChangeAsync();
                }
                return userDetails.UserId;
            }
        }

        public List<UserDetails> GetMembers(string customerCode)
        {
            using (var scope = _serviceScope.CreateScope())
            {
                var _context = scope.GetRequiredService();
                return _context.UserDetails.Where(t => t.CustomerCode  == customerCode && t.IsArchived == false).ToList();
            }
        }

        public async Task<string> ActivateDactivateUser(UserDetails userDetails)
        {
            using (var scope = _serviceScope.CreateScope())
            {
                var _context = scope.GetRequiredService();
                var dbUser = _context.UserDetails.FirstOrDefault(t => t.UserId == userDetails.UserId && t.CustomerCode  == userDetails.CustomerCode );
                if (dbUser != null)
                {

                    dbUser.IsActive = userDetails.IsActive;
                    dbUser.lastmodifiedby = userDetails.lastmodifiedby;
                    dbUser.lastmodifiedon = DateTime.UtcNow;
                    _context.UserDetails.Update(dbUser);
                    await _context.SaveChangeAsync();
                }
                return userDetails.UserId;
            }
        }

        public async Task<string> DeleteUser(UserDetails userDetails)
        {
            using (var scope = _serviceScope.CreateScope())
            {
                var _context = scope.GetRequiredService();
                var dbUser = _context.UserDetails.FirstOrDefault(t => t.UserId == userDetails.UserId && t.CustomerCode  == userDetails.CustomerCode );
                if (dbUser != null)
                {
                    dbUser.IsArchived = userDetails.IsArchived;
                    dbUser.lastmodifiedby = userDetails.lastmodifiedby;
                    dbUser.lastmodifiedon = DateTime.UtcNow;
                    _context.UserDetails.Update(dbUser);
                    await _context.SaveChangeAsync();
                }
                return userDetails.UserId;
            }
        }

        //public async Task<long> AddUpdateUserTemplates(List<UserTemplates> userTemplates, string userId)
        //{
        //    using (var scope = _serviceScope.CreateScope())
        //    {
        //        var _context = scope.GetRequiredService();
        //        if (userTemplates?.Count > 0)
        //        {
        //            foreach (var template in userTemplates)
        //            {
        //                var dbTemplate = _context.UserTemplates.FirstOrDefault(t => t.UserId == userId && 
        //                t.CustomerCode == template.CustomerCode && t.WorkspaceId == template.WorkspaceId && t.CustomerOutputTemplateId == template.CustomerOutputTemplateId);
        //                if (dbTemplate == null)
        //                {
        //                    template.Id = 0;
        //                    template.CreatedOn = DateTime.UtcNow;
        //                    template.ModifiedOn = DateTime.UtcNow;
        //                    template.CreatedBy = template.CreatedBy;
        //                    template.IsDelete = template.IsDelete;
        //                    template.UserId = userId;
        //                    _context.UserTemplates.Add(template);
        //                }
        //                else if(dbTemplate.Id > 0)
        //                {
        //                    template.UserId = userId;
        //                    dbTemplate.ModifiedOn = DateTime.UtcNow;
        //                    dbTemplate.ModifiedBy = template.ModifiedBy;
        //                    template.IsDelete = template.IsDelete;
        //                    _context.UserTemplates.Update(dbTemplate);
        //                }
        //            }
        //            await _context.SaveChangeAsync();
        //        }
        //        return userTemplates.Count;
        //    }
        //}

        //public List<UserTemplates> GetUserTemplates(string userId, string customerCode)
        //{
        //    using (var scope = _serviceScope.CreateScope())
        //    {
        //        var _context = scope.GetRequiredService();
        //        return _context.UserTemplates.Where(t => t.UserId == userId && t.CustomerCode == customerCode).ToList();
        //    }
        //}
    }
}
