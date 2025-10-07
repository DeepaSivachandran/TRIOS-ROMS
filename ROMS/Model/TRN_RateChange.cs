using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_RateChange
    {
        public int paraViewType { get; set; } = 0;
        public int paraProductID { get; set; } = 0;
        public double paraRRate { get; set; } = 0;
        public double paraWRate { get; set; } = 0;
        public string paraTeller { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int paraGroupID { get; set; } = 0;
        public int paraSubGroupID { get; set; } = 0;
        public int paraBrandID { get; set; } = 0;
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public int paraType { get; set; } = 0;
        public int paraSupplierID { get; set; } = 0;
        public int paraScheduleID { get; set; } = 0;
    }
}
