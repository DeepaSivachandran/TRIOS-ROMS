using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_DebitNote
    {
        public int ViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public int paraCompanyCode { get; set; } = 0;
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public string paraDebit_Remarks { get; set; } = "";
        public int paraSupplierID { get; set; } = 0;
        public string paraOriginator { get; set; } = "";
        public string paraDebit_Date { get; set; } = "";
        public string paraDebit_NO { get; set; } = "";
        public int paraScheduleID { get; set; } = 0;
        public int paraStatusID { get; set; } = 0;
        public int paraDebitID { get; set; } = 0;
        public int paraReasonId { get; set; } = 0;
        public decimal paraDebitAmount { get; set; } = 0;
        public decimal ParaSubtotal { get; set; } = 0;
       public int paraDCID { get; set; } = 0;
       public int paraPurchaseId { get; set; } = 0;
       public decimal paraTax { get; set; } = 0;
       public decimal paraAmount { get; set; } = 0;
       public DataTable paraTRN_DebitNote { get; set; } = null;
    }
}
