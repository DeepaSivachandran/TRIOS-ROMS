using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    public class TRN_PurchaseEntry
    { 
        public int ViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public string ParaPEFromDate { get; set; } = "";
        public string ParaToFromDate { get; set; } = "";
        public int ParaGRNID { get; set; } = 0;
        public int paraCompanyId { get; set; } = 0; 
        public int paraSupplierID { get; set; } = 0;
        public string ParaExpiryDate { get; set; } = "";
        public string ParaPEDate { get; set; } = "";
        public int paraScheduleID { get; set; } = 0; 
        public int paraProductId { get; set; } = 0; 
        public string paraINVNo { get; set; } = "";
        public decimal ParaInvAmt { get; set; } = 0;  
        public int paraflag { get; set; } = 0; 
        public int paraStatus { get; set; } = 0; 
        public string ParaPOIds { get; set; } = ""; 
    }
}
