using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Vendor;
using EMarket.DLL.Interfaces.Vendor;
using EMarket.Entities;
using EMarketDTO.Vendar;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Vendor
{
    public class Add_Item_Specification: IAdd_Item_Specification
    {
        IAdd_Item_Specification_Repository _inter;
               int status = 0;
        bool saved = false;
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        public Add_Item_Specification(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IAdd_Item_Specification_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public Add_Item_SpecificationDTO getdata(Add_Item_SpecificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "item_item_Specification/getdata";
            var Params = new DbParameter[] { };
            try
            {
                var dbParams = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                   };
                Params = dbParams;
                dto.procedure_name = "fn_get_masterspecification";
                dto.specificationlist = _sql.fn_get_list(dto.procedure_name, dbParams);

                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_languageid", dto.language_id),
                      DbHelper.CreateParameter("in_vendorid", dto.language_id)
                    };
                Params = dbParams;
                dto.procedure_name = "fn_get_itemnames";
                dto.itemlist = _sql.fn_get_list(dto.procedure_name, dbParams);
              
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);

            }
            return dto;
        }

        public Add_Item_SpecificationDTO savespecification(Add_Item_SpecificationDTO dto)
        {
            return _inter.savespecification(dto);
        }
      
        public Add_Item_SpecificationDTO getitemspecification(Add_Item_SpecificationDTO dto)
        {
            return _inter.getitemspecification(dto);
        }
        public Add_Item_SpecificationDTO editspecification(Add_Item_SpecificationDTO dto)
        {
            return _inter.editspecification(dto);
        }

    }
}
