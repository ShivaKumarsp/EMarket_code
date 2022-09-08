using EMarket.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Repository.Interfaces
{
   public  interface IMasterLocation_Repository
    {
        Task<long> Createlocation(Master_LocationDMO order);
    }
}
