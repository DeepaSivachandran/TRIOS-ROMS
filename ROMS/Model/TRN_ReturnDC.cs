using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ROMS.Model
{
    public class TRN_ReturnDC
    {
        public int paraViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int paraCompanyId { get; set; } = 0;
        public string paraReturnDC_Date { get; set; } = "";
        public string paraReturnDC_NO { get; set; } = "";
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public int ParaSupplierId { get; set; } = 0;
        public int ParaScheduleID { get; set; } = 0;
        public int paraDcID { get; set; } = 0;
        public int ParaPO { get; set; } = 0;
        public int ParaSupplier { get; set; } = 0;
        public string paraReturnDC_Remarks { get; set; } = "";
        public string paraDCIDs { get; set; } = "";
        public int paraStatusID { get; set; } = 0;
        public int paraReturnDCID { get; set; } = 0;
        public int ParaGroupID { get; set; } = 0;
        public int ParaSubGroupID { get; set; } = 0;
        public int paraReasonId { get; set; } = 0;
        public int paraClosingReasonId { get; set; } = 0;
        public decimal paraReturnDCAmount { get; set; } = 0;
        public string paraCreditNoteNo { get; set; } = "";
        public string paraExchangeRemarks { get; set; } = "";
        public string paraCreditNoteDate { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public double paraDeleteFlag { get; set; } = 0;
        public  decimal ParaSubtotal { get; set; } = 0;
        public decimal paraTax { get; set; } = 0;
        public int paraPurchaseId { get; set; } = 0;
        public int paraFlag { get; set; } = 0;
        public int paraUpdateflag { get; set; } = 0;
        public int paraVerifiedBy { get; set; } = 0;
        public int paraProductId { get; set; } = 0;
        public DataTable paraTRN_Purchase_ReturnDC { get; set; } = null;
        public DataTable ParaTRN_ReturnDCProducts { get; set; } = null;
    }
}
