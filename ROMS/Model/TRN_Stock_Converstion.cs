using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_Stock_Converstion
    {

        public int ViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int ParaTransactionId { get; set; } = 0;
        public int ParaCompanyCode { get; set; } = 0;
        public string paraOutwardDate { get; set; } = "";
        public int paraSLID { get; set; } = 0;
        public int paraTransferType { get; set; } = 0;
        public string paraRemarks { get; set; } = "";
        public int paraStatusId { get; set; } = 0;
        public int paraPRID { get; set; } = 0;
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public int ParaFlag { get; set; } = 0;
        public int paraDeleteflag { get; set; } = 0;
        public int paraTransType { get; set; } = 0;
        public DataTable paraStockConversion { get; set; } = null;
        public DataTable paraStockTransfer { get; set; } = null;
        public string paraUserLocations { get; set; } = "";
    }
}

 
