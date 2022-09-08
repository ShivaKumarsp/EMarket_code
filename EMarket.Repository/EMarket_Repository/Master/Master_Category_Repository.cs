
using EMarket.DLL.Comman_Data;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Core;
using LiteX.DbHelper.Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace EMarket.DLL.EMarket_Repository.Master
{
    public class Master_Category_Repository : IMaster_Category_Repository
    {

        comman_class cmm = new comman_class();
        PostgreSqlContext _context;
        SqlHelper sqlHelper = new SqlHelper();
        int status = 0;
        string return_string = "";
        List<string> invalue = new List<string>();
        public Master_Category_Repository(PostgreSqlContext context)
        {
            _context = context;


        }
        public Master_CategoryDTO save_subcat(Master_CategoryDTO dto)
        {
            IDbHelper _dbHelper = new NpgsqlHelper(cmm.ConnectionString);

            var dbParams = new DbParameter[]
    {
                    DbHelper.CreateParameter("in_msc_id", dto.msc_id),
                    DbHelper.CreateParameter("in_mc_id", dto.mc_id),
                    DbHelper.CreateParameter("in_msc_name", dto.msc_name),
                    DbHelper.CreateParameter("in_description", dto.description),
                    DbHelper.CreateParameter("in_imageurl", dto.image_url),
                    DbHelper.CreateParameter("in_language_id", dto.language_id),
                    DbHelper.CreateParameter("in_user_id", dto.user_id)
    };
            foreach (var item in dbParams)
            {
                invalue.Add(item.ParameterName + ':' + item.Value);
            }
            dto.inputvalue = Newtonsoft.Json.JsonConvert.SerializeObject(invalue);

            dto.procedure_name = "call sp_update_subcategory(:in_msc_id,:in_mc_id, :in_msc_name,:in_description,:in_imageurl,:in_language_id,:in_user_id)";
            status = _dbHelper.ExecuteNonQuery(dto.procedure_name, CommandType.Text, dbParams);
            if (status == -1)
            {
                if(dto.msc_id>0)
                {
                    dto.status = "Update";
                    dto.message = "SubCategory Updated Successfully";

                }
                else
                {
                    dto.status = "Insert";
                    dto.message = "SubCategory Inserted Successfully";
                }
             
            }
            else
            {
                dto.status = "Failed";
                dto.message = "'Product Specification Not Saved, Please Try Again',";
            }

            return dto;
        }

       
    }
}
