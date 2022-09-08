using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Admin
{
    public interface IOrderWise_Report
    {
        OrderWise_ReportDTO get_data(OrderWise_ReportDTO dto);
        OrderWise_ReportDTO payment_details(OrderWise_ReportDTO dto);
        OrderWise_ReportDTO get_payment_data(OrderWise_ReportDTO dto);
    }
}
