using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    public class TRN_DiscountVoucher
    {
        public int ViewType { get; set; } = 0;
        public int paraDiscountId { get; set; } = 0;
        public int ParaCompanycode { get; set; } = 0;
        public string paraDiscountDate { get; set; } = "";
        public int paraSupplierId { get; set; } = 0;
        public int paraScheduleId { get; set; } = 0;
        public decimal ParaDiscountAmt { get; set; } = 0;
        public int paraDeleteFlag { get; set; } = 0;
        public string paraOriginator { get; set; } = "";
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public int paraStatusID { get; set; } = 0;
        public string paraRemarks { get; set; } = "";
        public int paraPURID { get; set; } = 0;
        public int paraGRNID { get; set; } = 0;
    }
}
