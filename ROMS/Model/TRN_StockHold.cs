using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_StockHold
    {
        public int ViewType { get; set; } = 0;
        public int paraSHID { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public int paraCompanycode { get; set; } = 0;
        public int paraPRID { get; set; } = 0;
        public int paraSLID { get; set; } = 0;
        public int paraRKID { get; set; } = 0;
        public decimal paraMrp { get; set; } = 0;
        public string paraExpiryDate { get; set; } = "";
        public string paraBatchNo { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public string paraAlpha { get; set; } = "";
        public int paraUTID { get; set; } = 0;
        public decimal paraQty { get; set; } = 0;
        public int paraFlag { get; set; } = 0;
        public int paraReason { get; set; } = 0;
        public int paraSupplierID { get; set; } = 0;
        public int paraScheduleID { get; set; } = 0;
        public int paraStatus { get; set; } = 0;
        public int paraStockQty { get; set; } = 0;
        public int paraParentSHID { get; set; } = 0;
        public int paraDeleteFlag { get; set; } = 0;
        public string paraSHIds { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public string paraTeller { get; set; } = "";

    }
}
