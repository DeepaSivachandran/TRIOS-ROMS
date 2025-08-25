using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    public class TRN_Advance
    {
        public int ViewType { get; set; } = 0;
        public int paraAdvanceId { get; set; } = 0;
        public int ParaCompanycode { get; set; } = 0;
        public string paraAdvanceDate { get; set; } = "";
        public int paraSupplierId { get; set; } = 0;
        public int paraScheduleId { get; set; } = 0;
        public decimal ParaAmt { get; set; } = 0;
        public int paraDeleteFlag { get; set; } = 0;
        public string paraOriginator { get; set; } = "";
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public int paraStatusID { get; set; } = 0;
        public int paraPAYID { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public int paraPaymentMode { get; set; } = 0;
        public int paraPaymentType { get; set; } = 0;
        public int paraBankId { get; set; } = 0;
        public int paraModeOfIssue { get; set; } = 0;
        public string paraIssueDetails { get; set; } = "";
        public string paraChequeDate { get; set; } = "";
        public string paraChequeNo { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public int paraAmountType { get; set; } = 0;
    }
}
