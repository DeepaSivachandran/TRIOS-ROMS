using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ROMS.Model
{
    public class TRN_Purchase_ReturnDC
    {
        public int ViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int paraCompanyId { get; set; } = 0;
        //public string paraDC_Date { get; set; } = "";
        //public string paraDC_NO { get; set; } = "";
        //public string paraFromDate { get; set; } = "";
        //public string paraToDate { get; set; } = "";
        public int paraSupplierID { get; set; } = 0;
        public int paraScheduleID { get; set; } = 0;
        public int paraStatusID { get; set; } = 0;
       
        public DataTable ParaTRN_Purchase_DC { get; set; } = null;
    }
    
}
