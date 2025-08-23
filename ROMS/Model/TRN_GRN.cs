using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    public class TRN_GRN
    {
        public int ViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int ParaGRNID { get; set; } = 0;
        public int paraCompanyId { get; set; } = 0;
        public string paraSkipped { get; set; } = "";
        public int paraSupplierID { get; set; } = 0;
        public int paraScheduleID { get; set; } = 0;
        public string paraGRNDate { get; set; } = "";
        public string paraINVDate { get; set; } = "";
        public string paraINVNo { get; set; } = "";
        public decimal ParaInvAmt { get; set; } = 0;
        public string ParaUnLoadingCharge { get; set; } = "";
        public string ParaFrightCharge { get; set; } = "";
        public int paraOrderType { get; set; } = 0;
        public string paraPAckage { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public DataTable ParaTRN_GRN_PO { get; set; } = null;
        public int ParaVerify1 { get; set; } = 0;
        public int ParaVerify2 { get; set; } = 0;
        public string ParaVerifyDate1 { get; set; } = "";
        public string ParaVerifyDate2 { get; set; } = "";
        public int paraflag { get; set; } = 0;
        public string ParaPurchaseDC { get; set; } = "0"; 
        public int paraStatus { get; set; } =0;
        public int paraDeleteFlag { get; set; } =0;
        public int ParaEditFlag { get; set; } =0;
        public int paraID { get; set; } =0;
        public DataTable paraGRNProd { get; set; } =null;
        public byte[] paraQrimg { get; set; } =null;
        public int paraSaveFlag { get; set; } = 0;
        public string paraVerifiedTime1 { get; set; } = "";
        public string paraVerifiedTime2 { get; set; } = "";
        public string paraVerifiedFormat1 { get; set; } = "";
        public string paraVerifiedFormat2 { get; set; } = "";
        public int paraPayment { get; set; } = 0;
        public string paraCompletedIDs { get; set; } = "";
        public int paraADID { get; set; } = 0;

    }
}
