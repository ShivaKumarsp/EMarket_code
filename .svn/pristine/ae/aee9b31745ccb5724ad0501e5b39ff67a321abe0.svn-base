using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

using ImageMagick;
using EMarketDTO.CommanDTO;
using Microsoft.AspNetCore.Authorization;
using Azure.Storage.Blobs;
using System.Net;
using System.Text;

namespace EMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageUploadController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _accessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        string accountname = "";
        string accesskey = "";
        string folder = "";
        public ImageUploadController(IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _accessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;


        }


        private string GenerateFileName(string fileName)
        {
            try
            {
                string strFileName = string.Empty;
                string[] strName = fileName.Split('.');
                strFileName = fileName + DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." +
                   strName[strName.Length - 1];
                return strFileName;
            }
            catch (Exception ex)
            {
                return fileName;
            }
        }

        [HttpPost("Upload_Image")]
        [AllowAnonymous]
        public async Task<filedetails> Upload_Image(IFormFile file)
        {
            filedetails emp = new filedetails();
            try
            {

                var filename = GenerateFileName(file.FileName);
                var fileUrl = "";
                BlobContainerClient container = new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=demoschooltest;AccountKey=B0mUb4zemfjGP/6AlY5bjXYnrxn1aSusOP0KP9vKakyLyGuIolXgNva01gwVrayk+8vUQ9ymNWMW+AStrS430A==;EndpointSuffix=core.windows.net", "emarketplace");
                try
                {
                    BlobClient blob = container.GetBlobClient("profile" + "/" + filename);
                    using (Stream stream = file.OpenReadStream())
                    {
                        blob.Upload(stream);
                    }
                    fileUrl = blob.Uri.AbsoluteUri;
                }
                catch (Exception ex) { }
                emp.path = fileUrl;

            }
            catch (Exception ex)
            {

            }
            return emp;
        }

        //===============
        [HttpPost("Banner_Image_Upload")]
        [AllowAnonymous]
        public async Task<filedetails> Banner_Image_Upload(IFormFile File)
        {
            filedetails emp = new filedetails();

            try
            {
                var guid = Guid.NewGuid().ToString();
                folder = "/Banner_Image/" + guid + "_" + File.FileName;
                emp.name = File.FileName;
                emp.path = folder;
                var request = (FtpWebRequest)WebRequest.Create("ftp://124.153.106.183/EMarket_Image" + folder);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("avaniiis", "M@Avn#01");
                byte[] buffer = new byte[1024];
                var stream = File.OpenReadStream();
                byte[] fileContents;
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    fileContents = ms.ToArray();
                }
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }
                var response = (FtpWebResponse)request.GetResponse();
                var ddd = response.StatusCode == FtpStatusCode.FileActionOK;

            }
            catch (Exception ex)
            {

            }

            return emp;
        }

        [HttpPost("Cateory_Image_Upload")]
        [AllowAnonymous]
        public async Task<filedetails> Cateory_Image_Upload(IFormFile File)
        {
            filedetails emp = new filedetails();

            try
            {
                var guid = Guid.NewGuid().ToString();
                folder = "/Category_Image/" + guid + "_" + File.FileName;
                emp.name = File.FileName;
                emp.path = folder;
                var request = (FtpWebRequest)WebRequest.Create("ftp://124.153.106.183/EMarket_Image" + folder);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("avaniiis", "M@Avn#01");
                byte[] buffer = new byte[1024];
                var stream = File.OpenReadStream();
                byte[] fileContents;
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    fileContents = ms.ToArray();
                }
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }
                var response = (FtpWebResponse)request.GetResponse();
                var ddd = response.StatusCode == FtpStatusCode.FileActionOK;

            }
            catch (Exception ex)
            {

            }

            return emp;
        }

        [HttpPost("Item_Image_Upload")]
        [AllowAnonymous]
        public async Task<filedetails> Item_Image_Upload(IFormFile File)
        {
            filedetails emp = new filedetails();

            try
            {
                var guid = Guid.NewGuid().ToString();
                folder = "/Item_Image/" + guid + "_" + File.FileName;
                emp.name = File.FileName;
                emp.path = folder;
                var request = (FtpWebRequest)WebRequest.Create("ftp://124.153.106.183/EMarket_Image" + folder);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("avaniiis", "M@Avn#01");
                byte[] buffer = new byte[1024];
                var stream = File.OpenReadStream();
                byte[] fileContents;
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    fileContents = ms.ToArray();
                }
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }
                var response = (FtpWebResponse)request.GetResponse();
                var ddd = response.StatusCode == FtpStatusCode.FileActionOK;

            }
            catch (Exception ex)
            {

            }

            return emp;
        }

        [HttpPost("Product_Image_Upload")]
        [AllowAnonymous]
        public async Task<filedetails> Product_Image_Upload(IFormFile File)
        {
            filedetails emp = new filedetails();

            try
            {
                var guid = Guid.NewGuid().ToString();
                folder = "/Product_Image/" + guid + "_" + File.FileName;
                emp.name = File.FileName;
                emp.path = folder;
                var request = (FtpWebRequest)WebRequest.Create("ftp://124.153.106.183/EMarket_Image" + folder);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("avaniiis", "M@Avn#01");
                byte[] buffer = new byte[1024];
                var stream = File.OpenReadStream();
                byte[] fileContents;
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    fileContents = ms.ToArray();
                }
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }
                var response = (FtpWebResponse)request.GetResponse();
                var ddd = response.StatusCode == FtpStatusCode.FileActionOK;

            }
            catch (Exception ex)
            {

            }

            return emp;
        }

        [HttpPost("Profile_Upload")]
        [AllowAnonymous]
        public async Task<filedetails> Profile_Upload(IFormFile File)
        {
            filedetails emp = new filedetails();

            try
            {
                var guid = Guid.NewGuid().ToString();
                folder = "/Profile_Image/" + guid + "_" + File.FileName;
                emp.name = File.FileName;
                emp.path = folder;
                var request = (FtpWebRequest)WebRequest.Create("ftp://124.153.106.183/EMarket_Image" + folder);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("avaniiis", "M@Avn#01");
                byte[] buffer = new byte[1024];
                var stream = File.OpenReadStream();
                byte[] fileContents;
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    fileContents = ms.ToArray();
                }
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }
                var response = (FtpWebResponse)request.GetResponse();
                var ddd = response.StatusCode == FtpStatusCode.FileActionOK;

            }
            catch (Exception ex)
            {

            }

            return emp;
        }


        [HttpPost("Store_Image_Upload")]
        [AllowAnonymous]
        public async Task<filedetails> Store_Image_Upload(IFormFile File)
        {
            filedetails emp = new filedetails();

            try
            {
                var guid = Guid.NewGuid().ToString();
                folder = "/Store_Image/" + guid + "_" + File.FileName;
                emp.name = File.FileName;
                emp.path = folder;
                var request = (FtpWebRequest)WebRequest.Create("ftp://124.153.106.183/EMarket_Image" + folder);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("avaniiis", "M@Avn#01");
                byte[] buffer = new byte[1024];
                var stream = File.OpenReadStream();
                byte[] fileContents;
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    fileContents = ms.ToArray();
                }
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }
                var response = (FtpWebResponse)request.GetResponse();
                var ddd = response.StatusCode == FtpStatusCode.FileActionOK;

            }
            catch (Exception ex)
            {

            }

            return emp;
        }

        [HttpPost("Vendor_Details_Image_Upload")]
        [AllowAnonymous]
        public async Task<filedetails> Vendor_Details_Image_Upload(IFormFile File)
        {
            filedetails emp = new filedetails();

            try
            {
                var guid = Guid.NewGuid().ToString();
                folder = "/Vendor_Details/" + guid + "_" + File.FileName;
                emp.name = File.FileName;
                emp.path = folder;
                var request = (FtpWebRequest)WebRequest.Create("ftp://124.153.106.183/EMarket_Image" + folder);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("avaniiis", "M@Avn#01");
                byte[] buffer = new byte[1024];
                var stream = File.OpenReadStream();
                byte[] fileContents;
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    fileContents = ms.ToArray();
                }
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }
                var response = (FtpWebResponse)request.GetResponse();
                var ddd = response.StatusCode == FtpStatusCode.FileActionOK;

            }
            catch (Exception ex)
            {

            }

            return emp;
        }

        //===============
        ///=======================================================================================================
        //[HttpPost("DocumentUpload")]
        //[AllowAnonymous]
        //public async Task<filedetails> DocumentUpload(IFormFile File)
        //{
        //    filedetails emp = new filedetails();
        //    try
        //    {
        //        string basefilepath = "";

        //        // file save project folder
        //        var names = new List<string>();
        //        var contentTypes = new List<string>();

        //        string newImageName = "";
        //        List<string> Filesname = new List<string>();
        //        List<filedetails> FilesPaths = new List<filedetails>();

        //        //string filename = "";
        //        //var path = Path.Combine(_webHostEnvironment.WebRootPath, "Gallery", File.FileName);
        //        //using (var filestrem = new FileStream(path, FileMode.Create))
        //        //{
        //        //    File.CopyTo(filestrem);
        //        //}

        //        //var baseurl = _accessor.HttpContext.Request.Scheme + "://" +
        //        //    _accessor.HttpContext.Request.Host +
        //        //    _accessor.HttpContext.Request.PathBase;
        //        emp.name = File.FileName;
        //        //emp.path = filename;
        //        FilesPaths.Add(emp);

        //        // file save project folder end

        //        //  File save drive folder
        //        var fileName = string.Empty;
        //        var nameofthefile = "";
        //        string containername = "D:\\Upload\\";

        //        //string containername = "http://192.168.1.122/Upload/";
        //        string folder = "gallery";
        //        if (File.Length > 0)
        //        {


        //            var uploads = Path.Combine(containername, folder);

        //            if (Directory.Exists(uploads))
        //            {
        //                Console.WriteLine("That path exists already.");
        //            }
        //            else
        //            {
        //                DirectoryInfo di = Directory.CreateDirectory(uploads);
        //            }
        //            fileName = File.FileName;
        //            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
        //            {
        //                await File.CopyToAsync(fileStream);
        //                nameofthefile = fileName;
        //            }



        //            string newpath = Path.Combine(uploads) + $@"\{fileName}";
        //            emp.path = newpath;

        //        }
        //        //  File save drive folder end

        //        // file convert base64
        //        if (File.Length > 0)
        //        {
        //            using (var ms = new MemoryStream())
        //            {
        //                File.CopyTo(ms);
        //                var fileBytes = ms.ToArray();
        //                basefilepath = Convert.ToBase64String(fileBytes);
        //                //emp.path = "data:image/jpeg;base64," + basefilepath;
        //                emp.path = basefilepath;
        //            }
        //        }
        //        // file convert base64 end
        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //        return emp;
        //    }


        //// Local Storege
        //[HttpPost("DocumentUpload")]
        //[AllowAnonymous]
        //public async Task<filedetails> DocumentUpload(IFormFile File)
        //{
        //    // Local Storege
        //    filedetails emp = new filedetails();
        //    try
        //    {
        //        string basefilepath = "";

        //        // file save project folder
        //        var names = new List<string>();
        //        var contentTypes = new List<string>();

        //        string newImageName = "";
        //        List<string> Filesname = new List<string>();
        //        List<filedetails> FilesPaths = new List<filedetails>();

        //        string filename = "";
        //        var path = Path.Combine(_webHostEnvironment.WebRootPath, "Gallery", File.FileName);
        //        using (var filestrem = new FileStream(path, FileMode.Create))
        //        {
        //            File.CopyTo(filestrem);
        //        }

        //        var baseurl = _accessor.HttpContext.Request.Scheme + "://" +
        //            _accessor.HttpContext.Request.Host +
        //            _accessor.HttpContext.Request.PathBase;
        //        emp.name = File.FileName;
        //        //emp.path = filename;
        //        FilesPaths.Add(emp);


        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //    return emp;
        //}


        //// Base 64
        //[HttpPost("DocumentUpload")]
        //[AllowAnonymous]
        //public async Task<filedetails> DocumentUpload(IFormFile File)
        //{
        //    filedetails emp = new filedetails();
        //    try
        //    {
        //        string basefilepath = "";


        //        // file convert base64
        //        if (File.Length > 0)
        //        {
        //            using (var ms = new MemoryStream())
        //            {
        //                File.CopyTo(ms);
        //                var fileBytes = ms.ToArray();
        //                basefilepath = Convert.ToBase64String(fileBytes);
        //                //emp.path = "data:image/jpeg;base64," + basefilepath;
        //                emp.path = basefilepath;
        //            }
        //        }
        //        // file convert base64 end
        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //    return emp;
        //}


    }


    public class filedetails
    {
        public string name { get; set; }
        public string path { get; set; }

    }
}