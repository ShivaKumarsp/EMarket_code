using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.Interfaces.Admin;
using EMarket.Entities;
using EMarketDTO.Master;
using LiteX.DbHelper.Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class Item_Verification : IItem_Verification
    {
        IItem_Verification_Repository _inter;
        PostgreSqlContext _context;    
        ISqlClass _sql;
        IErrorClass _error;
        public Item_Verification(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IItem_Verification_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _inter = inter;
        }

        public Item_VerificationDTO Get_Item(Item_VerificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "item_verification/Get_Item";
            var Params = new DbParameter[] { };
            try
            {
                //item list
                var dbParams = new DbParameter[]
                                  {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_flag", "Pending"),
                                  };
                Params = dbParams;
                dto.procedure_name = "fn_get_verify_items_list";
                dto.itemlist = _sql.Get_Data(dto.procedure_name, dbParams);               
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        public Item_VerificationDTO Get_Reviewitem(Item_VerificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "item_verification/Get_Reviewitem";
            var Params = new DbParameter[] { };

            try
            {
                //item view
                var dbParams = new DbParameter[]
                                  {
                      DbHelper.CreateParameter("in_item_id", dto.item_id),
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
                                  };
                Params = dbParams;
                dto.procedure_name = "fn_get_verify_item";
                dto.view_item = _sql.Get_Data(dto.procedure_name, dbParams);

                // get warrantyuom
                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                    };
                dto.procedure_name = "fn_getwarrantyuom";
                Params = dbParams1;
                dto.warrantytypelist = _sql.Get_Data(dto.procedure_name, dbParams1);


                var dbParams2 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                    };
                dto.procedure_name = "fn_get_verify_product";
                Params = dbParams2;
                dto.verify_product = _sql.Get_Data(dto.procedure_name, dbParams2);

                // Speficfication
                var dbParams3 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                   };
                dto.procedure_name = "fn_get_verify_item_specification";
                Params = dbParams3;
                dto.verify_item_specification = _sql.Get_Data(dto.procedure_name, dbParams3);


                var dbParams4 = new DbParameter[]
         {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
         };
                dto.procedure_name = "fn_get_itemfeatures";
                Params = dbParams4;
                dto.feature_list = _sql.Get_Data(dto.procedure_name, dbParams4);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
        //update review status
        public Item_VerificationDTO Upadate_Status(Item_VerificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "item_verification/Upadate_Status";
            var Params = new DbParameter[] { };
            if(dto.item_id==0&& dto.verify_status == "" && dto.remarks=="")
            {
                dto.status = "Failed";
                dto.message = "Please Enter Mandotary Field";
                return dto;
            }
            try
            {
                
                _inter.Upadate_Status(dto);
            }
            catch(Exception ex)
            {
                _error.errorlog_add(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
            }
            try
            {
                //item view
                var dbParams = new DbParameter[]
                                  {
                      DbHelper.CreateParameter("in_item_id", dto.item_id),
                      DbHelper.CreateParameter("in_language_id", dto.language_id)
                                  };
                Params = dbParams;
                dto.procedure_name = "fn_get_verify_item";
                dto.view_item = _sql.Get_Data(dto.procedure_name, dbParams);

                // get warrantyuom
                var dbParams1 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("planguageid", dto.language_id)
                    };
                dto.procedure_name = "fn_getwarrantyuom";
                Params = dbParams1;
                dto.warrantytypelist = _sql.Get_Data(dto.procedure_name, dbParams1);


                var dbParams2 = new DbParameter[]
                    {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                    };
                dto.procedure_name = "fn_get_verify_product";
                Params = dbParams2;
                dto.verify_product = _sql.Get_Data(dto.procedure_name, dbParams2);

                // Speficfication
                var dbParams3 = new DbParameter[]
                   {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
                   };
                dto.procedure_name = "fn_get_verify_item_specification";
                Params = dbParams3;
                dto.verify_item_specification = _sql.Get_Data(dto.procedure_name, dbParams3);


                var dbParams4 = new DbParameter[]
         {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_item_id", dto.item_id)
         };
                dto.procedure_name = "fn_get_itemfeatures";
                Params = dbParams4;
                dto.feature_list = _sql.Get_Data(dto.procedure_name, dbParams4);


            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }

            return dto;
        }

        // item list
        public Item_VerificationDTO get_all_Item(Item_VerificationDTO dto)
        {
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "item_verification/Get_All_Item";
            var Params = new DbParameter[] { };
            try
            {
                //item list
                var dbParams = new DbParameter[]
                                  {
                      DbHelper.CreateParameter("in_language_id", dto.language_id),
                      DbHelper.CreateParameter("in_flag", "All"),
                                  };
                Params = dbParams;
                dto.procedure_name = "fn_get_verify_items_list";
                dto.itemlist = _sql.Get_Data(dto.procedure_name, dbParams);
            }
            catch (Exception ex)
            {
                _error.errorlog(ex, dto.userid, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, Params);
            }
            return dto;
        }
    }
}
