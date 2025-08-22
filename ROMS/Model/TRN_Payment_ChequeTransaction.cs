using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_Payment_ChequeTransaction
    { 
        public int paraViewType { get; set; } = 0;
        public string paraUserID { get; set; } = "";
        public string paraIPAddress { get; set; } = "";
        public int paraSupplierId { get; set; } = 0;
        public int paraScheduleId { get; set; } = 0;
        public int paraCompanyId { get; set; } = 0;
        public int paraID { get; set; } = 0;
        public string ParaFromDate { get; set; } = "";
        public string ParaToDate { get; set; } = "";
        public int paraPYID { get; set; } = 0;
        public string paraOriginator { get; set; } = "";
        public string paraHostName { get; set; } = "";

        public string paraChequeDate { get; set; } = "";
        public int paraPAYID { get; set; } = 0;
        public string paraChequeNo { get; set; } = "";
        public decimal paraAmount { get; set; } = 0;
        public string paraPAYNo { get; set; } = "";
        public int paraSupplierID { get; set; } = 0;

    }
}
