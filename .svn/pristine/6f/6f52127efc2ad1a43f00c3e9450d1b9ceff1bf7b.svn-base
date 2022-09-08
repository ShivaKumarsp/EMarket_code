using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.AuthServer
{
    public class GlobalInterceptor : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Controller controller = filterContext.Controller as Controller;
            var descriptor = filterContext.HttpContext.Request.Path.ToString();
            //if (!descriptor.Contains("Register") && !descriptor.Contains("login") && !descriptor.Contains("sendotp") && !descriptor.Contains("connect") && !descriptor.Contains("changepassword"))

            if (descriptor != "/api/Account/login" &&  descriptor != "/api/Landing/getdata/1"&&  descriptor != "/api/Landing/getdata/2" && descriptor != "/api/PublicLanding/get_public_productdetails/" && descriptor!= "/api/PublicLanding/attributecheck/" && descriptor!= "/api/Account/CheckAvailable" && descriptor!= "/api/Account/Register" && descriptor!= "/api/Account/sendotpreg" && descriptor != "/api/Account/login_details_angular")
            {
                //if (controller != null)
                //{


                    if (filterContext.HttpContext.Session.GetInt32("UserId") == null || filterContext.HttpContext.Session.GetInt32("UserId") == 0)
                    {
                        var data = new
                        {
                            isSessionExpired = true,
                        };
                        filterContext.Result = new JsonResult(data);
                    }

                }
            //}



            base.OnActionExecuting(filterContext);
        }
    }
}
