using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_Stock
    {
        public int ViewType { get; set; } = 0;
        public int paraPRID { get; set; } = 0;
        public int paraCOMID { get; set; } = 0;
        public int paraSLID { get; set; } = 0;
        public int paraMonth { get; set; } = 0;
        public string paraPICode { get; set; } = "";
        public int paraGroupID { get; set; } = 0;
        public int paraSubGroupID { get; set; } = 0;
        public int paraBrandID { get; set; } = 0;
        public int paraStockType { get; set; } = 0;
        public int paraDays { get; set; } = 0;
        public int paraOrder { get; set; } = 0;
        public int paraFilterType { get; set; } = 0;
        public string paraUserLocations { get; set; } = "";

        public int paraType { get; set; } = 0;
        public string paraAlpha { get; set; } = "";
        public int paraNameType { get; set; } = 0;
        public int paraBlockedFlag { get; set; } = 0;
        public int paraReportType { get; set; } = 0;
        public int paraSupplierId { get; set; } = 0;
        public int paraCategoryID { get; set; } = 0;
        public string paraDate { get; set; } = "";
        public int paraFlag { get; set; } = 0;
        public int paraUnitId { get; set; } = 0;
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
    }      
}
