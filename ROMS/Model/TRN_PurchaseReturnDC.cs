using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ROMS.Model
{
    public class TRN_PurchaseReturnDC
    {
        public int ViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int paraCompanyId { get; set; } = 0;
        public string paraReturnDC_Date { get; set; } = "";
        public string paraReturnDC_NO { get; set; } = "";
        public int paraSupplierID { get; set; } = 0;
        public int paraScheduleID { get; set; } = 0;
        public string paraReturnDC_Remarks { get; set; } = "";
        public int paraStatusID { get; set; } = 0;
        public int paraReturnDCID { get; set; } = 0;
        public int paraReasonId { get; set; } = 0;
        public int paraClosingReasonId { get; set; } = 0;
        public float paraReturnDCAmount { get; set; } = 0;
        public string paraCreditNoteNo { get; set; } = "";
        public string paraCreditNoteDate { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public float ParaSubtotal { get; set; } = 0;
        public float paraTax { get; set; } = 0;
        public DataTable paraTRN_Purchase_ReturnDC { get; set; } = null;
    }
}
