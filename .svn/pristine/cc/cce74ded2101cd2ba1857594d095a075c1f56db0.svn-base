using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.Entities.Models
{
    public class ApplicationUser1 : IdentityUser<int>
    {
        public string RoleTypeFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Name { get; set; }

    }


    public class ApplicationRole : IdentityRole<int>
    {

        public string roleType { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public ApplicationUserRole() : base() { }


    }

    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
        public ApplicationRoleClaim() : base() { }

    }

    public class ApplicationUserClaims : IdentityUserClaim<int>
    {

    }

    public class ApplicationUserLogins : IdentityUser<int>
    {




        public string test { get; set; }

    }


    public class ApplicationUserToken : IdentityUserToken<int>
    {
    }
}
