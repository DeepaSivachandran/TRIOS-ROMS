using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_Supplier_Payment
    {
        public int ViewType { get; set; } = 0;
        public int paraSupplierid { get; set; } = 0;
        public int paraScheduleId { get; set; } = 0;
        public int paraCompanyId { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraPaymentDate { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int paraPaymode { get; set; } = 0;
        public int paraPayType { get; set; } = 0;
        public string paraChequeDate { get; set; } = "";
        public string paraChequeNo { get; set; } = "";
        public int paraPYID { get; set; } = 0;
        public decimal paraTotalAmnt { get; set; } = 0;
        public int paraSTSID { get; set; } = 0;
        public int paraID { get; set; } = 0;
        public int paraBankID { get; set; } = 0;
        public decimal paraAdvanceAmnt { get; set; } = 0;
        public decimal paraSubTotal { get; set; } = 0;
        public string paraAdvanceID { get; set; } = "";
        public string ParaToDate { get; set; } = "";
        public string paraFromDate { get; set; } = "";
        public int paraDeleteFlag { get; set; } = 0;
        public int paraComBank { get; set; } = 0;
        public string paraHostName { get; set; } = "";
        public DataTable paraPayment { get; set; } = null;
        public DataTable paradtparaAdvance { get; set; } = null;
        public string paraPurchaseID { get; set; } = "";
        public int paraSource { get; set; } = 0;
        public int paraModeOfIssue { get; set; } = 0;
        public int paraChequeLimitDays { get; set; } = 0;
        public string paraModeOfIssue_Details { get; set; } = "";
    }
}
