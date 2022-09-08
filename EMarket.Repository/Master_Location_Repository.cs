using EMarket.Entities;
using EMarket.Entities.Entities;
using EMarket.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Repository
{
   public class Master_Location_Repository: IMasterLocation_Repository
    {
        private readonly IServiceScopeFactory<PostgreSqlContext> _serviceScope;

        public Master_Location_Repository(IServiceScopeFactory<PostgreSqlContext> serviceScope) => _serviceScope = serviceScope;

        public async Task<long> Createlocation(Master_LocationDMO order)
        {
            using (var scope = _serviceScope.CreateScope())
            {
                var _context = scope.GetRequiredService();
               
                _context.Master_Location_con.Add(order);
                var result = await _context.SaveChangesAsync();
                return order.ml_id;

                //var dto = new Master_LocationDMO();
                ////dto.ml_id = order.ml_id;
                //dto.ml_location = order.ml_location;
                //dto.ml_locationdescription = order.ml_locationdescription;
                //dto.ml_locationfacilities = order.ml_locationfacilities;
                //dto.createddate = DateTime.UtcNow;
                //dto.ml_createdby = 1;
                //dto.updateddate = DateTime.UtcNow;
                //dto.ml_updatedby = 1;
                //_context.Master_Location_con.Add(dto);
                //await _context.SaveChangeAsync();

                // Add log
                //var log = new PaymentLogs();
                //log.Id = 0;
                //log.OrderId = order.Id;
                //log.CustomerCode = order.CustomerCode;
                //log.UserId = order.UserId;
                //log.PaymentId = payment.Id;
                //log.RequestData = "Order created";
                //log.CreatedBy = order.CreatedBy;
                //log.CreatedOn = DateTime.UtcNow;
                //_context.PaymentLogs.Add(log);
                //return order.ml_id;
            }
        }
    }
}
