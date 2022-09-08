using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerCode { get; set; }
        public string messageflg { get; set; }
        public string ipAddress { get; set; }
        public UserDetailsDto userDetails { get; set; }
        public List<UserTemplatesDto> userTemplatesDto { get; set; }
    }

    public class UserDetailsDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string CustomerCode { get; set; }
        public string CompanyName { get; set; }
        public DateTime? DOB { get; set; }
        public string EMail { get; set; }
        public long WorkSpaceID { get; set; }
        public string AlternateMobile { get; set; }
        public bool IsArchived { get; set; }
        public bool IsActive { get; set; }
        public string Createdby { get; set; }
        public string LastModifiedBy { get; set; }
        public string Role { get; set; }
        public string ImageBinary { get; set; }

    }
}
