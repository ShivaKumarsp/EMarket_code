using AutoMapper;
using EMarket.Entities;
using EMarket.Entities.Entities;
using EMarket.Models;
using EMarket.Repository;
using EMarket.Service.Interfaces;
using EMarketDTO;
using log4net.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Master_Location : APIBaseController
    {

        private readonly IMapper _mapper;
        private readonly IMasterLocation _masterLocation;

        private PostgreSqlContext _serviceScope;
        public Master_Location(PostgreSqlContext serviceScope)
        {
            _serviceScope = serviceScope;
        }
        //public Master_Location(IMasterLocation masterLocation)
        //{
        //    _masterLocation = masterLocation;
        //}
        [HttpGet("getdate")]
        [AllowAnonymous]
        public Master_LocationDTO Getdata()
        {
            Master_LocationDTO dto = new Master_LocationDTO();
            //try
            //{
                //dto.getdata = _serviceScope.Master_Location_con.ToArray();
                return _masterLocation.Createlocation(dto);
            //}
            //catch (Exception ex)
            //{
            //    return PrepareErrorResponse(new List<Master_LocationDTO>(), ex);
            //}
            //return dto;
        }

        [HttpPost("Create")]
        [AllowAnonymous]
       //public async Task<APIResponse<string>> CreateLocation([FromBody] Master_LocationDTO dto)
         public Master_LocationDTO CreateLocation([FromBody] Master_LocationDTO dto)
        {
            if (dto.ml_id == 0)
            {
                Master_LocationDMO dmo = new Master_LocationDMO();
                dmo.ml_location = dto.ml_location;
                dmo.ml_locationdescription = dto.ml_locationdescription;
                dmo.ml_locationfacilities = dto.ml_locationfacilities;
                dmo.ml_createdby = 1;
                dmo.createddate = DateTime.UtcNow;
                dmo.ml_updatedby = 1;
                dmo.updateddate = DateTime.UtcNow;
                _serviceScope.Add(dmo);
                var ss = _serviceScope.SaveChanges();
                if (ss > 0)
                {
                    dto.message = "Insert Successfully";
                }
            }
            else
            {
                var dmo = _serviceScope.Master_Location_con.Where(a => a.ml_id == dto.ml_id).SingleOrDefault();
                dmo.ml_location = dto.ml_location;
                dmo.ml_locationdescription = dto.ml_locationdescription;
                dmo.ml_locationfacilities = dto.ml_locationfacilities;
                dmo.ml_createdby = 1;
                dmo.createddate = DateTime.UtcNow;
                dmo.ml_updatedby = 1;
                dmo.updateddate = DateTime.UtcNow;
                _serviceScope.Update(dmo);
                var ss = _serviceScope.SaveChanges();
                //if (ss > 0)
                //{
                //    dto.message = "Update Successfully";
                //}
            }
            return dto;

          //  return CreateSuccessResponse();
        }

        [HttpPut("Update")]
        [AllowAnonymous]
        //public async Task<APIResponse<string>> CreateLocation([FromBody] Master_LocationDTO dto)
        public Master_LocationDTO UpdateLocation([FromBody] Master_LocationDTO dto)
        {
           
                var dmo = _serviceScope.Master_Location_con.Where(a => a.ml_id == dto.ml_id).SingleOrDefault();
                dmo.ml_location = dto.ml_location;
                dmo.ml_locationdescription = dto.ml_locationdescription;
                dmo.ml_locationfacilities = dto.ml_locationfacilities;
                dmo.ml_createdby = 1;
                dmo.createddate = DateTime.UtcNow;
                dmo.ml_updatedby = 1;
                dmo.updateddate = DateTime.UtcNow;
                _serviceScope.Update(dmo);
                var ss = _serviceScope.SaveChanges();
            if (ss > 0)
            {
                dto.message = "Update Successfully";
            }

            return dto;

            //  return CreateSuccessResponse();
        }

        [HttpDelete("Delete")]
        [AllowAnonymous]
        public async Task<APIResponse<string>> DeleteLocation([FromBody] Master_LocationDTO dto)
        // public Master_LocationDTO DeleteLocation([FromBody] Master_LocationDTO dto)
        {
            var dmo = _serviceScope.Master_Location_con.Single(a => a.ml_id == dto.ml_id);
            _serviceScope.Remove(dmo);
            var ss = _serviceScope.SaveChanges();
            if (ss > 0)
            {
                dto.message = "Delete Successfully";
            }
            return PrepareSuccessResponse(dto.message.ToString());
            // return dto;
        }



    }
}
