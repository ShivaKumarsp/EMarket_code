using EMarket.BLL.Comman_Class.Interface;
using EMarket.BLL.Interfaces.Master;
using EMarket.DLL.Interfaces.Master;
using EMarket.Entities;
using EMarket.Entities.Master;
using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Master
{
    public class Master_Specification : IMaster_Specification
    {
        IMaster_Specification_Repository _inter;
        PostgreSqlContext _context;
        ISqlClass _sql;
        IErrorClass _error;
        IDuplicateCheck _duplicate;
        int status = 0;
        string return_string = "";

        public Master_Specification(PostgreSqlContext context, ISqlClass sql, IErrorClass error, IDuplicateCheck duplicate,
            IMaster_Specification_Repository inter)
        {
            _context = context;
            _sql = sql;
            _error = error;
            _duplicate = duplicate;
            _inter = inter;
        }

        // Specification
        public Master_SpecificationDTO get_data_specification(Master_SpecificationDTO dto)
        {
            dto.specification_list = _context.Master_SpecificationDMO_con.Where(a => a.language_id == dto.language_id).OrderBy(a => a.specification_name).ToArray();
            return dto;
        }
        public Master_SpecificationDTO save_specification(Master_SpecificationDTO dto)
        {
         
            var page_form = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            string methodname = "Master_specification/save_specification";

            if (dto.specification_name == "")
            {
                dto.status = "Failed";
                dto.message = "Please Insert Specification Name";
                return dto;
            }
           
            if (dto.specification_id> 0)
            {
                var spec = _context.Master_SpecificationDMO_con.Where(a => a.specification_name.Trim() == dto.specification_name.Trim()
                && a.specification_id!=dto.specification_id).ToList();
                if (spec.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "Specification Already Exist";
                    return dto;
                }

                try
                {
                    _inter.save_specification(dto);
                }
             catch(Exception ex)
                {
                    _error.errorlog_add(ex, dto.user_id, methodname, dto.ipAddress, dto.apitype, page_form, dto.procedure_name, dto.inputvalue);
                }
            }
            else
            {
                var spec = _context.Master_SpecificationDMO_con.Where(a => a.specification_name.Trim() == dto.specification_name.Trim()).ToList();
                if (spec.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "Specification Already Exist";
                    return dto;
                }

                if (dto.language_id == 1)
                {
                    long result = 0;
                    var result11 = _context.Master_SpecificationDMO_con.ToList();
                    if(result11.Count>0)
                    {
                        result = _context.Master_SpecificationDMO_con.Max(a => a.specification_id);
                    }
                   
                    Master_SpecificationDMO dmo = new Master_SpecificationDMO();
                    dmo.specification_id = result + 1;
                    dmo.specification_name = dto.specification_name.Trim();
                    dmo.specification_code = dto.specification_code.Trim();
                    dmo.is_active = true;
                    dmo.language_id = dto.language_id;
                    _context.Add(dmo);
                    var ss = _context.SaveChanges();
                    if (ss > 0)
                    {
                        dto.status = "Insert";
                        dto.message = "Specification Inserted Successfully";
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Specification Not Inserted";
                    }
                }

            }
            dto.specification_list = _context.Master_SpecificationDMO_con.Where(a => a.language_id == dto.language_id).OrderBy(a => a.specification_name).ToArray();
            return dto;
        }
        // Atribute name
        public Master_SpecificationDTO get_data_attrname(Master_SpecificationDTO dto)
        {
            dto.attrname_list = _context.Master_Attribute_NameDMO_con.Where(a => a.language_id == dto.language_id).OrderBy(a=>a.attribute_name).ToArray();
            return dto;
        }
        public Master_SpecificationDTO save_attrname(Master_SpecificationDTO dto)
        {
            if (dto.attribute_name == "")
            {
                dto.status = "Failed";
                dto.message = "Please Insert Attribute Name";
                return dto;
            }
            
            if (dto.attribute_name_id > 0)
            {
                var spec = _context.Master_Attribute_NameDMO_con.Where(a => a.attribute_name.Trim() == dto.attribute_name.Trim() && a.attribute_name_id!=dto.attribute_name_id).ToList();
                if (spec.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "Attribute Already Exist";
                    return dto;
                }
                _inter.save_attrname(dto);
;               
            }
            else
            {
                var spec = _context.Master_Attribute_NameDMO_con.Where(a => a.attribute_name.Trim() == dto.attribute_name.Trim() ).ToList();
                if (spec.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "Attribute Already Exist";
                    return dto;
                }

                if (dto.language_id == 1)
                {
                      var result = _context.Master_Attribute_NameDMO_con.Max(a => a.attribute_name_id);
                    Master_Attribute_NameDMO dmo = new Master_Attribute_NameDMO();
                    dmo.attribute_name_id = result+1;
                    dmo.attribute_name = dto.attribute_name.Trim();
                    dmo.attribute_code = dto.attribute_code.Trim();
                    dmo.is_active = true;
                    dmo.language_id = dto.language_id;
                    _context.Add(dmo);
                    var ss = _context.SaveChanges();
                    if (ss > 0)
                    {
                        dto.status = "Insert";
                        dto.message = "Attribute Inserted Successfully";
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Attribute Not Inserted";
                    }
                }             

            }
            dto.attrname_list = _context.Master_Attribute_NameDMO_con.Where(a => a.language_id == dto.language_id).OrderBy(a => a.attribute_name).ToArray();
            return dto;
        }

        // Atribute value
        public Master_SpecificationDTO get_data_attrvalue(Master_SpecificationDTO dto)
        {
            dto.attrname_dd = _context.Master_Attribute_NameDMO_con.Where(a => a.language_id == dto.language_id).OrderBy(a => a.attribute_name_id).ToArray();

            dto.attrvalue_list  = (from a in _context.Master_Attribute_ValueDMO_con
                               from b in _context.Master_Attribute_NameDMO_con
                               where a.attribute_name_id == b.attribute_name_id && a.language_id==dto.language_id && b.language_id==dto.language_id
                               select new Master_SpecificationDTO
                               {
                                   attribute_value_id = a.attribute_value_id,
                                   attribute_name_id=a.attribute_name_id,
                                   attribute_name=b.attribute_name,
                                   attribute_value = a.attribute_value,
                                   attribute_code = a.attribute_code,
                                   is_active = a.is_active,
                                   language_id = a.language_id,
                               }).OrderBy(a => a.attribute_name).ToArray();
                
          
            return dto;
        }
        public Master_SpecificationDTO save_attrvalue(Master_SpecificationDTO dto)
        {
            if (dto.attribute_value == "")
            {
                dto.status = "Failed";
                dto.message = "Please Insert Attribute Value";
                return dto;
            }
            
            if (dto.attribute_value_id > 0)
            {
                var spec = _context.Master_Attribute_ValueDMO_con.Where(a => a.attribute_value.Trim() == dto.attribute_value.Trim() && a.attribute_value_id!=dto.attribute_value_id).ToList();
                if (spec.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "Attribute Value Already Exist";
                    return dto;
                }

                _inter.save_attrvalue(dto);
            }
            else
            {
                var spec = _context.Master_Attribute_ValueDMO_con.Where(a => a.attribute_value.Trim() == dto.attribute_value.Trim() && a.attribute_name_id == dto.attribute_name_id).ToList();
                if (spec.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "Attribute Value Already Exist";
                    return dto;
                }

                if (dto.language_id == 1)
                { 
                    long result = 0;
                    var result11 = _context.Master_Attribute_ValueDMO_con.ToList();
                    if(result11.Count>0)
                    {
                    result = _context.Master_Attribute_ValueDMO_con.Max(a => a.attribute_value_id);
                    }
                   
                    Master_Attribute_ValueDMO dmo = new Master_Attribute_ValueDMO();
                    dmo.attribute_value_id = result + 1;
                    dmo.attribute_name_id = dto.attribute_name_id;
                    dmo.attribute_value = dto.attribute_value.Trim();
                    dmo.attribute_code = dto.attribute_code.Trim();
                    dmo.is_active = true;
                    dmo.language_id = dto.language_id;
                    _context.Add(dmo);
                    var ss = _context.SaveChanges();
                    if (ss > 0)
                    {
                        dto.status = "Insert";
                        dto.message = "Attribute Value Inserted Successfully";
                    }
                    else
                    {
                        dto.status = "Failed";
                        dto.message = "Attribute Value Not Inserted";
                    }
                }

            }
            dto.attrname_dd = _context.Master_Attribute_NameDMO_con.Where(a => a.language_id == dto.language_id).OrderBy(a => a.attribute_name).ToArray();
            dto.attrvalue_list = (from a in _context.Master_Attribute_ValueDMO_con
                                  from b in _context.Master_Attribute_NameDMO_con
                                  where a.attribute_name_id == b.attribute_name_id && a.language_id == dto.language_id && b.language_id == dto.language_id
                                  select new Master_SpecificationDTO
                                  {
                                      attribute_value_id = a.attribute_value_id,
                                      attribute_name_id = a.attribute_name_id,
                                      attribute_name = b.attribute_name,
                                      attribute_value = a.attribute_value,
                                      attribute_code = a.attribute_code,
                                      is_active = a.is_active,
                                      language_id = a.language_id,
                                  }).OrderBy(a => a.attribute_name).ToArray();
            return dto;
        }
        public Master_SpecificationDTO delete_specidfication(Master_SpecificationDTO dto)
        {
            

                var result = _context.Master_Additionalcat_Specification_Map_con.Where(a => a.specification_id == dto.specification_id).ToList();
                if (result.Count > 0)
                {
                    dto.status = "Failed";
                    dto.message = "This Specification Mapped with Category, You cant Delete";
                    return dto;
                }
            else
            {
                _inter.delete_specidfication(dto);
            }
            dto.specification_list = _context.Master_SpecificationDMO_con.Where(a => a.language_id == dto.language_id).OrderBy(a => a.specification_name).ToArray();


            return dto;
        }
    }
}
