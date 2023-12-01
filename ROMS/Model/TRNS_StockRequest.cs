using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    public class TRNS_StockRequest
    {
        public int ViewType { get; set; } = 0;
        public int paraStockRequestID { get; set; } = 0;
        public int ParaCompanycode { get; set; } = 0;
        public string paraRequestDate { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public int paraStatusId { get; set; } = 0;
        public string paraOriginator { get; set; } = "";
        public DataTable paraStockRequest { get; set; } = null;
    }
}
