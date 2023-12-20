using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ROMS.Model
{
    public class TRN_Purchase_DC
    {
        public int ViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int paraCompanyId { get; set; } = 0;
        public string paraDC_Date { get; set; } = "";
        public string paraDC_NO { get; set; } = "";
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public int paraSupplierID { get; set; } = 0;
        public int paraScheduleID { get; set; } = 0;
        public string paraDC_Remarks { get; set; } = "";
        public int paraDC_PURID { get; set; } = 0;
        public int paraStatusID { get; set; } = 0;
        public int paraDCID { get; set; } = 0;
        public int paraDeleteFlag { get; set; } = 0;
        public DataTable ParaTRN_Purchase_DC { get; set; } = null;
    }
    
}
