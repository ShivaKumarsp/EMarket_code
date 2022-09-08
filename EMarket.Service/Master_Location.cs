using EMarket.Entities;
using EMarket.Entities.Entities;
using EMarket.Repository;
using EMarket.Repository.Interfaces;
using EMarket.Service.Interfaces;
using EMarketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Service
{
    public class Master_Location: IMasterLocation
    {
        // private readonly IServiceScopeFactory<PostgreSqlContext> _serviceScope;

        //public Master_Location(IServiceScopeFactory<PostgreSqlContext> serviceScope) => _serviceScope = serviceScope;

        private readonly IMasterLocation_Repository _interface;

        private PostgreSqlContext _serviceScope;
        public Master_Location(PostgreSqlContext serviceScope)
        {
            _serviceScope = serviceScope;
        }

        //public Master_Location(IMasterLocation_Repository interfac)
        //{
        //    _interface = interfac;
        //}
        public Master_LocationDTO Createlocation(Master_LocationDTO dto)
        {

            dto.getdata = _serviceScope.Master_Location_con.ToArray();
            return dto;
        }

        //public async Task<long> Createlocation(Master_LocationDMO dto)
        //{

        //    return await _interface.Createlocation(dto);
        //}
        //public async Task<long> Createlocation(Master_LocationDMO dto)
        //{
        //    using (var scope = _serviceScope.CreateScope())
        //    {
        //        var _context = scope.GetRequiredService();

        //        var dmo = new Master_LocationDMO();
        //        dmo.ml_id = 2;
        //        dmo.ml_location = dto.ml_location;
        //        dmo.ml_locationdescription = dto.ml_locationdescription;
        //        dmo.ml_locationfacilities = dto.ml_locationfacilities;
        //        dmo.ml_activeflg = true;
        //        dmo.ml_createdby = 1;
        //        dmo.createddate = DateTime.UtcNow;
        //        dmo.ml_updatedby = 1;
        //        dmo.createddate = DateTime.UtcNow;
        //        _context.Master_Location_con.Add(dmo);
        //        await _context.SaveChangeAsync();
        //        return dto.ml_id;
        //    }
        //}
    }
}
