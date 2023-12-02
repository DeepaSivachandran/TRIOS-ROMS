using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    public class TRNG_StockRequest
    {
        public int paraViewType { get; set; } = 0;
        public int paraStockRequestID { get; set; } = 0;
        public int paraConcern { get; set; } = 0;
        public int paraPRID { get; set; } = 0;
        public int paraStatus { get; set; } = 0;
        public string ParaSTFromDate { get; set; } = "";
        public string ParaSTToDate { get; set; } = "";

    }
}
