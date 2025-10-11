using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_GoodsInward
    {
        public int ViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int paraGIID { get; set; } = 0;
        public int paraCompanyCode { get; set; } = 0;
        public string paraInwardDate { get; set; } = "";
        public int paraSLID { get; set; } = 0;
        public int paraTransferType { get; set; } = 0;
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public int paraPRID { get; set; } = 0;
        public int paraStatusId { get; set; } = 0;
        public string paraRemarks { get; set; } = "";
        public int paraDeleteFlag { get; set; } = 0;
        public int paraFlag { get; set; } = 0;
        public int paraSTRID { get; set; } = 0;
        public DataTable paraGoodsInward { get; set; } = null;
        public string paraUserLocations { get; set; } = "";
    }
}
