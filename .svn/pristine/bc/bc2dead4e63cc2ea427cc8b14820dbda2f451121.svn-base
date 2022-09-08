using EMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EMarket.Controllers
{
    public class APIBaseController : ControllerBase
    {
       // private readonly ICustomerService _iCustomerService;

        //public APIBaseController(ICustomerService customerService)
        //{
        //    _iCustomerService = customerService;
        //}

        [NonAction]
        public APIResponse<T> PrepareSuccessRespnse<T>(T data) where T : class
        {
            APIResponse<T> response = new APIResponse<T>();
            response.Message = "Success";
            response.Code = StatusCodes.Status200OK;
            response.Entity = data;
            return response;
        }

        [NonAction]
        public APIResponse<T> PrepareErrorResponse<T>(T data, Exception ex, Dictionary<string, string> errors = null) where T : class
        {
            APIResponse<T> response = new APIResponse<T>();
            response.Message = "Failed";
            response.Code = StatusCodes.Status500InternalServerError;
            response.ErrorDetails = new Dictionary<string, string>();
            if (errors != null && errors.Count > 0)
            {
                response.ErrorDetails = errors;
            }
            else
            {
                response.ErrorDetails.Add("Error", ex.Message);
            }
            return response;
        }

        [NonAction]
        public APIResponse<string> PrepareSuccessResponse(string id = "")
        {
            APIResponse<string> response = new APIResponse<string>();
            response.Message = "Success";
            if (!string.IsNullOrEmpty(id))
                response.Id = id;
            response.Code = StatusCodes.Status200OK;
            return response;
        }

        [NonAction]
        public APIResponse<string> PrepareBadRequestResponse()
        {
            APIResponse<string> response = new APIResponse<string>();
            response.Message = "Fail";
            response.ErrorDetails = new Dictionary<string, string>();
            response.ErrorDetails.Add("Error", "Invalid Request");
            response.Code = StatusCodes.Status400BadRequest;
            return response;
        }
        [NonAction]
        public APIResponse<string> CreateSuccessResponse(string id = "")
        {
            APIResponse<string> response = new APIResponse<string>();
            response.Message = "Success";
            if (!string.IsNullOrEmpty(id))
                response.Id = id;
            response.Code = StatusCodes.Status201Created;
            return response;
        }

        //[NonAction]
        //public bool IsValidHeader(string fffff)
        //{
        //    if (!string.IsNullOrEmpty(fffff))
        //    {
        //        Startup.CustomerCode = fffff;
        //        var result = _iCustomerService.GetCustomer(Startup.fffff);
        //        if (result != null && result.customerid > 0)
        //        {
        //            return true;
        //        }
        //    }
        //    throw new Exception("Customer code is mandatory");
        //}
    }
}
