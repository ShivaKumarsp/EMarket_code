using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EMarketDTO.CommanDTO
{
    public class FileDescriptionDTO
    {
        public string Email_id { get; set; }
        public string Mobileno { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Pic_Path { get; set; }
        public string Role_Type { get; set; }
        public string filepath { get; set; }
        public IFormFile File { get; set; }
        public ICollection<IFormFile> File1 { get; set; }


    }
}
