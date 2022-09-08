using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Master;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;

namespace EMarket.DLL.EMarket_Repository.Admin
{
  public  class Brand_Repository: IBrand_Repository
    {
        PostgreSqlContext _context;
        ISql_Layer _sql;
        IError_Log _error;
        comman_class comm = new comman_class();
        public Brand_Repository(PostgreSqlContext context, ISql_Layer sql, IError_Log error)
        {
            _context = context;
            _sql = sql;
            _error = error;

        }
        public BrandDTO GetBrand(BrandDTO dto)
        {
            try
            {

    

            }
            catch (Exception ex)
            {

            }
            return dto;
        }

        public BrandDTO AddBrand(BrandDTO dto)
        {
            int result;
            try
            {
                //call sp_save_brand(:in_brand_name,:in_brand_code,:in_brand_description,:in_language_id,:in_image_url
            }
            catch (Exception ex)
            {

            }
            return dto;
        }
    }
}
