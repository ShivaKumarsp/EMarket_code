using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Customer
{
    public interface ILanding_Service
    {
        PublicLandingDTO getdata(PublicLandingDTO dto);
        PublicLandingDTO get_public_productdetails(PublicLandingDTO dto);
        PublicLandingDTO get_specification(PublicLandingDTO dto);
        PublicLandingDTO get_specification_details(PublicLandingDTO dto);
        PublicLandingDTO attributecheck(PublicLandingDTO dto);
        PublicLandingDTO get_subcategory(PublicLandingDTO dto);
        PublicLandingDTO get_addcategory(PublicLandingDTO dto);
        PublicLandingDTO getdata_footer(PublicLandingDTO dto);
    }
}
