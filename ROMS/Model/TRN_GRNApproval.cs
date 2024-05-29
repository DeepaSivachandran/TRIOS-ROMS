using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_GRNApproval
    {
        public int ViewType { get; set; } = 0;
        public int paraPURID { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public int paraFlag { get; set; } = 0;
        public int paraCompanyId { get; set; } = 0;
        public int paraSupplierID { get; set; } = 0;
        public int paraScheduleID { get; set; } = 0;
        public string paraReturnDC_Date { get; set; } = "";
        public DataTable paraApprovalProduct { get; set; } = null;
        public DataTable paraTRN_Purchase_ReturnDC { get; set; } = null;
        public int ParaGRNAID { get; set; } = 0;
        public int ParaGRNAPRID { get; set; } = 0;
    }
}
