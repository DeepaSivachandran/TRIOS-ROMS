using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_GoodsOutward
    {
        public int ViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int ParaGOId { get; set; } = 0;
        public int ParaCompanyCode { get; set; } = 0;
        public string paraOutwardDate { get; set; } = "";
        public int paraSLID { get; set; } = 0;
        public int paraTransferType { get; set; } = 0;
        public string paraRemarks { get; set; } = "";
        public int paraStatusId { get; set; } = 0;
        public int paraPRID { get; set; } = 0;
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public int ParaFlag { get; set; } = 0;
        public int paraCompletedby { get; set; } = 0;
        public DataTable paraStockTransfer { get; set; } = null;
        public string paraTeller { get; set; } = "";
        public string paraUserLocations { get; set; } = "";
        public DataTable paraStockChild { get; set; } = null;
        public DataTable paraStockConversion { get; set; } = null;
        public int paraTypeID { get; set; } = 0;
    }
}
